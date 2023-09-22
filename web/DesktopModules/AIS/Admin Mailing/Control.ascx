<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Mailing_Control" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>

<asp:Label ID="test" runat="server" />

<h2><asp:Label ID="lbl_noClubSelected" runat="server" Text="Veuillez sélectionner un club"></asp:Label></h2>

<asp:Panel ID="Panel1" runat="server">
    <p><asp:Button runat="server" Text="Ajouter un message" ID="BT_Ajouter" CssClass="btn btn-primary" OnClick="BT_Ajouter_Click" /></p>

    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"  AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
        <Columns>
            <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" DataFormatString="{0:d}" />
            <asp:BoundField DataField="title" HeaderText="Titre"  SortExpression="title" />
            <asp:ButtonField ButtonType="Link" runat="server" Text="Détail" CommandName="detail" />
        </Columns>    
       <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
        <EmptyDataTemplate>Aucun mail associé à ce club</EmptyDataTemplate>
    </asp:GridView>

    <asp:HiddenField ID="tri" Value="name" runat="server"/>
    <asp:HiddenField ID="sens" Value="ASC" runat="server"/>
    <asp:HiddenField ID="HF_Cric" runat="server" />
    <asp:HiddenField ID="HF_Param" runat="server" />
</asp:Panel>

<asp:Panel ID="Panel2" runat="server" Visible="false">
<asp:HiddenField runat="server" ID="HF_id" />

<div class="Marron">
	<h2><span class="Head">Détail de votre message</span></h2>
</div>

<div class="form-inline">
    <div class="form-group">
	    <span>Date : </span>
        <asp:TextBox runat="server" ID="TXT_Dt" TextMode="Date" Width="120px" CssClass="form-control"></asp:TextBox>

        <span>Sujet : </span>
        <asp:TextBox runat="server" ID="TXT_Titre" MaxLength="255" Width="450px"  CssClass="form-control"></asp:TextBox>
      </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Il manque le sujet" Display="None" ControlToValidate="TXT_Titre"></asp:RequiredFieldValidator>
  
</div>
<div>
	</div>   
<div class="form-inline">
    <div class="form-group">
	<span>Nom expéditeur : </span>
    <asp:TextBox runat="server" ID="TXT_Exp_Nom" MaxLength="255" Width="300px"  CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Il manque le nom expediteur" Display="None" ControlToValidate="TXT_Exp_Nom"></asp:RequiredFieldValidator>	
	<span>E-mail : </span>
	<asp:TextBox runat="server" ID="TXT_Exp_Email" MaxLength="255" Width="300px"  CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Il manque l'email" Display="None" ControlToValidate="TXT_Exp_Email"></asp:RequiredFieldValidator>
        </div>
</div>   
<div>
	<span>Contenu : </span>
    <dnn:TextEditor runat="server" ID="TXT_Editor" Width="100%" Height="500"/>
	<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Le texte n'a pas été saisi" Display="None" ControlToValidate="TXT_Editor"></asp:RequiredFieldValidator>
</div>

<asp:Panel ID="Panel_Club" runat="server" Visible="false">
    <asp:Panel ID="Panel_Bureau" runat="server" >
        <asp:Label ID="LBL_Bureau_Titre" runat="server" Text="Envoyer aux autres clubs :" />
  
        <asp:CheckBox ID="CHK_Bureau_Pres" runat="server" Text="&nbsp;Président" OnCheckedChanged="CHK_Bureau_Pres_CheckedChanged"  AutoPostBack="true"/>
        <asp:CheckBox ID="CHK_Bureau_Secr" runat="server" Text="&nbsp;Secrétaire" OnCheckedChanged="CHK_Bureau_Secr_CheckedChanged"  AutoPostBack="true"/>                

        <asp:Label ID="LBL_Bureau_Filtre" runat="server" Text="Filtrer par département : " Visible="false"></asp:Label>
        <asp:RadioButtonList ID="RB_Dept" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RB_Dept_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:RadioButtonList>
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" >
        <asp:Label ID="LBL_All_Members_Titre" runat="server" Text="Envoyer à tous les membres de mon club :" />
        <asp:CheckBox ID="CHK_All_Members" runat="server" Text="&nbsp;Tous les membres"  OnCheckedChanged="CHK_All_Members_CheckedChanged"  AutoPostBack="true"/>
    </asp:Panel>
</asp:Panel>

<asp:Panel ID="Panel_District" runat="server" Visible="false">
    <asp:Panel ID="Panel_Role" runat="server" >
        <asp:Label ID="LBL_Role" runat="server" Text="Rôle(s) :" CssClass="Titre"/>
        <asp:CheckBoxList ID="CHKList_Role" TextAlign="Right" runat="server" Width="100%" RepeatColumns="4" OnSelectedIndexChanged="CHKList_Role_SelectedIndexChanged" AutoPostBack="true" />
    </asp:Panel>


    <asp:Panel ID="Panel_Fct" runat="server" >
        <asp:Label ID="LBL_Fct" runat="server" Text="Fonction(s) (rotary et rotaract) :" CssClass="Titre"/>
        <asp:CheckBoxList ID="CHKList_Fct" TextAlign="Right" runat="server" Width="100%" RepeatColumns="4" OnSelectedIndexChanged="CHKList_Role_SelectedIndexChanged" AutoPostBack="true"  />
    </asp:Panel>


    <asp:Panel ID="Panel_AR" runat="server">
        <asp:Label ID="LBL_AR_TITRE" runat="server" Text="Années rotariennes :" CssClass="Titre" />              
        <asp:CheckBox ID="CHK_AR_0" runat="server"  OnCheckedChanged="CHK_AR_0_CheckedChanged"  AutoPostBack="true"/>
        <asp:CheckBox ID="CHK_AR_1" runat="server"  OnCheckedChanged="CHK_AR_1_CheckedChanged"  AutoPostBack="true"/>
    </asp:Panel>
        
    <asp:Label ID="LBL_Role_Filtre" runat="server" Text="Filtrer par département : " CssClass="Titre" Visible="false"></asp:Label>
    <asp:RadioButtonList ID="RB_Role_Dept" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RB_Role_Dept_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:RadioButtonList>
</asp:Panel>

<div>
    <asp:Label ID="LBL_NB_Dest" runat="server" CssClass="Titre"/>
</div>
<div class="pe-spacer size20"></div>
<div class="txtCenter">
	<asp:ValidationSummary runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
	<asp:Button runat="server" ID="BT_Supprimer" Text="Supprimer" CssClass="btn btn-danger" CausesValidation="false" OnClick="BT_Supprimer_Click" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer ce message ?');" />&nbsp;
	<asp:Button runat="server" ID="BT_Valider" Text="Valider" OnClick="BT_Valider_Click" CssClass="btn btn-primary" />&nbsp;<asp:Button runat="server" ID="BT_Annuler" Text="Annuler" OnClick="BT_Annuler_Click" CausesValidation="false" CssClass="btn btn-default" />
</div>
</asp:Panel>

<asp:Panel ID="Panel_Envoi" runat="server" Visible="false">
    <div class="Marron">
		<h2><asp:Label ID="LBL_Titre_Test" Text="Tester la newsletter" runat="server" CssClass="Head"/></h2>
	</div>
	
    <asp:Panel ID="Panel_Test" runat="server" Visible="true">
        <asp:Label ID="LBL_Email_Test" Text="Email du destinataire : " runat="server" />
        <asp:TextBox ID="TBX_Email_Test" runat="server" AutoPostBack="false" />
        <asp:Button ID="BTN_Test" runat="server" OnClick="BTN_Test_Click" CssClass="btn btn-primary"  Text="Tester"/>
        <asp:RegularExpressionValidator ID="REV_Test" runat="server" ControlToValidate="TBX_Email_Test" ErrorMessage="Email non valide" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>      
        <asp:RequiredFieldValidator ID="RFV_Test" runat="server" ErrorMessage="L'email de test n'a pas été saisi" ControlToValidate="TBX_Email_Test"></asp:RequiredFieldValidator>
    </asp:Panel>

    <asp:Panel ID="Panel_Resultat_Test" runat="server" Visible="false">
        <asp:Label ID="LBL_Resultat_Test" Text="La newsletter de test est en cours d'envoi" runat="server" />            
        <asp:Button ID="BTN_Resultat_Test" runat="server" OnClick="BTN_Result_Click" CssClass="btn btn-primary"  Text="Fermer"/>
    </asp:Panel>

    <div class="Marron">
		<h2><asp:Label ID="LBL_Titre_Env" Text="Envoyer la newsletter" runat="server" CssClass="Head"/></h2>
	</div>
    <asp:Label ID="LBL_Nb_Env" runat="server" /><br/><br/>
    <asp:CheckBox ID="CHK_Env" runat="server" AutoPostBack="true" Text="&nbsp;Confirmer l'envoi de la newsletter." OnCheckedChanged="CHK_Env_CheckedChanged" />
    <asp:Button ID="BTN_Env" runat="server" OnClick="BTN_Env_Click" CssClass="btn btn-primary"   Text="Envoyer" Visible="false"/>
</asp:Panel>

<asp:Panel ID="Panel_Result" runat="server" Visible="false">
    <div class="Marron">
    	<h2><asp:Label ID="LBL_Result"  runat="server" CssClass="Head"/></h2>
    	<div class="Blanc">
		    <asp:Label ID="LBL_Nb_E" runat="server" /><br/>            
            <br/><asp:Label ID="LBL_Titre_E" runat="server" Text="Liste des e-mails en erreur :" Visible="false"/><br/>           
            <asp:GridView ID="GV_Emails_Erreur" runat="server" Visible="false" ></asp:GridView>            
            <table>
                <tr><td colspan="2"><asp:Label runat="server" Text="Statistiques :"></asp:Label></td></tr>
                <tr><td><asp:Label ID="Label1" runat="server" Text="Nombre de messages lus : "></asp:Label></td><td><asp:Label ID="LBL_NB_MSG_LU" runat="server" Text=""></asp:Label></td></tr>
                <tr><td><asp:Label ID="Label2" runat="server" Text="Nombre de messages non lus : "></asp:Label></td><td><asp:Label ID="LBL_NB_MSG_NONLU" runat="server" Text=""></asp:Label></td></tr>
                <tr><td><asp:Label ID="Label3" runat="server" Text="Nombre de messages en erreur : "></asp:Label></td><td><asp:Label ID="LBL_NB_MSG_ERREUR" runat="server" Text=""></asp:Label></td></tr>
                </table><br />

            <p>Date : <asp:Label runat="server" ID="lbl_date" ></asp:Label></p>	
	        <p>Sujet : <asp:Label runat="server" ID="lbl_Sujet" /></p>
            <span>Contenu : </span>
            <dnn:TextEditor runat="server" ID="rad_Resutat" Width="100%" Height="500"/>
             <p>
            <asp:Button ID="BTN_Export_Lists" runat="server" OnClick="BTN_Export_Lists_Click" CssClass="btn btn-primary"  Text="Export listes messages" />
		    <asp:Button ID="BTN_Copier" runat="server" OnClick="BTN_Copier_Click" CssClass="btn btn-primary"  Text="Copier ce message" />
		    <asp:Button ID="BTN_Result" runat="server" OnClick="BTN_Result_Click" CssClass="btn btn-primary"   Text="Fermer"/>
            </p>
	    </div>
    </div>      
    
</asp:Panel>

