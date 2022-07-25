<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AnnonceViewer.ascx.cs" Inherits="DesktopModules_AIS_AnnonceViewer_AnnonceViewer" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div class="BlocBlanc" style="padding:10px;">
<asp:Panel ID="Panel1" runat="server">
	<asp:Hyperlink runat="server" ID="Hyperlink1"  ToolTip="Voir l'annonce" CssClass="Annonce" >
		<asp:Label runat="server" ID="Label1" Text="" />
		<asp:Literal runat="server" ID="Literal1"  />
	</asp:HyperLink>
</asp:Panel>

<asp:Panel ID="Panel2" runat="server">
	<asp:Hyperlink runat="server" ID="Hyperlink2"  ToolTip="Voir l'annonce" CssClass="Annonce" >
		<asp:Label runat="server" ID="Label2" Text="" />
		<asp:Literal runat="server" ID="Literal2"  />
	</asp:HyperLink>
</asp:Panel>

<asp:Panel ID="Panel3" runat="server">
	<asp:Hyperlink runat="server" ID="HLK_Annonces"  ToolTip="Voir toutes les annonces" Text="Voir toutes les annonces" />
</asp:Panel>
</div>





