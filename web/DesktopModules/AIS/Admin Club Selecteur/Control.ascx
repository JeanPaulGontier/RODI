
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Club_Selecteur" %>
<asp:Label ID="Label1" runat="server" Text="Je gère le club : "></asp:Label>
<asp:DropDownList runat="server" ID="DL_Clubs" AutoPostBack="true" OnSelectedIndexChanged="DL_Clubs_SelectedIndexChanged"></asp:DropDownList>
<%-- <asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Ajouter" Visible="false" Text="Ajouter" OnClick="BT_Ajouter_Click" ToolTip="Ajouter un club rotaract"/>		--%>

