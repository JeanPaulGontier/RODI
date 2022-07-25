var VueApps = [];

function InitVue(CID, GUID) {

    VueApps[CID] = Vue.createApp({
        data() {
            return {
                serviceurl: location.pathname + '?cid=' + CID,
                token:null,
                meetings: [
                   
                    
                ],
                users:[],
              
                viewMeeting: true,
                editMeeting: false,

                editMeeting: false,
                newMeeting: false,
                meetingsList: true,
                meetingParticipants: 0,
                currentMeeting: [],
                lastRef: '',
                delConfirm: false,
                delSelect: '',
                whatIsToday: new Date().toISOString().slice(0, 10),

            };
        },
        methods: {
            getData: function (action, parms, callBackOk, callBackError) {
                var pStr = "&action=" + encodeURIComponent(action);
                for (p in parms) {
                    pStr += "&" + p + "=" + encodeURIComponent(parms[p]);
                }
                axios
                    .get(this.serviceurl + pStr)
                    .then(callBackOk)
                    .catch(callBackError);
            },
            putData: function (action, obj, callBackOk, callBackError) {
                axios
                    .post(this.serviceurl, {

                        Key: action,
                        Value: obj

                    })
                    .then(callBackOk)
                    .catch(callBackError);

            },            
            guid: function () {
                function _p8(s) {
                    var p = (Math.random().toString(16) + "000000000").substr(2, 8);
                    return s ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
                }
                return _p8(false) + _p8(true) + _p8(true) + _p8(false);
            },
            saveUser(u) {
                this.putData("setUser", {
                    guid: u.Guid,
                    meetingguid: this.currentMeeting.Guid,
                    user: JSON.stringify(u)
                }, (r) => {
                    console.log(r.data);
                })
            },
            getMeeting(guid) {
                this.getData('getMeeting',
                    {
                        guid: guid
                    },
                    (r) => {
                        this.currentMeeting = JSON.parse(r.data);
                        this.viewMeeting = true;
                        this.getUsers(this.currentMeeting.Guid);
                    });
                
            },
            getUsers(guid) {
                this.getData('getUsers',
                    {
                        guid: guid
                    },
                    (r) => {
                        let u = r.data;
                        this.users = [];
                        u.forEach((uu) => {
                            let uuu = JSON.parse(uu.value);
                            this.users.push(uuu);
                        });
                        this.viewMeeting = true;
                    });

            },
            addNewUser() {
                this.users.push({
                    Guid: this.guid(),
                    token: this.token,
                    name: "",
                    surname: "",
                    options: [],
                });
                this.$forceUpdate();
                this.$nextTick(() => {
                    this.lastRef = this.$refs.meetingUser.length - 1;
                    this.$refs.meetingUser[this.lastRef].focus();
                });

            }
            
         

        },
        mounted() {
            let token = localStorage.getItem("meeting.token");
            if (token) {
                this.token = token;
            }
            else {
                this.token = this.guid();
                localStorage.setItem("meeting.token", this.token);
            }
            this.viewMeeting = false;
            this.editMeeting = false;
            this.currentMeeting = null;
            this.getMeeting(GUID);
        }
    }).mount("#AppPane" + CID);
    $("#AppPane" + CID).show();
}