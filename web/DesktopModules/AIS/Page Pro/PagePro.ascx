<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PagePro.ascx.cs" Inherits="DesktopModules_AIS_Page_Pro_PagePro" %>

<asp:Panel ID="rotary" runat="server">
    <div class="col-sm-8">
        <asp:Panel ID="pnl_pres" runat="server">
            <asp:Repeater runat="server" ID="repeat_blocs" OnItemDataBound="repeat_blocs_ItemDataBound">
                <ItemTemplate>
                    <asp:Panel ID="Panel1" runat="server">
		                <asp:Image ID="Image1" runat="server" CssClass="Block DetailedArticle" />
                        <h1><asp:Label ID="Titre1" runat="server" Text='<%# Bind("title") %>' /></h1>
		                <asp:Panel runat="server" CssClass="Block" ID="pnl_content">
                            <p><asp:Label ID="Texte1" runat="server" Text='<%# Bind("content") %>' /></p>
		                </asp:Panel>
		                <div class="clear"></div>
	                </asp:Panel>
                </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnl_noPres">
            <p>Vous n'avez pas encore de présentation. Vous pouvez en créer une gratuitement mais nous vous invitons à faire un don à la Fondation pour soutenir le Rotary !</p><br />
            <asp:Button runat="server" ID="btn_create" CssClass="btn btn-primary" OnClick="btn_create_Click"  Text="Créer ma page professionnelle" OnClientClick="Javascript: return confirm('Vous alez être redirigés vers la page de donation');"/>
        </asp:Panel>
        
    </div>
    
    <asp:Panel runat="server" ID="pnl_header" CssClass="col-sm-4 text-center">
        <asp:Image ID="img_photoMember" runat="server" />
        <br/>
        <strong><asp:Label ID="lbl_name" runat="server" ></asp:Label></strong><br />
        <asp:Label ID="lbl_industry" runat="server"></asp:Label><br />
        <asp:Label ID="lbl_company" runat="server"></asp:Label><br />
        <asp:HyperLink ID="hlk_website" runat="server">Accès au site web</asp:HyperLink><br />
        <asp:HyperLink ID="hlk_contact" runat="server" Imageurl="/Portals/_default/Skins/Rotary/images/mail.png" ToolTip="Lui envoyer un message" Text="Lui envoyer un message"></asp:HyperLink>
    </asp:Panel>

    
    
</asp:Panel>

<asp:Panel ID="notRotary" runat="server" Visible="false">
    <h3>Vous n'êtes pas un rotarien, vous ne pouvez pas avoir de page professionnelle.</h3>
</asp:Panel>