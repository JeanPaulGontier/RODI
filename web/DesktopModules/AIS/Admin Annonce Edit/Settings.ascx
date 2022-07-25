<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Page_Membre_Edit_Settings" %>
<asp:Label ID="Label1" runat="server" 
    Text="Page de l'annonce :"></asp:Label>&nbsp;
<asp:DropDownList ID="Tab" runat="server">
</asp:DropDownList>
<br />

<asp:Label ID="Label2" runat="server" 
    Text="Page de paiement :"></asp:Label>&nbsp;
<asp:DropDownList ID="Tab_Don" runat="server">
</asp:DropDownList>
<br />

<asp:Label ID="Label3" runat="server" 
    Text="Page de retour à l'espace pro :"></asp:Label>&nbsp;
<asp:DropDownList ID="Tab_Pro" runat="server">
</asp:DropDownList>
<br />