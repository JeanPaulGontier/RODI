using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Admin_News_Liste_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;

        txtNotif1.Text = "" + Yemon.dnn.Helpers.GetItem("meeting:msgNotif1");
        txtNotif2.Text = "" + Yemon.dnn.Helpers.GetItem("meeting:msgNotif2");
        // ModuleController objModules = new ModuleController();

    }

    public override void UpdateSettings()
    {

        Yemon.dnn.Helpers.SetItem("meeting:msgNotif1", "" + HttpUtility.HtmlDecode(txtNotif1.Text), "" + UserId, keephistory: false);
        Yemon.dnn.Helpers.SetItem("meeting:msgNotif2", "" + HttpUtility.HtmlDecode(txtNotif2.Text), "" + UserId, keephistory: false);
        // base.UpdateSettings();

        //DotNetNuke.Entities.Modules.ModuleController objModules3 = new DotNetNuke.Entities.Modules.ModuleController();

        //objModules3.UpdateModuleSetting(ModuleId, "mode", "");
    }
}