<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2018                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditSliderShow.ascx.cs" Inherits="DesktopModules_AIS_Club_Nouvelles_Control" %>
<%@ Register TagPrefix="AIS" TagName="FileManager" Src="~/AIS/FilesManager/FileManagerControl.ascx" %>


<asp:Panel ID="pnl_Images"  runat="server">
    <script type="text/javascript">
             // Get the instance of PageRequestManager.
             var prm = Sys.WebForms.PageRequestManager.getInstance();
             // Add initializeRequest and endRequest
             prm.add_initializeRequest(prm_InitializeRequest);
             prm.add_endRequest(prm_EndRequest);
            
             // Called when async postback begins
             function prm_InitializeRequest(sender, args) {
                 // get the divImage and set it to visible
                 var panelProg = $get('divImage_Images');                
                 panelProg.style.display = '';
                 // reset label text
                 var lbl = $get('<%= this.lblText_Images.ClientID %>');
                 lbl.innerHTML = '';
 
                 // Disable button that caused a postback
                 $get(args._postBackElement.id).disabled = true;
             }
 
             // Called when async postback ends
             function prm_EndRequest(sender, args) {
                 // get the divImage and hide it again
                 var panelProg = $get('divImage_Images');                
                 panelProg.style.display = 'none';
 
                 // Enable button that caused a postback
                 $get(sender._postBackSettings.sourceElement.id).disabled = false;
             }
    </script>

    

    <asp:UpdatePanel ID="upnl_Images" runat="server" class="relative">
        <ContentTemplate>
            <asp:HiddenField ID="hdf_Images" runat="server" />

            <asp:Label ID="lblText_Images" runat="server" Text=""></asp:Label>
            
            <div id="divImage_Images" style="display: none" class="progressBar">
                <asp:Image ID="img_Images" runat="server" ImageUrl="~/images/progressbar.gif" />
                <p>processing...</p>
            </div>

            <ul id="ul_ManageImg" style="margin:0;" >
                <asp:Repeater ID="rpt_ManageImg" runat="server" OnItemDataBound="rpt_ManageImg_ItemDataBound" OnItemCommand="rpt_ManageImg_ItemCommand" >
                    <ItemTemplate>
                        <li id="li_Img" class="panel panel-default" style="list-style: none;">
                            <div class="panel-body">
                                
                                <asp:Image ID="img_ManageImg" runat="server" />
                                <p>
                                    <asp:Label ID="lbl_Title" runat="server" Text="Titre : " />
                                    <asp:TextBox ID="tbx_title" runat="server" CssClass="form-control" />
                                </p>
                                <p>
                                    <asp:Label ID="lbl_urlText" runat="server" Text="URL de l'article" />
                                    <asp:TextBox ID="tbx_urlText" runat="server" CssClass="form-control" />
                                </p>
                                <asp:Label ID="lbl_visible" runat="server" Text="Visible : " />
                                <asp:RadioButtonList ID="rbtl_visible" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Text="Oui" Value="true" />
                                    <asp:ListItem Text="Non" Value="false" />
                                </asp:RadioButtonList>
                           <div class="text-right">
                                <asp:LinkButton ID="ibt_up" Visible ="false" runat="server" CssClass="btn btn-primary" ToolTip="Monter" ><span class="glyphicon glyphicon-chevron-up"></span></asp:LinkButton>
                                <asp:LinkButton ID="ibt_down" Visible="false" runat="server" CssClass="btn btn-primary" ToolTip="Descendre"><span class="glyphicon glyphicon-chevron-down"></span></asp:LinkButton>
                           </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>

        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Button ID="btn_valid" runat="server" Text="Valider" OnClick="btn_valid_Click" CssClass="btn btn-primary" />

    <h4>
        <asp:Label ID="lbl_phototeque" runat="server" Text="Photothèque" />
    </h4>
    <div class="alert alert-warning small">Pour un affichage optimum, veuillez envoyer des fichiers de 1120px de large x 420px de hauteur au format JPG.</div>
    <AIS:FileManager runat="server" ID="Filesmanage_Img" Multiple="true" ThumbImage="true" TypeFilter="image" ExtAuthorised="image/*" NameHide="true" CssUL="list-img" CssBtnDelete="btn btn-danger" />

</asp:Panel>
