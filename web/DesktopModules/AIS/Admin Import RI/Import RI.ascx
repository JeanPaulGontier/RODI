<!--**********************************************************************************-->
<!-- RODI - https://rodi-platform.org                                                 -->
<!-- Copyright (c) 2012-2022                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Import RI.ascx.cs" Inherits="DesktopModules_AIS_Admin_Import_RI" %>


<asp:Panel runat="server" ID="error" Visible="false" CssClass="alert alert-danger">
    <asp:Literal runat="server" ID="errorlabel"></asp:Literal>
</asp:Panel>
<asp:Panel runat="server" ID="panel">
    <div>
        <h2>Traitement du fichier Excel des membres extrait du site Rotary.org (ClubsandMembersinYourDistrictList.xlsx)</h2>

        <asp:Panel runat="server" ID="dvFileUpload">       
            <div><asp:FileUpload runat="server" ID="FU_RI" /><br /></div>
            <div><asp:Button runat="server" ID="BT_Upload" CssClass="btn btn-primary"  Text="Importer" OnClick="BT_Upload_Click" CausesValidation="false" /><br />
            </div>
                
            <div style="display: none">
                
                <script>function OnClientUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload.ClientID %>'); bt.click(); }</script>
            </div>            
        </asp:Panel>


        <%--<asp:Button ID="btn_import_ri" runat="server" CssClass="btn btn-primary" Text="Importer le fichier" OnClick="btn_import_ri_Click" />    --%>            
        <div style="width:100%;overflow-x:auto">
            <asp:Button ID="btn_rapprochement" runat="server" CssClass="btn btn-primary" Text="Rapprochement" OnClick="btn_rapprochement_Click" Visible="false"/>
            <asp:Panel runat="server" ID="panel_rapprochement">
                <div style="padding: 10px">
                    <asp:Literal runat="server" ID="result_rapprochement"></asp:Literal>
                    <em>Attention : lors du rapprochement, les données issues du fichier du RI remplaceront les données existantes des membres pour les champs suivants : civilité, date d'admission, nom, prenom, adresse, cp, ville, pays, email et telephone, ce qui peut impacter l'accès de l'utilisateur qui est basé sur l'email</em>
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


