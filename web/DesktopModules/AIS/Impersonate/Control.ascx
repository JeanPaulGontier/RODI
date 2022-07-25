<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Impersonate_Control" %>
<asp:UpdatePanel runat="server">
    <Triggers>
        <asp:PostBackTrigger ControlID="TXT_Username" />
        <asp:PostBackTrigger ControlID="BT_Impersonate" />
        <asp:PostBackTrigger ControlID="LI_Users" />
    </Triggers>
    <ContentTemplate>
        <label>Nom d'utilisateur</label>
        <asp:TextBox runat="server" ID="TXT_Username" OnTextChanged="TXT_Username_TextChanged" AutoPostBack="true"></asp:TextBox>
        <div><asp:ListBox  runat="server" ID="LI_Users" AutoPostBack="true" OnSelectedIndexChanged="LI_Users_SelectedIndexChanged"></asp:ListBox></div>
        <asp:Button runat="server" ID="BT_Impersonate"  Text="Se connecter en tant que" OnClick="BT_Impersonate_Click" CssClass="btn btn-primary" />

    </ContentTemplate>

</asp:UpdatePanel>