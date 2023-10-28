function InitApp(appid, MODULEID, BLOCKSSUFFIX, EDITABLE) {
    const app = Vue.createApp({
        data() {
            return {
                blocks: [],
                editable: EDITABLE
            }
        },
        components: {
            BlocksEditor
        },
        methods: {
            getBlocks() {
                _yemon[MODULEID].service.getData("/GetItem", {
                    name: 'blockscontent:' + BLOCKSSUFFIX
                }, (r) => {
                    this.blocks = [];
                    if (r.data) {
                        this.blocks = JSON.parse(r.data);
                    }
                    this.$forceUpdate();
                }, (e) => {
                    toastr["error"]("Erreur : " + e.response.data);
                })
            },
            changed(data) {
                if (!data)
                    return;

                _yemon[MODULEID].service.postData("/SetItem", {
                    name: 'blockscontent:' + BLOCKSSUFFIX,
                    value: JSON.stringify(data),
                    keephistory:false
                }, (r) => {
                    //this.changed = false;
                    //toastr["success"]("enregistrée");
                    
                }, (e) => {
                    toastr["error"]("Erreur : " + e.response.data);
                })
            }
        },
        mounted() {
            this.getBlocks();
        }
    });
    app.component('cropper', VueAdvancedCropper.Cropper);

    app.mount('#' + appid);
}