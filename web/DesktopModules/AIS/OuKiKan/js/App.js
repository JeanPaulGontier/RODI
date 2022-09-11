var VueApps = [];

function InitVue(CID) {

    VueApps[CID] = Vue.createApp({
        data() {
            return {
                serviceurl: location.pathname + '?cid=' + CID,

                meetings: [],
                users: [],
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
                interval: null

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
            getMeetings() {
                this.getData('getMeetings',
                    {

                    },
                    (r) => {
                        let m = r.data;
                        this.meetings = [];
                        if (m) {
                            m.forEach((mm) => {
                                let mmm = JSON.parse(mm.value);
                                mmm.link = "/oukikan?guid=" + mmm.Guid;
                                this.meetings.push(mmm);
                            });
                        }

                        this.getNbUsers();

                    });

            },
            
            viewCurrentMeeting(m) {
                this.users = [];
                this.currentMeeting = m;
                this.getUsers(m.Guid);
                this.meetingsList = false;
                this.viewMeeting = true;

            },
            editCurrentMeeting(e) {
                this.currentMeeting = e;
                this.meetingsList = false;
                this.editMeeting = true;

            },
            saveMeeting() {
                this.putData('setMeeting', {
                        guid: this.currentMeeting.Guid,
                        meeting: JSON.stringify(this.currentMeeting)
                    },
                    (r) => {
                        if (r.data.Key === "error")
                            alert("Erreur : " + r.data.value);
                        else {
                            this.currentMeeting = null;
                            this.editMeeting = false;
                            this.newMeeting = false;
                            this.meetingsList = true;

                            this.getMeetings();
                        }
                    }
                )
            },
            createMeeting() {
                this.currentMeeting = {
                    Guid: this.guid(),
                    name: "",
                    description: "",
                    link: "",
                    lieu: "",
                    videoConfLink: "",
                    users: [],
                    options: [],
                };
               
               //this.meetings.push(this.currentMeeting);
                this.meetingsList = false;
                this.newMeeting = true;

            },
            getUsers(guid) {
                this.getData('getUsers',
                    {
                        guid: guid
                    },
                    (r) => {
                        let u = r.data;
                        this.users = [];
                        if (u) {
                            u.forEach((uu) => {
                                let uuu = JSON.parse(uu.value);
                                this.users.push(uuu);
                            });
                        }
                        this.viewMeeting = true;
                    });

            },
            addNewUser() {
                this.users.push({
                    Guid: this.guid(),
                    name: "",
                    surname: "",
                    options: [],
                });
                this.$forceUpdate();
                this.$nextTick(() => {
                    this.lastRef = this.$refs.meetingUser.length - 1;
                    this.$refs.meetingUser[this.lastRef].focus();
                });

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
            backToMeetingList(m) {

                let where = this.meetings.findIndex(function (meetings) {
                    return meetings.Guid === m;
                });

                this.meetings[where] = this.currentMeeting;
                this.currentMeeting = null;
                this.editMeeting = false;
                this.newMeeting = false;
                this.meetingsList = true;
            },
            deleteOption(d) {
               
                this.currentMeeting.options.splice(d, 1);
            },
            deleteUser(d) {
                let u = this.users[d];
                this.getData("deleteUser", { meetingguid: this.currentMeeting.Guid,guid: u.Guid });
                this.users.splice(d, 1);
            },
            addNewOption(event) {
              

                this.currentMeeting.options.push({
                    Guid: this.guid(),
                    date: "",
                    heure: ""
                });
                this.$forceUpdate();
                this.$nextTick(() => {
                    this.lastRef = this.$refs.meetingOption.length - 1;

                });

            },
            getNbUsers() {
                this.meetings.forEach((m) => {
                    this.getData("getNbUsers", { guid: m.Guid }, (r) => {
                        m.users = r.data;
                    })
                })
            }

        },
        mounted() {
            this.viewMeeting = false;
            this.editMeeting = false;
            this.currentMeeting = null;
            this.getMeetings();
            this.interval = setInterval(() => { this.getNbUsers() }, 5000);
        }
    }).mount("#AppPane" + CID);
    $("#AppPane" + CID).show();
}