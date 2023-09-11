<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_News_Article_Control" %>
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
<script src="/AIS/TextEditor/ckeditor/ckeditor.js"></script>
<h1 class="DetailedArticle">
	<asp:Label ID="LBL_Titre" runat="server" Text=""></asp:Label>
    
    <asp:HyperLink runat="server" ID="HL_Print" CssClass="fa fa-print" Target="_blank" ToolTip="Imprimer"></asp:HyperLink>
    <asp:HyperLink runat="server" ID="HL_Back" CssClass="fa fa-reply"  style="padding:0 3px " ToolTip="Retour"></asp:HyperLink>
</h1>
<!--<div class="text-right">
	<asp:HyperLink ID="HLK_Club" runat="server" CssClass="Normal"/>
	<asp:Label ID="LBL_Date" runat="server" Text="" CssClass="Date Normal" Visible="false"></asp:Label>
</div>-->
<asp:HiddenField ID="hfd_files" runat="server" />
<asp:HiddenField ID="hfd_filesToDelete" runat="server" />
<asp:Panel ID="pnl_type" runat="server" Visible="false">
        
</asp:Panel>


<asp:Repeater runat="server" ID="LI_Blocs" OnItemDataBound="LI_Blocs_ItemDataBound" OnItemCommand="LI_Blocs_ItemCommand">
<HeaderTemplate></HeaderTemplate>
<ItemTemplate>

	<asp:Panel ID="Panel1" runat="server">
		<asp:Image ID="Image1" runat="server" CssClass="Block DetailedArticle" />
        <asp:Literal runat="server" ID="L_Title"></asp:Literal>
		<asp:Panel runat="server" CssClass="Block" ID="pnl_content">
            <p><asp:Label ID="Texte1" runat="server" Text='<%# Bind("content") %>' /></p>
		</asp:Panel>
		<div class="clear"></div>
	</asp:Panel>


    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <asp:RadioButtonList runat="server" ID="rbl_type">
            <asp:ListItem Text="Texte uniquement"  Value="NoPhoto"></asp:ListItem>
            <asp:ListItem Text="Image à gauche + Texte" Value="PhotoLeft"></asp:ListItem>
            <asp:ListItem Text="Image à droite + Texte" Value="PhotoRight"></asp:ListItem>
            <asp:ListItem Text="Image au-dessus" Value="PhotoTop"></asp:ListItem>
            <asp:ListItem Text="Image uniquement" Value="Photo"></asp:ListItem>
            <asp:ListItem Text="Liste de liens" Value="Links"></asp:ListItem>
            <asp:ListItem Text="Liste de fichiers à télécharger" Value="Files"></asp:ListItem>
            <asp:ListItem Text="Vidéo" Value="Video"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button CssClass="btn btn-primary" ID="btn_type" runat="server" Text="Changer le type de bloc" />
        <br />
        <asp:Label Text="Titre : " runat="server"></asp:Label>
        <asp:TextBox ID="tbx_titre" Width="100%" Text='<%# Bind("title") %>' runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbl_contenu" Text="Contenu : " runat="server"></asp:Label>
        <asp:TextBox ID="tbx_contenu" Visible="false" TextMode="MultiLine" Width="600" Height="300" runat="server" Text='<%# Bind("content") %>'></asp:TextBox>
        
        <asp:Literal ID="script" runat="server" ></asp:Literal>
        <asp:Label ID="lbl_img" Text="Image : " runat="server"></asp:Label>
        <asp:Image ID="Image2" runat="server" />
        <br />
        <asp:FileUpload ID="ful_img" runat="server" />
        <asp:Button ID="btn_upload" CssClass="btn btn-primary" Text="Changer l'image"  runat="server" />
        <asp:Panel ID="pnl_links" Visible="false" runat="server">
            <div class="row">
                <div class="col-sm-4">
                    <asp:Label Text="URL : " runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="tbx_link1"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:Label Text="Nom à l'affichage" runat="server"></asp:Label>
                    <asp:TextBox ID="tbx_text1" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:Label Text="Ouvrir dans " runat="server"></asp:Label>
                    <asp:DropDownList ID="ddl_target1" runat="server"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-4">
                    <asp:Label Text="URL : " runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="tbx_link2"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:Label Text="Nom à l'affichage" runat="server"></asp:Label>
                    <asp:TextBox ID="tbx_text2" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:Label Text="Ouvrir dans " runat="server"></asp:Label>
                    <asp:DropDownList ID="ddl_target2" runat="server"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-4">
                    <asp:Label Text="URL : " runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="tbx_link3"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:Label Text="Nom à l'affichage" runat="server"></asp:Label>
                    <asp:TextBox ID="tbx_text3" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:Label Text="Ouvrir dans " runat="server"></asp:Label>
                    <asp:DropDownList ID="ddl_target3" runat="server"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-4">
                    <asp:Label Text="URL : " runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="tbx_link4"></asp:TextBox>
                    
                </div>
                <div class="col-sm-4">
                    <asp:Label Text="Nom à l'affichage" runat="server"></asp:Label>
                    <asp:TextBox ID="tbx_text4" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:Label Text="Ouvrir dans " runat="server"></asp:Label>
                    <asp:DropDownList ID="ddl_target4" runat="server"></asp:DropDownList>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnl_files" Visible="false" runat="server">
            
            
            <asp:Panel ID="pnl_filesUploaded" runat="server">
                <asp:GridView ID="gvw_filesUploaded" CssClass="table table-stripped" OnRowCommand="gvw_filesUploaded_RowCommand1" Width="100%" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="Fichier" DataField="Name"></asp:BoundField>
                        <asp:ButtonField HeaderText="Les fichiers supprimés ne peuvent pas être récupérés" HeaderStyle-Width="220" Text="Supprimer" ButtonType="Button" ControlStyle-Width="100%" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>


            </asp:Panel>
            <asp:FileUpload ID="ful_files" runat="server" />
            <asp:Button ID="btn_uploadFiles" CssClass="btn btn-primary" runat="server" Text="Charger le fichier" />

            <br />
        </asp:Panel>
        <asp:Panel ID="pnl_video" Visible="false" runat="server">
            <asp:Label Text="URL de la vidéo : " runat="server"></asp:Label>
            <asp:TextBox ID="tbx_urlYT" Width="100%" runat="server"></asp:TextBox>
        </asp:Panel>
        <br />
        <br />
        <asp:Button Text="Valider les modifications" CssClass="btn btn-primary" ID="btn_validate" runat="server"></asp:Button>
        &nbsp
        <asp:Button Text="Annuler les modifications" ID="btn_cancel" CssClass="btn btn-default" runat="server"></asp:Button>
        
    </asp:Panel>
    <asp:Panel Visible="false" ID="pnl_modif" runat="server" CssClass="row panel-body DNNAlignright">
        <asp:HyperLink ID="hlk_modif" CssClass="btn btn-primary" runat="server" ><span class="fa fa-pencil"></span></asp:HyperLink>
        <asp:LinkButton ID="ibt_top" Visible="false" runat="server" CommandName='<%# Bind("id") %>' CssClass="btn btn-default middle"><span class="fa fa-angle-double-up" title="monter tout en haut"></span></asp:LinkButton>
        <asp:LinkButton ID="ibt_up" Visible="false" runat="server" CommandName='<%# Bind("id") %>' CssClass="btn btn-default middle"><span class="fa fa-angle-up" title="monter d'une position"></span></asp:LinkButton>
        <asp:LinkButton ID="ibt_down" Visible="false" runat="server" CssClass="btn btn-default middle" CommandName='<%# Bind("id") %>' ><span class="fa fa-angle-down" title="descendre d'une position"></span></asp:LinkButton>
        <asp:LinkButton ID="ibt_bottom" Visible="false" runat="server" CssClass="btn btn-default middle" CommandName='<%# Bind("id") %>' ><span class="fa fa-angle-double-down" title="descendre tout en bas"></span></asp:LinkButton>
        <!-- Button trigger modal -->
        <asp:HiddenField ID="hfd_blocid" runat="server" />
        <asp:LinkButton OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce bloc ?');" CommandArgument='<%# Bind("id") %>' CssClass="btn btn-danger" ID="lbt_delete" runat="server"><span class="fa fa-trash-o"></span></asp:LinkButton>     
    </asp:Panel>
    
	<div class="pe-spacer size10"></div>
</ItemTemplate>
<FooterTemplate></FooterTemplate>
</asp:Repeater>


<asp:Panel ID="pnl_add" runat="server" Visible="false">
    
    <asp:HyperLink ID="hlk_add" Text="Ajouter un nouveau bloc" runat="server" CssClass="btn btn-primary"  />
    
</asp:Panel>
<asp:Panel ID="pnl_delete" runat="server" Visible="false">
    <asp:Label Text="Voulez-vous vraiment supprimer ce bloc?" runat="server"></asp:Label>
    <br />
    
</asp:Panel>

<%--<script type="text/javascript" src="http://w.sharethis.com/button/buttons.js"></script>
<script type="text/javascript" stLight.options({ publisher: "ur-2d12a09a-60ba-4999-196a-7d351be3cccc", doNotHash: true, doNotCopy: true, hashAddressBar: false });></script>--%>


<div class="pe-spacer size10"></div>
<asp:Panel ID="P_Share" runat="server" CssClass="text-right" Visible="false">
    <a class='st_facebook_large' displayText='Facebook'></a>
    <a class='st_twitter_large' displayText='Tweet'></a>
    <a class='st_googleplus_large' displayText='Google +'></a>
    <a class='st_linkedin_large' displayText='LinkedIn'></a>
    <a class='st_viadeo_large' displayText='Viadeo'></a>
</asp:Panel>


