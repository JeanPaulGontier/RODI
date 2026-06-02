function InitAppNotif(appid, MODULEID, NOTIFICATIONS) {

    const app = Vue.createApp({
        data() {
            return {
                moduleid: MODULEID,
                notifications: NOTIFICATIONS,
                unopenedcheck: false,
                unread:0,
                notifs: []
            }
        },
        components: {

        },
        
        methods: {
            isCloseDate() {
                var closedDate = localStorage.getItem("notification.closed");;   
                return (closedDate == new Date().toDateString());       
            },
            close() {
                localStorage.setItem("notification.closed", new Date().toDateString());
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

                this.unread = 0;
                this.notifs.forEach((n) => {
                    if (!n.opened) this.unread++;
                });
                    
                
            },
            Peek() {
                _yemon[this.moduleid].service.getData("/Peek", {                   
                }, (r) => {
                    localStorage.setItem("notification.peek", new Date(r.data).toDateString());
                });
            },
            GetNotifications() {
                _yemon[this.moduleid].service.getData("/GetNotifications", {
                    onlyunopened: this.unopenedcheck == "true"
                }, (r) => {
                    this.notifications = r.data;
                    this.UpdateList();
                });
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
            this.$nextTick(() => {
                this.Peek();
                setInterval(() => { this.Peek() }, 10000);
            });
            if (!this.isCloseDate() || this.unread>0)
                this.$nextTick(() => {
                    $("#" + appid).fadeIn();
                });
                
        }
    });
    app.mount('#' + appid);
}
