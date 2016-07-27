<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageMembreEdit.ascx.cs" Inherits="DesktopModules_AIS_Page_Member_Edit_PageMemberEdit" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<script src="/AIS/TextEditor/ckeditor/ckeditor.js"></script>

<style>
    .videoContainer 
    {
    position: relative;
    width: 100%;
    height: 0;
    padding-bottom: 56.25%;
    }
    .video
    {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    }
</style>


<asp:Panel ID="Panel1" runat="server">

    <div>
        <h3><asp:Label runat="server" ID="Label2" Text="Titre de présentation : " /></h3>
        <asp:TextBox runat="server" ID="TBX_Titre" AutoPostBack="true" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Le titre n'a pas été saisi" ControlToValidate="TBX_Titre"></asp:RequiredFieldValidator>
    </div>

    <div>
        <h3><asp:Label runat="server" ID="Label1" Text="Société : " /></h3>
        <asp:TextBox runat="server" ID="TBX_Societe" AutoPostBack="true" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La société n'a pas été saisie" ControlToValidate="TBX_Societe"></asp:RequiredFieldValidator>
    </div>

    <br />
    <asp:Panel runat="server" ID="pnl_simple">

        <asp:Panel ID="pnl_display" runat="server">
            <asp:Repeater runat="server" ID="LI_Blocs" OnItemDataBound="LI_Blocs_ItemDataBound" OnItemCommand="LI_Blocs_ItemCommand" >
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>
                    <asp:Panel runat="server">
                        <asp:Panel ID="Panel1" runat="server">
		                    <asp:HyperLink ID="HL_Detail" runat="server">
			                    <div class="LimitedHeight"><asp:Image ID="Image1" runat="server" /></div>
			                    <h1><asp:Label ID="Titre1" runat="server" Text='<%# Bind("title") %>' /></h1>
		                    </asp:HyperLink>
		                    <asp:Panel runat="server" CssClass="Block" ID="pnl_content">
			                    <p><asp:Label ID="Texte1" runat="server" Text='<%# Bind("content") %>' /></p>
                            </asp:Panel>   
	                    </asp:Panel>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:LinkButton ID="hlk_edit_texte" Target="_blank" CommandName='<%#Bind("id") %>' CssClass="btn btn-primary" runat="server"><span class="fa fa-pencil"></span></asp:LinkButton>
                        </div>
                        <div class="col-sm-3 col-sm-offset-1">
                            <asp:LinkButton ID="btn_up" CssClass="btn btn-default" CommandName='<%#Bind("id") %>' runat="server" ><span class="fa fa-arrow-up"></span></asp:LinkButton>
            
                            <asp:LinkButton ID="btn_down" CssClass="btn btn-default" CommandName='<%#Bind("id") %>' runat="server" Text="" ><span class="fa fa-arrow-down"></span></asp:LinkButton>
                        </div>
                        <div class="col-sm-4">
                            <asp:LinkButton ID="lbt_delete" CommandArgument='<%# Bind("id") %>' OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce bloc ?');" CssClass="btn btn-danger right"  runat="server" ><span class="fa fa-trash-o"></span></asp:LinkButton>
                        </div>
                    </div>
		            <div class="clear"></div>
                    </asp:Panel>
	            </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater>
            <asp:Button runat="server" ID="btn_add" CausesValidation="false" CssClass="btn btn-primary" OnClick="btn_add_Click" Text="Ajouter un bloc" />
        </asp:Panel>

        <asp:Panel ID="pnl_Edit" runat="server" Visible="false">
            <h3><asp:Label runat="server" ID="Label6" Text="Présentation : " /></h3>
            <asp:RadioButtonList ID="rbl_type" runat="server">
                <asp:ListItem Text="Texte seulement" Selected="True" Value="NoPhoto"></asp:ListItem>
                <asp:ListItem Text="Image à gauche + texte" Value="PhotoLeft"></asp:ListItem>
                <asp:ListItem Text="Image à droite + texte" Value="PhotoRight"></asp:ListItem>
                <asp:ListItem Text="Image au-dessus du texte" Value="PhotoTop"></asp:ListItem>
                <asp:ListItem Text="Vidéo" Value="Video"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="btn_type" CssClass="btn btn-primary" runat="server" Text="Changer le type" CausesValidation="false" OnClick="btn_type_Click" />
        
            <br />
            <asp:Label ID="lbl_contenu" Text="Contenu : " runat="server"></asp:Label>
            <asp:TextBox ID="tbx_contenu" Visible="true" TextMode="MultiLine" Width="600" Height="300" runat="server" ></asp:TextBox>
            <script> CKEDITOR.replace('<%=tbx_contenu.ClientID%>', {
                    uiColor: '#CCEAEE'
                });  </script>
            <asp:Panel ID="pnl_image" runat="server" Visible="false">
                <asp:FileUpload ID="ful_image" runat="server" />
                <asp:Button ID="btn_image" runat="server" CssClass="btn btn-primary" Text="Charger l'image" OnClick="btn_image_Click" />
                <asp:Image ID="img" runat="server" />
                <asp:HiddenField ID="hfd_image" runat="server" />
            </asp:Panel>
            <asp:Panel ID="pnl_video" runat="server" Visible="false">
                <asp:Label runat="server">URL de la vidéo : </asp:Label>
                <asp:TextBox ID="TextBox2" Width="100%" runat="server"></asp:TextBox>
            </asp:Panel>
            <br />
            <asp:Button ID="btn_validateAdd" runat="server" OnClick="btn_validateAdd_Click" CssClass="btn btn-primary" CausesValidation="false" Text="Ajouter le bloc" />
            <asp:Button ID="btn_cancelAdd" runat="server" OnClick="btn_cancelAdd_Click" CssClass="btn btn-default" CausesValidation="false" Text="Annuler" />            

            <br />              
        </asp:Panel>
                
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_advanced" Visible="false">
        <h3><asp:Label runat="server" ID="Label3" Text="Présentation : " /></h3>
        <%-------------------------------------------------------------------------------CHANGER ICI ----------------------------------------%>
        <telerik:RadEditor runat="server" ID="TXT_Editor" ToolsFile="~/DesktopModules/AIS/Page Membre Edit/XMLFile.xml" style="width:100%;" AutoPostBack="true" ></telerik:RadEditor>
	    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="La présentation n'a pas été saisie" Display="None" ControlToValidate="TXT_Editor"></asp:RequiredFieldValidator>
    </asp:Panel>

    <div>
        <asp:Image runat="server" ID="IMG_Photo" />
	    <%--<telerik:RadAsyncUpload ID="FU_Photo" Localization-Select="Changer la photo" HideFileInput="true" DisablePlugins="true" MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientPhotoUploaded" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
	    <div style="display:none; width:130px;">
		    <asp:Button runat="server" ID="BT_Upload_Photo" Text="Mettre à jour" OnClick="BT_Upload_Photo_Click" />
		    <script>function OnClientPhotoUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload_Photo.ClientID %>'); bt.click(); }</script>
	    </div>
        <asp:HiddenField runat="server" ID="HF_Photo" />
        <asp:Button runat="server" ID="BT_Effacer_Photo" Text="Supprimer la photo" OnClick="BT_Effacer_Photo_Click" />--%>
    </div>

    <div>
        <asp:Label runat="server" ID="LBL_Nom_Prenom" />
    </div>

    <div>
        <asp:Label runat="server" ID="LBL_Fonction" />
    </div>
    
    <div>
        <asp:Label runat="server" ID="LBL_Classification" />
    </div>

    <div>
        <h3><asp:Label runat="server" ID="Label5" Text="Logo : " /></h3>
        <asp:Image runat="server" ID="IMG_Logo" />
        <asp:HiddenField runat="server" ID="HF_Logo" />
        <telerik:RadAsyncUpload ID="FU_Logo" HideFileInput="true" Localization-Select="Sélectionner un logo"  MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientLogoUploaded" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
        <%--<div style="display:none">--%>
        <div style="display:none">
        	<asp:Button runat="server" ID="BT_Upload_Logo" Text="Mettre à jour" OnClick="BT_Upload_Logo_Click" CausesValidation="false" />
        	<script>function OnClientLogoUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt2 = document.getElementById('<%=BT_Upload_Logo.ClientID %>'); bt2.click(); }</script>
        </div>
        <asp:Button runat="server" ID="BT_Effacer_Logo" CssClass="btn btn-danger" Text="Supprimer le logo" OnClick="BT_Effacer_Logo_Click" CausesValidation="false" />
    </div>

    <div>
        <asp:Label runat="server" ID="Label4" Text="URL du site web : " />
        <asp:TextBox runat="server" ID="TBX_URL" AutoPostBack="true" />    
    </div>

    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
        <asp:Button runat="server" ID="BT_Valider" CssClass="btn btn-primary" Text="Valider" OnClick="BT_Valider_Click" CausesValidation="true" />
        &nbsp;
        <asp:Button runat="server" ID="BT_Annuler" Text="Annuler" CssClass="btn btn-default" OnClick="BT_Annuler_Click" CausesValidation="false" />
    </div>

</asp:Panel>








