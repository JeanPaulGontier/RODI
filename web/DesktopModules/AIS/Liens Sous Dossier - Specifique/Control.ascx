<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Liens_Sous_Dossier_Control" %>
<%= ""+Settings["header"] %>
<ul>
<asp:DataList ID="DataList1" runat="server" RepeatLayout="Flow" ItemStyle-CssClass="sousmenu" OnItemDataBound="DataList1_ItemDataBound">
    <ItemTemplate>
        <li>
        <asp:HyperLink runat="server" ID="HL_Nom"></trong><%# Eval("LocalizedTabName") %></asp:HyperLink>
        <asp:Label runat="server" ID="LBL_Nom"><strong><%# Eval("LocalizedTabName") %></strong></asp:Label>
        </li>
    </ItemTemplate>
</asp:DataList>
</ul>
<%= ""+Settings["footer"] %>