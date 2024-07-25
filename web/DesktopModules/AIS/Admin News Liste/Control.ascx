<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_News_List_Control" %>
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
<link rel="stylesheet" type="text/css" href="<%=libPath %>slick-carousel-1.8.1/slick.css" />
<link rel="stylesheet" type="text/css" href="<%=libPath %>slick-carousel-1.8.1/slick-theme.css" />
<script type="text/javascript" src="<%=libPath %>slick-carousel-1.8.1/slick.min.js"></script>

<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/ImageEditor.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockFileCollection.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockImageCollection.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockImageText.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockRaw.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockVideo.cshtml" -->
<!-- #include virtual ="/DesktopModules/RazorModules/RazorHost/Scripts/BlocksContent/BlockEditor.cshtml" -->
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
<!-- #include virtual ="/DesktopModules/AIS/Admin News Liste/News.html" -->
<!-- #include virtual ="/DesktopModules/AIS/Admin News Liste/NewsEdit.html" -->
<!-- #include virtual ="/DesktopModules/AIS/Admin News Liste/NewsView.html" -->
<script src="/DesktopModules/AIS/Admin News Liste/app.min.js?cdv=<%=Yemon.dnn.Functions.CDV %>"></script>
<script>
    var HOST = '<%=AIS.Const.DISTRICT_URL%>';

    var CATEGORIES =  <%=Yemon.dnn.Functions.Serialize(categories)%>;

    $(document).ready(function () {

        if (typeof _yemon == 'undefined')
            _yemon = [];
        _yemon[<%=ModuleId%>] = new Yemon(<%=ModuleId%>, '/Desktopmodules/AIS/API/News');


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