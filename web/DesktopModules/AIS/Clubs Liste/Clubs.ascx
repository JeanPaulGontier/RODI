<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Clubs.ascx.cs" Inherits="DesktopModules_AIS_Clubs_Liste" %>

<asp:Panel runat="server" Visible="false"><asp:Label runat="server" Text="Filtrer par département : "></asp:Label><asp:RadioButtonList ID="RB_Dept" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RB_Dept_SelectedIndexChanged" AutoPostBack="true"></asp:RadioButtonList></asp:Panel>

<asp:GridView ID="GridView1" runat="server" ShowHeader="false" CssClass="table table-striped"  AllowSorting="False"  GridLines="None" PageSize="100" AllowPaging="False" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
<Columns>
    <asp:TemplateField ><ItemTemplate><asp:HyperLink ID="HyperLink1" runat="server" Visible='<%# GetSeo((int)Eval("cric"))!="" %>' NavigateUrl='<%# GetSeo((int)Eval("cric")) %>'><%# Eval("name") %></asp:HyperLink></ItemTemplate></asp:TemplateField>
    <asp:TemplateField Visible="false" HeaderText="Adresse" SortExpression="adress_1" ItemStyle-Width="230"><ItemTemplate><asp:Label runat="server" Text='<%# GetAdresse(""+Eval("adress_1"),""+Eval("adress_2")) %>' /></ItemTemplate></asp:TemplateField>
    <asp:BoundField Visible="false" DataField="zip" HeaderText="Code Postal" SortExpression="zip"  ItemStyle-Width="50" />
    <asp:BoundField Visible="false" DataField="town" HeaderText="Ville" SortExpression="town" ItemStyle-Width="150" />
    <asp:TemplateField ItemStyle-Width="32"><ItemTemplate><asp:HyperLink runat="server" Visible='<%# (""+Eval("email"))!="" %>' NavigateUrl='<%# GetSeo((int)Eval("cric"))+"Contact" %>'><img src="<%= PortalSettings.ActiveTab.SkinPath %>images/mail.png" title="Contacter le club" /></asp:HyperLink></ItemTemplate></asp:TemplateField>
    <asp:TemplateField ItemStyle-Width="32"><ItemTemplate><asp:HyperLink runat="server" Visible='<%# (""+Eval("web"))!="" %>' NavigateUrl='<%# Eval("web") %>' Target="_blank" ToolTip="Consulter le site du club"><img src="<%= PortalSettings.ActiveTab.SkinPath %>images/web.png" title="Consulter le site du club" /></asp:HyperLink></ItemTemplate></asp:TemplateField>
</Columns>      
</asp:GridView>
<asp:HiddenField ID="tri" Value="name" runat="server"/><asp:HiddenField ID="sens" Value="ASC" runat="server"/>
