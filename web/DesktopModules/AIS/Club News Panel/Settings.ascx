<!--**********************************************************************************-->
<!-- RODI - https://rodi-platform.org                                                 -->
<!-- Copyright (c) 2012-2019                                                          -->
<!-- by SAS AIS : https://www.aisdev.net                                              -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Club_News_Panel_Settings" %>
<table>
    <tr>
        <td><asp:Label runat="server" Text="Page de détail :"></asp:Label></td>
        <td><asp:DropDownList ID="Tab" runat="server" Width="300"></asp:DropDownList></td>
    </tr>
    
    <tr>
        <td><asp:Label runat="server" Text="Nombre de news :"></asp:Label></td>
        <td><asp:TextBox ID="TXT_NB_News" runat="server" MaxLength="2" Width="50"></asp:TextBox></td>
    </tr>

</table>