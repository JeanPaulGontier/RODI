using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;


public partial class AIS_PresentationMembreMobile : System.Web.UI.Page
{
    int UserIdQuery = 0;
    Member member = null;
    Affectation affectation;
    AIS.Content content;

    protected void Page_Load(object sender, EventArgs e)
    {
        int.TryParse("" + Request.QueryString["UserId"], out UserIdQuery);

       

        if (UserIdQuery > 0)
        {
            if (DataMapping.Sub_Active(UserIdQuery, "PagePro") == true) //La page est accessible par superuser, par le membre propriétaire même si l'abonnement est inactif
            {
                member = DataMapping.GetMemberByUserID(UserIdQuery);

                if (member != null && member.id != null && member.id > 0 && member.nim > 0)
                {
                    affectation = DataMapping.GetAffectation(member.nim, DateTime.Now.Year);
                    content = DataMapping.GetContentPagePro(UserIdQuery);

                    Binding_Panel2();
                }                
                else
                {
                    //if (PortalSettings.HomeTabId > 0)
                    //{
                    //    Response.Redirect(Globals.NavigateURL(PortalSettings.HomeTabId), true);
                    //}
                    //else
                    //{
                    //    Response.Redirect(Globals.GetPortalDomainName(PortalSettings.PortalAlias.HTTPAlias, Request, true), true);
                    //}
                }
            }
            else
            {
                //if (PortalSettings.HomeTabId > 0)
                //{
                //    Response.Redirect(Globals.NavigateURL(PortalSettings.HomeTabId), true);
                //}
                //else
                //{
                //    Response.Redirect(Globals.GetPortalDomainName(PortalSettings.PortalAlias.HTTPAlias, Request, true), true);
                //}
            }
        }
        else
        {
            //if (PortalSettings.HomeTabId > 0)
            //{
            //    Response.Redirect(Globals.NavigateURL(PortalSettings.HomeTabId), true);
            //}
            //else
            //{
            //    Response.Redirect(Globals.GetPortalDomainName(PortalSettings.PortalAlias.HTTPAlias, Request, true), true);
            //}
        }
    }

    protected void Binding_Panel2()
    {
        string nom = "";
        if (member != null && member.id != null && member.id > 0)
        {
            nom = nom + member.name + "  " + member.surname;
        }

        if (content != null)
        {
            if (!string.IsNullOrEmpty(content.text))
            {
                LTL_Texte2.Text = content.text;
            }

            if (!string.IsNullOrEmpty(content.title))
            {
                LBL_Titre2.Text = content.title;
            }

        }

    }
    
}