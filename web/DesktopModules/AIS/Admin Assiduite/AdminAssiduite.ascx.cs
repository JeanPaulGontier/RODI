
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

public partial class DesktopModules_AIS_Admin_Attendance_AdminAttendance : PortalModuleBase
{
    protected List<Attendance> theAtt = null;
    protected int CurrentYear = DateTime.Now.Year;
    protected int YearPast = DateTime.Now.Year - 1;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Functions.CurrentClub!=null && (UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT) || DataMapping.isADG(Functions.GetCurrentMember().id)|| UserInfo.IsSuperUser))
            {



                if (!IsPostBack)
                {
                    if (hfd_cric.Value != "" + Functions.CurrentCric)
                    {
                        hfd_cric.Value = "" + Functions.CurrentCric;
                        if (ddl_nb != null)
                            ddl_nb.SelectedIndex = 0;
                    }

                    pnl_saisie.Visible = true;
                    if (UserInfo.IsSuperUser)
                    {
                        lbl_ss_titre.Text = "Pas de club pour le super user";
                    }
                    else if (Functions.CurrentCric == 0)
                    {
                        lbl_ss_titre.Text = "Choisissez un club";
                        pnl_saisie.Visible = false;
                        if (ddl_nb != null)
                            ddl_nb.SelectedIndex = 0;
                    }

                    else
                    {
                        lbl_ss_titre.Text = "Club de " + Functions.CurrentClub.name;
                        pnl_saisie.Visible = true;
                    }

                    btn_Valider.Visible = false;


                    CleartextBoxes(pnl_saisie);
                    findMonth();

                    tbx_nbMember_1.Text = "" + nbMembers();
                    tbx_nbMember_2.Text = "" + nbMembers();
                    tbx_nbMember_3.Text = "" + nbMembers();
                    tbx_nbMember_4.Text = "" + nbMembers();
                    tbx_nbMember_5.Text = "" + nbMembers();
                    // btn_Valider.Text = "Ajouter";
                    btn_annuler.Visible = false;

                    BindingDDL_jour_1();
                    BindingDDL_jour_2();
                    BindingDDL_jour_3();
                    BindingDDL_jour_4();
                    BindingDDL_jour_5();
                    BindingDDL_nb();

                    pnl_saisie.Visible = true;
                    ShowMonth(true);
                    //pnl_saisie_detail.Visible = false;

                    RefreshGrid();

                }
                else
                {
                    if(hfd_cric.Value != Functions.CurrentCric + "")
                        Response.Redirect(Globals.NavigateURL());
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
            if (btn_Valider.Text == "Modifier")
                btn_annuler.Visible = true;
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    //protected Attendance GetAttendance()
    //{
    //    Attendance att = new Attendance();

    //    try
    //    {
    //        att.annee = int.Parse(ddl_annee.SelectedValue);
    //        att.mois = int.Parse(ddl_mois.SelectedValue);
    //        att.day = int.Parse(lbl_jour_1.Text.Trim());
    //        att.nbc = int.Parse(lbl_nb_compense_1.Text.Trim());
    //        att.nbd = int.Parse(lbl_nb_dispense_1.Text.Trim());
    //        att.nbe = int.Parse(lbl_nb_excuse_1.Text.Trim());
    //        att.nbm = int.Parse(lbl_nb_membre_1.Text.Trim());
    //        att.nbp = int.Parse(lbl_nb_present_1.Text.Trim());
    //        att.nbdp = int.Parse(lbl_nb_dispense_present_1.Text.Trim());

    //        return att;
    //    }
    //    catch (Exception ee)
    //    {
    //        Functions.Error(ee);
    //        return null;
    //    }
    //}

    /// <summary>
    /// Récupère l'attiduité dont les informations sont contenues sur la page
    /// </summary>
    /// <param name="id">Indique quelle ligne de la page le programme doit récupérer</param>
    /// <returns></returns>
    protected Attendance GetAttendance(int id)
    {
        if (id == 1)
        {
            Attendance att = new Attendance();

            try
            {
                att.year = int.Parse(lbl_annee.Text.Trim());
                att.month = nbMonth();
                att.day = int.Parse(ddl_jour_1.SelectedValue);
                att.nbc = int.Parse(tbx_nbCompense_1.Text.Trim());
                att.nbd = int.Parse(tbx_nbDispense_1.Text.Trim());
             // att.nbe = int.Parse(tbx_nbExcuse_1.Text.Trim());
                att.nbm = int.Parse(tbx_nbMember_1.Text.Trim());
                att.nbp = int.Parse(tbx_nbPresent_1.Text.Trim());
                att.nbdp = int.Parse(tbx_nbDispensePresent_1.Text.Trim());

                if (!string.IsNullOrEmpty(hfd_id1.Value))
                {
                    att.id = int.Parse(hfd_id1.Value);
                }
                if (!string.IsNullOrEmpty(hfd_dateSaisie_1.Value))
                {
                    att.dt_input = DateTime.Parse(hfd_dateSaisie_1.Value);
                }
                    if (btn_Valider.Text == "Modifier")
                {
                    att.dt_edit = DateTime.Now;
                    btn_annuler.Visible = true;
                }

                return att;
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return null;
            }
        }
        else if (id == 2)
        {
            Attendance att = new Attendance();

            try
            {
                att.year = int.Parse(lbl_annee.Text.Trim());
                att.month = nbMonth();
                att.day = int.Parse(ddl_jour_2.SelectedValue);
                att.nbc = int.Parse(tbx_nbCompense_2.Text.Trim());
                att.nbd = int.Parse(tbx_nbDispense_2.Text.Trim());
              //att.nbe = int.Parse(tbx_nbExcuse_2.Text.Trim());
                att.nbm = int.Parse(tbx_nbMember_2.Text.Trim());
                att.nbp = int.Parse(tbx_nbPresent_2.Text.Trim());
                att.nbdp = int.Parse(tbx_nbDispensePresent_2.Text.Trim());

                if (!string.IsNullOrEmpty(hfd_id2.Value))
                {
                    att.id = int.Parse(hfd_id2.Value);
                }

                if (!string.IsNullOrEmpty(hfd_dateSaisie_2.Value))
                {
                    att.dt_input = DateTime.Parse(hfd_dateSaisie_2.Value);
                }

                if (btn_Valider.Text == "Modifier")
                {
                    att.dt_edit = DateTime.Now;
                    btn_annuler.Visible = true;
                }

                return att;
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return null;
            }
        }
        else if (id == 3)
        {
            Attendance att = new Attendance();

            try
            {
                att.year = int.Parse(lbl_annee.Text.Trim());
                att.month = nbMonth();
                att.day = int.Parse(ddl_jour_3.SelectedValue);
                att.nbc = int.Parse(tbx_nbCompense_3.Text.Trim());
                att.nbd = int.Parse(tbx_nbDispense_3.Text.Trim());
//              att.nbe = int.Parse(tbx_nbExcuse_3.Text.Trim());
                att.nbm = int.Parse(tbx_nbMember_3.Text.Trim());
                att.nbp = int.Parse(tbx_nbPresent_3.Text.Trim());
                att.nbdp = int.Parse(tbx_nbDispensePresent_3.Text.Trim());

                if (!string.IsNullOrEmpty(hfd_id3.Value))
                {
                    att.id = int.Parse(hfd_id3.Value);
                }

                if (!string.IsNullOrEmpty(hfd_dateSaisie_3.Value))
                {
                    att.dt_input = DateTime.Parse(hfd_dateSaisie_3.Value);
                }

                if (btn_Valider.Text == "Modifier")
                {
                    att.dt_edit = DateTime.Now;
                    btn_annuler.Visible = true;
                }

                return att;
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return null;
            }
        }
        else if (id == 4)
        {
            Attendance att = new Attendance();

            try
            {
                att.year = int.Parse(lbl_annee.Text.Trim());
                att.month = nbMonth();
                att.day = int.Parse(ddl_jour_4.SelectedValue);
                att.nbc = int.Parse(tbx_nbCompense_4.Text.Trim());
                att.nbd = int.Parse(tbx_nbDispense_4.Text.Trim());
                //att.nbe = int.Parse(tbx_nbExcuse_4.Text.Trim());
                att.nbm = int.Parse(tbx_nbMember_4.Text.Trim());
                att.nbp = int.Parse(tbx_nbPresent_4.Text.Trim());
                att.nbdp = int.Parse(tbx_nbDispensePresent_4.Text.Trim());

                if (!string.IsNullOrEmpty(hfd_id4.Value))
                {
                    att.id = int.Parse(hfd_id4.Value);
                }

                if (!string.IsNullOrEmpty(hfd_dateSaisie_4.Value))
                {
                    att.dt_input = DateTime.Parse(hfd_dateSaisie_4.Value);
                }

                if (btn_Valider.Text == "Modifier")
                {
                    att.dt_edit = DateTime.Now;
                    btn_annuler.Visible = true;

                }

                return att;
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return null;
            }
        }
        else if (id == 5)
        {
            Attendance att = new Attendance();

            try
            {
                att.year = int.Parse(lbl_annee.Text.Trim());
                att.month = nbMonth();
                att.day = int.Parse(ddl_jour_5.SelectedValue);
                att.nbc = int.Parse(tbx_nbCompense_5.Text.Trim());
                att.nbd = int.Parse(tbx_nbDispense_5.Text.Trim());
//                att.nbe = int.Parse(tbx_nbExcuse_5.Text.Trim());
                att.nbm = int.Parse(tbx_nbMember_5.Text.Trim());
                att.nbp = int.Parse(tbx_nbPresent_5.Text.Trim());
                att.nbdp = int.Parse(tbx_nbDispensePresent_5.Text.Trim());

                if (!string.IsNullOrEmpty(hfd_id5.Value))
                {
                    att.id = int.Parse(hfd_id5.Value);
                }

                if (!string.IsNullOrEmpty(hfd_dateSaisie_5.Value))
                {
                    att.dt_input = DateTime.Parse(hfd_dateSaisie_5.Value);
                }

                if (btn_Valider.Text == "Modifier")
                {
                    att.dt_edit = DateTime.Now;
                    btn_annuler.Visible = true;

                }

                return att;
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return null;
            }
        }
        else
            throw new Exception("Mauvais id");
    }

    /// <summary>
    /// Permet de valider l'ajout ou la modification d'une attiduité
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Valider_Click(object sender, EventArgs e)
    {
        try
        {
            gvw_assiduite.Visible = true;
            List<Attendance> theAtts = new List<Attendance>();
            Member m = Functions.GetCurrentMember();
            Attendance att = null;

            for (int i = 0; i < int.Parse(ddl_nb.SelectedValue); i++ )
            {
                att = GetAttendance(i + 1);
                if (att != null)
                {
                    theAtts.Add(att);
                }
            }

            if(theAtts != null && theAtts.Count > 0)
            {
                foreach(Attendance atts in theAtts)
                {
                    if (m != null)
                    {
                        atts.nim = m.nim;
                        atts.name_surname = m.surname + " " + m.name;
                    }
                    
                    atts.cric = int.Parse(hfd_cric.Value);

                    if (btn_Valider.Text == "Valider")
                    {
                        atts.dt_input = DateTime.Now;
                    }

                    if (btn_Valider.Text == "Modifier")
                        btn_annuler.Visible = true;

                    int id = DataMapping.Insert_Attendance(atts);

                    if (id == null || id < 1)
                    {
                        break;
                        throw new Exception("Erreur lors de l'insert/update de l'attiduité");
                    }
                }

                
                ShowMonth(false);
                pnl_saisie.Visible = false;
                ddl_nb.Items.Clear();
                pnl_grid.Visible = true;
                ClearHiddenField();

                RefreshGrid();   
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Permet le retour à l'affichage des attiduités
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_annuler_Click(object sender, EventArgs e)
    {
        try
        {
            gvw_assiduite.Visible = true;
            ShowMonth(false);
            pnl_saisie.Visible = false;
            ddl_nb.Items.Clear();
            
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Supprime le texte des Textbox
    /// </summary>
    /// <param name="parent">Control dans lequel se trouvent les textbox</param>
    protected void CleartextBoxes(Control parent)
    {

        foreach (Control c in parent.Controls)
        {
            if ((c.GetType() == typeof(TextBox)))
            {

                ((TextBox)(c)).Text = "";
            }
            else if ((c.GetType() == typeof(CheckBox)))
            {

                ((CheckBox)(c)).Checked = false;
            }
            //else if ((c.GetType() == typeof(DropDownList)))
            //{

            //    ((DropDownList)(c)).SelectedIndex = 0;
            //}
            //else if ((c.GetType() == typeof(RadioButton)))
            //{

            //    ((RadioButton)(c)).Checked = false;
            //}

            if (c.HasControls())
            {
                CleartextBoxes(c);
            }
        }
    }
    
    /// <summary>
    /// Permet la modification des attiduités d'un mois
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvw_assiduite_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e == null)
                return;


            
            if (e.CommandName == "modifier")
            {
                gvw_assiduite.Visible = false;
                pnl_saisie.Visible = true;
                pnl_btn.Visible = true;
                string[] splits = e.CommandArgument.ToString().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                if (splits.Count() == 2)
                {
                    if (!string.IsNullOrEmpty(splits[0]) && !string.IsNullOrEmpty(splits[1]))
                    {
                        Edit(/*splits[0], splits[1]*/);
                    }
                    else
                    {
                        throw new Exception("Le mois, l'année ou les 2 sont vides : " + e.CommandArgument.ToString());
                    }
                }
                else
                {
                    throw new Exception("Erreur lors de la récupération de l'année et du mois : " + e.CommandArgument.ToString());
                }
                
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Calcule le numéro du mois
    /// </summary>
    /// <returns>Numéro du mois</returns>
    public int nbMonth ()
    {
        DateTime date = DateTime.Now;
        int mois = 0;
        

        if (date.Day < 29)
            mois = date.Month - 1;
        else
            mois = date.Month;

        if (mois == 0)
        {
            mois = 12;
        }

        return mois;
    }

    /// <summary>
    /// Trouve le nom du mois en fonction de son numéro
    /// </summary>
    /// <returns>Nom du mois</returns>
    public String findMonth ()
    {
        
        DateTime date = DateTime.Now;
        int mois=0;
        int annee = date.Year;
        String moisTxt = "";


        if (date.Day < 29)
            mois = date.Month - 1;
        else
            mois = date.Month;

        if (mois == 0)
        {
            mois = 12;
            annee = date.Year - 1;
            lbl_annee.Text = annee.ToString();
        }
        else
            lbl_annee.Text = annee.ToString();
            
            
       

        switch (mois)
                {
                    case 1:
                        moisTxt = "Janvier";
                        break;
                    case 2:
                        moisTxt = "Février";
                        break;
                    case 3:
                        moisTxt = "Mars";
                        break;
                    case 4:
                        moisTxt = "Avril";
                        break;
                    case 5:
                        moisTxt = "Mai";
                        break;
                    case 6:
                        moisTxt = "Juin";
                        break;
                    case 7:
                        moisTxt = "Juillet";
                        break;
                    case 8:
                        moisTxt = "Août";
                        break;
                    case 9:
                        moisTxt = "Septembre";
                        break;
                    case 10:
                        moisTxt = "Octobre";     
                        break;
                    case 11:
                        moisTxt = "Novembre";
                        break;
                    case 12:
                        moisTxt = "Décembre";
                        break;
                }
        
        lbl_mois.Text = moisTxt;
        return moisTxt;
    }

    /// <summary>
    /// Supprime le texte des HiddenField
    /// </summary>
    public void ClearHiddenField()
    {
        hfd_dateSaisie_1.Value = null;
        hfd_dateSaisie_2.Value = null;
        hfd_dateSaisie_3.Value = null;
        hfd_dateSaisie_4.Value = null;
        hfd_dateSaisie_5.Value = null;

        hfd_id1.Value = null;
        hfd_id2.Value = null;
        hfd_id3.Value = null;
        hfd_id4.Value = null;
        hfd_id5.Value = null;
    }

    /// <summary>
    /// Gère la modification d'une attiduité
    /// </summary>
    protected void Edit() 
    {
        try
        {
            
            if(!IsPostBack)
                RefreshGrid();
            int mois = nbMonth();
            List<Attendance> theAttsEdit = DataMapping.GetListAttendance("cric = " + Functions.CurrentCric + " AND month = " + mois);
            if (theAttsEdit != null && theAttsEdit.Count > 0 )
            {
                CleartextBoxes(pnl_saisie);

                #region NB
                BindingDDL_nb();
                ddl_nb.Items.Clear();
                for (int i = 1; i < 6; i++)
                {
                    ddl_nb.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                if (theAttsEdit.Count.ToString() != null && theAttsEdit.Count!=0)
                {
                    try { 
                         ddl_nb.SelectedValue = theAttsEdit.Count.ToString();
                    }
                    catch { ddl_nb.SelectedValue = "5"; }
                }
               
                btn_Valider.Visible = true;

                int btn_selected_value = 5;
                int.TryParse(ddl_nb.SelectedValue, out btn_selected_value);
                if (btn_selected_value < 1 || btn_selected_value>5)
                    btn_selected_value = 5;
                if (btn_selected_value >= 1)
                {
                    entry_1.Visible = true;
                    entry_2.Visible = false;
                    entry_3.Visible = false;
                    entry_4.Visible = false;
                    entry_5.Visible = false;

                    ddl_jour_1.SelectedValue = "" + theAttsEdit[0].day;
                    tbx_nbCompense_1.Text = "" + theAttsEdit[0].nbc;
                    tbx_nbDispense_1.Text = "" + theAttsEdit[0].nbd;
                    tbx_nbExcuse_1.Text = "" + theAttsEdit[0].nbe;
                    tbx_nbMember_1.Text = "" + theAttsEdit[0].nbm;
                    tbx_nbPresent_1.Text = "" + theAttsEdit[0].nbp;
                    tbx_nbDispensePresent_1.Text = "" + theAttsEdit[0].nbdp;
                    hfd_id1.Value = "" + theAttsEdit[0].id;
                    hfd_dateSaisie_1.Value = "" + theAttsEdit[0].dt_input;
                }
                if (btn_selected_value >= 2)
                {
                    entry_1.Visible = true;
                    entry_2.Visible = true;
                    entry_3.Visible = false;
                    entry_4.Visible = false;
                    entry_5.Visible = false;

                    ddl_jour_2.SelectedValue = "" + theAttsEdit[1].day;
                    tbx_nbCompense_2.Text = "" + theAttsEdit[1].nbc;
                    tbx_nbDispense_2.Text = "" + theAttsEdit[1].nbd;
                    tbx_nbExcuse_2.Text = "" + theAttsEdit[1].nbe;
                    tbx_nbMember_2.Text = "" + theAttsEdit[1].nbm;
                    tbx_nbPresent_2.Text = "" + theAttsEdit[1].nbp;
                    tbx_nbDispensePresent_2.Text = "" + theAttsEdit[1].nbdp;
                    hfd_id2.Value = "" + theAttsEdit[1].id;
                    hfd_dateSaisie_2.Value = "" + theAttsEdit[1].dt_input;

                }
                if (btn_selected_value >= 3)
                {
                    entry_1.Visible = true;
                    entry_2.Visible = true;
                    entry_3.Visible = true;
                    entry_4.Visible = false;
                    entry_5.Visible = false;

                    ddl_jour_3.SelectedValue = "" + theAttsEdit[2].day;
                    tbx_nbCompense_3.Text = "" + theAttsEdit[2].nbc;
                    tbx_nbDispense_3.Text = "" + theAttsEdit[2].nbd;
                    tbx_nbExcuse_3.Text = "" + theAttsEdit[2].nbe;
                    tbx_nbMember_3.Text = "" + theAttsEdit[2].nbm;
                    tbx_nbPresent_3.Text = "" + theAttsEdit[2].nbp;
                    tbx_nbDispensePresent_3.Text = "" + theAttsEdit[2].nbdp;
                    hfd_id3.Value = "" + theAttsEdit[2].id;
                    hfd_dateSaisie_3.Value = "" + theAttsEdit[2].dt_input;
                }
                if (btn_selected_value >= 4)
                {
                    entry_1.Visible = true;
                    entry_2.Visible = true;
                    entry_3.Visible = true;
                    entry_4.Visible = true;
                    entry_5.Visible = false;

                    ddl_jour_4.SelectedValue = "" + theAttsEdit[3].day;
                    tbx_nbCompense_4.Text = "" + theAttsEdit[3].nbc;
                    tbx_nbDispense_4.Text = "" + theAttsEdit[3].nbd;
                    tbx_nbExcuse_4.Text = "" + theAttsEdit[3].nbe;
                    tbx_nbMember_4.Text = "" + theAttsEdit[3].nbm;
                    tbx_nbPresent_4.Text = "" + theAttsEdit[3].nbp;
                    tbx_nbDispensePresent_4.Text = "" + theAttsEdit[3].nbdp;
                    hfd_id4.Value = "" + theAttsEdit[3].id;
                    hfd_dateSaisie_4.Value = "" + theAttsEdit[3].dt_input;
                }
                if (btn_selected_value == 5)
                {
                    entry_1.Visible = true;
                    entry_2.Visible = true;
                    entry_3.Visible = true;
                    entry_4.Visible = true;
                    entry_5.Visible = true;

                    ddl_jour_5.SelectedValue = "" + theAttsEdit[4].day;
                    tbx_nbCompense_5.Text = "" + theAttsEdit[4].nbc;
                    tbx_nbDispense_5.Text = "" + theAttsEdit[4].nbd;
                    tbx_nbExcuse_5.Text = "" + theAttsEdit[4].nbe;
                    tbx_nbMember_5.Text = "" + theAttsEdit[4].nbm;
                    tbx_nbPresent_5.Text = "" + theAttsEdit[4].nbp;
                    tbx_nbDispensePresent_5.Text = "" + theAttsEdit[4].nbdp;
                    hfd_id5.Value = "" + theAttsEdit[4].id;
                    hfd_dateSaisie_5.Value = "" + theAttsEdit[4].dt_input;
                }
                //if (btn_selected_value > 5 || btn_selected_value < 1)
                //{
                //    throw new Exception("Problème de reception du nombre d'entrées");
                //}

               
                #endregion NB
          
                pnl_titre.Visible = true;
                ShowMonth(true);

                btn_Valider.Text = "Modifier";
                btn_annuler.Visible = true;
                

            }
            else
            {
                ShowMonth(false);
                pnl_saisie.Visible = false;
                ddl_nb.Items.Clear();
                RefreshGrid();
            }
            
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Actualise les données de la GridView
    /// </summary>
    protected void RefreshGrid()
    {        
        List<Attendance> LesAssFinaux = new List<Attendance>();
        if (DataMapping.GetListAttendancePurcent(" cric = " + Functions.CurrentCric) != null && DataMapping.GetListAttendancePurcent(" cric = " + Functions.CurrentCric).Count != 0)
        {
            LesAssFinaux = DataMapping.GetListAttendancePurcent(" cric = " + Functions.CurrentCric);
        }


        gvw_assiduite.DataSource = LesAssFinaux;
        gvw_assiduite.DataBind();
                
    }

    /// <summary>
    /// Ajoute le texte dans la DropDownListe ddl_nb
    /// </summary>
    protected void BindingDDL_nb()
    {
        try
        {
            ddl_nb.Items.Clear();
            ddl_nb.Items.Add(new ListItem("--Selectionnez--", "0") { Selected = true });
            for (int i = 1; i < 6; i++ )
            {
                ddl_nb.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
                
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

   /// <summary>
   /// Calcule le préfixe du jour, soit l'initiale du jour
   /// </summary>
   /// <param name="day">Numéro du jour</param>
   /// <param name="month">Numéro du mois</param>
   /// <param name="year">Année</param>
   /// <returns>Initiale du jour (L pour lundi, M pour mardi etc...)</returns>
    public String prefixDay (String day, int month, int year)
    {
        int Jour = int.Parse(day);
        DateTime dt = new DateTime(year, month, Jour);
        if (dt.DayOfWeek == DayOfWeek.Monday)
            return "L "+day;
        if (dt.DayOfWeek == DayOfWeek.Tuesday)
            return "M " + day;
        if (dt.DayOfWeek == DayOfWeek.Wednesday)
            return "M " + day;
        if (dt.DayOfWeek == DayOfWeek.Thursday)
            return "J " + day;
        if (dt.DayOfWeek == DayOfWeek.Friday)
            return "V " + day;
        if (dt.DayOfWeek == DayOfWeek.Saturday)
            return "S " + day;
        if (dt.DayOfWeek == DayOfWeek.Sunday)
            return "D " + day;
        else
            throw new Exception ("Erreur dans l'acquisition du jour"); 
    }

    /// <summary>
    /// Ensemble de fonctions ajoutant les jours et leur préfixe dans les DDL correspondantes en retirant les jours déja sélectionnés dans les autres DDL
    /// </summary>
    #region Binding DDL_jour;
    protected void BindingDDL_jour_1()

    {
        try
        {
            DateTime date = DateTime.Now;
            int mois = 0;
            int annee = date.Year;


            if (date.Day < 29)
                mois = date.Month - 1;
            else
                mois = date.Month;

            if (mois == 0)
            {
                mois = 12;
                annee = date.Year - 1;
            }


            for (int i = 1; i <= DateTime.DaysInMonth(Convert.ToInt32(lbl_annee.Text), mois); i++)
            {
                String jour = "";
                if (i<10)
                    jour = "0"+i;
                else
                    jour = ""+i;
                ListItem item = new ListItem(prefixDay(jour, mois, annee), i.ToString());
                
                if (!ddl_jour_1.Items.Contains(item))
                    ddl_jour_1.Items.Insert(i-1, item);
                
                
            }





        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void BindingDDL_jour_2()
    {
        try
        {
            DateTime date = DateTime.Now;
            int mois = 0;
            int annee = date.Year;


            if (date.Day < 29)
                mois = date.Month - 1;
            else
                mois = date.Month;

            if (mois == 0)
            {
                mois = 12;
                annee = date.Year - 1;
            }


            for (int i = 1; i <= DateTime.DaysInMonth(Convert.ToInt32(lbl_annee.Text), mois); i++)
            {
                String jour = "";
                if (i < 10)
                    jour = "0" + i;
                else
                    jour = "" + i;
                ListItem item = new ListItem(prefixDay(jour, mois, annee), i.ToString());

                if (!ddl_jour_2.Items.Contains(item))
                    ddl_jour_2.Items.Insert(i - 1, item);


            }


        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void BindingDDL_jour_3()
    {
        try
        {
            DateTime date = DateTime.Now;
            int mois = 0;
            int annee = date.Year;


            if (date.Day < 29)
                mois = date.Month - 1;
            else
                mois = date.Month;

            if (mois == 0)
            {
                mois = 12;
                annee = date.Year - 1;
            }


            for (int i = 1; i <= DateTime.DaysInMonth(Convert.ToInt32(lbl_annee.Text), mois); i++)
            {
                String jour = "";
                if (i < 10)
                    jour = "0" + i;
                else
                    jour = "" + i;
                ListItem item = new ListItem(prefixDay(jour, mois, annee), i.ToString());

                if (!ddl_jour_3.Items.Contains(item))
                    ddl_jour_3.Items.Insert(i - 1, item);


            }


        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void BindingDDL_jour_4()
    {
        try
        {
            DateTime date = DateTime.Now;
            int mois = 0;
            int annee = date.Year;


            if (date.Day < 29)
                mois = date.Month - 1;
            else
                mois = date.Month;

            if (mois == 0)
            {
                mois = 12;
                annee = date.Year - 1;
            }


            for (int i = 1; i <= DateTime.DaysInMonth(Convert.ToInt32(lbl_annee.Text), mois); i++)
            {
                String jour = "";
                if (i < 10)
                    jour = "0" + i;
                else
                    jour = "" + i;
                ListItem item = new ListItem(prefixDay(jour, mois, annee), i.ToString());

                if (!ddl_jour_4.Items.Contains(item))
                    ddl_jour_4.Items.Insert(i - 1, item);


            }


        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void BindingDDL_jour_5()
    {
        try
        {
            DateTime date = DateTime.Now;
            int mois = 0;
            int annee = date.Year;


            if (date.Day < 29)
                mois = date.Month - 1;
            else
                mois = date.Month;

            if (mois == 0)
            {
                mois = 12;
                annee = date.Year - 1;
            }



            for (int i = 1; i <= DateTime.DaysInMonth(Convert.ToInt32(lbl_annee.Text), mois); i++)
            {
                String jour = "";
                if (i < 10)
                    jour = "0" + i;
                else
                    jour = "" + i;
                ListItem item = new ListItem(prefixDay(jour, mois, annee), i.ToString());

                if (!ddl_jour_5.Items.Contains(item))
                    ddl_jour_5.Items.Insert(i - 1, item);


            }


        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

#endregion Binding DDL_jour;

    /// <summary>
    /// Appelle la fonction SelectDDL_Nb lors du changement d'index de ddl_nb
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddl_nb_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectDDL_Nb();
        entries.Visible = true;
        btn_Valider.Visible = true;
    }

    /// <summary>
    /// Affiche les lignes d'entrées nécessaire et effectue une première suppression des doublons dans les DDL
    /// </summary>
    protected void SelectDDL_Nb()
    {
        try
        {
            switch (ddl_nb.SelectedValue)
            {
                default:
                    entry_1.Visible = false;
                    entry_2.Visible = false;
                    entry_3.Visible = false;
                    entry_4.Visible = false;
                    entry_5.Visible = false;
                    pnl_btn.Visible = false;
                    break;

                case "1":
                    entry_1.Visible = true;
                    entry_2.Visible = false;
                    entry_3.Visible = false;
                    entry_4.Visible = false;
                    entry_5.Visible = false;
                    pnl_btn.Visible = true;
                    if (tbx_nbMember_1.Text=="")
                        tbx_nbMember_1.Text = "" + nbMembers();
                    break;

                case "2":
                    entry_1.Visible = true;
                    entry_2.Visible = true;
                    entry_3.Visible = false;
                    entry_4.Visible = false;
                    entry_5.Visible = false;
                    pnl_btn.Visible = true;
                    if (tbx_nbMember_1.Text == "")
                        tbx_nbMember_1.Text = "" + nbMembers();
                    if (tbx_nbMember_2.Text == "")
                        tbx_nbMember_2.Text = "" + nbMembers();

                    ddl_jour_2.Items.Remove(ddl_jour_1.SelectedItem);

                    break;

                case "3":
                    entry_1.Visible = true;
                    entry_2.Visible = true;
                    entry_3.Visible = true;
                    entry_4.Visible = false;
                    entry_5.Visible = false;
                    pnl_btn.Visible = true;
                    if (tbx_nbMember_1.Text == "")
                        tbx_nbMember_1.Text = "" + nbMembers();
                    if (tbx_nbMember_2.Text == "")
                        tbx_nbMember_2.Text = "" + nbMembers();
                    if (tbx_nbMember_3.Text == "")
                        tbx_nbMember_3.Text = "" + nbMembers();

                    ddl_jour_2.Items.Remove(ddl_jour_1.SelectedItem);
                    ddl_jour_3.Items.Remove(ddl_jour_1.SelectedItem);
                    ddl_jour_3.Items.Remove(ddl_jour_2.SelectedItem);
                    break;

                case "4":
                    entry_1.Visible = true;
                    entry_2.Visible = true;
                    entry_3.Visible = true;
                    entry_4.Visible = true;
                    entry_5.Visible = false;
                    pnl_btn.Visible = true;
                    if (tbx_nbMember_1.Text == "")
                        tbx_nbMember_1.Text = "" + nbMembers();
                    if (tbx_nbMember_2.Text == "")
                        tbx_nbMember_2.Text = "" + nbMembers();
                    if (tbx_nbMember_3.Text == "")
                        tbx_nbMember_3.Text = "" + nbMembers();
                    if (tbx_nbMember_4.Text == "")
                        tbx_nbMember_4.Text = "" + nbMembers();

                    ddl_jour_2.Items.Remove(ddl_jour_1.SelectedItem);
                    ddl_jour_3.Items.Remove(ddl_jour_1.SelectedItem);
                    ddl_jour_3.Items.Remove(ddl_jour_2.SelectedItem);
                    ddl_jour_4.Items.Remove(ddl_jour_1.SelectedItem);
                    ddl_jour_4.Items.Remove(ddl_jour_2.SelectedItem);
                    ddl_jour_4.Items.Remove(ddl_jour_3.SelectedItem);
                    

                    break;

                case "5":
                    entry_1.Visible = true;
                    entry_2.Visible = true;
                    entry_3.Visible = true;
                    entry_4.Visible = true;
                    entry_5.Visible = true;
                    pnl_btn.Visible = true;
                    if (tbx_nbMember_1.Text == "")
                        tbx_nbMember_1.Text = "" + nbMembers();
                    if (tbx_nbMember_2.Text == "")
                        tbx_nbMember_2.Text = "" + nbMembers();
                    if (tbx_nbMember_3.Text == "")
                        tbx_nbMember_3.Text = "" + nbMembers();
                    if (tbx_nbMember_4.Text == "")
                        tbx_nbMember_4.Text = "" + nbMembers();
                    if (tbx_nbMember_5.Text == "")
                        tbx_nbMember_5.Text = "" + nbMembers();



                    ddl_jour_2.Items.Remove(ddl_jour_1.SelectedItem);
                    ddl_jour_3.Items.Remove(ddl_jour_1.SelectedItem);
                    ddl_jour_3.Items.Remove(ddl_jour_2.SelectedItem);
                    ddl_jour_4.Items.Remove(ddl_jour_1.SelectedItem);
                    ddl_jour_4.Items.Remove(ddl_jour_2.SelectedItem);
                    ddl_jour_4.Items.Remove(ddl_jour_3.SelectedItem);
                    ddl_jour_5.Items.Remove(ddl_jour_1.SelectedItem);
                    ddl_jour_5.Items.Remove(ddl_jour_2.SelectedItem);
                    ddl_jour_5.Items.Remove(ddl_jour_3.SelectedItem);
                    ddl_jour_5.Items.Remove(ddl_jour_4.SelectedItem);

                    break;
            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Gère la suppression d'une attiduité
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_supp_Click(object sender, EventArgs e)
    {
        try
        {
            string idstring = "";

            Button btn = (Button)sender;
            if(btn != null)
            {
                switch(btn.ID)
                {
                    case "btn_supp_1":
                        idstring = "" + hfd_id1.Value;
                        break;
                    case "btn_supp_2":
                        idstring = "" + hfd_id2.Value;
                        break;
                    case "btn_supp_3":
                        idstring = "" + hfd_id3.Value;
                        break;
                    case "btn_supp_4":
                        idstring = "" + hfd_id4.Value;
                        break;
                    case "btn_supp_5":
                        idstring = "" + hfd_id5.Value;
                        break;
                }

                if (!string.IsNullOrEmpty(idstring))
                {
                    int id = Convert.ToInt32(idstring);

                    if (DataMapping.Delete_Attendance(id) > 0)
                    {
                        Edit(/*ddl_annee.SelectedValue, ddl_mois.SelectedValue*/);
                    }
                    else
                    {
                        throw new Exception(id.ToString());
                    }
                }
                else
                {
                    throw new Exception("Impossible de récupérer l'ID");
                }
            }
            else
            {
                throw new Exception("Impossible de récupérer le boutton supprimer cliqué");
            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Définit si l'on affiche le label mois ou non
    /// </summary>
    /// <param name="VF"></param>
    protected void ShowMonth(bool VF)
    {
        try
        {
            lbl_mois.Visible = VF;
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Initialise les données de la page en fonction des inforamtions du GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvw_assiduite_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            Button btnModif = (Button)e.Row.FindControl("btn_modif");
            Label lblMois = (Label)e.Row.FindControl("lbl_mois_2");
            Label lblAnnee = (Label)e.Row.FindControl("lbl_annee_2");
            try
            {
                if (lblMois.Text == nbMonth().ToString() && lblAnnee.Text == lbl_annee.Text)
                {
                    btnModif.Visible = true;
                    pnl_titre.Visible = false;
                }
                else
                { 
                    btnModif.Visible = false;
                }
               
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
            
        }
    }

    /// <summary>
    /// Permet le rafraichissement des DDL ainsi que la suppression des doublons dans les autres DDL lors du changement d'index
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    #region DDL Refresh;
    protected void ddl_jour_1_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        if(entry_2.Visible)
        {
            BindingDDL_jour_2();
            ddl_jour_2.Items.Remove(ddl_jour_1.SelectedItem);
        }
        if(entry_3.Visible)
        {
            ddl_jour_2.Items.Remove(ddl_jour_3.SelectedItem);
            BindingDDL_jour_3();
            ddl_jour_3.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_2.SelectedItem);


        }
        if (entry_4.Visible)
        {
            ddl_jour_2.Items.Remove(ddl_jour_4.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_4.SelectedItem);
            BindingDDL_jour_4();
            ddl_jour_4.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_3.SelectedItem);


        }
        
        if(entry_5.Visible)
        {
            ddl_jour_2.Items.Remove(ddl_jour_5.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_5.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_5.SelectedItem);
            BindingDDL_jour_5();
            ddl_jour_5.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_4.SelectedItem);


        }
        
    }

    protected void ddl_jour_2_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindingDDL_jour_1();
        ddl_jour_1.Items.Remove(ddl_jour_2.SelectedItem);
        if (entry_3.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_3.SelectedItem);
            BindingDDL_jour_3();
            ddl_jour_3.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_2.SelectedItem);
        }
        if (entry_4.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_4.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_4.SelectedItem);
            BindingDDL_jour_4();
            ddl_jour_4.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_3.SelectedItem);
        }

        if (entry_5.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_5.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_5.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_5.SelectedItem);
            BindingDDL_jour_5();
            ddl_jour_5.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_4.SelectedItem);
        }
    }

    protected void ddl_jour_3_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindingDDL_jour_1();
        ddl_jour_1.Items.Remove(ddl_jour_3.SelectedItem);
        if(entry_2.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_2.SelectedItem);
            BindingDDL_jour_2();
            ddl_jour_2.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_3.SelectedItem);
        }
        if(entry_4.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_4.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_4.SelectedItem);
            BindingDDL_jour_4();
            ddl_jour_4.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_3.SelectedItem);
        }
        if(entry_5.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_5.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_5.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_5.SelectedItem);
            BindingDDL_jour_5();
            ddl_jour_5.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_4.SelectedItem);
        }
        
    }

    protected void ddl_jour_4_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindingDDL_jour_1();
        ddl_jour_1.Items.Remove(ddl_jour_4.SelectedItem);
        if(entry_3.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_3.SelectedItem);
            BindingDDL_jour_3();
            ddl_jour_3.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_4.SelectedItem);
        }
        if(entry_2.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_2.SelectedItem);
            BindingDDL_jour_2();
            ddl_jour_2.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_4.SelectedItem);
        }
        if(entry_5.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_5.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_5.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_5.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_5.SelectedItem);
            BindingDDL_jour_5();
            ddl_jour_5.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_4.SelectedItem);
        }
        
    }

    protected void ddl_jour_5_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindingDDL_jour_1();
        ddl_jour_1.Items.Remove(ddl_jour_5.SelectedItem);
        if (entry_3.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_3.SelectedItem);
            BindingDDL_jour_3();
            ddl_jour_3.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_4.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_5.SelectedItem);
        }
        if(entry_2.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_4.Items.Remove(ddl_jour_2.SelectedItem);
            ddl_jour_5.Items.Remove(ddl_jour_2.SelectedItem);
            BindingDDL_jour_2();
            ddl_jour_2.Items.Remove(ddl_jour_1.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_3.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_4.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_5.SelectedItem);

        }
        if(entry_4.Visible)
        {
            ddl_jour_1.Items.Remove(ddl_jour_4.SelectedItem);
            ddl_jour_3.Items.Remove(ddl_jour_4.SelectedItem);
            ddl_jour_2.Items.Remove(ddl_jour_4.SelectedItem);
            BindingDDL_jour_4();
            ddl_jour_4.Items.Remove(ddl_jour_5.SelectedItem);
        }
        
    }
    #endregion DDL Refresh;

    /// <summary>
    /// Calcule le nombre de membres dans le club courant
    /// </summary>
    /// <returns>Nombre de membres</returns>
    public int nbMembers ()
    {
        List<Member> membres = new List<Member>(DataMapping.ListMembers(Functions.CurrentCric));
        return membres.Count;
    }


}