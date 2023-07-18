<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Import RI.ascx.cs" Inherits="DesktopModules_AIS_Admin_Import_RI" %>


<asp:Panel runat="server" ID="error" Visible="false" CssClass="alert alert-danger">
    <asp:Literal runat="server" ID="errorlabel"></asp:Literal>
</asp:Panel>
<asp:Panel runat="server" ID="panel">
    <div>
        <h2>Traitement du fichier Excel des membres extrait du site Rotary.org (ClubsandMembersinYourDistrictList.xlsx)</h2>
        <div class="alert alert-info">Le traitement se déroule en 2 étapes :<br /><ol>
            <li>l'import pour vérifier qu'il s'agit du bon fichier</li>
            <li>puis le rapprochement qui met à jour les données locales de RODI</li>
                                                         </ol> </div>
        <asp:Panel runat="server" ID="dvFileUpload">       
            <div><asp:FileUpload runat="server" ID="FU_RI" /><br /></div>
            <div style="padding:10px 0"><asp:Button runat="server" ID="BT_Upload" CssClass="btn btn-primary"  Text="Importer" OnClick="BT_Upload_Click" CausesValidation="false" /><br />
            </div>
                
            <div style="display: none">
                
                <script>function OnClientUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload.ClientID %>'); bt.click(); }</script>
            </div>            
        </asp:Panel>


        <%--<asp:Button ID="btn_import_ri" runat="server" CssClass="btn btn-primary" Text="Importer le fichier" OnClick="btn_import_ri_Click" />    --%>            
        <div style="width:100%;overflow-x:auto">
       
           <asp:Panel runat="server" ID="panel_rapprochement" Visible="false">
                 <div class="alert alert-info">Fonctionnement du rapprochement :<br />
                    <ul>
                        <li>Ajoute les membres manquants (nim,email,nom,prenom,sexe,date admission,telephone,adresse professionnelle,statut honorifique)</li>
                        <li>Supprime ceux qui ne sont plus rotarien ou rotaractien.</li>
                        <li>Pour les membres existant dans RODI, seul l'appartenance au club, le statut honorifique et l'email sont remplacés (pour l'email uniquement s'il n'y avait pas déjà un email local)</li>   
                    </ul>

                </div>
          </asp:Panel>   
            <div>
              <asp:Button ID="btn_rapprochement" runat="server" CssClass="btn btn-primary" Text="Rapprochement" OnClick="btn_rapprochement_Click" Visible="false"/>
           </div>
                <div style="padding: 10px">
                    <asp:Literal runat="server" ID="result_rapprochement"></asp:Literal>
                </div>
            
           
            <asp:Panel runat="server" ID="panel_result" Visible="false">
                <div style="padding:10px"><asp:Label runat="server" ID="lbl_result"></asp:Label></div>
                <asp:DataGrid runat="server" ID="members" AutoGenerateColumns="true" CssClass="table table-striped">

                </asp:DataGrid>
            </asp:Panel>
        </div>
    </div>
    
</asp:Panel>


