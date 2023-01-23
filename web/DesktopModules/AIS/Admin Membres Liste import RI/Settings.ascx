<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_Membres_Liste_Settings" %>

<asp:Label ID="Label3" runat="server" 
    Text="Page de présentation :"></asp:Label>&nbsp;
<asp:DropDownList ID="Tab_presentation" runat="server">
</asp:DropDownList>
<asp:RadioButtonList ID="rbl_mode" runat="server">
    <asp:ListItem Text="Club" Value="club"></asp:ListItem>
    <asp:ListItem Text="District" Value="district"></asp:ListItem>
</asp:RadioButtonList>
<br />
