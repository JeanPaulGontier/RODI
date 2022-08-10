<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Club_AAR_Control" %>
<asp:Label runat="server" ID="LBL_AR" Text="Année Rotarienne : "></asp:Label>
<asp:RadioButtonList runat="server" ID="RB_AR" AutoPostBack="true" OnSelectedIndexChanged="RB_AR_SelectedIndexChanged" RepeatDirection="Horizontal"></asp:RadioButtonList>
<asp:Panel ID="PanelErreur" runat="server" CssClass="panel panel-danger" Visible="false"><div class="panel-heading"><asp:Label ID="lbl_erreur" runat="server" Text="" /></div></asp:Panel>
<asp:Panel ID="Panel1" runat="server">
</asp:Panel>
<asp:Button ID="BT_Valider" runat="server" Text="Valider" CssClass="btn btn-primary right" OnClientClick="javascript: return confirm('Valider les changements ?');" OnClick="BT_Valider_Click" />
<asp:HiddenField ID="HF_Cric" runat="server" /><script type="text/javascript">function AfficheValider() { obj=document.getElementById("<%=BT_Valider.ClientID%>").style;obj.visibility='visible';}</script>
<br />
<em>* affectations qui permettent d'administrer le club</em>
<asp:Label ID="lbl_choisirClub" runat="server" Text="Choisissez un club" />

<asp:Label ID="TXT_Result" runat="server"></asp:Label>