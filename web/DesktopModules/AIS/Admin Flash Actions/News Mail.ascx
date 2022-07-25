<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="News Mail.ascx.cs" Inherits="DesktopModules_AIS_News_Mail_News_Mail" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

    <asp:Label ID="test" runat="server" />

<asp:Panel ID="pnl_saisie" runat="server" >

    <asp:Label Text="Titre : " runat="server" />
    <asp:TextBox ID="tbx_titre" runat="server" Width="300"/>
    <asp:RequiredFieldValidator ID="rvr_titre" ControlToValidate="tbx_titre" Display="None" ErrorMessage="Veuillez entrer un titre" runat="server" ValidationGroup="vgp_news" />
    <br />
    <br />
    <asp:Label Text="Edito : " runat="server"/>
    <telerik:RadEditor runat="server" ID="TXT_Editor"  style="width:100%;" ></telerik:RadEditor>
    <asp:RequiredFieldValidator ID="rvr_edito" ControlToValidate="TXT_Editor" Display="None" ErrorMessage="Veuillez entrer un Edito" runat="server" ValidationGroup="vgp_news" />
    <br />




    <h2><asp:Label Text="District" runat="server" /></h2>
    <br />
    <asp:DataList ID="dl_NewsDistrict" runat="server" RepeatColumns="1" RepeatDirection="Vertical" OnItemDataBound="dl_NewsDistrict_ItemDataBound">
        <ItemTemplate>
            <asp:CheckBox ID="cbx_NewsDistrict" runat="server" Checked="true"/>
            <asp:Image ID="img_NewsDistrict" runat="server" />
            <asp:Label ID="lbl_NewsDistrict" runat="server" />
            <br />
            <asp:Label ID="lbl_DateNewsDistrict" runat="server" CssClass="right" />
        </ItemTemplate>
    </asp:DataList>
    <asp:Label ID="lbl_DlDistrictVide" Text="Aucune news cette semaine" runat="server" Visible="false" />
    <br />




    <h2><asp:Label Text="Club" runat="server" /></h2>
    <br />
    <asp:DataList ID="dl_NewsClub" runat="server" RepeatColumns="1" RepeatDirection="Vertical" OnItemDataBound="dl_NewsClub_ItemDataBound">
        <ItemTemplate>
            <asp:CheckBox ID="cbx_NewsClub" runat="server" Checked="true" />
            <asp:Image ID="img_NewsClub" runat="server" />
            <asp:Label ID="lbl_NewsClub" runat="server" />
            <br />
            <asp:Label ID="lbl_DateNewsClub" runat="server" CssClass="right" />
        </ItemTemplate>
    </asp:DataList>
    <asp:Label ID="lbl_DlClubVide" Text="Aucune news cette semaine" runat="server" Visible="false" />


    <br />
    <br />
    <asp:HiddenField ID="hfd_newsDistrict" runat="server" />
    <asp:HiddenField ID="hfd_newsClub" runat="server" />
    <asp:ValidationSummary id="vsy_news" runat="server" ValidationGroup="vgp_news" />
    <asp:Button ID="btn_generer" ValidationGroup="vgp_news" CausesValidation="true" runat="server" CssClass="right btn btn-primary" Text="Générer" OnClick="btn_generer_Click" />
</asp:Panel>