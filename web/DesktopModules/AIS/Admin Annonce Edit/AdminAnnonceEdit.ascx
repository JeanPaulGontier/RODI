<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminAnnonceEdit.ascx.cs" Inherits="DesktopModules_AIS_Admin_Annonce_Edit_AdminAnnonceEdit" %>
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
        <h3><asp:Label runat="server" ID="Label2" Text="Titre :   " /></h3>
        <asp:TextBox runat="server" ID="TBX_Titre" AutoPostBack="true" Width="400" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Le titre n'a pas été saisi" ControlToValidate="TBX_Titre"></asp:RequiredFieldValidator>
    </div>
    <br />
    <div>
        <asp:RadioButton id="RBT_Offre" Text="Offre" Checked="True" GroupName="typeAnnonce" runat="server"/>
        <asp:RadioButton id="RBT_Demande" Text="Demande" GroupName="typeAnnonce" runat="server"/>
    </div>

    <h3>Annonce :</h3>
    <asp:Panel ID="pnl_advanced" runat="server">
        <telerik:RadEditor runat="server" ID="TXT_Editor" ToolsFile="~/DesktopModules/AIS/Page Membre Edit/XMLFile.xml" style="width:100%;" AutoPostBack="true" ></telerik:RadEditor>
	    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="L'annonce n'a pas été saisie" Display="None" ControlToValidate="TXT_Editor"></asp:RequiredFieldValidator>--%>
    </asp:Panel>
    <asp:Panel ID="pnl_simple" runat="server">
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
                            <asp:LinkButton ID="hlk_edit_texte" Target="_blank" CausesValidation="false" CommandName='<%#Bind("id") %>' CssClass="btn btn-primary" runat="server"><span class="fa fa-pencil"></span></asp:LinkButton>
                        </div>
                        <div class="col-sm-3 col-sm-offset-1">
                            <asp:LinkButton ID="btn_up" CssClass="btn btn-default" CommandName='<%#Bind("id") %>' CausesValidation="false" runat="server" ><span class="fa fa-arrow-up"></span></asp:LinkButton>
            
                            <asp:LinkButton ID="btn_down" CssClass="btn btn-default" CommandName='<%#Bind("id") %>' runat="server" CausesValidation="false" Text="" ><span class="fa fa-arrow-down"></span></asp:LinkButton>
                        </div>
                        <div class="col-sm-4">
                            <asp:LinkButton ID="lbt_delete" CommandArgument='<%# Bind("id") %>' CausesValidation="false" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce bloc ?');" CssClass="btn btn-danger right"  runat="server" ><span class="fa fa-trash-o"></span></asp:LinkButton>
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
                <asp:ListItem Text="Liste de fichiers à télécharger" Value="Files"></asp:ListItem>
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
                <asp:Button ID="btn_image" runat="server" CssClass="btn btn-primary" Text="Charger l'image" CausesValidation="false" OnClick="btn_image_Click" />
                <asp:Image ID="img" runat="server" />
                <asp:HiddenField ID="hfd_image" runat="server" />
            </asp:Panel>
            <asp:Panel ID="pnl_video" runat="server" Visible="false">
                <asp:Label runat="server">URL de la vidéo : </asp:Label>
                <asp:TextBox ID="TextBox2" Width="100%" runat="server"></asp:TextBox>
            </asp:Panel>
             <asp:Panel ID="pnl_files" Visible="false" runat="server">
            
            
            <asp:Panel ID="pnl_filesUploaded" runat="server">
                <asp:GridView ID="gvw_filesUploaded" CssClass="table table-stripped" OnRowCommand="gvw_filesUploaded_RowCommand" Width="100%" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="Fichier" DataField="Name"></asp:BoundField>
                        <asp:ButtonField HeaderText="Les fichiers supprimés ne peuvent pas être récupérés" CausesValidation="false" HeaderStyle-Width="220" Text="Supprimer" ButtonType="Button" ControlStyle-Width="100%" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>


            </asp:Panel>
            <asp:FileUpload ID="ful_files" runat="server" />
            <asp:Button ID="btn_uploadFiles" CausesValidation="false" CssClass="btn btn-primary" runat="server" OnClick="btn_uploadFiles_Click" Text="Charger le fichier" />
            <asp:HiddenField ID="hfd_files" runat="server" />
            <asp:HiddenField ID="hfd_id" runat="server" />
            <asp:HiddenField ID="hfd_filesToDelete" runat="server" />
            <br />
        </asp:Panel>
            <br />
            <asp:Button ID="btn_validateAdd" runat="server" OnClick="btn_validateAdd_Click" CssClass="btn btn-primary" CausesValidation="false" Text="Ajouter le bloc" />
            <asp:Button ID="btn_cancelAdd" runat="server" OnClick="btn_cancelAdd_Click" CssClass="btn btn-default" CausesValidation="false" Text="Annuler" />            

            <br />              
        </asp:Panel>
    </asp:Panel>

    <div>
        <h3><asp:Label runat="server" ID="Label5" Text="Visuel de l'annonce (apparaîtra à droite de mon annonce) : " /></h3>
        <asp:Image runat="server" ID="IMG_Logo" />
        <asp:HiddenField runat="server" ID="HF_Logo" />
        <telerik:RadAsyncUpload ID="FU_Logo" HideFileInput="true" Localization-Select="Sélectionner une image"  MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientLogoUploaded" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
		<asp:Button runat="server" ID="BT_Upload_Logo" CssClass="btn btn-primary" Text="Mettre à jour le visuel" OnClick="BT_Upload_Logo_Click" CausesValidation="false" />
		<script>function OnClientLogoUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt2 = document.getElementById('<%=BT_Upload_Logo.ClientID %>'); bt2.click(); }</script>
        <asp:Button runat="server" ID="BT_Effacer_Logo" CssClass="btn btn-danger" Text="Supprimer le visuel" OnClick="BT_Effacer_Logo_Click" CausesValidation="false" />
    </div>

    
    <br />
    <div>
        <asp:CheckBox ID="cbx_publish" runat="server" Text="Rendre cette annonce publique" />
    </div>
    <br />
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
        <asp:Button runat="server" ID="BT_Valider" Text="Valider" CssClass="btn btn-primary" OnClick="BT_Valider_Click" CausesValidation="true" />
        &nbsp;
        <asp:Button runat="server" ID="BT_Annuler" Text="Annuler" CssClass="btn btn-default" OnClick="BT_Annuler_Click" CausesValidation="false" />
    </div>

</asp:Panel>








