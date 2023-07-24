<%@ Control Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeFile="News.ascx.cs" Inherits="DesktopModules_AIS_News_Visu_News" %>
<asp:Repeater runat="server" ID="LI_News" OnItemDataBound="LI_News_ItemDataBound">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li class="BlocBlanc">
            <asp:HyperLink ID="HL_Detail" runat="server">
                <asp:Panel runat="server" ID="PNews" CssClass="LimitedHeight" Visible="false">
                    <asp:Image ID="Image1" runat="server" />
                </asp:Panel>
                <h2>
                    <asp:Label ID="LBL_Titre" runat="server" Text='<%# Bind("title") %>' />
                </h2>
                <asp:Label ID="LBL_Date" runat="server" Text='<%# Bind("dt","{0:dd MMM yyyy}") %>' CssClass="Date" />
            </asp:HyperLink>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>

<asp:Label ID="lbl_noClubSelected" runat="server" Visible="false">Veuillez sélectionner un club</asp:Label>
<h3><asp:Label ID="lbl_noNews" runat="server" Visible="false" Text="Pas de news à afficher"></asp:Label></h3>