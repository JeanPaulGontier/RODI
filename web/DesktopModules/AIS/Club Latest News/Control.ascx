<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2018                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Club_Nouvelles_Control" %>
<asp:Repeater runat="server" ID="LI_News" OnItemDataBound="LI_News_ItemDataBound">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li class="BlocBlanc">
            <asp:HyperLink ID="HL_Detail" runat="server">
                <asp:Panel runat="server" ID="PNews" CssClass="LimitedHeight relative">
                    <asp:Image ID="Image1" runat="server" />

                </asp:Panel>
                    <h2>
                        <asp:Label ID="LBL_Titre" runat="server" Text='<%# Bind("title") %>' />

                    </h2>
                    <asp:Label ID="LBL_Date" runat="server" Text='<%# Bind("dt","{0:dd MMM yyyy}") %>' />            </asp:HyperLink>
        </li>
    </ItemTemplate>
</asp:Repeater>
</asp:Repeater>

