function InitApp(appid, MODULEID, CONTEXT, CRIC, MODE, EDITABLE) {


    const routes = [
        { path: '/', component: News, props: true },
        { path: '/edit/:id', component: NewsEdit, props: true },
        { path: '/view/:id', component: NewsView, props: true }
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
                    cric: CRIC,
                    mode: MODE
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
    app.component('cropper', VueAdvancedCropper.Cropper);
    app.mount('#' + appid);
}