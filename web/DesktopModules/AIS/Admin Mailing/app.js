function InitApp(appid, MODULEID, CONTEXT, CRIC, MODE, EDITABLE) {


    const routes = [
        { path: '/', component: Mailing, props: true },
        {
            path: '/edit/:id',
            component: MailingEdit,
            props: true,
            children: [
                {
                    path: '/',
                    name: 'default',
                    component: MailingEditDest
                },
                {                    
                    path: 'dest',
                    name: 'dest',
                    component: MailingEditDest
                },
                {
                    path: 'content',
                    name: 'content',
                    component: MailingEditContent
                },
                {
                    path: 'preview',
                    name: 'preview',
                    component: MailingEditPreview
                },
                {
                    path: 'send',
                    name: 'send',
                    component: MailingEditSend
                },

            ]
        },
        { path: '/view/:id', component: MailingView, props: true },
        { path: '/edit/:id', component: MailingEdit, props: true }
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
    app.mount('#' + appid);
}