<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Club_Map_Control" %>

<asp:Literal id="LTL_API_Google" runat="server"/>
<asp:Literal id="LTL_Map" runat="server"/>
<div style="margin:0;padding:0;">
<div id="map_canvas" style="width: 960px; height:500px"></div>
</div>