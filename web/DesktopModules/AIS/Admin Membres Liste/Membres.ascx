﻿
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Membres.ascx.cs" Inherits="DesktopModules_AIS_Admin_Members_Liste" %>
 <style>
    input[type=file]::-webkit-file-upload-button {
        color: #ffffff;
        border: none;
        cursor: pointer;            
        background-image: linear-gradient(to right,#428bca,#428bca);
        border-color: #357edb;
        border-radius: 4px;
           
        font-size: 12px;
        padding: 6px 12px;
        user-select: none;
        white-space: nowrap;
    }
</style>

<asp:Label ID="test" runat="server" />

<h2><asp:Label runat="server" Visible="false" ID="lbl_noClubSelected" Text="Veuillez choisir un club"></asp:Label></h2>

<asp:Panel ID="Panel1" runat="server">
<asp:Label ID="Label1" runat="server" Text="Recherche :"></asp:Label>
<asp:TextBox runat="server" ID="TXT_Critere" AutoPostBack="true" OnTextChanged="TXT_Critere_TextChanged" ></asp:TextBox>
<asp:Label ID="LBL_Nb" runat="server"></asp:Label>
<asp:Button runat="server" ID="BT_Import" Text="Importer les membres" CssClass="btn btn-primary" ToolTip="Importer les membres à partir d'un fichier Excel" CausesValidation="false" OnClick="BT_Import_Click" />
<asp:Button runat="server" ID="BT_Ajout" Text="Ajouter un membre" CssClass="btn btn-primary" ToolTip="Ajouter un membre" CausesValidation="false" OnClick="BT_Ajout_Click" />
<h3><asp:Label runat="server" ID="lbl_TousADG" Text="Choisissez un club" Visible="false" /></h3>


<asp:GridView ID="GridView1"  runat="server" CssClass="table table-striped"  PagerStyle-CssClass="GVPager" AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound">
<Columns>
    <asp:BoundField DataField="nim" HeaderText="NIM" SortExpression="nim" />
    <asp:BoundField DataField="civility" SortExpression="civility"  />
    <asp:TemplateField ItemStyle-Width="32"> 
        <ItemTemplate>
            <%# DataBinder.Eval(Container.DataItem, "honorary_member").Equals("O")?"<img src='"+ PortalSettings.ActiveTab.SkinPath +"images/honor.png' Width=16 title='Honoraire' />":"" %>
            <%# DataBinder.Eval(Container.DataItem, "satellite_member").Equals("O")?"<img src='"+ PortalSettings.ActiveTab.SkinPath +"images/satellite.png' Width=16 title='Membre club satellite' />":"" %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="surname" HeaderText="Nom" SortExpression="surname"  />
    <asp:BoundField DataField="name" HeaderText="Prénom" SortExpression="name"  />
    <asp:TemplateField HeaderText="Email" SortExpression="email"  ItemStyle-Width="32">
        <ItemTemplate><a href="mailto:<%# Eval("email") %>"><%# Eval("email") %></a></ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="club_name" HeaderText="Club" SortExpression="club_name"  />
    <asp:ButtonField ButtonType="Link" runat="server" Text="Détail" CommandName="detail" />
</Columns>    
   <PagerSettings Mode="NumericFirstLast" Position="Bottom"  /> 
</asp:GridView>

    <p><asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Export_XLS" Text="Export Excel" OnClick="BT_Export_XLS_Click" CausesValidation="false"/>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Export_CSV" Text="Export CSV" OnClick="BT_Export_CSV_Click" Visible="false" CausesValidation="false"/></p>
        <asp:Panel runat="server" ID="pnl_exports">
        <asp:HiddenField ID="tri" Value="surname" runat="server"/><asp:HiddenField ID="sens" Value="ASC" runat="server"/>
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
    <asp:BoundField DataField="honorary_member" HeaderText="Membre d'honneur" />
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
    <asp:BoundField DataField="satellite_member" HeaderText="Membre club satellite" />
</Columns>    
</asp:GridView>
</asp:Panel>

<asp:HiddenField runat="server" ID="HF_id" />

<asp:Panel runat="server" ID="Panel2" Visible="false">
    <asp:HiddenField runat="server" ID="HF_NIM" />
	<div class="Marron MultiTitre">
		<h2><asp:Label runat="server" ID="LBL_Civilite" />
		<asp:Label runat="server" ID="LBL_Nom"  /></h2>
    </div>

    <div class="Table">
     
        <div class="row">
            <div class="TableCell col-sm-2">
			    <asp:Image runat="server" ID="IMG_Photo" />
		    </div>
		    <div class="col-sm-10">
                <div>
		            <p><asp:Label runat="server" ID="LBL_Fonction_Metier" />
		            <asp:Label runat="server" ID="LBL_Retraite" />
		            <asp:Label runat="server" ID="LBL_Member_Honneur" Visible="false" />
                     </p>
                </div>
                <div>
			        <p>Année naissance : <asp:Label runat="server" ID="LBL_DT_Naissance" /></p>
		        </div>
		
		        <div>
			        <p>Branche d'activité : <asp:Label runat="server" ID="LBL_Branche_Activite" /></p>
			        <p>Année d&#39;entrée au <asp:Label runat="server" ID="LBL_Club_Type" /> : <asp:Label runat="server" ID="LBL_DT_Entree_Rotary" /></p>
		        </div>
		    </div>
        </div>
		
		
        <asp:Panel CssClass="row" runat="server">
            <div class="Adresse col-sm-6">
			    <h3>Coordonnées personnelles :</h3>
			        <p><asp:Label runat="server" ID="LBL_Adresse" /></p>
			        <p><asp:Label runat="server" ID="LBL_Emailt" Text="Email : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Email" /><br />
			        <asp:Label runat="server" ID="LBL_Telt" Text="Tél : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Tel" /><br />
			        <asp:Label runat="server" ID="LBL_GSMt" Text="GSM : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Gsm" /><br />
			        <asp:Label runat="server" ID="LBL_Faxt" Text="Fax : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Fax" /></p>
		    </div>
		
		    <asp:Panel runat="server" ID="Panel_Coord_Pro" CssClass="Adresse col-sm-6">
			    <h3>Coordonnées professionnelles :</h3>
                    <p><asp:Label runat="server" ID="LBL_Adresse_Pro" /></p>
			        <p><asp:Label runat="server" ID="LBL_Email_Prot" Text="Email : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Email_Pro" /><br />
			        <asp:Label runat="server" ID="LBL_Tel_Prot" Text="Tél : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_Tel_Pro" /><br />
			        <asp:Label runat="server" ID="LBL_GSM_Prot" Text="GSM : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_GSM_Pro" /><br />
			        <asp:Label runat="server" ID="LBL_Fax_Prot" Text="Fax : " CssClass="WLabel" /><asp:Label runat="server" ID="LBL_FAX_Pro" /></p>
		    </asp:Panel>
        </asp:Panel>
	</div>
</asp:Panel>

<asp:Panel ID="pnl_Saisie" runat="server" Visible="false">
    <script language="javascript" type="text/javascript">
       
            function toTitleCase(item) {
                var txt = item.value;
                txt = txt.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
                return txt;
            }
       
    </script>
    <asp:HiddenField runat="server" ID="hf_type_club" />
    <asp:HiddenField runat="server" ID="hf_CRIC2" />
    <asp:HiddenField runat="server" ID="hf_NIM2" />
    <asp:HiddenField runat="server" ID="hf_userid" />
    <p>
        <i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i> cet icône après un champ, indique qu'il sera remplacé par le champ issu du Rotary International (<a href="rotary.org" target="_blank">rotary.org</a>) lors de la prochaine synchronisation. Il faut aussi modifier les champs correspondants sur my Rotary.

    </p>

    <h2>Civilités :</h2>
    <p>
        <asp:Label ID="lbl_civilite2" Width="200px" runat="server" Text="Civilité : " /><asp:RadioButtonList ID="rbtl_civilite" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Text="Madame" Value="Mme" />
            <asp:ListItem Text="Monsieur" Value="M" />
        </asp:RadioButtonList>&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_titre2" Width="200px" runat="server" Text="Titre : " /><asp:TextBox runat="server" ID="tbx_titre" Width="400px" MaxLength="255" onchange='javascript: this.value = toTitleCase(this);' /></p>
    <p><asp:Label ID="lbl_nom2" Width="200px" runat="server" Text="Nom * : " /><asp:TextBox runat="server" ID="tbx_nom" Width="400px" MaxLength="255" onchange='javascript: this.value = this.value.toUpperCase();' /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="red" Text="Obligatoire" ErrorMessage="Nom" ControlToValidate="tbx_nom" Width="20px"></asp:RequiredFieldValidator>&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_prenom2" Width="200px" runat="server" Text="Prénom * : " /><asp:TextBox runat="server" ID="tbx_prenom" Width="400px" MaxLength="255"  onchange='javascript: this.value = toTitleCase(this);' /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="red" Text="Obligatoire" ErrorMessage="Prénom" ControlToValidate="tbx_prenom" Width="20px"></asp:RequiredFieldValidator>&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p>
    <table><tr>
        <td><p><asp:Label ID="lbl_ann_Naiss2" Width="200px" runat="server" Text="Année de naissance : " /></p></td>
        <td><asp:TextBox runat="server" ID="dpk_ann_Naiss" CssClass="form-control" Height="30px" TextMode="Date"></asp:TextBox></td>
    </tr></table>
        </p>
    <p><asp:Label ID="lbl_nom_JF2" Width="200px" runat="server" Text="Nom de jeune fille : " /><asp:TextBox runat="server" ID="tbx_nom_JF" Width="400px" MaxLength="255" onchange='javascript: this.value = this.value.toUpperCase();'  /></p>
    <p><asp:Label ID="lbl_prenom_Conjoint2" Width="200px" runat="server" Text="Prénom conjoint : " /><asp:TextBox runat="server" ID="tbx_prenom_Conjoint" Width="400px" MaxLength="255"  onchange='javascript: this.value = toTitleCase(this);' /></p>
    <p><asp:Label ID="lbl_bio2" Width="200px" runat="server" Text="Biographie : " /><asp:TextBox runat="server" ID="tbx_bio" TextMode="MultiLine" Rows="5" Width="400px" Wrap="true" /></p>


    <div>
        <asp:Label runat="server" ID="Label10" Text="Photo : " Width="200px" />
        <asp:Image runat="server" ID="IMG_Photo2" />
        <asp:FileUpload runat="server" ID="FU_Photo2"  onchange="OnClientPhotoUploaded2(this, this.files[0])" accept=".png, .jpeg, .jpg" />      
        <div style="display: none">
            <asp:Button runat="server" ID="BT_Upload_Photo2" CssClass="btn btn-primary" Text="Mettre à jour"  CausesValidation="false" OnClick="BT_Upload_Photo2_Click" />
            <script>function OnClientPhotoUploaded2(sender, args) { var bt = document.getElementById('<%=BT_Upload_Photo2.ClientID %>'); bt.click(); }</script>
        </div>
        <asp:HiddenField runat="server" ID="HF_Photo2" />
        <asp:Button runat="server" CssClass="btn btn-xs btn-danger" ID="BT_Effacer_Photo2" Text="Supprimer la photo" CausesValidation="false" OnClick="BT_Effacer_Photo2_Click" />
    </div>

    <br />
    <h2>Coordonnées personnelles :</h2>
    <p><asp:Label ID="lbl_adresse1_2" Width="200px" runat="server" Text="Adresse : " /><asp:TextBox runat="server" ID="tbx_adresse1" Width="400px" MaxLength="255" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_adresse2_2" Width="200px" runat="server" Text="Complément 1 : " /><asp:TextBox runat="server" ID="tbx_adresse2" Width="400px" MaxLength="255" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_adresse3_2" Width="200px" runat="server" Text="Complément 2 : " /><asp:TextBox runat="server" ID="tbx_adresse3" Width="400px" MaxLength="255" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_cp2" Width="200px" runat="server" Text="Code postal : " /><asp:TextBox runat="server" ID="tbx_cp" Width="400px" MaxLength="50" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_ville2" Width="200px" runat="server" Text="Ville : " /><asp:TextBox runat="server" ID="tbx_ville" Width="400px" MaxLength="255"  onchange='javascript: this.value = this.value.toUpperCase();'  />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_pays2" Width="200px" runat="server" Text="Pays : " /><asp:TextBox runat="server" ID="tbx_pays" Width="400px" MaxLength="50"  onchange='javascript: this.value = this.value.toUpperCase();'  />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_email2" Width="200px" runat="server" Text="Email : " /><asp:TextBox runat="server" ID="tbx_email" Width="400px" MaxLength="255"   onchange='javascript: this.value = this.value.toLowerCase();' />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><em>ATTENTION : l'email est utilisé comme identifiant pour accéder à l'espace membre, le changement d'email implique la recréation de l'identifiant et donc la génération d'un nouveau mot de passe, qu'il faudra réinitialiser lors de la prochaine connexion</em></p>
    <p><asp:Label ID="lbl_telephone2" Width="200px" runat="server" Text="Téléphone : " /><asp:TextBox runat="server" ID="tbx_telephone" Width="400px" MaxLength="50" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_fax2" Width="200px" runat="server" Text="Fax : " /><asp:TextBox runat="server" ID="tbx_fax" Width="400px" MaxLength="50" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_gsm2" Width="200px" runat="server" Text="Mobile : " /><asp:TextBox runat="server" ID="tbx_gsm" Width="400px" MaxLength="50" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>

    <br />
    <h2>Profession :</h2>
    <p><asp:Label ID="lbl_fct_metier2" Width="200px" runat="server" Text="Métier : " /><asp:TextBox runat="server" ID="tbx_fct_metier" Width="400px" MaxLength="255"   onchange='javascript: this.value = toTitleCase(this);'  /></p>
    <p><asp:Label ID="lbl_branche2" Width="200px" runat="server" Text="Branche d'activité : " /><asp:TextBox runat="server" ID="tbx_branche" Width="400px" MaxLength="255"   onchange='javascript: this.value = toTitleCase(this);'  /></p>
    <p>
        <asp:Label ID="lbl_retraite2" Width="200px" runat="server" Text="Retraité : " /><asp:RadioButtonList ID="rbtl_retraite" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Text="Oui" Value="O" />
            <asp:ListItem Text="Non" Value="N" />
        </asp:RadioButtonList></p>

    <br />
    <h2>Coordonnées professionnelles :</h2>
    <p><asp:Label ID="lbl_adresse_pro2" Width="200px" runat="server" Text="Adresse : " /><asp:TextBox runat="server" ID="tbx_adresse_pro" Width="400px" MaxLength="255" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_cp_pro2" Width="200px" runat="server" Text="Code postal : " /><asp:TextBox runat="server" ID="tbx_cp_pro" Width="400px" MaxLength="50" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_ville_pro2" Width="200px" runat="server" Text="Ville : " /><asp:TextBox runat="server" ID="tbx_ville_pro" Width="400px" MaxLength="255"  onchange='javascript: this.value = this.value.toUpperCase();'  />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_email_pro2" Width="200px" runat="server" Text="Email : " /><asp:TextBox runat="server" ID="tbx_email_pro" Width="400px" MaxLength="255"  onchange='javascript: this.value = this.value.toLowerCase();'  />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_tel_pro2" Width="200px" runat="server" Text="Téléphone : " /><asp:TextBox runat="server" ID="tbx_tel_pro" Width="400px" MaxLength="50" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_fax_pro2" Width="200px" runat="server" Text="Fax : " /><asp:TextBox runat="server" ID="tbx_fax_pro" Width="400px" MaxLength="50" />&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></p>
    <p><asp:Label ID="lbl_gsm_pro2" Width="200px" runat="server" Text="Mobile : " /><asp:TextBox runat="server" ID="tbx_gsm_pro" Width="400px" MaxLength="50" /></p>

    <br />
    <h2><asp:Label runat="server" ID="LBL_Titre_Rotary"></asp:Label></h2>
    <p>
        <asp:Label ID="LBL_NIM2" Width="200px" runat="server" Text="NIM : " />
        <asp:TextBox runat="server" ID="tbx_nim" Width="400px" MaxLength="255" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="red" Text="Obligatoire" ErrorMessage="NIM"
            ControlToValidate="tbx_nim" Width="20px"></asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" Type="Integer" ForeColor="red"
            MinimumValue="1" MaximumValue="1000000000" ControlToValidate="tbx_nim"
            ErrorMessage="Vous devez saisir un NIM compris entre 1 et 1000000000" />
    </p>
    <p>

    <p>
        <asp:Label ID="lbl_district2" runat="server" Text="District : " Width="200px" />
        <asp:Label ID="lbl_district3" runat="server" Width="400px" />
    </p>
    <p>
        <asp:Label ID="lbl_club2" runat="server" Text="Club : " Width="200px" />
        <asp:Label ID="lbl_club3" runat="server" Width="400px" />
        <asp:Panel runat="server" ID="PChangerClub" Visible="false">
            <asp:DropDownList ID="ddlClubs" runat="server" CssClass="form-control" Width="50%">
            </asp:DropDownList>
            <asp:Panel ID="pnl_adminRotDis" runat="server" >
                <asp:Button ID="btn_validateClub" runat="server" CssClass="btn btn-primary" Text="Changer de club" OnClick="btn_validateClub_Click" />
            </asp:Panel>
        </asp:Panel>
        <p>
        </p>
        <asp:Panel runat="server" Visible="false">
            <p>
                <asp:Label ID="lbl_membre_H2" runat="server" Text="Membre d'honneur : " Width="200px" />
                <asp:RadioButtonList ID="rbtl_membre_H" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="Oui" Value="O" />
                    <asp:ListItem Text="Non" Value="N" />
                </asp:RadioButtonList>
                &nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i>
            </p>
            <p>
                <asp:Label ID="lbl_membre_A2" runat="server" Text="Membre actif : " Width="200px" />
                <asp:RadioButtonList ID="rbtl_membre_A" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="Oui" Value="O" />
                    <asp:ListItem Text="Non" Value="N" />
                </asp:RadioButtonList>
            </p>
            <p>
                <asp:Label ID="lbl_radie" runat="server" Text="Radié : " Width="200px" />
                <asp:RadioButtonList ID="rbtl_radie" runat="server" Enabled="false" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="Oui" Value="O" />
                    <asp:ListItem Text="Non" Value="N" />
                </asp:RadioButtonList>
            </p>
        </asp:Panel>
        <p>
        <table>
            <tr>
                <td><p><asp:Label ID="lbl_ann_adh_rotary" runat="server" Text="Année adhésion Rotary : " Width="200px" /><asp:Label ID="lbl_ann_adh_rotaract" runat="server" Text="Année adhésion Rotaract : " Width="200px" /></p></td>
                <td><asp:TextBox runat="server" TextMode="Date" ID="dpk_ann__adh" CssClass="form-control" Height="30px"></asp:TextBox></td>                    
                <td>&nbsp;<i class="glyphicon glyphicon-cloud-download" title="champ remplacé lors de l'import de my Rotary"></i></td>
            </tr>
        </table>
       </p>
                   
        
    </p>
</asp:Panel>

<br />
<asp:Panel ID="pnl_Bouton" runat="server" Visible="false">

    <div class="txtRight">
			Visible dans l'annuaire public : 
        <asp:RadioButtonList ID="RB_Autoriser_Publication" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Selected="true" Text="Oui" Value="O" />
            <asp:ListItem Text="Non" Value="N" />
        </asp:RadioButtonList>
	</div>
    <div class="txtRight">
        Membre d'honneur : 
        <asp:RadioButtonList ID="RB_Membre_d_Honneur" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Selected="true" Text="Oui" Value="O" />
            <asp:ListItem Text="Non" Value="N" />
        </asp:RadioButtonList>
       
    </div>
     <div class="txtRight">
        Membre club satellite : 
        <asp:RadioButtonList ID="RB_Membre_satellite" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Text="Oui" Value="O" />
            <asp:ListItem Selected="true" Text="Non" Value="N" />
        </asp:RadioButtonList>
       
    </div>

    <div class="row">
        <p>        
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList"  HeaderText="Veuillez compléter le formulaire" ShowMessageBox="true" ShowSummary="false" />
        </p>

        <div class="col-sm-4">
            <asp:Button runat="server" CssClass="btn btn-danger" ID="BT_Supprimer" Text="Supprimer" OnClick="BT_Supprimer_Click" OnClientClick="return confirm('Voulez vous vraiment supprimer le membre ?');"  />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_VCF" Text="Carte de visite" CausesValidation="false" OnClick="BT_VCF_Click"/>
        </div>
        <div class="col-sm-8">
           
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Valider" Text="Valider" CausesValidation="true" OnClick="BT_Valider_Click"/>		
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Ajouter" Visible="false" Text="Ajouter"  CausesValidation="true" OnClick="BT_Valider_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BT_Modifier" Visible="false" Text="Modifier"  CausesValidation="true" OnClick="BT_Modifier_Click" />
            <asp:Button runat="server" CssClass="btn btn-default" ID="BT_Annuler" Text="Retour" CausesValidation="false" OnClick="BT_Annuler_Click" />
        </div>



        <asp:HiddenField ID="hf_Modif" runat="server"/>
        <asp:HiddenField ID="hf_Ajout" runat="server"/>
	</div>
</asp:Panel>
<asp:Panel runat="server" ID="PanelImport" Visible="false">
    <h2>Importer les membres à partir d'un fichier Excel :</h2>
    <div class="alert">L'import a pour but de mettre à jour les membres existants dans le district, ajouter les membres manquants et supprimer les membres n'existant plus, à partir du fichier effectif (Format Excel) à récupérer sur le site rotary.org, sur cette page :<br />
        <a href='https://my.rotary.org/fr/secure/application/523' target="_blank">https://my.rotary.org/fr/secure/application/523</a><br /> 
        Si vous avez un doute, contactez le webmaster du site du district. <br /><br />
        Le n° NIM (numéro d'identification de membre) sert pour rapprocher les membres issus du Rotary avec ceux du district.<br /><br />
        <em>NB : l'email personnel du membre est utilisé comme identifiant sur le site du district,<br />
            en cas de changement d'email, un nouvel accès est alors créé avec le nouvel email et un nouveau mot de passe<br />
            Le membre pourra alors réinitialiser son mot de passe à partir de l'écran connexion<br />
            Liste des champs qui sont mis à jour a partir du fichier venant du RI : <br />
            nom, prénom, adresse pro, email, tel, fax & mobile pro et perso<br />
            En cas de création d'un nouveau membre, il faut compléter manuellement la fiche.
        </em>
    </div>
    <asp:HiddenField runat="server" ID="HF_Import" />
    <div>
        <div class="alert">
            Choisir le fichier excel récupéré du Rotary.org : <asp:FileUpload runat="server" ID="FU_import" CssClass="btn" />  <asp:Button runat="server" CssClass="btn btn-primary" ID="Bti_Analyser" Text="Analyser le fichier" CausesValidation="false" OnClick="Bti_Analyser_Click" /> <em>L'analyse permet de fichier que le fichier correspond bien au club et affiche ce qui va être fait</em>           
        </div>
        <asp:Panel runat="server" ID="PImportResult">
            <asp:Literal runat="server" ID="LT_Import"></asp:Literal>
        </asp:Panel>
        <div class="alert">
            <asp:Button runat="server" CssClass="btn btn-primary" ID="Bti_Valider" Text="Valider" CausesValidation="false" OnClick="Bti_Valider_Click" />
        </div>
        <asp:Panel runat="server" ID="LT_Import_Ok" CssClass="alert alert-success">
            La mise à jour des membres a fonctionné...
        </asp:Panel>
    </div>
    <div>
        <asp:Button runat="server" CssClass="btn btn-default" ID="Bti_Annuler" Text="Annuler" CausesValidation="false" OnClick="Bti_Annuler_Click" />
        <asp:Button runat="server" CssClass="btn btn-primary" ID="Bti_Fermer" Text="Fermer" CausesValidation="false" OnClick="Bti_Annuler_Click" />
    </div>
</asp:Panel>

