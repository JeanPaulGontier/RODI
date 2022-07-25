using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_News_Article_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;

        DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
        tbx_path.Text = "" + objModules.GetModuleSettings(ModuleId)["path"];
        tbx_style.Text = "" + objModules.GetModuleSettings(ModuleId)["style"];
        tbx_print.Text = "" + objModules.GetModuleSettings(ModuleId)["print"];
    }

    public override void UpdateSettings()
    {
        base.UpdateSettings();

        DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();

        objModules.UpdateModuleSetting(ModuleId, "style", tbx_style.Text);
        objModules.UpdateModuleSetting(ModuleId, "path", tbx_path.Text);
        objModules.UpdateModuleSetting(ModuleId, "print", tbx_print.Text);
    }
}