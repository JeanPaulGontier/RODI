<!--**********************************************************************************-->
<!-- RODI - https://rodi-platform.org                                                 -->
<!-- Copyright (c) 2012-2022                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_News_List_Control" %>
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






<%--<asp:Label ID="test" runat="server" />

<asp:Panel ID="Panel1" runat="server">
<asp:Button runat="server" Text="Ajouter une nouvelle" ID="BT_Ajouter_News" OnClick="BT_Ajouter_News_Click" CssClass="btn btn-primary" />
<h3><asp:Label runat="server" ID="lbl_TousADG" Visible="false" Text="Choisissez un club" /></h3>
<asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"  AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
<Columns>
    <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" DataFormatString="{0:d}" />
    <asp:BoundField DataField="title" HeaderText="Titre"  SortExpression="title" />
    <asp:BoundField DataField="category" HeaderText="Catégorie" SortExpression="category" ItemStyle-HorizontalAlign="Center" />
    <asp:BoundField DataField="tag1" HeaderText="Nature" SortExpression="tag1" ItemStyle-HorizontalAlign="Center" />
    <asp:BoundField DataField="visible" HeaderText="Visible" SortExpression="visible" ItemStyle-HorizontalAlign="Center" />
    <asp:ButtonField ButtonType="Link" runat="server" Text="Détail" CommandName="detail" />
</Columns>    
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
<asp:HiddenField ID="tri" Value="dt" runat="server"/><asp:HiddenField ID="sens" Value="DESC" runat="server"/>
<asp:HiddenField ID="HF_Cric" runat="server" />
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" Visible="false">
<asp:HiddenField runat="server" ID="HF_id" />

<div class="Marron">
	<h2><span class="Head">Détail de la nouvelle</span></h2>
</div>

<div class="row">
	<div class="col-sm-2">
		<span>Date : </span>
    </div>
    <div class="col-sm-10">
        <telerik:RadDatePicker runat="server" ID="TXT_Dt"></telerik:RadDatePicker>
	</div>
	
</div>
    <asp:Panel runat="server" ID="PanelSujet" CssClass="row">
	    <div class="col-sm-2">
            <span>Catégorie :</span>
	    </div>
        <div class="col-sm-10">
            <p><asp:DropDownList runat="server" ID="DL_Sujet" Width="25%" CssClass="form-control">
            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>            
            <asp:ListItem Text="Action" Value="Action"></asp:ListItem>
            <asp:ListItem Text="Bulletin" Value="Bulletin"></asp:ListItem>
            <asp:ListItem Text="Conférence" Value="Conférence"></asp:ListItem>
            <asp:ListItem Text="District" Value="District"></asp:ListItem>
            <asp:ListItem Text="Formation" Value="Formation"></asp:ListItem>
            <asp:ListItem Text="Général" Value="Général"></asp:ListItem>
            </asp:DropDownList></p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Veuillez sélectionner une catégorie" ControlToValidate="DL_Sujet" Display="None"></asp:RequiredFieldValidator> 
        </div>
	</asp:Panel>
<div class="row">
	<div class="col-sm-2">
	    <span>Visible : </span>
    </div>
    <div class="col-sm-10">
	    <asp:RadioButtonList ID="RB_Visible" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
	    	<asp:ListItem Text="Oui" Value="O" /><asp:ListItem Text="Non" Value="N" />
	    </asp:RadioButtonList>
	</div>
</div>

<div class="row">
	<div class="col-sm-2">
	    <span>Titre : </span>
    </div>
    <div class="col-sm-10">
		<asp:TextBox runat="server" ID="TXT_Titre" MaxLength="255" Width="100%"  CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Il manque le titre" Display="None" ControlToValidate="TXT_Titre"></asp:RequiredFieldValidator>
	</div>
</div>
	
<div class="row">
	<div class="col-sm-2">
       	<span>Photo : </span>
    </div>
    <div class="col-sm-10">

        <style>
            input[type=file]::-webkit-file-upload-button {
                color: #ffffff;
                border: none;
                cursor: pointer;            
                background-image: linear-gradient(to right,#428bca,#428bca);
                border-color: #357edb;
                border-radius: 4px;
           
                font-size: 12px;
                padding: 6px 12px;
                user-select: none;
                white-space: nowrap;
            }
        </style>
        <asp:Image runat="server" ID="IMG_Photo" /><asp:HiddenField runat="server" ID="HF_Photo" />
        <div class="pe-spacer size10"></div>
        <asp:FileUpload runat="server" ID="FU_Photo"  onchange="OnClientPhotoUploaded(this, this.files[0])" accept=".png, .jpeg, .jpg" />
        <div style="display:none">
        	<asp:Button runat="server" ID="BT_Upload_Photo" Text="Mettre à jour" OnClick="BT_Upload_Photo_Click" CausesValidation="false" />
        	<script>function OnClientPhotoUploaded(sender, args) {var bt = document.getElementById('<%=BT_Upload_Photo.ClientID %>');bt.click();}</script>
        </div>
        <div class="pe-spacer size10"></div>
        <p><asp:Button runat="server" ID="BT_Effacer_Photo" Text="Supprimer la photo" OnClick="BT_Effacer_Photo_Click" CausesValidation="false" CssClass="btn btn-xs btn-danger" /></p>
        <div class="pe-spacer size20"></div>
	</div>
</div>

<div class="row">
	<div class="col-sm-2">
        	<span>Texte : </span>
    </div>
    <div class="col-sm-10">
        	<asp:TextBox runat="server" ID="TXT_Texte" TextMode="MultiLine" Rows="12" Width="100%"  CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Le texte n'a pas été saisi" Display="None" ControlToValidate="TXT_Texte"></asp:RequiredFieldValidator>
	</div>
</div>

<div class="row">
	<div class="col-sm-2">
    	<span>Fichier (.pdf) : </span>
    </div>
    <div class="col-sm-10">
	    	<asp:HyperLink runat="server" ID="HL_Url" Target="_blank"></asp:HyperLink>
            <div class="pe-spacer size10"></div>
            <asp:FileUpload runat="server" ID="FU_Url"  onchange="OnClientFileUploaded(this, this.files[0])"  accept=".pdf"/>
            <div class="pe-spacer size10"></div>
        	<div style="display:none">
	    		<asp:Button runat="server" ID="BT_Upload_Fichier" Text="Envoyer" OnClick="BT_Upload_Fichier_Click" CausesValidation="false"  />
	    		<script>function OnClientFileUploaded(sender, args) {var bt = document.getElementById('<%=BT_Upload_Fichier.ClientID %>');bt.click();}</script>
	    	</div>
        <div class="pe-spacer size20"></div>
	</div>
</div>

<div class="row">
	<div class="col-sm-2">
	    	<span>Nom visible du fichier : </span>
    </div>
    <div class="col-sm-10">
	    	<p><asp:TextBox runat="server" ID="TXT_Url_Texte" Width="100%"  CssClass="form-control"></asp:TextBox></p>
	    	<asp:Button runat="server" ID="BT_Effacer_Fichier" Text="Supprimer le fichier" OnClick="BT_Effacer_Fichier_Click"  CausesValidation="false" CssClass="btn btn-xs btn-danger" />
	        <asp:Button runat="server" ID="BT_Creer_Vignette" Text="Créer l'image du fichier" OnClick="BT_Creer_Vignette_Click" CausesValidation="false" CssClass="btn btn-xs btn-primary" />
	</div>
    <div class="pe-spacer size20"></div>
</div>


<div class="row">
	<p><asp:ValidationSummary runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" /></p>
    <div class="col-sm-4">
	    <asp:Button runat="server" ID="BT_Supprimer" Text="Supprimer" CausesValidation="false" OnClick="BT_Supprimer_Click" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer cette nouvelle ?');" CssClass="btn btn-danger" />&nbsp;
    </div>
    <div class="col-sm-8">
	<asp:Button runat="server" ID="BT_Valider" Text="Valider" OnClick="BT_Valider_Click" CssClass="btn btn-primary" />&nbsp;<asp:Button runat="server" ID="BT_Annuler" Text="Retour" OnClick="BT_Annuler_Click" CausesValidation="false" CssClass="btn btn-default" />
    </div>
</div>
</asp:Panel>--%>


