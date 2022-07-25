
#region Copyrights

// RODI - http://rodi.aisdev.net
// Copyright (c) 2012-2016
// by SAS AIS : http://www.aisdev.net
// supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730)
//
//GNU LESSER GENERAL PUBLIC LICENSE
//Version 3, 29 June 2007 Copyright (C) 2007
//Free Software Foundation, Inc. <http://fsf.org/> Everyone is permitted to copy and distribute verbatim copies of this license document, but changing it is not allowed.
//This version of the GNU Lesser General Public License incorporates the terms and conditions of version 3 of the GNU General Public License, supplemented by the additional permissions listed below.

//0. Additional Definitions.

//As used herein, "this License" refers to version 3 of the GNU Lesser General Public License, and the "GNU GPL" refers to version 3 of the GNU General Public License.
//"The Library" refers to a covered work governed by this License, other than an Application or a Combined Work as defined below.
//An "Application" is any work that makes use of an interface provided by the Library, but which is not otherwise based on the Library.Defining a subclass of a class defined by the Library is deemed a mode of using an interface provided by the Library.
//A "Combined Work" is a work produced by combining or linking an Application with the Library. The particular version of the Library with which the Combined Work was made is also called the "Linked Version".
//The "Minimal Corresponding Source" for a Combined Work means the Corresponding Source for the Combined Work, excluding any source code for portions of the Combined Work that, considered in isolation, are based on the Application, and not on the Linked Version.
//The "Corresponding Application Code" for a Combined Work means the object code and/or source code for the Application, including any data and utility programs needed for reproducing the Combined Work from the Application, but excluding the System Libraries of the Combined Work.

//1. Exception to Section 3 of the GNU GPL.

//You may convey a covered work under sections 3 and 4 of this License without being bound by section 3 of the GNU GPL.

//2. Conveying Modified Versions.

//If you modify a copy of the Library, and, in your modifications, a facility refers to a function or data to be supplied by an Application that uses the facility (other than as an argument passed when the facility is invoked), then you may convey a copy of the modified version:
//a) under this License, provided that you make a good faith effort to ensure that, in the event an Application does not supply the function or data, the facility still operates, and performs whatever part of its purpose remains meaningful, or
//b) under the GNU GPL, with none of the additional permissions of this License applicable to that copy.

//3. Object Code Incorporating Material from Library Header Files.

//The object code form of an Application may incorporate material from a header file that is part of the Library. You may convey such object code under terms of your choice, provided that, if the incorporated material is not limited to numerical parameters, data structure layouts and accessors, or small macros, inline functions and templates(ten or fewer lines in length), you do both of the following:
//a) Give prominent notice with each copy of the object code that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the object code with a copy of the GNU GPL and this license document.

//4. Combined Works.

//You may convey a Combined Work under terms of your choice that, taken together, effectively do not restrict modification of the portions of the Library contained in the Combined Work and reverse engineering for debugging such modifications, if you also do each of the following:
//a) Give prominent notice with each copy of the Combined Work that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the Combined Work with a copy of the GNU GPL and this license document.
//c) For a Combined Work that displays copyright notices during execution, include the copyright notice for the Library among these notices, as well as a reference directing the user to the copies of the GNU GPL and this license document.
//d) Do one of the following:
//0) Convey the Minimal Corresponding Source under the terms of this License, and the Corresponding Application Code in a form suitable for, and under terms that permit, the user to recombine or relink the Application with a modified version of the Linked Version to produce a modified Combined Work, in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.
//1) Use a suitable shared library mechanism for linking with the Library. A suitable mechanism is one that (a) uses at run time a copy of the Library already present on the user's computer system, and (b) will operate properly with a modified version of the Library that is interface-compatible with the Linked Version.
//e) Provide Installation Information, but only if you would otherwise be required to provide such information under section 6 of the GNU GPL, and only to the extent that such information is necessary to install and execute a modified version of the Combined Work produced by recombining or relinking the Application with a modified version of the Linked Version. (If you use option 4d0, the Installation Information must accompany the Minimal Corresponding Source and Corresponding Application Code. If you use option 4d1, you must provide the Installation Information in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.)

//5. Combined Libraries.

//You may place library facilities that are a work based on the Library side by side in a single library together with other library facilities that are not Applications and are not covered by this License, and convey such a combined library under terms of your choice, if you do both of the following:
//a) Accompany the combined library with a copy of the same work based on the Library, uncombined with any other library facilities, conveyed under the terms of this License.
//b) Give prominent notice with the combined library that part of it is a work based on the Library, and explaining where to find the accompanying uncombined form of the same work.

//6. Revised Versions of the GNU Lesser General Public License.

//The Free Software Foundation may publish revised and/or new versions of the GNU Lesser General Public License from time to time. Such new versions will be similar in spirit to the present version, but may differ in detail to address new problems or concerns.
//Each version is given a distinguishing version number. If the Library as you received it specifies that a certain numbered version of the GNU Lesser General Public License "or any later version" applies to it, you have the option of following the terms and conditions either of that published version or of any later version published by the Free Software Foundation. If the Library as you received it does not specify a version number of the GNU Lesser General Public License, you may choose any version of the GNU Lesser General Public License ever published by the Free Software Foundation.
//If the Library as you received it specifies that a proxy can decide whether future versions of the GNU Lesser General Public License shall apply, that proxy's public statement of acceptance of any version is permanent authorization for you to choose that version for the Library.

#endregion Copyrights


using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using Telerik.Web.UI;
using System.Drawing;
using System.IO;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using System.Drawing.Imaging;
using Aspose;
using System.Web.UI.HtmlControls;

public partial class DesktopModules_AIS_News_Mail_News_Mail : PortalModuleBase
{
    DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
    int tabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["tabid"], out t);
            return t;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RefreshDL();
            hfd_newsDistrict.Value = "";
            hfd_newsClub.Value = "";
        }
        
    }

    /// <summary>
    /// Lors du clic, récupère les nouvelles sélectionnées dans les deux datalists, crée le code HTML via la méthode creerTexte et envoie chaque nouvelle dans la table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_generer_Click(object sender, EventArgs e)
    {

        if (tbx_titre.Text!="" && TXT_Editor.Text!="") //On ne fait rien si les champs ne sont pas remplis
        {
            foreach (DataListItem item in dl_NewsDistrict.Items)
            {
                foreach (Control control in item.Controls)
                {
                    if (control.GetType() == typeof(CheckBox))
                    {
                        CheckBox cbx = (CheckBox)control;
                        if (cbx.Checked)
                        {
                            Label hl = (Label)item.Controls[5];
                            
                            hfd_newsDistrict.Value += hl.Text + "_"; //Pour chaque nouvelle sélectionnée, on récupère le titre et on l'ajoute dans le HiddenField
                        }

                    }
                }
            }


            foreach (DataListItem item in dl_NewsClub.Items)
            {
                foreach (Control control in item.Controls)
                {
                    if (control.GetType() == typeof(CheckBox))
                    {
                        CheckBox cbx = (CheckBox)control;
                        if (cbx.Checked)
                        {
                            Label hl = (Label)item.Controls[5];
                            hfd_newsClub.Value += hl.Text + "_"; //Pour chaque nouvelle sélectionnée, on récupère le titre et on l'ajoute dans le HiddenField
                        }

                    }
                }
            }
            Newsletter news = new Newsletter();
            news.text = creerTexte(hfd_newsDistrict.Value, hfd_newsClub.Value) + "<br />"; //Le texte de la newsletter est en fait un code HTML qui contient les images et les liens associés
            news.dt = DateTime.Now;
            news.recipient = "R:Membres";
            news.cric = 0;
            news.status = "N"; //Le message n'est pas envoyé. Ainsi, l'utilisateur peut le modifier
            news.club_type = "rotary";
            news.sender_email = UserInfo.Email;
            news.sender_name = UserInfo.DisplayName;
            news.title = tbx_titre.Text;
            DataMapping.UpdateNewsletter(news);

            hfd_newsClub.Value = "";
            hfd_newsDistrict.Value = "";

            Response.Redirect(Globals.NavigateURL(tabid));
        }
        
    }

    /// <summary>
    /// Retourne la date du debut de semaine
    /// </summary>
    /// <returns></returns>
    public string DebutSemaine()
    {
        DateTime date = DateTime.Now;
        int jour = DateTime.Now.Day;
        int mois = DateTime.Now.Month;
        int annee = DateTime.Now.Year;

        while (date.DayOfWeek.ToString()!="Monday") //On boucle tant que l'on n'est pas au début de la semaine
        {
            jour--;
            if (jour==0) //Si le jour est à 0, on se place au dernier jour du mois précédent
            {
                mois--;
                if (mois==0) //Si le mois est à 0, on se place au mois de décembre de l'année précédente
                {
                    annee--;
                    mois = 12;
                }
                
                jour = DateTime.DaysInMonth(annee, mois);
                
            }
            date = new DateTime(annee, mois, jour);
        }
        return annee + "-" + mois + "-" + jour; //On retourne une chaîne de caractère utilisable par la base de données
    }

    /// <summary>
    /// Rafraichit les deux DataLists
    /// </summary>
    public void RefreshDL()
    {
        try
        {
            List<News> newsDistrict = DataMapping.ListNewsMobile(0, "District", "", "", "", "dt", 0, 100, false, "dt >='" + DebutSemaine() + "'");
            if (newsDistrict.Count == 0)
                lbl_DlDistrictVide.Visible = true; //On affiche un Label disant qu'il n'y a aucune nouvelles ce mois-ci
            else
                lbl_DlDistrictVide.Visible = false;
            dl_NewsDistrict.DataSource = newsDistrict;
            dl_NewsDistrict.DataBind();

            List<News> newsClub = DataMapping.ListNewsMobile(0, "Clubs", "", "Bulletin", "", "dt", 0, 100, false, "dt >='" + DebutSemaine() + "'");
            if (newsClub.Count == 0)
                lbl_DlClubVide.Visible = true; //On affiche un Label disant qu'il n'y a aucune nouvelles ce mois-ci
            else
                lbl_DlClubVide.Visible = false;
            dl_NewsClub.DataSource = newsClub;
            dl_NewsClub.DataBind();

        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

    /// <summary>
    /// Associe les informations des nouvelles à la DataList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_NewsDistrict_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        News news = (News)e.Item.DataItem;

        if (news == null)
            throw new Exception ("Pas de nouvelles : item manquant");
        Label lbl_Titre = (Label)e.Item.FindControl("lbl_NewsDistrict");
        Label lbl_Date = (Label)e.Item.FindControl("lbl_DateNewsDistrict");

        var image = e.Item.FindControl("img_NewsDistrict") as System.Web.UI.WebControls.Image;
        image.ImageUrl = Functions.GetCorrectUrl("www.rotary1730.org" + news.GetPhoto());
        image.Visible = image.ImageUrl != "";
        image.Width = 100;
        lbl_Titre.Text = news.title;
        string date = "" + news.dt;
        string[] splits = date.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        lbl_Date.Text = splits[0]; //On n'affiche que la date, on retire l'heure

    }

    /// <summary>
    /// Associe les informations des nouvelles à la DataList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_NewsClub_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        News news = (News)e.Item.DataItem;

        if (news == null)
            throw new Exception("Pas de nouvelles : item manquant");

        Label lbl_Titre = (Label)e.Item.FindControl("lbl_NewsClub");
        Label lbl_Date = (Label)e.Item.FindControl("lbl_DateNewsClub");
        CheckBox cbx = (CheckBox)e.Item.FindControl("cbx_NewsClub");

        

        var image = e.Item.FindControl("img_NewsClub") as System.Web.UI.WebControls.Image;

        image.ImageUrl = Functions.GetCorrectUrl("www.rotary1730.org" + news.GetPhoto());
        image.Visible = image.ImageUrl != "";
        image.Width = 100;
        lbl_Titre.Text = news.title;
        string date = "" + news.dt;
        string[] splits = date.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        lbl_Date.Text = splits[0]; //On n'affiche que la date, on retire l'heure
        
    }

    /// <summary>
    /// Crée le code HTML qui sera la contenu du mail
    /// </summary>
    /// <param name="TitresNewssDistrict">Tous les noms des nouvelles du District séparés par un '_'</param>
    /// <param name="TitresNewssClub">Tous les noms des nouvelles des clubs séparés par un '_'</param>
    /// <returns></returns>
    public String creerTexteMael(string TitresNewssDistrict, string TitresNewssClub)
    {

        String css = "<style type=\"text / css\"> #outlook a { padding: 0; } .ReadMsgBody { width: 100%; } .ExternalClass { width: 100%; }  .ExternalClass* { line-height: 100%; }  body { margin: 0;  padding: 0;  -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;  } table, td {  border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; }  img { border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none; -ms-interpolation-mode: bicubic; } p { display: block; margin: 13px 0; } </style>";
        css += "<!--[if !mso]><!-->";
        css += "<style type=\"text/css\">   @import url(https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700); </style> ";
        css += "<style type=\"text/css\"> @media only screen and(max-width:480px) { @-ms-viewport { width: 320px; }  @viewport { width: 320px; }}</style>";
        css += "<link href=\"https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700\" rel=\"stylesheet\" type=\"text/css\" />";
        css += "<!--<![endif]-->";
        css += "<style type=\"text / css\">  @media only screen and (min-width:480px) { .mj-column-per-66, * [aria-labelledby=\"mj-column-per-66\"] { width: 66 % !important;}.mj-column-per-33, * [aria-labelledby=\"mj-column-per-33\"] { width: 33 % !important;}.mj-column-per-50, * [aria-labelledby=\"mj-column-per-50\"] {width: 50 % !important;} .mj-column-per-100, * [aria-labelledby=\"mj-column-per-100\"] {width: 100 % !important;  } } </style> ";
        String div = "<div style=\"margin: 0px auto; max-width: 600px; background: #ffffff none repeat scroll 0% 0%;\">";
        String divEnTete = "<div aria-labelledby=\"mj-column-per-50\" class=\"mj-column-per-50\" style=\"vertival-align: top; display: inline-block; font-size: 20px; color: #00246c; text-align:right; width: 100%;\">";


        String Text = css + "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"background-color: #e7e7e8;\"><tbody><tr><td><div style=\"background-color: #e7e7e8;\"><!--[if mso]><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" align=\"center\" style=\"width:600px;\"><tr><td><![endif]-->";
        Text += "<div style=\"margin: 0px auto; max-width: 600px; \"><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"font-size: 0px; width: 100%;\"><tbody ></tbody ></table ></div > ";
        Text += "<!--[if mso]></td></tr></table><![endif]-->";



        Text += "<!--[if mso]><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" align=\"center\" style=\"width:600px;\"><tr><td><![endif]-->";
        Text += div + twoColumns(divEnTete + " <img width=\"186\" height=auto alt\"Rotary-District 1730\" src=\"http://www.rotary1730.org/Portals/0/logo.png\" style=\"border: medium none; text-decoration: none; width :100%; height: auto;\" /></div>", divEnTete + "<span style=\"font-size: 20px; font-family: roboto, helvetica, arial, sans-serif;\">FLASH ACTION DISTRICT & CLUBS</span></div>");
        String divContent = "<div style=\"cursor : auto; color: #00246c; font-family: Georgia,Helvetica,Arial,sans-serif; font-size: 20px; line-height: 25px;\">";
        String spanBigTitle = "<span style=\"font-size: 25px; font-family: roboto, helvetica, arial,sans-serif; color: #00246c; \">";
        Text += "<!--[if mso]></td ></tr></table><![endif]--> ";
        Text += "<!--[if mso]><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" align=\"center\" style =\"width:600px;\"><tr><td><![endif]-->";
        Text += "<h3>" + spanBigTitle + " Edito </span></h3>";
        Text += divContent + TXT_Editor.Content + "</div>";
        String nbsp = "<p style=\"font-size: 1px; margin: 0px auto; border-top: 20px solid #e7e7e8; width: 100%; \">&nbsp;</p>";
        String line = "<p style=\"font-size: 1px; margin: 0px auto; border-top: 1px solid #e7e7e8; width: 100%; \">&nbsp;</p> <!--[if mso]><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:1px; margin: 0 auto; border-top:1px solid #e7e7e8;width:100%;\" width=\"600\"><tr><td> </td></tr></table><![endif]-->";

        Text += "</div>";
        Text += "<!--[if mso]></td></tr></table><![endif]-->";
        Text += "<!--[if mso]><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:1px; margin: 0 auto; border-top:20px solid #e7e7e8;width:100%;\" width=\"600\"><tr><td> </td></tr></table><![endif]-->";
        Text += div + "<h3>" + spanBigTitle + " District</span> </h3>";
        String spanDate = "<span style=\"align:right; font-size: 15px; font-family: roboto, helvetica, arial,sans-serif; color: #74585a; \">";
        String spanTitle = "<span style=\"align:left; font-size: 15px; font-family: roboto, helvetica, arial,sans-serif; color: #00246c; \">";


        if (TitresNewssDistrict != "")
        {
            string[] splitsDistr = TitresNewssDistrict.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries); //On sépare tous les titres des nouvelles du District afin de pouvoir récupérer les dites nouvelles

            if (splitsDistr.Count() != 0) //On ne crée le code HTML que s'il y a des nouvelles
            {
                for (int i = 0; i < splitsDistr.Count(); i++)
                {
                    News news = null;
                    List<News> listeNews = DataMapping.ListNewsMobile(0, "", "", "", "", "dt", 0, 100, false, "dt >='" + DebutSemaine() + "'");
                    foreach (News News in listeNews)
                    {
                        if (News.title == splitsDistr[i])
                        {
                            news = News;
                            break;
                        }
                    }

                    string date = "" + news.dt;
                    string[] DTsplit = date.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Text += "<!--[if mso]><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" align=\"center\" style=\"width:600px;\"><tr><td><![endif]-->";
                    Text += divContent + reduceImg(" <a href =\"" + Functions.GetCorrectUrl("rotary1730.aisdev.net/LesNouvelles/District.aspx?newsid=") + news.id + "&cric=0\" ><img width=\"550\" height=\"auto\" alt=\"" + news.title + "\" src=\"" + news.GetPhoto() + "\" style=\"border : medium none; display: block; outline: medium none; text-decoration: none; width: 100%; height: auto;\" />");
                    Text += "<!--[if mso]></td></tr></table><![endif]-->";
                    Text += "<!--[if mso]><table border =\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" align=\"center\" style=\"width:600px;\"><tr><td><![endif]-->";
                    Text += twoColumnsContent(spanTitle + news.title + " </span>", spanDate + DTsplit[0] + "</span>") + "</a>";
                    Text += "<!--[if mso]></td></tr></table><![endif]-->";
                    Text += "</div>";
                    if (splitsDistr.Count() > 1)
                        Text += line;
                }
            }
        }
        else
            Text += divContent + spanTitle + "Pas de news cette semaine </span></div>"; //S'il n'y a pas de nouvelles, on affiche ce texte

        Text += "<!--[if mso]><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:1px; margin: 0 auto; border-top:20px solid #e7e7e8;width:100%;\" width=\"600\"><tr><td> </td></tr></table><![endif]-->";

        Text += "</div>" + div + "<h3>" + spanBigTitle + " Clubs </span></h3>";

        if (TitresNewssClub != "")
        {
            string[] splitsClub = TitresNewssClub.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);//On sépare tous les titres des nouvelles des clubs afin de pouvoir récupérer les dites nouvelles

            if (splitsClub.Count() != 0)
            {
                for (int i = 0; i < splitsClub.Count(); i++)
                {
                    News news = null;
                    List<News> listeNews = DataMapping.ListNewsMobile(Functions.CurrentCric, "", "", "", "", "dt", 0, 100, false, "dt >='" + DebutSemaine() + "'");
                    foreach (News News in listeNews)
                    {
                        if (News.title == splitsClub[i])
                        {
                            news = News;
                            break;
                        }
                    }

                    string date = "" + news.dt;
                    string[] DTsplit = date.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Text += "<!--[if mso]><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" align=\"center\" style=\"width:600px;\"><tr><td><![endif]-->";
                    Text += divContent + reduceImg("<a href=\"" + Functions.GetCorrectUrl("rotary1730.aisdev.net/LesNouvelles/Clubs.aspx?newsid=") + news.id + "&cric=" + news.cric + "\" > <img width=\"550\" height=\"auto\" alt=\"" + news.title + "\" src=\"" + news.GetPhoto() + "\" style=\"border : medium none; display: block; outline: medium none; text-decoration: none; width: 100%; height: auto;\" />");
                    Text += "<!--[if mso]></td></tr></table><![endif]-->";
                    Text += "<!--[if mso]><table border =\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"600\" align=\"center\" style=\"width:600px;\"><tr><td><![endif]-->";
                    Text += twoColumnsContent(spanTitle + news.title + "</span>", spanDate + DTsplit[0] + "</span>") + "</a>";
                    Text += "<!--[if mso]></td></tr></table><![endif]-->";
                    Text += "</div>";
                    if (splitsClub.Count() > 1)
                        Text += line;
                }
            }

            Text += "</div>";
        }
        else
            Text += divContent + spanTitle + "Pas de news cette semaine </span></div>"; //S'il n'y a pas de nouvelles, on affiche ce texte

        Text += "<!--[if mso]><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:1px; margin: 0 auto; border-top:20px solid #e7e7e8;width:100%;\" width=\"600\"><tr><td> </td></tr></table><![endif]-->";

        Text += nbsp + div + twoColumns(divEnTete + "<a href=\"http://0z0q.mj.am/link/0z0q/pxpwk/18/ZRDVvO8kWqUkZnMDRWOV8g/aHR0cHM6Ly93d3cuZmFjZWJvb2suY29tL1JvdGFyeTE3MzAvP3JlZj10cyZmcmVmPXRz\" target=\"_blank\"><img width=\"200\" height=\"auto\" alt=\"Suivez nous sur Facebook\" src=\"http://0z0q.mj.am/img/0z0q/b/151x4/rnh6.jpeg\" style=\"border: medium none; display: block; outline: medium none; text-decoration: none; width: 100%; height: auto;\"/></a></div>", divEnTete + "<a href=\"http://0z0q.mj.am/link/0z0q/pxpwk/19/DhBpMmuFGW6HXBRmUhg1Zg/aHR0cHM6Ly90d2l0dGVyLmNvbS9Sb3RhcnkxNzMw\" target=\"_blank\"><img width=\"200\" height=\"auto\" alt=\"Suivez nous sur Twitter\" src=\"http://0z0q.mj.am/img/0z0q/b/151x4/rnhh.jpeg\" style=\"border: medium none; display: block; outline: medium none; text-decoration: none; width: 100%; height: auto;\"/></a></div>") + "</div>";
        Text += "</div></td></tr></tbody></table>";
        return Text;
    }

    public String creerTexte(string TitresNewssDistrict, string TitresNewssClub)
    {

        string text = "";

        try {
            string entete = File.ReadAllText(Server.MapPath(AppRelativeTemplateSourceDirectory + "entete.txt"));
            string edito = File.ReadAllText(Server.MapPath(AppRelativeTemplateSourceDirectory + "edito.txt"));
            string district = File.ReadAllText(Server.MapPath(AppRelativeTemplateSourceDirectory + "district.txt"));
            string clubs = File.ReadAllText(Server.MapPath(AppRelativeTemplateSourceDirectory + "clubs.txt"));
            string corps = File.ReadAllText(Server.MapPath(AppRelativeTemplateSourceDirectory + "corps.txt"));
            string pied = File.ReadAllText(Server.MapPath(AppRelativeTemplateSourceDirectory + "pied.txt"));


            edito = edito.Replace("@edito@", TXT_Editor.Text);

            string temp = "";

            text = entete + edito + district;

            if (TitresNewssDistrict != "")
            {
                string[] splitsDistr = TitresNewssDistrict.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries); //On sépare tous les titres des nouvelles du District afin de pouvoir récupérer les dites nouvelles

                if (splitsDistr.Count() != 0) //On ne crée le code HTML que s'il y a des nouvelles
                {
                    for (int i = 0; i < splitsDistr.Count(); i++)
                    {
                        News news = null;
                        List<News> listeNews = DataMapping.ListNewsMobile(0, "", "", "", "", "dt", 0, 100, false, "dt >='" + DebutSemaine() + "'");
                        foreach (News News in listeNews)
                        {
                            if (News.title == splitsDistr[i])
                            {
                                news = News;
                                break;
                            }
                        }

                        if (news != null)
                        {
                            string date = "" + news.dt;
                            string[] DTsplit = date.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            temp = corps;

                            temp = corps.Replace("@title@", news.title);
                            temp = temp.Replace("@link@", Functions.GetCorrectUrl("www.rotary1730.org/LesNouvelles/District.aspx?newsid=") + news.id + "&cric=0");
                            temp = temp.Replace("@img@", Functions.GetCorrectUrl("www.rotary1730.org"+news.GetPhoto()));
                            temp = temp.Replace("@date@", DTsplit[0]);


                            text = text + temp;
                        }
                    }
                }
            }

            text = text + clubs;

            if (TitresNewssClub != "")
            {
                string[] splitsClub = TitresNewssClub.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);//On sépare tous les titres des nouvelles des clubs afin de pouvoir récupérer les dites nouvelles

                if (splitsClub.Count() != 0)
                {
                    List<News> listeNews = DataMapping.ListNewsMobile(Functions.CurrentCric, "", "", "", "", "dt", 0, 100, false, "dt >='" + DebutSemaine() + "'");

                    for (int i = 0; i < splitsClub.Count(); i++)
                    {
                        News news = null;
                        foreach (News News in listeNews)
                        {
                            if (News.title == splitsClub[i])
                            {
                                news = News;
                                break;
                            }
                        }

                        if(news != null)
                        { 
                            string date = "" + news.dt;
                            string[] DTsplit = date.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            temp = corps;

                            temp = corps.Replace("@title@", news.title);
                            temp = temp.Replace("@link@",Functions.GetCorrectUrl("www.rotary1730.org/LesNouvelles/Clubs.aspx?newsid=") + news.id + "&cric=" + news.cric);
                            temp = temp.Replace("@img@", Functions.GetCorrectUrl("www.rotary1730.org" + news.GetPhoto()));
                            temp = temp.Replace("@date@", DTsplit[0]);


                            text = text + temp;
                        }

                    }
                }

            
            }

            text = text + pied;

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    
        return text;
    }

    private String twoColumns(String column1, String column2)
    {
        String table="<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"font-size: 0px; width: 100%; background: #ffffff none repeat scroll 0% 0%;\"><tbody><tr>";
        String lineTable="<td style=\"text-align: center; vertical-align: middle; font-size: 0px; padding: 0px 0px 20px;\">";
        String endTable="</tr></tbody></table>";

        return table+ lineTable + column1 + "</td>" + lineTable + column2 + "</td>" + endTable;
    }

    private String twoColumnsContent(String column1, String column2)
    {
        String table="<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"font-size: 0px; width: 100%; background: #ffffff none repeat scroll 0% 0%;\"><tbody><tr>";
        String lineLeftTable="<td style=\"text-align: left; vertical-align: middle; font-size: 0px; padding: 0px 25px;\">";
        String lineRightTable="<td style=\"text-align: right; vertical-align: middle; font-size: 0px; padding: 10px 25px;\">";
        String endTable="</tr></tbody></table>";

        return table + lineLeftTable + column1 + "</td>" + lineRightTable + column2 + "</td>" + endTable;
    }

    private String reduceImg(String img)
    {
        String divTable="<div aria-labelledby=\"mj-column-per-100\" class=\"mj-column-per-100\" style=\"vertical-align: top; display: inline-block; font-size: 13px; text-align: left; width: 100%;\">";
        String table="<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr>";
        String td="<td align=\"center\" style=\"font-size: 0px; padding: 0px 25px;\">";
        String table2="<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\" style=\"border-collapse: collapse; border-spacing: 0px;\"><tbody><tr>";
        String td2="<td style=\"width: 550px;\">";

        return table + td + table2+ td2+ img + "</td></tr></tbody></table></td></tr></tbody></table>";
    }
}
