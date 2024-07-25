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

    }
}
