<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Club_News_Panel_Settings" %>
<table>
    <tr>
        <td><asp:Label runat="server" Text="Page de détail :"></asp:Label></td>
        <td><asp:DropDownList ID="Tab" runat="server" Width="300"></asp:DropDownList></td>
    </tr>
    
    <tr>
        <td><asp:Label runat="server" Text="Nombre de news :"></asp:Label></td>
        <td><asp:TextBox ID="TXT_NB_News" runat="server" MaxLength="2" Width="50"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label runat="server" Text="Afficher seulement l'image d'accroche :"></asp:Label></td>
        <td><asp:RadioButtonList ID="RB_Visu_Link" runat="server">
            <asp:ListItem Text="Oui" Value="O"></asp:ListItem>
            <asp:ListItem Text="Non" Value="N"></asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
     <tr>
         <td><asp:Label runat="server" Text="Class contour :"></asp:Label></td>
         <td><asp:TextBox ID="TXT_Class" runat="server" MaxLength="50" Width="150"></asp:TextBox></td>
     </tr>
      <tr>
          <td><asp:Label runat="server" Text="Class contour admin :"></asp:Label></td>
          <td><asp:TextBox ID="TXT_ClassAdmin" runat="server" MaxLength="50" Width="150"></asp:TextBox></td>
      </tr>

</table>