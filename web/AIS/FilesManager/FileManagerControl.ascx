<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileManagerControl.ascx.cs" Inherits="AIS_FilesManager_FileManagerControl" %>

<asp:Panel ID="pnl_Control" runat="server">

<%--<script type="text/javascript" src="/JS/jquery-1.12.0.js"></script>
<script type="text/javascript" src="/JS/JQuery UI/jquery-ui.js"></script>
<link href="/JS/JQuery UI/jquery-ui.css" rel="stylesheet" />--%>



<script>
        $(document).ready(function () {           

            //Récupération du répertoire des fichiers
            var rep = $("#<%= hfd_path.ClientID %>").val();
            //if (rep != null & rep != '') {

            //Ajout ou pas de la selection de multiple fichiers
            var mult = $("#<%= hfd_mult.ClientID %>").val();
            if (mult == 'multiple') {
                $('#ipt_file').prop('multiple', 'multiple');
            }

            //Autoriser que certains type de fichier pour l'upload
            var extAuthorised = $("#<%= hfd_extAuthorised.ClientID %>").val();
            if (extAuthorised != null & extAuthorised != '') {
                $('#ipt_file').prop('accept', extAuthorised);
            }

            //On cache ou pas l'upload de fichier; dans la fonction refresh, on implémente ou pas le bouton delete
            var readOnly = $("#<%= hfd_readOnly.ClientID %>").val();
            if (readOnly == 'true') {
                $('#ipt_file').hide();
            }

            var thumb = $("#<%= hfd_thumb.ClientID %>").val();
            var typeFilter = $("#<%= hfd_typeFilter.ClientID %>").val();
            var extFilter = $("#<%= hfd_extFilter.ClientID %>").val();
            var nameHide = $("#<%= hfd_nameHide.ClientID %>").val();
            var cssBtnDelete = "" + $("#<%= hfd_cssBtnDelete.ClientID %>").val();
            var cssLink = "" + $("#<%= hfd_cssLink.ClientID %>").val();
            var cssThumbImage = "" + $("#<%= hfd_cssThumbImage.ClientID %>").val();
            var widthThumbImage = "" + $("#<%= hfd_widthThumbImage.ClientID %>").val();
                if (widthThumbImage == "") { widthThumbImage = "100"; }
            var heightThumbImage = "" + $("#<%= hfd_heightThumbImage.ClientID %>").val();
                if (heightThumbImage == "") { heightThumbImage = "100"; }
            var cssUL = "" + $("#<%= hfd_cssUL.ClientID %>").val();
            var cssLI = "" + $("#<%= hfd_cssLI.ClientID %>").val();
            var txt_Button = "" + $("#<%= hfd_txt_Button.ClientID %>").val();
                $('#lbl_ipt').html("" + txt_Button);
            var url_Refresh = "" + $("#<%= hfd_url_Refresh.ClientID %>").val();

            $('#imgProgress').attr('src',  window.location.origin + '/images/progressbar.gif')

            Refresh();

            function Refresh() {

                var data = new FormData();
                data.append('rep', rep);
                data.append('typeFilter', typeFilter);
                data.append('extFilter', extFilter);

                InProgress(true);

                $.ajax({
                    url: window.location.origin + "/AIS/FilesManager/GetFilesHandler.ashx",
                    type: "POST",
                    data: data,
                    contentType: false,
                    processData: false,
                    progress: function (e, data) {

                    },

                    success: function (response, status) {
                        var ul_Preview = document.getElementById("ul_files");
                        ul_Preview.className = cssUL;

                        //On nettoie le UL
                        if (ul_Preview) {
                            while (ul_Preview.firstChild) {
                                ul_Preview.removeChild(ul_Preview.firstChild);
                            }
                        }

                        //Binding
                        $.each(response, function (index) {
                            var li_preview = document.createElement("li");
                            li_preview.className = cssLI;

                            if (thumb == 'true' & response[index].mime.indexOf('image') == 0) {
                                var img = document.createElement("IMG");
                                img.height = heightThumbImage;
                                img.width = widthThumbImage;
                                img.alt = "" + response[index].alt;
                                img.src = window.location.origin + "/" + response[index].urlLink;
                                img.className = cssThumbImage;
                                li_preview.appendChild(img);
                            }

                            if (nameHide != 'true') {
                                var lbl_labelname = document.createElement("label");
                                lbl_labelname.textContent = "Nom du fichier : ";
                                li_preview.appendChild(lbl_labelname);

                                var lbl_name = document.createElement("label");
                                lbl_name.textContent = response[index].name + response[index].ext;
                                lbl_name.id = response[index].name;
                                li_preview.appendChild(lbl_name);
                            }


                            var a = document.createElement("a");
                            a.setAttribute("target", "_blank");
                            var linkText = document.createTextNode(response[index].name + response[index].ext);
                            if (response[index].title != null & response[index].title != "") {
                                var linkText = document.createTextNode(response[index].title);
                            }
                            a.appendChild(linkText);
                            a.title = response[index].name;;
                            a.href = window.location.origin + "/" + response[index].urlLink;
                            a.className = cssLink;
                            li_preview.appendChild(a);

                            if (readOnly != 'true') {
                                var btn_preview = document.createElement("BUTTON");
                                //btn_preview.textContent = "X";
                                btn_preview.setAttribute('lien', response[index].urlLink);
                                btn_preview.setAttribute('class', cssBtnDelete);
                                btn_preview.onclick = DeleteFile;

                                var spn_label = document.createElement('span');
                                spn_label.setAttribute("class", "glyphicon glyphicon-trash");
                                btn_preview.appendChild(spn_label);

                                li_preview.appendChild(btn_preview);

                                
                                

                            }

                            ul_Preview.appendChild(li_preview);

                                
                        });

                        InProgress(false);

                        if (readOnly != 'true') {
                            if (mult != 'multiple' && ul_Preview.children.length > 0) {
                                $('#<%=pnl_input.ClientID %>').hide()
                            }
                            else {
                                $('#<%=pnl_input.ClientID %>').show();
                            }
                        }
                        else {
                            $('#<%=pnl_input.ClientID %>').hide();
                        };

                    },

                    error: function (err) {
                        alert('Problème lors de la récupération!');

                        console.log('error', error);

                        InProgress(false);
                    }
                });
            };

            function InProgress(start) {
                if (start == true) {
                    $('#progressbar').show();
                    $('#ipt_file').hide();
                }
                else {
                    $('#progressbar').hide();
                    $('#ipt_file').show();
                }
            }

            function  RefreshPage() {
                window.location = url_Refresh;
            }

            $("#ipt_file").on("change", UpdateInput);

            function DeleteFile(evt, obj) {
                if (confirm("Etes-vous sûr de vouloir supprimer ce fichier?")) {
                    var lien = $(this).attr('lien');
                    var jsonData = {
                        'path': rep,
                        'urlLink': lien
                    }
                    jsonData = JSON.stringify(jsonData);

                    InProgress(true);

                    $.ajax({
                        url: window.location.origin + "/AIS/FilesManager/DeleteFileHandler.ashx",
                        type: "POST",
                        data: jsonData,
                        success: function (response, status) {
                            //console.log('success', response);

                            InProgress(false);
                            //Refresh();                            
                            RefreshPage();
                        },
                        error: function (error) {
                            alert('Problème lors de la suppression!');

                            console.log('error', error);

                            InProgress(false);
                        }
                    });//End Ajax

                    evt.preventDefault();
                }//End IF
            };

            function UpdateInput(evt, obj) {
                //Récupération des fichiers sélectionnés
                var fileUpload = $("#ipt_file").get(0);
                var files = fileUpload.files;

                //var ext = $("#ipt_file").val().split('.').pop().toLowerCase();
                //if ($.inArray(ext, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
                //    alert('invalid extension!');
                //}
                //var erreur = ValidFiles();

                //if (erreur == false) {
                var data = new FormData();
                for (var i = 0; i < files.length; i++) {
                    data.append(files[i].name, files[i]);
                }
                data.append('rep', rep);

                InProgress(true);

                $.ajax({
                    url: window.location.origin + "/AIS/FilesManager/UploadFileHandler.ashx",
                    async : true,
                    type: "POST",
                    data: data,
                    contentType: false,
                    processData: false,
                    //progress: function (e, data) {
                    //    var progress = parseInt(data.loaded / data.total * 100, 10);
                    //    $('#myBar div').css('width:', progress + '%');
                    //},

                    //xhr: function () {
                    //    var xhr = new window.XMLHttpRequest();
                    //    //Download progress
                    //    xhr.addEventListener("progress", function (evt) {
                    //        if (evt.lengthComputable) {
                    //            var percentComplete = evt.loaded / evt.total;
                    //            $('#myBar div').css('width:', (Math.round(percentComplete * 100) + "%"));
                    //            console.log("progression : " + (Math.round(percentComplete * 100) + "%"));
                    //        }
                                
                    //    }, false);
                    //    return xhr;
                    //},

                    success: function (response, status) {
                        InProgress(false);
                        RefreshPage();
                        <%--Refresh();                        
                        
                        var mult = $("#<%= hfd_mult.ClientID %>").val();
                        if (mult != 'multiple')
                        {
                            $('#ipt_file').hide();
                        }--%>

                        //console.log('success', response);
                    },

                    error: function (error) {
                        alert('Problème lors du téléchargement!');

                        console.log('error', error);

                        InProgress(false);
                        //$('#ipt_file').show();
                        //$('#progressbar').hide();
                        //$('#myBar  div').css('width:', '0%');
                        Refresh();
                    }


                });
                
            }
            //}
            //else {
            //        $('#ipt_file').hide();
            //        $('#progressbar').hide();
            //        alert('Auncun répertoire défini! ');
            //}
    });


</script>


<asp:HiddenField runat="server" ID="hfd_path" />
<asp:HiddenField runat="server" ID="hfd_mult" />
<asp:HiddenField runat="server" ID="hfd_thumb" />
<asp:HiddenField runat="server" ID="hfd_typeFilter" />
<asp:HiddenField runat="server" ID="hfd_extFilter" />
<asp:HiddenField runat="server" ID="hfd_extAuthorised" />
<asp:HiddenField runat="server" ID="hfd_readOnly" />
<asp:HiddenField runat="server" ID="hfd_nameHide" />
<asp:HiddenField runat="server" ID="hfd_cssBtnDelete" />
<asp:HiddenField runat="server" ID="hfd_cssLink" />
<asp:HiddenField runat="server" ID="hfd_cssThumbImage" />
<asp:HiddenField runat="server" ID="hfd_widthThumbImage" />
<asp:HiddenField runat="server" ID="hfd_heightThumbImage" />
<asp:HiddenField runat="server" ID="hfd_cssUL" />
<asp:HiddenField runat="server" ID="hfd_cssLI" />
<asp:HiddenField runat="server" ID="hfd_txt_Button" />
<asp:HiddenField runat="server" ID="hfd_url_Refresh" />



    <div id="dv_ul_files">
        
            <ul id="ul_files">
            </ul>
        

        <div class="text-center">
            <asp:Panel ID="pnl_input" runat="server">                
                <Label id="lbl_ipt" for="ipt_file" class="btn btn-primary" > </Label>
                <input type="file" id="ipt_file" name="ipt_file" style="visibility: hidden;"  />
            </asp:Panel>
        </div>
    </div>


    <div id="progressbar" class="progress" style="display: none;">
        <div id="myBar" >
       <%-- <div id="myBar" class="progress-bar progress-bar-success" role="progressbar" aria-valuemin="0" aria-valuemax="100">--%>
            <img id="imgProgress" src="" alt="In progress">            
        </div>
    </div>

</asp:Panel>
