<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Comptabilite_Control" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>

<asp:Panel runat="server" ID="P_Error" CssClass="alert alert-danger" Visible="false">
<asp:Literal runat="server" ID="TXT_Error" />
</asp:Panel>
<asp:Panel ID="Panel1" runat="server">
<asp:Button runat="server" Text="Ajouter un appel" CssClass="btn btn-primary" ID="BT_Ajouter" OnClick="BT_Ajouter_Click" />
<asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"  AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
<Columns>
    <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" DataFormatString="{0:d}" />
    <asp:BoundField DataField="title" HeaderText="Titre"  SortExpression="title" />
    <asp:ButtonField ButtonType="Link" runat="server" Text="Détail" CommandName="detail" />
</Columns>    
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
<asp:Button ID="BT_Exporter_Transactions_CB" runat="server" CssClass="btn btn-primary" OnClick="BT_Exporter_Transactions_CB_Click" Text="Exporter les transactions CB" Visible="false"/>
<asp:HiddenField ID="tri" Value="dt" runat="server"/><asp:HiddenField ID="sens" Value="DESC" runat="server"/>
<asp:HiddenField ID="HF_Cric" runat="server" />
</asp:Panel>


<div class="pe-spacer size10"></div>
<asp:Panel ID="Panel2" runat="server" Visible="false">
<asp:HiddenField runat="server" ID="HF_id" />
<div class="Marron">
	<h2>Détail de l'appel</h2>
</div>
<div>
	<div class="form-inline">Date : <asp:TextBox TextMode="Date" runat="server" ID="TXT_Dt" CssClass="form-control"></asp:TextBox></div>		
</div>
<div class="pe-spacer size10"></div>
<div>
	<div class="form-inline">Titre : <asp:TextBox runat="server" ID="TXT_Titre" MaxLength="255" Width="60%" CssClass="form-control"></asp:TextBox></div>
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
   
<asp:Panel runat="server" ID="P_Montant1" Visible="false" CssClass="form-inline">
    <asp:Label runat="server" ID="LBL_libelle1"></asp:Label>
    <asp:TextBox runat="server" ID="TXT_montant1" TextMode="Number" inputmode="decimal" step="0.01" min="0" CssClass="form-control"></asp:TextBox>
</asp:Panel>
<asp:Panel runat="server" ID="P_Montant2" Visible="false" CssClass="form-inline">
    <asp:Label runat="server" ID="LBL_libelle2"></asp:Label>
    <asp:TextBox runat="server" ID="TXT_montant2" TextMode="Number" inputmode="decimal" step="0.01" min="0"  CssClass="form-control"> </asp:TextBox>
</asp:Panel>
<div>
    <div class="pe-spacer size10"></div>
    <div class="txtCenter">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
        <asp:Button CssClass="btn btn-danger" runat="server" ID="BT_Supprimer" Text="Supprimer" CausesValidation="false" OnClick="BT_Supprimer_Click" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer cet appel ?');" />&nbsp;
        <asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Valider" Text="Valider" OnClick="BT_Valider_Click" />&nbsp;<asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Annuler" Text="Retour" OnClick="BT_Annuler_Click" CausesValidation="false" />
    </div>

    <div class="pe-spacer size20"></div>

<asp:Panel runat="server" ID="P_GenerateOrders" >
<div>Génération des factures :</div>
    <asp:Literal runat="server" ID="Lit_Info_Generation_Commandes"><blockquote class="blockquote">
        <p class="text-info">
            Pour générer les factures, il faut au préalable valider le formulaire. Le bouton de génération apparaitra alors. Attention de bien s'assurer de l'effectif après import du fichier des membres venant du RI.        
        </p>
    </blockquote>
    </asp:Literal>
    <div class="txtCenter">
        <div class="pe-spacer size10"></div>
    <asp:Button CssClass="btn btn-primary" runat="server" ID="BT_Generer_Orders" Text="Générer les factures" OnClick="BT_Generer_Orders_Click" />
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

<div>Liste des factures :</div>
<asp:GridView ID="GridView2" runat="server" CssClass="table table-stripped"  AllowSorting="True"  GridLines="None" OnRowCommand="GridView2_RowCommand" AutoGenerateColumns="False" OnSorting="GridView2_Sorting" OnRowDataBound="GridView2_RowDataBound">
<Columns>
    
    <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" DataFormatString="{0:d}" />
    <asp:BoundField DataField="id" HeaderText="N°" SortExpression="id" />
    <asp:BoundField DataField="club" HeaderText="Club"  SortExpression="club" />
    <asp:BoundField DataField="amount" HeaderText="Montant" SortExpression="amount" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:n}" />
    <asp:TemplateField ItemStyle-Width="150"  HeaderText="Réglée" SortExpression="rule" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate>
            <asp:Label ID="lbl_paid" runat="server"></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="rule_type" HeaderText="Moyen"  />
    <asp:BoundField DataField="rule_par" HeaderText="Par qui"  />
    <asp:TemplateField HeaderText="Quand">
        <ItemTemplate>
            <asp:Label runat="server" Text='<%# ShowDate((DateTime)Eval("rule_dt")) %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
     
    <asp:BoundField DataField="rule_info" HeaderText="Description" />
    <asp:TemplateField>
        <ItemTemplate>
            <asp:Button ID="btn_edit" runat="server" CommandName="Editer" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-primary" Text="Règlement" />
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
        <ItemTemplate>
            <asp:HyperLink runat="server" ID="HL_Detail" Text="Détail" Target="_blank"></asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>

    
</Columns>    
    <EmptyDataTemplate>
        <div>Aucune facture de club pour le moment ...</div>
    </EmptyDataTemplate>
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
    <asp:HiddenField ID="tri2" Value="club" runat="server"/><asp:HiddenField ID="sens2" Value="ASC" runat="server"/>
    <br /><asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Export_Orders" Text="Exporter les factures" OnClick="BT_Export_Orders_Click"  />&nbsp;<asp:Button runat="server" Text="Exporter seulement les prélèvements" OnClick="BT_Export_Only_Transfers_Click" ID="BT_Export_Only_Transfers" CssClass="btn btn-primary"  />&nbsp;<asp:Button runat="server" Text="Valider tous les virements" ID="BT_Validate_Transfers" CssClass="btn btn-primary" OnClientClick="confirm('voulez vous validez tous les paiements par virement d'un coup ?')" Visible="false" OnClick="BT_Validate_Transfers_Click" />&nbsp;<asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Exporter_Inscrits" Visible="false" Text="Exporter les inscrits" OnClick="BT_Exporter_Inscrits_Click"  />
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
           Montant réglé : 
        </div>
        <div class="col-md-3">
              <asp:TextBox runat="server" ID="tbx_amount" Width="200" TextMode="Number" inputmode="decimal" step="0.01" min="0" CssClass="form-control"></asp:TextBox>
       </div>
       <div class="col-md-7">
       
            <em class="text-info">ATTENTION : le changement de montant, change le montant de la facture</em>
        </div>
    </div>
    <div class="pe-spacer size10"></div>
    <div class="row">
        <div class="col-md-2">
            Réglé par : 
        </div>
        <div class="col-md-10">
            <asp:RadioButtonList ID="rbl_type" RepeatDirection="Horizontal" runat="server">
                 <asp:ListItem Text="Non réglée" Value=""></asp:ListItem>
                <asp:ListItem Text="Chèque" Value="Chèque"></asp:ListItem>
                <asp:ListItem Text="Virement" Value="Virement"></asp:ListItem>
                 <asp:ListItem Text="Prélèvement" Value="Prélèvement"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <div class="pe-spacer size10"></div>
    <div class="row">
        <div class="col-md-2">
            Date : 
        </div>
        <div class="col-md-10">
            <asp:TextBox TextMode="Date" ID="tbx_date" runat="server" CssClass="form-control" Width="200"></asp:TextBox>
        </div>
    </div>
    <div class="pe-spacer size10"></div>
    <div class="row">
        <div class="col-md-2">
            Par qui : 
        </div>
        <div class="col-md-10">
            <asp:DropDownList ID="ddl_members" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
        </div>
    </div>
    <div class="pe-spacer size10"></div>
    <div class="row">
        <div class="col-md-2">
            Description : 
        </div>
        <div class="col-md-10">
            <asp:TextBox TextMode="MultiLine" ID="tbx_info" runat="server" CssClass="form-control" Height="200"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="btn_validate" runat="server" Text="Valider le règlement" CssClass="btn btn-primary"  OnClick="btn_validate_Click"/>
    <asp:Button ID="btn_cancel" runat="server" Text="Annuler" CssClass="btn btn-default" OnClick="btn_cancel_Click" />
</asp:Panel>
<asp:Panel runat="server" ID="P_Admin_Commands" visible="false">
    <div class="pe-spacer size10"></div>
    <asp:Button runat="server" CssClass="btn btn-danger" ID="BT_Delete_Invoices" Text="Supprimer les factures" OnClientClick="confirm('supprimer les factures ?')" OnClick="BT_Delete_Invoices_Click" />
</asp:Panel>