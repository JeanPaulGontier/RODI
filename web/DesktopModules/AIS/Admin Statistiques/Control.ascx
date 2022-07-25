<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Statistiques_Control" %>
<p>
<asp:Label runat="server" Text="Nombre total de Rotariens : "  />
<asp:Label runat="server" Text="" ID="LBL_Nombre_Rotariens" />
<asp:Label runat="server" Text="" ID="LBL_Nombre_Detail" />
<asp:Label runat="server" Text=", de Rotaractiens : "  />
<asp:Label runat="server" Text="" ID="LBL_Nombre_Rotaractiens" />
<asp:Label runat="server" Text=", d'Interactiens : "  />
<asp:Label runat="server" Text="" ID="LBL_Nombre_Interact" />
</p>
<asp:GridView ID="GridView1" runat="server" CssClass="table table-stripped spacingBottom"  GridLines="None" PageSize="100" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AllowSorting="True">
    <Columns>
        <asp:BoundField DataField="Club" HeaderText="Club" SortExpression="Club" />
        <asp:BoundField DataField="Nb" HeaderText="Nb" ReadOnly="True" SortExpression="Nb" />
        <asp:BoundField DataField="Actif" HeaderText="Actif" ReadOnly="True" SortExpression="Actif" />
        <asp:BoundField DataField="Hono" HeaderText="Honoraire" ReadOnly="True" SortExpression="Hono" />
        <asp:BoundField DataField="Moyenne Age" HeaderText="Moyenne Age" ReadOnly="True" SortExpression="Moyenne Age" />
        <asp:BoundField DataField="% Hommes" HeaderText="% Hommes" ReadOnly="True" SortExpression="% Hommes" />
        <asp:BoundField DataField="% Femmes" HeaderText="% Femmes" ReadOnly="True" SortExpression="% Femmes" />
    </Columns>
</asp:GridView>
<asp:Button runat="server" ID="BT_Export_XLS" Text="Export Excel" OnClick="BT_Export_XLS_Click" />
<asp:Button runat="server" ID="BT_Export_CSV" Text="Export CSV" OnClick="BT_Export_CSV_Click" />
<asp:SqlDataSource runat="server" ID="SqlDataSource1" SelectCommand="select distinct club_name as 'Club',(select count(*) from ais_members M where M.club_name = A.club_name) as 'Nb',(select count(*) from ais_members M where M.club_name = A.club_name and M.honorary_member='O') as 'Hono',(select count(*) from ais_members M where M.club_name = A.club_name and M.honorary_member != 'O') as 'Actif',(select (avg(year(getdate())-year(birth_year))) from ais_members o where o.club_name = A.club_name and birth_year is not null) as 'Moyenne Age',((select count(*) from ais_members M where M.club_name = A.club_name and M.civility='M')*100/(select count(*) from ais_members M where M.club_name = A.club_name)) as '% Hommes',Round(100-(100*(select count(*) from ais_members M where M.club_name = A.club_name and M.civility='M')/(select count(*) from ais_members M where M.club_name = A.club_name)),0) as '% Femmes' from ais_members A order by Nb desc" ConnectionString="<%$ ConnectionStrings:SiteSqlServer %>"></asp:SqlDataSource>
