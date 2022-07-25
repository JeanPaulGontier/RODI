<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Actions_List_Control" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



<style type="text/css">
    .auto-style1
    {
        width: 200px;
    }
    .auto-style2
    {
        width: 220px;
    }
</style>



<asp:Panel ID="Panel1" runat="server">
<asp:Button runat="server" Text="Ajouter une action" ID="BT_Ajouter_Nouvelle" OnClick="BT_Ajouter_Nouvelle_Click" />
<asp:GridView ID="GridView1" runat="server" CssClass="tableDefault spacingTop"  AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
<Columns>
    
    <asp:BoundField DataField="name_action" HeaderText="Action"  SortExpression="name_action" />
    <asp:BoundField DataField="dt_action" HeaderText="Date" SortExpression="dt_action" DataFormatString="{0:d}"/>
    <asp:BoundField DataField="goal" HeaderText="Objectif"  SortExpression="goal" />
    <asp:BoundField DataField="name_responsable" HeaderText="Responsable" SortExpression="name_responsable" />
    <asp:BoundField DataField="club_name" HeaderText="Club" SortExpression="club_name" />
    <asp:BoundField DataField="geographical_area" HeaderText="Zone géographique" SortExpression="geographical_area" />
    <asp:ButtonField ButtonType="Link" runat="server" Text="Détail" CommandName="detail" />
</Columns>    
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
<asp:HiddenField ID="tri" Value="name" runat="server"/><asp:HiddenField ID="sens" Value="ASC" runat="server"/>
<asp:HiddenField ID="HF_Cric" runat="server" />
</asp:Panel>


<asp:Panel ID="Panel2" runat="server" Visible="false">
<asp:HiddenField runat="server" ID="HF_id" />

<div class="Marron">
	<h2><span class="Head">Détail de l'action</span></h2>
</div>
    <asp:Panel runat="server" ID="P_Modifiable">
        <table>
    <tr>
        <td class="auto-style1"><b></b></td><td><b>Exemple d&#39;action :</b></td><td><b>Votre action :</b></td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Début de l&#39;action : </b> </td>
        <td><i>05/05/2011</i></td>
        <td>
            <telerik:RadDatePicker ID="DT_Date" runat="server" Height="24px"/>
        </td>
    </tr>
    <tr>
        <td class="auto-style1"></td><td></td><td></td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Nom de l&#39;action :</b></td>
        <td><i>BLE DE L&#39;ESPERENCE</i></td>
        <td><asp:TextBox runat="server" ID="TXT_nom_action" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_nom_action" ErrorMessage="Nom de l'action">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Description :</b></td>
        <td><i>Vente de sac de blé auprès de commerces.</i></td>
        <td>
            <asp:TextBox ID="TXT_description" runat="server" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXT_description" ErrorMessage="Description de l'action">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Nom du club :</b></td>
        <td><i>Club du District 1730</i></td>
        <td><asp:Label runat="server" ID="LBL_nom_club"></asp:Label></td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td><i></i></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Coordonnées du
            <br />
            responsable de
            <br />
            l&#39;action :</b></td>
        <td><i>Sélectionner un membre du club</i></td>
        <td>
        <table>
                <tr>
                    <td>
                    <asp:DropDownList ID="DL_id_user_responsable" runat="server">
                    </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LBL_nom_user_responsable"></asp:Label>
                    </td>
                </tr>
            </table>
            </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td><i></i></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Finalité / Objectif :</b></td>
        <td><i>Le fruit de la collecte permet de doter les services pédiatriques des centres d&#39;accueil spécialisés, de matériel informatique, ludique, audiovisuel ou médical.</i></td>
        <td>
            <asp:TextBox ID="TXT_objectif" runat="server" Width="400px" TextMode="MultiLine" Height="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td><i></i></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Membre du club
            <br />
            au courant de l&#39;action :</b></td>
        <td><i>Sélectionner un membre du club</i></td>
        <td>
            <table>
                <tr>
                    <td>
                    <asp:DropDownList ID="DL_id_user_courant" runat="server">
                    </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LBL_nom_user_courant"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td><i></i></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Moyens matériels :</b></td>
        <td><i>L&#39;association Blé de l&#39;Espérance réalise un packaging contenant une boite en carton permettant de recueillir l&#39;argent et des sachets de blé que le donateur achète pour semer chez lui ces grains de blé.</i></td>
        <td>
            <asp:TextBox ID="TXT_moyens_materiel" runat="server" Height="150px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td><i></i></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Description des
            <br />
            phases :</b></td>
        <td><i>En octobre :<br />
            <br />
            Le club évalue le nombre de boites qui lui semble possible de déposer chez les commerçants. Commande à l&#39;association Blé de l&#39;Espérance de x boites.<br /> Dépôt des boites chez les commerçants.<br />
            <br />
            Début décembre :<br />
            <br />
            Le club récupère les boites. Comptabilise l&#39;argent récolté. Envoi l&#39;argent à l&#39;association Blé de
            <br />
            l&#39;Espérance, par exemple 10 000 €. Transmet le projet d&#39;affectation de cette somme à tel projet. L&#39;association Blé de l&#39;Espérance adresse un chèque au club pour réaliser le projet, validé par l&#39;association elle-même.</i></td>
        <td>
            <asp:TextBox ID="TXT_description_phases" runat="server" Height="400px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td><i></i></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Moyens humains :</b></td>
        <td><i>10 personnes</i></td>
        <td>
            <asp:TextBox ID="TXT_moyens_humains" runat="server" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td><i></i></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Remarques :</b></td>
        <td><i>Exemple : préciser les points auxquels il faut prêter attention pour le bon déroulement de l&#39;action...</i></td>
        <td>
            <asp:TextBox ID="TXT_remarques" runat="server" Height="100px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td><i></i></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Résultat de l&#39;action : </b> </td>
        <td><i>Exemple : décrire les résultats sur plusieurs années...</i></td>
        <td>
            <asp:TextBox ID="TXT_resultats" runat="server" Height="100px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td><i></i></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1"><b>Zone<br /> géographique<br /> déjà courverte :</b></td>
        <td><i>Nice</i></td>
        <td>
            <asp:TextBox ID="TXT_zone_geographique" runat="server" Height="100px" TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="3"><asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" /></td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Button ID="BT_Supprimer" runat="server" CausesValidation="false" OnClick="BT_Supprimer_Click" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer cette action ?');" Text="Supprimer" />
        </td>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="BT_Valider" runat="server" OnClick="BT_Valider_Click" Text="Valider" />&nbsp;
            <asp:Button ID="BT_Annuler" runat="server" CausesValidation="false" OnClick="BT_Annuler_Click" Text="Retour" />
        </td>
    </tr>
</table>
    </asp:Panel>
    <asp:Panel runat="server" ID="P_Lecture">
        <table>
    <tr>
        <td class="auto-style2"><b>Début de l&#39;action : </b></td><td>
        <asp:Label ID="LBL_date" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2"></td><td></td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Nom de l&#39;action :</b></td>
        <td>
            <asp:Label ID="LBL_nom_action" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Description :</b></td>
        <td>
            <asp:Label ID="LBL_description" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Nom du club :</b></td>
        <td><asp:Label runat="server" ID="LBL_nom_club1"></asp:Label></td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Coordonnées du
            <br />
            responsable de
            <br />
            l&#39;action :</b></td>
        <td>
              <asp:Label runat="server" ID="LBL_nom_responsable"></asp:Label>
         </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Finalité / Objectif :</b></td>
        <td>
            <asp:Label ID="LBL_objectif" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Membre du club
            <br />
            au courant de l&#39;action :</b></td>
        <td>
            <asp:Label runat="server" ID="LBL_nom_courant"></asp:Label>
                
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Moyens matériels :</b></td>
        <td>
            <asp:Label ID="LBL_moyens" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Description des phases :</b></td>
        <td>
            <asp:Label ID="LBL_phases" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Moyens humains :</b></td>
        <td>
            <asp:Label ID="LBL_humains" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Remarques :</b></td>
        <td>
            <asp:Label ID="LBL_remarques" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Résultat de l&#39;action : </b> </td>
        <td>
            <asp:Label ID="LBL_resultat" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2"><b>Zone<br /> géographique<br /> déjà courverte :</b></td>
        <td>
            <asp:Label ID="LBL_zone" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            &nbsp;</td>
        <td>
            &nbsp;<asp:Button ID="BT_retour1" runat="server" CausesValidation="false" OnClick="BT_Annuler_Click" Text="Retour" />
        </td>
    </tr>
</table>
    </asp:Panel>
</asp:Panel>
