<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Actions Club Liste.ascx.cs" Inherits="DesktopModules_AIS_Actions_Club_Liste_Actions_Club_Liste" %>

<asp:GridView ID="gvw_liste" CssClass="table table-striped"  GridLines="None" AllowPaging="True" PageSize="50"  AutoGenerateColumns="false" runat="server" OnRowDataBound="gvw_liste_RowDataBound" >
    <Columns>
        <asp:BoundField  DataFormatString="{0:d}" DataField="dt" HeaderText="Date" SortExpression="dt" />
        <asp:BoundField DataField="title" HeaderText="Action" SortExpression="title" />
        <asp:TemplateField HeaderText="Organisé par le club">
            <ItemTemplate>
                <asp:Label ID="lbl_club" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>     
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="hlk_more" runat="server">En savoir plus...</asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>   
    </Columns>

</asp:GridView>