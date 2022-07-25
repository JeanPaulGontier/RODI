<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_News_Article_Settings" %>

<table>
    <tr>
        <td><asp:Label runat="server" Text="Chemin d'accès au fichiers : "></asp:Label></td>
        <td><asp:TextBox runat="server" ID="tbx_path" ></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Style : "></asp:Label></td>
        <td><asp:TextBox runat="server" ID="tbx_style" ></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Page d'impression : "></asp:Label></td>
        <td><asp:TextBox runat="server" ID="tbx_print" ></asp:TextBox></td>
    </tr>
</table>