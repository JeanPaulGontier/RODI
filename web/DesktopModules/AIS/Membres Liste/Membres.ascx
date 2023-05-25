<%@ Control Language="C#"  AutoEventWireup="true" CodeFile="Membres.ascx.cs" Inherits="DesktopModules_AIS_News_Visu_News" %>

<div>
    <asp:Label ID="Label1" runat="server" Text="Afficher l'annuaire : "></asp:Label>
    <asp:RadioButton id="RBT_Pro" Checked="false" Text="professionel" GroupName="typeMembre" runat="server" OnCheckedChanged="RBT_Pro_CheckedChanged" AutoPostBack="true" Visible="false" />
    <asp:RadioButton id="RBT_General" Checked="true" Text="du district" GroupName="typeMembre" runat="server" OnCheckedChanged="RBT_General_CheckedChanged" AutoPostBack="true"/>
    <asp:RadioButton id="RBT_Club" Text="par club"  GroupName="typeMembre" runat="server" OnCheckedChanged="RBT_Club_CheckedChanged" AutoPostBack="true"/>
</div>

<asp:Panel runat="server" ID="PanelSearch">
    <asp:Label runat="server" Text="Recherche :"></asp:Label>
    <asp:TextBox runat="server" ID="TXT_Critere" AutoPostBack="true" OnTextChanged="TXT_Critere_TextChanged" ></asp:TextBox>
</asp:Panel>

<asp:Panel runat="server" ID="PanelSearchClub">
    <asp:Label runat="server" Text="Afficher les membres du club :"></asp:Label>
    <asp:DropDownList runat="server" ID="DL_Clubs" AutoPostBack="true" OnSelectedIndexChanged="DL_Clubs_SelectedIndexChanged"></asp:DropDownList>
</asp:Panel>
<div class="pe-spacer size30"></div>

<asp:Panel ID="PanelPro" runat="server">
    <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped"
    OnRowDataBound="GridView2_RowDataBound" 
    AllowSorting="True" GridLines="None" AllowPaging="True" PageSize="50" 
    OnPageIndexChanging="GridView2_PageIndexChanging" 
    OnRowCommand="GridView2_RowCommand" AutoGenerateColumns="False" OnSorting="GridView2_Sorting">
     
    <Columns>    
        <asp:BoundField DataField="civility" SortExpression="civility" ItemStyle-Width="32" />
        <asp:BoundField DataField="surname" HeaderText="Nom" SortExpression="surname"  />
        <asp:BoundField DataField="name" HeaderText="Prénom" SortExpression="name"  />
        <asp:BoundField DataField="title" HeaderText="Activité" SortExpression="title" />
        <asp:BoundField DataField="job" HeaderText="Profession" SortExpression="job" />
        <asp:BoundField DataField="industry" HeaderText="Branche activité" SortExpression="industry" />
        <asp:TemplateField HeaderText="Club" SortExpression="club_name"><ItemTemplate><asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" ><%# Eval("club_name") %></asp:HyperLink></ItemTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="" SortExpression="">
            <ItemTemplate>
                <asp:HyperLink ID="HLK_Presentation" runat="server" CssClass="SmallLink" >En voir plus
                    <%--<img src="<%= PortalSettings.ActiveTab.SkinPath %>images/icon_hostusers_32px.gif" title="Voir la présentation" />--%>
                </asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>

       <%-- <asp:TemplateField HeaderText="Email" SortExpression="email"  ItemStyle-Width="32">
            <ItemTemplate>
                <a href="javascript:dnnModal.show('/AIS/contact.aspx?id=<%# Eval("id") %>&popUp=true',false,350,500,false);">
                    <img src="<%= PortalSettings.ActiveTab.SkinPath %>images/mail.png" title="Lui envoyer un message" />
                </a>
            </ItemTemplate>
        </asp:TemplateField>--%>
    
    </Columns>    
   
        <EmptyDataTemplate>Désolé mais nous n'avons aucun membre pour les critères saisis</EmptyDataTemplate>
       <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
    </asp:GridView>
    <asp:HiddenField ID="tri2" Value="surname" runat="server"/>
    <asp:HiddenField ID="sens2" Value="ASC" runat="server"/>
</asp:Panel>


<asp:Panel ID="PanelGen" runat="server">
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" OnRowDataBound="GridView1_RowDataBound"  AllowSorting="True" GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
<Columns>
    <asp:BoundField DataField="civility" SortExpression="civility" ItemStyle-Width="32" />
    <asp:BoundField DataField="surname" HeaderText="Nom" SortExpression="surname"  />
    <asp:BoundField DataField="name" HeaderText="Prénom" SortExpression="name"  />
    <asp:BoundField DataField="job" HeaderText="Profession" SortExpression="job" />
    <asp:BoundField DataField="industry" HeaderText="Branche activité" SortExpression="industry" />
    <asp:TemplateField HeaderText="Club" SortExpression="club_name"><ItemTemplate><asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" ><%# Eval("club_name") %></asp:HyperLink></ItemTemplate></asp:TemplateField>

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

    <asp:TemplateField HeaderText="" SortExpression="">
            <ItemTemplate>
                <asp:HyperLink ID="HLK_Presentation" runat="server" CssClass="SmallLink" >En voir plus
                    <%--<img src="<%= PortalSettings.ActiveTab.SkinPath %>images/icon_hostusers_32px.gif" title="Voir la présentation" />--%>
                </asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
    
</Columns>    
   
    <EmptyDataTemplate>Désolé mais nous n'avons aucun membre pour les critères saisis</EmptyDataTemplate>
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
</asp:Panel>



<asp:HiddenField ID="tri" Value="surname" runat="server"/>
<asp:HiddenField ID="sens" Value="ASC" runat="server"/>
