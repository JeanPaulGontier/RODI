using Dnn.PersonaBar.Users.Components;
using DotNetNuke.Common;
using DotNetNuke.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;


public partial class AIS_AutoLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string guid = "" + Request["guid"];
        string url = "" + Request["url"];
        if (Application[guid] != null)
        {
            try
            {
                int userid = (int)Application[guid];
                if (userid != Globals.GetPortalSettings().UserId)
                {

                    UserController userController = new UserController();
                    UserInfo userInfo = userController.GetUser(Globals.GetPortalSettings().PortalId, userid);
                    if (userInfo != null)
                    {
                        UserController.UserLogin(
                            Globals.GetPortalSettings().PortalId,
                            userInfo,
                            Globals.GetPortalSettings().PortalName,
                            HttpContext.Current.Request.UserHostAddress,
                            false
                        );

                        Application[guid] = null;

                 
                    }
                }
            }
            catch (Exception ex)
            {
                Yemon.dnn.Functions.Error(ex);
            }
        }
        Response.Redirect(url, false);
    }
}