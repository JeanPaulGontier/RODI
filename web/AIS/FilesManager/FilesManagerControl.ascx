<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FilesManagerControl.ascx.cs" Inherits="AIS_FilesManager_FilesManagerControl" %>


    <script type="text/javascript" src="/JS/jquery-1.12.0.js"></script>
    <script type="text/javascript" src="/JS/JQuery UI/jquery-ui.js"></script>
    <link href="/JS/JQuery UI/jquery-ui.css" rel="stylesheet" />



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

                Refresh();

                function Refresh() {

                    var data = new FormData();
                    data.append('rep', rep);
                    data.append('typeFilter', typeFilter);
                    data.append('extFilter', extFilter);

                    $.ajax({
                        url: "AIS/FilesManager/GetFilesHandler.ashx",
                        type: "POST",
                        data: data,
                        contentType: false,
                        processData: false,
                        progress: function (e, data) {

                        },

                        success: function (response, status) {
                            var ul_Preview = document.getElementById("ul_files");

                            //On nettoie le UL
                            if (ul_Preview) {
                                while (ul_Preview.firstChild) {
                                    ul_Preview.removeChild(ul_Preview.firstChild);
                                }
                            }

                            //Binding
                            $.each(response, function (index) {
                                var li_preview = document.createElement("li");

                                if (thumb == 'true' & response[index].mime.indexOf('image') == 0) {
                                    var img = document.createElement("IMG");
                                    img.height = "100";
                                    img.width = "100";
                                    img.alt = "" + response[index].alt;
                                    img.src = response[index].urlLink;
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
                                var linkText = document.createTextNode(response[index].name);
                                if (response[index].title != null & response[index].title != "") {
                                    var linkText = document.createTextNode(response[index].title);
                                }
                                a.appendChild(linkText);
                                a.title = response[index].name;;
                                a.href = response[index].urlLink;
                                li_preview.appendChild(a);

                                if (readOnly != 'true') {
                                    var btn_preview = document.createElement("BUTTON");
                                    btn_preview.textContent = "X";
                                    btn_preview.setAttribute('lien', response[index].urlLink);
                                    btn_preview.onclick = DeleteFile;
                                    li_preview.appendChild(btn_preview);
                                }

                                ul_Preview.appendChild(li_preview);
                            });
                        },

                        error: function (err) {
                        }
                    });
                };

                $("#ipt_file").on("change", UpdateInput);

                function DeleteFile(evt, obj) {
                    if (confirm("Etes-vous sûr de vouloir supprimer ce fichier?")) {
                        var lien = $(this).attr('lien');
                        var jsonData = {
                            'path': rep,
                            'urlLink': lien
                        }
                        jsonData = JSON.stringify(jsonData);

                        $.ajax({
                            url: "AIS/FilesManager/DeleteFileHandler.ashx",
                            type: "POST",
                            data: jsonData,
                            success: function (response, status) {
                                console.log('success', response);
                                Refresh();
                            },
                            error: function (error) {
                                console.log('error', error);
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

                    $('#progressbar').show();

                    $.ajax({
                        url: "AIS/FilesManager/UploadFileHandler.ashx",
                        type: "POST",
                        data: data,
                        contentType: false,
                        processData: false,
                        progress: function (e, data) {
                            var progress = parseInt(data.loaded / data.total * 100, 10);
                            $('#progressbar div').css('width', progress + '%');
                        },

                        success: function (response, status) {
                            $('#progressbar').hide();
                            $('#progressbar div').css('width', '0%');
                            Refresh();
                            console.log('success', response);
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


    <form id="form1" runat="server">

        <asp:HiddenField runat="server" ID="hfd_path" />
        <asp:HiddenField runat="server" ID="hfd_mult" />
        <asp:HiddenField runat="server" ID="hfd_thumb" />
        <asp:HiddenField runat="server" ID="hfd_typeFilter" />
        <asp:HiddenField runat="server" ID="hfd_extFilter" />
        <asp:HiddenField runat="server" ID="hfd_extAuthorised" /> 
        <asp:HiddenField runat="server" ID="hfd_readOnly" /> 
        <asp:HiddenField runat="server" ID="hfd_nameHide" /> 
            
       
        <div id="dv_ul_files">
            <ul id="ul_files" >
            </ul>       
                        
            <div>
                <input type="file" id="ipt_file" name="ipt_file" style="color:transparent;" />
            </div>
        </div>
            

        <div id="progressbar" style="width:100px; display:none;">
            Progression
        </div>

    </form>

