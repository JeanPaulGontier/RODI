﻿<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Admin_Subscriptions_Settings" %>
<asp:Label ID="Label1" runat="server" 
    Text="Page d'annonce :"></asp:Label>&nbsp;
<asp:DropDownList ID="Tab" runat="server">
</asp:DropDownList>
<br />

<asp:Label ID="Label5" runat="server" 
    Text="Page de création d'annonce :"></asp:Label>&nbsp;
<asp:DropDownList ID="Tab_annonce_edit" runat="server">
</asp:DropDownList>
<br />

<asp:Label ID="Label2" runat="server" 
    Text="Page de renouvellement :"></asp:Label>&nbsp;
<asp:DropDownList ID="Tab_renouvellement" runat="server">
</asp:DropDownList>
<br />

<asp:Label ID="Label3" runat="server" 
    Text="Page de présentation :"></asp:Label>&nbsp;
<asp:DropDownList ID="Tab_presentation" runat="server">
</asp:DropDownList>
<br />

<asp:Label ID="Label4" runat="server" 
    Text="Page de création de présentation :"></asp:Label>&nbsp;
<asp:DropDownList ID="Tab_presentation_edit" runat="server">
</asp:DropDownList>
<br />
