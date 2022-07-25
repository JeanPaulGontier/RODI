<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_News_Detail_Control" %>

<asp:Image ID="Image1" runat="server" />

<h1><asp:Label ID="LBL_Titre" runat="server" Text="" /></h1>

<div class="text-right">
	<asp:HyperLink ID="HLK_Club" runat="server" CssClass="Normal" />
	<asp:Label ID="LBL_Date" runat="server" Text="" CssClass="Date Normal"></asp:Label>
</div>
<div class="pe-spacer size10"></div>

<p class="text-justify Normal">
	<asp:Literal ID="LBL_Detail" runat="server" Text="" ></asp:Literal>
</p>

<asp:Label ID="LBL_Url" runat="server" Text="Document à télécharger : " CssClass="Normal"></asp:Label>
<asp:HyperLink ID="HL_Url" runat="server" Target="_blank" CssClass="Normal"></asp:HyperLink>

<script type="text/javascript" src="http://w.sharethis.com/button/buttons.js"></script>
<script type="text/javascript" stLight.options({ publisher: "ur-2d12a09a-60ba-4999-196a-7d351be3cccc", doNotHash: true, doNotCopy: true, hashAddressBar: false });></script>

<div class="pe-spacer size10"></div>
<div class="text-right">
    <a class='st_facebook_large' displayText='Facebook'></a>
    <a class='st_twitter_large' displayText='Tweet'></a>
    <a class='st_googleplus_large' displayText='Google +'></a>
    <a class='st_linkedin_large' displayText='LinkedIn'></a>
    <a class='st_viadeo_large' displayText='Viadeo'></a>
</div>