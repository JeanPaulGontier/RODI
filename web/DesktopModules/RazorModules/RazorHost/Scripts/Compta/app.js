function InitApp(appid, MODULEID, CONTEXT, routes) {

    
    
    const router = VueRouter.createRouter({
        history: VueRouter.createWebHashHistory(),
        routes, // short for `routes: routes`,
        //base: window.location.pathname,
    });

    const app = Vue.createApp({
        data() {
            return {
                moduleid: MODULEID,
                context: CONTEXT,
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