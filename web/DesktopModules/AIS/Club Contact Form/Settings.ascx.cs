using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using System.Data.SqlClient;
using System.Data.Odbc;
using DotNetNuke.Common.Utilities;
//using AIS;

public partial class DesktopModules_BBPEnregistrement_Settings : ModuleSettingsBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public override void LoadSettings()
    {
        base.LoadSettings();

        try
        {
            //Domaine domMail = DataMapping.getDomaine("fr-FR", "contact", "mail_exp_contact");
            //if (domMail != null)
            //{
            //    tbx_mail.Text = "" + domMail.valeur;
            //    hfd_mail.Value = "" + domMail.id;
            //}

            //Domaine domSujet = DataMapping.getDomaine("fr-FR", "contact", "sujet_contact");
            //if (domSujet != null)
            //{
            //    tbx_sujet.Text = "" + domSujet.valeur;
            //    hfd_mail.Value = "" + domSujet.id;
            //}

            //Domaine domMess = DataMapping.getDomaine("fr-FR", "contact", "message_contact");
            //if (domMess != null)
            //{
            //    tbx_message.Text = "" + domMess.valeur;
            //    hfd_message.Value = "" + domMess.id;
            //}
        }
        catch (Exception ee)
        {
            //Functions.Error(ee);
        }

        //    DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
        //    int tabid = 0;
        //    int.TryParse("" + objModules.GetModuleSettings(ModuleId)["tabid"], out tabid);
        //    TabID.DataTextField = "Text";
        //    TabID.DataValueField = "Value";
        //    TabID.DataSource = Functions.GetListItemsFromTabs(tabid);
        //    TabID.DataBind();
        //    TabID.SelectedValue = "" + tabid;

        //    int categorie = 1;
        //    int.TryParse("" + objModules.GetModuleSettings(ModuleId)["categorie"], out categorie);

        //    TabCategorie.DataBind();
        //    TabCategorie.SelectedValue = ""+categorie;
    }

    public override void UpdateSettings()
    {
        base.UpdateSettings();

        try
        {
            //Domaine domMail = new Domaine();
            //int id = 0;
            //int.TryParse(("" + hfd_mail.Value), out id);
            //domMail.id = id;
            //domMail.culture = "fr-FR";
            //domMail.domaine = "contact";
            //domMail.libelle = "mail_exp_contact";
            //domMail.valeur = "" + tbx_mail.Text.Trim().ToLower();

            //if (!DataMapping.DeleteInsertDomaine(domMail))
            //{
            //    Response.Write("<script>alert('Le mail n'a pas pu être sauvegardé !');</script>");
            //}

            //Domaine domSujet = new Domaine();
            //int idSujet = 0;
            //int.TryParse(("" + hfd_sujet.Value), out idSujet);
            //domSujet.id = id;
            //domSujet.culture = "fr-FR";
            //domSujet.domaine = "contact";
            //domSujet.libelle = "sujet_contact";
            //domSujet.valeur = "" + tbx_sujet.Text.Trim();

            //if (!DataMapping.DeleteInsertDomaine(domSujet))
            //{
            //    Response.Write("<script>alert('Le sujet n'a pas pu être sauvegardé !');</script>");
            //}

            //Domaine domMessage = new Domaine();
            //int idMess = 0;
            //int.TryParse(("" + hfd_message.Value), out idMess);
            //domMessage.id = id;
            //domMessage.culture = "fr-FR";
            //domMessage.domaine = "contact";
            //domMessage.libelle = "message_contact";
            //domMessage.valeur = "" + tbx_message.Text.Trim();

            //if (!DataMapping.DeleteInsertDomaine(domMessage))
            //{
            //    Response.Write("<script>alert('Le message n'a pas pu être sauvegardé !');</script>");
            //}

        }
        catch (Exception ee)
        {
            //Functions.Error(ee);
        }

    //    DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
    //    objModules.UpdateModuleSetting(ModuleId, "tabid", TabID.SelectedValue);
    //    objModules.UpdateModuleSetting(ModuleId, "categorie", TabCategorie.SelectedValue);
    }
         
    
}