<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#"  AutoEventWireup="true" CodeFile="Membres.ascx.cs" Inherits="DesktopModules_AIS_News_Visu_News" %>


<asp:Panel ID="PanelGen" runat="server">
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" OnRowDataBound="GridView1_RowDataBound"  AllowSorting="True" GridLines="None" AllowPaging="False" PageSize="500" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
<Columns>
    <asp:BoundField DataField="civility" SortExpression="civility" ItemStyle-Width="32" />
    <asp:BoundField DataField="surname" HeaderText="Nom" SortExpression="surname"  />
    <asp:BoundField DataField="name" HeaderText="Prénom" SortExpression="name"  />
    <asp:BoundField DataField="job" HeaderText="Profession" SortExpression="job" />
    <asp:BoundField DataField="industry" HeaderText="Branche activité" SortExpression="industry" />
    
    <%--<asp:TemplateField HeaderText="Présentation" SortExpression="presentation">
        <ItemTemplate>
            <asp:HyperLink ID="HLK_Presentation" runat="server">
                <img src="<%= PortalSettings.ActiveTab.SkinPath %>images/icon_hostusers_32px.gif" title="Voir la présentation" />
            </asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>--%>

    <asp:TemplateField HeaderText="Email" SortExpression="email"  ItemStyle-Width="32">
        <ItemTemplate>
            <%--<a href="javascript:dnnModal.show('/AIS/contact.aspx?id=<%# Eval("id") %>&popUp=true',false,350,500,false);">--%>
            <a href=<%# GetUrl(Eval("id").ToString()) %>>
                <img src="<%= PortalSettings.ActiveTab.SkinPath %>images/mail.png" title="Lui envoyer un message" />
            </a>
        </ItemTemplate>
    </asp:TemplateField>

   
</Columns>    
   
    <EmptyDataTemplate>Désolé mais nous n'avons aucun membre pour les critères saisis</EmptyDataTemplate>
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
</asp:Panel>



<asp:HiddenField ID="tri" Value="surname" runat="server" />
<asp:HiddenField ID="sens" Value="ASC" runat="server"/>
