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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http;
using Yemon.dnn;

namespace AIS.controller
{
    public class ContactsController : DnnApiController
    {
        [HttpGet]
        public HttpResponseMessage Hello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "is it me you looking for ?");
        }

    
        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetContactsLists(string context)
        {
            try
            {
                var application = ActionContext.Request.GetHttpContext().Application;

                int cric = 0;
                int.TryParse("" + application[context + ":cric"], out cric);
                if (cric == 0)
                    return Request.CreateResponse(HttpStatusCode.OK, new Contact.List());

                PortalSettings ps = Globals.GetPortalSettings();
                var userInfo = UserController.Instance.GetCurrentUserInfo();

                List<Contact.List> contacts = Yemon.dnn.DataMapping.ExecSql<Contact.List>(new SqlCommand("select * from ais_contacts where cric=" + cric + " order by title"));

                return Request.CreateResponse(HttpStatusCode.OK, Yemon.dnn.Functions.Serialize(contacts));

            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetContactList(Guid guid)
        {
            try
            {
               
                PortalSettings ps = Globals.GetPortalSettings();
                var userInfo = UserController.Instance.GetCurrentUserInfo();

                var sql = new SqlCommand("select * from ais_contacts where guid=@guid");
                sql.Parameters.AddWithValue("guid", guid);

                Contact.List list = Yemon.dnn.DataMapping.ExecSqlFirst<Contact.List>(sql);

                return Request.CreateResponse(HttpStatusCode.OK, Yemon.dnn.Functions.Serialize(list));

            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage GetMembres(string context)
        {
            try
            {
                var application = ActionContext.Request.GetHttpContext().Application;

                int cric = 0;
                int.TryParse("" + application[context + ":cric"], out cric);
                if (cric == 0)
                    return Request.CreateResponse(HttpStatusCode.OK, new Contact.List());


                PortalSettings ps = Globals.GetPortalSettings();
                var userInfo = UserController.Instance.GetCurrentUserInfo();

                var members = DataMapping.ListMembers(cric: cric);

                var membres = new List<Contact>();
                foreach (var m in members)
                    membres.Add(new Contact
                    {
                        nim = m.nim,
                        name = m.surname + " " + m.name
                    });

                membres = membres.OrderBy(m => m.name).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, Yemon.dnn.Functions.Serialize(membres));

            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage SetContactList(dynamic param)
        {
            try
            {
                var application = ActionContext.Request.GetHttpContext().Application;
                string ctx = "" + param["context"];
                int cric = 0;
                int.TryParse("" + application[ctx + ":cric"], out cric);
                if (cric == 0)
                    throw new Exception("club introuvable");

                PortalSettings ps = Globals.GetPortalSettings();
                var userInfo = UserController.Instance.GetCurrentUserInfo();

                Contact.List list = (Contact.List)Yemon.dnn.Functions.Deserialize("" + param["data"], typeof(Contact.List));

                var row = new Dictionary<string, object>();
                row["id"] = list.id;
                row["cric"] = cric;
                if (list.guid == null)
                    list.guid = Guid.NewGuid();
                row["guid"] = list.guid;
                row["title"] = list.title;
                row["contacts"] = list.contacts;
                row["dt_update"] = DateTime.Now;

                var result = Yemon.dnn.DataMapping.UpdateOrInsertRecord(Const.TABLE_PREFIX + "contacts", "id", row);

                return Request.CreateResponse(HttpStatusCode.OK, result.Key != "error");

            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }


        [HttpGet]
        [ValidateAntiForgeryToken]
        [DnnAuthorize]
        public HttpResponseMessage DeleteContactList(Guid guid)
        {
            try
            {
                PortalSettings ps = Globals.GetPortalSettings();
                var userInfo = UserController.Instance.GetCurrentUserInfo();
                var sql = new SqlCommand("delete from ais_contacts where guid=@guid");
                sql.Parameters.AddWithValue("guid", guid);

                int result = Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);

                return Request.CreateResponse(HttpStatusCode.OK, result>0);

            }
            catch (Exception ee)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(ee.Message));
            }
        }

    }
}