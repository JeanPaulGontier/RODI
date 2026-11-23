<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Settings.ascx.cs" Inherits="AgendaPublic_Settings" %>
<fieldset>
    <div class="dnnFormItem" style="display:none">
        <div class="dnnLabel">URL news view : </div>
        <asp:TextBox runat="server" ID="url"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <div class="dnnLabel">Catégories à afficher : </div>
        <asp:TextBox runat="server" ID="Inclues" TextMode="MultiLine"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <div class="dnnLabel">Catégories à exclure : </div>
        <asp:TextBox runat="server" ID="Exclues" TextMode="MultiLine"></asp:TextBox>
    </div>
</fieldset>