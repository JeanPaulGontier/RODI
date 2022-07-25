<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Annonce.ascx.cs" Inherits="DesktopModules_AIS_Admin_Annonce_Annonce" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Panel CssClass="panel panel-info" runat="server" ID="pnl_modif" Visible="false">
    <div class="panel-heading">
        <asp:Label runat="server">Vos modifications ont bien été enregistrées. Nous vous invitons à faire un don à la Fondation afin de nous soutenir !</asp:Label>
        <asp:HyperLink CssClass="btn btn-primary" runat="server" Target="_blank" Text="Faire un don à la fondation" NavigateUrl="https://www.rotary.org/fr/give"></asp:HyperLink>
    </div>
</asp:Panel>

<asp:Button runat="server" ID="btn_newAnnonce" Text="Passer une annonce" CssClass="btn btn-primary" OnClick="btn_newAnnonce_Click" />

<asp:Panel ID="Panel2" CssClass="row" runat="server">
    <div class="col-sm-8">
        <asp:Panel ID="pnl_advanced" runat="server">
            <h3><asp:Label runat="server" ID="LBL_Titre2" Text="" /></h3>
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
        
    </div>

    <div class="col-sm-4">
        <asp:Image runat="server" ID="IMG_Logo2" />
        <asp:HyperLink runat="server" ID="HLK_URL2"   Target="_blank" Text="Télécharger le fichier"/>
        <asp:Hyperlink runat="server" ID="HLK_Contact2" Imageurl="/Portals/_default/Skins/Rotary/images/mail.png" ToolTip="Lui envoyer un message" Text="Lui envoyer un message" />
    </div>
    
    <div class="clear"></div>
    

</asp:Panel>
<asp:Button runat="server" ID="BTN_Edit" CssClass="btn btn-primary" Text="Modifier l'annonce" OnClick="BTN_Edit_Click" />




