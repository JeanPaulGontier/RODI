﻿
#region Copyrights

// RODI - https://rodi-platform.org
// Copyright (c) 2012-2025
// by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730)
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
using AIS;
using DotNetNuke.Entities.Modules;
using System.Data.SqlClient;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Security.Roles;
using DotNetNuke.Common;
using System.Collections;
using DotNetNuke.Entities.Users;
using System.Data;

public partial class DesktopModules_AIS_Club_AAR_Control : PortalModuleBase
{
    int nbError = 0;
    List<Member> members = new List<Member>();

    /// <summary>
    /// Crée dynamiquement un panel
    /// </summary>
    /// <param name="e"></param>
    protected override void OnLoad(EventArgs e)
    {
        CreatePanel();
        base.OnLoad(e);
        
    }
   
    /// <summary>
    /// Supprime le contenu des controles et les synchronise à nouveau
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_choisirClub.Visible = (Functions.CurrentCric == 0);
        RB_AR.Visible = (Functions.CurrentCric != 0);
        LBL_AR.Visible = (Functions.CurrentCric != 0);
        if (!Page.IsPostBack)
        {
            RB_AR.Items.Clear();
            int rotary_year = Functions.GetRotaryYear();

            RB_AR.Items.Add(new ListItem() { Text = "" + rotary_year + "-" + (rotary_year + 1), Value = "" + rotary_year, Selected = true });
            RB_AR.Items.Add(new ListItem() { Text = "" + (rotary_year + 1) + "-" + (rotary_year + 2), Value = "" + (rotary_year + 1) });
            RB_AR.Items.Add(new ListItem() { Text = "" + (rotary_year + 2) + "-" + (rotary_year + 3), Value = "" + (rotary_year + 2) });
            
        }

        // si le controle de sélecteur de club est sur la meme page (exemple admin district)
        // alors on vérifie s'il a été activé pour changer de club
        // dans ce cas on doit revaloriser les controles de fonctions
        if (HF_Cric.Value != Functions.CurrentCric + "")
        {
            SetPanel();
            HF_Cric.Value = "" + Functions.CurrentCric;
        }

    }
    
    /// <summary>
    /// Crée dynamiquement un panel contenant les DropDownList permettant la modification des AAR
    /// </summary>
    void CreatePanel()
    {
        BT_Valider.Style.Add("visibility", "hidden");


        int cric = Functions.CurrentCric;
        Panel1.Controls.Clear();
        if (cric == 0)
            return;

        nbError = 0;

        members = DataMapping.ListMembers(cric, sort: "surname asc");
        // avant on utlisait la liste des affectations déjà données dans un club pour générer la droplist
        // maintenant on utilise un domaine de valeurs
        //List<string> fonctions = DataMapping.ListFunctionsRY(cric);
        List<Domain> lst = DataMapping.GetListDomain("RYA","");
        List<string> fonctions = new List<string>();
        foreach (Domain d in lst)
            fonctions.Add(d.value);

            
        foreach (string fonction in fonctions)
        {

            Literal lit = new Literal();
            lit.Text = "<div class='row'>";
            Panel1.Controls.Add(lit);

            Label lb = new Label() { Text = fonction + " : " };
            lb.CssClass = "dnnLabel";
            if(Const.AFFECTATIONS_ADMIN_CLUB.IndexOf(fonction)>-1)
            {
                lb.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
                lb.Text = lb.Text.Replace(" : ", "* : ");
            }
            Panel1.Controls.Add(lb);
            
            DropDownList dl = new DropDownList();
            dl.CssClass = "dnnFormItem";
            dl.ID = cric + "_DL_" + fonction;
            dl.Items.Add(new ListItem("--- Personne ---", ""));
            foreach (Member membre in members)
            {
                if (membre.nim > 0)
                {
                    dl.Items.Add(new ListItem(membre.surname +" " + membre.name , "" + membre.nim));
                }
                else
                {
                    nbError += 1;
                }
            }

            dl.SelectedIndex = 0;
            if(UserInfo.IsSuperUser ||
                UserInfo.IsInRole(Const.ADMIN_ROLE) || 
                UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || 
                UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || 
                DataMapping.isADG(Functions.GetCurrentMember().id))
                dl.Attributes.Add("onchange", "javascript: AfficheValider();");
            Panel1.Controls.Add(dl);
            lit = new Literal();
            lit.Text = "</div>";
            Panel1.Controls.Add(lit);

        }

        //if(nbError > 0)
        //{
        //    nbError = nbError / fonctions.Count();

        //    if (nbError == 1)
        //    {
        //        lbl_erreur.Text = "ATTENTION : il y a 1 membre dont le nim est 0. Tant que cette erreur n'est pas corrigée, vous ne pourrez pas affecter ce membre à un poste.";
        //    }
        //    else
        //    {
        //        lbl_erreur.Text = "ATTENTION : il y a " + nbError + " membres dont le nim est 0. Tant que ces erreurs ne sont pas corrigées, vous ne pourrez pas affecter ces membres à un poste.";
        //    }
        //    PanelErreur.Visible = true;
        //}
        //else
        //{
           PanelErreur.Visible = false;
        //}

        
    }

    /// <summary>
    /// Associe les informations aux DropDownLists dans le panel
    /// </summary>
    protected void SetPanel()
    {
        
        int cric = Functions.CurrentCric;

        List<Affectation> affectations = DataMapping.ListAffectationRY(cric, int.Parse(RB_AR.SelectedValue));

        foreach (Control row in Panel1.Controls)
        {
            if (row is DropDownList)
            {
                DropDownList dl = row as DropDownList; //cell.Controls[0] as DropDownList;
                string[] ids = dl.ID.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                string fonction = ids[ids.Length - 1];

                foreach (Affectation affectation in affectations)
                {
                    if (affectation.function == fonction)
                    {
                        for (int i = 0; i < dl.Items.Count; i++)
                        {
                            ListItem item = dl.Items[i] as ListItem;
                            if (item.Value == ""+affectation.nim)
                                dl.SelectedIndex = i;
                        }
                        break;
                    }
                }

            }
        }
    }

   /// <summary>
   /// Permet de valider les modifications des AAR
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        if (!(UserInfo.IsSuperUser || 
            UserInfo.IsInRole(Const.ADMIN_ROLE) || 
            UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || 
            UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || 
            DataMapping.isADG(Functions.GetCurrentMember().id)))
            return;

        int cric = Functions.CurrentCric;
        List<Affectation> affectations = new List<Affectation>();

        foreach (Control row in Panel1.Controls)
        {
            if (row is DropDownList)
            {
                DropDownList dl = row as DropDownList; 
                string[] ids = dl.ID.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                
                Affectation affectation = new Affectation();
                affectation.cric = cric;
                affectation.function = ids[ids.Length - 1];

                int nim = 0;
                int.TryParse("" + dl.SelectedValue, out nim);
                affectation.nim = nim;
                affectation.name = dl.SelectedIndex > 0 ? GetMemberFullName(dl.Items[dl.SelectedIndex].Value) : "";
                if (affectation.name != "")
                {
                    affectations.Add(affectation);
                }
            }
        }
        if(DataMapping.UpdateAffectationRY(cric, int.Parse(RB_AR.SelectedValue), affectations))
        {
            Club c = AIS.DataMapping.GetClub(cric);

            string subject = "[Rotary District] Information";
            string body = "Le bureau du club " + c.name + " vient d'être modifié pour l'année " + RB_AR.SelectedValue + ".";

            
            //AIS.Functions.SendMail("secretaire@rotary1730.org", subject, body);
            //AIS.Functions.SendMail("webmaster@rotary1730.org", subject, body);
            MajAAR();
        }

    }

    string GetMemberFullName(string nim)
    {
        int n = 0;
        if (!int.TryParse(nim, out n))
            return "";
        
        foreach(Member member in members)
        {
            if(member.nim==n)
            {
                return member.name + " " + member.surname;
            }
        }
        return "";
    }

    /// <summary>
    /// Lors du changement de l'année rotarienne, actualise le panel 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RB_AR_SelectedIndexChanged(object sender, EventArgs e)
    {
        CreatePanel();
        SetPanel();
    }

    private void MajAAR ()
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        try
        {
            conn.Open();

            int annee = Functions.GetRotaryYear();

            RoleController rc = new RoleController();

            RoleInfo uri = rc.GetRoleByName(Globals.GetPortalSettings().PortalId, Const.ROLE_ADMIN_CLUB);
            RoleInfo urip = rc.GetRoleByName(Globals.GetPortalSettings().PortalId, Const.ROLE_PRESIDENTS_CLUBS);
            IList<UserInfo> users = RoleController.Instance.GetUsersByRole(PortalId, Const.ROLE_ADMIN_CLUB);
            //ArrayList users =  rc.GetUsersByRoleName(PortalId, Const.ROLE_ADMIN_CLUB);
            
            List<UserInfo> club = new List<UserInfo>();
            foreach (UserInfo user in users)
            {
                foreach (Member m in DataMapping.ListMembers(cric: Functions.CurrentCric, sort:"Surname asc"))
                {
                    if (m.userid == user.UserID)
                        club.Add(user);
                }
            }

            foreach (UserInfo user in club)
            {
                if (!RoleController.DeleteUserRole(user, uri, Globals.GetPortalSettings(), false))
                {
                }
                if (!RoleController.DeleteUserRole(user, urip, Globals.GetPortalSettings(), false))
                {
                }
            }

            String query = "SELECT nim,name,[function] FROM " + Const.TABLE_PREFIX + "rya WHERE [function] IN ("+Const.AFFECTATIONS_ADMIN_CLUB+") AND cric='" + Functions.CurrentCric+"' AND rotary_year IN (";

            if (DateTime.Now.Month >= 1 && DateTime.Now.Month < 7)
                query += annee + "," + (annee + 1);
            else // if (DateTime.Now.Month >= 7)
                //query += (annee - 1) + "," + annee;
                query += annee;

            query += ")";


            SqlCommand sql = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string function = "" + row["function"];
                cestbon:

                Member membre = DataMapping.GetMemberByNim((int)row["nim"]);
                if (membre != null)
                {
                    if (membre.userid == 0)
                    {
                        //TXT_Result.Text += "<br/>Le membre : " + row["name"] + " n'a pas de user DNN";
                        if (DataMapping.UpdateOrCreateUser(membre.id, membre.email))
                        {
                            //TXT_Result.Text += "<br/>et a été créé";
                            goto cestbon;
                        }
                        else
                        {
                           // TXT_Result.Text += "<br/>et n'a pas été créé";
                        }

                    }
                    else
                    {
                        UserInfo ui = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, membre.email);
                        if (ui != null)
                        {

                            rc.AddUserRole(Globals.GetPortalSettings().PortalId, ui.UserID, uri.RoleID, Null.NullDate, Null.NullDate);
                            if(function=="Président")
                            {
                                rc.AddUserRole(Globals.GetPortalSettings().PortalId, ui.UserID, urip.RoleID, Null.NullDate, Null.NullDate);
                            }
                            //TXT_Result.Text += "<br/>Ajout role admin club : " + row["name"];
                        }
                    }
                }
            }

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
           
        }
        finally
        {
            conn.Close();
        }
    }
}