<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Club_Contact_Control" %>
<% 
    string libPath = TabController.CurrentPage.SkinPath + "echoppe/";
    string appID = "app" + ModuleId;

%>
<asp:HiddenField ID="ContextGuid" runat="server" />
<script src="<%=libPath %>vue/3.2.23/vue.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script src="<%=libPath %>vue-router/4.0.12/vue-router.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script src="<%=libPath %>axios/0.24.0/axios.min.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script src="<%=libPath %>toastr/toastr.min.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<link href="<%=libPath %>toastr/toastr.min.css?cdv=<%=Yemon.dnn.Functions.CDV %>" rel="stylesheet" />

<style>
    [v-cloak] {
        display: none;
    }
</style>

<div class="admin" id='<%=appID %>' v-cloak>
     <router-view :moduleid="moduleid" :context="context" :editable="editable"></router-view> 
</div>
<script src="/DesktopModules/Yemon/API/Services/VueJS"></script>
<!-- #include virtual ="/DesktopModules/AIS/Admin Club Contacts/Contacts.html" -->
<!-- #include virtual ="/DesktopModules/AIS/Admin Club Contacts/ContactsEdit.html" -->

<script src="/DesktopModules/AIS/Admin Club Contacts/app.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script>
    var HOST = '<%=AIS.Const.DISTRICT_URL%>';

    
   
    $(document).ready(function () {

        if (typeof _yemon == 'undefined')
            _yemon = [];
        _yemon[<%=ModuleId%>] = new Yemon(<%=ModuleId%>, '/Desktopmodules/AIS/API/Contacts');


    //Yemon = new Yemon(@moduleID, '/DesktopModules/Yemon/API/Services');
        InitApp('<%=appID %>',<%=ModuleId%>, '<%=context%>',<%=cric%>,<%=editable.ToString().ToLower()%>);
        });
        //$("form").keypress(function (e) {
        ////Enter key
        //if (e.which == 13) {
        //return false;
        //}
  //  });
</script>

