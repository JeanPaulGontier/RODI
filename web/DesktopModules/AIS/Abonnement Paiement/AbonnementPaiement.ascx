<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AbonnementPaiement.ascx.cs" Inherits="DesktopModules_AIS_Abonnement_Paiement_AbonnementPaiement" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<%--<asp:Panel ID="Panel2" runat="server">
    <div class="left spacingRight">
        <h3><asp:Label runat="server" ID="LBL_Titre2" Text="" /></h3>
        <asp:Literal runat="server" ID="LTL_Texte2"  />
    </div>

    <div class="InfosMembre">
        <asp:Image runat="server" ID="IMG_Logo2" />
        <asp:HyperLink runat="server" ID="HLK_URL2"  Target="_blank" Text="Télécharger le fichier"/>
        <asp:Hyperlink runat="server" ID="HLK_Contact2" Imageurl="/Portals/_default/Skins/Rotary/images/mail.png" ToolTip="Lui envoyer un message" Text="Lui envoyer un message" />
    </div>
    
    <div class="clear"></div>
    <asp:Button runat="server" ID="BTN_Edit" Text="Modifier l'annonce" OnClick="BTN_Annonce_Edit_Click" />

</asp:Panel>

<asp:Panel ID="Panel1" runat="server">
    <div>
        <asp:Label runat="server" ID="Label1" Text="" />
    </div>

    <div>
        <asp:Literal runat="server" ID="Literal1"  />
    </div>

    <div>
        <asp:Image runat="server" ID="IMG_Photo2" />
    </div>
    
    <div>
        <asp:Label runat="server" ID="LBL_Nom_Prenom2" />
    </div>

    <div>
        <asp:Label runat="server" ID="LBL_Fonction2" />
    </div>

    <div>
        <asp:Label runat="server" ID="LBL_Classification2" />
    </div>

    <div>
        <asp:Image runat="server" ID="Image1" />
    </div>

    <div>
        <asp:HyperLink runat="server" ID="HyperLink1"  Target="_blank" Text="Accès au site web"/>
    </div>

    <div>
        <asp:Hyperlink runat="server" ID="Hyperlink2" Imageurl="<%= PortalSettings.ActiveTab.SkinPath %>images/mail.png" ToolTip="Lui envoyer un message" Text="Lui envoyer un message" />
    </div>

    <div>
        <asp:Button runat="server" ID="Button1" Text="Modifier la présentation" OnClick="BTN_Presentation_Edit_Click" />
    </div>

</asp:Panel>--%>

<asp:Panel runat="server" ID="Panel3">
    <div style="text-align:center">
    <asp:Literal id="LTL_Paypal" runat="server"/>
    <%--https://github.com/paypal/JavaScriptButtons#editable-fields--%>
    </div>
    <div  style="text-align:center;margin-top:20px">
    <asp:Button ID="BTN_Annuler" runat="server" Text="Annuler" OnClick="BTN_Annuler_Click" />    
    </div>    
</asp:Panel>




