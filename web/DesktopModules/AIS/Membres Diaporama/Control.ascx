<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Members_Diaporama_Control" %>

<asp:DataList ID="DataList1" RepeatColumns="3" RepeatDirection="Horizontal" runat="server" ItemStyle-Width="33%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" OnItemDataBound="DataList1_ItemDataBound">
    <ItemTemplate>
        <p><strong><asp:HyperLink ID="LBL_Nom_Club" runat="server" Text='<%#Eval("nom_club") %>'></asp:HyperLink></strong></p>
        <p><asp:Image ID="Image1" runat="server" /></p>
        <p><strong><asp:Label ID="LBL_Nom" runat="server" Text=""></asp:Label></strong></p>
        <p><asp:HyperLink ID="HL_Contact" runat="server">Le contacter</asp:HyperLink></p>    
        <br />
    </ItemTemplate>
</asp:DataList>