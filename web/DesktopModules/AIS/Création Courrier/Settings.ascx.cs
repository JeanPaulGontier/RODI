using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Création_Courrier_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;
        PortalSettings portalSettings = new PortalSettings();
        int portalId = portalSettings.PortalId;
        DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();

        tbx_page.Text = "" + objModules.GetModuleSettings(ModuleId)["page"];
        tbx_role.Text = "" + objModules.GetModuleSettings(ModuleId)["role"];
        tbx_role_readonly.Text = "" + objModules.GetModuleSettings(ModuleId)["role_readonly"];
        tbx_path.Text = "" + objModules.GetModuleSettings(ModuleId)["path"];
        tbx_style.Text = "" + objModules.GetModuleSettings(ModuleId)["style"];
        tbx_impress.Text = "" + objModules.GetModuleSettings(ModuleId)["impress"];
        tbx_redirect.Text = "" + objModules.GetModuleSettings(ModuleId)["redirect"];
        tbx_article_gauche.Text = "" + objModules.GetModuleSettings(ModuleId)["article_gauche"];
        tbx_article_droite.Text = "" + objModules.GetModuleSettings(ModuleId)["article_droite"];
        tbx_article_detail_gauche.Text = "" + objModules.GetModuleSettings(ModuleId)["article_detail_gauche"];
        tbx_article_detail_droite.Text = "" + objModules.GetModuleSettings(ModuleId)["article_detail_droite"];

    }

    public override void UpdateSettings()
    {
        base.UpdateSettings();

        
        DotNetNuke.Entities.Modules.ModuleController objModules4 = new DotNetNuke.Entities.Modules.ModuleController();

        objModules4.UpdateModuleSetting(ModuleId, "page", tbx_page.Text);
        objModules4.UpdateModuleSetting(ModuleId, "role", tbx_role.Text);
        objModules4.UpdateModuleSetting(ModuleId, "role_readonly", tbx_role_readonly.Text);
        objModules4.UpdateModuleSetting(ModuleId, "path", tbx_path.Text);
        objModules4.UpdateModuleSetting(ModuleId, "style", tbx_style.Text);
        objModules4.UpdateModuleSetting(ModuleId, "impress", tbx_impress.Text);
        objModules4.UpdateModuleSetting(ModuleId, "redirect", tbx_redirect.Text);
        objModules4.UpdateModuleSetting(ModuleId, "article_gauche", tbx_article_gauche.Text);
        objModules4.UpdateModuleSetting(ModuleId, "article_droite", tbx_article_droite.Text);
        objModules4.UpdateModuleSetting(ModuleId, "article_detail_gauche", tbx_article_detail_gauche.Text);
        objModules4.UpdateModuleSetting(ModuleId, "article_detail_droite", tbx_article_detail_droite.Text);

    }
}