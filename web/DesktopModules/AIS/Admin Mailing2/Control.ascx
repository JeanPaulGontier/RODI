<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Mailing_Control" %>
<% 
    string libPath = TabController.CurrentPage.SkinPath + "echoppe/";
    string appID = "app" + ModuleId;

%>
<asp:HiddenField ID="ContextGuid" runat="server" />
<script src="<%=libPath %>tinymce/tinymce.min.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script src="<%=libPath %>vue/3.2.23/vue.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script src="<%=libPath %>vue-router/4.0.12/vue-router.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script src="<%=libPath %>axios/0.24.0/axios.min.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script src="<%=libPath %>toastr/toastr.min.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<link href="<%=libPath %>toastr/toastr.min.css?cdv=<%=Yemon.dnn.Functions.CDV %>" rel="stylesheet" />
<script src="<%=libPath %>vue-easy-tinymce-1.0.2/dist/vue-easy-tinymce.min.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script src="<%=libPath %>vue-advanced-cropper/2.8.8/index.global.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<link href="<%=libPath %>vue-advanced-cropper/2.8.8/style.css?cdv=<%=Yemon.dnn.Functions.CDV %>" rel="stylesheet" />
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/Init.mailing.html" -->
<link href="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/styles.min.css?cdv=<%=Yemon.dnn.Functions.CDV %>" rel="stylesheet" />


<style>
    [v-cloak] {
        display: none;
    }
</style>

<div class="admin" id='<%=appID %>' v-cloak>
     <router-view :moduleid="moduleid" :context="context" :editable="editable"></router-view> 
</div>
<script src="/DesktopModules/Yemon/API/Services/VueJS"></script>
<!-- #include virtual ="/DesktopModules/AIS/Admin Mailing2/Mailing.html" -->
<!-- #include virtual ="/DesktopModules/AIS/Admin Mailing2/MailingEdit.html" -->
<!-- #include virtual ="/DesktopModules/AIS/Admin Mailing2/MailingView.html" -->
<script src="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/app.min.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script src="/DesktopModules/AIS/Admin Mailing2/app.min.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script>

    var CATEGORIES = <%=Yemon.dnn.Functions.Serialize(categories)%>;
    var RECIPIENTS = <%=Yemon.dnn.Functions.Serialize(recipients)%>;

    var SENDER_EMAIL = '<%= sender_email%>';
    var DEFAULT_SENDERS = <%= Yemon.dnn.Functions.Serialize(default_senders) %>;

    var DEFAULT_TEST_EMAIL = '<%=default_test_email%>';

$(document).ready(function () {

        if (typeof _yemon == 'undefined')
            _yemon = [];
        _yemon[<%=ModuleId%>] = new Yemon(<%=ModuleId%>, '/Desktopmodules/AIS/API/Mailing');

        InitApp('<%=appID %>',<%=ModuleId%>, '<%=context%>',<%=cric%>,'<%=mode%>',<%=editable.ToString().ToLower()%>);
        });
        //$("form").keypress(function (e) {
        ////Enter key
        //if (e.which == 13) {
        //return false;
        //}
  //  });
</script>

