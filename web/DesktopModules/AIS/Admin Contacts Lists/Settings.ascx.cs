using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/** 

catégories par défaut pour clubs
 
Actions
Bulletin
Calendrier
Conférence
Divers
Galeries de photos
Lettre du président
in memoriam


catégories par défaut pour district

Actualités
Actions
Galeries de photos
Lettre du gouverneur
in memoriam

**/

public partial class DesktopModules_AIS_Admin_Contacts_Lists_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;

        ModuleController objModules = new ModuleController();
        string valueRBL = "" + Settings["mode"];
        foreach (ListItem li in mode.Items)
        {
            if (li.Value == valueRBL)
                li.Selected = true;
        }

        categories.Text = "" + Settings["categories"];

    }

    public override void UpdateSettings()
    {
        base.UpdateSettings();

        DotNetNuke.Entities.Modules.ModuleController objModules3 = new DotNetNuke.Entities.Modules.ModuleController();
        
        objModules3.UpdateModuleSetting(ModuleId, "mode", mode.SelectedValue);
        objModules3.UpdateModuleSetting(ModuleId, "categories", categories.Text);
    }

    protected void btreset_Click(object sender, EventArgs e)
    {
        if(mode.SelectedValue=="district")
            categories.Text = "Actualités\r\nActions\r\nGaleries de photos\r\nLettre du gouverneur\r\nin memoriam";
        else
            categories.Text = "Actions\r\nBulletin\r\nCalendrier\r\nConférence\r\nDivers\r\nGaleries de photos\r\nLettre du président\r\nin memoriam";
    }

}