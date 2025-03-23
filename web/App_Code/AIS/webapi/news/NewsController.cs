#region Copyrights

//
// RODI - https://rodi-platform.org
// Copyright (c) 2012-2025
// by SARL AIS : https://www.aisdev.net
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
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Security.Roles;
using DotNetNuke.Web.Api;
using GemBox.Pdf;
using QRCoder;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Yemon.dnn;

namespace AIS.controller
{
    public class NewsController : DnnApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Hello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "is it me you looking for ?");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage SetItem(dynamic param)
        {
            try
            {
                PortalSettings ps = Globals.GetPortalSettings();
                var userInfo = UserController.Instance.GetCurrentUserInfo();

                string guid = Yemon.dnn.Helpers.SetItem("" + param.name, "" + param.value, "" + userInfo.UserID, keephistory: (bool)param.keephistory, portalid: ps.PortalId);
                return Request.CreateResponse(HttpStatusCode.OK, guid);

            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetItem(string name)
        {
            try
            {
                PortalSettings ps = Globals.GetPortalSettings();
                var userInfo = UserController.Instance.GetCurrentUserInfo();

                object o = Yemon.dnn.Helpers.GetItem(name);
                return Request.CreateResponse(HttpStatusCode.OK, o);

            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage SetMedia()
        {

            try
            {
             

                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {

                    foreach (string file in httpRequest.Files)
                    {
                        string type = httpRequest.Form["type"];
                        string folder = "";
                        string name = "";
                        var postedFile = httpRequest.Files[file];
                        Yemon.dnn.core.Media media = new Yemon.dnn.core.Media(postedFile);
                        name = "media:" + media.GUID + ":" + type;

                        if (type == "photo")
                        {
                            bool allowPdf2Image = ("" + httpRequest.Form["allowPdf2Image"]).ToLower() == "true";
                            if (allowPdf2Image && media.MimeType == "application/pdf")
                            {


                                MemoryStream ms = new MemoryStream(media.Content);
                                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                                GemBox.Pdf.PdfDocument pdfDocument = PdfDocument.Load(ms);
                                GemBox.Pdf.ImageSaveOptions options = new GemBox.Pdf.ImageSaveOptions();
                                ms = new MemoryStream();
                                options.Format = GemBox.Pdf.ImageSaveFormat.Jpeg;
                                options.PageCount = 1;
                                options.PageNumber = 0;
                                pdfDocument.Save(ms, options);

                                media.Content = ms.GetBuffer();
                                media.MimeType = "image/jpeg";
                                media.ContentSize = media.Content.Length;

                            }
                            else if (!media.MimeType.Contains("image"))
                            {
                                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Le fichier fourni n'est pas une image " + (allowPdf2Image ? "ni un fichier PDF" : ""));
                            }

                        }
                        //switch (type)
                        //{
                        //    case "photo":
                        //    case "document":

                        //        folder = UserInfo.UserID.ToString();
                        //        name = ":" + type;
                        //        break;
                        //    default:
                        folder = type;
                        //name = ":" + type;
                        //        break;
                        //}




                        string guid = Yemon.dnn.Helpers.SetMedia(media, "" + UserInfo.UserID, folder: folder, name: name);

                        // return new media with item guid for public media access
                        media.GUID = guid;
                        media.Content = null;
                        media.Storage = null;
                        media.Folder = null;
                        return Request.CreateResponse(HttpStatusCode.OK, media);
                    }

                }

            }
            catch (Exception ee)
            {
                Functions.Error(ee);

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }


        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetMedia(string guid, int width = 0, string format = "")
        {
            try
            {
                Yemon.dnn.core.Media media = Yemon.dnn.Helpers.GetMedia(new Guid(guid));
                if (media == null)
                    throw new Exception();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                MemoryStream ms = new MemoryStream(media.Content);
                response.Content = new StreamContent(ms); ;
                response.Content.Headers.Add("Content-type", media.MimeType);
                response.Content.Headers.Add("Content-Length", "" + media.ContentSize);
                if (!media.MimeType.StartsWith("image"))
                {
                    response.Content.Headers.Add("Content-Disposition", "attachment; filename = \"" + media.Filename + "\"");
                }
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(media.MimeType);
                DateTime dt = media.Date.ToUniversalTime();
                dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);

                response.Headers.CacheControl = new CacheControlHeaderValue()
                {
                    Public = true,
                    MaxAge = new TimeSpan(365, 0, 0, 0)

                };

                response.Content.Headers.Expires = DateTime.Now.ToUniversalTime().AddDays(365);
                response.Content.Headers.LastModified = dt;

                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetNewsDetail(string guid)
        {
            
            News    news = DataMapping.GetNews(guid);
            return Request.CreateResponse(HttpStatusCode.OK, Yemon.dnn.Functions.Serialize(news));
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage DeleteNews(string guid)
        {

            if (DataMapping.DeleteNews(guid))
                Yemon.dnn.Helpers.DeleteItem("blockscontent:" + guid,purgeHistory:true);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetNews(string context,string categorie)
        {
            try
            {

            
                var application = ActionContext.Request.GetHttpContext().Application;

                string mode = "" + application[context + ":mode"];
                if (mode == "")
                    throw new Exception("mode inconnu");
                int cric = 0;

                int.TryParse(""+application[context + ":cric"],out cric);
                categorie = "" + categorie;                        
                List<News> news = new List<News>();
                List<News> news1 = new List<News>();
                if (mode=="clubs" && cric!=0)
                {
                    news = DataMapping.ListNews(cric,"Clubs",max:int.MaxValue);

                }
                else if(mode=="district")
                {
                    news = DataMapping.ListNews(0, "District", max: int.MaxValue);
                }
                else
                {
                    news = DataMapping.ListNews(0, mode, max: int.MaxValue);
                }
                if (!UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) && !UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) && !UserInfo.IsAdmin && !UserInfo.IsSuperUser)
                {
                    foreach (News n in news)
                    {
                        if(n.visible!=Const.NO)
                            if(n.tag1==categorie || categorie=="")
                                news1.Add(n);
                    }
                }
                else
                {
                    foreach(News n in news)
                    {
                        if (n.tag1 == categorie || categorie == "")
                            news1.Add(n);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK,Yemon.dnn.Functions.Serialize(news1));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetQR(string link)
        {

            bool forcedownload = ("" + HttpContext.Current.Request.QueryString["forcedownload"]).Equals("true");

            QRCodeGenerator gen = new QRCodeGenerator();
            QRCodeData qr = gen.CreateQrCode(Const.DISTRICT_URL + "/n-" + link, QRCodeGenerator.ECCLevel.H);
            QRCode code = new QRCode(qr);
            System.Drawing.Image bitmap = code.GetGraphic(4);


            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms = new MemoryStream(ms.GetBuffer());
            response.Content = new StreamContent(ms); ;
            response.Content.Headers.Add("Content-type", "image/png");
            if(forcedownload)
            {
                response.Content.Headers.Add("Content-Disposition","attachment; filename=qrcode.png");
            }

            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");

            return response;


        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetNewsCategories(string context)
        {
            try { 
                var application = ActionContext.Request.GetHttpContext().Application;

                string mode = "" + application[context + ":mode"];
                if (mode == "")
                    throw new Exception("mode inconnu");
                int cric = 0;
                int.TryParse(""+application[context + ":cric"],out cric);

                List<News> news = new List<News>();
                List<string> cats = new List<string>();
            
                if (mode == "clubs" && cric != 0)
                {
                    news = DataMapping.ListNews(cric, "Clubs", max: int.MaxValue);
                }
                else if (mode == "district")
                {
                    news = DataMapping.ListNews(0, "District", max: int.MaxValue);
                }
                else
                {
                    news = DataMapping.ListNews(0,mode,max: int.MaxValue);
                }
                if (!UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB))
                {
                    foreach (News n in news)
                    {
                        if (n.visible != Const.NO)
                            if (!cats.Contains(n.tag1))
                                cats.Add(n.tag1);
                    }
                }
                else
                {
                    foreach (News n in news)
                    {
                        if (!cats.Contains(n.tag1))
                            cats.Add(n.tag1);
                    }
                }
                string[] c = cats.ToArray();
                Array.Sort(c);
                List<object> cc = new List<object>();
                cc.Add(new { Key = "Toutes",Value="" });
                foreach(string ccc in c)
                    cc.Add(new { Key = ccc, Value = ccc });


                return Request.CreateResponse(HttpStatusCode.OK, cc);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage SetNews(dynamic param)
        {
            try
            {
                var application = ActionContext.Request.GetHttpContext().Application;
                string ctx = "" + param["context"];
                string mode = "" + application[ctx + ":mode"];
                if (mode == "")
                    throw new Exception("mode inconnu");
                int cric = 0;
                int.TryParse(""+application[ctx + ":cric"],out cric);

                PortalSettings ps = Globals.GetPortalSettings();
                var userInfo = UserController.Instance.GetCurrentUserInfo();
                News news = (News)Yemon.dnn.Functions.Deserialize("" + param["news"], typeof(News));
                string blocks = "" + param["blocks"];
                news.cric = cric;
                news.category = mode;
                if(mode=="clubs")
                {
                    Club club = DataMapping.GetClub(cric);
                    news.club_name = club.name;
                    news.club_type = club.club_type;
                }
                else
                {
                    news.cric = 0;
                }




                if (!DataMapping.UpdateNews(news))
                    throw new Exception("Erreur de mise a jour");

                Yemon.dnn.Helpers.SetItem("blockscontent:" + news.id, ""+param["blocks"], "" + userInfo.UserID, keephistory: false, portalid: ps.PortalId);
                return Request.CreateResponse(HttpStatusCode.OK, news.id);

            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }



        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetBlockContentNews(bool district, bool clubs, bool next,string tags_included,string tags_excluded) {
            var block = new Block.NewsCards();
            block.Clubs = clubs;
            block.Next = next;
            block.District = district;
            block.Tags_Included = tags_included;
            block.Tags_Excluded = tags_excluded;

            return Request.CreateResponse(HttpStatusCode.OK, Yemon.dnn.Functions.Serialize(block.News));

        }
    }
}
