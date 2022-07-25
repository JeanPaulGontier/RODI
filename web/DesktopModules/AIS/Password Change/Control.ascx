<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Password_Change_Control" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Panel runat="server" ID="P1" CssClass="txtCenter">
	<p>Le minimum requis pour le mot de passe est de <b>8 caractères</b> avec <b>au moins 1 chiffre</b>, mais pour plus de sécurité vous pouvez mélanger des majuscules et minuscules et ajouter des symboles (Exemple : MonBeau!M0tdeP@sse)</p>
	<p><asp:Label runat="server" Text="Saisir le nouveau mot de passe"></asp:Label>&nbsp;<asp:TextBox ID="TXT_Pass1" runat="server" TextMode="Password"></asp:TextBox></p>
	<p><asp:Label runat="server" Text="Saisir une 2ème fois le mot de passe"></asp:Label>&nbsp;<asp:TextBox ID="TXT_Pass2" runat="server" TextMode="Password"></asp:TextBox></p>
	    
	<telerik:RadInputManager runat="server" ID="RadInputManager1">
        <telerik:TextBoxSetting>
            <TargetControls>
                <telerik:TargetInput ControlID="TXT_Pass1"></telerik:TargetInput>
            </TargetControls>
            <PasswordStrengthSettings ShowIndicator="true"  MinimumLowerCaseCharacters="0" MinimumNumericCharacters="1" MinimumSymbolCharacters="0" RequiresUpperAndLowerCaseCharacters="false" TextStrengthDescriptions="Trop faible;Faible;Moyen;Fort;Très fort"></PasswordStrengthSettings>
        </telerik:TextBoxSetting>
    </telerik:RadInputManager>
	<telerik:RadInputManager runat="server" ID="RadInputManager2">
        <telerik:TextBoxSetting>
            <TargetControls>
                <telerik:TargetInput ControlID="TXT_Pass2"></telerik:TargetInput>
            </TargetControls>
            <PasswordStrengthSettings ShowIndicator="true" MinimumLowerCaseCharacters="0" MinimumNumericCharacters="1" MinimumSymbolCharacters="0" RequiresUpperAndLowerCaseCharacters="false" TextStrengthDescriptions="Trop faible;Faible;Moyen;Fort;Très fort"></PasswordStrengthSettings>
        </telerik:TextBoxSetting>
    </telerik:RadInputManager>

	<p class="NormalRed"><asp:Label runat="server" ID="TXT_Resultat"></asp:Label></p>
	<asp:Button runat="server" Text="Valider" ID="BT_Valider" OnClick="BT_Valider_Click" class="btn default"/>
</asp:Panel>

<asp:Panel runat="server" ID="P2" Visible="false">
    Le mot de passe a correctement été changé...
</asp:Panel>