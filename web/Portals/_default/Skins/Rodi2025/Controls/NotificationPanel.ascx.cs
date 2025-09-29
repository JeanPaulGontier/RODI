using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NotificationPanel : System.Web.UI.UserControl
{
    public string PanelClientID { get; set; }

    public int ModuleID { get; set; }
    public List<Notification> Notifications { get
        {
            return NotificationHelper.GetNotifications(PortalSettings.Current.UserId);
        } 
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ModuleID =(int)Math.Abs(new Random().Next()*100000);
    }
}