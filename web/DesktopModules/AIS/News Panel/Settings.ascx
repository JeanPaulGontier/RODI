<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_News_Panel_Settings" %>
<table>
    <tr>
        <td><asp:Label runat="server" Text="Page de détail :"></asp:Label></td>
        <td><asp:DropDownList ID="Tab" runat="server" Width="300"></asp:DropDownList></td>
    </tr>
    <tr>
        <td><asp:Label ID="TXT_Categorie" runat="server" Text="Catégorie :"></asp:Label></td>
        <td><asp:RadioButtonList ID="RB_Categorie" runat="server" RepeatDirection="Horizontal"><asp:ListItem Text="District" Value="District"></asp:ListItem><asp:ListItem Text="Clubs" Value="Clubs"></asp:ListItem><asp:ListItem Text="Courrier district" Value="courrierdistrict"></asp:ListItem></asp:RadioButtonList></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Nombre de news :"></asp:Label></td>
        <td><asp:TextBox ID="TXT_NB_News" runat="server" MaxLength="2" Width="50"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Style :</td>
        <td><asp:TextBox ID="TXT_Style" runat="server" MaxLength="50" Width="300px"></asp:TextBox></td>
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
    <tr>
        <td><asp:Label runat="server" Text="Chemin d'accès au fichiers : "></asp:Label></td>
        <td><asp:TextBox runat="server" ID="tbx_path" ></asp:TextBox></td>
    </tr>
</table>