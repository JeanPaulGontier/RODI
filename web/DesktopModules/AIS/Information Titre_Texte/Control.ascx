
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Information_Titre_Texte_Control" %>

    <h2 style="margin-top:-10px;">        
        <asp:Label runat="server" ID="lbl_Title" CssClass="c_title_RoyalBlue" />
    </h2>

    <asp:Label runat="server" ID="lbl_Text" />

<asp:Panel ID="pnl_Modify" runat="server" Visible="false">
<br />
<asp:Button ID="btn_Modify" runat="server" Text="Modifier" CssClass="btn btn-warning" OnClick="btn_Modify_Click" />
</asp:Panel>

