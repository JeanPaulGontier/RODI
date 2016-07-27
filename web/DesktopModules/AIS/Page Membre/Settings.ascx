<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Page_Membre_Settings" %>
<asp:Label ID="Label1" runat="server" 
    Text="Page d'édition de présentation :"></asp:Label>&nbsp;
<asp:DropDownList ID="Tab" runat="server">
</asp:DropDownList>
<br />
Type de page : 
<asp:RadioButtonList ID="type" runat="server" RepeatDirection="Horizontal">
    <asp:ListItem Text="Ma page" Value="mypage"></asp:ListItem>
    <asp:ListItem Text="N'importe quelle page" Value="anypage"></asp:ListItem>
</asp:RadioButtonList>
<br />

