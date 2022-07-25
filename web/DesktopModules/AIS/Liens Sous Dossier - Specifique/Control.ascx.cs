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
        int parenttab = 0;
        int.TryParse("" + Settings["parenttab"], out parenttab);
        int nbmax = 12;
        int.TryParse("" + Settings["nbmax"], out nbmax);
        List<TabInfo> tabs;
        if ((""+Settings["sortby"])== "desc")
            tabs = (from t in TabController.GetTabsByParent(parenttab, PortalId)
                    where t.ParentId == parenttab &&
                          t.IsVisible && !t.IsDeleted && !t.IsSecure &&
                          DotNetNuke.Security.Permissions.TabPermissionController.CanViewPage(t)
                    orderby t.TabOrder descending
                    select t).Take(nbmax).ToList();
        else
            tabs = (from t in TabController.GetTabsByParent(parenttab, PortalId)
                    where t.ParentId == parenttab &&
                          t.IsVisible && !t.IsDeleted && !t.IsSecure &&
                          DotNetNuke.Security.Permissions.TabPermissionController.CanViewPage(t)
                    orderby t.TabOrder ascending
                    select t).Take(nbmax).ToList();


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