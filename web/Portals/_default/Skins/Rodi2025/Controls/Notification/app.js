function InitAppNotif(appid, MODULEID, NOTIFICATIONS) {

    const app = Vue.createApp({
        data() {
            return {
                moduleid: MODULEID,
                notifications: NOTIFICATIONS,
                unopenedcheck: false,
                notifs: []
            }
        },
        components: {

        },
        
        methods: {
            close() {
                $("#" + appid).fadeOut();
            },
            unopened() {
                var uo = localStorage.getItem("notification.unopened");
                 if (uo != this.unopenedcheck) {
                    this.unopenedcheck = uo
                    this.UpdateUnopened();
                }
                
            },
            UpdateList() {
                if (this.unopenedcheck=="true") {
                    var notifs = [];
                    this.notifications.forEach((n) => {
                        if (!n.opened)
                            notifs.push(n);
                    });
                    this.notifs = notifs;
                } else {
                    this.notifs = this.notifications;
                }
                    
                
            },
            GetDetail(n) {
                return JSON.parse(n.detail);
            },
            Navigate(n) {
                _yemon[this.moduleid].service.getData("/SetOpened", {
                        guid: n.guid,
                        opened:true
                    }, (r) => {
                        if (n.type == 10) {
                            window.location = "/m-" + this.GetDetail(n).value;
                        }
                        
                    }
                    , (e) => {
                    toastr["error"]("Erreur : " + e.response.data.Message);
                    }
                )
            },
            UpdateUnopened() {
                localStorage.setItem("notification.unopened", this.unopenedcheck);
                this.$nextTick(() => {
                    this.UpdateList();
                });
            }
        },
        mounted() {
            setInterval(() => { this.unopened() }, 1000);          
           

                
        }
    });
    app.mount('#' + appid);
}
