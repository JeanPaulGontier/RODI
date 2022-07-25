
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Entities.Modules;
using System.IO;
using System.Drawing;
using Telerik.Web.UI;

public partial class DesktopModules_AIS_Admin_Actions_List_Control : PortalModuleBase
{
   /// <summary>
   /// Définit quel panel afficher et la visiblité du bouton. Actualise le GridView
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if ("" + Functions.CurrentCric != HF_Cric.Value)
        {
            HF_Cric.Value = "" + Functions.CurrentCric;
            GridView1.PageIndex = 0;
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        RefreshGrid();

        BT_Ajouter_Nouvelle.Visible = (Functions.CurrentCric!=0 && (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || DataMapping.isADG(Functions.GetCurrentMember().id))) ;
             
    }

    /// <summary>
    /// Définit quelle commande doit être appliquée et le script qu'elle entraîne
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
                List<Actions> news = gv.DataSource as List<Actions>;

                Actions n = news[index];

                HF_id.Value = "" + n.id;
                LBL_nom_club.Text = "" + n.club_name;
                TXT_description.Text = "" + n.description;
                TXT_description_phases.Text = "" + n.description_phases;
                TXT_moyens_humains.Text = "" + n.human_resources;
                TXT_moyens_materiel.Text = "" + n.material_resources;
                TXT_nom_action.Text = "" + n.name_action;
                TXT_objectif.Text = "" + n.goal;
                TXT_remarques.Text = "" + n.remarks;
                TXT_resultats.Text = "" + n.results;
                TXT_zone_geographique.Text = "" + n.geographical_area;
                DT_Date.SelectedDate = n.dt_action;

                LBL_nom_user_courant.Text = n.name_current + "<br/><a href='mailto:" + n.mail_current + "'>" + n.mail_current + "</a><br/>" + n.mobile_current;
                LBL_nom_user_responsable.Text = n.name_responsable + "<br/><a href='mailto:" + n.mail_responsable + "'>" + n.mail_responsable + "</a><br/>" + n.mobile_responsable;

                #region lecture_seule
                LBL_date.Text = n.dt_action.ToShortDateString();
                LBL_description.Text = n.description.Replace("\n","<br/>");
                LBL_phases.Text = n.description_phases.Replace("\n", "<br/>");
                LBL_humains.Text = n.human_resources.Replace("\n", "<br/>");
                LBL_moyens.Text = n.material_resources.Replace("\n", "<br/>");
                LBL_nom_action.Text = n.name_action.Replace("\n", "<br/>");
                LBL_nom_club1.Text = n.club_name.Replace("\n", "<br/>");
                LBL_objectif.Text = n.goal.Replace("\n", "<br/>");
                LBL_remarques.Text = n.remarks.Replace("\n", "<br/>");
                LBL_resultat.Text = n.results.Replace("\n", "<br/>");
                LBL_zone.Text = n.geographical_area.Replace("\n", "<br/>");

                LBL_nom_courant.Text = LBL_nom_user_courant.Text;
                LBL_nom_responsable.Text = LBL_nom_user_responsable.Text;
                #endregion





                BT_Supprimer.Visible = (Functions.CurrentCric == n.cric && (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || DataMapping.isADG(Functions.GetCurrentMember().id)));
               
                bool validable = (Functions.CurrentCric==n.cric && (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || DataMapping.isADG(Functions.GetCurrentMember().id)));

                BT_Valider.Visible = validable;
                DL_id_user_courant.Visible = validable;
                DL_id_user_responsable.Visible = validable;

                P_Lecture.Visible = !validable;
                P_Modifiable.Visible = validable;

                if (validable)
                {
                    List<Member> members = DataMapping.ListMembers(Functions.CurrentCric, "", "", "nom", 0, 999, false, true);

                    DL_id_user_courant.Items.Clear();
                    DL_id_user_responsable.Items.Clear();
                    foreach (Member m in members)
                    {
                        DL_id_user_courant.Items.Add(new ListItem("" + m.surname + " " + m.name, "" + m.id)
                            {
                                Selected = m.id == n.id_user_current
                            });
                        DL_id_user_responsable.Items.Add(new ListItem("" + m.surname + " " + m.name, "" + m.id)
                            {
                                Selected = m.id == n.id_user_in_charge
                            });
                    }
                }
                foreach (Control ctr in Panel2.Controls)
                    if (ctr is TextBox)
                        (ctr as TextBox).ReadOnly = !validable;
                

                Panel1.Visible = false;
                Panel2.Visible = true;
                break;
        }
    }

    /// <summary>
    /// Permet de trier les lignes du GridView
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
    /// Définit la marche à suivre lors d'un changement de page
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
        List<Actions> news = DataMapping.ListActions( cric: Functions.CurrentCric, index: GridView1.PageIndex, max: GridView1.PageSize);
        GridView1.DataSource = news;
        GridView1.DataBind();
    }

    /// <summary>
    /// Actualise le GridView, cache le panel 2 et affiche le panel 1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Annuler_Click(object sender, EventArgs e)
    {
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    /// <summary>
    /// Permet l'ajout ou la modification d'une action de la liste
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        Actions n = new Actions();
        if (HF_id.Value!="")
        {
            n = DataMapping.GetActions(HF_id.Value);    
        }
        n.club_name = LBL_nom_club.Text;
        n.description = TXT_description.Text  ;
        n.description_phases = TXT_description_phases.Text;
        n.human_resources = TXT_moyens_humains.Text;
        n.material_resources = TXT_moyens_materiel.Text;
        n.name_action = TXT_nom_action.Text;
        n.goal = TXT_objectif.Text;
        n.remarks =  TXT_remarques.Text;
        n.results = TXT_resultats.Text;
        n.geographical_area = TXT_zone_geographique.Text;
        int id = 0;
        int.TryParse("" + DL_id_user_courant.SelectedValue, out id);
        n.id_user_current = id;
        id = 0;
        int.TryParse("" + DL_id_user_responsable.SelectedValue, out id);
        n.id_user_in_charge = id;

        n.dt_action = DT_Date.SelectedDate != null ? (DateTime)DT_Date.SelectedDate : DateTime.Now;
        n.cric = Functions.CurrentCric;

        
        if (!DataMapping.UpdateActions(n))
            return;
        
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    /// <summary>
    /// Permet d'ajouter une Nouvelle et de la paramétrer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Ajouter_Nouvelle_Click(object sender, EventArgs e)
    {

        HF_id.Value = "";

        HF_Cric.Value = ""+Functions.CurrentCric;
        LBL_nom_club.Text = DataMapping.GetClub(Functions.CurrentCric).name;


        TXT_description.Text = "";
        TXT_description_phases.Text = "";
        TXT_moyens_humains.Text = "";
        TXT_moyens_materiel.Text = "";
        TXT_nom_action.Text = "";
        TXT_objectif.Text = "";
        TXT_remarques.Text = "";
        TXT_resultats.Text = "";
        TXT_zone_geographique.Text = "";
        DT_Date.SelectedDate = DateTime.Now;

        LBL_nom_user_courant.Text = "";
        LBL_nom_user_responsable.Text = "";

        bool validable = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || DataMapping.isADG(Functions.GetCurrentMember().id));
        BT_Valider.Visible = validable;
        DL_id_user_courant.Visible = validable;
        DL_id_user_responsable.Visible = validable;

        P_Lecture.Visible = !validable;
        P_Modifiable.Visible = validable;

        if (validable)
        {
 
            List<Member> members = DataMapping.ListMembers(Functions.CurrentCric, "", "", "nom", 0, 999, false, true);

            DL_id_user_courant.Items.Clear();
            DL_id_user_responsable.Items.Clear();
            foreach (Member m in members)
            {
                DL_id_user_courant.Items.Add(new ListItem("" + m.surname + " " + m.name, "" + m.id) );
                DL_id_user_responsable.Items.Add(new ListItem("" + m.surname + " " + m.name, "" + m.id) );
            }
        }


        BT_Supprimer.Visible = false;
        
        Panel2.Visible = true;
        Panel1.Visible = false;

    }

    /// <summary>
    /// Supprime l'action sélectionnée, actualise le GridView et affiche le panel 1
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Supprimer_Click(object sender, EventArgs e)
    {
        if (!DataMapping.DeleteActions(HF_id.Value))
        {
            return;
        }
       
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

   
}