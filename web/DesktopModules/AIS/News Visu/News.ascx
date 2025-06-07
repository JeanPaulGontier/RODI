<%@ Control Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeFile="News.ascx.cs" Inherits="DesktopModules_AIS_News_Visu_News" %>
<asp:Repeater runat="server" ID="LI_News" OnItemDataBound="LI_News_ItemDataBound">
<HeaderTemplate><ul></HeaderTemplate>
<ItemTemplate><li class="BlocBlanc">
<asp:HyperLink ID="HL_Detail" runat="server">
<div class="LimitedHeight"><asp:Image ID="Image1" runat="server" /></div>
<!--<h5><span>District</span></h5>-->  <!-- a remplacer par un asp:label-->
<h2><asp:Label ID="LBL_Titre" runat="server" Text='<%# Bind("title") %>' /></h2>
<asp:Label ID="LBL_Date" runat="server" Text='<%# Bind("dt","{0:dd MMM yyyy}") %>' />
</asp:HyperLink>
</li></ItemTemplate>
<FooterTemplate></ul></FooterTemplate>
</asp:Repeater>
<asp:Label ID="lbl_noClubSelected" runat="server" Visible="false">Veuillez sélectionner un club</asp:Label>
<h3><asp:Label ID="lbl_noNews" runat="server" Visible="false" Text="Pas de news à afficher"></asp:Label></h3>

 <% if (isEmpty && !UserInfo.IsAdmin) { %>
     <script>
         var m = document.getElementsByClassName('DnnModule-<%= ModuleId %>');
         if (m && m.length > 0) {
             m[0].style.display = "none";
         }
     </script>
 <% } %>