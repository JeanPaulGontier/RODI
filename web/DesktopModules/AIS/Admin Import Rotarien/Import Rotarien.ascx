<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2016                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Import Rotarien.ascx.cs" Inherits="DesktopModules_AIS_Admin_Import_Rotarien_Import_Rotarien" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel runat="server" ID="error" Visible="false"></asp:Panel>
<asp:Panel ID="panel" runat="server" >

    <h2>Mise à jour des informations membres à partir des données du site lerotarien.org (export_membre dd mm yyyy.xls)</h2>

        <asp:Panel runat="server" ID="dvFileUpload">            
            <telerik:RadAsyncUpload ID="FU_RI" Localization-Select="Import" HideFileInput="true" DisablePlugins="true" MultipleFileSelection="Disabled" runat="server"
                OnClientFileUploaded="OnClientUploaded" AllowedFileExtensions="xls"></telerik:radasyncupload>
                
            <div style="display: none">
                <asp:Button runat="server" ID="BT_Upload" Text="Importer" OnClick="BT_Upload_Click" CausesValidation="false" />
                <script>function OnClientUploaded(sender, args) { var contentType = args.get_fileInfo().ContentType; var bt = document.getElementById('<%=BT_Upload.ClientID %>'); bt.click(); }</script>
            </div>            
        </asp:Panel>

            <%--<asp:Button ID="btn_import_ri" runat="server" CssClass="btn btn-primary" Text="Importer le fichier" OnClick="btn_import_ri_Click" />    --%>            
        <asp:Button ID="btn_rapprochement" runat="server" CssClass="btn btn-primary" Text="Rapprochement" OnClick="btn_rapprochement_Click" Visible="false"/>
        <asp:Panel runat="server" ID="panel_result" Visible="false">
            <div style="padding:10px"><asp:Label runat="server" ID="lbl_result"></asp:Label></div>
            <asp:DataGrid runat="server" ID="members" AutoGenerateColumns="true" CssClass="table table-striped">

            </asp:DataGrid>
        </asp:Panel>
        <asp:Panel runat="server" ID="panel_rapprochement">
            <asp:Literal runat="server" ID="result_rapprochement"></asp:Literal>
        </asp:Panel>


</asp:Panel>
