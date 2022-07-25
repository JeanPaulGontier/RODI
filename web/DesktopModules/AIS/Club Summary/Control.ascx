<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2018                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Club_Nouvelles_Control" %>

<div class="pe-spacer size10"></div>
<div class="animated fadeInUp">
    <p style="text-align: center;">
        <asp:Image runat="server" ID="I_Photo" /><br />
        <strong><asp:Label runat="server" ID="L_President"></asp:Label></strong><br />
        <asp:Label runat="server" ID="L_Annee"></asp:Label><br />
        <asp:Label runat="server" ID="L_Motdupresident"></asp:Label>
    </p>
</div>
<div class="pe-spacer size50"></div>
<div class="animated fadeInUp">
    <p style="text-align: center;">
        <asp:Image runat="server" ID="I_Fanion" /><br />
        <span style="font-size: 16px;"><strong><asp:Label runat="server" ID="L_Nom" /></strong></span>
        <br />
        <asp:Label runat="server" ID="L_Adresse" />
    </p>
</div>
