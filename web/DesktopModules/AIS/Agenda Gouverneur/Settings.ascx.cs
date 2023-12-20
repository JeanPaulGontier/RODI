using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Agenda_Gouverneur_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            username.Text = "" + Settings["username"];
            password.Text = "" + Settings["password"];
            host.Text = "" + Settings["host"];
            int n = 0;
            int.TryParse("" + Settings["num"], out n);
            num.Text = "" + n;
        }
    }

    public override void UpdateSettings()
    {
        base.UpdateSettings();

        var mc = new ModuleController();
        mc.UpdateModuleSetting(this.ModuleId, "username", "" + username.Text.Trim().ToLower());
        if (!password.Text.Trim().ToLower().Equals(""))
            mc.UpdateModuleSetting(this.ModuleId, "password", "" + password.Text.Trim());
        if (!host.Text.Trim().ToLower().Equals(""))
            mc.UpdateModuleSetting(this.ModuleId, "host", "" + host.Text.Trim().ToLower());
        int n = 0;
        int.TryParse("" + num.Text, out n);
        mc.UpdateModuleSetting(this.ModuleId, "num", "" + n);
    }
}