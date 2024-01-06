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

        tbx_page.Text = "" + Settings["page"];
        tbx_role.Text = "" + Settings["role"];
        tbx_role_readonly.Text = "" + Settings["role_readonly"];
        tbx_path.Text = "" + Settings["path"];
        tbx_style.Text = "" + Settings["style"];
        tbx_impress.Text = "" + Settings["impress"];
        tbx_redirect.Text = "" + Settings["redirect"];
        tbx_article_gauche.Text = "" + Settings["article_gauche"];
        tbx_article_droite.Text = "" + Settings["article_droite"];
        tbx_article_detail_gauche.Text = "" + Settings["article_detail_gauche"];
        tbx_article_detail_droite.Text = "" + Settings["article_detail_droite"];

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

    protected void tb_reset_Click(object sender, EventArgs e)
    {
        tbx_page.Text = "Lettre du gouverneur";
        tbx_role.Text = "Rédacteur courrier District";
        tbx_role_readonly.Text = "Lecteur courrier District";
        tbx_path.Text = "District/LettreduGouverneur";
        tbx_style.Text = "MiniNews";
        tbx_impress.Text = "/lettre-du-gouverneur/print";
        tbx_redirect.Text = "/lettre-du-gouverneur/";
        tbx_article_gauche.Text = "FourGrid8";
        tbx_article_droite.Text = "FourGrid4";
        tbx_article_detail_gauche.Text = "FourGrid8";
        tbx_article_detail_droite.Text = "FourGrid4";
    }
}