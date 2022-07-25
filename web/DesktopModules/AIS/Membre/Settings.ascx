<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_News_Visu_Settings" %>
<table>
    <tr>
        <td><asp:Label runat="server" Text="NIM du membre :"></asp:Label></td>
        <td><asp:TextBox ID="TXT_NIM" runat="server" MaxLength="10"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="Label1" runat="server" Text="Nom du membre :"></asp:Label></td>
        <td><asp:Label ID="LBL_Nom" runat="server" Text="..."></asp:Label></td>
    </tr>
    <tr>
        <td><asp:Label ID="Label2" runat="server" Text="Libelle :"></asp:Label></td>
        <td><asp:TextBox ID="TXT_Libelle" runat="server" TextMode="MultiLine" Height="100" /></td>
    </tr>
</table>
<asp:HiddenField runat="server" ID="HF_ID" />