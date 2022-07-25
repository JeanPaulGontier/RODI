<!--**********************************************************************************-->
<!-- RODI - https://rodi-platform.org                                                 -->
<!-- Copyright (c) 2012-2019                                                          -->
<!-- by SAS AIS : https://www.aisdev.net                                              -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Club_Slideshow_Control" %>

<div class="flexslider">
    <ul class="slides">
        <asp:Repeater ID="rpt_Img_Slider" runat="server" OnItemDataBound="rpt_Img_Slider_ItemDataBound">
            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="hlk_Slider1" runat="server">
                        <asp:Image ID="img_Slider" runat="server" Width="100%"  />
                        
                    </asp:HyperLink>
                    <asp:HyperLink ID="hlk_Slider" runat="server">
                            <strong><asp:Label ID="lbl_Slider" runat="server" Style="font-size: 24px; display: block; line-height: 30px; text-align: center; color: #019fcb" /></strong>
                    </asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>

<asp:Panel ID="pnl_Modify" runat="server" Visible="false">
    <br />
    <asp:Button ID="btn_Modify" runat="server" Text="Modifier" CssClass="btn btn-warning" OnClick="btn_Modify_Click" />
</asp:Panel>
