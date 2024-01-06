<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Création_Courrier_Settings" %>

<table>
    <tr>
        <td><asp:Label Text="Nom de la page parente : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_page" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label Text="Role autorisé à modifier : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_role" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
        <td><asp:Label Text="Role autorisé à lire : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_role_readonly" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label Text="Chemin d'accès aux fichiers par défaut : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_path" runat="server" ></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label Text="Style du bandeau : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_style" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label Text="Page d'impression : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_impress" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label Text="Chemin racine de redirection : " runat="server"></asp:Label></td>
        <td><asp:TextBox ID="tbx_redirect" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label Text="Zone article gauche : " runat="server"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbx_article_gauche" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label Text="Zone article droite : " runat="server"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbx_article_droite" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label Text="Zone détail article gauche : " runat="server"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbx_article_detail_gauche" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label Text="Zone détail article droite : " runat="server"></asp:Label></td>
        <td>
            <asp:TextBox ID="tbx_article_detail_droite" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td>    <asp:Button runat="server" CssClass="dnnSecondaryAction" Text="Paramètres par défaut"  ID="tb_reset" OnClick="tb_reset_Click"/>
</td>
    </tr>
</table>

