<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminAssiduite.ascx.cs" Inherits="DesktopModules_AIS_Admin_Attendance_AdminAttendance"  %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Label ID="test" runat="server" />

   <div class="Marron">
	    <h2><span class="Head"><asp:Label runat="server" ID="lbl_titre" Text="SAISIE DE L'ASSIDUITE" /></span></h2>
        <h3><asp:Label runat="server" ID="lbl_ss_titre"  /></h3>
<%--        <asp:Button ID="btn_saisie" Text="Saisir l'assiduité d'un nouveau mois" runat="server" OnClick="btn_saisie_Click" />--%>
    </div>

<asp:HiddenField ID="hfd_cric" runat="server" />

<asp:Panel ID="pnl_saisie" runat="server">
    <asp:Panel ID="pnl_titre" runat="server">
        <div class="spacingBottom " >
            <asp:Label ID="lbl_nb" runat="server" Text="Nombre de réunion à saisir" />
            <asp:DropDownList ID="ddl_nb" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_nb_SelectedIndexChanged" />
            &nbsp;
            <asp:Label Text="pour le mois de : " runat="server" />
            &nbsp;
           <asp:Label ID="lbl_mois" runat="server" Text="Mois" />
    <%--        <asp:DropDownList ID="ddl_mois" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_mois_SelectedIndexChanged" />--%>
            <asp:Label ID="lbl_annee" runat="server" Text="Année" />
            <%--<asp:DropDownList ID="ddl_annee" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_annee_SelectedIndexChanged" />
            &nbsp;--%>
        </div>
    </asp:Panel>
    <asp:Panel ID="entries" runat="server" >
    <asp:Panel ID="entry_1" runat="server" Visible="false">
        <asp:Label ID="lbl_titre_jour" runat="server" Text="Jour" Width="100" />
        <asp:Label ID="lbl_titre_nbMember" runat="server" Text="Nombre de membres" Width="115" />
        <asp:Label ID="lbl_titre_nbPresent" runat="server" Text="Nombre de présents" Width="110" />
        <asp:Label ID="lbl_titre_nbCompense" runat="server" Text="Nombre de compensés" Width="120" />
        <asp:Label ID="lbl_titre_nbExcuse" runat="server" Text="Nombre d'excusés" Width="115"   Visible="false" />
        <asp:Label ID="mbm_titre_nbDispense" runat="server" Text="Nombre de dispensés" Width="110" />
        <asp:Label ID="nbDispensePresent" runat="server" Text="Nombre de dispensés présents" Width="120" />
        <br />
        <asp:DropDownList ID="ddl_jour_1" runat="server" AutoPostBack="true" Width="100" OnSelectedIndexChanged="ddl_jour_1_SelectedIndexChanged"/>
        <asp:HiddenField ID="hfd_id1" runat="server" />
        <asp:HiddenField ID="hfd_dateSaisie_1" runat="server" />

        <asp:TextBox ID="tbx_nbMember_1" runat="server" Width="100" />
        <asp:RangeValidator id="rvr_nb_membre_1" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbMember_1" Type="Integer" MinimumValue="1" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres compris entre 1 et 500 pour la première saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_membre_1" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres pour la première saisie" Display="None" ControlToValidate="tbx_nbMember_1"  />
        
        <asp:TextBox ID="tbx_nbPresent_1" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_present_1" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbPresent_1" Type="Integer" MinimumValue="1" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres présents compris entre 1 et 500 pour la première saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_present_1" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres présents pour la première saisie" Display="None" ControlToValidate="tbx_nbPresent_1"  />

        <asp:TextBox ID="tbx_nbCompense_1" runat="server"  Width="100"/>
        <asp:RangeValidator id="rvr_nb_compense_1" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbCompense_1" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  ErrorMessage="Veuillez saisir le nombre de compensation compris entre 0 et 500 pour la première saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_compense_1" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de compensation pour la première saisie" Display="None" ControlToValidate="tbx_nbCompense_1"  />

        <asp:TextBox ID="tbx_nbExcuse_1" runat="server" Width="100"  Text="0" Visible="false"/>
        <asp:RangeValidator id="rvr_nb_excuse_1" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbExcuse_1" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres excusés compris entre 0 et 500 pour la première saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_excuse_1" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres excusés pour la première saisie" Display="None" ControlToValidate="tbx_nbExcuse_1"  />

        <asp:TextBox ID="tbx_nbDispense_1" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_dispense_1" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés compris entre 0 et 500 pour la première saisie" ControlToValidate="tbx_nbDispense_1" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  />
        <asp:RequiredFieldValidator ID="rfv_nb_dispense_1" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés pour la première saisie" Display="None" ControlToValidate="tbx_nbDispense_1"  />
        
        <asp:TextBox ID="tbx_nbDispensePresent_1" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_dispense_present_1" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés présents compris entre 0 et 500 pour la première saisie" ControlToValidate="tbx_nbDispensePresent_1" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  />
        <asp:RequiredFieldValidator ID="rfv_nb_dispense_present_1" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés présents pour la première saisie" Display="None" ControlToValidate="tbx_nbDispensePresent_1"  />
    
    </asp:Panel>

    <asp:Panel ID="entry_2" runat="server" Visible="false">
        <asp:DropDownList ID="ddl_jour_2" runat="server" AutoPostBack="true" Width="100" OnSelectedIndexChanged="ddl_jour_2_SelectedIndexChanged"/>
        <asp:HiddenField ID="hfd_id2" runat="server" />
        <asp:HiddenField ID="hfd_dateSaisie_2" runat="server" />
        <asp:TextBox ID="tbx_nbMember_2" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_membre_" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbMember_2" Type="Integer" MinimumValue="1" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres compris entre 1 et 500 pour la deuxième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_membre_2" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres pour la deuxième saisie" Display="None" ControlToValidate="tbx_nbMember_2"  />

        <asp:TextBox ID="tbx_nbPresent_2" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_present_2" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbPresent_2" Type="Integer" MinimumValue="1" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres présents compris entre 1 et 500 pour la deuxième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_present_2" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres présents pour la deuxième saisie" Display="None" ControlToValidate="tbx_nbPresent_2"  />

        <asp:TextBox ID="tbx_nbCompense_2" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_compense_2" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbCompense_2" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  ErrorMessage="Veuillez saisir le nombre de compensation compris entre 0 et 500 pour la deuxième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_compense_2" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de compensation pour la deuxième saisie" Display="None" ControlToValidate="tbx_nbCompense_2"  />

        <asp:TextBox ID="tbx_nbExcuse_2" runat="server" Width="100"  Text="0" Visible="false"/>
        <asp:RangeValidator id="rvr_nb_excuse_2" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbExcuse_2" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres excusés compris entre 0 et 500 pour la deuxième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_excuse_2" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres excusés pour la deuxième saisie" Display="None" ControlToValidate="tbx_nbExcuse_2"  />

        <asp:TextBox ID="tbx_nbDispense_2" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_dispense_2" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés compris entre 0 et 500 pour la deuxième saisie" ControlToValidate="tbx_nbDispense_2" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  />
        <asp:RequiredFieldValidator ID="rfv_nb_dispense_2" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés pour la deuxième saisie" Display="None" ControlToValidate="tbx_nbDispense_2"  />

        <asp:TextBox ID="tbx_nbDispensePresent_2" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_dispense_present_2" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés présents compris entre 0 et 500 pour la deuxième saisie" ControlToValidate="tbx_nbDispensePresent_2" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  />
        <asp:RequiredFieldValidator ID="rfv_nb_dispense_present_2" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés présents pour la deuxième saisie" Display="None" ControlToValidate="tbx_nbDispensePresent_2"  />

    </asp:Panel>

    <asp:Panel ID="entry_3" runat="server" Visible="false">
        <asp:DropDownList ID="ddl_jour_3" runat="server" AutoPostBack="true" Width="100" OnSelectedIndexChanged="ddl_jour_3_SelectedIndexChanged"/>
        <asp:HiddenField ID="hfd_id3" runat="server" />
        <asp:HiddenField ID="hfd_dateSaisie_3" runat="server" />
        <asp:TextBox ID="tbx_nbMember_3" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_membre_3" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbMember_3" Type="Integer" MinimumValue="1" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres compris entre 1 et 500 pour la troisième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_membre_3" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres pour la troisième saisie" Display="None" ControlToValidate="tbx_nbMember_3"  />

        <asp:TextBox ID="tbx_nbPresent_3" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_present_3" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbPresent_3" Type="Integer" MinimumValue="1" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres présents compris entre 1 et 500 pour la troisième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_present_3" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres présents pour la troisième saisie" Display="None" ControlToValidate="tbx_nbPresent_3"  />
        
        <asp:TextBox ID="tbx_nbCompense_3" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_compense_3" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbCompense_3" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  ErrorMessage="Veuillez saisir le nombre de compensation compris entre 0 et 500 pour la troisième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_compense_3" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de compensation pour la troisième saisie" Display="None" ControlToValidate="tbx_nbCompense_3"  />
        
        <asp:TextBox ID="tbx_nbExcuse_3" runat="server" Width="100"  Text="0" Visible="false"/>
        <asp:RangeValidator id="rvr_nb_excuse_3" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbExcuse_3" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres excusés compris entre 0 et 500 pour la troisième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_excuse_3" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres excusés pour la troisième saisie" Display="None" ControlToValidate="tbx_nbExcuse_3"  />
        
        <asp:TextBox ID="tbx_nbDispense_3" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_dispense_3" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés compris entre 0 et 500 pour la troisième saisie" ControlToValidate="tbx_nbDispense_3" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  />
        <asp:RequiredFieldValidator ID="rfv_nb_dispense_3" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés pour la troisième saisie" Display="None" ControlToValidate="tbx_nbDispense_3"  />
        
        <asp:TextBox ID="tbx_nbDispensePresent_3" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_dispense_present_3" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés présents compris entre 0 et 500 pour la troisième saisie" ControlToValidate="tbx_nbDispensePresent_3" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  />
        <asp:RequiredFieldValidator ID="rfv_nb_dispense_present_3" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés présents pour la troisième saisie" Display="None" ControlToValidate="tbx_nbDispensePresent_3"  />

    </asp:Panel>
     
    <asp:Panel ID="entry_4" runat="server" Visible="false">
        <asp:DropDownList ID="ddl_jour_4" runat="server" AutoPostBack="true" Width="100" OnSelectedIndexChanged="ddl_jour_4_SelectedIndexChanged"/>
        <asp:HiddenField ID="hfd_id4" runat="server" />
        <asp:HiddenField ID="hfd_dateSaisie_4" runat="server" />

        <asp:TextBox ID="tbx_nbMember_4" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_membre_4" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbMember_4" Type="Integer" MinimumValue="1" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres compris entre 1 et 500 pour la quatrième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_membre_4" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres pour la quatrième saisie" Display="None" ControlToValidate="tbx_nbMember_4"  />
        
        <asp:TextBox ID="tbx_nbPresent_4" runat="server" Width="100" />
        <asp:RangeValidator id="rvr_nb_present_4" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbPresent_4" Type="Integer" MinimumValue="1" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres présents compris entre 1 et 500pour la quatrième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_present_4" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres présents pour la quatrième saisie" Display="None" ControlToValidate="tbx_nbPresent_4"  />
        
        <asp:TextBox ID="tbx_nbCompense_4" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_compense_4" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbCompense_4" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  ErrorMessage="Veuillez saisir le nombre de compensation compris entre 0 et 500" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_compense_4" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de compensation pour la quatrième saisie" Display="None" ControlToValidate="tbx_nbCompense_4"  />
        
        <asp:TextBox ID="tbx_nbExcuse_4" runat="server" Width="100"  Text="0" Visible="false" />
        <asp:RangeValidator id="rvr_nb_excuse_4" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbExcuse_4" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres excusés compris entre 0 et 500 pour la quatrième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_excuse_4" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres excusés pour la quatrième saisie" Display="None" ControlToValidate="tbx_nbExcuse_4"  />
        
        <asp:TextBox ID="tbx_nbDispense_4" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_dispense_4" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés compris entre 0 et 500 pour la quatrième saisie" ControlToValidate="tbx_nbDispense_4" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  />
        <asp:RequiredFieldValidator ID="rfv_nb_dispense_4" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés pour la quatrième saisie" Display="None" ControlToValidate="tbx_nbDispense_4"  />
        
        <asp:TextBox ID="tbx_nbDispensePresent_4" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_dispense_present_4" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés présents compris entre 0 et 500 pour la quatrième saisie" ControlToValidate="tbx_nbDispensePresent_4" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  />
        <asp:RequiredFieldValidator ID="rfv_nb_dispense_present_4" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés présents pour la quatrième saisie" Display="None" ControlToValidate="tbx_nbDispensePresent_4"  />

    </asp:Panel>

    <asp:Panel ID="entry_5" runat="server" Visible="false">
        <asp:DropDownList ID="ddl_jour_5" runat="server" AutoPostBack="true" Width="100" OnSelectedIndexChanged="ddl_jour_5_SelectedIndexChanged"/>
        <asp:HiddenField ID="hfd_id5" runat="server" />
        <asp:HiddenField ID="hfd_dateSaisie_5" runat="server" />

        <asp:TextBox ID="tbx_nbMember_5" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_membre_5" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbMember_5" Type="Integer" MinimumValue="1" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres compris entre 1 et 500 pour la cinquième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_membre_5" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres pour la cinquième saisie" Display="None" ControlToValidate="tbx_nbMember_5"  />
        
        <asp:TextBox ID="tbx_nbPresent_5" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_present_5" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbPresent_5" Type="Integer" MinimumValue="1" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres présents compris entre 1 et 500 pour la cinquième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_present_5" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres présentspour la cinquième saisie" Display="None" ControlToValidate="tbx_nbPresent_5"  />
        
        <asp:TextBox ID="tbx_nbCompense_5" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_compense_5" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbCompense_5" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  ErrorMessage="Veuillez saisir le nombre de compensation compris entre 0 et 500 pour la cinquième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_compense_5" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de compensation pour la cinquième saisie" Display="None" ControlToValidate="tbx_nbCompense_5"  />
        
        <asp:TextBox ID="tbx_nbExcuse_5" runat="server" Width="100" Text="0" Visible="false"/>
        <asp:RangeValidator id="rvr_nb_excuse_5" ValidationGroup="vgp_pnl_1" ControlToValidate="tbx_nbExcuse_5" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None" ErrorMessage="Veuillez saisir le nombre de membres excusés compris entre 0 et 500 pour la cinquième saisie" runat="server"/>
        <asp:RequiredFieldValidator ID="rfv_nb_excuse_5" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres excusés pour la cinquième saisie" Display="None" ControlToValidate="tbx_nbExcuse_5"  />
        
        <asp:TextBox ID="tbx_nbDispense_5" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_dispense_5" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés compris entre 0 et 500 pour la cinquième saisie" ControlToValidate="tbx_nbDispense_5" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  />
        <asp:RequiredFieldValidator ID="rfv_nb_dispense_5" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés pour la cinquième saisie" Display="None" ControlToValidate="tbx_nbDispense_5"  />
        
        <asp:TextBox ID="tbx_nbDispensePresent_5" runat="server" Width="100"/>
        <asp:RangeValidator id="rvr_nb_dispense_present_5" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés présents compris entre 0 et 500 pour la cinquième saisie" ControlToValidate="tbx_nbDispensePresent_5" Type="Integer" MinimumValue="0" MaximumValue="500" Display="None"  />
        <asp:RequiredFieldValidator ID="rfv_nb_dispense_present_5" ValidationGroup="vgp_pnl_1" runat="server" ErrorMessage="Veuillez saisir le nombre de membres dispensés présents pour la cinquième saisie" Display="None" ControlToValidate="tbx_nbDispensePresent_5"  />

    </asp:Panel>

        </asp:Panel>
    <br />
    <asp:Panel ID="pnl_btn" runat="server" Visible="false">
        <asp:ValidationSummary ID="vsy_Valide" ValidationGroup="vgp_pnl_1" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
        <asp:Button CssClass="btn btn-primary" runat="server" ID="btn_Valider" Text="Valider" OnClick="btn_Valider_Click" CausesValidation="true" ValidationGroup="vgp_pnl_1" />
        <asp:Button CssClass="btn btn-default" runat="server" ID="btn_annuler" Text="Annuler" OnClick="btn_annuler_Click" CausesValidation="false" ValidationGroup="vgp_pnl_1"/>
    </asp:Panel>


  







    

</asp:Panel>

 <script type="text/javascript" >
     function UserDeleteConfirmation() {
         return confirm("Etes-vous sûr de vouloir supprimer cet enregistrement?");
     }
 </script>

<asp:Panel ID="pnl_grid" runat="server">

        


    <asp:GridView ID="gvw_assiduite" runat="server"  CssClass="tableDefault spacingTop" 
        OnRowCommand="gvw_assiduite_RowCommand"
        AllowSorting="True" 
        GridLines="None" 
        AllowPaging="True" 
        PageSize="25" 
        AutoGenerateColumns="False" 
        DataKeyNames="id"  
        AutoGenerateSelectButton="false"
        OnRowDataBound="gvw_assiduite_RowDataBound"   >    

        <Columns >   
            
            <asp:TemplateField HeaderText="Année" >
                <ItemTemplate>
                    <asp:Label ID="lbl_annee_2" runat="server" text='<%#Eval("year") %>' Width="50" />
                </ItemTemplate>
            </asp:TemplateField>
                        
            <asp:TemplateField HeaderText="Mois" >
                <ItemTemplate>
                    <asp:Label ID="lbl_mois_2" runat="server" text='<%#Eval("month") %>' Width="50"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Pourcentage de présence" >
                <ItemTemplate>
                    <asp:Label ID="lbl_purcent" runat="server" text='<%#Eval("purcent") %>' Width="50"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ValidationSummary ID="vsy_Valide" ValidationGroup="pnl_grid" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />   
                    <asp:Button CssClass="btn btn-primary" ID="btn_modif" runat="server" Text="Modifier"  CommandName="modifier" CausesValidation="true" ValidationGroup="pnl_grid" CommandArgument='<%# Eval("year")  + "-"  + Eval("month")%>'/>
                    <%--<asp:button ID="btn_supp" runat="server" Text="Supprimer"   CommandName="supprimer" CausesValidation="false" ValidationGroup="pnl_grid" CommandArgument='<%#Eval("id") %>' OnClientClick="if ( ! UserDeleteConfirmation()) return false;"/>--%>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>    
   
    <EmptyDataTemplate>Aucune assiduité saisie</EmptyDataTemplate>
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>

</asp:Panel>








