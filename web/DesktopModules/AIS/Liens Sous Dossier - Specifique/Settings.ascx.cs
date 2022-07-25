using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using Dnn.PersonaBar.UI.Services;
using DotNetNuke.Entities.Tabs;
using ClientDependency.Core;

public partial class DesktopModules_AIS_Liens_Sous_Dossier___Specifique_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (("" + Settings["nbmax"]) == "")
                Settings["nbmax"] = "12";
            int n = 12;
            int.TryParse("" + Settings["nbmax"],out n);
            nbmax.Text = ""+n;
            sortby.SelectedValue = "" + Settings["sortby"];
            header.Text = "" + Settings["header"];
            footer.Text = "" + Settings["footer"];
            List<TabInfo> tabs = (from t in TabController.GetPortalTabs(PortalId, 0, true, true) orderby t.LocalizedTabName select t).ToList();
            parenttab.Items.Clear();
            foreach (TabInfo t in tabs)
            {
                string offset = "";
                //for (int i = 0; i < t.Level; i++)
                //    offset += "\xA0\xA0\xA0";
                
                parenttab.Items.Add(new ListItem(offset + t.LocalizedTabName,""+t.TabID));
                if (("" + Settings["parenttab"]) == "" + t.TabID)
                {
                    parenttab.SelectedIndex = parenttab.Items.Count - 1;
                }
            }
        }
    }
    public override void UpdateSettings()
    {
        base.UpdateSettings();

        var mc = new ModuleController();
        int n = 12;
        int.TryParse(nbmax.Text, out n);
        mc.UpdateModuleSetting(this.ModuleId, "nbmax", "" + n);
        mc.UpdateModuleSetting(this.ModuleId, "sortby", "" + sortby.SelectedValue);
        mc.UpdateModuleSetting(this.ModuleId, "header", "" + header.Text);
        mc.UpdateModuleSetting(this.ModuleId, "footer", "" + footer.Text);
        mc.UpdateModuleSetting(this.ModuleId, "parenttab", "" + parenttab.SelectedValue);

    }
}