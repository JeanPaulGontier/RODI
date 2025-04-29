
#region Copyrights

//
// RODI - https://rodi-platform.org
// Copyright (c) 2012-2023
// by SAS AIS : http://www.aisdev.net
// supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730)
//
//GNU LESSER GENERAL PUBLIC LICENSE
//Version 3, 29 June 2007 Copyright (C) 2007
//Free Software Foundation, Inc. <http://fsf.org/> Everyone is permitted to copy and distribute verbatim copies of this license document, but changing it is not allowed.
//This version of the GNU Lesser General Public License incorporates the terms and conditions of version 3 of the GNU General Public License, supplemented by the additional permissions listed below.

//0. Additional Definitions.

//As used herein, "this License" refers to version 3 of the GNU Lesser General Public License, and the "GNU GPL" refers to version 3 of the GNU General Public License.
//"The Library" refers to a covered work governed by this License, other than an Application or a Combined Work as defined below.
//An "Application" is any work that makes use of an interface provided by the Library, but which is not otherwise based on the Library.Defining a subclass of a class defined by the Library is deemed a mode of using an interface provided by the Library.
//A "Combined Work" is a work produced by combining or linking an Application with the Library. The particular version of the Library with which the Combined Work was made is also called the "Linked Version".
//The "Minimal Corresponding Source" for a Combined Work means the Corresponding Source for the Combined Work, excluding any source code for portions of the Combined Work that, considered in isolation, are based on the Application, and not on the Linked Version.
//The "Corresponding Application Code" for a Combined Work means the object code and/or source code for the Application, including any data and utility programs needed for reproducing the Combined Work from the Application, but excluding the System Libraries of the Combined Work.

//1. Exception to Section 3 of the GNU GPL.

//You may convey a covered work under sections 3 and 4 of this License without being bound by section 3 of the GNU GPL.

//2. Conveying Modified Versions.

//If you modify a copy of the Library, and, in your modifications, a facility refers to a function or data to be supplied by an Application that uses the facility (other than as an argument passed when the facility is invoked), then you may convey a copy of the modified version:
//a) under this License, provided that you make a good faith effort to ensure that, in the event an Application does not supply the function or data, the facility still operates, and performs whatever part of its purpose remains meaningful, or
//b) under the GNU GPL, with none of the additional permissions of this License applicable to that copy.

//3. Object Code Incorporating Material from Library Header Files.

//The object code form of an Application may incorporate material from a header file that is part of the Library. You may convey such object code under terms of your choice, provided that, if the incorporated material is not limited to numerical parameters, data structure layouts and accessors, or small macros, inline functions and templates(ten or fewer lines in length), you do both of the following:
//a) Give prominent notice with each copy of the object code that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the object code with a copy of the GNU GPL and this license document.

//4. Combined Works.

//You may convey a Combined Work under terms of your choice that, taken together, effectively do not restrict modification of the portions of the Library contained in the Combined Work and reverse engineering for debugging such modifications, if you also do each of the following:
//a) Give prominent notice with each copy of the Combined Work that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the Combined Work with a copy of the GNU GPL and this license document.
//c) For a Combined Work that displays copyright notices during execution, include the copyright notice for the Library among these notices, as well as a reference directing the user to the copies of the GNU GPL and this license document.
//d) Do one of the following:
//0) Convey the Minimal Corresponding Source under the terms of this License, and the Corresponding Application Code in a form suitable for, and under terms that permit, the user to recombine or relink the Application with a modified version of the Linked Version to produce a modified Combined Work, in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.
//1) Use a suitable shared library mechanism for linking with the Library. A suitable mechanism is one that (a) uses at run time a copy of the Library already present on the user's computer system, and (b) will operate properly with a modified version of the Library that is interface-compatible with the Linked Version.
//e) Provide Installation Information, but only if you would otherwise be required to provide such information under section 6 of the GNU GPL, and only to the extent that such information is necessary to install and execute a modified version of the Combined Work produced by recombining or relinking the Application with a modified version of the Linked Version. (If you use option 4d0, the Installation Information must accompany the Minimal Corresponding Source and Corresponding Application Code. If you use option 4d1, you must provide the Installation Information in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.)

//5. Combined Libraries.

//You may place library facilities that are a work based on the Library side by side in a single library together with other library facilities that are not Applications and are not covered by this License, and convey such a combined library under terms of your choice, if you do both of the following:
//a) Accompany the combined library with a copy of the same work based on the Library, uncombined with any other library facilities, conveyed under the terms of this License.
//b) Give prominent notice with the combined library that part of it is a work based on the Library, and explaining where to find the accompanying uncombined form of the same work.

//6. Revised Versions of the GNU Lesser General Public License.

//The Free Software Foundation may publish revised and/or new versions of the GNU Lesser General Public License from time to time. Such new versions will be similar in spirit to the present version, but may differ in detail to address new problems or concerns.
//Each version is given a distinguishing version number. If the Library as you received it specifies that a certain numbered version of the GNU Lesser General Public License "or any later version" applies to it, you have the option of following the terms and conditions either of that published version or of any later version published by the Free Software Foundation. If the Library as you received it does not specify a version number of the GNU Lesser General Public License, you may choose any version of the GNU Lesser General Public License ever published by the Free Software Foundation.
//If the Library as you received it specifies that a proxy can decide whether future versions of the GNU Lesser General Public License shall apply, that proxy's public statement of acceptance of any version is permanent authorization for you to choose that version for the Library.

#endregion Copyrights


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Log.EventLog;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Xml.Serialization;
using DotNetNuke.Services.Mail;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Users;
using System.Web;
using DotNetNuke.Entities.Tabs;
using Aspose.Pdf.Facades;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

using Lucene.Net.Analysis;
using SmarterMailSchedule;
//using Org.BouncyCastle.Asn1.Ocsp;
//using System.Web.Http;
//using System.Activities.Expressions;
//using System.ServiceModel.Activities;
//using Microsoft.VisualBasic.Activities;

namespace AIS
{
    public static class Functions
    {
        public static TextBox getTextBox(string name, ControlCollection controls)
        {
            name = name.ToLower();
            foreach (Control ctrl in controls)
            {
                if (ctrl.Controls.Count > 0)
                {
                    Control ret = getTextBox(name, ctrl.Controls);
                    if (ret != null)
                    {
                        return (TextBox)ret;
                    }
                }
                else
                {
                    if (ctrl.GetType().Name.Equals("TextBox"))
                    {
                        if (ctrl.ID.ToLower().Equals(name))
                        {
                            return (TextBox)ctrl;
                        }
                    }
                }
            }
            return null;
        }
        public static RadioButtonList getRadioButtonList(string name, ControlCollection controls)
        {
            name = name.ToLower();
            foreach (Control ctrl in controls)
            {
                if (ctrl.Controls.Count > 0)
                {
                    Control ret = getRadioButtonList(name, ctrl.Controls);
                    if (ret != null)
                    {
                        return (RadioButtonList)ret;
                    }
                }
                else
                {
                    if (ctrl is RadioButtonList)
                    {
                        if (ctrl.ID.ToLower().Equals(name))
                        {
                            return (RadioButtonList)ctrl;
                        }
                    }
                }
            }
            return null;
        }
        public static DropDownList getDropDownList(string name, ControlCollection controls)
        {
            name = name.ToLower();
            foreach (Control ctrl in controls)
            {
                if (ctrl.Controls.Count > 0)
                {
                    Control ret = getDropDownList(name, ctrl.Controls);
                    if (ret != null)
                    {
                        return (DropDownList)ret;
                    }
                }
                else
                {
                    if (ctrl.GetType().Name.Equals("DropDownList"))
                    {
                        if (ctrl.ID.ToLower().Equals(name))
                        {
                            return (DropDownList)ctrl;
                        }
                    }
                }
            }
            return null;
        }

        public static void MessageBoxShow(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            page.ClientScript.RegisterStartupScript(owner.GetType(),
                "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
                message));
        }

        /// <summary>
        /// Get a list of items using the tabid
        /// </summary>
        /// <param name="selectedtabid"></param>
        /// <returns></returns>
        public static List<ListItem> GetListItemsFromTabs(int selectedtabid)
        {
            List<ListItem> liste = new List<ListItem>();
            List<TabInfo> tabs = TabController.GetPortalTabs(Globals.GetPortalSettings().PortalId, 0, false, null, true, false, true, false, false);

            foreach (TabInfo t in tabs)
            {
                ListItem li = new ListItem();
                li.Text = (new String('.', 3 * t.Level)) + t.TabName;
                li.Value = "" + t.TabID;
                if (t.TabID == selectedtabid)
                    li.Selected = true;

                liste.Add(li);
            }
            return liste;
        }

        public static string GetMimeType(string extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException("extension");
            }

            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            string mime;

            return _mappings.TryGetValue(extension, out mime) ? mime : "application/octet-stream";
        }


        /// <summary>
        /// Get the rotary year
        /// </summary>
        /// <returns></returns>
        public static int GetRotaryYear()
        {
            int annee = DateTime.Now.Year;
            if (DateTime.Now < new DateTime(annee, 7, 1))
                annee--;
            return annee;
        }

        /// <summary>
        /// Get the member
        /// </summary>
        /// <returns></returns>
        public static Member GetCurrentMember()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return DataMapping.GetMemberByUserID(Globals.GetPortalSettings().UserInfo.UserID);
            }
            return null;
        }

        

        /// <summary>
        /// Get the user club
        /// </summary>
        public static Club CurrentClub
        {
            get
            {
                Member member = GetCurrentMember();
                if (member != null)
                {
                    if ((   !DataMapping.IsMemberInRole(member.id, Const.ROLE_ADMIN_DISTRICT) && 
                            !DataMapping.IsMemberInRole(member.id, Const.ADMIN_ROLE) && 
                            !DataMapping.IsMemberInRole(member.id, Const.ROLE_ADMIN_ROTARACT) && 
                            !DataMapping.isADG(member.id) && 
                            !DataMapping.IsMemberInRole(member.id, Const.ROLE_FORMATEUR_CLUBS))
                       || HttpContext.Current.Session["Club"] == null)
                    {
                        Club club = DataMapping.GetClub(member.cric);
                        HttpContext.Current.Session["Club"] = club;
                    }
                }
                return HttpContext.Current.Session["Club"] as Club;
            }
            set
            {
                HttpContext.Current.Session["Club"] = value;
            }
        }

        /// <summary>
        /// Get cric of satellite club from parent cric
        /// </summary>
        /// <param name="cric"></param>
        /// <returns>Satellite CRIC (0, if no sat or CLUB_SATELLITE_APART is false </returns>
        public static int GetSatelliteCricFromParentClub(int cric)
        {
            if(!Const.CLUB_SATELLITE_APART && Const.CLUB_SATELLITE_PARENT_CHILD.Length==0)
                return 0;

            var cpc = Const.CLUB_SATELLITE_PARENT_CHILD;
            for (int i = 0; i < cpc.GetLength(0); i++)
            {
                if (cpc[i,0]==cric)
                {
                    return cpc[i,1];
                }
            }
            return 0;
        }

        /// <summary>
        /// Get cric of parent club from satellite cric
        /// </summary>
        /// <param name="cric"></param>
        /// <returns>Satellite CRIC (0, if no sat or CLUB_SATELLITE_APART is false </returns>
        public static int GetParentCricFromSatelliteClub(int cric)
        {
            if (!Const.CLUB_SATELLITE_APART && Const.CLUB_SATELLITE_PARENT_CHILD.Length == 0)
                return 0;

            var cpc = Const.CLUB_SATELLITE_PARENT_CHILD;
            for (int i = 0; i < cpc.GetLength(0); i++)
            {
                if (cpc[i,1] == cric)
                {
                    return cpc[i, 0];
                }
            }
            return 0;
        }

        /// <summary>
        /// Get the cric of the user club
        /// </summary>
        public static int CurrentCric
        {
            get
            {
                int cric = 0;
                if (Functions.CurrentClub != null)
                    cric = Functions.CurrentClub.cric;
                return cric;
            }
        }

        public static string RemoveAccents(string c)
        {
            return new Regex(@"\p{Mn}", RegexOptions.Compiled).Replace(c.Normalize(NormalizationForm.FormD), String.Empty);
        }

        /// <summary>
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ClearFileName(string filename)
        {
            filename = RemoveAccents(filename).ToLower();
            filename = filename.Replace(" ", "-");
            filename = filename.Replace("'", "-");
            filename = filename.Replace("?", "");
            filename = filename.Replace("&", "");
            filename = filename.Replace("!", "");
            filename = filename.Replace("*", "");
            filename = filename.Replace(">", "");
            filename = filename.Replace("<", "");
            filename = MakeValidFileName(filename);
            filename = RemoveDiacritics(filename);
            return filename;
        }
        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
        public static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }

        public static string GetSEO(string nom)
        {
            nom = RemoveAccents(nom);
            nom = nom.ToLower();
            nom = nom.Replace(" ", "-");
            nom = nom.Replace("'", "-");
            nom = nom.Replace("?", "");
            nom = nom.Replace("&", "");
            nom = nom.Replace("!", "");
            nom = nom.Replace("*", "");
            nom = nom.Replace(".", "");
            nom = nom.Replace(">", "");
            nom = nom.Replace("<", "");
            //nom = nom.Replace("é", "e");
            //nom = nom.Replace("è", "e");
            //nom = nom.Replace("à", "a");
            //nom = nom.Replace("û", "u");
            //nom = nom.Replace("ù", "u");
            //nom = nom.Replace("ô", "o");
            //nom = nom.Replace("'", "-");
            nom = nom.Replace("\\", "-");
            nom = nom.Replace("/", "sur");
            nom = nom.Replace("\"", "-");
            string[] mots = nom.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            nom = "";
            foreach (string m in mots)
            {
                if (m.Length > 0)
                    nom += m.Substring(0, 1).ToUpper();
                if (m.Length > 1)
                    nom += m.Substring(1).ToLower();
                nom += "-";
            }
            if (nom.EndsWith("-"))
                nom = nom.Substring(0, nom.Length - 1);
            return nom;
        }
        public static string YESNO2UF(string yesno)
        {
            if (yesno == Const.YES)
                return Const.YES_UF;
            if (yesno == Const.NO)
                return Const.NO_UF;
            return "";
        }
        public static Bitmap Thumb(Bitmap bmp, int newWidth, int newHeight)
        {
            Bitmap bmpOut = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bmpOut);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
            g.DrawImage(bmp, 0, 0, newWidth, newHeight);
            return bmpOut;
        }
        public static Bitmap ThumbByWidth(Bitmap bmp, int width)
        {
            double ratio = (double)bmp.Height / (double)bmp.Width;

            int newWidth = width;
            int newHeight = (int)(width * ratio);

            bmp = AIS.Functions.Thumb(bmp, newWidth, newHeight);
            return bmp;
        }

        public static string UrlAddParam(string url, string param, string valeur)
        {
            string ur = url;
            if (ur.IndexOf("?") > -1)
            {
                string[] prms = ur.Substring(ur.IndexOf("?") + 1).Split('&');
                ur = ur.Substring(0, url.IndexOf("?") + 1);
                foreach (string s in prms)
                {
                    if (!s.StartsWith(param)) // supprime l'eventuelle presence du meme param
                        ur += s + "&";
                }
                ur += param + "=" + valeur;
            }
            else
                ur += "?" + param + "=" + valeur;


            return ur;
        }

        /// <summary>
        /// Get the culture
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentCulture()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.Name;
        }
        public static void SendMail(string email, string subject, string body)
        {
            try
            {
                SendMail("", email, subject, body);
            }
            catch (Exception ee)
            {
                Error(ee);
            }
        }
        public static void SendMail(string from, string email, string subject, string body, string sendername="")
        {
            try
            {
                PortalSettings ps = Globals.GetPortalSettings();
                string[] att = new string[0];
                Yemon.dnn.Functions.SendMail("",email,subject,body,new List<System.Net.Mail.Attachment>(),from,sendername);  
            }
            catch (Exception ee)
            {
                Error(ee);
            }
        }
        public static UserInfo GetProvider(int PortalId, int UserID)
        {
            return UserController.GetUserById(PortalId, UserID);
        }
        public static string GetCorrectUrl(string url)
        {
            url = url.ToLower();
            if (url.StartsWith("http://"))
                return url;
            if (url.StartsWith("https://"))
                return url;
            return "https://" + url;
        }

        public static string GetCurrentUrlWithoutParms()
        {
            var httpContext = System.Web.HttpContext.Current;
            string url = httpContext.Request.RawUrl.IndexOf("?")>-1? httpContext.Request.RawUrl.Substring(0, httpContext.Request.RawUrl.IndexOf("?")) : httpContext.Request.RawUrl;
            string host = httpContext.Request.Url.AbsoluteUri.Replace(httpContext.Request.Url.PathAndQuery, "");
            return host+url;
            
        }
        /// <summary>
        /// Send exception detail into DNN's event log
        /// </summary>
        /// <param name="e"></param>
        public static void Error(Exception e)
        {
            EventLogController eventLog = new EventLogController();
            LogInfo logInfo = new LogInfo();

            logInfo.LogUserID = -1;
            logInfo.LogPortalID = Globals.GetPortalSettings().PortalId;
            logInfo.LogTypeKey = EventLogController.EventLogType.HOST_ALERT.ToString();
            logInfo.AddProperty("Source de l'erreur", e.Source);
            logInfo.AddProperty("Message d'erreur", e.Message);
            logInfo.AddProperty("Pile d'appel", e.StackTrace);
            logInfo.AddProperty("Erreur complète", e.ToString());

            eventLog.AddLog(logInfo);
            var error = new Error(e.Source, "" + e.InnerException, Environment.StackTrace, e.Message,e.ToString());
            DataMapping.Log("error","",Yemon.dnn.Functions.Serialize(error),Globals.GetPortalSettings().UserId);
        }

        public static void Log(Exception e,EventLogController.EventLogType logtype)
        {
            EventLogController eventLog = new EventLogController();
            LogInfo logInfo = new LogInfo();

            logInfo.LogUserID = -1;
            logInfo.LogPortalID = Globals.GetPortalSettings().PortalId;
            logInfo.LogTypeKey = logtype.ToString();
            logInfo.AddProperty("Source", e.Source);
            logInfo.AddProperty("Message", e.Message);
            logInfo.AddProperty("Pile d'appel", e.StackTrace);
            logInfo.AddProperty("Erreur complète", e.ToString());

            eventLog.AddLog(logInfo);

            var error = new Error(e.Source, "" + e.InnerException, Environment.StackTrace, e.Message, e.ToString());
            DataMapping.Log("error", "", Yemon.dnn.Functions.Serialize(error), Globals.GetPortalSettings().UserId);
        }


        public static Bitmap GetBitmapFromMedia(Media media)
        {
            Bitmap bmp = new Bitmap(1, 1);
            try
            {

                MemoryStream ms = new MemoryStream(media.content);

                DataMapping.InitLicenceAsposePdf();

                PdfConverter objConverter = new PdfConverter();
                objConverter.BindPdf(ms);
                objConverter.DoConvert();

                if (objConverter.HasNextImage())
                {
                    //read image into memory stream
                    MemoryStream memoryStream = new MemoryStream();
                    objConverter.GetNextImage(memoryStream);


                    bmp = new Bitmap(memoryStream);
                }
                objConverter.Close();

            }
            catch (Exception ee)
            {
                Error(ee);
            }
            return bmp;
        }

        public static String BytesToString(byte[] bytes)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(bytes);
        }
        public static byte[] StringToBytes(string chaine)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(chaine);
        }
        public static Object Deserialize(String str, Type t)
        {

            XmlSerializer serializer = new XmlSerializer(t);
            StringReader reader = new StringReader(str);

            Object obj = serializer.Deserialize(reader);
            return obj;

        }
        public static String Serialize(Object Obj)
        {
            XmlSerializer serializer = new XmlSerializer(Obj.GetType());

            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            serializer.Serialize(writer, Obj, namespaces);
            writer.Close();
            writer.Dispose();
            return sb.ToString();
        }
        public static T DeepCopy<T>(T obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                memoryStream.Position = 0;
                return (T)formatter.Deserialize(memoryStream);
            }
        }
        public static string CalculateMD5Hash(byte[] inputBytes)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static bool UseBinarySerialization = true;
        public static byte[] Decompress(byte[] gzip)
        {
            if (gzip == null)
                return null;
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }
        public static Object DeserialiseFromBytes(byte[] bytes, Type t)
        {
            if (UseBinarySerialization)
            {
                BinaryFormatter b = new BinaryFormatter();
                MemoryStream m = new MemoryStream(Decompress(bytes));
                Object o = b.Deserialize(m);
                return o;

            }
            else
            {
                string serialise = BytesToString(Decompress(bytes));
                return Deserialize(serialise, t);
            }

        }
        public static byte[] SerializeToBytes(Object Obj)
        {
            if (UseBinarySerialization)
            {
                MemoryStream m = new MemoryStream();
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(m, Obj);
                byte[] ba = m.ToArray();
                m.Close();
                return Compress(ba);
            }
            else
            {
                string ret = Serialize(Obj);
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                return Compress(encoding.GetBytes(ret));
            }
        }
        public static byte[] Compress(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream();

            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(bytes, 0, bytes.Length);
            }

            return ms.ToArray();
        }

        public static string ToTitleCase(string t)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(t);
        }

        /// <summary>
        /// Check if the file's name and extension are valid
        /// Return file's name if correct
        /// or return file's edited name (forbidden caracters replaced with _)
        /// or return null with error message
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
                Functions.Error(ee);
                Erreur = ee.Message;
                return null;
            }
        }

        /// <summary>
        /// Check if the file's name contains the right extension according to the content type
        /// return the file's name with the right extension
        /// or return NULL with an error message 
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
                Functions.Error(ee);
                Erreur = ee.Message;
                return null;
            }
        }



        public static bool UpdateSEOClubs(System.Web.HttpContext httpContext)
        {
            string[] lines;
            StringBuilder zonesb = new StringBuilder();
            StringBuilder redirsb = new StringBuilder();
            StringBuilder iisbindings = new StringBuilder();

            string domain = Const.DISTRICT_URL.Replace("https://", "").Replace("www", "");
            string host = Const.DISTRICT_URL.Replace("https://", "");
            zonesb.Append("; fichier zone pour " + domain + Environment.NewLine);
            redirsb.Append("# redirections clubs " + domain + Environment.NewLine);
            iisbindings.Append("<!-- fichier dans lequel copier les bindings sur le site correspondant : C:\\Windows\\System32\\inetsrv\\config\\applicationHost.config -->" + Environment.NewLine);
            

            SqlConnection conn = new SqlConnection(Config.GetConnectionString());
            try
            {

                conn.Open();

                SqlCommand sql = new SqlCommand("SELECT * FROM ais_clubs", conn);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                da.Fill(ds);

                lines = new string[ds.Tables[0].Rows.Count];
                int i = 0;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string nom = "" + row["name"];
                    nom = GetSEO(nom).ToLower();
                    string cric = "" + row["cric"];
                    string seo_mode = "" + row["seo_mode"];
                    string domaine = "" + row["domaine"];

                    sql = new SqlCommand("UPDATE ais_clubs SET seo=@seo WHERE cric=@cric", conn);
                    sql.Parameters.AddWithValue("seo", nom);
                    sql.Parameters.AddWithValue("cric", cric);
                    sql.ExecuteNonQuery();
                    lines[i] = nom + ","+seo_mode+","+domaine;

                    //TXT_Result.Text += TXT_Result.Text + nom + "<br/>";

                    zonesb.Append(nom + "\tCNAME\t" + host + "." + Environment.NewLine);
                    redirsb.Append(nom +  domain + " " + Const.DISTRICT_URL + "/" + nom + "/ 301" + Environment.NewLine);
                    iisbindings.Append("<binding protocol=\"http\" bindingInformation=\"*:80:"+ nom + domain + "\" />" + Environment.NewLine);

                    string chemin = httpContext.Server.MapPath("/Portals/0/Clubs/" + nom);
                    try
                    {
                        Directory.CreateDirectory(chemin);
                    }
                    catch
                    {
                    }
                    try
                    {
                        Directory.CreateDirectory(chemin + "/Documents");
                    }
                    catch
                    {
                    }
                    try
                    {
                        Directory.CreateDirectory(chemin + "/Images");
                    }
                    catch
                    {
                    }

                    i++;
                }
                httpContext.Application["ClubsSEO"] = null;
                System.IO.File.WriteAllLines(httpContext.Server.MapPath("/listeSEO.txt"), lines);
                System.IO.File.WriteAllText(httpContext.Server.MapPath("/zonesclubs.dns"), zonesb.ToString());
                System.IO.File.WriteAllText(httpContext.Server.MapPath("/redirclubs.txt"), redirsb.ToString());
                System.IO.File.WriteAllText(httpContext.Server.MapPath("/iisbindings.txt"), iisbindings.ToString());
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return false;
            }
            finally
            {
                conn.Close();

            }

            return true;
        }


        private static IDictionary<string, string> _mappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) {
  
            #region Big freaking list of mime types
    // combination of values from Windows 7 Registry and 
    // from C:\Windows\System32\inetsrv\config\applicationHost.config
    // some added, including .7z and .dat
    {".323", "text/h323"},
    {".3g2", "video/3gpp2"},
    {".3gp", "video/3gpp"},
    {".3gp2", "video/3gpp2"},
    {".3gpp", "video/3gpp"},
    {".7z", "application/x-7z-compressed"},
    {".aa", "audio/audible"},
    {".AAC", "audio/aac"},
    {".aaf", "application/octet-stream"},
    {".aax", "audio/vnd.audible.aax"},
    {".ac3", "audio/ac3"},
    {".aca", "application/octet-stream"},
    {".accda", "application/msaccess.addin"},
    {".accdb", "application/msaccess"},
    {".accdc", "application/msaccess.cab"},
    {".accde", "application/msaccess"},
    {".accdr", "application/msaccess.runtime"},
    {".accdt", "application/msaccess"},
    {".accdw", "application/msaccess.webapplication"},
    {".accft", "application/msaccess.ftemplate"},
    {".acx", "application/internet-property-stream"},
    {".AddIn", "text/xml"},
    {".ade", "application/msaccess"},
    {".adobebridge", "application/x-bridge-url"},
    {".adp", "application/msaccess"},
    {".ADT", "audio/vnd.dlna.adts"},
    {".ADTS", "audio/aac"},
    {".afm", "application/octet-stream"},
    {".ai", "application/postscript"},
    {".aif", "audio/x-aiff"},
    {".aifc", "audio/aiff"},
    {".aiff", "audio/aiff"},
    {".air", "application/vnd.adobe.air-application-installer-package+zip"},
    {".amc", "application/x-mpeg"},
    {".application", "application/x-ms-application"},
    {".art", "image/x-jg"},
    {".asa", "application/xml"},
    {".asax", "application/xml"},
    {".ascx", "application/xml"},
    {".asd", "application/octet-stream"},
    {".asf", "video/x-ms-asf"},
    {".ashx", "application/xml"},
    {".asi", "application/octet-stream"},
    {".asm", "text/plain"},
    {".asmx", "application/xml"},
    {".aspx", "application/xml"},
    {".asr", "video/x-ms-asf"},
    {".asx", "video/x-ms-asf"},
    {".atom", "application/atom+xml"},
    {".au", "audio/basic"},
    {".avi", "video/x-msvideo"},
    {".axs", "application/olescript"},
    {".bas", "text/plain"},
    {".bcpio", "application/x-bcpio"},
    {".bin", "application/octet-stream"},
    {".bmp", "image/bmp"},
    {".c", "text/plain"},
    {".cab", "application/octet-stream"},
    {".caf", "audio/x-caf"},
    {".calx", "application/vnd.ms-office.calx"},
    {".cat", "application/vnd.ms-pki.seccat"},
    {".cc", "text/plain"},
    {".cd", "text/plain"},
    {".cdda", "audio/aiff"},
    {".cdf", "application/x-cdf"},
    {".cer", "application/x-x509-ca-cert"},
    {".chm", "application/octet-stream"},
    {".class", "application/x-java-applet"},
    {".clp", "application/x-msclip"},
    {".cmx", "image/x-cmx"},
    {".cnf", "text/plain"},
    {".cod", "image/cis-cod"},
    {".config", "application/xml"},
    {".contact", "text/x-ms-contact"},
    {".coverage", "application/xml"},
    {".cpio", "application/x-cpio"},
    {".cpp", "text/plain"},
    {".crd", "application/x-mscardfile"},
    {".crl", "application/pkix-crl"},
    {".crt", "application/x-x509-ca-cert"},
    {".cs", "text/plain"},
    {".csdproj", "text/plain"},
    {".csh", "application/x-csh"},
    {".csproj", "text/plain"},
    {".css", "text/css"},
    {".csv", "text/csv"},
    {".cur", "application/octet-stream"},
    {".cxx", "text/plain"},
    {".dat", "application/octet-stream"},
    {".datasource", "application/xml"},
    {".dbproj", "text/plain"},
    {".dcr", "application/x-director"},
    {".def", "text/plain"},
    {".deploy", "application/octet-stream"},
    {".der", "application/x-x509-ca-cert"},
    {".dgml", "application/xml"},
    {".dib", "image/bmp"},
    {".dif", "video/x-dv"},
    {".dir", "application/x-director"},
    {".disco", "text/xml"},
    {".dll", "application/x-msdownload"},
    {".dll.config", "text/xml"},
    {".dlm", "text/dlm"},
    {".doc", "application/msword"},
    {".docm", "application/vnd.ms-word.document.macroEnabled.12"},
    {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
    {".dot", "application/msword"},
    {".dotm", "application/vnd.ms-word.template.macroEnabled.12"},
    {".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template"},
    {".dsp", "application/octet-stream"},
    {".dsw", "text/plain"},
    {".dtd", "text/xml"},
    {".dtsConfig", "text/xml"},
    {".dv", "video/x-dv"},
    {".dvi", "application/x-dvi"},
    {".dwf", "drawing/x-dwf"},
    {".dwp", "application/octet-stream"},
    {".dxr", "application/x-director"},
    {".eml", "message/rfc822"},
    {".emz", "application/octet-stream"},
    {".eot", "application/octet-stream"},
    {".eps", "application/postscript"},
    {".etl", "application/etl"},
    {".etx", "text/x-setext"},
    {".evy", "application/envoy"},
    {".exe", "application/octet-stream"},
    {".exe.config", "text/xml"},
    {".fdf", "application/vnd.fdf"},
    {".fif", "application/fractals"},
    {".filters", "Application/xml"},
    {".fla", "application/octet-stream"},
    {".flr", "x-world/x-vrml"},
    {".flv", "video/x-flv"},
    {".fsscript", "application/fsharp-script"},
    {".fsx", "application/fsharp-script"},
    {".generictest", "application/xml"},
    {".gif", "image/gif"},
    {".group", "text/x-ms-group"},
    {".gsm", "audio/x-gsm"},
    {".gtar", "application/x-gtar"},
    {".gz", "application/x-gzip"},
    {".h", "text/plain"},
    {".hdf", "application/x-hdf"},
    {".hdml", "text/x-hdml"},
    {".hhc", "application/x-oleobject"},
    {".hhk", "application/octet-stream"},
    {".hhp", "application/octet-stream"},
    {".hlp", "application/winhlp"},
    {".hpp", "text/plain"},
    {".hqx", "application/mac-binhex40"},
    {".hta", "application/hta"},
    {".htc", "text/x-component"},
    {".htm", "text/html"},
    {".html", "text/html"},
    {".htt", "text/webviewhtml"},
    {".hxa", "application/xml"},
    {".hxc", "application/xml"},
    {".hxd", "application/octet-stream"},
    {".hxe", "application/xml"},
    {".hxf", "application/xml"},
    {".hxh", "application/octet-stream"},
    {".hxi", "application/octet-stream"},
    {".hxk", "application/xml"},
    {".hxq", "application/octet-stream"},
    {".hxr", "application/octet-stream"},
    {".hxs", "application/octet-stream"},
    {".hxt", "text/html"},
    {".hxv", "application/xml"},
    {".hxw", "application/octet-stream"},
    {".hxx", "text/plain"},
    {".i", "text/plain"},
    {".ico", "image/x-icon"},
    {".ics", "application/octet-stream"},
    {".idl", "text/plain"},
    {".ief", "image/ief"},
    {".iii", "application/x-iphone"},
    {".inc", "text/plain"},
    {".inf", "application/octet-stream"},
    {".inl", "text/plain"},
    {".ins", "application/x-internet-signup"},
    {".ipa", "application/x-itunes-ipa"},
    {".ipg", "application/x-itunes-ipg"},
    {".ipproj", "text/plain"},
    {".ipsw", "application/x-itunes-ipsw"},
    {".iqy", "text/x-ms-iqy"},
    {".isp", "application/x-internet-signup"},
    {".ite", "application/x-itunes-ite"},
    {".itlp", "application/x-itunes-itlp"},
    {".itms", "application/x-itunes-itms"},
    {".itpc", "application/x-itunes-itpc"},
    {".IVF", "video/x-ivf"},
    {".jar", "application/java-archive"},
    {".java", "application/octet-stream"},
    {".jck", "application/liquidmotion"},
    {".jcz", "application/liquidmotion"},
    {".jfif", "image/pjpeg"},
    {".jnlp", "application/x-java-jnlp-file"},
    {".jpb", "application/octet-stream"},
    {".jpe", "image/jpeg"},
    {".jpeg", "image/jpeg"},
    {".jpg", "image/jpeg"},
    {".js", "application/x-javascript"},
    {".json", "application/json"},
    {".jsx", "text/jscript"},
    {".jsxbin", "text/plain"},
    {".latex", "application/x-latex"},
    {".library-ms", "application/windows-library+xml"},
    {".lit", "application/x-ms-reader"},
    {".loadtest", "application/xml"},
    {".lpk", "application/octet-stream"},
    {".lsf", "video/x-la-asf"},
    {".lst", "text/plain"},
    {".lsx", "video/x-la-asf"},
    {".lzh", "application/octet-stream"},
    {".m13", "application/x-msmediaview"},
    {".m14", "application/x-msmediaview"},
    {".m1v", "video/mpeg"},
    {".m2t", "video/vnd.dlna.mpeg-tts"},
    {".m2ts", "video/vnd.dlna.mpeg-tts"},
    {".m2v", "video/mpeg"},
    {".m3u", "audio/x-mpegurl"},
    {".m3u8", "audio/x-mpegurl"},
    {".m4a", "audio/m4a"},
    {".m4b", "audio/m4b"},
    {".m4p", "audio/m4p"},
    {".m4r", "audio/x-m4r"},
    {".m4v", "video/x-m4v"},
    {".mac", "image/x-macpaint"},
    {".mak", "text/plain"},
    {".man", "application/x-troff-man"},
    {".manifest", "application/x-ms-manifest"},
    {".map", "text/plain"},
    {".master", "application/xml"},
    {".mda", "application/msaccess"},
    {".mdb", "application/x-msaccess"},
    {".mde", "application/msaccess"},
    {".mdp", "application/octet-stream"},
    {".me", "application/x-troff-me"},
    {".mfp", "application/x-shockwave-flash"},
    {".mht", "message/rfc822"},
    {".mhtml", "message/rfc822"},
    {".mid", "audio/mid"},
    {".midi", "audio/mid"},
    {".mix", "application/octet-stream"},
    {".mk", "text/plain"},
    {".mmf", "application/x-smaf"},
    {".mno", "text/xml"},
    {".mny", "application/x-msmoney"},
    {".mod", "video/mpeg"},
    {".mov", "video/quicktime"},
    {".movie", "video/x-sgi-movie"},
    {".mp2", "video/mpeg"},
    {".mp2v", "video/mpeg"},
    {".mp3", "audio/mpeg"},
    {".mp4", "video/mp4"},
    {".mp4v", "video/mp4"},
    {".mpa", "video/mpeg"},
    {".mpe", "video/mpeg"},
    {".mpeg", "video/mpeg"},
    {".mpf", "application/vnd.ms-mediapackage"},
    {".mpg", "video/mpeg"},
    {".mpp", "application/vnd.ms-project"},
    {".mpv2", "video/mpeg"},
    {".mqv", "video/quicktime"},
    {".ms", "application/x-troff-ms"},
    {".msi", "application/octet-stream"},
    {".mso", "application/octet-stream"},
    {".mts", "video/vnd.dlna.mpeg-tts"},
    {".mtx", "application/xml"},
    {".mvb", "application/x-msmediaview"},
    {".mvc", "application/x-miva-compiled"},
    {".mxp", "application/x-mmxp"},
    {".nc", "application/x-netcdf"},
    {".nsc", "video/x-ms-asf"},
    {".nws", "message/rfc822"},
    {".ocx", "application/octet-stream"},
    {".oda", "application/oda"},
    {".odc", "text/x-ms-odc"},
    {".odh", "text/plain"},
    {".odl", "text/plain"},
    {".odp", "application/vnd.oasis.opendocument.presentation"},
    {".ods", "application/oleobject"},
    {".odt", "application/vnd.oasis.opendocument.text"},
    {".one", "application/onenote"},
    {".onea", "application/onenote"},
    {".onepkg", "application/onenote"},
    {".onetmp", "application/onenote"},
    {".onetoc", "application/onenote"},
    {".onetoc2", "application/onenote"},
    {".orderedtest", "application/xml"},
    {".osdx", "application/opensearchdescription+xml"},
    {".p10", "application/pkcs10"},
    {".p12", "application/x-pkcs12"},
    {".p7b", "application/x-pkcs7-certificates"},
    {".p7c", "application/pkcs7-mime"},
    {".p7m", "application/pkcs7-mime"},
    {".p7r", "application/x-pkcs7-certreqresp"},
    {".p7s", "application/pkcs7-signature"},
    {".pbm", "image/x-portable-bitmap"},
    {".pcast", "application/x-podcast"},
    {".pct", "image/pict"},
    {".pcx", "application/octet-stream"},
    {".pcz", "application/octet-stream"},
    {".pdf", "application/pdf"},
    {".pfb", "application/octet-stream"},
    {".pfm", "application/octet-stream"},
    {".pfx", "application/x-pkcs12"},
    {".pgm", "image/x-portable-graymap"},
    {".pic", "image/pict"},
    {".pict", "image/pict"},
    {".pkgdef", "text/plain"},
    {".pkgundef", "text/plain"},
    {".pko", "application/vnd.ms-pki.pko"},
    {".pls", "audio/scpls"},
    {".pma", "application/x-perfmon"},
    {".pmc", "application/x-perfmon"},
    {".pml", "application/x-perfmon"},
    {".pmr", "application/x-perfmon"},
    {".pmw", "application/x-perfmon"},
    {".png", "image/png"},
    {".pnm", "image/x-portable-anymap"},
    {".pnt", "image/x-macpaint"},
    {".pntg", "image/x-macpaint"},
    {".pnz", "image/png"},
    {".pot", "application/vnd.ms-powerpoint"},
    {".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12"},
    {".potx", "application/vnd.openxmlformats-officedocument.presentationml.template"},
    {".ppa", "application/vnd.ms-powerpoint"},
    {".ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12"},
    {".ppm", "image/x-portable-pixmap"},
    {".pps", "application/vnd.ms-powerpoint"},
    {".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"},
    {".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
    {".ppt", "application/vnd.ms-powerpoint"},
    {".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12"},
    {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
    {".prf", "application/pics-rules"},
    {".prm", "application/octet-stream"},
    {".prx", "application/octet-stream"},
    {".ps", "application/postscript"},
    {".psc1", "application/PowerShell"},
    {".psd", "application/octet-stream"},
    {".psess", "application/xml"},
    {".psm", "application/octet-stream"},
    {".psp", "application/octet-stream"},
    {".pub", "application/x-mspublisher"},
    {".pwz", "application/vnd.ms-powerpoint"},
    {".qht", "text/x-html-insertion"},
    {".qhtm", "text/x-html-insertion"},
    {".qt", "video/quicktime"},
    {".qti", "image/x-quicktime"},
    {".qtif", "image/x-quicktime"},
    {".qtl", "application/x-quicktimeplayer"},
    {".qxd", "application/octet-stream"},
    {".ra", "audio/x-pn-realaudio"},
    {".ram", "audio/x-pn-realaudio"},
    {".rar", "application/octet-stream"},
    {".ras", "image/x-cmu-raster"},
    {".rat", "application/rat-file"},
    {".rc", "text/plain"},
    {".rc2", "text/plain"},
    {".rct", "text/plain"},
    {".rdlc", "application/xml"},
    {".resx", "application/xml"},
    {".rf", "image/vnd.rn-realflash"},
    {".rgb", "image/x-rgb"},
    {".rgs", "text/plain"},
    {".rm", "application/vnd.rn-realmedia"},
    {".rmi", "audio/mid"},
    {".rmp", "application/vnd.rn-rn_music_package"},
    {".roff", "application/x-troff"},
    {".rpm", "audio/x-pn-realaudio-plugin"},
    {".rqy", "text/x-ms-rqy"},
    {".rtf", "application/rtf"},
    {".rtx", "text/richtext"},
    {".ruleset", "application/xml"},
    {".s", "text/plain"},
    {".safariextz", "application/x-safari-safariextz"},
    {".scd", "application/x-msschedule"},
    {".sct", "text/scriptlet"},
    {".sd2", "audio/x-sd2"},
    {".sdp", "application/sdp"},
    {".sea", "application/octet-stream"},
    {".searchConnector-ms", "application/windows-search-connector+xml"},
    {".setpay", "application/set-payment-initiation"},
    {".setreg", "application/set-registration-initiation"},
    {".settings", "application/xml"},
    {".sgimb", "application/x-sgimb"},
    {".sgml", "text/sgml"},
    {".sh", "application/x-sh"},
    {".shar", "application/x-shar"},
    {".shtml", "text/html"},
    {".sit", "application/x-stuffit"},
    {".sitemap", "application/xml"},
    {".skin", "application/xml"},
    {".sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12"},
    {".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide"},
    {".slk", "application/vnd.ms-excel"},
    {".sln", "text/plain"},
    {".slupkg-ms", "application/x-ms-license"},
    {".smd", "audio/x-smd"},
    {".smi", "application/octet-stream"},
    {".smx", "audio/x-smd"},
    {".smz", "audio/x-smd"},
    {".snd", "audio/basic"},
    {".snippet", "application/xml"},
    {".snp", "application/octet-stream"},
    {".sol", "text/plain"},
    {".sor", "text/plain"},
    {".spc", "application/x-pkcs7-certificates"},
    {".spl", "application/futuresplash"},
    {".src", "application/x-wais-source"},
    {".srf", "text/plain"},
    {".SSISDeploymentManifest", "text/xml"},
    {".ssm", "application/streamingmedia"},
    {".sst", "application/vnd.ms-pki.certstore"},
    {".stl", "application/vnd.ms-pki.stl"},
    {".sv4cpio", "application/x-sv4cpio"},
    {".sv4crc", "application/x-sv4crc"},
    {".svc", "application/xml"},
    {".swf", "application/x-shockwave-flash"},
    {".t", "application/x-troff"},
    {".tar", "application/x-tar"},
    {".tcl", "application/x-tcl"},
    {".testrunconfig", "application/xml"},
    {".testsettings", "application/xml"},
    {".tex", "application/x-tex"},
    {".texi", "application/x-texinfo"},
    {".texinfo", "application/x-texinfo"},
    {".tgz", "application/x-compressed"},
    {".thmx", "application/vnd.ms-officetheme"},
    {".thn", "application/octet-stream"},
    {".tif", "image/tiff"},
    {".tiff", "image/tiff"},
    {".tlh", "text/plain"},
    {".tli", "text/plain"},
    {".toc", "application/octet-stream"},
    {".tr", "application/x-troff"},
    {".trm", "application/x-msterminal"},
    {".trx", "application/xml"},
    {".ts", "video/vnd.dlna.mpeg-tts"},
    {".tsv", "text/tab-separated-values"},
    {".ttf", "application/octet-stream"},
    {".tts", "video/vnd.dlna.mpeg-tts"},
    {".txt", "text/plain"},
    {".u32", "application/octet-stream"},
    {".uls", "text/iuls"},
    {".user", "text/plain"},
    {".ustar", "application/x-ustar"},
    {".vb", "text/plain"},
    {".vbdproj", "text/plain"},
    {".vbk", "video/mpeg"},
    {".vbproj", "text/plain"},
    {".vbs", "text/vbscript"},
    {".vcf", "text/x-vcard"},
    {".vcproj", "Application/xml"},
    {".vcs", "text/plain"},
    {".vcxproj", "Application/xml"},
    {".vddproj", "text/plain"},
    {".vdp", "text/plain"},
    {".vdproj", "text/plain"},
    {".vdx", "application/vnd.ms-visio.viewer"},
    {".vml", "text/xml"},
    {".vscontent", "application/xml"},
    {".vsct", "text/xml"},
    {".vsd", "application/vnd.visio"},
    {".vsi", "application/ms-vsi"},
    {".vsix", "application/vsix"},
    {".vsixlangpack", "text/xml"},
    {".vsixmanifest", "text/xml"},
    {".vsmdi", "application/xml"},
    {".vspscc", "text/plain"},
    {".vss", "application/vnd.visio"},
    {".vsscc", "text/plain"},
    {".vssettings", "text/xml"},
    {".vssscc", "text/plain"},
    {".vst", "application/vnd.visio"},
    {".vstemplate", "text/xml"},
    {".vsto", "application/x-ms-vsto"},
    {".vsw", "application/vnd.visio"},
    {".vsx", "application/vnd.visio"},
    {".vtx", "application/vnd.visio"},
    {".wav", "audio/wav"},
    {".wave", "audio/wav"},
    {".wax", "audio/x-ms-wax"},
    {".wbk", "application/msword"},
    {".wbmp", "image/vnd.wap.wbmp"},
    {".wcm", "application/vnd.ms-works"},
    {".wdb", "application/vnd.ms-works"},
    {".wdp", "image/vnd.ms-photo"},
    {".webarchive", "application/x-safari-webarchive"},
    {".webtest", "application/xml"},
    {".wiq", "application/xml"},
    {".wiz", "application/msword"},
    {".wks", "application/vnd.ms-works"},
    {".WLMP", "application/wlmoviemaker"},
    {".wlpginstall", "application/x-wlpg-detect"},
    {".wlpginstall3", "application/x-wlpg3-detect"},
    {".wm", "video/x-ms-wm"},
    {".wma", "audio/x-ms-wma"},
    {".wmd", "application/x-ms-wmd"},
    {".wmf", "application/x-msmetafile"},
    {".wml", "text/vnd.wap.wml"},
    {".wmlc", "application/vnd.wap.wmlc"},
    {".wmls", "text/vnd.wap.wmlscript"},
    {".wmlsc", "application/vnd.wap.wmlscriptc"},
    {".wmp", "video/x-ms-wmp"},
    {".wmv", "video/x-ms-wmv"},
    {".wmx", "video/x-ms-wmx"},
    {".wmz", "application/x-ms-wmz"},
    {".wpl", "application/vnd.ms-wpl"},
    {".wps", "application/vnd.ms-works"},
    {".wri", "application/x-mswrite"},
    {".wrl", "x-world/x-vrml"},
    {".wrz", "x-world/x-vrml"},
    {".wsc", "text/scriptlet"},
    {".wsdl", "text/xml"},
    {".wvx", "video/x-ms-wvx"},
    {".x", "application/directx"},
    {".xaf", "x-world/x-vrml"},
    {".xaml", "application/xaml+xml"},
    {".xap", "application/x-silverlight-app"},
    {".xbap", "application/x-ms-xbap"},
    {".xbm", "image/x-xbitmap"},
    {".xdr", "text/plain"},
    {".xht", "application/xhtml+xml"},
    {".xhtml", "application/xhtml+xml"},
    {".xla", "application/vnd.ms-excel"},
    {".xlam", "application/vnd.ms-excel.addin.macroEnabled.12"},
    {".xlc", "application/vnd.ms-excel"},
    {".xld", "application/vnd.ms-excel"},
    {".xlk", "application/vnd.ms-excel"},
    {".xll", "application/vnd.ms-excel"},
    {".xlm", "application/vnd.ms-excel"},
    {".xls", "application/vnd.ms-excel"},
    {".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12"},
    {".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12"},
    {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
    {".xlt", "application/vnd.ms-excel"},
    {".xltm", "application/vnd.ms-excel.template.macroEnabled.12"},
    {".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
    {".xlw", "application/vnd.ms-excel"},
    {".xml", "text/xml"},
    {".xmta", "application/xml"},
    {".xof", "x-world/x-vrml"},
    {".XOML", "text/plain"},
    {".xpm", "image/x-xpixmap"},
    {".xps", "application/vnd.ms-xpsdocument"},
    {".xrm-ms", "text/xml"},
    {".xsc", "application/xml"},
    {".xsd", "text/xml"},
    {".xsf", "text/xml"},
    {".xsl", "text/xml"},
    {".xslt", "text/xml"},
    {".xsn", "application/octet-stream"},
    {".xss", "application/xml"},
    {".xtp", "application/octet-stream"},
    {".xwd", "image/x-xwindowdump"},
    {".z", "application/x-compress"},
    {".zip", "application/x-zip-compressed"},
    #endregion

    };




        
        public static int Notify(string name, string value, Dictionary<string,string> optionaldata =null)
        {
            //var namespaceFound = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
            //                      from type in assembly.GetTypes()
            //                      where type.Namespace == "Yemon.dnn.SIPro"
            //                      select type).Any();
                                  
            //if(!namespaceFound)
            //{
            //    return 0;
            //}

            PortalSettings ps = Globals.GetPortalSettings();
            var userInfo = UserController.Instance.GetCurrentUserInfo();
            try
            {
                string data = "";
                if(optionaldata != null)
                {
                    data = Yemon.dnn.Functions.Serialize(optionaldata);
                }

                int msgid = Yemon.dnn.SIPro.SIPro.AddMessage(ps.PortalId, userInfo.UserID, name, value, data);

                return msgid;
            }
            catch(Exception ee)
            {
                Functions.Error(ee);
                return 0;
                
            }

            
        }

        /// <summary>
        /// Formatage du numero 
        /// n° Francais : 00 00 00 00 00
        /// n° Etranger : +0000000000000
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string FormatNumber(string number)
        {
            if (number == null)
                return "";
            if (number.Length == 10 && number.StartsWith("0"))
                return number.Substring(0, 2) + " " +
                    number.Substring(2, 2) + " " +
                    number.Substring(4, 2) + " " +
                    number.Substring(6, 2) + " " +
                    number.Substring(8, 2);

            return number;
        }


        /// <summary>
        /// Corrige et normalize un n° de téléphone venant du RI
        /// afin que le n° soit utilisable pour une numérotation directe (exemple : APP Mobile)
        /// n° Francais : 0000000000 (sans le +33 devant)
        /// n° Etranger : +0000000000
        /// un n° de moins de 10 chiffres est remplacé par une chaine vide
        /// tout caractère non numérique est supprimé
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NormalizeNumber(string number)
        {
            string n = number.Replace(" ", "");
            n = n.Replace("-", "");
            n = n.Replace("(", "");
            n = n.Replace(")", "");
            n = n.Replace(".", "");
            n = n.Replace("?", "");
            n = n.Replace("/", "");
            if (n.IndexOf(",") > 8)
                n = n.Substring(0, n.IndexOf(","));

            string n1 = "";
            if (n.StartsWith("+"))
                n1 = "+";
            foreach (char c in n.ToCharArray())
            {
                if ("0123456789".Contains(c))
                    n1 += c;
            }
            n = n1;


            // correction n° francais
            bool isfrench = false;
            if (n.StartsWith("+33"))
            {
                n = n.Substring(3);
                isfrench = true;
            }

            if (n.StartsWith("33"))
            {
                n = n.Substring(2);
                isfrench = true;
            }

            if (n.StartsWith("0033"))
            {
                n = n.Substring(4);
                isfrench = true;
            }

            if (n.StartsWith("33"))
            {
                n = n.Substring(2);
                isfrench = true;
            }


            if (n.StartsWith("+33"))
            {
                n = n.Substring(3);
                isfrench = true;
            }


            // correction n° andorre
            if (n.StartsWith("37600376"))
                n = "376" + n.Substring(8);
            if (n.StartsWith("376376"))
                n = "376" + n.Substring(6);

            // correction n° belgique
            if (n.StartsWith("320032"))
                n = "+32" + n.Substring(6);


            if (!n.StartsWith("0") && !n.StartsWith("376") && n.Length == 9)
            {
                n = "0" + n;
                isfrench = true;
            }


            if (!n.StartsWith("0") && !n.StartsWith("+") && n.Length > 10 && !isfrench)
                n = "+" + n;

            if (n.StartsWith("0") && n.Length > 10)
                n = n.Substring(0, 10);

            if (!n.StartsWith("0") && n.Length >= 10 && isfrench)
                n = "0" + n.Substring(0, 9);

            if (n.StartsWith("+") && n.Length == 10 && isfrench)
                n = "0" + n.Substring(1);

            if (!n.StartsWith("0") && !n.StartsWith("+") && n.Length == 10 && !isfrench)
                n = "+" + n;

            if (n.StartsWith("376") && n.Length == 9 && !isfrench)
                n = "+" + n;


            if (n.StartsWith("+4141"))
                n = "+41" + n.Substring(5);






            if (n.Length < 10)
                n = "";

            if (n == "0000000000")
                n = "";

            return n;
        }


        public static int GetClubSatellite(int cric){
        
            for (int i = 0; i < (Const.CLUB_SATELLITE_PARENT_CHILD.Length / 2) ; i++)
            {
                if (Const.CLUB_SATELLITE_PARENT_CHILD[i, 0] == cric)
                {
                    return Const.CLUB_SATELLITE_PARENT_CHILD[i, 1];
                }

            }
            return 0;
        }

        public static int GetClubParent(int cric)
        {

            for (int i = 0; i < (Const.CLUB_SATELLITE_PARENT_CHILD.Length / 2) ; i++)
            {
                if (Const.CLUB_SATELLITE_PARENT_CHILD[i, 1] == cric)
                {
                    return Const.CLUB_SATELLITE_PARENT_CHILD[i, 0];
                }

            }
            return 0;
        }


        public static string JSONFormat(string json)
        {
            StringBuilder sb = new StringBuilder();
            int level = 0;
            foreach(var c in json.ToCharArray())
            {
                if (c == '{')
                {
                    sb.AppendLine("{");
                    level++;
                    for (int i = 0; i < level; i++)
                        sb.Append("\t");
                    
                }
                else if (c == '}')
                {
                    sb.AppendLine();
                     level--;
                    for (int i = 0; i < level; i++)
                        sb.Append("\t");
                    sb.Append("}");                   
                }
                else if (c == ',')
                {
                    sb.AppendLine(",");
                    for (int i = 0; i < level; i++)
                        sb.Append("\t");
                }
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }

    }
}
