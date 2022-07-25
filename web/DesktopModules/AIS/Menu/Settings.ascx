<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Menu_Settings" %>


<table>
    <tr>
        <td>
            Afficher les sous-pages de : 
        </td>
        <td>
            <asp:DropDownList ID="ddl_tab" runat="server"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Rang maximum : 
        </td>
        <td>
            <asp:TextBox ID="tbx_rank" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>

