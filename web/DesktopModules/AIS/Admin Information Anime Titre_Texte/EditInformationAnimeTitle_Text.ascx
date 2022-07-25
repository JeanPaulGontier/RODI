﻿<!--**********************************************************************************-->
<!-- RODI - http://rodi.aisdev.net                                                    -->
<!-- Copyright (c) 2012-2018                                                          -->
<!-- by SAS AIS : http://www.aisdev.net                                               -->
<!-- supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730) -->
<!--**********************************************************************************-->

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditInformationAnimeTitle_Text.ascx.cs" Inherits="DesktopModules_AIS_Admin_Information_Anime_Titre_Texte_EditInformationTitle_Text" %>





<%--<script src="/AIS/TextEditor/ckeditor/ckeditor.js"></script>--%>
<script src="/Providers/HtmlEditorProviders/DNNConnect.CKE/js/ckeditor/4.5.3/ckeditor.js"></script>




<asp:Panel ID="pnl_Images"  runat="server">
    <%--<script type="text/javascript">
             // Get the instance of PageRequestManager.
             var prm = Sys.WebForms.PageRequestManager.getInstance();
             // Add initializeRequest and endRequest
             prm.add_initializeRequest(prm_InitializeRequest);
             prm.add_endRequest(prm_EndRequest);
            
             // Called when async postback begins
             function prm_InitializeRequest(sender, args) {
                 // get the divImage and set it to visible
                 var panelProg = $get('divImage_Progress');                
                 panelProg.style.display = '';
                 // reset label text
                 var lbl = $get('<%= this.lblText_Progress.ClientID %>');
                 lbl.innerHTML = '';
 
                 // Disable button that caused a postback
                 $get(args._postBackElement.id).disabled = true;
             }
 
             // Called when async postback ends
             function prm_EndRequest(sender, args) {
                 // get the divImage and hide it again
                 var panelProg = $get('divImage_Progress');                
                 panelProg.style.display = 'none';
 
                 // Enable button that caused a postback
                 $get(sender._postBackSettings.sourceElement.id).disabled = false;
             }
    </script>

    

    <asp:UpdatePanel ID="upnl_Title_Text" runat="server" class="relative">
        <ContentTemplate>
        
        <asp:Label ID="lblText_Progress" runat="server" Text=""></asp:Label>
            
            <div id="divImage_Progress" style="display: none" class="progressBar">
                <asp:Image ID="img_Images" runat="server" ImageUrl="~/images/progressbar.gif" />
                <p>processing...</p>
            </div>--%>

          
            <div class="panel-body">  
                <p>
                    <asp:Label ID="lbl_Type_Anim" runat="server" Text="Sélectionner le type d'animation : " />
                    <asp:DropDownList ID="ddl_Type_Anim" runat="server" CssClass="form-control" > 
                        <asp:ListItem Value="scaleUp1" Text="scaleUp1" />
                        <asp:ListItem Value="scaleUp2" Text="scaleUp2" />
                        <asp:ListItem Value="scaleUp3" Text="scaleUp3" />
                        <asp:ListItem Value="scaleUp4" Text="scaleUp4" />
                    </asp:DropDownList>
                </p>

<script type="text/javascript">                    
    $(function() {
        $('#iconSelect').find('li').click(function () {
            var valIcon = $(this).attr('data-valIcon');
            $('#<%=hfd_Icon.ClientID %>').val(valIcon);
            $('#iconSelected').html($(this).html());
        });
    });

    function SelectIcon(valIcon) {
        $toto = $("li[data-valIcon='" + valIcon + "']");
        $('#iconSelected').html($toto.html());
    };
</script>
                <p>
                    <asp:Label ID="lbl_Type_Icon" runat="server" Text="Sélectionner l'icone : " />
                    <asp:HiddenField ID="hfd_Icon" runat="server" />
                    <div id='iconSelect' class="btn-group">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <span id="iconSelected">Icone</span> <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu">
                            <li data-valicon='fa fa-search'><a href="#"><span class='fa fa-search'></span></a></li>
                            <li data-valicon='fa fa-bell-o'><a href="#"><span class='fa fa-bell-o'></span></a></li>
                            <li data-valicon='fa fa-envelope-o'><a href="#"><span class='fa fa-envelope-o'></span></a></li>
                            <li role="separator" class="divider"></li>
                            <li data-valicon='fa fa-arrows'><a href="#"><span class='fa fa-arrows'></span></a></li>
                            <li data-valicon='fa fa-star-o'><a href="#"><span class='fa fa-star-o'></span></a></li>
                            <li data-valicon='fa fa-cog'><a href="#"><span class='fa fa-cog'></span></a></li>
                            <li data-valicon='fa fa-spinner'><a href="#"><span class='fa fa-spinner'></span></a></li>
                        </ul>
                    </div>                    
                </p>

                <p>
                    <asp:Label ID="lbl_Title" runat="server" Text="Titre de l'article : " />
                    <asp:TextBox ID="tbx_title" runat="server" CssClass="form-control" />
                </p>

                <p>
                    <asp:Label ID="lbl_Text" runat="server" Text="Texte de l'article" />
                    <asp:TextBox ID="tbx_contenu" Visible="true" TextMode="MultiLine" Width="600" Height="750" runat="server"></asp:TextBox>
                    <script> 
                        //https://ckeditor.com/latest/samples/old/toolbar/toolbar.html
                        CKEDITOR.replace('<%=tbx_contenu.ClientID%>', {
                            toolbar: [		                        
                                { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript'] },
                            { name: 'links', items: [ 'Link', 'Unlink' ] },
                                { name: 'paragraph', groups: [ 'list', 'indent', 'blocks', 'align', 'bidi' ], items: [ 'NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock' ] }
                                
	                        ],
                         uiColor: '#CCEAEE',
                         height: '10em'
                        }); 
                    </script>

                </p>
                
            </div>
                        

       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

    <asp:Button ID="btn_valid" runat="server" Text="Valider" OnClick="btn_valid_Click" CssClass="btn btn-primary" />

   

</asp:Panel>
