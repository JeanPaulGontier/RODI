<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Club_Map_Control" %>


<asp:Button Text="Mettre à jour les coordonnées GPS des clubs" runat="server" Id="BTN_MAJ" OnClick="BTN_MAJ_Click" />  

<div>
    <asp:Literal id="LTL_Result" runat="server"/>
</div>