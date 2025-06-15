function InitApp(appid, MODULEID, BLOCKSSUFFIX, EDITABLE, TOGGLEABLE) {
    const { createApp, reactive } = Vue;
    const myStore = new reactive({
        changed:null
    })
    const app = createApp({
        setup() {
            return {
                myStore
            }
        },
        data() {
            return {
                blocks: [],
                editable: EDITABLE,
                toggleable: TOGGLEABLE,
                toggling: false
            }
        },
        components: {
            BlocksEditor
        },
        methods: {
            isEditable() {
                if (this.toggleable) 
                    return this.toggling;
                else 
                    return this.editable;                
            },
            getBlocks() {
                _yemon[MODULEID].service.getData("/GetItem", {
                    name: 'blockscontent:' + BLOCKSSUFFIX
                }, (r) => {
                    this.blocks = [];
                    if (r.data) {
                        this.blocks = JSON.parse(r.data);
                       
                    }
                    this.$forceUpdate();
                }
                    //, (e) => {
                    //toastr["error"]("Erreur : " + e.response.data);
                    //}
                )
            },
            toggle(v) {
                this.toggling = v;
            },
            changed() {
                _yemon[MODULEID].service.postData("/SetItem", {
                    name: 'blockscontent:' + BLOCKSSUFFIX,
                    value: JSON.stringify(this.blocks),
                    keephistory:false
                }, (r) => {
                    if (r.status != 200) {
                        toastr["error"]("Erreur");
                    }
                    this.changed = false;
                    toastr["success"]("Enregistré");
                    this.$nextTick(() => { this.$forceUpdate() });
                    
                }
                , (e) => {
                    toastr["error"]("Erreur : " + e.response.data.Message);
                    this.$nextTick(() => { this.$forceUpdate() });
                }
                )
            }
        },
        mounted() {
            this.myStore.changed = this.changed;
            this.getBlocks();
        }
    });
   
    app.component('cropper', VueAdvancedCropper.Cropper);
    app.mount('#' + appid);

}