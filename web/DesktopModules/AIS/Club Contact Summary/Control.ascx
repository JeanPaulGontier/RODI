<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2018                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Club_Contact_Control" %>

<div class="animation fadeInRight">
    <div class="contact_info">
        <p>
            <span style="font-size: 16px;"><strong>
                <asp:Label runat="server" ID="L_Nom" /></strong></span>
            <br />
            <asp:Label runat="server" ID="L_Adresse" />
        </p>
        <p>
            Tel&nbsp;:&nbsp;<asp:Label runat="server" ID="L_Phone" /><br />
            Fax&nbsp;:&nbsp;<asp:Label runat="server" ID="L_Fax" />
        </p>
        <p>Email&nbsp;:&nbsp;<span><asp:Hyperlink runat="server" ID="H_Email"></asp:Hyperlink></span></p>
        <p>Web&nbsp;:&nbsp;<span><asp:HyperLink runat="server" ID="H_Web"></asp:HyperLink></span></p>
    </div>
</div>
