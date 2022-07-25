using AIS;
using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Admin_Flash_Actions_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;

        DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
        int tabid = 0;
        int.TryParse("" + objModules.GetModuleSettings(ModuleId)["tabid"], out tabid);

        Tab.DataTextField = "Text";
        Tab.DataValueField = "Value";
        Tab.DataSource = Functions.GetListItemsFromTabs(tabid);
        Tab.DataBind();
        Tab.SelectedValue = "" + tabid;

    }

    public override void UpdateSettings()
    {
        base.UpdateSettings();

        DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
        objModules.UpdateModuleSetting(ModuleId, "tabid", Tab.SelectedValue);
    }
}