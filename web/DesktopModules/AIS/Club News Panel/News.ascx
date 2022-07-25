<%@ Control Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeFile="News.ascx.cs" Inherits="DesktopModules_AIS_Club_News_Panel"  %>
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
<asp:HiddenField runat="server" ID="CRIC" />
<asp:HiddenField runat="server" ID="URL" />
<asp:Repeater runat="server" ID="LI_News" OnItemDataBound="LI_News_ItemDataBound" OnItemCommand="LI_News_ItemCommand" >
<HeaderTemplate></HeaderTemplate>
<ItemTemplate>
    <asp:Panel runat="server" CssClass="Filet">
        <asp:Panel ID="Panel1" runat="server">
		    <asp:HyperLink ID="HL_Detail" runat="server">
			    <div><asp:Image ID="Image1" runat="server" /></div>
			    <asp:Literal runat="server" ID="L_Title"></asp:Literal>
		    </asp:HyperLink>
		    
		    <asp:Panel runat="server" CssClass="Block" ID="pnl_content">
			    <asp:Label ID="Date1" runat="server" Text='<%# Bind("dt","{0:dd MMM yyyy}") %>' CssClass="Date" Visible="false" />
			    <p><asp:Label ID="Texte1" runat="server" Text='<%# Bind("text") %>' /></p>
			    <asp:HyperLink ID="HL_Detail1" runat="server">Lire la suite...</asp:HyperLink>
		    </asp:Panel>   
	    </asp:Panel>
	    
        <div class="row panel-body DNNAlignright">
            <asp:HyperLink ID="hlk_edit_texte" CssClass="btn btn-primary" runat="server"><span class="fa fa-pencil"></span></asp:HyperLink>
            <asp:LinkButton ID="btn_up" CssClass="btn btn-default" CommandName='<%#Bind("id") %>' runat="server" ><span class="fa fa-arrow-up"></span></asp:LinkButton>
            <asp:LinkButton ID="btn_down" CssClass="btn btn-default" CommandName='<%#Bind("id") %>' runat="server" Text="" ><span class="fa fa-arrow-down"></span></asp:LinkButton>
            <asp:LinkButton ID="lbt_delete" CommandArgument='<%# Bind("id") %>' OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce bloc ?');" CssClass="btn btn-danger"  runat="server" ><span class="fa fa-trash-o"></span></asp:LinkButton>
        </div>
     </asp:Panel>
	
</ItemTemplate>
<FooterTemplate></FooterTemplate>
</asp:Repeater>




<asp:Button runat="server" ID="btn_add" CssClass="btn btn-primary" OnClick="btn_add_Click" Text="Ajouter un article" />
<br />
<asp:Panel ID="pnl_add" runat="server" Visible="false">
    <h1>Ajout ou modification de l'accroche</h1>
    <asp:RadioButtonList ID="rbl_type" runat="server">
        <asp:ListItem Text="Texte seulement" Selected="True" Value="NoPhoto"></asp:ListItem>
        <asp:ListItem Text="Image à gauche + texte" Value="PhotoLeft"></asp:ListItem>
        <asp:ListItem Text="Image à droite + texte" Value="PhotoRight"></asp:ListItem>
        <asp:ListItem Text="Image au-dessus du texte" Value="PhotoTop"></asp:ListItem>
        <asp:ListItem Text="Vidéo" Value="Video"></asp:ListItem>
    </asp:RadioButtonList>
    <asp:Button ID="btn_type" CssClass="btn btn-primary" runat="server" Text="Changer le type" OnClick="btn_type_Click" />
    <br />
    <asp:Label Text="Titre : " runat="server"></asp:Label>
    <asp:TextBox ID="tbx_titre" Width="100%" runat="server"></asp:TextBox>
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
        <asp:TextBox ID="tbx_url" Width="100%" runat="server"></asp:TextBox>
    </asp:Panel>

    <br />
    <asp:Button ID="btn_validate" runat="server" CssClass="btn btn-primary" OnClick="btn_validate_Click1" Text="Valider l'accroche" />
    <asp:Button ID="btn_cancel" runat="server" CssClass="btn btn-primary" OnClick="btn_cancel_Click" Text="Annuler" />



</asp:Panel>

<asp:Panel ID="pnl_delete" runat="server" Visible="false">

    <asp:Label Text="Voulez-vous vraiment détruire cette accroche?" runat="server"></asp:Label>

    <asp:Button ID="btn_yes" CssClass="btn btn-primary" runat="server" Text="Oui" OnClick="btn_yes_Click"/>
    <asp:Button ID="btn_no" CssClass="btn btn-primary" runat="server" Text="Non" OnClick="btn_no_Click" />

</asp:Panel>
