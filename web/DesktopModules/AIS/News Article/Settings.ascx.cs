using DotNetNuke.Entities.Modules;
using System;
using System.Web.UI;

public partial class DesktopModules_AIS_News_Article_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;

        tbx_path.Text = "" + Settings["path"];
        tbx_style.Text = "" + Settings["style"];
        tbx_print.Text = "" + Settings["print"];
    }

    public override void UpdateSettings()
    {
        base.UpdateSettings();

        ModuleController objModules = new ModuleController();

        objModules.UpdateModuleSetting(ModuleId, "style", tbx_style.Text);
        objModules.UpdateModuleSetting(ModuleId, "path", tbx_path.Text);
        objModules.UpdateModuleSetting(ModuleId, "print", tbx_print.Text);
    }
}