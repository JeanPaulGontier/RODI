using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Security.Roles;
using DotNetNuke.Services.Mail;
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
using UnityEngine;
using Yemon.dnn;


namespace AIS.controller
{
    public class MailingController : DnnApiController
    {
        [HttpGet]
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
        public HttpResponseMessage GetMailingDetail(string guid)
        {
            SqlCommand sql = new SqlCommand("select * from " + Const.TABLE_PREFIX + "mailings where guid=@guid");
            sql.Parameters.AddWithValue("guid", guid);

            Mailing mailing = Yemon.dnn.DataMapping.ExecSqlFirst<Mailing>(sql);
            if (mailing == null)
            {
                return Request.CreateResponse(Yemon.dnn.Functions.Serialize(new Mailing() { guid=new Guid(guid)}));
            }
                

           // mailing.content = ""+Yemon.dnn.Helpers.GetItem("blockscontent:" + guid);

            return Request.CreateResponse(HttpStatusCode.OK, Yemon.dnn.Functions.Serialize(mailing));
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage DeleteMailing(string guid)
        {
            SqlCommand sql = new SqlCommand("delete from " + Const.TABLE_PREFIX + "mailings where guid=@guid");
            sql.Parameters.AddWithValue("guid", guid);

            if(Yemon.dnn.DataMapping.ExecSqlNonQuery(sql)>0)
               Yemon.dnn.Helpers.DeleteItem("blockscontent:" + guid,purgeHistory:true);
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage SendMailing(dynamic param)
        {
            try
            {
                string guid = "" + param["guid"];
                string date = "" + param["date"];

                DateTime dt_start = DateTime.Now;

                SqlCommand sql = new SqlCommand("update " + Const.TABLE_PREFIX + "mailings set step="+(int)Mailing.STEPS.PREPARE+",dt_start=@dt_start where guid=@guid");
                sql.Parameters.AddWithValue("guid", guid);
                sql.Parameters.AddWithValue("dt_start", dt_start);

                int nb=Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);
                if(nb>0)
                    return Request.CreateResponse(HttpStatusCode.OK);

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage SendTest(dynamic param)
        {
            try
            {
                string guid = "" + param["guid"];
                string email = "" + param["email"];

                DateTime dt_start = DateTime.Now;

                SqlCommand sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "mailing_out " +
                    "(guid,mailing_guid,nim,email,status,portalid,priority) VALUES " +
                    "(@guid,@mailing_guid,@nim,@email,@status,@portalid,@priority)");
                sql.Parameters.AddWithValue("mailing_guid", "" + guid);
                sql.Parameters.AddWithValue("guid", "" + Guid.NewGuid());
                sql.Parameters.AddWithValue("nim", 0);
                sql.Parameters.AddWithValue("email", email);
                sql.Parameters.AddWithValue("status", Mailing.Out.TEST);
                sql.Parameters.AddWithValue("priority", Mailing.Out.PRIORITY.NORMAL);
                sql.Parameters.AddWithValue("portalid", 0);
                if (Yemon.dnn.DataMapping.ExecSqlNonQuery(sql) > 0)
                   return Request.CreateResponse(HttpStatusCode.OK);

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetMailings(string context,string categorie)
        {
            var application = ActionContext.Request.GetHttpContext().Application;

            string mode = "" + application[context + ":mode"];
            int cric = (int)application[context + ":cric"];
            categorie = "" + categorie;

            SqlCommand sql = new SqlCommand("select * from "+Const.TABLE_PREFIX+"mailings where cric=@cric order by dt desc");
            sql.Parameters.AddWithValue("cric", cric);
            sql.Parameters.AddWithValue("category", categorie);
            List<Mailing> mailings = Yemon.dnn.DataMapping.ExecSql<Mailing>(sql);
           
            return Request.CreateResponse(HttpStatusCode.OK,Yemon.dnn.Functions.Serialize(mailings));
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetCategories(string context)
        {
            var application = ActionContext.Request.GetHttpContext().Application;

            string mode = "" + application[context + ":mode"];
            int cric = (int)application[context + ":cric"];

            
            SqlCommand sql = new SqlCommand("select distinct category from " + Const.TABLE_PREFIX + "mailings where cric=@cric order by category");
            sql.Parameters.AddWithValue("cric", cric);

            List<string> categories = new List<string>();


            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage SetMail(dynamic param)
        {
            try
            {
                var application = ActionContext.Request.GetHttpContext().Application;
                string ctx = "" + param["context"];
                string mode = "" + application[ctx + ":mode"];
                int cric = (int)application[ctx + ":cric"];

                PortalSettings ps = Globals.GetPortalSettings();
                var userInfo = UserController.Instance.GetCurrentUserInfo();
                Mailing m = (Mailing)Yemon.dnn.Functions.Deserialize("" + param["mailing"], typeof(Mailing));

                SqlCommand sql = new SqlCommand("select * from " + Const.TABLE_PREFIX + "mailings where guid=@guid");
                sql.Parameters.AddWithValue("guid", m.guid);

                Dictionary<string, object> row = new Dictionary<string, object>();

                Mailing mailing = Yemon.dnn.DataMapping.ExecSqlFirst<Mailing>(sql);

                
                //SqlCommand sql = new SqlCommand("SELECT * FROM "+Const.TABLE_PREFIX + "mailings WHERE cric=@cric AND guid=@guid");
                //sql.Parameters.AddWithValue("cric", cric);
                //sql.Parameters.AddWithValue("guid", mailing.guid);

                //Mailing m = Yemon.dnn.DataMapping.ExecSqlFirst<Mailing>(sql);
                if (mailing==null)
                {
                    row["id"] = null;
                }                    
                else
                {
                    row["id"] = mailing.id;                   
                }

                row["cric"] = cric;
                row["guid"] = m.guid;
                row["step"] = m.step;

                row["category"] = m.category;
                row["dt"] = DateTime.Now;
                if (m.dt_start > DateTime.MinValue)
                    row["dt_start"] = m.dt_start;
                else
                    row["dt_start"] = null;
                row["subject"] = m.subject;
                row["sender_email"] = m.sender_email;
                row["sender_name"] = m.sender_name;
                row["recipients"] = m.recipients;

                row["portalid"] = ps.PortalId;

                var result = Yemon.dnn.DataMapping.UpdateOrInsertRecord(Const.TABLE_PREFIX + "mailings", "id", row);
                if(result.Key=="error")
                    throw new Exception("Erreur de mise a jour");

                return Request.CreateResponse(HttpStatusCode.OK, ""+ m.guid);

            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }


        
        

    }
}
