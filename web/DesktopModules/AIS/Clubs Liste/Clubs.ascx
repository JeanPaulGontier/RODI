<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Clubs.ascx.cs" Inherits="DesktopModules_AIS_Clubs_Liste" %>

<asp:Label runat="server" Text="Filtrer par département : "></asp:Label><asp:RadioButtonList ID="RB_Dept" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RB_Dept_SelectedIndexChanged" AutoPostBack="true"></asp:RadioButtonList>
<asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"  AllowSorting="True"  GridLines="None" PageSize="100" AllowPaging="False" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
<Columns>
    <asp:TemplateField HeaderText="Nom" SortExpression="name"><ItemTemplate><asp:HyperLink ID="HyperLink1" runat="server" Visible='<%# GetSeo(""+Eval("seo"))!="" %>' NavigateUrl='<%# GetSeo(""+Eval("seo")) %>'><%# Eval("name") %></asp:HyperLink></ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Adresse" SortExpression="adress_1" ItemStyle-Width="230"><ItemTemplate><asp:Label runat="server" Text='<%# GetAdresse(""+Eval("adress_1"),""+Eval("adress_2")) %>' /></ItemTemplate></asp:TemplateField>
    <asp:BoundField DataField="zip" HeaderText="Code Postal" SortExpression="zip"  ItemStyle-Width="50" />
    <asp:BoundField DataField="town" HeaderText="Ville" SortExpression="town" ItemStyle-Width="150" />
    <asp:TemplateField HeaderText="Email" SortExpression="email"  ItemStyle-Width="32"><ItemTemplate><a href="mailto:<%# Eval("email") %>"><img src="<%= PortalSettings.ActiveTab.SkinPath %>images/mail.png" title="Lui envoyer un message" /></a></ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Web" SortExpression="web" ItemStyle-Width="32"><ItemTemplate><asp:HyperLink runat="server" Visible='<%# Eval("web")!="" %>' NavigateUrl='<%# Eval("web") %>' Target="_blank" ToolTip="Consulter le site du club"><img src="<%= PortalSettings.ActiveTab.SkinPath %>images/web.png" title="Consulter le site du club" /></asp:HyperLink></ItemTemplate></asp:TemplateField>
</Columns>      
</asp:GridView>
<asp:HiddenField ID="tri" Value="name" runat="server"/><asp:HiddenField ID="sens" Value="ASC" runat="server"/>
