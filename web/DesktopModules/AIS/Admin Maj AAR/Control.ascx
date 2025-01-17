<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Maj_AAR_Control" %>

<div>
    <asp:Button style="margin-bottom:0.5em" ID="BT_Refresh_AAR" runat="server" Text="Mettre à jour les affectations des clubs" OnClick="BT_Refresh_AAR_Click" CssClass="btn btn-primary" />&nbsp;
    <asp:Button style="margin-bottom:0.5em" ID="BT_CreateUsersManquants" runat="server" Text="Créer les utilisateurs manquants" OnClick="BT_CreateUsersManquants_Click" CssClass="btn btn-primary" />&nbsp;
    <asp:Button style="margin-bottom:0.5em" ID="BT_PUU" runat="server" Text="Purge membres inutilisés" OnClick="BT_PUU_Click" CssClass="btn btn-primary" />&nbsp;
    <asp:Button style="margin-bottom:0.5em" ID="BT_CorrigerSEOClubs" runat="server" Text="Corriger SEO Clubs" OnClick="BT_CorrigerSEOClubs_Click" CssClass="btn btn-primary"></asp:Button>
    <asp:Button style="margin-bottom:0.5em" ID="BT_CorrigerNumerosTelephones" runat="server" Text="Corriger N° de téléphones des membres" OnClick="BT_CorrigerNumerosTelephones_Click" CssClass="btn btn-primary"></asp:Button>
</div>
<br />
<br />

<asp:Panel ID="pnl_error" Visible="false" runat="server" CssClass="panel panel-danger">
    <div class="panel-heading"><p>Une erreur est survenue lors de l'opération !</p></div>
</asp:Panel>
<asp:Panel ID="pnl_success" runat="server" CssClass="panel panel-success" Visible="false">
    <div class="panel-heading"><p>L'opération s'est bien effectuée</p></div>
</asp:Panel>


<asp:Literal ID="TXT_Result" runat="server"></asp:Literal>
