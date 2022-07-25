<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" ViewStateMode="Disabled" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_News_Galerie_Control" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<telerik:RadRotator runat="server" ID="N_Gallerie1" OnItemDataBound="N_Gallerie1_ItemDataBound" RotatorType="AutomaticAdvance" FrameDuration="3000" ItemWidth="980" ItemHeight="415" Width="980" Height="415">
<ItemTemplate><div><asp:HyperLink runat="server" ID="HL_Detail" ><asp:Image ID="Image1" runat="server" /></asp:HyperLink></div></ItemTemplate>
</telerik:RadRotator>