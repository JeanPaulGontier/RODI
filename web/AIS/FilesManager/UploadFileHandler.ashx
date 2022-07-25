<%@ WebHandler Language="C#" Class="UploadFileHandler" %>

using System;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Linq;

 public class UploadFileHandler : IHttpHandler
{

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (!string.IsNullOrEmpty(context.Request.Params["rep"]))
                {
                    string folder = "" + context.Request.Params["rep"];

                    string Serverpath = HttpContext.Current.Server.MapPath("~/" + folder);

                    if (context.Request.Files.Count > 0)
                    {

                        if (!Directory.Exists(Serverpath))
                        {
                            Directory.CreateDirectory(Serverpath);
                        }

                        HttpFileCollection files = context.Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFile file = files[i];

                            string fileName = "";

                            //In case of IE
                            if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                            {
                                string[] filesArray = file.FileName.Split(new char[] {
                                '\\'
                            });
                                fileName = filesArray[filesArray.Length - 1];
                            }
                            else // In case of other browsers
                            {
                                fileName = file.FileName;
                            }

                            string FileNameOk = Check_File_Name_Valid(fileName);

                            string fname = Serverpath + @"\" + FileNameOk;

                            if (File.Exists(fname))
                            {
                                context.Response.Write("Fichier ayant le même nom existant! ");
                                File.Delete(fname);
                                context.Response.Write("Fichier supprimé! ");
                            }

                            file.SaveAs(fname);
                            context.Response.Write("Fichier sauvegardé! ");
                        }

                        #region réponse server
                        //context.Response.AddHeader("Vary", "Accept");
                        //try
                        //{
                        //    if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                        //        context.Response.ContentType = "application/json";
                        //    else
                        //        context.Response.ContentType = "text/plain";
                        //}
                        //catch
                        //{
                        //    context.Response.ContentType = "text/plain";
                        //}


                        #endregion
                    }
                }
                else
                {
                    context.Response.Write("Pas de répertoire défini!");
                }
            }
            catch (Exception ee)
            {
                context.Response.Write("ERREUR!");
                context.Response.Write(ee.Message);
            }
        }

        /// <summary>
    /// Permet de vérifier si le nom du fichier comporte la bonne extension en fonction du type content
    /// retourne le nom de fichier avec la bonne extension
    /// ou retour NULL avec message d'erreur dans la variable out Erreur en cas de problème
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="mime"></param>
    /// <param name="Erreur"></param>
    /// <returns></returns>
    public static string Check_File_Ext_by_Mime(string filename, string mime, out string Erreur) //Liste des mime http://www.freeformatter.com/mime-types-list.html
    {
        Erreur = "";
        try
        {
            if (!string.IsNullOrEmpty(filename) && !string.IsNullOrEmpty(mime))
            {
                string[] splits = mime.ToLower().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

                if (splits.Count() == 2)
                {
                    switch (splits[0])
                    {
                        #region AUDIO
                        case "audio":
                            switch (splits[1])
                            {
                                case "basic":
                                    if (!filename.ToLower().EndsWith(".au") && !filename.ToLower().EndsWith(".snd"))
                                    {
                                        filename += ".au";
                                    }
                                    break;
                                case "L24":
                                    if (!filename.ToLower().EndsWith(".pcm"))
                                    {
                                        filename += ".pcm";
                                    }
                                    break;
                                case "mid":
                                    if (!filename.ToLower().EndsWith(".mid") && !filename.ToLower().EndsWith(".rmi"))
                                    {
                                        filename += ".mid";
                                    }
                                    break;
                                case "mpeg":
                                    if (!filename.ToLower().EndsWith(".mp3"))
                                    {
                                        filename += ".mp3";
                                    }
                                    break;
                                case "mp4":
                                    if (!filename.ToLower().EndsWith(".mp4"))
                                    {
                                        filename += ".mp4";
                                    }
                                    break;
                                case "x-aiff":
                                    if (!filename.ToLower().EndsWith(".aif") && !filename.ToLower().EndsWith(".aifc") && !filename.ToLower().EndsWith(".aiff"))
                                    {
                                        filename += ".aif";
                                    }
                                    break;
                                case "x-mpegurl":
                                    if (!filename.ToLower().EndsWith(".m3u"))
                                    {
                                        filename += ".m3u";
                                    }
                                    break;
                                case "vnd.rn-realaudio":
                                    if (!filename.ToLower().EndsWith(".ra") && !filename.ToLower().EndsWith(".ram"))
                                    {
                                        filename += ".ram";
                                    }
                                    break;
                                case "ogg":
                                    if (!filename.ToLower().EndsWith(".ogg") && !filename.ToLower().EndsWith(".oga"))
                                    {
                                        filename += ".ogg";
                                    }
                                    break;
                                case "vorbis":
                                    if (!filename.ToLower().EndsWith(".vorbis"))
                                    {
                                        filename += ".vorbis";
                                    }
                                    break;
                                case "vnd.wav":
                                    if (!filename.ToLower().EndsWith(".wav"))
                                    {
                                        filename += ".wav";
                                    }
                                    break;
                                case "x-ms-wma":
                                    if (!filename.ToLower().EndsWith(".wma"))
                                    {
                                        filename += ".wma";
                                    }
                                    break;
                                case "midi":
                                    if (!filename.ToLower().EndsWith(".mid"))
                                    {
                                        filename += ".mid";
                                    }
                                    break;
                            }
                            break;
                        #endregion AUDIO

                        #region IMAGE
                        case "image":
                            switch (splits[1])
                            {
                                case "bmp":
                                    if (!filename.ToLower().EndsWith(".bmp"))
                                    {
                                        filename += ".bmp";
                                    }
                                    break;
                                case "x-portable-graymap":
                                    if (!filename.ToLower().EndsWith(".pgm"))
                                    {
                                        filename += ".pgm";
                                    }
                                    break;
                                case "x-portable-pixmap":
                                    if (!filename.ToLower().EndsWith(".ppm"))
                                    {
                                        filename += ".ppm";
                                    }
                                    break;
                                case "g3fax":
                                    if (!filename.ToLower().EndsWith(".g3"))
                                    {
                                        filename += ".g3";
                                    }
                                    break;
                                case "cis-cod":
                                    if (!filename.ToLower().EndsWith(".cod"))
                                    {
                                        filename += ".cod";
                                    }
                                    break;
                                case "gif":
                                    if (!filename.ToLower().EndsWith(".gif"))
                                    {
                                        filename += ".gif";
                                    }
                                    break;
                                case "ief":
                                    if (!filename.ToLower().EndsWith(".ief"))
                                    {
                                        filename += ".ief";
                                    }
                                    break;
                                case "jpeg":
                                case "pjpeg":
                                case "jpg":
                                    if (!filename.ToLower().EndsWith(".jpe") && !filename.ToLower().EndsWith(".jpeg") && !filename.ToLower().EndsWith(".jpg"))
                                    {
                                        filename += ".jpg";
                                    }
                                    break;
                                case "pipeg":
                                    if (!filename.ToLower().EndsWith(".jfif"))
                                    {
                                        filename += ".jfif";
                                    }
                                    break;
                                case "svg+xml":
                                    if (!filename.ToLower().EndsWith(".svg"))
                                    {
                                        filename += ".svg";
                                    }
                                    break;
                                case "tiff":
                                    if (!filename.ToLower().EndsWith(".tiff") && !filename.ToLower().EndsWith(".tif"))
                                    {
                                        filename += ".tif";
                                    }
                                    break;
                                case "png":
                                case "x-png":
                                    if (!filename.ToLower().EndsWith(".png"))
                                    {
                                        filename += ".png";
                                    }
                                    break;
                                case "x-cmu-raster":
                                    if (!filename.ToLower().EndsWith(".ras"))
                                    {
                                        filename += ".ras";
                                    }
                                    break;
                                case "x-cmx":
                                    if (!filename.ToLower().EndsWith(".cmx"))
                                    {
                                        filename += ".cmx";
                                    }
                                    break;
                                case "x-icon":
                                case "vnd.microsoft.icon":
                                    if (!filename.ToLower().EndsWith(".ico"))
                                    {
                                        filename += ".ico";
                                    }
                                    break;
                                case "x-portable-anymap":
                                    if (!filename.ToLower().EndsWith(".pnm"))
                                    {
                                        filename += ".pnm";
                                    }
                                    break;
                                case "x-portable-bitmap":
                                    if (!filename.ToLower().EndsWith(".pbm"))
                                    {
                                        filename += ".pbm";
                                    }
                                    break;
                                case "x-rgb":
                                    if (!filename.ToLower().EndsWith(".rgb"))
                                    {
                                        filename += ".rgb";
                                    }
                                    break;
                                case "x-xbitmap":
                                    if (!filename.ToLower().EndsWith(".xbm"))
                                    {
                                        filename += ".xbm";
                                    }
                                    break;
                                case "x-xpixmap":
                                    if (!filename.ToLower().EndsWith(".xpm"))
                                    {
                                        filename += ".xpm";
                                    }
                                    break;
                                case "x-xwindowdump":
                                    if (!filename.ToLower().EndsWith(".xwd"))
                                    {
                                        filename += ".xwd";
                                    }
                                    break;
                            }
                            break;
                        #endregion IMAGE

                        #region APPLICATION
                        case "application":
                            switch (splits[1])
                            {
                                case "pdf":
                                    if (!filename.ToLower().EndsWith(".pdf"))
                                    {
                                        filename += ".pdf";
                                    }
                                    break;
                                case "xhtml+xml":
                                    if (!filename.ToLower().EndsWith(".xhtml"))
                                    {
                                        filename += ".xhtml";
                                    }
                                    break;
                                case "xml":
                                    if (!filename.ToLower().EndsWith(".xml"))
                                    {
                                        filename += ".xml";
                                    }
                                    break;
                                case "vnd.android.package-archive":
                                    if (!filename.ToLower().EndsWith(".apk"))
                                    {
                                        filename += ".apk";
                                    }
                                    break;
                                case "epub+zip":
                                    if (!filename.ToLower().EndsWith(".epub"))
                                    {
                                        filename += ".epub";
                                    }
                                    break;
                                case "x-msdownload":
                                    if (!filename.ToLower().EndsWith(".exe"))
                                    {
                                        filename += ".exe";
                                    }
                                    break;
                                case "vnd.ms-htmlhelp":
                                    if (!filename.ToLower().EndsWith(".chm"))
                                    {
                                        filename += ".chm";
                                    }
                                    break;
                                case "x-mswrite":
                                    if (!filename.ToLower().EndsWith(".wri"))
                                    {
                                        filename += ".wri";
                                    }
                                    break;
                                case "vnd.ms-works":
                                    if (!filename.ToLower().EndsWith(".wps"))
                                    {
                                        filename += ".wps";
                                    }
                                    break;
                                #region ADOBE
                                case "x-shockwave-flash":
                                    if (!filename.ToLower().EndsWith(".swf"))
                                    {
                                        filename += ".swf";
                                    }
                                    break;
                                case "vnd.adobe.fxp":
                                    if (!filename.ToLower().EndsWith(".fxp"))
                                    {
                                        filename += ".fxp";
                                    }
                                    break;
                                case "vnd.cups-ppd":
                                    if (!filename.ToLower().EndsWith(".ppd"))
                                    {
                                        filename += ".ppd";
                                    }
                                    break;
                                case "vnd.adobe.xfdf":
                                    if (!filename.ToLower().EndsWith(".xfdf"))
                                    {
                                        filename += ".xfdf";
                                    }
                                    break;
                                #endregion ADOBE
                                #region COMPRESSE
                                case "zip":
                                    if (!filename.ToLower().EndsWith(".zip"))
                                    {
                                        filename += ".zip";
                                    }
                                    break;
                                case "x-7z-compressed":
                                    if (!filename.ToLower().EndsWith(".7z"))
                                    {
                                        filename += ".7z";
                                    }
                                    break;
                                case "x-rar-compressed":
                                    if (!filename.ToLower().EndsWith(".rar"))
                                    {
                                        filename += ".rar";
                                    }
                                    break;
                                case "x-ace-compressed":
                                    if (!filename.ToLower().EndsWith(".ace"))
                                    {
                                        filename += ".ace";
                                    }
                                    break;
                                case "x-tar":
                                    if (!filename.ToLower().EndsWith(".tar"))
                                    {
                                        filename += ".tar";
                                    }
                                    break;
                                #endregion COMPRESSE
                                #region OPEN DOCUMENT
                                case "vnd.oasis.opendocument.text":
                                    if (!filename.ToLower().EndsWith(".odt"))
                                    {
                                        filename += ".odt";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.spreadsheet":
                                    if (!filename.ToLower().EndsWith(".ods"))
                                    {
                                        filename += ".ods";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.presentation":
                                    if (!filename.ToLower().EndsWith(".odp"))
                                    {
                                        filename += ".odp";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.graphics":
                                    if (!filename.ToLower().EndsWith(".odg"))
                                    {
                                        filename += ".odg";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.chart":
                                    if (!filename.ToLower().EndsWith(".odc"))
                                    {
                                        filename += ".odc";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.formula":
                                    if (!filename.ToLower().EndsWith(".odf"))
                                    {
                                        filename += ".odf";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.database":
                                    if (!filename.ToLower().EndsWith(".odb"))
                                    {
                                        filename += ".odb";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.image":
                                    if (!filename.ToLower().EndsWith(".odi"))
                                    {
                                        filename += ".odi";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.text-master":
                                    if (!filename.ToLower().EndsWith(".odm"))
                                    {
                                        filename += ".odm";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.text-template":
                                    if (!filename.ToLower().EndsWith(".ott"))
                                    {
                                        filename += ".ott";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.spreadsheet-template":
                                    if (!filename.ToLower().EndsWith(".ots"))
                                    {
                                        filename += ".ots";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.presentation-template":
                                    if (!filename.ToLower().EndsWith(".otp"))
                                    {
                                        filename += ".otp";
                                    }
                                    break;
                                case "vnd.oasis.opendocument.graphics-template":
                                    if (!filename.ToLower().EndsWith(".otg"))
                                    {
                                        filename += ".otg";
                                    }
                                    break;
                                #endregion OPEN DOCUMENT
                                #region OFFICE
                                case "msword":
                                    if (!filename.ToLower().EndsWith(".doc") && !filename.ToLower().EndsWith(".dot"))
                                    {
                                        filename += ".doc";
                                    }
                                    break;
                                case "vnd.openxmlformats-officedocument.wordprocessingml.document":
                                    if (!filename.ToLower().EndsWith(".docx"))
                                    {
                                        filename += ".docx";
                                    }
                                    break;
                                case "vnd.openxmlformats-officedocument.wordprocessingml.template":
                                    if (!filename.ToLower().EndsWith(".dotx"))
                                    {
                                        filename += ".dotx";
                                    }
                                    break;
                                case "vnd.ms-word.document.macroEnabled.12":
                                    if (!filename.ToLower().EndsWith(".docm"))
                                    {
                                        filename += ".docm";
                                    }
                                    break;
                                case "vnd.ms-word.template.macroEnabled.12":
                                    if (!filename.ToLower().EndsWith(".dotm"))
                                    {
                                        filename += ".dotm";
                                    }
                                    break;
                                case "ms-excel":
                                    if (!filename.ToLower().EndsWith(".xls") && !filename.ToLower().EndsWith(".xlt") && !filename.ToLower().EndsWith(".xla"))
                                    {
                                        filename += ".xls";
                                    }
                                    break;
                                case "vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                                    if (!filename.ToLower().EndsWith(".xlsx"))
                                    {
                                        filename += ".xlsx";
                                    }
                                    break;
                                case "vnd.openxmlformats-officedocument.spreadsheetml.template":
                                    if (!filename.ToLower().EndsWith(".xltx"))
                                    {
                                        filename += ".xltx";
                                    }
                                    break;
                                case "vnd.ms-excel.sheet.macroEnabled.12":
                                    if (!filename.ToLower().EndsWith(".xlsm"))
                                    {
                                        filename += ".xlsm";
                                    }
                                    break;
                                case "vnd.ms-excel.template.macroEnabled.12":
                                    if (!filename.ToLower().EndsWith(".xltm"))
                                    {
                                        filename += ".xltm";
                                    }
                                    break;
                                case "vnd.ms-excel.addin.macroEnabled.12":
                                    if (!filename.ToLower().EndsWith(".xlam"))
                                    {
                                        filename += ".xlam";
                                    }
                                    break;
                                case "vnd.ms-excel.sheet.binary.macroEnabled.12":
                                    if (!filename.ToLower().EndsWith(".xlsb"))
                                    {
                                        filename += ".xlsb";
                                    }
                                    break;
                                case "vnd.ms-powerpoint":
                                    if (!filename.ToLower().EndsWith(".ppt") && !filename.ToLower().EndsWith(".pot") && !filename.ToLower().EndsWith(".pps") && !filename.ToLower().EndsWith(".ppa"))
                                    {
                                        filename += ".ppt";
                                    }
                                    break;
                                case "vnd.openxmlformats-officedocument.presentationml.presentation":
                                    if (!filename.ToLower().EndsWith(".pptx"))
                                    {
                                        filename += ".pptx";
                                    }
                                    break;
                                case "vnd.openxmlformats-officedocument.presentationml.template":
                                    if (!filename.ToLower().EndsWith(".potx"))
                                    {
                                        filename += ".potx";
                                    }
                                    break;
                                case "vnd.openxmlformats-officedocument.presentationml.slideshow":
                                    if (!filename.ToLower().EndsWith(".ppsx"))
                                    {
                                        filename += ".ppsx";
                                    }
                                    break;
                                case "vnd.ms-powerpoint.addin.macroEnabled.12":
                                    if (!filename.ToLower().EndsWith(".ppam"))
                                    {
                                        filename += ".ppam";
                                    }
                                    break;
                                case "vnd.ms-powerpoint.presentation.macroEnabled.12":
                                    if (!filename.ToLower().EndsWith(".pptm"))
                                    {
                                        filename += ".pptm";
                                    }
                                    break;
                                case "vnd.ms-powerpoint.template.macroEnabled.12":
                                    if (!filename.ToLower().EndsWith(".potm"))
                                    {
                                        filename += ".potm";
                                    }
                                    break;
                                case "vnd.ms-powerpoint.slideshow.macroEnabled.12":
                                    if (!filename.ToLower().EndsWith(".ppsm"))
                                    {
                                        filename += ".ppsm";
                                    }
                                    break;
                                case "x-mspublisher":
                                    if (!filename.ToLower().EndsWith(".pub"))
                                    {
                                        filename += ".pub";
                                    }
                                    break;
                                    #endregion OFFICE
                            }
                            break;
                        #endregion APPLICATION

                        #region VIDEO
                        case "video":
                            switch (splits[1])
                            {
                                case "x-matroska":
                                    if (!filename.ToLower().EndsWith(".mkv"))
                                    {
                                        filename += ".mkv";
                                    }
                                    break;
                                case "3gpp":
                                    if (!filename.ToLower().EndsWith(".3gp"))
                                    {
                                        filename += ".3gp";
                                    }
                                    break;
                                case "3gpp2":
                                    if (!filename.ToLower().EndsWith(".3g2"))
                                    {
                                        filename += ".3g2";
                                    }
                                    break;
                                case "x-msvideo":
                                    if (!filename.ToLower().EndsWith(".avi"))
                                    {
                                        filename += ".avi";
                                    }
                                    break;
                                case "x-flv":
                                    if (!filename.ToLower().EndsWith(".flv"))
                                    {
                                        filename += ".flv";
                                    }
                                    break;
                                case "x-f4v":
                                    if (!filename.ToLower().EndsWith(".f4v"))
                                    {
                                        filename += ".f4v";
                                    }
                                    break;
                                case "h261":
                                    if (!filename.ToLower().EndsWith(".h261"))
                                    {
                                        filename += ".h261";
                                    }
                                    break;
                                case "h263":
                                    if (!filename.ToLower().EndsWith(".h263"))
                                    {
                                        filename += ".h263";
                                    }
                                    break;
                                case "h264":
                                    if (!filename.ToLower().EndsWith(".h264"))
                                    {
                                        filename += ".h264";
                                    }
                                    break;
                                case "x-ms-asf":
                                    if (!filename.ToLower().EndsWith(".asf"))
                                    {
                                        filename += ".asf";
                                    }
                                    break;
                                case "x-ms-wmv":
                                    if (!filename.ToLower().EndsWith(".wmv"))
                                    {
                                        filename += ".wmv";
                                    }
                                    break;
                                case "mpeg":
                                    if (!filename.ToLower().EndsWith(".mpeg"))
                                    {
                                        filename += ".mpeg";
                                    }
                                    break;
                                case "mp4":
                                    if (!filename.ToLower().EndsWith(".mp4"))
                                    {
                                        filename += ".mp4";
                                    }
                                    break;
                            }
                            break;
                        #endregion VIDEO

                        #region TEXTE
                        case "text":
                            switch (splits[1])
                            {
                                case "csv":
                                    if (!filename.ToLower().EndsWith(".csv"))
                                    {
                                        filename += ".csv";
                                    }
                                    break;
                                case "html":
                                    if (!filename.ToLower().EndsWith(".html"))
                                    {
                                        filename += ".html";
                                    }
                                    break;
                                case "plain":
                                    if (!filename.ToLower().EndsWith(".txt"))
                                    {
                                        filename += ".txt";
                                    }
                                    break;
                                case "x-vcard":
                                    if (!filename.ToLower().EndsWith(".vcf"))
                                    {
                                        filename += ".vcf";
                                    }
                                    break;
                                case "css":
                                    if (!filename.ToLower().EndsWith(".css"))
                                    {
                                        filename += ".css";
                                    }
                                    break;
                                case "tab-separated-values":
                                    if (!filename.ToLower().EndsWith(".tsv"))
                                    {
                                        filename += ".tsv";
                                    }
                                    break;
                            }
                            break;
                        #endregion TEXTE

                        #region MESSAGE
                        case "message":
                            switch (splits[1])
                            {
                                case "rfc822":
                                    if (!filename.ToLower().EndsWith(".eml"))
                                    {
                                        filename += ".eml";
                                    }
                                    break;
                            }
                            break;
                            #endregion MESSAGE
                    }

                    return filename;
                }
                else
                {
                    Erreur = "Erreur lors de la lecture du MIME !";
                    return null;
                }
            }
            else
            {
                Erreur = "Nom de fichier ou type MIME vide !";
                return null;
            }
        }
        catch (Exception ee)
        {
            Erreur = ee.Message;
            return null;
        }
    }

    /// <summary>
    /// Permet de vérifier la validité d'un nom de fichier et de son extension
    /// Retourne le nom de fichier s'il est correct
    /// ou retourne le nom de fichier modifié (caractères interdits remplacés par _)
    /// ou retourne null avec le message d'erreur dans la variable out
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="Erreur"></param>
    /// <returns></returns>
    public static string Check_File_Name_Valid(string filename, string content_type, out string Erreur)
    {
        Erreur = "";
        string patternStrict = @"^([A-Z]|[a-z]|[0-9]|_|-|\.|\s)$";

        try
        {
            if (!string.IsNullOrEmpty(filename) && !string.IsNullOrEmpty(content_type))
            {
                Regex emailregex = new Regex(patternStrict);
                Match match = emailregex.Match(filename);
                if (match.Success)
                {
                    string test_extension = Check_File_Ext_by_Mime(filename, content_type, out Erreur);
                    if (test_extension == null)
                    {
                        throw new Exception(Erreur);
                    }
                    else
                    {
                        return test_extension;
                    }
                }
                else
                {
                    string new_Filename = "";

                    char[] tab_char = filename.ToCharArray();
                    foreach (char c in tab_char)
                    {
                        Match match_char = emailregex.Match(c.ToString());
                        if (match_char.Success)
                        {
                            new_Filename = new_Filename + c.ToString();
                        }
                        else
                        {
                            new_Filename = new_Filename + "_";
                        }
                    }

                    string test_extension = Check_File_Ext_by_Mime(new_Filename, content_type, out Erreur);
                    if (test_extension == null)
                    {
                        throw new Exception(Erreur);
                    }
                    else
                    {
                        return test_extension;
                    }
                }
            }
            else
            {
                Erreur = "Nom de fichier ou type MIME vide !";
                return null;
            }
        }
        catch (Exception ee)
        {
            Erreur = ee.Message;
            return null;
        }
    }

    /// <summary>
    /// Permet de vérifier la validité d'un nom de fichier
    /// Retourne le nom de fichier s'il est correct
    /// ou retourne le nom de fichier modifié (caractères interdits remplacés par _)
    /// ou retourne null
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static string Check_File_Name_Valid(string filename)
    {
        string patternStrict = @"^([A-Z]|[a-z]|[0-9]|_|-|\.|\s)$";

        try
        {
            Regex emailregex = new Regex(patternStrict);
            Match match = emailregex.Match(filename);
            if (match.Success)
            {
                return filename;
            }
            else
            {
                string new_Filename = "";

                char[] tab_char = filename.ToCharArray();
                foreach (char c in tab_char)
                {
                    Match match_char = emailregex.Match(c.ToString());
                    if (match_char.Success)
                    {
                        new_Filename = new_Filename + c.ToString();
                    }
                    else
                    {
                        new_Filename = new_Filename + "_";
                    }
                }
                return new_Filename;
            }
        }
        catch (Exception ee)
        {
            return null;
        }
    }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    
}