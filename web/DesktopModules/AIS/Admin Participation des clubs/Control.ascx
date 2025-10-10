<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_Admin_Import_RI" %>


<asp:Panel runat="server" ID="error" Visible="false" CssClass="alert alert-danger">
    <asp:Literal runat="server" ID="errorlabel"></asp:Literal>
</asp:Panel>
 <asp:Panel runat="server" ID="panel_result" CssClass="alert alert-success" Visible="false">
     <asp:Label runat="server" ID="lbl_result"></asp:Label>
 </asp:Panel>
<asp:Panel runat="server" ID="panel">
    <div>
        <h2>Participation des clubs aux manifestations du district</h2>
        <div class="alert alert-info">La mise à jour de la participation des clubs se déroule en 4 étapes :<br />
            <ol>
                <li>Choisir l'année rotarienne à traiter</li>
                <li><span class="btn btn-default btn-xs">Exporter les participations de l'année</span>en format Excel pour avoir un gabarit de saisie</li>
                <li>Saisir les données de l'année dans le fichier Excel (ne pas modifier la forme du fichier)</li>
                <li>puis <span class="btn btn-default btn-xs">Importer l'année à partir du fichier</span> les données de l'année sont alors remplacées par celle du fichier importé</li>
            </ol> 
        </div>


        <div style="width:100%;overflow-x:auto">
                   
           
            <div class="form-inline"><label>Année rotarienne :&nbsp;</label><asp:DropDownList AutoPostBack="true" Width="150" runat="server" ID="annee" CssClass="form-control"></asp:DropDownList></div>
            <div class="row">
            <div class="col-sm-6"><br /><asp:Button runat="server" ID="BT_Export" CssClass="btn btn-primary m-3"  Text="Exporter les participations de l'année" OnClick="BT_Export_Click" CausesValidation="false"  /></div>

            <asp:Panel runat="server" ID="dvFileUpload" CssClass="col-sm-6">       
                <div><asp:FileUpload runat="server" ID="FU_RI" Width="100%" /><br /></div>
                <div style="padding:10px 0">
                    <asp:Button runat="server" ID="BT_Upload" CssClass="btn btn-primary"  Text="Importer l'année à partir du fichier" OnClick="BT_Upload_Click" CausesValidation="false"  /><br />
                </div>
                
                <div style="display: none">
                
                    <script>function OnClientUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload.ClientID %>'); bt.click(); }</script>
                </div>      
            
                
            </asp:Panel>
            </div>

            <asp:DataGrid runat="server" ID="members" AutoGenerateColumns="true" CssClass="table table-striped">

            </asp:DataGrid>
        </div>
    </div>
    
</asp:Panel>


