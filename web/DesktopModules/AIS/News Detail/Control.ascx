<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_News_Detail_Control" %>


<h1><asp:Label ID="LBL_Titre" runat="server" Text="" /></h1>

<div class="text-right">
	<asp:HyperLink ID="HLK_Club" runat="server" CssClass="Normal" />
	<asp:Label ID="LBL_Date" runat="server" Text="" CssClass="Date Normal"></asp:Label>
</div>
<div class="pe-spacer size10"></div>

<p class="text-justify Normal">
	<asp:Literal ID="LBL_Detail" runat="server" Text="" ></asp:Literal>
</p>
