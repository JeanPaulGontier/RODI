<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Membres.ascx.cs" Inherits="DesktopModules_AIS_Admin_Members_Liste" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Label ID="test" runat="server" />

<h2><asp:Label runat="server" Visible="false" ID="lbl_noClubSelected" Text="Veuillez choisir un club"></asp:Label></h2>

<asp:Panel ID="Panel1" runat="server">
<asp:Label ID="Label1" runat="server" Text="Recherche :"></asp:Label>
<asp:TextBox runat="server" ID="TXT_Critere" AutoPostBack="true" OnTextChanged="TXT_Critere_TextChanged" ></asp:TextBox>
<asp:Label ID="LBL_Nb" runat="server"></asp:Label>
<asp:Button runat="server" ID="btn_Ajout" Text="Ajouter un membre" CssClass="btn btn-primary" OnClick="btn_Ajout_Click" Visible="false" ToolTip="Ajouter un membre rotaract" CausesValidation="false"/>		
<h3><asp:Label runat="server" ID="lbl_TousADG" Text="Choisissez un club" Visible="false" /></h3>




<asp:GridView ID="GridView1"  runat="server" CssClass="table table-striped"  AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound">
<Columns>
    <asp:BoundField DataField="nim" HeaderText="NIM" SortExpression="nim" />
    <asp:BoundField DataField="civility" SortExpression="civility"  />
    <asp:BoundField DataField="surname" HeaderText="Nom" SortExpression="surname"  />
    <asp:BoundField DataField="name" HeaderText="Prénom" SortExpression="name"  />
    <asp:TemplateField HeaderText="Email" SortExpression="email"  ItemStyle-Width="32"><ItemTemplate><a href="mailto:<%# Eval("email") %>"><%# Eval("email") %></a></ItemTemplate></asp:TemplateField>
    <asp:BoundField DataField="club_name" HeaderText="Club" SortExpression="club_name"  />
     <asp:TemplateField HeaderText="Présentation" SortExpression="presentation">
        <ItemTemplate>
            <asp:HyperLink ID="HLK_Presentation" runat="server">
                <img src="<%= PortalSettings.ActiveTab.SkinPath %>images/icon_hostusers_32px.gif" title="Voir la présentation" />
            </asp:HyperLink>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:ButtonField ButtonType="Link" runat="server" Text="Détail" CommandName="detail" />
</Columns>    
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>

    <p><asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Export_XLS" Text="Export Excel" OnClick="BT_Export_XLS_Click" CausesValidation="false"/>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Export_CSV" Text="Export CSV" OnClick="BT_Export_CSV_Click" Visible="false" CausesValidation="false"/></p>
    <asp:Panel runat="server" ID="pnl_exports">
        <asp:HiddenField ID="tri" Value="name" runat="server"/><asp:HiddenField ID="sens" Value="ASC" runat="server"/>
        <asp:HiddenField ID="HF_Cric" runat="server" />
        
        <p><asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Carte_Member_Recto" Text="Cartes de membres recto PDF" OnClick="BT_Carte_Member_Recto_Click" CausesValidation="false"/>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Carte_Member_Verso" Text="Cartes de membres verso PDF" OnClick="BT_Carte_Member_Verso_Click" CausesValidation="false"/></p>
        <p><asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Carte_Member_Recto_DOC" Text="Cartes de membres recto Word 2003 (.doc)" OnClick="BT_Carte_Member_Recto_DOC_Click" CausesValidation="false"/>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Carte_Member_Verso_DOC" Text="Cartes de membres verso Word 2003 (.doc)" OnClick="BT_Carte_Member_Verso_DOC_Click" CausesValidation="false"/></p>
        <p><asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Carte_Member_Recto_Docx" Text="Cartes de membres recto Word 2007+ (.docx)" OnClick="BT_Carte_Member_Recto_DOCX_Click" CausesValidation="false"/>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Carte_Member_Verso_Docx" Text="Cartes de membres verso Word 2007+ (.docx)" OnClick="BT_Carte_Member_Verso_DOCX_Click" CausesValidation="false"/></p>
    </asp:Panel>

<asp:GridView ID="GridViewExport" runat="server" AutoGenerateColumns="False" Visible="false">
<Columns>
    <asp:BoundField DataField="nim" HeaderText="NIM" />
    <asp:BoundField DataField="civility" HeaderText="Civilité" />
    <asp:BoundField DataField="surname" HeaderText="Nom" />
    <asp:BoundField DataField="name" HeaderText="Prénom" />
    <asp:BoundField DataField="email" HeaderText="Email" />
    <asp:BoundField DataField="club_name" HeaderText="Club" />  
    <asp:BoundField DataField="cric" HeaderText="CRIC" />
    <asp:BoundField DataField="honorary_member" HeaderText="Member d'honneur" />
    <asp:BoundField DataField="maiden_name" HeaderText="Nom jeune fille" />
    <asp:BoundField DataField="spouse_name" HeaderText="Prénom conjoint" />
    <asp:BoundField DataField="title" HeaderText="Titre" />
    <asp:BoundField DataField="birth_year" HeaderText="Année naissance" DataFormatString="{0:d}" />
    <asp:BoundField DataField="year_membership_rotary" HeaderText="Année adhésion Rotary" DataFormatString="{0:d}" />
    <asp:BoundField DataField="adress_1" HeaderText="Adresse 1" />
    <asp:BoundField DataField="adress_2" HeaderText="Adresse 2" />
    <asp:BoundField DataField="adress_3" HeaderText="Adresse 3" />
    <asp:BoundField DataField="zip_code" HeaderText="CP" />
    <asp:BoundField DataField="town" HeaderText="Ville" />
    <asp:BoundField DataField="telephone" HeaderText="Téléphone" />
    <asp:BoundField DataField="fax" HeaderText="Fax" />
    <asp:BoundField DataField="gsm" HeaderText="GSM" />
    <asp:BoundField DataField="country" HeaderText="Pays" />
    <asp:BoundField DataField="job" HeaderText="Fonction Métier" />
    <asp:BoundField DataField="industry" HeaderText="Branche Activité" />
    <asp:BoundField DataField="biography" HeaderText="Biographie" />
    <asp:BoundField DataField="base_dtupdate" HeaderText="Date maj base" />
    <asp:BoundField DataField="professionnal_adress" HeaderText="Adresse Prof." />
    <asp:BoundField DataField="professionnal_zip_code" HeaderText="CP Prof." />
    <asp:BoundField DataField="professionnal_town" HeaderText="Ville Prof." />
    <asp:BoundField DataField="professionnal_tel" HeaderText="Tél Prof." />
    <asp:BoundField DataField="professionnal_fax" HeaderText="Fax Prof." />
    <asp:BoundField DataField="professionnal_mobile" HeaderText="Portable Prof." />
    <asp:BoundField DataField="professionnal_email" HeaderText="Email Prof." />
    <asp:BoundField DataField="retired" HeaderText="Retraité(e)" />
    <asp:BoundField DataField="removed" HeaderText="Radié(e)" />
</Columns>    
</asp:GridView>
</asp:Panel>

<asp:HiddenField runat="server" ID="HF_id" />

<asp:Panel runat="server" ID="Panel2" Visible="false">
	<div class="Marron MultiTitre">
		<h2><asp:Label runat="server" ID="LBL_Civilite" />
		<asp:Label runat="server" ID="LBL_Nom" CssClass="Head" />
		<asp:Label runat="server" ID="LBL_Fonction_Metier" />
		<asp:Label runat="server" ID="LBL_Retraite" />
		<asp:Label runat="server" ID="LBL_Member_Honneur" /></h2>
	</div>
	
	<div class="Table">
		<div class="TableCell">
			<asp:Image runat="server" ID="IMG_Photo" />
			<telerik:RadAsyncUpload ID="FU_Photo" Localization-Select="Changer la photo" HideFileInput="true" DisablePlugins="true" MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientPhotoUploaded" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
			<div style="display:none; width:130px;">
				<asp:Button runat="server" ID="BT_Upload_Photo" Text="Mettre à jour" OnClick="BT_Upload_Photo_Click" CausesValidation="false"/>
				<script>function OnClientPhotoUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload_Photo.ClientID %>'); bt.click(); }</script>
			</div><asp:HiddenField runat="server" ID="HF_Photo" /><asp:Button CssClass="btn btn-danger" runat="server" ID="BT_Effacer_Photo" Text="Supprimer la photo" OnClick="BT_Effacer_Photo_Click" CausesValidation="false"/>
		</div>
		
		<div>
			<p>NIM <asp:Label runat="server" ID="LBL_NIM" /></p>
			<p>Année naissance : <asp:Label runat="server" ID="LBL_DT_Naissance" /></p>
		</div>
		
		<div>
			<p>Branche d'activité : <asp:Label runat="server" ID="LBL_Branche_Activite" /></p>
			<p>Année d&#39;entrée au Rotary : <asp:Label runat="server" ID="LBL_DT_Entree_Rotary" /></p>
		</div>
		
		<div class="Adresse">
			<p>Coordonnées personnelles :<br/>
			<asp:Label runat="server" ID="LBL_Adresse" /></p>
			<p><asp:Label runat="server" ID="LBL_Emailt" Text="Email : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Email" /><br />
			<asp:Label runat="server" ID="LBL_Telt" Text="Tél : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Tel" /><br />
			<asp:Label runat="server" ID="LBL_GSMt" Text="GSM : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Gsm" /><br />
			<asp:Label runat="server" ID="LBL_Faxt" Text="Fax : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Fax" /></p>
		</div>
		
		<asp:Panel runat="server" ID="Panel_Coord_Pro" CssClass="Adresse">
			<p>Coordonnées professionnelles :<br />
			<asp:Label runat="server" ID="LBL_Adresse_Pro" /></p>
			<p><asp:Label runat="server" ID="LBL_Email_Prot" Text="Email : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Email_Pro" /><br />
			<asp:Label runat="server" ID="LBL_Tel_Prot" Text="Tél : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Tel_Pro" /><br />
			<asp:Label runat="server" ID="LBL_GSM_Prot" Text="GSM : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_GSM_Pro" /><br />
			<asp:Label runat="server" ID="LBL_Fax_Prot" Text="Fax : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_FAX_Pro" /></p>
		</asp:Panel>
		
		
	</div>
	
</asp:Panel>

<asp:Panel ID="pnl_Rotaract" runat="server" Visible="false">
    <asp:HiddenField runat="server" ID="hf_type_club" />
    <asp:HiddenField runat="server" ID="hf_Cric_Rotaract" />

       
    <h2>Civilités :</h2>
        <p><asp:Label ID="lbl_civilite2" Width="200px" runat="server"  Text="Civilité : " /><asp:RadioButtonList ID="rbtl_civilite" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="Madame" Value="Mme" /><asp:ListItem Text="Monsieur" Value="M" /></asp:RadioButtonList></p>
        <p><asp:Label ID="lbl_titre2" Width="200px" runat="server"  Text="Titre : " /><asp:TextBox runat="server" ID="tbx_titre" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_nom2" Width="200px" runat="server"  Text="Nom * : " /><asp:TextBox runat="server" ID="tbx_nom" Width="400px" MaxLength="255"  /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="" ControlToValidate="tbx_nom" Width="20px"></asp:RequiredFieldValidator></p>      
        <p><asp:Label ID="lbl_prenom2" Width="200px" runat="server"  Text="Prénom * : " /><asp:TextBox runat="server" ID="tbx_prenom" Width="400px" MaxLength="255"  /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="tbx_prenom" Width="20px"></asp:RequiredFieldValidator></p>
        <p><asp:Label ID="lbl_ann_Naiss2" Width="200px" runat="server"  Text="Année de naissance : " /> <telerik:RadDatePicker runat="server" Height="30px" ID="dpk_ann_Naiss" MinDate="01/01/1901"/></p>
        <p><asp:Label ID="lbl_nom_JF2" Width="200px" runat="server"  Text="Nom de jeune fille : " /><asp:TextBox runat="server" ID="tbx_nom_JF" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_prenom_Conjoint2" Width="200px" runat="server"  Text="Prénom conjoint : " /><asp:TextBox runat="server" ID="tbx_prenom_Conjoint" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_bio2" Width="200px" runat="server"  Text="Biographie : " /><asp:TextBox runat="server" ID="tbx_bio" TextMode="MultiLine" Rows="5" Width="400px" Wrap="true"  /></p>
            

    <div >
        <asp:Label runat="server" ID="Label10" Text="Photo : "  Width="200px" />
			<asp:Image runat="server" ID="IMG_Photo2" />
			<telerik:RadAsyncUpload ID="FU_Photo2" Localization-Select="Changer la photo" HideFileInput="true" DisablePlugins="true" MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientPhotoUploaded2" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
			<div style="display:none" >
				<asp:Button runat="server" ID="BT_Upload_Photo2" CssClass="btn btn-primary" Text="Mettre à jour" OnClick="BT_Upload_Photo2_Click" CausesValidation="false" />
				<script>function OnClientPhotoUploaded2(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload_Photo2.ClientID %>'); bt.click(); }</script>
			</div>
        <asp:HiddenField runat="server" ID="HF_Photo2" />
        <asp:Button runat="server" CssClass="btn btn-danger" ID="BT_Effacer_Photo2" Text="Supprimer la photo" OnClick="BT_Effacer_Photo2_Click" CausesValidation="false" />
	</div>

    <br />
    <h2>Coordonnées personnelles :</h2>             
        <p><asp:Label ID="lbl_adresse1_2" Width="200px" runat="server"  Text="Adresse : " /><asp:TextBox runat="server" ID="tbx_adresse1" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_adresse2_2" Width="200px" runat="server"  Text="Complément 1 : " /><asp:TextBox runat="server" ID="tbx_adresse2" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_adresse3_2" Width="200px" runat="server"  Text="Complément 2 : " /><asp:TextBox runat="server" ID="tbx_adresse3" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_cp2" Width="200px" runat="server"  Text="CP : " /><asp:TextBox runat="server" ID="tbx_cp" Width="400px" MaxLength="50"  /></p>
        <p><asp:Label ID="lbl_ville2" Width="200px" runat="server"  Text="Ville : " /><asp:TextBox runat="server" ID="tbx_ville" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_pays2" Width="200px" runat="server"  Text="Pays : " /><asp:TextBox runat="server" ID="tbx_pays" Width="400px" MaxLength="50"  /></p>
        <p><asp:Label ID="lbl_email2" Width="200px" runat="server"  Text="Email : " /><asp:TextBox runat="server" ID="tbx_email" Width="400px" MaxLength="255"  /></p>
        <p><asp:Label ID="lbl_telephone2" Width="200px" runat="server"  Text="Téléphone : " /><asp:TextBox runat="server" ID="tbx_telephone" Width="400px" MaxLength="50"  /></p>
        <p><asp:Label ID="lbl_fax2" Width="200px" runat="server"  Text="Fax : " /><asp:TextBox runat="server" ID="tbx_fax" Width="400px" MaxLength="50"  /></p>
        <p><asp:Label ID="lbl_gsm2" Width="200px" runat="server"  Text="Mobile : " /><asp:TextBox runat="server" ID="tbx_gsm" Width="400px" MaxLength="50"  /></p>
            
    <br />
         <h2>Profession :</h2>  
            <p><asp:Label ID="lbl_fct_metier2" Width="200px" runat="server"  Text="Métier : " /><asp:TextBox runat="server" ID="tbx_fct_metier" Width="400px" MaxLength="255"  /></p>
            <p><asp:Label ID="lbl_branche2" Width="200px" runat="server"  Text="Branche d'activité : " /><asp:TextBox runat="server" ID="tbx_branche" Width="400px" MaxLength="255"  /></p>
            <p><asp:Label ID="lbl_retraite2" Width="200px" runat="server"  Text="Retraité : " /><asp:RadioButtonList ID="rbtl_retraite" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="Oui" Value="O" /><asp:ListItem Text="Non" Value="N" /></asp:RadioButtonList></p>
            
    <br />
        <h2>Coordonnées professionnelles :</h2>   
            <p><asp:Label ID="lbl_adresse_pro2" Width="200px" runat="server"  Text="Adresse professionnelle : " /><asp:TextBox runat="server" ID="tbx_adresse_pro" Width="400px" MaxLength="255"  /></p>
            <p><asp:Label ID="lbl_cp_pro2" Width="200px" runat="server"  Text="CP professionnelle : " /><asp:TextBox runat="server" ID="tbx_cp_pro" Width="400px" MaxLength="50"  /></p>
            <p><asp:Label ID="lbl_ville_pro2" Width="200px" runat="server"  Text="Ville professionnelle : " /><asp:TextBox runat="server" ID="tbx_ville_pro" Width="400px" MaxLength="255"  /></p>
            <p><asp:Label ID="lbl_email_pro2" Width="200px" runat="server"  Text="Email professionnelle : " /><asp:TextBox runat="server" ID="tbx_email_pro" Width="400px" MaxLength="255"  /></p>
            <p><asp:Label ID="lbl_tel_pro2" Width="200px" runat="server"  Text="Téléphone professionnelle : " /><asp:TextBox runat="server" ID="tbx_tel_pro" Width="400px" MaxLength="50"  /></p>
            <p><asp:Label ID="lbl_fax_pro2" Width="200px" runat="server"  Text="Fax professionnelle : " /><asp:TextBox runat="server" ID="tbx_fax_pro" Width="400px" MaxLength="50"  /></p>
            <p><asp:Label ID="lbl_gsm_pro2" Width="200px" runat="server"  Text="Mobile professionnelle : " /><asp:TextBox runat="server" ID="tbx_gsm_pro" Width="400px" MaxLength="50"  /></p>
        
    <br />
        <h2>Rotary :</h2>             
            <p><asp:Label ID="lbl_district2" Width="200px" runat="server"  Text="District : " /> <asp:Label ID="lbl_district3" Width="400px" runat="server"   /></p>
            <p><asp:Label ID="lbl_club2" Width="200px" runat="server"  Text="Club : " /> <asp:Label ID="lbl_club3" Width="400px" runat="server"  /></p>
            <p><asp:Label ID="lbl_membre_H2" Width="200px" runat="server"  Text="Member d'honneur : " /> <asp:RadioButtonList ID="rbtl_membre_H" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="Oui" Value="O" /><asp:ListItem Text="Non" Value="N" /></asp:RadioButtonList></p>
            <p><asp:Label ID="lbl_membre_A2" Width="200px" runat="server"  Text="Member actif : " /> <asp:RadioButtonList ID="rbtl_membre_A" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="Oui" Value="O" /><asp:ListItem Text="Non" Value="N" /></asp:RadioButtonList></p>
            <p><asp:Label ID="lbl_radie" Width="200px" runat="server"  Text="Radié : " /> <asp:RadioButtonList ID="rbtl_radie" Enabled="false" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"><asp:ListItem Text="Oui" Value="O" /><asp:ListItem Text="Non" Value="N" /></asp:RadioButtonList></p>
            <p><asp:Label ID="lbl_ann_adh_Rot2" Width="200px" runat="server"  Text="Année adhésion rotary : " /> <telerik:RadDatePicker runat="server" Height="30px" ID="dpk_ann__adh_Rot" MinDate="01/01/1901"/></p>
            

    
</asp:Panel>

<asp:Panel ID="pnl_Bouton" runat="server" Visible="false">

    <div class="txtRight">
			Autoriser la publication : 
        <asp:RadioButtonList ID="RB_Autoriser_Publication" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Selected="true" Text="Oui" Value="O" />
            <asp:ListItem Text="Non" Value="N" />

        </asp:RadioButtonList>
	</div>

    <div class="txtCenter">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" HeaderText="Les champs nom et prénom sont obligatoires" ShowMessageBox="true" ShowSummary="false" />

        <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_VCF" Text="Carte de visite" OnClick="BT_VCF_Click" CausesValidation="false"/>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_CreateDNNUser" Text="Mettre à jour l'accès utilisateur" OnClick="BT_CreateDNNUser_Click" CausesValidation="false"/> 
 		<asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Valider" Text="Sauvegarder" OnClick="BT_Valider_Click" CausesValidation="true"/>		
        <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Ajouter" Visible="false" Text="Ajouter" OnClick="BT_Ajouter_Click" CausesValidation="true"/>		
        <asp:Button runat="server" CssClass="btn btn-danger" ID="BT_Supprimer" Text="Supprimer" CausesValidation="false" OnClientClick="javascript: return confirm('Voulez-vous vraiement supprimer ce membre ?');" OnClick="BT_Supprimer_Click" Visible="false" />
        <asp:Button runat="server" CssClass="btn btn-danger" ID="btn_suppMember" Text="Supprimer le membre" OnClick="BT_Supprimer_Click" />
        <asp:Button runat="server" CssClass="btn btn-default" ID="BT_Annuler" Text="Retour" OnClick="BT_Annuler_Click" CausesValidation="false" />


        <asp:HiddenField ID="hf_Supp" runat="server"/>
        <asp:HiddenField ID="hf_Ajout" runat="server"/>
	</div>
</asp:Panel>