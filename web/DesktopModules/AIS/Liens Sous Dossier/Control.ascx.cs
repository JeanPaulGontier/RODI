using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Profile;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Security.Roles;

public partial class DesktopModules_AIS_Liens_Sous_Dossier_Control :  PortalModuleBase
{
    string culture = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        List<TabInfo> tabs = (from t in TabController.GetTabsByParent(PortalSettings.ActiveTab.TabID, PortalId)
                              where t.ParentId == PortalSettings.ActiveTab.TabID && t.CultureCode == culture &&
                                    t.IsVisible && !t.IsDeleted && !t.IsSecure &&
                                    DotNetNuke.Security.Permissions.TabPermissionController.CanViewPage(t)
                              select t).ToList();

      
        DataList1.DataSource = tabs;
        DataList1.DataBind();
    }
    public bool IsVisible(int tabid)
    {
        return tabid != TabId;
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item == null)
            return;

        TabInfo tab = e.Item.DataItem as TabInfo ;

        HyperLink hl = e.Item.FindControl("HL_Nom") as HyperLink;
        hl.Visible = tab.TabID != TabId;
        hl.NavigateUrl = tab.FullUrl;

        Label lbl = e.Item.FindControl("LBL_Nom") as Label;
        lbl.Visible = tab.TabID == TabId;
    }
}