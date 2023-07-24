
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Password_Change_Control" %>
<asp:Panel runat="server" ID="P1" CssClass="txtCenter">
	<p>Le minimum requis pour le mot de passe est de <b>8 caractères</b> avec <b>au moins 1 chiffre</b>, mais pour plus de sécurité vous pouvez mélanger des majuscules et minuscules et ajouter des symboles (Exemple : MonBeau!M0tdeP@sse)</p>
	<div class="form-inline">
    <div class="form-group"><label for="<%=TXT_Pass1.ClientID %>">Saisir le nouveau mot de passe</label>&nbsp;<asp:TextBox ID="TXT_Pass1" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></div>
    </div>
    <div class="pe-spacer size10"></div>
    <div class="form-inline">
	<div class="form-group"><label for="<%=TXT_Pass2.ClientID %>">Saisir une 2ème fois le mot de passe</label>&nbsp;<asp:TextBox ID="TXT_Pass2" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></div>
    </div>
	<div class="pe-spacer size10"></div>
	<p class="NormalRed"><asp:Label runat="server" ID="TXT_Resultat"></asp:Label></p>
	<asp:Button runat="server" Text="Valider" ID="BT_Valider" OnClick="BT_Valider_Click" class="btn default"/>
</asp:Panel>

<asp:Panel runat="server" ID="P2" Visible="false">
    Le mot de passe a correctement été changé...
</asp:Panel>