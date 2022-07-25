<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreationCourrier.ascx.cs" Inherits="DesktopModules_AIS_Création_Courrier_CreationCourrier" %>


<asp:Panel runat="server" ID="pnl_page">

    
    <p> Année et mois du courrier : <asp:DropDownList ID="ddl_year" runat="server"></asp:DropDownList> <asp:DropDownList ID="ddl_month" runat="server"></asp:DropDownList></p>
    
    <br />
    <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_creation" Text="Créer les pages" OnClick="btn_creation_Click"/>
</asp:Panel>

<asp:Panel runat="server" ID="pnl_error" Visible="false">
    <asp:Label runat="server" Visible="true" ID="lbl_pageExists" Text="La page que vous essayez de créer existe déjà "></asp:Label><asp:HyperLink ID="hlk_pageExists" runat="server" CssClass="btn btn-primary" Text=" ici"></asp:HyperLink>
    <asp:Label runat="server" Visible="false" ID="lbl_pageInBin" Text="truc"> La page a déjà été créée puis effacée, il faut d'abord vider la corbeille afin de pouvoir la recréer</asp:Label>
    <br />
    <asp:Button runat="server" CssClass="btn btn-default" Text="Retour" ID="btn_back" OnClick="btn_back_Click" />
    
</asp:Panel>

<asp:Panel runat="server" ID="pnl_success" Visible="false">
    <asp:Label runat="server" Text="Vos pages ont été créées"></asp:Label>
</asp:Panel>
