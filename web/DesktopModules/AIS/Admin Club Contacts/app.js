function InitApp(appid, MODULEID, CONTEXT, CRIC, EDITABLE) {


    const routes = [
        { path: '/', component: Contacts, props: true },
        { path: '/edit/:id', component: ContactsEdit, props: true },       
    ];

    const router = VueRouter.createRouter({
        history: VueRouter.createWebHashHistory(),
        routes, // short for `routes: routes`,
        //base: window.location.pathname,
    });

    const app = Vue.createApp({
        data() {
            return {
                moduleid: MODULEID,
                context: {
                    context: CONTEXT,
                    cric: CRIC                   
                },
                editable: EDITABLE
            }
        },
        components: {
           
        },
        methods: {
           
        },
        mounted() {
          
        }
    });
    app.use(router);
    app.mount('#' + appid);
}