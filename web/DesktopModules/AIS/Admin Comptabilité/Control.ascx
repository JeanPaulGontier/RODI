<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Comptabilite_Control" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Panel ID="Panel1" runat="server">
<asp:Button runat="server" Text="Ajouter un règlement" CssClass="btn btn-primary" ID="BT_Ajouter" OnClick="BT_Ajouter_Click" />
<asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"  AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
<Columns>
    <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" DataFormatString="{0:d}" />
    <asp:BoundField DataField="title" HeaderText="Titre"  SortExpression="title" />
    <asp:ButtonField ButtonType="Link" runat="server" Text="Détail" CommandName="detail" />
</Columns>    
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
    <p><asp:Button ID="BT_Exporter_Transactions_CB" runat="server" CssClass="btn btn-primary" OnClick="BT_Exporter_Transactions_CB_Click" Text="Exporter les transactions CB" /></p>
<asp:HiddenField ID="tri" Value="dt" runat="server"/><asp:HiddenField ID="sens" Value="DESC" runat="server"/>
<asp:HiddenField ID="HF_Cric" runat="server" />
</asp:Panel>



<asp:Panel ID="Panel2" runat="server" Visible="false">
<asp:HiddenField runat="server" ID="HF_id" />

<div class="Marron">
	<h2><span class="Head">Détail du règlement</span></h2>
</div>

<div>
	<span>Date : </span><telerik:RadDatePicker runat="server" ID="TXT_Dt"></telerik:RadDatePicker>		
	<span>Règlement : </span>
	<asp:TextBox runat="server" ID="TXT_Titre" MaxLength="255" Width="300px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Il manque le titre" Display="None" ControlToValidate="TXT_Titre"></asp:RequiredFieldValidator>
</div>   
<div>
	<span>Description : </span>
</div>
<div>
    <telerik:RadEditor runat="server" ID="TXT_Editor" style="width:100%;"></telerik:RadEditor>
	<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Le texte n'a pas été saisi" Display="None" ControlToValidate="TXT_Editor"></asp:RequiredFieldValidator>
</div>
<div>
    <span>Type de règlement :</span>
    <asp:RadioButtonList ID="RB_Type" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RB_Type_SelectedIndexChanged" >
        <asp:ListItem Text="Taxe per capita" Value="T"></asp:ListItem>
        <asp:ListItem Text="Manifestation" Value="M"></asp:ListItem>
    </asp:RadioButtonList>
</div>
<asp:Panel runat="server" ID="P_Montant1" Visible="false">
    <asp:Label runat="server" ID="LBL_libelle1"></asp:Label>
    <telerik:RadNumericTextBox runat="server" ID="TXT_montant1" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
</asp:Panel>
<asp:Panel runat="server" ID="P_Montant2" Visible="false">
    <asp:Label runat="server" ID="LBL_libelle2"></asp:Label>
    <telerik:RadNumericTextBox runat="server" ID="TXT_montant2" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
</asp:Panel>
<asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Generer_Orders" Text="Générer les commandes" OnClick="BT_Generer_Orders_Click"/>
<asp:Literal runat="server" ID="TXT_Result"></asp:Literal>
<div>
<div class="txtCenter">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
    <asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Supprimer" Text="Supprimer" CausesValidation="false" OnClick="BT_Supprimer_Click" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce règlement ?');" />&nbsp;
    <asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Valider" Text="Valider" OnClick="BT_Valider_Click" />&nbsp;<asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Annuler" Text="Retour" OnClick="BT_Annuler_Click" CausesValidation="false" />
</div>

<div>Liste des commandes :</div>
<asp:GridView ID="GridView2" runat="server" CssClass="table table-stripped"  AllowSorting="True"  GridLines="None" OnRowCommand="GridView2_RowCommand" AutoGenerateColumns="False" OnSorting="GridView2_Sorting" OnRowDataBound="GridView2_RowDataBound">
<Columns>
    
    <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" DataFormatString="{0:d}" />
    <asp:BoundField DataField="id" HeaderText="N°" SortExpression="id" />
    <asp:BoundField DataField="club" HeaderText="Club"  SortExpression="club" />
    <asp:BoundField DataField="amount" HeaderText="Montant" SortExpression="amount" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}" />
    <asp:TemplateField ItemStyle-Width="150"  HeaderText="Réglée" SortExpression="rule" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lbl_paid" runat="server"></asp:Label>
            <%-- <asp:RadioButtonList ID="RB_Regle" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="RB_Regle_SelectedIndexChanged">
                <asp:ListItem Text="Oui" Value="O"></asp:ListItem>
                <asp:ListItem Text="Non" Value="N"></asp:ListItem>
            </asp:RadioButtonList> --%>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="rule_type" HeaderText="Type"  />
    <asp:BoundField DataField="rule_par" HeaderText="Par"  />
    <asp:BoundField DataField="rule_info" HeaderText="Description" />
    <asp:TemplateField>
        <ItemTemplate>
            <asp:Button ID="btn_edit" runat="server" CommandName="Editer" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-primary" Text="Modifier" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink runat="server" ID="HL_Detail" Text="Détail" Target="_blank"></asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>

    
</Columns>    
    <EmptyDataTemplate>
        <div>Aucune commande de club pour le moment ...</div>
    </EmptyDataTemplate>
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
    <asp:HiddenField ID="tri2" Value="club" runat="server"/><asp:HiddenField ID="sens2" Value="ASC" runat="server"/>
    <br /><asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Export_Orders" Text="Exporter les commandes" OnClick="BT_Export_Orders_Click"  />&nbsp;<asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Exporter_Inscrits" Text="Exporter les inscrits" OnClick="BT_Exporter_Inscrits_Click"  />
</div>

</asp:Panel>

<asp:GridView ID="GridViewExport" runat="server" Visible="false">
</asp:GridView>


<asp:Panel Visible="false" ID="pnl_modif" runat="server">
    <asp:HiddenField ID="hfd_id" runat="server" />
    <h3><asp:Label runat="server" ID="lbl_Titre"></asp:Label></h3>
    <br />
    <div class="row">
        <div class="col-md-2">
            Réglé par : 
        </div>
        <div class="col-md-10">
            <asp:RadioButtonList ID="rbl_type" RepeatDirection="Horizontal" runat="server">
                <asp:ListItem Text="Chèque" Value="cheque"></asp:ListItem>
                <asp:ListItem Text="Virement" Value="virement"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            et par : 
        </div>
        <div class="col-md-10">
            <asp:DropDownList ID="ddl_members" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2">
            Description : 
        </div>
        <div class="col-md-10">
            <asp:TextBox TextMode="MultiLine" ID="tbx_info" runat="server" Width="300" Height="200"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="btn_validate" runat="server" Text="Régler" CssClass="btn btn-primary"  OnClick="btn_validate_Click"/>
    <asp:Button ID="btn_cancel" runat="server" Text="Annuler" CssClass="btn btn-default" OnClick="btn_cancel_Click" />
</asp:Panel>