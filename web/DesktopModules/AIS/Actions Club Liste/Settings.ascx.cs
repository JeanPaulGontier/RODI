using AIS;
using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Actions_Club_Liste_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;

        DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();

        int tabid_Presentation = 0;
        int.TryParse("" + objModules.GetModuleSettings(ModuleId)["presentationtabid"], out tabid_Presentation);
        ddl_tabs.DataTextField = "Text";
        ddl_tabs.DataValueField = "Value";
        ddl_tabs.DataSource = Functions.GetListItemsFromTabs(tabid_Presentation);
        ddl_tabs.DataBind();
        ddl_tabs.SelectedValue = tabid_Presentation.ToString();
    }
    public override void UpdateSettings()
    {
        base.UpdateSettings();

        DotNetNuke.Entities.Modules.ModuleController objModules3 = new DotNetNuke.Entities.Modules.ModuleController();
        objModules3.UpdateModuleSetting(ModuleId, "presentationtabid", ddl_tabs.SelectedValue);
    }
}