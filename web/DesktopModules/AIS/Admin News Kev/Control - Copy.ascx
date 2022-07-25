<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control - Copy.ascx.cs" Inherits="DesktopModules_AIS_Admin_News_Kev_Control" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register TagPrefix="AIS" TagName="FilesManager"   Src="~/AIS/FilesManager/FilesManagerControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx" %>


<asp:Label ID="test" runat="server" />

<asp:Panel ID="pnl_grid" runat="server">
<asp:Button runat="server" Text="Ajouter une nouvelle" ID="BT_Ajouter_News" OnClick="BT_Ajouter_News_Click" />
<h3><asp:Label runat="server" ID="lbl_TousADG" Visible="false" Text="Choisissez un club" /></h3>
<asp:GridView ID="GridView1" runat="server" CssClass="tableDefault spacingTop"  AllowSorting="True"  GridLines="None" AllowPaging="True" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnSorting="GridView1_Sorting">
<Columns>
    <asp:BoundField DataField="dt" HeaderText="Date" SortExpression="dt" DataFormatString="{0:d}" />
    <asp:BoundField DataField="title" HeaderText="Titre"  SortExpression="title" />
    <asp:BoundField DataField="category" HeaderText="Catégorie" SortExpression="category" />
    <asp:BoundField DataField="tag1" HeaderText="Nature" SortExpression="tag1" />
    <asp:BoundField DataField="visible" HeaderText="Visible" SortExpression="visible" />
    <asp:ButtonField ButtonType="Link" runat="server" Text="Détail" CommandName="detail" />
</Columns>    
   <PagerSettings Mode="NumericFirstLast" Position="Bottom" /> 
</asp:GridView>
<asp:HiddenField ID="tri" Value="dt" runat="server"/><asp:HiddenField ID="sens" Value="ASC" runat="server"/>
<asp:HiddenField ID="HF_Cric" runat="server" />
</asp:Panel>
<asp:Panel ID="pnl_select" runat="server">
    <asp:RadioButtonList ID="RB_Nature" runat="server"></asp:RadioButtonList>
    <asp:Button ID="BT_Suivant" Text="Suivant" runat="server" OnClick="BT_Suivant_Click" />
</asp:Panel>
<asp:Panel ID="pnl_form" runat="server" Visible="false">
<asp:HiddenField runat="server" ID="HF_id" />
<asp:HiddenField runat="server" ID="HF_role_admin" />
<asp:HiddenField runat="server" ID="HF_categorie" />
<asp:HiddenField runat="server" ID="HF_path" />

<div class="Marron">
	<h2><span class="Head"><asp:Label ID="LB_Titre" Text="" runat="server" /></span></h2>
</div>

<div class="Table">
	<div class="TableCell">
        <table>
            <tr>
                <td colspan="2">
                    <asp:Panel runat="server" ID="PanelSujet">
                        <asp:Label ID="LB_Nature" Text="" runat="server" /> en tant qu'<asp:Label ID="LB_RoleAdmin" Text="" runat="server" />.
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Visible :</span>
                </td>
                <td>
                    <asp:RadioButtonList ID="RB_Visible" runat="server" RepeatDirection="Horizontal">
	    		        <asp:ListItem Text="Oui" Value="O" /><asp:ListItem Text="Non" Value="N" />
	    	        </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Date : </span>
                </td>
                <td>
                    <telerik:RadDatePicker runat="server" ID="TXT_Dt"></telerik:RadDatePicker>
                </td>
            </tr>
            <asp:Panel runat="server" ID="PanelDateFin">
                <tr>
                    <td>
                        <span>Date de fin : </span>
                    </td>
                    <td>
                        <telerik:RadDatePicker runat="server" ID="TXT_Dt_fin" ></telerik:RadDatePicker>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel runat="server" ID="PanelLocalisation">
                <tr>
                    <td>
                        <span>Adresse : </span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TXT_Adresse" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Code Postal : </span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TXT_CP" MaxLength="5" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Ville : </span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="TXT_Ville" />
                    </td>
                </tr>
            </asp:Panel>
        </table>
		<%--<asp:Panel runat="server" ID="PanelSujet">
	        <span>Catégorie :</span>
            <asp:DropDownList runat="server" ID="DL_Sujet">
            <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>            
            <asp:ListItem Text="Action" Value="Action"></asp:ListItem>
            <asp:ListItem Text="Bulletin" Value="Bulletin"></asp:ListItem>
            <asp:ListItem Text="Conférence" Value="Conférence"></asp:ListItem>
            <asp:ListItem Text="District 1730" Value="District 1730"></asp:ListItem>
            <asp:ListItem Text="Général" Value="Général"></asp:ListItem>
            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Veuillez sélectionner une catégorie" ControlToValidate="DL_Sujet" Display="None"></asp:RequiredFieldValidator>            
	    </asp:Panel>--%>
	</div>
	
	<div class="TableCell">
        <table>
            <tr>
                <td>
                    <span>Titre : </span>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TXT_Titre" MaxLength="255" Width="75%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Il manque le titre" Display="None" ControlToValidate="TXT_Titre"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Résumé :</span>
                </td>
                <td>
                    <asp:TextBox ID="TXT_Resume" runat="server" Width="75%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Photo : </span>
                </td>
                <td>
                    <telerik:RadAsyncUpload ID="FU_Photo" HideFileInput="true" Localization-Select="Sélectionner une photo"  MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientPhotoUploaded" AllowedFileExtensions="jpg,jpeg,gif,png,bmp" ></telerik:RadAsyncUpload>
                </td>
            </tr>
            <tr style="display:none">
                <td colspan="2">
                    <asp:Image runat="server" ID="IMG_Photo" /><asp:HiddenField runat="server" ID="HF_Photo" />
                </td>
            </tr>
            <tr style="display:none">
                <td>
                    <div style="display:none">
        		        <asp:Button runat="server" ID="BT_Upload_Photo" Text="Mettre à jour" OnClick="BT_Upload_Photo_Click" CausesValidation="false" />
        		        <script>function OnClientPhotoUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload_Photo.ClientID %>'); bt.click(); }</script>
        	        </div>
                </td>
                <td>
                    <asp:Button runat="server" ID="BT_Effacer_Photo" Text="Supprimer la photo" OnClick="BT_Effacer_Photo_Click" CausesValidation="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <span>Texte : </span>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadEditor runat="server" ID="TXT_Texte">
                        <Tools>
                            <telerik:EditorToolGroup>
                                <telerik:EditorTool Name="Bold" />
                                <telerik:EditorTool Name="Italic" />
                                <telerik:EditorTool Name="Underline" />
                            </telerik:EditorToolGroup>
                            <telerik:EditorToolGroup Tag="FileManagers">
                                <telerik:EditorTool Name="DocumentManager" />
                                <telerik:EditorTool Name="ImageManager" />
                                <telerik:EditorTool Name="InsertLink" />
                            </telerik:EditorToolGroup>
                        </Tools>
                    </telerik:RadEditor>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Le texte n'a pas été saisi" Display="None" ControlToValidate="TXT_Texte"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Fichier : </span>
                </td>
                <td>
                    <asp:HyperLink runat="server" ID="HL_Url" Target="_blank"></asp:HyperLink>
                    <telerik:RadAsyncUpload ID="FU_Url" HideFileInput="true" DisablePlugins="true" Localization-Select="Sélectionner un fichier" MultipleFileSelection="Disabled" runat="server" OnClientFileUploaded="OnClientFileUploaded" ></telerik:RadAsyncUpload>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="display:none">
	    		        <asp:Button runat="server" ID="BT_Upload_Fichier" Text="Envoyer" OnClick="BT_Upload_Fichier_Click" CausesValidation="false"  />
	    		        <script>function OnClientFileUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload_Fichier.ClientID %>'); bt.click(); }</script>
	    	        </div>
                    <%--<AIS:FilesManager runat="server" ID="FU_Url"  PathFile="Images/Upload2" Multiple="false" ThumbImage="true" TypeFilter="image" ExtFilter="jpg,png,bmp" ExtAuthorised="images/" ReadOnly="false" />--%>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Nom visible du fichier : </span>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TXT_Url_Texte" Width="75%"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td>
                    <asp:Button runat="server" ID="BT_Effacer_Fichier" Text="Supprimer le fichier" OnClick="BT_Effacer_Fichier_Click"  CausesValidation="false" />
                </td>
                <td>
                    <asp:Button runat="server" ID="BT_Creer_Vignette" Text="Créer l'image du fichier" OnClick="BT_Creer_Vignette_Click" CausesValidation="false" />
                </td>
            </tr>
        </table>
        <div>
            <%--<asp:Button ID="BT_Evenement" runat="server" Text="Ajouter une date et un lieu à l'évènement" />--%>
        </div>
	</div>
</div>

<div class="txtCenter">
	<asp:ValidationSummary runat="server" DisplayMode="BulletList" HeaderText="Veuillez compléter le formulaire avant de valider..." ShowMessageBox="true" ShowSummary="false" />
	<asp:Button runat="server" ID="BT_Supprimer" Text="Supprimer" CausesValidation="false" OnClick="BT_Supprimer_Click" OnClientClick="Javascript: return confirm('Voulez-vous vraiment supprimer cette nouvelle ?');" />&nbsp;
	<asp:Button runat="server" ID="BT_Valider" Text="Valider" OnClick="BT_Valider_Click" />&nbsp;<asp:Button runat="server" ID="BT_Annuler" Text="Retour" OnClick="BT_Annuler_Click" CausesValidation="false" />
</div>
</asp:Panel>






