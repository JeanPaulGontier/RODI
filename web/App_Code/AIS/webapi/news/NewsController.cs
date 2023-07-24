using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Security.Roles;
using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Yemon.dnn;

namespace AIS.controller
{
    public class NewsController : DnnApiController
    {

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
                        var postedFile = httpRequest.Files[file];

                        Yemon.dnn.core.Media media = new Yemon.dnn.core.Media(postedFile);
                        name = "media:" + media.GUID + ":" + type;


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
        public HttpResponseMessage GetMedia(string guid)
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
                if (!media.MimeType.StartsWith("image"))
                {
                    response.Content.Headers.Add("Content-Disposition", "attachment; filename = \"" + media.Filename + "\"");
                }
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(media.MimeType);

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
            var application = ActionContext.Request.GetHttpContext().Application;

            string mode = "" + application[context + ":mode"];
            int cric = (int)application[context + ":cric"];
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

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetNewsCategories(string context)
        {
            var application = ActionContext.Request.GetHttpContext().Application;

            string mode = "" + application[context + ":mode"];
            int cric = (int)application[context + ":cric"];

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
                int cric = (int)application[ctx + ":cric"];

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
