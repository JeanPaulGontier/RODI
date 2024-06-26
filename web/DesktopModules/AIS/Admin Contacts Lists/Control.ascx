﻿
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Contacts_Lists_Control" %>
<% 
    string libPath = TabController.CurrentPage.SkinPath + "echoppe/";
    string appID = "app" + ModuleId;

%>
<asp:HiddenField ID="ContextGuid" runat="server" />
<script src="<%=libPath %>tinymce/tinymce.min.js"></script>
<script src="<%=libPath %>vue/3.2.23/vue.js"></script>
<script src="<%=libPath %>vue-router/4.0.12/vue-router.js"></script>
<script src="<%=libPath %>axios/0.24.0/axios.min.js"></script>
<script src="<%=libPath %>toastr/toastr.min.js"></script>
<link href="<%=libPath %>toastr/toastr.min.css" rel="stylesheet" />
<script src="<%=libPath %>vue-easy-tinymce-1.0.2/dist/vue-easy-tinymce.min.js"></script>
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockFileCollection.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockImageCollection.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockImageText.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockRaw.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockVideo.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockEditor.cshtml" -->
<link href="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/styles.css" rel="stylesheet" />


<style>
    [v-cloak] {
        display: none;
    }
</style>

<div class="admin" id='<%=appID %>' v-cloak>
     <router-view :moduleid="moduleid" :context="context" :editable="editable"></router-view> 
</div>
<script src="/DesktopModules/Yemon/API/Services/VueJS"></script>
<!-- #include virtual ="/DesktopModules/AIS/Admin News Liste/News.html" -->
<!-- #include virtual ="/DesktopModules/AIS/Admin News Liste/NewsEdit.html" -->
<!-- #include virtual ="/DesktopModules/AIS/Admin News Liste/NewsView.html" -->
<script src="/DesktopModules/AIS/Admin News Liste/app.js"></script>
<script>

    var CATEGORIES =  <%=Yemon.dnn.Functions.Serialize(categories)%>;

    $(document).ready(function () {

        if (typeof _yemon == 'undefined')
            _yemon = [];
        _yemon[<%=ModuleId%>] = new Yemon(<%=ModuleId%>, '/Desktopmodules/AIS/API/Contacts');


    //Yemon = new Yemon(@moduleID, '/DesktopModules/Yemon/API/Services');
        InitApp('<%=appID %>',<%=ModuleId%>, '<%=context%>',<%=cric%>,'<%=mode%>',<%=editable.ToString().ToLower()%>);
        });
        //$("form").keypress(function (e) {
        ////Enter key
        //if (e.which == 13) {
        //return false;
        //}
  //  });
</script>



<asp:Panel runat="server" ID="p_convert" Visible="false">
    <asp:Button runat="server" ID="convert" Text="Convertir" OnClick="convert_Click" />
</asp:Panel>