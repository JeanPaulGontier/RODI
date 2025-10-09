<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Import RI ClubRecognitionSummary.ascx.cs" Inherits="DesktopModules_AIS_Admin_Import_RI" %>


<asp:Panel runat="server" ID="error" Visible="false" CssClass="alert alert-danger">
    <asp:Literal runat="server" ID="errorlabel"></asp:Literal>
</asp:Panel>
<asp:Panel runat="server" ID="panel">
    <div>
        <h2>Importation du fichier extrait du site Rotary.org (ClubRecognitionSummary.xlsx)</h2>
     <%--   <div class="alert alert-info">Le traitement se déroule en 2 étapes :<br /><ol>
            <li>l'import pour vérifier qu'il s'agit du bon fichier</li>
            <li>puis le rapprochement qui met à jour les données locales de RODI</li>
                                                         </ol> </div>--%>
        <asp:Panel runat="server" ID="dvFileUpload">       
            <div><asp:FileUpload runat="server" ID="FU_RI" Width="100%" /><br /></div>
            <div style="padding:10px 0">
                <asp:Button runat="server" ID="BT_Upload" CssClass="btn btn-primary"  Text="Importer" OnClick="BT_Upload_Click" CausesValidation="false"  /><br />
            </div>
                
            <div style="display: none">
                
                <script>function OnClientUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload.ClientID %>'); bt.click(); }</script>
            </div>            
        </asp:Panel>


        <div style="width:100%;overflow-x:auto">
                   
            <asp:Panel runat="server" ID="panel_result" Visible="false">
                <div style="padding:10px"><asp:Label runat="server" ID="lbl_result"></asp:Label></div>
                <asp:DataGrid runat="server" ID="members" AutoGenerateColumns="true" CssClass="table table-striped">

                </asp:DataGrid>
            </asp:Panel>
        </div>
    </div>
    
</asp:Panel>


