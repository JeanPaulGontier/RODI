<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contact.ascx.cs" Inherits="DesktopModules_Contact" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls" %>
<div id="Contact"></div>
<asp:Panel runat="server" ID="P2" Visible="false" CssClass="alert alert-success">
        Votre message a bien été envoyé...    
</asp:Panel>
<asp:Panel ID="pnl_Formulaire" runat="server" CssClass="animated fadeInUp">
    <asp:Panel ID="pnl_Champs" runat="server" CssClass="contact_input_style">
        <asp:Label ID="lbl_nom" runat="server" Text="Veuillez indiquer votre nom" CssClass="Normal"/>
        <asp:TextBox ID="tbx_nom" runat="server" MaxLength="50" CssClass="contact_input_box" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="tbx_nom" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbl_Tel" runat="server" Text="Votre téléphone" CssClass="Normal"/>
        <asp:TextBox ID="tbx_Tel" runat="server" MaxLength="50" CssClass="contact_input_box" />
        <br />
        <asp:Label ID="lbl_mail" runat="server" Text="Votre e-mail" CssClass="Normal"/>
        <asp:TextBox ID="tbx_mail" runat="server" MaxLength="50" CssClass="contact_input_box" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="tbx_mail" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="tbx_mail" ErrorMessage="Saisir un email valide (ex: nom@domaine.com)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lbl_message" runat="server" Text="Votre question" CssClass="Normal"/>
        <asp:TextBox ID="tbx_message" runat="server" TextMode="multiline"  CssClass="contact_textarea_box" Rows="10" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="tbx_message" Display="Dynamic"></asp:RequiredFieldValidator>
        <dnn:CaptchaControl ID="CaptchaDnnControl" runat="server" CaptchaHeight="40" CaptchaWidth="160" ErrorStyle-CssClass="NormalRed" CssClass="Normal" ErrorMessage="Le code saisi doit correspondre à l'image, veuillez re saisir" />
    </asp:Panel>
    
    <p class="Normal">Tous les champs (sauf le téléphone) sont obligatoires<br />Ni votre nom, ni votre téléphone, ni votre adresse e-mail ne sont conservés sur le site.</p>
    
    <asp:Panel ID="pnl_Boutons" runat="server">
		<asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="false" ShowSummary="false" />
		<asp:Button runat="server" ID="btn_Valider" Text="Envoyer" OnClick="btn_Valider_Click" CausesValidation="true" CssClass="btn btn-info" />
		&nbsp;
		<asp:Button runat="server" ID="btn_Annuler" Text="Annuler" OnClick="btn_Annuler_Click" CausesValidation="false" CssClass="btn btn-default" />
	</asp:Panel>
</asp:Panel>


<div class="clear"></div>