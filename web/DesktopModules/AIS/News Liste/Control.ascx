<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_News_List_Control" %>
<asp:Repeater runat="server" ID="LI_News" OnItemDataBound="LI_News_ItemDataBound">
<HeaderTemplate><ul></HeaderTemplate>
<ItemTemplate><li>
<asp:HyperLink ID="HL_Detail" runat="server">
<p><asp:Image ID="Image1" runat="server" ImageAlign="Left"  /></p>
<asp:Label ID="LBL_Titre" runat="server" Text='<%# Bind("title") %>' />
</asp:HyperLink>
</li></ItemTemplate>
<FooterTemplate></ul></FooterTemplate>
</asp:Repeater>