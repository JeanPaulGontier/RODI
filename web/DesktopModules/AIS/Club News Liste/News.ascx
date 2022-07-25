<!--**********************************************************************************-->
<!-- RODI - https://rodi-platform.org                                                 -->
<!-- Copyright (c) 2012-2018                                                          -->
<!-- by SAS AIS : https://www.aisdev.net                                              -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeFile="News.ascx.cs" Inherits="DesktopModules_AIS_News_Visu_News" %>
<asp:Repeater runat="server" ID="LI_News" OnItemDataBound="LI_News_ItemDataBound">
    <HeaderTemplate>
        <ul style="list-style: none; margin: 0; padding: 0;">
    </HeaderTemplate>
    <ItemTemplate>
        <li style="list-style: none;">
<asp:HyperLink ID="HL_Detail" runat="server">
<asp:Panel runat="server" ID="PNews" CssClass="LimitedHeight relative">
	<asp:Image ID="Image1" runat="server" />
	<h2><asp:Label ID="LBL_Titre" runat="server" Text='<%# Bind("title") %>' /><asp:Label ID="LBL_Date" runat="server" Text='<%# Bind("dt","{0:dd MMM yyyy}") %>' CssClass="Date" /></h2>
</asp:Panel>
</asp:HyperLink>
</li></ItemTemplate>
<FooterTemplate></ul></FooterTemplate>
</asp:Repeater>
<asp:Label ID="lbl_noClubSelected" runat="server" Visible="false">Veuillez sélectionner un club</asp:Label>
<h3><asp:Label ID="lbl_noNews" runat="server" Visible="false" Text="Pas de news à afficher"></asp:Label></h3>