<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Commission_View_Settings" %>

Éxécuter en mode administrateur ? 
<asp:RadioButtonList ID="rbl_admin" runat="server">
    <asp:ListItem Text="Oui" Value="true"></asp:ListItem>
    <asp:ListItem Text="Non" Value="false"></asp:ListItem>
</asp:RadioButtonList>