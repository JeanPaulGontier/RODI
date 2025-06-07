<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_News_Visu_Settings" %>
<table>
    <tr>
        <td><asp:Label runat="server" Text="Page de détail :"></asp:Label></td>
        <td><asp:DropDownList ID="Tab" runat="server" Width="300"></asp:DropDownList></td>
    </tr>
    <tr>
     <td><asp:Label runat="server" Text="Masquer si pas de nouvelles :"></asp:Label></td>
     <td><asp:CheckBox ID="CHK_Mask" runat="server" Width="300"></asp:CheckBox></td>
     </tr>
    <tr>
        <td><asp:Label ID="TXT_Categorie" runat="server" Text="Catégorie :"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="RB_Categorie" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Club courant" Value="clubCourant"></asp:ListItem>
                <asp:ListItem Text="Club sélectionné" Value="selectedClub"></asp:ListItem>
                <asp:ListItem Text="Clubs" Value="Clubs"></asp:ListItem>
                <asp:ListItem Text="District" Value="District"></asp:ListItem>

            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Nombre de news :"></asp:Label></td>
        <td><asp:TextBox ID="TXT_NB_News" runat="server" MaxLength="2" Width="50"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Tags a inclure :"></asp:Label>
            <br />
            (1 par ligne)</td>
        <td><asp:TextBox ID="TXT_Tags_Inclus" runat="server"  Rows="5" TextMode="MultiLine" Width="300"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Tags a exclure :"></asp:Label>
            <br />
            (1 par ligne)</td>
        <td><asp:TextBox ID="TXT_Tags_Exclus" runat="server"  Rows="5" TextMode="MultiLine"  Width="300"></asp:TextBox></td>
    </tr>
</table>