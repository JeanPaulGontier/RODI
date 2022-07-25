using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Common.Utilities;
using System.Data;
using System.Data.SqlClient;
using DotNetNuke.Entities.Portals;
using System.Text;
using System.Collections;
using DotNetNuke.Services.Mail;
using AIS;

public partial class DesktopModules_Contact : DotNetNuke.Entities.Modules.PortalModuleBase
{
    Club club;
    protected void Page_Load(object sender, EventArgs e)
    {
        club = DataMapping.GetClubBySeo("" + Request["sn"]);
        pnl_Formulaire.Visible = (club != null && !club.email.Equals(""));
    }


    protected void btn_Valider_Click(object sender, EventArgs e)
    {
        if (!CaptchaDnnControl.IsValid)
            return;

        try
        {
           

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Un message vous a été envoyé par : " + tbx_nom.Text);
            sb.AppendLine("");
            if(!string.IsNullOrEmpty(tbx_Tel.Text))
            {
                sb.AppendLine("Téléphone : " + tbx_Tel.Text);
                sb.AppendLine("");
            }
            sb.AppendLine("E-mail : " + tbx_mail.Text);
            sb.AppendLine("");
            sb.AppendLine("Voici son message :");
            sb.AppendLine("" + tbx_message.Text);

            string subject = "Message envoyé depuis la page contact du club " +(club!=null?club.name:"") ;

            if (club != null && !club.email.Equals(""))
            {
                Functions.SendMail(tbx_mail.Text, club.email, subject, sb.ToString());
            }
           

            pnl_Formulaire.Visible = false;
            P2.Visible = true;      
        }
        catch(Exception ee)
        {

            Functions.Error(ee);
        }
    }

    protected void btn_Annuler_Click(object sender, EventArgs e)
    {
        try
        {
            CleartextBoxes(this);
        }
        catch(Exception ee)
        {
            //Functions.Error(ee);
        }
    }

 

    public void CleartextBoxes(Control parent)
    {

        foreach (Control c in parent.Controls)
        {
            if ((c.GetType() == typeof(TextBox)))
            {

                ((TextBox)(c)).Text = "";
            }

            if (c.HasControls())
            {
                CleartextBoxes(c);
            }
        }
    }  
}