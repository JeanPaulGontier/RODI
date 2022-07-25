<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Liens_Meme_Dossier_Control" %>
<asp:DataList ID="DataList1" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" ItemStyle-CssClass="sousmenu" OnItemDataBound="DataList1_ItemDataBound">
    <ItemTemplate>
        <asp:HyperLink runat="server" ID="HL_Nom"></trong><%# Eval("LocalizedTabName") %></asp:HyperLink>
        <asp:Label runat="server" ID="LBL_Nom"><strong><%# Eval("LocalizedTabName") %></strong></asp:Label>       
    </ItemTemplate>
     

</asp:DataList>
