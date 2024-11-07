
#region Copyrights

// RODI - https://rodi-platform.org
// Copyright (c) 2012-2024
// by SAS AIS : https://www.aisdev.net
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using System.IO;
using System.Drawing;
using DotNetNuke.Security.Roles;
using DotNetNuke.Entities.Users;
using AIS;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DotNetNuke.Common.Utilities;


public partial class DesktopModules_AIS_Admin_Mailing_Control : PortalModuleBase
{
    string param = "";

    DotNetNuke.Entities.Modules.ModuleController objModules2 = new DotNetNuke.Entities.Modules.ModuleController();
    string mode
    {
        get
        {
            return "" + Settings["mode"];

        }
    }
    string CHK_AR_0_TEXT
    {
        get
        {
            return CHK_AR_0.Text.Substring(2, 4);
        }
    }
    string CHK_AR_1_TEXT
    {
        get
        {
            return CHK_AR_1.Text.Substring(2, 4);
        }
    }

    public string Statut(string s)
    {
        switch(s){
            case "N":
                return "Brouillon";
            case "T":
                return "Envoyée";
            case "P":
                return "Préparation";
            case "E":
                return "Envoi";

        }
        return "";
    }

    /// <summary>
    /// Définit à quel groupe l'utilisateur appartient et affiche les éléments en fonction
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            RB_Dept.Enabled = (!DataMapping.isADG());
            LBL_Bureau_Filtre.Enabled = (!DataMapping.isADG());
            BT_Ajouter.Visible = (Functions.CurrentCric != 0);
            if (Functions.CurrentCric == 0)
                RefreshGrid();
            if ("" + Functions.CurrentCric != HF_Cric.Value)
            {
                HF_Cric.Value = "" + Functions.CurrentCric;
                GridView1.PageIndex = 0;
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel_Envoi.Visible = false;
            }

            int annee_0 = Functions.GetRotaryYear();
            // Member du DISTRICT
            UserInfo ui = PortalSettings.UserInfo;
            if ((ui.IsInRole(Const.ROLE_ADMIN_DISTRICT) == true ||
                ui.IsInRole(Const.ROLE_ADMIN_ROTARACT) == true) && 
                mode=="district")
            {
                Panel_District.Visible = true;
                BT_Ajouter.Visible = true;

                if (IsPostBack == false)
                {
                    // Peuplement des roles
                    RoleController ObjRoleController = new RoleController();
                    var arrRoles = ObjRoleController.GetRoles();
                    foreach (RoleInfo c in arrRoles)
                    {
                        if (c.RoleID > 4)
                        {
                            CHKList_Role.Items.Add(new ListItem("&nbsp;"+c.RoleName, c.RoleName));
                        }
                    }

                    // Peuplement des fonctions
                    List<string> liste_Fonctions = DataMapping.GetFunctions();
                    foreach (string s in liste_Fonctions)
                    {
                        CHKList_Fct.Items.Add(new ListItem("&nbsp;"+s, s));
                    }

                    // Peuplement des années rotariennes
                    CHK_AR_0.Text = "&nbsp;" + annee_0 + "/" + (annee_0 + 1);
                    CHK_AR_1.Text = "&nbsp;" + (annee_0 + 1) + "/" + (annee_0 + 2);
                  
                    // Peuplement du filtre departemental
                    List<Club> clubs = DataMapping.ListClubs(sort: tri.Value + " " + sens.Value);
                    RB_Role_Dept.Items.Clear();
                    var counts =
                    from c in clubs
                    orderby c.zip
                    group c by ((c.zip + "  ").Substring(0, 2).Replace("04", "06")).Trim() into g
                    select new { Cp = g.Key, Count = g.Count() };
                    RB_Role_Dept.Items.Add(new ListItem("Tous", "") { Selected = true });
                    foreach (var o in counts)
                    {
                        switch (o.Cp)
                        {
                            case "06":
                                RB_Role_Dept.Items.Add(new ListItem("Alpes-Maritimes", o.Cp));
                                break;
                            case "20":
                                RB_Role_Dept.Items.Add(new ListItem("Corse", o.Cp));
                                break;
                            case "83":
                                RB_Role_Dept.Items.Add(new ListItem("Var", o.Cp));
                                break;
                            case "98":
                                RB_Role_Dept.Items.Add(new ListItem("Monaco", o.Cp));
                                break;
                        }
                    }
                }

                // Custum image manager
                //string filename_Img = Functions.ClearFileName(@"~/Portals/0/District/Images");
                //TXT_Editor.ImageManager.ViewPaths = new string[] { filename_Img };
                //TXT_Editor.ImageManager.UploadPaths = new string[] { filename_Img };
                //TXT_Editor.ImageManager.DeletePaths = new string[] { filename_Img };

                // Custum document manager
                //string filename_Doc = Functions.ClearFileName(@"~/Portals/0/District");
                //TXT_Editor.DocumentManager.ViewPaths = new string[] { filename_Doc };
                //TXT_Editor.DocumentManager.UploadPaths = new string[] { filename_Doc };
                //TXT_Editor.DocumentManager.DeletePaths = new string[] { filename_Doc };


                //TXT_Editor.DocumentManager.MaxUploadFileSize = 4194304;
                //TXT_Editor.ImageManager.MaxUploadFileSize = 1048576;
            }
            else // Member CLUB
            {
                BT_Ajouter.Visible = false;
                P_Info.Visible = true;
                BTN_Copier.Visible=false;
                //Member m = Functions.GetCurrentMember();
                //if (m != null)
                //{
                //    if (m.cric == 0)
                //    {

                //    }
                //    else
                //    {
                Panel_Club.Visible = true;

                if (IsPostBack == false)
                {
                    List<Club> clubs = DataMapping.ListClubs(sort: tri.Value + " " + sens.Value);
                    RB_Dept.Items.Clear();
                    var counts =
                    from c in clubs
                    orderby c.zip
                    group c by ((c.zip+"  ").Substring(0, 2).Replace("04", "06")).Trim() into g
                    select new { Cp = g.Key, Count = g.Count() };
                    RB_Dept.Items.Add(new ListItem("Tous", "") { Selected = true });
                    foreach (var o in counts)
                    {
                        switch (o.Cp)
                        {
                            case "06":
                                RB_Dept.Items.Add(new ListItem("Alpes-Maritimes", o.Cp));
                                break;
                            case "20":
                                RB_Dept.Items.Add(new ListItem("Corse", o.Cp));
                                break;
                            case "83":
                                RB_Dept.Items.Add(new ListItem("Var", o.Cp));
                                break;
                            case "98":
                                RB_Dept.Items.Add(new ListItem("Monaco", o.Cp));
                                break;
                        }
                    }
                }

               
                //string filename_Img = Functions.ClearFileName(@"~/Portals/0/Clubs/" + Functions.CurrentClub.seo + "/Images"); //Documents

                //TXT_Editor.ImageManager.ViewPaths = new string[] { filename_Img };
                //TXT_Editor.ImageManager.UploadPaths = new string[] { filename_Img };
                //TXT_Editor.ImageManager.DeletePaths = new string[] { filename_Img };

                //string filename_Doc = Functions.ClearFileName(@"~/Portals/0/Clubs/" + Functions.CurrentClub.seo + "/Documents");
                //TXT_Editor.DocumentManager.ViewPaths = new string[] { filename_Doc };
                //TXT_Editor.DocumentManager.UploadPaths = new string[] { filename_Doc };
                //TXT_Editor.DocumentManager.DeletePaths = new string[] { filename_Doc };

                //TXT_Editor.Modules[0].Visible = false;
                //TXT_Editor.Modules[1].Visible = false;
                //TXT_Editor.Modules[2].Visible = false;
                //TXT_Editor.Modules[3].Visible = false;

                //TXT_Editor.DocumentManager.MaxUploadFileSize = 4194304;
                //TXT_Editor.ImageManager.MaxUploadFileSize = 1048576;
            }
            //}
            //}

            LBL_NB_Dest.Text = "Nombre de destinataire(s) : 0";

            if (mode == "club" && Functions.CurrentCric == 0)
            {
                Panel1.Visible = false;
                lbl_noClubSelected.Visible = true;
            }
            else if (mode == "district")
            {
                Functions.CurrentClub = null;
                lbl_noClubSelected.Visible = false;
            }
            else
            {
                //if (!Panel2.Visible || !Panel_Envoi.Visible || !Panel_Result.Visible)
                //    Panel1.Visible = true;
                lbl_noClubSelected.Visible = false;

            }

            RefreshGrid();

            
        }
        catch (Exception ee)
        {
      
            Functions.Error(new Exception(ee.InnerException+ee.StackTrace));
        }
         
    }

    /// <summary>
    /// Définit le script à exécuter lors d'une action sur le GridView1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Sort":

                break;
            case "detail":
                GridView gv = sender as GridView;
                int index = (gv.PageIndex * gv.PageSize) + Convert.ToInt32(e.CommandArgument);
                List<Newsletter> news = gv.DataSource as List<Newsletter>;
                
                Newsletter n = news[index];
                SelectNewsletter(n);
                break;

        }
    }

    protected void SelectNewsletter(Newsletter n)
    {
        HF_id.Value = "" + n.id;

        TXT_Titre.Text = "" + n.title;
        TXT_Dt.Text = n.dt.ToString("yyyy-MM-dd");
        TXT_Editor.Text = n.text;
        TXT_Exp_Nom.Text = n.sender_name;
        TXT_Exp_Email.Text = n.sender_email;

        lbl_date.Text = n.dt.ToString("dd/MM/yyyy");
        lbl_Sujet.Text = n.title;
        rad_Resutat.Text = n.text.Replace("<body", "<p").Replace("</body>", "</p>").Replace("<head>", "").Replace("</head>", "").Replace("<html", "<p").Replace("</html>", "</p>");

        string[] splits = n.recipient.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string s in splits)
        {
            switch (s.Substring(0, 2))
            {
                case "R:":
                    foreach (ListItem c in CHKList_Role.Items)
                    {
                        if (c.Value == s.Remove(0, 2))
                        {
                            c.Selected = true;
                        }
                    }
                    break;

                case "F:":
                    foreach (ListItem c in CHKList_Fct.Items)
                    {
                        if (c.Value == s.Remove(0, 2))
                        {
                            c.Selected = true;
                        }
                    }
                    break;

                case "D:":
                    string ss = s;
                    if (ss.Remove(0, 2) == "'06','04'")
                    {
                        ss = ss.Replace("'06','04'", "06");
                    }
                    ss = ss.Replace("'", "");

                    foreach (ListItem c in RB_Role_Dept.Items)
                    {
                        if (c.Value == ss.Remove(0, 2))
                        {
                            c.Selected = true;
                            RB_Role_Dept.SelectedIndex = RB_Role_Dept.Items.IndexOf(c);
                        }
                    }

                    foreach (ListItem c in RB_Dept.Items)
                    {
                        if (c.Value == ss.Remove(0, 2))
                        {
                            c.Selected = true;
                            RB_Dept.SelectedIndex = RB_Dept.Items.IndexOf(c);
                        }
                    }
                    break;

                case "B:":
                    if (s.Remove(0, 2) == "Secrétaire")
                    {
                        CHK_Bureau_Secr.Checked = true;
                    }
                    else if (s.Remove(0, 2) == "Président")
                    {
                        CHK_Bureau_Pres.Checked = true;
                    }
                    break;

                case "A:":
                    if (s.Remove(0, 2) == CHK_AR_0_TEXT)
                    {
                        CHK_AR_0.Checked = true;
                    }
                    else if (s.Remove(0, 2) == CHK_AR_1_TEXT)
                    {
                        CHK_AR_1.Checked = true;
                    }
                    break;

                case "M:":
                    CHK_All_Members.Checked = true;
                    break;
            }
        }

        List<Member> La_List = new List<Member>();
        if (n.recipient.Contains("R:") || n.recipient.Contains("F:"))
        {
            La_List = Recherche_District(out param);
        }
        else
        {
            La_List = Les_Destinataires(out param);
        }
        LBL_NB_Dest.Text = "Nombre de destinataire(s) : " + La_List.Count().ToString();

        switch (n.status)
        {
            case "N":
                if (n.club_type == Const.Club_Rotary && (
                    DataMapping.IsRotaract(PortalSettings.UserId) && 
                    !UserInfo.IsAdmin && 
                    !UserInfo.IsSuperUser && 
                    !UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)
                    ))// L'admin rotaract ne peut pas modifier les mailling de type rotary
                {
                    BT_Supprimer.Visible = false;
                    BT_Valider.Visible = false;
                    Panel2.Visible = true;
                    Panel_Test.Visible = false;
                }
                else
                {
                    BT_Supprimer.Visible = true;
                    BT_Valider.Visible = true;
                    Panel2.Visible = true;
                    Panel_Test.Visible = true;
                }

                Panel1.Visible = false;
                Panel_Envoi.Visible = false;
                Panel_Resultat_Test.Visible = false;
                CHK_Env.Checked = false;
                Panel_Result.Visible = false;
                LBL_Nb_E.Text = "";
                break;

            default:
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel_Envoi.Visible = false;
                Panel_Result.Visible = true;
                LBL_Nb_E.Text = "";
                break;

            case "P":
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel_Envoi.Visible = false;
                Panel_Result.Visible = true;
                LBL_Result.Text = "Préparation de la newsletter pour l'envoi.";
                LBL_Nb_E.Text = "";
                break;

            case "E":
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel_Envoi.Visible = false;
                Panel_Result.Visible = true;
                string mail_exp = DataMapping.Get_Nb_Mails_by_status(HF_id.Value, "TE");
                if (!string.IsNullOrEmpty(mail_exp))
                {
                    int nb_fait = 0;
                    int.TryParse(mail_exp, out nb_fait);
                    if (nb_fait > -1)
                    {
                        double percentage = (nb_fait * 100) / La_List.Count();
                        LBL_Result.Text = "Envoi de la newsletter en cours. " + percentage.ToString() + "% réalisé.";
                    }
                    else
                    {
                        LBL_Result.Text = "Envoi de la newsletter en cours.";
                    }
                    //LBL_Nb_E.Text = "La newsletter a été envoyée à " + mail_exp + " destinataire(s) sur les " + La_List.Count().ToString() + " destinataire(s) à qui elle est adressée.";
                }
                else
                {
                    LBL_Result.Text = "Envoi de la newsletter en cours.";
                }
                break;

            case "T":
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel_Envoi.Visible = false;
                Panel_Result.Visible = true;

                string nb_Mail_T = DataMapping.Get_Nb_Mails_by_status(HF_id.Value, "T");
                if (!string.IsNullOrEmpty(nb_Mail_T))
                {
                    int nb_fait = 0;
                    int.TryParse(nb_Mail_T, out nb_fait);
                    if (nb_fait > 0 && nb_fait == La_List.Count())
                    {
                        LBL_Result.Text = "L'envoi de la newsletter est terminé.";
                        LBL_Nb_E.Text = "La newsletter a été expédiée au(x) " + nb_Mail_T + " destinataire(s).";
                    }
                    else
                    {
                        string nb_Mail_E = DataMapping.Get_Nb_Mails_by_status(HF_id.Value, "E");
                        LBL_Result.Text = "L'envoi de la newsletter est terminé mais a rencontré des problèmes.";
                        //LBL_Nb_E.Text = "Sur les " + La_List.Count() + " destinataires de la newsletter, " + nb_Mail_T + " destinataire(s)  l'ont reçu et " + nb_Mail_E + " ne l'ont pas reçu.";

                        try
                        {
                            //SqlConnection conn = new SqlConnection(Config.GetConnectionString());
                            //conn.Open();

                            //SqlCommand sql = new SqlCommand("select N.nim as 'NIM',N.email as 'Email',M.nom_club as 'Club', erreur as 'Erreur' from ais_newsletters_out N,ais_members M where N.status='E' and N.nim = M.nim and newsletter_id=@newsletter_id", conn);
                            //sql.Parameters.AddWithValue("newsletter_id",""+HF_id.Value);
                            //SqlDataAdapter da = new SqlDataAdapter(sql);
                            //DataSet ds = new DataSet();
                            //da.Fill(ds);
                            //if (ds.Tables.Count > 0)
                            //{
                            //    GV_Emails_Erreur.DataSource = ds.Tables[0].DefaultView;
                            //    GV_Emails_Erreur.DataBind();
                            //    GV_Emails_Erreur.Visible = ds.Tables[0].Rows.Count > 0;
                            //    LBL_Titre_E.Visible = ds.Tables[0].Rows.Count > 0;
                            //}
                        }
                        catch (Exception ee)
                        {
                            Functions.Error(ee);
                        }
                    }

                    try
                    {
                        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
                        conn.Open();

                        SqlCommand sql = new SqlCommand("select count(*) from ais_newsletters_out N,ais_members M where N.status='E' and N.nim = M.nim and newsletter_id=@newsletter_id", conn);
                        sql.Parameters.AddWithValue("newsletter_id", "" + HF_id.Value);
                        int nberreur = int.Parse("" + sql.ExecuteScalar());

                        sql = new SqlCommand("select count(*) from ais_newsletters_out N where N.[read]!='N' and newsletter_id=@newsletter_id", conn);
                        sql.Parameters.AddWithValue("newsletter_id", "" + HF_id.Value);
                        int nblus = int.Parse("" + sql.ExecuteScalar());

                        sql = new SqlCommand("select count(*) from ais_newsletters_out N where N.[read]='N' and newsletter_id=@newsletter_id", conn);
                        sql.Parameters.AddWithValue("newsletter_id", "" + HF_id.Value);
                        int nbnonlus = int.Parse("" + sql.ExecuteScalar());
                        int total = nblus + nbnonlus;

                        LBL_NB_MSG_ERREUR.Text = nberreur + " (" + Math.Round(((float)nberreur * 100.0 / (float)total), 1) + "%)";
                        LBL_NB_MSG_LU.Text = nblus + " (" + Math.Round(((float)nblus * 100.0 / (float)total), 1) + "%)";
                        LBL_NB_MSG_NONLU.Text = nbnonlus + " (" + Math.Round(((float)nbnonlus * 100.0 / (float)total), 1) + "%)";

                    }
                    catch (Exception ee)
                    {
                        Functions.Error(ee);
                    }
                }


                break;
        

        }
    }


    /// <summary>
    /// Définit le type de tri sur le GridView1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        tri.Value = "" + e.SortExpression;
        sens.Value = sens.Value == "ASC" ? sens.Value = "DESC" : sens.Value = "ASC";
        RefreshGrid();
    }

    /// <summary>
    /// Actualise les nouvelles données lors du changement de page du GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (GridView1.PageIndex == e.NewPageIndex)
        {
            e.Cancel = true;
            return;
        }
        GridView1.PageIndex = e.NewPageIndex;
        RefreshGrid();
    }

    /// <summary>
    /// Actualise les données du GridView
    /// </summary>
    void RefreshGrid()
    {
        List<Newsletter> news = new List<Newsletter>();
        if(mode=="club")
        {
            if (Functions.CurrentCric == 0 && DataMapping.isADG())
            {
                List<Domain> listeDom = DataMapping.GetListDomain("ADG", "");
                foreach (Domain dom in listeDom)
                {
                    if (UserInfo.IsInRole(dom.subdomain))
                    {
                        foreach (Newsletter newsletter in DataMapping.ListNewsletters(cric: int.Parse(dom.value), index: GridView1.PageIndex, max: GridView1.PageSize))
                        {
                            news.Add(newsletter);
                        }

                    }
                }
            }
            else
            {
                news = DataMapping.ListNewsletters(cric: Functions.CurrentCric, index: GridView1.PageIndex, max: GridView1.PageSize);
            }
        }
        else
        {
            news = DataMapping.ListNewsletters();
        }
       
           

        GridView1.DataSource = news;
        GridView1.DataBind();
    }

    /// <summary>
    /// Actualise les données et affiche le panel de départ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Annuler_Click(object sender, EventArgs e)
    {
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel_Envoi.Visible = false;
        Panel_Result.Visible = false;
    }

    /// <summary>
    /// Crée ou modifie une newsletter en fonction des caractéristiques du membre
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        List<Member> La_List = new List<Member>();

        UserInfo ui = PortalSettings.UserInfo;
        if ((ui.IsInRole(Const.ROLE_ADMIN_DISTRICT) || ui.IsInRole(Const.ROLE_ADMIN_ROTARACT)) == true && Functions.CurrentCric == 0)
        {
            La_List = Recherche_District(out param);
        }
        else
        {
            La_List = Les_Destinataires(out param);
        }

        if (La_List != null)
        {
            if (La_List.Count > 0)
            {
                Newsletter obj = new Newsletter();
                if (HF_id.Value != "")
                {
                    obj = DataMapping.GetNewsletter(HF_id.Value);
                }
                else
                {
                    obj.status = "N";
                    obj.recipient = "";
                }
                obj.cric = Functions.CurrentCric;
                DateTime n= DateTime.Now;
                DateTime.TryParse("" + TXT_Dt.Text, out n);
                obj.dt = n;
                obj.text = Server.HtmlDecode(TXT_Editor.Text) + "<br />";
                obj.sender_email = TXT_Exp_Email.Text;
                obj.sender_name = TXT_Exp_Nom.Text;
                                
                if(DataMapping.IsRotaract(PortalSettings.UserId))
                {
                    obj.club_type = Const.Club_Rotaract;
                }
                else
                {
                    obj.club_type = Const.Club_Rotary;
                }

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    if (obj.text.Contains("src=\"/Portals/"))
                    {
                        obj.text = obj.text.Replace("src=\"/Portals/", "src=\"http://rodi1730.aisdev.net//Portals/");
                    }
                    if (obj.text.Contains("<a href=\"/Portals/"))
                    {
                        obj.text = obj.text.Replace("<a href=\"/Portals/", "<a href=\"http://rodi1730.aisdev.net/Portals/");
                    }
                }
                else
                {
                    if (obj.text.Contains("src=\"/Portals/"))
                    {
                        obj.text = obj.text.Replace("src=\"/Portals/", "src=\"http://" + Request.Url.Host + "/Portals/");
                    }
                    if (obj.text.Contains("<a href=\"/Portals/"))
                    {
                        obj.text = obj.text.Replace("<a href=\"/Portals/", "<a href=\"http://" + Request.Url.Host + "/Portals/");
                    }
                }

                obj.title = TXT_Titre.Text;
                obj.recipient = param;
                HF_Param.Value = param;

                bool result = true;
                string guid = Guid.NewGuid().ToString();
                if (obj.id == null)
                {
                    result = DataMapping.UpdateNewsletter(obj, guid);
                }
                else
                {
                    result = DataMapping.UpdateNewsletter(obj);
                }

                if (result == false)
                {
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(HF_id.Value))
                    {
                        HF_id.Value = guid;
                    }
                }


                RefreshGrid();
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel_Envoi.Visible = true;

                UserInfo user = PortalSettings.UserInfo;
                TBX_Email_Test.Text = user.Email;
                LBL_Nb_Env.Text = "La newsletter sera expédiée à " + La_List.Count + " destinataire(s).";
            }
            else
            {
                Functions.MessageBoxShow("Vous devez sélectionner au moins un destinataire", this);
            }
        }
        else
        {
            Functions.MessageBoxShow("La liste des destinataires est null", this);
        }


        
    }
   
    /// <summary>
    /// Affiche les champs permettant de créer une nouvelle NewsLetter
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Ajouter_Click(object sender, EventArgs e)
    {
        TXT_Exp_Nom.Text = "";
        TXT_Exp_Email.Text = "";
        HF_id.Value = "";
        if(mode=="club" && Functions.CurrentCric!=0)
        {
            Club club = Functions.CurrentClub;
            if(club!=null)
            {
                if (!String.IsNullOrEmpty(club.email))
                    TXT_Exp_Email.Text = club.email;
                TXT_Exp_Nom.Text = club.club_type.ToUpper() + " " + club.name;
            }
            
        }
        else if (mode == "district")
        {
            TXT_Exp_Email.Text = PortalSettings.Email;
            TXT_Exp_Nom.Text = Const.DISTRICT_TITLE;
        }
       
        if(TXT_Exp_Nom.Text=="")
            TXT_Exp_Nom.Text=UserInfo.DisplayName;
        if (TXT_Exp_Email.Text == "")
            TXT_Exp_Email.Text = UserInfo.Email;


        TXT_Titre.Text = "";
        TXT_Dt.Text = DateTime.Now.ToString("yyyy-MM-dd");
        TXT_Editor.Text = "";
        CHK_Bureau_Pres.Checked = false;
        CHK_Bureau_Secr.Checked = false;
        if (RB_Dept.Items.Count > 0)
        {
            RB_Dept.SelectedIndex = 0;
        }
        CHK_All_Members.Checked = false;
        
        foreach(ListItem i in CHKList_Role.Items)
        {
            i.Selected = false;
        }

        foreach(ListItem i in CHKList_Fct.Items)
        {
            i.Selected = false;
        }

        CHK_AR_0.Checked = false;
        CHK_AR_1.Checked = false;
        if (RB_Role_Dept.Items.Count > 0)
        {
            RB_Role_Dept.SelectedIndex = 0;
        }
        LBL_NB_Dest.Text = "Nombre de destinataire(s) : 0";
        TBX_Email_Test.Text = "";
        Panel_Test.Visible = true;
        Panel_Resultat_Test.Visible = false;
        CHK_Env.Checked = false;
        BTN_Env.Visible = false;

        BT_Supprimer.Visible = false;

        Panel2.Visible = true;
        Panel1.Visible = false;
        Panel_Envoi.Visible = false;
        Panel_Result.Visible = false;


    }

    /// <summary>
    /// Supprime une Newsletter, actualise les données et affiche le panel de départ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Supprimer_Click(object sender, EventArgs e)
    {
        if (!DataMapping.DeleteNewsletter(HF_id.Value))
        {
            return;
        }
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    #region membre CLUB

    /// <summary>
    /// Change le nombre de destinataires
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CHK_Bureau_Pres_CheckedChanged(object sender, EventArgs e)
    {
        //if(CHK_Bureau_Pres.Checked == true)
        //{
        //    string dept = "";
        //    if (RB_Dept.SelectedIndex > 0)
        //    {
        //        dept = "'" + RB_Dept.SelectedValue.Replace("06", "06','04") + "'"; // contournement du club qui est dans le 04
        //    }

        //    int annee_0 = Functions.GetAnneeRotarienne();

        //    HFD_Bureau_Pres.Value = "SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function]='Président' AND rotary_year = '" + annee_0.ToString() + "'";
        //    if(!string.IsNullOrEmpty(dept))
        //    {
        //        HFD_Bureau_Pres.Value = HFD_Bureau_Pres.Value + " AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(cp, 1, 2) IN (" + dept + ")))";
        //    }
        //    else
        //    {
        //        HFD_Bureau_Pres.Value = HFD_Bureau_Pres.Value + ")";
        //    }
        //}
        //else
        //{
        //    HFD_Bureau_Pres.Value = "";
        //}

        List<Member> La_List = Les_Destinataires(out param);
        LBL_NB_Dest.Text = "Nombre de destinataire(s) : " + La_List.Count().ToString();
    }

    /// <summary>
    /// Change le nombre de destinataires
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CHK_Bureau_Secr_CheckedChanged(object sender, EventArgs e)
    {
        //if (CHK_Bureau_Secr.Checked == true)
        //{
        //    string dept = "";
        //    if (RB_Dept.SelectedIndex > 0)
        //    {
        //        dept = "'" + RB_Dept.SelectedValue.Replace("06", "06','04") + "'"; // contournement du club qui est dans le 04
        //    }

        //    int annee_0 = Functions.GetAnneeRotarienne();

        //    HFD_Bureau_Secr.Value = "SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function]='Secrétaire' AND rotary_year = '" + annee_0.ToString() + "'";
        //    if (!string.IsNullOrEmpty(dept))
        //    {
        //        HFD_Bureau_Secr.Value = HFD_Bureau_Secr.Value + " AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(cp, 1, 2) IN (" + dept + ")))";
        //    }
        //    else
        //    {
        //        HFD_Bureau_Secr.Value = HFD_Bureau_Secr.Value + ")";
        //    }
        //}
        //else
        //{
        //    HFD_Bureau_Secr.Value = "";
        //}

        List<Member> La_List = Les_Destinataires(out param);
        LBL_NB_Dest.Text = "Nombre de destinataire(s) : " + La_List.Count().ToString();
    }

    /// <summary>
    /// Change le nombre de destinataires
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CHK_All_Members_CheckedChanged(object sender, EventArgs e)
    {
        //if(CHK_All_Members.Checked == true)
        //{
        //    HFD_All_Members.Value = "SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE cric='" + HF_Cric.Value + "'";
        //}
        //else
        //{
        //    HFD_All_Members.Value = "";
        //}

        List<Member> La_List = Les_Destinataires(out param);
        LBL_NB_Dest.Text = "Nombre de destinataire(s) : " + La_List.Count().ToString();
    }

    /// <summary>
    /// Change le nombre de destinataires
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RB_Dept_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string dept = "";
        //if (RB_Dept.SelectedIndex > 0)
        //{
        //    dept = "'" + RB_Dept.SelectedValue.Replace("06", "06','04") + "'"; // contournement du club qui est dans le 04
        //}

        //int annee_0 = Functions.GetAnneeRotarienne();

        //if (CHK_Bureau_Pres.Checked == true)
        //{
        //    HFD_Bureau_Pres.Value = "SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function]='Président' AND rotary_year = '" + annee_0.ToString() + "'";
        //    if (!string.IsNullOrEmpty(dept))
        //    {
        //        HFD_Bureau_Pres.Value = HFD_Bureau_Pres.Value + " AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(cp, 1, 2) IN (" + dept + ")))";
        //    }
        //    else
        //    {
        //        HFD_Bureau_Pres.Value = HFD_Bureau_Pres.Value + ")";
        //    }
        //}
        //else
        //{
        //    HFD_Bureau_Pres.Value = "";
        //}

        //if (CHK_Bureau_Secr.Checked == true)
        //{            
        //    HFD_Bureau_Secr.Value = "SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function]='Secrétaire' AND rotary_year = '" + annee_0.ToString() + "'";
        //    if (!string.IsNullOrEmpty(dept))
        //    {
        //        HFD_Bureau_Secr.Value = HFD_Bureau_Secr.Value + "AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(cp, 1, 2) IN (" + dept + ")))";
        //    }
        //    else
        //    {
        //        HFD_Bureau_Secr.Value = HFD_Bureau_Secr.Value + ")";
        //    }
        //}
        //else
        //{
        //    HFD_Bureau_Secr.Value = "";
        //}

        List<Member> La_List = Les_Destinataires(out param);
        LBL_NB_Dest.Text = "Nombre de destinataire(s) : " + La_List.Count().ToString();
    }

    /// <summary>
    /// Crée une liste de destinataires du le club
    /// </summary>
    /// <param name="parametres"></param>
    /// <returns>List de destinataires</returns>
    protected List<Member> Les_Destinataires(out string parametres)
    {
        parametres = "";
        List<Member> La_List = new List<Member>();
        List<Member> List_Members = new List<Member>();
        List<Member> List_President = new List<Member>();
        List<Member> List_Secretaire = new List<Member>();

        string dept = "";
        if (RB_Dept.SelectedIndex > 0)
        {
            dept = "'" + RB_Dept.SelectedValue.Replace("06", "06','04") + "'"; // contournement du club qui est dans le 04
            parametres = parametres + ";D:" + dept;
        }

        int annee_0 = Functions.GetRotaryYear();

        if(CHK_Bureau_Secr.Checked == true)
        {
            if (string.IsNullOrEmpty(dept) && !DataMapping.isADG())
            {
                List_Secretaire = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function]='Secrétaire' AND rotary_year = '" + annee_0.ToString() + "')");
            }
            else if (!DataMapping.isADG())
            {
                List_Secretaire = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function] = 'Secrétaire' AND rotary_year = '" + annee_0.ToString() + "'  AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(cp, 1, 2) IN (" + dept + ")))");
            }
            else
            {
                foreach (Domain dom in DataMapping.GetListDomain("ADG",""))
                {
                    if (UserInfo.IsInRole(dom.subdomain))
                    {
                        foreach (Member membre in DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function] = 'Secrétaire' AND rotary_year = '" + annee_0.ToString() +"' AND cric="+dom.value +" )"))
                        {
                            List_Secretaire.Add(membre);
                        }
                    }
                }
            }

            parametres = parametres + ";B:Secrétaire";
        }

        if(CHK_Bureau_Pres.Checked == true)
        {
            if (string.IsNullOrEmpty(dept) && !DataMapping.isADG())
            {
                List_President = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function]='Président' AND rotary_year = '" + annee_0.ToString() + "')");
            }
            else if (!DataMapping.isADG())
            {
                List_President = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function]='Président' AND rotary_year = '" + annee_0.ToString() + "' AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(cp, 1, 2) IN (" + dept + ")))");
            }
            else
            {
                foreach (Domain dom in DataMapping.GetListDomain("ADG", ""))
                {
                    if (UserInfo.IsInRole(dom.subdomain))
                    {
                        foreach (Member membre in DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function]='Président' AND rotary_year = '" + annee_0.ToString() + "' AND cric=" + dom.value + " )"))
                        {
                            List_President.Add(membre);
                        }
                    }
                }
            }
            parametres = parametres + ";B:Président";
        }

        if(CHK_All_Members.Checked == true)
        {
            if (HF_Cric.Value != ""+0)
                List_Members = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE cric='" + HF_Cric.Value + "'");
            else
                List_Members = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members");
            parametres = parametres + ";M:" + HF_Cric.Value;
        }

        if (List_Members != null)
        {
            foreach (Member m in List_Members)
            {
                La_List.Add(m);
            }
        }

        if(List_President != null)
        {
            foreach (Member mp in List_President)
            {
                if(!La_List.Exists(mem => mem.nim == mp.nim))
                {
                    La_List.Add(mp);
                }                
            }
        }

        if (List_Secretaire != null)
        {
            foreach (Member ms in List_Secretaire)
            {
                if (!La_List.Exists(mem => mem.nim == ms.nim))
                {
                    La_List.Add(ms);
                }
            }
        }

        if (parametres.StartsWith(";"))
        {
            parametres = parametres.Remove(0, 1);
        }

        return La_List;
    }
    #endregion membre CLUB

    #region membre DISTRICT   

    /// <summary>
    /// Change le nombre de destinataires
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RB_Role_Dept_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Member> La_List = Recherche_District( out param);
        LBL_NB_Dest.Text = "Nombre de destinataire(s) : " + La_List.Count().ToString();
    }

    /// <summary>
    /// Change le nombre de destinataires
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CHK_AR_1_CheckedChanged(object sender, EventArgs e)
    {
        List<Member> La_List = Recherche_District(out param);
        LBL_NB_Dest.Text = "Nombre de destinataire(s) : " + La_List.Count().ToString();
    }

    /// <summary>
    /// Change le nombre de destinataires
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CHK_AR_0_CheckedChanged(object sender, EventArgs e)
    {
        List<Member> La_List = Recherche_District(out param);
        LBL_NB_Dest.Text = "Nombre de destinataire(s) : " + La_List.Count().ToString();
    }
   
    /// <summary>
    /// Récupère les destinataires dans le District
    /// </summary>
    /// <param name="parametres"></param>
    /// <returns></returns>
    protected List<Member> Recherche_District(out string parametres)
    {
        parametres = "";
        List<Member> la_List = new List<Member>();
        List<Member> la_List_Fonction = new List<Member>();
        List<Member> La_List_Role = new List<Member>();

        #region extraction des critères de recherche
        List<string> Role_Select = new List<string>();
        foreach (ListItem c in CHKList_Role.Items)
        {           
                if (c.Selected == true)
                {
                    Role_Select.Add(c.Value);
                    parametres = parametres + ";R:" + c.Value;
                }
        }


        List<string> fonctions_Select = new List<string>();
        foreach (ListItem c in CHKList_Fct.Items)
        {
            if (c.Selected == true)
            {
                fonctions_Select.Add(c.Value);
                parametres = parametres + ";F:" + c.Value;
            }
        }

        List<string> AR_Select = new List<string>();
        foreach (Control c in Panel_AR.Controls)
        {
            if (c.GetType() == typeof(CheckBox)) //vérifier le casting
            {
                CheckBox chk = (CheckBox)c; //casting effectif
                if (chk.Checked == true)
                {
                    string t = chk.Text.Substring(6, 4);
                    AR_Select.Add(t);
                    parametres = parametres + ";A:" + t;
                }
            }
        }

        string dept = "";
        if (RB_Role_Dept.SelectedIndex > 0)
        {
            dept = "'" + RB_Role_Dept.SelectedValue.Replace("06", "06','04") + "'"; // contournement du club qui est dans le 04
            parametres = parametres + ";D:" + dept;
        }
        #endregion extraction des critères de recherche

        #region Recherche par fonctions
        string requete = " SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE ";
        if (fonctions_Select != null)
        {
            if (fonctions_Select.Count > 0)
            {
                string requete_AR = "";
                string requete_FCT = "";

                #region AR
                if (AR_Select != null)
                {
                    if (AR_Select.Count > 0)
                    {
                        if (AR_Select.Count == 1)
                        {
                            requete_AR = requete_AR + " rotary_year = '" + AR_Select[0] + "' ";
                        }
                        else
                        {
                            for (int i = 0; i < AR_Select.Count; i++)
                            {
                                if (i == 0)
                                {
                                    requete_AR = requete_AR + " (rotary_year = '" + AR_Select[i] + "' ";
                                }
                                else
                                {
                                    requete_AR = requete_AR + " OR rotary_year = '" + AR_Select[i] + "' ";
                                }
                            }
                            requete_AR = requete_AR + ")";
                        }
                    }
                    else //Si pas AR selectionné => année en cours sélectionné
                    {
                        int annee_0 = Functions.GetRotaryYear();
                        requete_AR = requete_AR + " rotary_year = '" + annee_0.ToString() + "'";
                    }
                }
                else
                {
                    int annee_0 = Functions.GetRotaryYear();
                    requete_AR = requete_AR + " rotary_year = '" + annee_0.ToString() + "'";
                }
                #endregion AR

                #region Fonction
                if (fonctions_Select.Count == 1)
                {
                    requete_FCT = requete_FCT + " AND [function]='" + fonctions_Select[0] + "' ";
                }
                else
                {
                    for (int i = 0; i < fonctions_Select.Count; i++)
                    {
                        if (i == 0)
                        {
                            requete_FCT = requete_FCT + " AND ([function]='" + fonctions_Select[i] + "' ";
                        }
                        else
                        {
                            requete_FCT = requete_FCT + " OR [function]='" + fonctions_Select[i] + "' ";
                        }
                    }
                    requete_FCT = requete_FCT + ")";
                }
                #endregion Fonction

                requete = requete + requete_AR + requete_FCT + " AND nim != 0 ) ";

                if(!string.IsNullOrEmpty(dept))
                {
                    requete = requete + " AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(cp, 1, 2) IN (" + dept + "))";
                }

                la_List_Fonction = DataMapping.GetListMembers_Mailling(requete);
            }
        }
        #endregion Recherche par fonctions

        #region Recherche par role
        if(Role_Select != null)
        {
            List<string> List_Email = new List<string>();
            RoleController ObjRoleController = new RoleController();
            foreach (string s in Role_Select)
            {
             
                var arrUsers = ObjRoleController.GetUsersByRoleName(PortalId, s);
                foreach (UserInfo u in arrUsers)
                {
                    if (!string.IsNullOrEmpty(u.Email))
                    {
                        // List_Email.Add("'" + u.Email + "'");
                        if(!la_List.Exists(m => m.email==u.Email)){
                            la_List.Add(new Member
                            {
                                email = u.Email,
                                name = u.FirstName,
                                surname = u.LastName,
                                district_id = Const.DISTRICT_ID,
                                userid = u.UserID
                            });
                        }
                        
                    }
                }
            }

            //string ListEmail = string.Join(",", List_Email);
            //La_List_Role = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE email IN (" + ListEmail + ") ");
        }

        //if (!string.IsNullOrEmpty(DL_Role.SelectedValue))
        //{
        //    List<string> List_Email = new List<string>();
        //    RoleController ObjRoleController = new RoleController();
        //    var arrUsers = ObjRoleController.GetUsersByRoleName(PortalId,DL_Role.SelectedValue);
        //    foreach(UserInfo u in arrUsers)
        //    {
        //        if (!string.IsNullOrEmpty(u.Email))
        //        {
        //            List_Email.Add("'" + u.Email + "'");
        //        }
        //    }
            
        //    string ListEmail = string.Join(",", List_Email);
        //    La_List_Role = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE email IN (" + ListEmail + ") ");
        //}
        #endregion Recherche par role


        if (la_List_Fonction != null)
        {
            foreach (Member m in la_List_Fonction)
            {
                la_List.Add(m);
            }
        }

        //if (La_List_Role != null)
        //{
        //    foreach (Member mp in La_List_Role)
        //    {
        //        if (!la_List.Exists(mem => mem.nim == mp.nim))
        //        {
        //            la_List.Add(mp);
        //        }
        //    }
        //}

        if(parametres.StartsWith(";"))
        {
            parametres = parametres.Remove(0, 1);
        }
       
        return la_List;
    }

    /// <summary>
    /// Change le nombre de destinataires
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CHKList_Role_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Member> La_List = Recherche_District(out param);
        LBL_NB_Dest.Text = "Nombre de destinataire(s) : " + La_List.Count().ToString();
    }
    #endregion membre DISTRICT

    #region Envoi

    /// <summary>
    /// Vérifie si l'envoi d'un mail s'est bien effectué
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_Test_Click(object sender, EventArgs e)
    {
        if(!DataMapping.Insert_Newsletter_Out(HF_id.Value, 0, TBX_Email_Test.Text, "A", ""))
        {
            Functions.MessageBoxShow("La newsletter de test n'a pas pu être envoyée.", this);
        }
        else
        {
            Panel_Test.Visible = false;
            Panel_Resultat_Test.Visible = true;
        }
    }

    /// <summary>
    /// Met à jour la newsletter
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_Env_Click(object sender, EventArgs e)
    {
         
        Newsletter obj = new Newsletter();
        if (HF_id.Value != "")
        {
            obj = DataMapping.GetNewsletter(HF_id.Value);
            obj.cric = Functions.CurrentCric;
            DateTime n=DateTime.Now;
            DateTime.TryParse("" + TXT_Dt.Text, out n);
            obj.dt = n;
            obj.text = Server.HtmlDecode(TXT_Editor.Text) + "<br />";
            if (System.Diagnostics.Debugger.IsAttached)
            {
                if (obj.text.Contains("src=\"/Portals/"))
                {
                    obj.text = obj.text.Replace("src=\"/Portals/", "src=\"http://rodi1730.aisdev.net//Portals/");
                }
                if (obj.text.Contains("<a href=\"/Portals/"))
                {
                    obj.text = obj.text.Replace("<a href=\"/Portals/", "<a href=\"http://rodi1730.aisdev.net/Portals/");
                }
            }
            else
            {
                if (obj.text.Contains("src=\"/Portals/"))
                {
                    obj.text = obj.text.Replace("src=\"/Portals/", "src=\"http://" + Request.Url.Host + "/Portals/");
                }
                if (obj.text.Contains("<a href=\"/Portals/"))
                {
                    obj.text = obj.text.Replace("<a href=\"/Portals/", "<a href=\"http://" + Request.Url.Host + "/Portals/");
                }
            }

            obj.title = TXT_Titre.Text;
            obj.recipient = HF_Param.Value;
            obj.status = "P";

            if (!DataMapping.UpdateNewsletter(obj))
            {
                Functions.MessageBoxShow("Une erreur est survenue lors de la mise à jour de la newsletter", this);
            }
            else
            {
                RefreshGrid();
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel_Envoi.Visible = false;
            }
        }        
    }

    /// <summary>
    /// Définit la visibilité du bouton d'envoi
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CHK_Env_CheckedChanged(object sender, EventArgs e)
    {
        if(CHK_Env.Checked ==true)
        {
            BTN_Env.Visible = true;
        }
        else
        {
            BTN_Env.Visible = false;
        }
    }
    #endregion Envoi

    /// <summary>
    /// Actualise les données et affiche le panel de départ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_Result_Click(object sender, EventArgs e)
    {
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel_Envoi.Visible = false;
        Panel_Result.Visible = false;
    }
   
    /// <summary>
    /// Exporte les messages vers un fichier Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTN_Export_Lists_Click(object sender, EventArgs e)
    {

        DataSet dslus = new DataSet();
        DataSet dsnonlus = new DataSet();
        DataSet dserreur = new DataSet();
        List<DataTable> liste = new List<DataTable>();

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());            
        try
        {
            conn.Open();
            SqlCommand sql = new SqlCommand("select N.nim as 'NIM',M.surname++' '++M.name as 'Nom',N.email as 'Email',M.club_name as 'Club' from ais_newsletters_out N,ais_members M where N.[read]!='N' and N.email = M.email and newsletter_id=@newsletter_id order by M.club_name,M.surname", conn);
            sql.Parameters.AddWithValue("newsletter_id", HF_id.Value);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(dslus);
            if (dslus.Tables.Count > 0)
            {
                dslus.Tables[0].TableName = "Lus";
                liste.Add(dslus.Tables[0]);
            }

            sql = new SqlCommand("select N.nim as 'NIM',M.surname++' '++M.name as 'Nom',N.email as 'Email',M.club_name as 'Club' from ais_newsletters_out N,ais_members M where N.[read]='N' and N.email = M.email and newsletter_id=@newsletter_id order by M.club_name,M.surname", conn);
            sql.Parameters.AddWithValue("newsletter_id", HF_id.Value);
            da = new SqlDataAdapter(sql);
            da.Fill(dsnonlus);
            if (dsnonlus.Tables.Count > 0)
            {
                dsnonlus.Tables[0].TableName = "Non lus";
                liste.Add(dsnonlus.Tables[0]);
            }

            sql = new SqlCommand("select N.nim as 'NIM',M.surname++' '++M.name as 'Nom',N.email as 'Email',M.club_name as 'Club', error as 'Erreur' from ais_newsletters_out N,ais_members M where N.status='E' and N.email = M.email and newsletter_id=@newsletter_id order by M.club_name,M.surname", conn);
            sql.Parameters.AddWithValue("newsletter_id", HF_id.Value);
            da = new SqlDataAdapter(sql);
            da.Fill(dserreur);
            if (dserreur.Tables.Count > 0)
            {
                dserreur.Tables[0].TableName = "Erreurs";
                liste.Add(dserreur.Tables[0]);
            }

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }

        Media media = DataMapping.ExportDataTablesToXLS(liste, "Lists des messages.xls", Aspose.Cells.SaveFormat.Excel97To2003);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    protected void BTN_Copier_Click(object sender, EventArgs e)
    {
        try
        {
            Newsletter n = DataMapping.GetNewsletter(HF_id.Value);
            n.id = null;
            n.status = "N";
            n.dt = DateTime.Now;
            n.title += " (copie)";
            string guid = Guid.NewGuid().ToString();
            
            if(DataMapping.UpdateNewsletter(n, guid)==true)
            {
                n.id = guid;
                SelectNewsletter(n);

            }
            
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

}