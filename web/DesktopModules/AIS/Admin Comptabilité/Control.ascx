<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Comptabilite_Control" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>

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


<div class="pe-spacer size10"></div>

<asp:Panel ID="Panel2" runat="server" Visible="false">
<asp:HiddenField runat="server" ID="HF_id" />

<div class="Marron">
	<h2><span class="Head">Détail du règlement</span></h2>
</div>

<div>
	<span>Date : </span><telerik:RadDatePicker runat="server" ID="TXT_Dt"></telerik:RadDatePicker>		
	<span>Titre : </span>
	<asp:TextBox runat="server" ID="TXT_Titre" MaxLength="255" Width="100%"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Il manque le titre" Display="None" ControlToValidate="TXT_Titre"></asp:RequiredFieldValidator>
</div>   
<div>
	<span>Description : </span>
    <blockquote class="blockquote">
        <p class="text-info">
            On peut saisir <strong>#url#</strong> dans le corps du texte, ce tag sera remplacé automatiquement par l'url de la facture adaptée à chaque destinataire. Ce qui permet au destinataire de récupérer sa facture directement sans avoir besoin de s'identifier dans le site
        </p>
    </blockquote>
</div>
<div>
    <dnn:TextEditor runat="server" ID="TXT_Editor" style="width:100%;"></dnn:TextEditor>
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
    <telerik:RadNumericTextBox runat="server" ID="TXT_montant1" NumberFormat-DecimalDigits="2" NumberFormat-DecimalSeparator="."></telerik:RadNumericTextBox>
</asp:Panel>
<asp:Panel runat="server" ID="P_Montant2" Visible="false">
    <asp:Label runat="server" ID="LBL_libelle2"></asp:Label>
    <telerik:RadNumericTextBox runat="server" ID="TXT_montant2" NumberFormat-DecimalDigits="2" NumberFormat-DecimalSeparator="."></telerik:RadNumericTextBox>
</asp:Panel>
<div>
    <div class="pe-spacer size10"></div>
<div class="txtCenter">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
    <asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Supprimer" Text="Supprimer" CausesValidation="false" OnClick="BT_Supprimer_Click" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce règlement ?');" />&nbsp;
    <asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Valider" Text="Valider" OnClick="BT_Valider_Click" />&nbsp;<asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Annuler" Text="Retour" OnClick="BT_Annuler_Click" CausesValidation="false" />
</div>

    <div class="pe-spacer size20"></div>

<asp:Panel runat="server" ID="P_GenerateOrders" >
<div>Génération des commandes :</div>
    <asp:Literal runat="server" ID="Lit_Info_Generation_Commandes"><blockquote class="blockquote">
        <p class="text-info">
            Pour générer les commandes, il faut au préalable valider le formulaire. Le bouton de génération apparaitra alors. Attention de bien s'assurer de l'effectif après import du fichier des membres venant du RI.        
        </p>
    </blockquote>
    </asp:Literal>
    <div class="txtCenter">

    <asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Generer_Orders" Text="Générer les commandes" OnClick="BT_Generer_Orders_Click" />
    <div>
    <asp:Literal runat="server" ID="TXT_Result"></asp:Literal>
    </div>
</div>    
</asp:Panel>

    <div class="pe-spacer size10"></div>

<asp:Panel runat="server" ID="P_SendMail">
<div>Envoi des emails :</div>
<div class="txtCenter">
    <div><em>Les emails sont envoyés à chaque trésorier, président et secrétaire. Dans le cas ou un club n'aurait ni trésorier ni président ni secrétaire déclaré, l'email n'est pas envoyé, il faut alors contacter le club par un autre moyen.</em></div>
    <div>
        <span>Email expéditeur : </span>
        <asp:TextBox runat="server" ID="TXT_Email_Sender" MaxLength="255" Width="300px"></asp:TextBox><br />
        <asp:CheckBox runat="server" ID="CB_Just_A_Test" Checked="true" Text="&nbsp;Juste un test&nbsp;" /><em>Quand cette option est cochée, un test sur le 1er club est envoyé à l'adresse expéditeur. Il faut décocher pour envoyer les messages a tout les clubs.</em>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Il manque l'email expéditeur" Display="None" ControlToValidate="TXT_Email_Sender" ></asp:RequiredFieldValidator>
    </div>
    <asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Send_Emails" Text="Envoi des emails" OnClick="BT_Send_Emails_Click" />
    <div>
    <asp:Literal runat="server" ID="TXT_Result_Mails"></asp:Literal>
    </div>
</div>
</asp:Panel>

    <div class="pe-spacer size20"></div>

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

<div class="pe-spacer.size10"></div>
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