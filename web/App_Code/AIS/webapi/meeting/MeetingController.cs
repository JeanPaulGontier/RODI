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
    public class MeetingController : DnnApiController
    {
        [HttpGet]
        public HttpResponseMessage Hello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "is it me you looking for ?");
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Test()
        {
            return Request.CreateResponse(HttpStatusCode.OK, MeetingHelper.DoPeriodics());
            //return Request.CreateResponse(HttpStatusCode.OK, Meeting.DoNotifications());
        }


        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetQR(string link)
        {
            
            QRCodeGenerator gen = new QRCodeGenerator();
            QRCodeData qr= gen.CreateQrCode(Const.DISTRICT_URL+"/m-"+ link, QRCodeGenerator.ECCLevel.H);
            QRCode code = new QRCode(qr);
            System.Drawing.Image bitmap = code.GetGraphic(4);


            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms = new MemoryStream(ms.GetBuffer());
            response.Content = new StreamContent(ms); ;
            response.Content.Headers.Add("Content-type","image/png");
            
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");

            return response;

           
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
        public HttpResponseMessage GetMeetings(string context,string category)
        {
            
            try { 
                var application = ActionContext.Request.GetHttpContext().Application;

                int cric = 0;
                int.TryParse("" + application[context + ":cric"],out cric) ;
                string cat = "" + category;
                SqlCommand sql = new SqlCommand("SELECT * FROM ais_meetings WHERE cric=" + cric + " AND type=@type ORDER BY dtstart DESC");
                sql.Parameters.AddWithValue("type", cat);

                List<Meeting> meetings = Yemon.dnn.DataMapping.ExecSql<Meeting>(sql);
               
                return Request.CreateResponse(HttpStatusCode.OK, meetings);
            }
            catch(Exception ee)
            {
                Functions.Error(ee);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage DeleteMeeting(string guid)
        {
            SqlCommand sql = new SqlCommand("DELETE FROM ais_meetings WHERE guid = @guid");
            sql.Parameters.AddWithValue("guid", guid);
            Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);
            Yemon.dnn.Helpers.DeleteItem("blockscontent:" + guid,purgeHistory:true);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetMeeting(string context,string guid)
        {
            try { 
                var application = ActionContext.Request.GetHttpContext().Application;


                int cric = 0;
                int.TryParse(""+application[context + ":cric"],out cric);

                SqlCommand sql = new SqlCommand("select * from ais_meetings where cric=@cric and guid=@guid");
                sql.Parameters.AddWithValue("guid", guid);
                sql.Parameters.AddWithValue("cric", cric);

                Meeting meeting = Yemon.dnn.DataMapping.ExecSqlFirst<Meeting>(sql);
                if (meeting == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

         


                return Request.CreateResponse(HttpStatusCode.OK,meeting);
            }catch(Exception ee)
            {
                Functions.Error(ee);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage SetMeeting(dynamic param)
        {
            try
            {
                var application = ActionContext.Request.GetHttpContext().Application;
                string ctx = "" + param["context"];
                string mode = "" + application[ctx + ":mode"];
               
                int cric = 0;
                int.TryParse(""+application[ctx + ":cric"],out cric);
                if (cric == 0)
                    throw new Exception("club inconnu");
                PortalSettings ps = Globals.GetPortalSettings();
                var userInfo = UserController.Instance.GetCurrentUserInfo();

                

                Meeting meeting = (Meeting)Yemon.dnn.Functions.Deserialize("" + param["meeting"], typeof(Meeting));
                string blocks = "" + param["blocks"];
                meeting.cric = cric;



                Dictionary<string, object> row = new Dictionary<string, object>();
                SqlCommand sql = new SqlCommand("SELECT * FROM ais_meetings WHERE cric=@cric AND guid=@guid");
                sql.Parameters.AddWithValue("cric", cric);
                sql.Parameters.AddWithValue("guid", meeting.guid);

                Meeting m = Yemon.dnn.DataMapping.ExecSqlFirst<Meeting>(sql);
                if (m == null)
                    row["id"] = null;
                else
                    row["id"] = m.id;
                

                row["guid"] = meeting.guid;
                row["name"] = meeting.name;
                row["active"] = meeting.active;
                row["statutory"] = meeting.statutory;
                row["type"] = meeting.type;
                row["cric"] = meeting.cric;
                row["active"] = meeting.active;
                row["doperiodics"] = meeting.doperiodics;
                row["mustnotify"] = meeting.mustnotify;
                row["periods"] = meeting.periods;
                if (meeting.dtstart == DateTime.MinValue)
                    meeting.dtstart = DateTime.Now;
                if (meeting.dtend == DateTime.MinValue)
                    meeting.dtend = meeting.dtstart.AddHours(1);

                row["dtstart"] = meeting.dtstart;
                row["dtend"] = meeting.dtend;
                if (meeting.dtendactive == DateTime.MinValue)
                    meeting.dtendactive = meeting.dtstart;
                row["dtendactive"] = meeting.dtendactive;

                if (meeting.dtrevision<DateTime.Now)
                    row["dtrevision"]=DateTime.Now;
                else
                    row["dtrevision"] = meeting.dtrevision;

                if (meeting.dtnotif1 == DateTime.MinValue)
                    row["dtnotif1"] = null;
                else
                    row["dtnotif1"] = meeting.dtnotif1;
                if (meeting.dtnotif2 == DateTime.MinValue)
                    row["dtnotif2"] = null;
                else
                    row["dtnotif2"] = meeting.dtnotif2;

                row["notif1done"] = meeting.notif1done;
                row["notif2done"] = meeting.notif2done;

                if (meeting.mustnotify=="O" && meeting.type=="unitary")
                {
                    row["dtnotif1"] =null;
                    row["dtnotif2"] = null;
                    row["notif1done"] = null;
                    row["notif2done"] = null;
                }
              
                
                
                row["dtlastupdate"] = DateTime.Now;
                row["portalid"] = 0;
                row["link"] = (""+meeting.guid).ToLower().Substring(9, 9);
                row["notificationtype"] = meeting.notificationtype;
                row["notificationlist"] = meeting.notificationlist;
                row["notificationmsg"] = meeting.notificationmsg;

                var result = Yemon.dnn.DataMapping.UpdateOrInsertRecord("ais_meetings", "id", row);

                if(result.Key=="error")
                    throw new Exception("Erreur de mise a jour");

                Yemon.dnn.Helpers.SetItem("blockscontent:" + meeting.guid, ""+param["blocks"], "" + userInfo.UserID, keephistory: false, portalid: ps.PortalId);
                return Request.CreateResponse(HttpStatusCode.OK, meeting.guid);

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage SetUser(dynamic param)
        {
            try
            {
                Meeting.User user = Yemon.dnn.Functions.Deserialize("" + param["user"],typeof(Meeting.User));



                SqlCommand sql = new SqlCommand("SELECT * FROM ais_meetings WHERE guid=@guid");
                sql.Parameters.AddWithValue("guid", user.meetingguid);
                Meeting m = Yemon.dnn.DataMapping.ExecSqlFirst<Meeting>(sql);
                if (m == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);


                sql = new SqlCommand("SELECT * FROM ais_meetings_users WHERE guid=@guid AND meetingguid=@meetingguid");
                sql.Parameters.AddWithValue("guid", user.guid);
                sql.Parameters.AddWithValue("meetingguid", user.meetingguid);

                Dictionary<string, object> row = new Dictionary<string, object>();
                Meeting.User u = Yemon.dnn.DataMapping.ExecSqlFirst<Meeting.User>(sql);
                
                if(u==null)
                {
                    row["id"] = null;
                }
                else
                {
                    row["id"] = u.id;
                }
                row["guid"] = user.guid;
                row["useridguid"] = user.useridguid;

                row["meetingguid"] = user.meetingguid;
                row["firstname"] = user.firstname;
                row["lastname"] = user.lastname;
                row["comment"] = user.comment;
                row["presence"] = user.presence;
                row["dtlastupdate"] = DateTime.Now;
                var result = Yemon.dnn.DataMapping.UpdateOrInsertRecord("ais_meetings_users", "id", row);
                if (result.Key == "error")
                    throw new Exception("Erreur d'ajout d'utilisateur");

                sql = new SqlCommand("UPDATE ais_meetings SET nbusers=(select count(*) FROM ais_meetings_users WHERE meetingguid = ais_meetings.guid AND presence='Y')");
                Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);


                var data = new Dictionary<string, string>();
                data.Add("userguid", user.useridguid);
                data.Add("userfirstname", user.firstname);
                data.Add("userlastname", user.lastname);
                data.Add("userpresence", user.presence);
                Functions.Notify("MeetingSetUser", "" + user.meetingguid, optionaldata: data);


                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetUsers(string guid)
        {
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM [ais_meetings_users] WHERE meetingguid=@guid order by lastname,firstname ");
                sql.Parameters.AddWithValue("guid", guid);
                var users = Yemon.dnn.DataMapping.ExecSql<Meeting.User>(sql);
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch(Exception ee)
            {
                Functions.Error(ee);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage DeleteUser(string guid,string meetingguid)
        {
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM [ais_meetings_users] WHERE guid=@guid AND meetingguid=@meetingguid");
                sql.Parameters.AddWithValue("guid", guid);
                sql.Parameters.AddWithValue("meetingguid", meetingguid);
                Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);

                sql = new SqlCommand("UPDATE ais_meetings SET nbusers=(select count(*) FROM ais_meetings_users WHERE meetingguid = ais_meetings.guid AND presence='Y')");
                Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);

                var data = new Dictionary<string, string>();
                data.Add("userguid", guid);
                Functions.Notify("MeetingDeleteUser", "" + meetingguid, optionaldata: data);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetLoggedUser(string useridguid)
        {
            int userid = -1;
            if((""+useridguid)!="")
            {
                SqlCommand sql = new SqlCommand("SELECT userid FROM users WHERE CONVERT(varchar(32), HASHBYTES('md5', CONVERT(VARCHAR(32), UserID, 2)), 2)=@guid");
                sql.Parameters.AddWithValue("guid", useridguid);
                string r = "" + Yemon.dnn.DataMapping.ExecSqlScalar(sql);
                int.TryParse(r, out userid);
            }
            else if(UserInfo.UserID>0)
            {
                userid = UserInfo.UserID;
            }
            if(userid>0)
            {
                 string firstname = "";
                string lastname = "";
                Member member = DataMapping.GetMemberByUserID(userid);
                if(member!=null)
                {
                    firstname=member.name;
                    lastname = member.surname;
                };
                string useridguid2 = Yemon.dnn.Functions.CalculateMD5Hash(""+UserInfo.UserID);
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    firstname = firstname,
                    lastname = lastname,                    
                    useridguid = useridguid2
                });
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
