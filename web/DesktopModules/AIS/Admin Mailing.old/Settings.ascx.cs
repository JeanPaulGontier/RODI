using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Admin_Mailing_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;

        DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();

         string valueRBL = "" + objModules.GetModuleSettings(ModuleId)["mode"];
        foreach (ListItem li in rbl_mode.Items)
        {
            if (li.Value == valueRBL)
                li.Selected = true;
        }
    }
    public override void UpdateSettings()
    {
        base.UpdateSettings();

        DotNetNuke.Entities.Modules.ModuleController objModules3 = new DotNetNuke.Entities.Modules.ModuleController();
       
        objModules3.UpdateModuleSetting(ModuleId, "mode", rbl_mode.SelectedValue);
    }
}