﻿using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Security.Roles;
using DotNetNuke.Web.Api;
using EasyDNNSolutions.Modules.EasyDNNRotator.Entities;
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
    public class MailingController : DnnApiController
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
        public HttpResponseMessage GetMailingDetail(string guid)
        {
            SqlCommand sql = new SqlCommand("select * from " + Const.TABLE_PREFIX + "mailings where guid=@guid");
            sql.Parameters.AddWithValue("guid", guid);

            Mailing mailing = Yemon.dnn.DataMapping.ExecSqlFirst<Mailing>(sql);
            if (mailing == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            mailing.content = ""+Yemon.dnn.Helpers.GetItem("blockscontent:" + guid);

            return Request.CreateResponse(HttpStatusCode.OK, Yemon.dnn.Functions.Serialize(mailing));
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage DeleteMail(string guid)
        {
            SqlCommand sql = new SqlCommand("delete from " + Const.TABLE_PREFIX + "mailings where guid=@guid");
            sql.Parameters.AddWithValue("guid", guid);

            if(Yemon.dnn.DataMapping.ExecSqlNonQuery(sql)>0)
               Yemon.dnn.Helpers.DeleteItem("blockscontent:" + guid,purgeHistory:true);
            
            return Request.CreateResponse(HttpStatusCode.OK);
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
                Mailing mailing = (Mailing)Yemon.dnn.Functions.Deserialize("" + param["mailing"], typeof(Mailing));
                string blocks = "" + param["blocks"];
                
                Dictionary<string,object> row = new Dictionary<string,object>();

                SqlCommand sql = new SqlCommand("SELECT * FROM "+Const.TABLE_PREFIX + "mailings WHERE cric=@cric AND guid=@guid");
                sql.Parameters.AddWithValue("cric", cric);
                sql.Parameters.AddWithValue("guid", mailing.guid);

                Mailing m = Yemon.dnn.DataMapping.ExecSqlFirst<Mailing>(sql);
                if (m == null)
                {
                    row["id"] = null;
                }                    
                else
                {
                    row["id"] = m.id;                   
                }

                row["cric"] = m.cric;
                row["guid"] = m.guid;
                row["step"] = m.step;

                row["category"] = mailing.category;
                row["dt"] = mailing.dt;
                row["dt"] = mailing.dt_start;
                row["subject"] = mailing.subject;
                row["sender_email"] = mailing.sender_email;
                row["sender_name"] = mailing.sender_name;
                row["recipients"] = mailing.recipients;

                row["portalid"] = ps.PortalId;

                var result = Yemon.dnn.DataMapping.UpdateOrInsertRecord(Const.TABLE_PREFIX + "mailings", "id", row);
                if(result.Key=="error")
                    throw new Exception("Erreur de mise a jour");

                Yemon.dnn.Helpers.SetItem("blockscontent:" + mailing.guid, blocks, "" + userInfo.UserID, keephistory: false, portalid: ps.PortalId);
                return Request.CreateResponse(HttpStatusCode.OK, ""+ mailing.guid);

            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }

    }
}