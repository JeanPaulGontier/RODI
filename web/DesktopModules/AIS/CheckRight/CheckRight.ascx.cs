using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Common.Utilities;
using System.Data;
using System.Data.SqlClient;
using DotNetNuke.Entities.Portals;
using AIS;
using System.Text;
using System.Collections;
using DotNetNuke.Services.Mail;

public partial class DesktopModules_CheckRight : DotNetNuke.Entities.Modules.PortalModuleBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet dsTAB = DataMapping.ExecSql("Select t.*, u.username from tabs as t, users as u where tabid in (SELECT TabID FROM TabPermission where permissionID in (4) AND  roleid = -1) AND t.LastModifiedByUserID = u.userID");
            DataSet dsMODULE = DataMapping.ExecSql("Select m.moduleid, tm.ModuleTitle, t.TabID, t.TabName, t.Title, t.TabPath, t.IsVisible, t.IsDeleted, u.username, m.LastModifiedOnDate from modules as m, tabs as t, TabModules as tm, users as u  where m.moduleid in (SELECT moduleID FROM modulePermission where permissionID in (2) AND  roleid = -1) AND tm.moduleid = m.moduleid AND t.tabid = tm.tabid AND m.LastModifiedByUserID = u.userID");

            gvw_tab.DataSource = dsTAB;
            gvw_tab.DataBind();

            gvw_Mod.DataSource = dsMODULE;
            gvw_Mod.DataBind();

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }





    protected void gvw_tab_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.DataItem == null)
                return;

            DataRowView drTab = ((DataRowView)e.Row.DataItem);

            HyperLink hlk = (HyperLink)e.Row.FindControl("lkbtn_Tab");
            hlk.NavigateUrl = DotNetNuke.Common.Globals.NavigateURL((int)drTab["Tabid"]) ;
            hlk.Target = "blank";
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }
    protected void gvw_Mod_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.DataItem == null)
                return;

            DataRowView drTab = ((DataRowView)e.Row.DataItem);

            HyperLink hlk = (HyperLink)e.Row.FindControl("lkbtn_Mod");
            hlk.NavigateUrl = DotNetNuke.Common.Globals.NavigateURL((int)drTab["Tabid"]);
            hlk.Target = "blank";
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }
}