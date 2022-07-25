<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContainerControl.ascx.cs" Inherits="AIS_News_ContainerControl" %>

<div>
    <div>
        <asp:Label ID="lbl_container_title" runat="server" Text="Titre" />
        <asp:TextBox ID="tbx_container_title" runat="server" />
        <asp:Button ID="btn_container_titleOK" runat="server" Text="Valider" OnClick="btn_titleOK_Click" ToolTip="Valider le titre" />
        <asp:Button ID="btn_container_titleCANCEL" runat="server" Text="Annuler" OnClick="btn_titleCANCEL_Click" ToolTip="Annuler le titre" />
    </div>

    <div>
        <asp:PlaceHolder ID="phl_container_UC" runat="server" />
    </div>

</div>

<div>
    <asp:Button ID="btn_container_up" runat="server" Text="Monter" OnClick="btn_container_up_Click" ToolTip="Monter le bloc"  />
    <asp:Button ID="btn_container_down" runat="server" Text="Descendre" OnClick="btn_container_down_Click" ToolTip="Descendre le bloc"  />
    <asp:Button ID="btn_container_Delete" runat="server" Text="Supprimer" OnClick="btn_container_Delete_Click" ToolTip="Supprimer le bloc"  />
</div>
