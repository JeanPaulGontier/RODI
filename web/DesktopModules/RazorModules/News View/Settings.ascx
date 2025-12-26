<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="NewsView_Settings" %>
<p>Afficher les boutons de partage :</p>
<asp:RadioButtonList ID="rsvisible" runat="server">
    <asp:ListItem Text="Oui" Value="oui"></asp:ListItem>
    <asp:ListItem Text="Non" Value="non"></asp:ListItem>
</asp:RadioButtonList>