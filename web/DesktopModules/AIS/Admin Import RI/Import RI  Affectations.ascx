
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Import RI  Affectations.ascx.cs" Inherits="DesktopModules_AIS_Admin_Import_RI_Affectations" %>


<asp:Panel runat="server" ID="error" Visible="false" CssClass="alert alert-danger">
    <asp:Literal runat="server" ID="errorlabel"></asp:Literal>
</asp:Panel>
<asp:Panel runat="server" ID="panel">
    <div>
        <h2>Traitement du fichier Excel des affectations extrait du site Rotary.org (CurrentClubOfficer.xlsx & IncomingClubOfficer.xlsx)</h2>
        <div>
            <h3>Type de fichier a importer :</h3>
            <asp:RadioButtonList runat="server" ID="RB_type">
                <asp:ListItem Value="current" Text="currentclubofficer.xlsx" Selected="True"></asp:ListItem>
                <asp:ListItem Value="incoming" Text="incomingclubofficer.xlsx"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Panel runat="server" ID="dvFileUpload">       
            <div><asp:FileUpload runat="server" ID="FU_RI" Width="100%" /><br /></div>
            <div><asp:Button runat="server" ID="BT_Upload" CssClass="btn btn-primary"  Text="Importer" OnClick="BT_Upload_Click" CausesValidation="false" /><br />
            </div>
                
            <div style="display: none">
                
                <script>function OnClientUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload.ClientID %>'); bt.click(); }</script>
            </div>            
        </asp:Panel>


        <%--<asp:Button ID="btn_import_ri" runat="server" CssClass="btn btn-primary" Text="Importer le fichier" OnClick="btn_import_ri_Click" />    --%>            
        <div style="width:100%;overflow-x:auto">
            <div>&nbsp;</div>
            <asp:Button ID="btn_rapprochement" runat="server" CssClass="btn btn-primary" Text="Rapprochement" OnClick="btn_rapprochement_Click" Visible="false"/>
            <asp:Panel runat="server" ID="panel_rapprochement">
                <div style="padding: 10px">
                    <asp:Literal runat="server" ID="result_rapprochement"></asp:Literal>
                    <div class="alert alert-info">
                        <ul>
                            <li>Lors du rapprochement, les données issues du fichier du RI remplaceront les données existantes seulement pour les rôles indiqués dans le RI, si l'information n'est pas signalée sur le RI pour un rôle alors il ne change pas le rôle déjà renseigné dans RODI</li>
                            <li>Les présidents sont automatiquement affectés comme présidents élus pour l'année n-1</li>
                        </ul>
                    </div>
                </div>
            </asp:Panel>        
            <asp:Panel runat="server" ID="panel_result" Visible="false">
                <div style="padding:10px"><asp:Label runat="server" ID="lbl_result"></asp:Label></div>
                <asp:DataGrid runat="server" ID="members" AutoGenerateColumns="true" CssClass="table table-striped">

                </asp:DataGrid>
            </asp:Panel>
        </div>
    </div>
    
</asp:Panel>


