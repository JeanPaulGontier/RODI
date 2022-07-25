<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Liens_Sous_Dossier___Specifique_Settings" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>
<div>
    <label>Page parente : </label>
    <br />
    <asp:DropDownList runat="server" ID="parenttab" Width="80%"></asp:DropDownList>
</div>
<div>
    <label>Trier par : </label>
    <br />
    <asp:DropDownList runat="server" ID="sortby" Width="80%">
        <asp:ListItem Text="Ordre croissant" Value="asc"></asp:ListItem>
        <asp:ListItem Text="Ordre décroissant" Value="desc"></asp:ListItem>
    </asp:DropDownList>
</div>
<div>
    <label>NB Max : </label>
    <br />
   <asp:TextBox ID="nbmax" runat="server" ></asp:TextBox>
</div>
<div>
    <label>Header : </label>
    <br />
    <dnn:TextEditor runat="server" ID="header" Width="80%" Height="200"  />
</div>
<div>
    <label>Footer : </label>
    <br />
    <dnn:TextEditor runat="server" ID="footer" Width="80%" Height="200" />
</div>
