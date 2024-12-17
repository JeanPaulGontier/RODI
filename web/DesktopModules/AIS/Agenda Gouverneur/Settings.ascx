<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="DesktopModules_AIS_Agenda_Gouverneur_Settings" %>
<fieldset>
    <div class="dnnFormItem">
        <div class="dnnLabel">Serveur mail : </div>
        <asp:TextBox runat="server" ID="host"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <div class="dnnLabel">Username : </div>
        <asp:TextBox runat="server" ID="username"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <div class="dnnLabel">Password : </div>
        <asp:TextBox runat="server" ID="password" TextMode="Password"   ToolTip="Laisser vide pour ne pas le remplacer"></asp:TextBox>
      
    </div>
    <div class="dnnFormItem">
        <div class="dnnLabel">N° calendrier : </div>
        <asp:TextBox runat="server" ID="num" TextMode="Number"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <div class="dnnLabel">Nb max affichage : </div>
        <asp:TextBox runat="server" ID="max" TextMode="Number"></asp:TextBox>
    </div>
</fieldset>
