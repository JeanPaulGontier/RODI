<%@ Control Language="C#"  AutoEventWireup="true" CodeFile="Membres.ascx.cs" Inherits="DesktopModules_AIS_Members_Liste_Presentation" %>

<asp:Panel runat="server" ID="PanelSearch">
    <asp:Label ID="Label1" runat="server" Text="Recherche :"></asp:Label>
    <asp:TextBox runat="server" ID="TXT_Critere" AutoPostBack="true" OnTextChanged="TXT_Critere_TextChanged" ></asp:TextBox>
</asp:Panel>

<asp:Panel runat="server" ID="PanelSearchClub">
    <asp:Label ID="Label2" runat="server" Text="Club :"></asp:Label>
    <asp:DropDownList runat="server" ID="DL_Clubs" Width="418px" AutoPostBack="true" OnSelectedIndexChanged="DL_Clubs_SelectedIndexChanged"></asp:DropDownList>
</asp:Panel>


<style>
    .presentationColWidth{
        width:25%
    }
</style>

<asp:GridView ID="GridView1" 
    runat="server" 
    CssClass="table table-striped"
    OnRowDataBound="GridView1_RowDataBound" 
    AllowSorting="True" GridLines="None" AllowPaging="True" PageSize="50" 
    OnPageIndexChanging="GridView1_PageIndexChanging" 
    OnRowCommand="GridView1_RowCommand"
    
    AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
     
<Columns>    
    <asp:BoundField DataField="civility" SortExpression="civility" ItemStyle-Width="32" />
    <asp:BoundField DataField="surname" HeaderText="Nom" SortExpression="surname"  />
    <asp:BoundField DataField="name" HeaderText="Prénom" SortExpression="name"  />
    <asp:BoundField DataField="job" HeaderText="Profession" SortExpression="job" ItemStyle-CssClass="presentationColWidth" />
    <asp:BoundField DataField="industry" HeaderText="Activité" SortExpression="industry"  ItemStyle-CssClass="presentationColWidth" />
    <asp:TemplateField HeaderText="" SortExpression="presentation">
            <ItemTemplate>
                <asp:HyperLink ID="HLK_Presentation" CssClass="btn btn-link" runat="server" >En voir plus</asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
   <%-- <asp:BoundField DataField="fonction_metier" HeaderText="Profession" SortExpression="fonction_metier" />
    <asp:BoundField DataField="branche_activite" HeaderText="Branche activité" SortExpression="branche_activite" />
    <asp:TemplateField HeaderText="Club" SortExpression="nom_club"><ItemTemplate><asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" ><%# Eval("club_name") %></asp:HyperLink></ItemTemplate></asp:TemplateField>

    <asp:TemplateField HeaderText="Présentation" SortExpression="presentation">
        <ItemTemplate>
            <asp:HyperLink ID="HLK_Presentation" runat="server" >
                <img src="<%= PortalSettings.ActiveTab.SkinPath %>images/icon_hostusers_32px.gif" title="Voir la présentation" />
            </asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Email" SortExpression="email"  ItemStyle-Width="32">
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
<asp:HiddenField ID="tri" Value="name" runat="server"/>
<asp:HiddenField ID="sens" Value="ASC" runat="server"/>
