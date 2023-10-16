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
    public class ContactsController : DnnApiController
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

    }
}