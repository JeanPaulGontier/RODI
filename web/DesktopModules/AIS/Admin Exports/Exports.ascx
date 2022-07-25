<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Exports.ascx.cs" Inherits="DesktopModules_AIS_Admin_Exports_Exports" %>

<asp:Panel runat="server" ID="panel">
    <div>
        <h2>Année Rotarienne actuelle</h2>
        <asp:Button ID="btn_exportPresActuel" runat="server" OnClick="btn_exportPresActuel_Click" CssClass="btn btn-primary" Text="Exporter les présidents" />
        <asp:Button ID="btn_exportBureauActuel" runat="server" OnClick="btn_exportBureauActuel_Click" CssClass="btn btn-primary" Text="Exporter le bureau" />
    </div>
    <div>
        <h2>Année Rotarienne prochaine</h2>
        <asp:Button ID="btn_exportPres" runat="server" OnClick="btn_exportPres_Click" CssClass="btn btn-primary" Text="Exporter les présidents élus" />
        <asp:Button ID="btn_exportBureau" runat="server" OnClick="btn_exportBureau_Click" CssClass="btn btn-primary" Text="Exporter le bureau déclaré " />
        <asp:Button ID="btn_exportBureauComplet" runat="server" OnClick="btn_exportBureauComplet_Click" CssClass="btn btn-primary" Text="Exporter le bureau déclaré complet" />
        <asp:Button ID="btn_exportClubsSansBureau" runat="server" OnClick="btn_exportClubsSansBureau_Click" CssClass="btn btn-primary" Text="Exporter les clubs qui n'ont pas déclaré de bureau" />
    </div>
</asp:Panel>


