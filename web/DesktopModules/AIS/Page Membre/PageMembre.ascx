<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageMembre.ascx.cs" Inherits="DesktopModules_AIS_Page_Member_PageMember" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

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

<asp:Panel CssClass="panel panel-info" runat="server" ID="pnl_modif" Visible="false">
    <div class="panel-heading">
        <asp:Label runat="server">Vos modifications ont bien été enregistrées. Nous vous invitons à faire un don à la Fondation afin de nous soutenir !</asp:Label>
        <asp:HyperLink CssClass="btn btn-primary" runat="server" Target="_blank" Text="Faire un don à la fondation" NavigateUrl="https://www.rotary.org/fr/give"></asp:HyperLink>
    </div>
</asp:Panel>
<div class="row">
    <asp:Panel runat="server" ID="pnl_content" CssClass="col-sm-8">
	    <h3><asp:Label runat="server" ID="LBL_Titre2" Text="" /></h3>
        <asp:Panel runat="server" ID="pnl_advanced">
            <asp:Literal runat="server" ID="LTL_Texte2"  />
        </asp:Panel>
	    <asp:Panel runat="server" ID="pnl_simple">
            <asp:Repeater runat="server" ID="LI_Blocs" OnItemDataBound="LI_Blocs_ItemDataBound" >
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
                   
		            <div class="clear"></div>
                    </asp:Panel>
	            </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater>
	    </asp:Panel>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl_noContent" CssClass="col-sm-8" Visible="false">
        <h3>Vous n'avez pas encore de fiche professionnelle. Vous pouvez en créer une dès à présent ! Ce service est <em>gratuit</em>, néanmoins nous vous invitons à faire un don à la Fondation afin de soutenir le Rotary ! </h3><br />
        <asp:Button ID="btn_create" OnClick="btn_create_Click" runat="server" Text="Créer ma page" CssClass="btn btn-primary" />
    </asp:Panel>
    
    <asp:Panel ID="pnl_membre" runat="server" CssClass="col-sm-4 text-center">
	    <asp:Image runat="server" ID="IMG_Photo2" /><br />
        <strong><asp:Label runat="server" ID="LBL_Nom_Prenom2" /></strong>
        <asp:Label runat="server" ID="LBL_Fonction2" /><br />
        <asp:Label runat="server" ID="LBL_Classification2" />
        <div class="pe-spacer size10"></div>
        <asp:Label runat="server" ID="LBL_Societe" />
        <div class="pe-spacer size10"></div>
        <asp:Image runat="server" ID="IMG_Logo2" />
        <div class="pe-spacer size10"></div>
        <asp:HyperLink runat="server" ID="HLK_URL2"  Target="_blank" Text="Accès au site web"/><br />
        <asp:Hyperlink runat="server" ID="HLK_Contact2" Imageurl="/Portals/_default/Skins/Rotary/images/mail.png" ToolTip="Lui envoyer un message" Text="Lui envoyer un message" />
    </asp:Panel>

	<div class="clear"></div>
    
    
</div>
<asp:Button runat="server" CssClass="btn btn-primary" ID="BTN_Edit" Text="Modifier la présentation" OnClick="BTN_Edit_Click" />





