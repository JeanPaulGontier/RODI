<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Admin_News_Liste_Settings" %>

<p>Mode de fonctionnement :</p>
<asp:RadioButtonList ID="mode" runat="server">
    <asp:ListItem Text="Clubs" Value="clubs"></asp:ListItem>
    <asp:ListItem Text="District" Value="district"></asp:ListItem>
</asp:RadioButtonList>

<p>Catégories (une par ligne) : <asp:LinkButton runat="server" ID="btreset" OnClick="btreset_Click">Remettre par défaut</asp:LinkButton></p>
<asp:TextBox TextMode="MultiLine" runat="server" ID="categories" Rows="10"></asp:TextBox>
