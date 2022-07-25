
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

public partial class DesktopModules_AIS_Admin_DRYA_DRYA : PortalModuleBase
{
    /// <summary>
    /// Au démarrage de la page, permet d'actualiser les données et de choisir quelle DataList afficher
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            if (!IsPostBack)
            {
                
                int testSession = 0;
                // Sélectionne la page à afficher si l'on vient de la page d'arborescence
                if (Session["ID"] != null && Session["ID"].ToString() != null && Session["ID"].ToString() != "")
                {
                    if (Session["ID"].ToString() == "btn_redirectLes Gouverneurs et Conseillers")
                    {
                        lbl_titreDL.Text = "Gouverneurs et Conseillers";
                        dl_gouv.Visible = true;
                        lbl_cache.Text = "Gouv";

                    }
                    else if (Session["ID"].ToString() == "btn_redirectLe Bureau")
                    {
                        lbl_titreDL.Text = "Le Bureau";
                        dl_bureau.Visible = true;
                        lbl_cache.Text = "Bur";


                    }
                    else if (Session["ID"].ToString() == "btn_redirectLa Fondation")
                    {
                        lbl_titreDL.Text = "La Fondation";
                        dl_fondation.Visible = true;
                        lbl_cache.Text = "Fonda";

                    }
                    else if (Session["ID"].ToString() == "btn_redirectAdjoints Alpes-Maritimes et Monaco")
                    {
                        lbl_titreDL.Text = "Adjoints des Alpes-Maritimes et Monaco";
                        dl_amMonaco.Visible = true;
                        lbl_cache.Text = "amMonaco";

                    }
                    else if (Session["ID"].ToString() == "btn_redirectAdjoints Corse")
                    {
                        lbl_titreDL.Text = "Adjoints de Corse";
                        dl_Corse.Visible = true;
                        lbl_cache.Text = "Corse";

                    }
                    else if (Session["ID"].ToString() == "btn_redirectAdjoints Var")
                    {
                        lbl_titreDL.Text = "Adjoints du Var";
                        dl_Var.Visible = true;
                        lbl_cache.Text = "var";

                    }
                    else if (Session["ID"].ToString() == "btn_redirectLes Presidents des clubs")
                    {
                        lbl_titreDL.Text = "Les présidents des clubs";
                        dl_presidents.Visible = true;
                        lbl_cache.Text = "Pres";

                    }
                    else
                        testSession++;
                }
                else 
                    testSession++;

                if ( testSession!=0)
                {
                    lbl_titreDL.Text = "Gouverneurs et Conseillers";
                    dl_gouv.Visible = true;
                    lbl_cache.Text = "Gouv";
                    afficherModifArbo(lbl_cache.Text, Functions.GetRotaryYear());
                    
                }
                    
                



                CleartextBoxes(pnl_modif);
                rbt_anneeCourante.Text = "" + Functions.GetRotaryYear();
                rbt_anneePlusDeux.Text = "" + (Functions.GetRotaryYear() + 2);
                rbt_anneePlusUn.Text = "" + (Functions.GetRotaryYear() + 1);
                lbl_anneeRot.Text = rbl_anneeRot.SelectedValue.ToString();
                btn_commissionAjout.Visible = false;
                RefreshDL();
                RefreshGrid();
                BindDDL();
                if (!UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) && !UserInfo.IsSuperUser)
                {
                    btn_ajoutModifMember.Visible = false;
                    rbl_anneeRot.Visible = false;
                }






            }
            creerOrganigramme("AARD");

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

    #region Refresh et Bind 
    /// <summary>
    /// Permet l'actualisation des GridView
    /// </summary>
    public void RefreshGrid()
    {
        try
        {
            CleartextBoxes(pnl_modif);
            pnl_ddl.Visible = false;
            int anneeRot=int.Parse(rbl_anneeRot.SelectedValue);
            int test1 = 0;
            List<DRYA> lesArchi=null;
            if (DataMapping.GetListDRYA("[rotary_year] = " + rbl_anneeRot.SelectedValue) != null && DataMapping.GetListDRYA("").Count != 0) //On vérifie qu'il existe bien des données dans la table répondant aux critères
            {
                lesArchi = DataMapping.GetListDRYA("[rotary_year] = " + rbl_anneeRot.SelectedValue);






                // Création des listes
                List<DRYA> archiAdjAmMonaco = null;
                List<DRYA> archiAdjCorse = null;
                List<DRYA> archiAdjVar = null;
                List<DRYA> archiBureau = null;
                List<DRYA> archiFondation = null;
                List<DRYA> archiGouv = null;
                List<DRYA> archiPres = null;

                //Choix de la liste à synchroniser avec le GridView
                switch (lbl_cache.Text)
                {
                    case ("amMonaco"):
                        if (DataMapping.GetListDRYA("section = 'Adjoint Alpes-Maritimes Monaco' AND [rotary_year] = " + rbl_anneeRot.SelectedValue) != null && DataMapping.GetListDRYA("section = 'Adjoint Alpes-Maritimes Monaco' AND [rotary_year] = " + rbl_anneeRot.SelectedValue).Count!=0)
                            archiAdjAmMonaco = DataMapping.GetListDRYA("section = 'Adjoint Alpes-Maritimes Monaco' AND [rotary_year] = " + rbl_anneeRot.SelectedValue);
                        else
                        {
                            test1++;
                            break;
                        }
                        gvw_modification.DataSource = archiAdjAmMonaco;
                        tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Adjoint Alpes-Maritimes Monaco' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                        break;

                    case ("Corse"):
                        if (DataMapping.GetListDRYA("section = 'Adjoint Corse'  AND [rotary_year] = " + rbl_anneeRot.SelectedValue) != null && DataMapping.GetListDRYA("section = 'Adjoint Corse'  AND [rotary_year] = " + rbl_anneeRot.SelectedValue).Count != 0)
                            archiAdjCorse = DataMapping.GetListDRYA("section = 'Adjoint Corse'  AND [rotary_year] = " + rbl_anneeRot.SelectedValue);
                        else
                        {
                            test1++;
                            break;
                        }
                        gvw_modification.DataSource = archiAdjCorse;
                        tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Adjoint Corse' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                        break;

                    case ("var"):
                        if (DataMapping.GetListDRYA("section = 'Adjoint Var' AND [rotary_year] = " + rbl_anneeRot.SelectedValue) != null && DataMapping.GetListDRYA("section = 'Adjoint Var' AND [rotary_year] = " + rbl_anneeRot.SelectedValue).Count != 0)
                            archiAdjVar = DataMapping.GetListDRYA("section = 'Adjoint Var' AND [rotary_year] = " + rbl_anneeRot.SelectedValue);
                        else
                        {
                            test1++;
                            break;
                        }
                        gvw_modification.DataSource = archiAdjVar;
                        tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Adjoint Var' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                        break;
                    case ("Bur"):
                        if (DataMapping.GetListDRYA("section = 'Bureau' AND [rotary_year] = " + anneeRot) != null && DataMapping.GetListDRYA("section = 'Bureau' AND [rotary_year] = " + anneeRot).Count != 0)
                            archiBureau = DataMapping.GetListDRYA("section = 'Bureau' AND [rotary_year] = " + anneeRot);
                        else
                        {
                            test1++;
                            break;
                        }
                        gvw_modification.DataSource = archiBureau;
                        tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Bureau' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                        break;
                    case ("Fonda"):
                        if (DataMapping.GetListDRYA("section = 'Fondation' AND [rotary_year] = " + rbl_anneeRot.SelectedValue)!=null && DataMapping.GetListDRYA("section = 'Fondation' AND [rotary_year] = " + rbl_anneeRot.SelectedValue).Count != 0)
                            archiFondation = DataMapping.GetListDRYA("section = 'Fondation' AND [rotary_year] = " + rbl_anneeRot.SelectedValue);
                        else
                        { 
                            test1++;
                            break;
                        }
                        gvw_modification.DataSource = archiFondation;
                        tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Fondation' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                        break;
                    case ("Gouv"):
                        if (DataMapping.GetListDRYA("section = 'Gouverneur' AND [rotary_year] = " + rbl_anneeRot.SelectedValue)!=null && DataMapping.GetListDRYA("section = 'Gouverneur' AND [rotary_year] = " + rbl_anneeRot.SelectedValue).Count != 0)
                            archiGouv = DataMapping.GetListDRYA("section = 'Gouverneur' AND [rotary_year] = " + rbl_anneeRot.SelectedValue);
                        else
                        {
                            test1++;
                            break;
                        }
                        gvw_modification.DataSource = archiGouv;
                        tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Gouverneur' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                        break;
                    case ("Pres"):
                        if (DataMapping.GetListDRYA("section = 'Président' AND [rotary_year] = " + rbl_anneeRot.SelectedValue)!=null && DataMapping.GetListDRYA("section = 'Président' AND [rotary_year] = " + rbl_anneeRot.SelectedValue).Count != 0)
                            archiPres = DataMapping.GetListDRYA("section = 'Président' AND [rotary_year] = " + rbl_anneeRot.SelectedValue);
                        else
                        {
                            test1++;
                            break;
                        }
                        gvw_modification.DataSource = archiPres;
                        tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Président' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                        pnl_ddl.Visible = false;
                        break;
                }
                if (test1 != 0)
                {
                    List<DRYA> lesArchiVides = new List<DRYA>();
                    gvw_modification.DataSource = null;
                    gvw_modification.DataBind();
                    gvw_modification.DataSource = lesArchiVides;
                    gvw_modification.DataBind();
                    tbx_rangModif.Text = "1";
                }
                else 
                    gvw_modification.DataBind();
            }
            else
            {
                List<DRYA> lesArchiVides = new List<DRYA>();
                gvw_modification.DataSource = null;
                gvw_modification.DataBind();
                gvw_modification.DataSource = lesArchiVides;
                gvw_modification.DataBind();
                tbx_rangModif.Text = "1";
            }
                
            
            
               

            //Dans le cas des commissions
                #region Commission

                List<Commission> listeCommission = DataMapping.GetListCommission("name = '" + ddl_commission.SelectedValue + "'");
                gvw_commission.DataSource = listeCommission;
                gvw_commission.DataBind();

                BindDDL();

                #endregion Commission
            
            BindDDL();
            afficherModifArbo(lbl_cache.Text, int.Parse(rbl_anneeRot.SelectedValue));
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        
        

 
    }

    /// <summary>
    /// Permet l'actualisation des DataList
    /// </summary>
    public void RefreshDL()
    {
        try
        {
            //CleartextBoxes(pnl_modif);
            int anneeRot = int.Parse(rbl_anneeRot.SelectedValue);
            int test=0;
            List<DRYA> archiAdjAmMonaco = null;
            List<DRYA> archiAdjCorse = null;
            List<DRYA> archiAdjVar = null;
            List<DRYA> archiBureau = null;
            List<DRYA> archiFondation = null;
            List<DRYA> archiGouv = null;
            List<DRYA> archiPres = null;

            //Avant de remplir les listes, on vérifie qu'il existe bien des données répondant aux critères définis

            if (DataMapping.GetListDRYA("section = 'Adjoint Alpes-Maritimes Monaco' AND [rotary_year] = " + anneeRot)!=null && DataMapping.GetListDRYA("section = 'Adjoint Alpes-Maritimes Monaco' AND [rotary_year] = " + anneeRot).Count!=0) 
            {
                archiAdjAmMonaco = DataMapping.GetListDRYA("section = 'Adjoint Alpes-Maritimes Monaco' AND [rotary_year] = " + anneeRot);
                test++;
            }
                
            if (DataMapping.GetListDRYA("section = 'Adjoint Corse' AND [rotary_year] = " + anneeRot)!=null && DataMapping.GetListDRYA("section = 'Adjoint Corse' AND [rotary_year] = " + anneeRot).Count!=0)
            {
                archiAdjCorse = DataMapping.GetListDRYA("section = 'Adjoint Corse' AND [rotary_year] = " + anneeRot);
                test++;
            }
            if (DataMapping.GetListDRYA("section = 'Adjoint Var' AND [rotary_year] = " + anneeRot)!=null && DataMapping.GetListDRYA("section = 'Adjoint Var' AND [rotary_year] = " + anneeRot).Count!=0)
            {
                archiAdjVar = DataMapping.GetListDRYA("section = 'Adjoint Var' AND [rotary_year] = " + anneeRot);
                test++;
            }
            if (DataMapping.GetListDRYA("section = 'Bureau' AND [rotary_year] = " + anneeRot)!=null && DataMapping.GetListDRYA("section = 'Bureau' AND [rotary_year] = " + anneeRot).Count!=0)
            {
                archiBureau = DataMapping.GetListDRYA("section = 'Bureau' AND [rotary_year] = " + anneeRot);
                test++;
            }
            if(DataMapping.GetListDRYA("section = 'Fondation' AND [rotary_year] = " + anneeRot)!=null && DataMapping.GetListDRYA("section = 'Fondation' AND [rotary_year] = " + anneeRot).Count!=0)
            {
                archiFondation = DataMapping.GetListDRYA("section = 'Fondation' AND [rotary_year] = " + anneeRot);
                test++;
            }
           if(DataMapping.GetListDRYA("section = 'Gouverneur' AND [rotary_year] = " + anneeRot)!=null && DataMapping.GetListDRYA("section = 'Gouverneur' AND [rotary_year] = " + anneeRot).Count!=0)
           {
               archiGouv = DataMapping.GetListDRYA("section = 'Gouverneur' AND [rotary_year] = " + anneeRot);
               test++;
           }
            if(DataMapping.GetListDRYA("section = 'Président' AND [rotary_year] = " + anneeRot)!=null && DataMapping.GetListDRYA("section = 'Président' AND [rotary_year] = " + anneeRot).Count!=0)
            {
                archiPres = DataMapping.GetListDRYA("section = 'Président' AND [rotary_year] = " + anneeRot);
                test++;
            }
            if (test==0)
            {
                dl_gouv.DataSource = new List<DRYA>();
                dl_gouv.DataBind();
            }
            




            dl_gouv.DataSource = archiGouv;
            dl_presidents.DataSource = archiPres;
            dl_amMonaco.DataSource = archiAdjAmMonaco;
            dl_bureau.DataSource = archiBureau;
            dl_Corse.DataSource = archiAdjCorse;
            dl_fondation.DataSource = archiFondation;
            dl_Var.DataSource = archiAdjVar;

            //On ne Bind que les DL visibles
            if (dl_amMonaco.Visible == true)
            {
                if (archiAdjAmMonaco != null)
                {
                    dl_amMonaco.DataBind();
                    lbl_dlVide.Visible = false;
                }  
                else
                {
                    lbl_dlVide.Visible = true;
                    dl_amMonaco.Visible = false;
                }
            }
            else if (dl_Corse.Visible == true)
            {
                if (archiAdjCorse != null)
                {
                    dl_Corse.DataBind();
                    lbl_dlVide.Visible = false;
                }
                else
                {
                    lbl_dlVide.Visible = true;
                    dl_Corse.Visible = false;
                }
            }
            else if (dl_Var.Visible == true)
            {
                if (archiAdjVar != null)
                {
                    dl_Var.DataBind();
                    lbl_dlVide.Visible = false;
                }
                else
                {
                    lbl_dlVide.Visible = true;
                    dl_Var.Visible = false;
                }
            }

            else if (dl_bureau.Visible == true)
            {
                if (archiBureau != null)
                {
                    dl_bureau.DataBind();
                    lbl_dlVide.Visible = false;
                }
                else
                {
                    lbl_dlVide.Visible = true;
                    dl_bureau.Visible = false;
                }
            }
            else if (dl_fondation.Visible == true)
            {
                if (archiFondation != null)
                {
                    dl_fondation.DataBind();
                    lbl_dlVide.Visible = false;
                }
                else
                {
                    lbl_dlVide.Visible = true;
                    dl_fondation.Visible = false;
                }
            }
            else if (dl_gouv.Visible == true)
            {
                if (archiGouv != null)
                {
                    dl_gouv.DataBind();
                    lbl_dlVide.Visible = false;
                }
                else
                {
                    lbl_dlVide.Visible = true;
                    dl_gouv.Visible = false;
                }
            }
            else if (dl_presidents.Visible == true)
            {
                if (archiPres != null)
                {
                    dl_presidents.DataBind();
                    lbl_dlVide.Visible = false;
                }
                else
                {
                    lbl_dlVide.Visible = true;
                    dl_presidents.Visible = false;
                }
            }


        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
        

    }

    /// <summary>
    /// Permet de remplir les DropDownList avec les données correspondantes
    /// </summary>
    public void BindDDL()
    {
        try
        {
            
                ddl_fonctModif.Items.Clear();
                ddl_ajoutNom.Items.Clear();
                ddl_nim.Items.Clear();
                ddl_commission.Items.Clear();
                //On ne Bind que les 10 membres dont le nom ou le prénom se rapprochent le plus du texte entré dans la TextBox
                List<Member> membres = DataMapping.ListTopTenMembers(0, tbx_search.Text);
                List<int> nim = new List<int>();
                List<String> fonctionsAdjoints = new List<string>();
                List<Commission> lesCom = DataMapping.GetListCommission("");
                int testCom = 0;
                foreach (Commission com in lesCom)
                {
                    if (com.rotary_year==int.Parse(rbl_anneeRot.SelectedValue))
                    {
                        testCom = 1;
                        break;
                    }
                }
                List<Commission> listeCommission =new List<Commission>();
                if(testCom!=0)
                    listeCommission = DataMapping.GetListCommission("[rotary_year] =" + rbl_anneeRot.SelectedValue );
                

                #region fonction
                //Bind des fonctions

                for (int i = 1; i < 7; i++)
                {
                    string fonctionAdjoint = "";
                    if (lbl_cache.Text == "amMonaco")
                        fonctionAdjoint = "Adjoint du Gouverneur : Groupe 06-" + i;
                    else if (lbl_cache.Text == "Corse")
                    {
                        fonctionAdjoint = "Adjoint du Gouverneur : Groupe 20-" + i;
                    }
                    else if (lbl_cache.Text == "var")
                        fonctionAdjoint = "Adjoint du Gouverneur : Groupe 83-" + i;

                    if (fonctionAdjoint != "")
                        fonctionsAdjoints.Add(fonctionAdjoint);
                }


                if (fonctionsAdjoints.Count != 0)
                {
                    foreach (string fonctionAdjoint in fonctionsAdjoints)
                        ddl_fonctModif.Items.Add(fonctionAdjoint);
                }
                else
                {
                    switch (lbl_cache.Text)
                    {
                        case ("Bur") :
                            ddl_fonctModif.Items.Add("Secrétaire de District");
                            ddl_fonctModif.Items.Add("Trésorier de District");
                            ddl_fonctModif.Items.Add("Chef du protocole de District");
                            ddl_fonctModif.Items.Add("Secrétaire de District Adjoint");
                            ddl_fonctModif.Items.Add("Trésorier de District Adjoint");
                            ddl_fonctModif.Items.Add("Chef du protocole de District Adjoint");
                            ddl_fonctModif.Items.Add("Webmestre de District");
                            ddl_fonctModif.Items.Add("Édition | Lettre du Gouverneur");
                            ddl_fonctModif.Items.Add("Communication");
                            ddl_fonctModif.Items.Add("Site internet et Réseau");
                            ddl_fonctModif.Items.Add("Image Publique");
                            break;

                        case ("Fonda") :
                            ddl_fonctModif.Items.Add("Président de la Commission");
                            ddl_fonctModif.Items.Add("Gestion Financière");
                            ddl_fonctModif.Items.Add("Objectif des Dons");
                            ddl_fonctModif.Items.Add("Subventions et Bourses");
                            ddl_fonctModif.Items.Add("Anciens de la Fondation");
                            ddl_fonctModif.Items.Add("Audit");
                            ddl_fonctModif.Items.Add("Archivage");
                            ddl_fonctModif.Items.Add("Certification");
                            ddl_fonctModif.Items.Add("Polio Plus");
                            break;

                        case ("Gouv") :
                            ddl_fonctModif.Items.Add("Gouverneur");
                            ddl_fonctModif.Items.Add("Gouverneur Élu");
                            ddl_fonctModif.Items.Add("Gouverneur Nommé");
                            ddl_fonctModif.Items.Add("Conseiller Spécial");
                            ddl_fonctModif.Items.Add("Conseiller");
                            break;
                    }
                }
                #endregion fonction

                #region nom
                //Bind des noms

                if (membres.Count != 0)
                {
                    foreach (Member membre in membres)
                    {
                        int j = 0;
                        string nom = membre.civility + " " + membre.surname + " " + membre.name + " (" + membre.club_name + ")"; //On ajoute au nom et au prénom le club du membre
                        ListItem item = new ListItem(nom);
                        for (int i = 0; i < ddl_ajoutNom.Items.Count; i++)
                        {
                            if (membre.removed != "O" && nom.CompareTo(ddl_ajoutNom.Items[i].ToString()) == -1 && !ddl_ajoutNom.Items.Contains(item)) //Les noms sont classés par ordre alphabétique
                            {
                                ddl_ajoutNom.Items.Insert(i, nom);
                                nim.Insert(i, membre.nim);
                                j = i;
                                break;
                            }
                        }
                        
                        if (j == 0 && membre.removed != "O" && !ddl_ajoutNom.Items.Contains(item))
                        {
                            ddl_ajoutNom.Items.Add(nom);
                            nim.Add(membre.nim);
                        }
                    }

                    foreach (int i in nim)
                    {//On ajoute dans une DDL invisible le nim du membre au même index
                        ddl_nim.Items.Add(i.ToString());
                    }
                    lbl_vide.Visible = false;
                    btn_Valider.Visible = true;
                    ddl_fonctModif.Visible = true;
                    lbl_fonctionModif.Visible = true;
                    lbl_desc.Visible = true;
                    tbx_desc.Visible = true;
                    lbl_rangModif.Visible = true;
                    tbx_rangModif.Visible = true;
                }
                else
                {//Si aucun membre n'est trouvé, affiche un message d'erreur
                    ddl_ajoutNom.Visible = false;
                    lbl_vide.Visible = true;
                    btn_Valider.Visible = false;
                    ddl_fonctModif.Visible = false;
                    lbl_fonctionModif.Visible = false;
                    lbl_desc.Visible = false;
                    tbx_desc.Visible = false;
                    lbl_rangModif.Visible = false;
                    tbx_rangModif.Visible = false;
                }


                #endregion nom

                #region commission
                //Bind des commissions
                ddl_commission.Items.Add("--Selectionnez une commission--");
                if (listeCommission.Count != 0 && listeCommission != null)
                {
                    foreach (Commission com in listeCommission)
                    {
                        ListItem item = new ListItem(com.name);
                        if (!ddl_commission.Items.Contains(item))
                        {//On vérifie de ne pas ajouter deux fois la même commission
                            ddl_commission.Items.Add(item);
                        }
                    }
                }


                #endregion commission
            
            
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

    #endregion Refresh et Bind  
   
    #region Boutons
    /// <summary>
    /// Évènement gérant le bouton de modification des aard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_modifier_Click(object sender, EventArgs e)
    {
        pnl_contenu.Visible = false;
        pnl_modif.Visible = true;
        btn_ajouter.Visible = true;
        lbl_pres.Visible = false;
        pnl_domaine.Visible = false;
        
        RefreshDL();
        RefreshGrid();
        BindDDL();

    }

    /// <summary>
    /// Évènement gérant le bouton de retour
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_retour_Click(object sender, EventArgs e)
    {
        RefreshDL();
        RefreshGrid();
        ddl_ajoutNom.Visible = false;
        pnl_domaine.Visible = true;
        pnl_contenu.Visible = true;
        pnl_modif.Visible = false;
        pnl_ddl.Visible = false;
        lbl_rangModif.Visible = false;
        tbx_rangModif.Visible = false;
        afficherModifArbo(lbl_cache.Text, int.Parse(rbl_anneeRot.SelectedValue));
        RefreshDL();
        RefreshGrid();
    }

    #endregion Boutons

    #region DataLists

    /// <summary>
    /// Évènement appelé lors du bind de la DataList gérant les Gouverneurs & Conseillers
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_gouv_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.DataItem == null)
        {
            return;
        }
        lbl_cache.Text = "Gouv";
        DRYA archi = (DRYA)e.Item.DataItem;
        Member membre = DataMapping.GetMemberByNim(archi.nim);
        System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image1");
        System.Web.UI.WebControls.Label lblNom = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Nom");
        System.Web.UI.WebControls.Label lblClub = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Club");
        
        HyperLink hlContact = (HyperLink)e.Item.FindControl("HL_Contact");
        System.Web.UI.WebControls.Label lblFonction = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbl_Fonction");

        image.ImageUrl = membre.GetPhoto();
        Label lblDesc = (Label)e.Item.FindControl("lbl_description");
        lblDesc.Text =archi.description;
        lblNom.Text =archi.name+" "+ archi.surname;
        lblClub.Text = archi.club;
        lblFonction.Text = archi.job;
        PortalSettings ps = PortalController.GetCurrentPortalSettings();
        if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
        {
            hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,850,false);";
        }
        else
        {
            hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,500,false);";
        }

        if (membre.IsWoman() == true)
            hlContact.Text = "La contacter";

        




    }

    /// <summary>
    /// Évènement appelé lors du bind de la DataList gérant le Bureau
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_bureau_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem == null)
            {
                return;
            }
            lbl_cache.Text = "Bur";
            DRYA archi = (DRYA)e.Item.DataItem;
            Member membre = DataMapping.GetMemberByNim(archi.nim);
            System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image1");
            System.Web.UI.WebControls.Label lblNom = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Nom");
            System.Web.UI.WebControls.Label lblClub = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Club");
            HyperLink hlContact = (HyperLink)e.Item.FindControl("HL_Contact");
            System.Web.UI.WebControls.Label lblFonction = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbl_Fonction");

            Label lblDesc = (Label)e.Item.FindControl("lbl_description");
            lblDesc.Text = archi.description;
            image.ImageUrl = membre.GetPhoto();
            lblNom.Text = archi.name + " " + archi.surname;
            lblClub.Text = archi.club;
            lblFonction.Text = archi.job;
            PortalSettings ps = PortalController.GetCurrentPortalSettings();
            if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,850,false);";
            }
            else
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,500,false);";
            }

            if (membre.IsWoman() == true)
                hlContact.Text = "La contacter";
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

    /// <summary>
    /// Évènement appelé lors du bind de la DataList gérant la Fondation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_fondation_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem == null)
            {
                return;
            }
            lbl_cache.Text = "Fonda";
            DRYA archi = (DRYA)e.Item.DataItem;
            Member membre = DataMapping.GetMemberByNim(archi.nim);
            System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image1");
            System.Web.UI.WebControls.Label lblNom = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Nom");
            System.Web.UI.WebControls.Label lblClub = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Club");
            HyperLink hlContact = (HyperLink)e.Item.FindControl("HL_Contact");
            System.Web.UI.WebControls.Label lblFonction = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbl_Fonction");

            Label lblDesc = (Label)e.Item.FindControl("lbl_description");
            lblDesc.Text = archi.description;
            image.ImageUrl = membre.GetPhoto();
            lblNom.Text = archi.name + " " + archi.surname;
            lblClub.Text = archi.club;
            lblFonction.Text = archi.job;
            PortalSettings ps = PortalController.GetCurrentPortalSettings();
            if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,850,false);";
            }
            else
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,500,false);";
            }

            if (membre.IsWoman() == true)
                hlContact.Text = "La contacter";
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Évènement appelé lors du bind de la DataList gérant les Adjoints des Alpes-Maritimes et de Monaco
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_amMonaco_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem == null)
            {
                return;
            }
            lbl_cache.Text = "amMonaco";
            DRYA archi = (DRYA)e.Item.DataItem;
            Member membre = DataMapping.GetMemberByNim(archi.nim);
            System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image1");
            System.Web.UI.WebControls.Label lblNom = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Nom");
            System.Web.UI.WebControls.Label lblClub = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Club");
            HyperLink hlContact = (HyperLink)e.Item.FindControl("HL_Contact");
            System.Web.UI.WebControls.Label lblFonction = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbl_Fonction");

            Label lblDesc = (Label)e.Item.FindControl("lbl_description");
            lblDesc.Text = archi.description;
            image.ImageUrl = membre.GetPhoto();
            lblNom.Text = archi.name + " " + archi.surname;
            lblClub.Text = archi.club;
            lblFonction.Text = archi.job;
            PortalSettings ps = PortalController.GetCurrentPortalSettings();
            if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,850,false);";
            }
            else
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,500,false);";
            }

            if (membre.IsWoman() == true)
                hlContact.Text = "La contacter";
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }
    
    /// <summary>
    /// Évènement appelé lors du bind de la DataList gérant les Adjoints de Corse
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_Corse_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem == null)
            {
                return;
            }
            lbl_cache.Text = "Corse";
            DRYA archi = (DRYA)e.Item.DataItem;
            Member membre = DataMapping.GetMemberByNim(archi.nim);
            System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image1");
            System.Web.UI.WebControls.Label lblNom = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Nom");
            System.Web.UI.WebControls.Label lblClub = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Club");
            HyperLink hlContact = (HyperLink)e.Item.FindControl("HL_Contact");
            System.Web.UI.WebControls.Label lblFonction = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbl_Fonction");

            Label lblDesc = (Label)e.Item.FindControl("lbl_description");
            lblDesc.Text = archi.description;
            image.ImageUrl = membre.GetPhoto();
            lblNom.Text = archi.name + " " + archi.surname;
            lblClub.Text = archi.club;
            lblFonction.Text = archi.job;
            PortalSettings ps = PortalController.GetCurrentPortalSettings();
            if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,850,false);";
            }
            else
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,500,false);";
            }

            if (membre.IsWoman() == true)
                hlContact.Text = "La contacter";
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }
    
    /// <summary>
    /// Évènement appelé lors du bind de la DataList gérant les Adjoints du Var
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_Var_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem == null)
            {
                return;
            }

            lbl_cache.Text = "var";
            DRYA archi = (DRYA)e.Item.DataItem;
            Member membre = DataMapping.GetMemberByNim(archi.nim);
            System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image1");
            System.Web.UI.WebControls.Label lblNom = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Nom");
            System.Web.UI.WebControls.Label lblClub = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Club");
            HyperLink hlContact = (HyperLink)e.Item.FindControl("HL_Contact");
            System.Web.UI.WebControls.Label lblFonction = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbl_Fonction");

            Label lblDesc = (Label)e.Item.FindControl("lbl_description");
            lblDesc.Text = archi.description;
            image.ImageUrl = membre.GetPhoto();
            lblNom.Text = archi.name + " " + archi.surname;
            lblClub.Text = archi.club;
            lblFonction.Text = archi.job;
            PortalSettings ps = PortalController.GetCurrentPortalSettings();
            if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,850,false);";
            }
            else
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,500,false);";
            }

            if (membre.IsWoman() == true)
                hlContact.Text = "La contacter";
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }
    
    /// <summary>
    /// Évènement appelé lors du bind de la DataList gérant les Présidents des clubs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_presidents_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            if (e.Item.DataItem == null)
            {
                return;
            }
            lbl_cache.Text = "Pres";
            DRYA archi = (DRYA)e.Item.DataItem;
            Member membre = DataMapping.GetMemberByNim(archi.nim);
            System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image1");
            System.Web.UI.WebControls.Label lblNom = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Nom");
            System.Web.UI.WebControls.Label lblClub = (System.Web.UI.WebControls.Label)e.Item.FindControl("LBL_Club");
            HyperLink hlContact = (HyperLink)e.Item.FindControl("HL_Contact");
            System.Web.UI.WebControls.Label lblFonction = (System.Web.UI.WebControls.Label)e.Item.FindControl("lbl_Fonction");

            image.ImageUrl = membre.GetPhoto();
            lblNom.Text = archi.name + " " + archi.surname;
            lblClub.Text = archi.club;
            PortalSettings ps = PortalController.GetCurrentPortalSettings();
            if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,850,false);";
            }
            else
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,500,false);";
            }

            if (membre.IsWoman() == true)
                hlContact.Text = "La contacter";
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    #endregion DataLists

    #region Grid View Modif

    /// <summary>
    /// Évènement appelé lors du bind de la GridView gérant les modifications
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvw_modification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DRYA archi = (DRYA)e.Row.DataItem;
                System.Web.UI.WebControls.Label lblNomGrid = (System.Web.UI.WebControls.Label)e.Row.FindControl("lbl_nomGrid");
                System.Web.UI.WebControls.Label lblFonctGrid = (System.Web.UI.WebControls.Label)e.Row.FindControl("lbl_fonctGrid");
                System.Web.UI.WebControls.Button btnModifier = (System.Web.UI.WebControls.Button)e.Row.FindControl("btn_modifier");
                hfd_id.Value = "";
                hfd_nim.Value = "";

                lblNomGrid.Text = archi.name + " " + archi.surname;
                lblFonctGrid.Text = archi.job;
                

                if (lbl_cache.Text=="Pres")
                {
                    btnModifier.Visible = false;
                    lblFonctGrid.Text = "Président";
                }


            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        
        
    }
    
    /// <summary>
    /// Évènement gérant le bouton qui permet de modifier une aard déja existante
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_modifier_Click1(object sender, EventArgs e)
    {
        btn_annuler.Visible = true;
        btn_Valider.Visible = true;
        tbx_search.Visible = false;
        btn_search.Visible = false;
        pnl_ddl.Visible = true;
        ddl_ajoutNom.Visible = false;
        lbl_nomDDL.Visible = true;
        lbl_supp.Visible = false;
        lbl_nomModif.Visible = true;
        btn_Valider.Text = "Modifier";
        btn_ajouter.Visible = true;
        lbl_fonctionModif.Visible = true;
        lbl_desc.Visible = true;
        tbx_desc.Visible = true;
        ddl_fonctModif.Visible = true;
        btn_redirect.Visible = false;
        btn_ajouter.Visible = false;
        lbl_rangModif.Visible = false;
        tbx_rangModif.Visible = false;
        if (dl_presidents.Visible)
            ddl_fonctModif.Visible = false;
    }

    /// <summary>
    /// Évènement gérant la validation d'une action (ajouter, supprimer, modifier)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Valider_Click(object sender, EventArgs e)
    {
        try
        {
            btn_annuler.Visible = false;
            ddl_ajoutNom.Visible = false;
            int i = ddl_ajoutNom.SelectedIndex;
            if (btn_Valider.Text == "Ajouter")
                hfd_nim.Value = ddl_nim.Items[i].ToString();

            Member membre = DataMapping.GetMemberByNim(int.Parse(hfd_nim.Value.ToString()));
            
            if (btn_Valider.Text=="Modifier")
            {//Dans le cas d'une modification
                List<DRYA> DRYA = DataMapping.GetListDRYA("id = " + hfd_id.Value + " AND [rotary_year] = " + lbl_anneeRot.Text);//On sélectionne l'DRYA à modifier
                DRYA archi = new DRYA();
                archi.id = DRYA[0].id;
                archi.nim = DRYA[0].nim;
                archi.surname = DRYA[0].surname;
                archi.name = DRYA[0].name;
                archi.job = ddl_fonctModif.SelectedValue;
                archi.description = tbx_desc.Text;
                archi.cric = DRYA[0].cric;
                archi.club = DRYA[0].club;
                archi.section = DRYA[0].section;
                archi.rank = DRYA[0].rank;
                archi.rotary_year = DRYA[0].rotary_year;

                int id = DataMapping.InsertDRYA(archi);

            }
            
            else if (btn_Valider.Text=="Ajouter")
            {//Dans le cas d'un ajout
                DRYA archi2 = new DRYA();
                archi2.nim = membre.nim;
                archi2.surname = membre.surname;
                archi2.name = membre.name;
                archi2.cric = membre.cric;
                archi2.club = membre.club_name;
                switch (lbl_cache.Text)
                {
                    case "Gouv":
                        archi2.section = "Gouverneur";
                        break;
                    case "Bur":
                        archi2.section = "Bureau";
                        break;
                    case "Fonda":
                        archi2.section = "Fondation";
                        break;
                    case "Pres":
                        archi2.section = "Président";
                        break;
                    case "amMonaco":
                        archi2.section = "Adjoint Alpes-Maritimes Monaco";
                        break;
                    case "Corse":
                        archi2.section = "Adjoint Corse";
                        break;
                    case "var":
                        archi2.section = "Adjoint Var";
                        break;

                }
                
                archi2.job = ddl_fonctModif.SelectedValue;
                archi2.description = tbx_desc.Text;
                archi2.rotary_year = int.Parse(rbl_anneeRot.SelectedValue);
                int rang = 0;
                List<DRYA> lesArchi = null;
                if (DataMapping.GetListDRYA("") != null)
                {
                    lesArchi = DataMapping.GetListDRYA("");
                    foreach (DRYA archi in lesArchi)
                    {
                        if (archi2.section == archi.section && archi2.rotary_year == archi.rotary_year)
                        {
                            List<DRYA> lesArchiSectionAR = DataMapping.GetListDRYA("section ='" + archi.section + "' AND [rotary_year]=" + archi.rotary_year);
                            rang = lesArchiSectionAR.Count + 1;
                            break;
                        }

                    }
                    if (rang == 0)
                        rang = 1;
                    if (tbx_rangModif.Text == "")
                        tbx_rangModif.Text = "" + rang;
                    if (int.Parse(tbx_rangModif.Text) <= rang)
                        archi2.rank = int.Parse(tbx_rangModif.Text);
                    else
                        archi2.rank = rang;

                }
                else
                    archi2.rank = 1;

                
                int id = DataMapping.InsertDRYA(archi2);
                decalerApresDRYA(archi2);
                btn_redirect.Visible = true;
                lbl_rangModif.Visible = false;
                tbx_rangModif.Visible = false;
               
            }
            else if (btn_Valider.Text=="Supprimer")
            {//Dans le cas d'une suppression
                int id = int.Parse(hfd_id.Value);
                int rang = DataMapping.GetListDRYA("id=" + hfd_id.Value)[0].rank;
                string section = DataMapping.GetListDRYA("id=" + hfd_id.Value)[0].section;
                List<DRYA> listeAard = DataMapping.GetListDRYA("rang >=" + rang + " AND [rotary_year] = +" +rbl_anneeRot.SelectedValue + " AND section= '"+ section+ "'" );
                foreach (DRYA A in listeAard)
                {
                    A.rank--;
                    DataMapping.InsertDRYA(A);
                }
                if (!DataMapping.DeleteDRYA(id))
                {
                    throw new Exception("Problème de suppression");
                }
                RefreshGrid();
                RefreshDL();

            }
            else
                throw new Exception("Problème récup DRYA");






            ddl_fonctModif.Visible = false;
            btn_Valider.Visible = false;
            pnl_ddl.Visible = false;
            btn_ajouter.Visible = true;
            ddl_fonctModif.Visible = false;
            lbl_fonctionModif.Visible = false;
            lbl_desc.Visible = false;
            tbx_desc.Visible = false;
            lbl_rangModif.Visible = false;
            tbx_rangModif.Visible = false;
            ddl_ajoutNom.Visible = false;
            RefreshGrid();
           

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
            
        
    }
    
    /// <summary>
    /// Évènement se déclenchant lors d'une action sur une ligne : actualise les champs nécessaires à
    /// la poursuite des actions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvw_modification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lbl_nomModif.Text = e.CommandArgument.ToString();
            hfd_nim.Value = e.CommandName.ToString();
            hfd_id.Value = e.CommandName.ToString();
            

        }
        catch (Exception ee)
        { 
            Functions.Error(ee);
        }

    }

    /// <summary>
    /// Évènement gérant la suppression d'une aard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_supprimer_Click(object sender, EventArgs e)
    {
        try
        {
            btn_annuler.Visible = true;
            btn_Valider.Visible = true;
            tbx_search.Visible = false;
            btn_search.Visible = false;
            pnl_ddl.Visible = true;
            ddl_ajoutNom.Visible = false;
            lbl_nomDDL.Visible = false;
            lbl_rangModif.Visible = false;
            tbx_rangModif.Visible = false;
            lbl_supp.Visible = true;
            lbl_nomModif.Visible = true;
            btn_Valider.Text = "Supprimer";
            btn_ajouter.Visible = true;
            lbl_fonctionModif.Visible = false;
            lbl_desc.Visible = false;
            tbx_desc.Visible = false;
            ddl_fonctModif.Visible = false;
            if (dl_presidents.Visible)
                ddl_fonctModif.Visible = false;
            Page.ClientScript.RegisterStartupScript(GetType(), "anchor", "location.href = '#ancre_supp';", true);
            btn_ajouter.Visible = false;
            btn_redirect.Visible = false;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
            
    }

    /// <summary>
    /// Évènement gérant l'ajout d'une aard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        BindDDL();
        btn_Valider.Visible = false;
        btn_redirect.Visible = false;
        lbl_nomDDL.Visible = false;
        lbl_nomModif.Visible = false;
        lbl_supp.Visible = false;
        lbl_nomDDL.Visible = true;
        pnl_ddl.Visible = true;
        tbx_search.Visible = true;
        btn_search.Visible = true;
        btn_Valider.Text = "Ajouter";
        ddl_fonctModif.Visible = false;
        lbl_fonctionModif.Visible = false;
        lbl_desc.Visible = false;
        tbx_desc.Visible = false;
        lbl_rangModif.Visible = false;
        tbx_rangModif.Visible = false;
        btn_annuler.Visible = true;
        
    }

    /// <summary>
    /// Évènement gérant la recherche d'un membre en vue de l'ajouter
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_search_Click(object sender, EventArgs e)
    {
        ddl_ajoutNom.Visible = true;
        lbl_nomDDL.Visible = true;
        btn_Valider.Text = "Ajouter";
        btn_Valider.Visible = true;
        if (!lbl_vide.Visible)
        {
            lbl_rangModif.Visible = true;
            tbx_rangModif.Visible = true;
            lbl_fonctionModif.Visible = true;
            lbl_desc.Visible = true;
            tbx_desc.Visible = true;
            ddl_fonctModif.Visible = true;
            
        }
        else
        {
            lbl_rangModif.Visible = false;
            tbx_rangModif.Visible = false;
            lbl_fonctionModif.Visible = false;
            lbl_desc.Visible = false;
            tbx_desc.Visible = false;
            ddl_fonctModif.Visible = false;
            
        }    
        btn_ajouter.Visible = false;
        if (lbl_cache.Text == "Pres")
        {
            ddl_fonctModif.Visible = false;
            lbl_fonctionModif.Visible = false;
            lbl_desc.Visible = false;
            tbx_desc.Visible = false;
            lbl_rangModif.Visible = false;
            tbx_rangModif.Visible = false;
        }
        BindDDL();
    }

    /// <summary>
    /// Évènement gérant le bouton d'annulation d'une action
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_annuler_Click(object sender, EventArgs e)
    {
        ddl_ajoutNom.Visible = false;
        lbl_supp.Visible = false;
        lbl_nomDDL.Visible = false;
        lbl_nomModif.Visible = false;
        ddl_fonctModif.Visible = false;
        btn_annuler.Visible = false;
        btn_Valider.Visible = false;
        lbl_fonctionModif.Visible = false;
        lbl_desc.Visible = false;
        tbx_desc.Visible = false;
        tbx_search.Visible = false;
        btn_search.Visible = false;
        btn_ajouter.Visible = true;
        lbl_rangModif.Visible = false;
        tbx_rangModif.Visible = false;
        CleartextBoxes(pnl_modif);
        RefreshGrid();
    }

    #endregion Grid View Modif

    #region Table Domain
     
    /// <summary>
    /// Permet de créer les onglets sous forme d'un organigramme
    /// </summary>
    /// <param name="nomDomain">Le domaine dans lequel sont stockées les informations des onglets</param>
    public void creerOrganigramme (string nomDomain)
    {
        try
        {
            #region decalage
            //On cherche à placer les onglets suivant l'organigramme. On représente chaque onglet par son ID dans une liste d'int. Pour symboliser un décalage, on ajoutera un 0. Ainsi, un entier précédé d'un 0 sera l'enfant du dernier entier non précédé d'un 0. La liste se crée de la manière suivante :
            List<Domain> listeDomains = DataMapping.GetListDomain(nomDomain, "");
            List<int> listeId = new List<int>();
            for (int i=0; i<listeDomains.Count; i++)
            {
                if (!listeId.Contains(listeDomains[i].id))
                {
                    if (listeDomains[i].parent==0)
                        listeId.Add(listeDomains[i].id);
                    else
                    {
                        listeId.Add(0);
                        listeId.Add(listeDomains[i].id);
                    }
                
                    int j=i;
                    int decalage = 1;
                    while (aUnEnfant(listeDomains[j]) && j<listeDomains.Count)
                    {//tant que l'onglet a un enfant, il faut récupérer cet enfant et le placer après n+1 zéros. n étant le nombre de zéros précédant l'onglet parent
                        for(int k=0; k<decalage; k++)
                            listeId.Add(0);
                        listeId.Add(idEnfant(listeDomains[j]));
                        decalage++;
                        Domain domEnf = new Domain();
                        domEnf.id = idEnfant(listeDomains[j]);
                        domEnf.domain = listeDomains[j].domain;
                        j=trouverPos(domEnf);
                        }
                    }
            }

            #endregion decalage

            
            #region Bouton ou label
            //Ici, on utilise la liste précédemment créée pour ajouter les controles dans notre panel. Les derniers enfants seront des Boutons et les parents seront des Labels
            for (int i=0; i<listeId.Count; i++)
            {
                if (((i + 1 >= listeId.Count || listeId[i + 1] != 0) && listeId[i] != 0))
                {//Si l'int suivant n'est pas un zéro et que l'int actuel n'est pas un zéro ou qu'il est le dernier de la liste, on crée un Bouton
                    int w=0;
                    while (listeDomains[w].id!=listeId[i])
                        w++;
                    System.Web.UI.WebControls.LinkButton btn = new LinkButton();
                        btn = (LinkButton) creerControl(listeDomains[w].wording, btn);
                    pnl_domaine.Controls.Add(btn);
                    HtmlGenericControl br = new HtmlGenericControl("br");
                    pnl_domaine.Controls.Add(br);
                }
                else if(listeId[i]!=0 && listeId[i+1]==0)
                {//Si l'int actuel n'est pas un zéro mais que le suivant en est un, on crée un Label 
                    if (nbZeros(listeId,i,"apres")>nbZeros(listeId,i,"avant"))
                    {
                        int w = 0;
                        while (listeDomains[w].id != listeId[i])
                            w++;
                        System.Web.UI.WebControls.Label lbl = new Label();
                            lbl= (Label) creerControl(listeDomains[w].wording, lbl);
                        pnl_domaine.Controls.Add(lbl);
                        HtmlGenericControl br = new HtmlGenericControl("br");
                        pnl_domaine.Controls.Add(br);
                    }
                    else
                    {
                        int w = 0;
                        while (listeDomains[w].id != listeId[i])
                            w++;
                        System.Web.UI.WebControls.LinkButton btn = new LinkButton();
                        btn=(LinkButton)creerControl(listeDomains[w].wording, btn);
                        pnl_domaine.Controls.Add(btn);
                        HtmlGenericControl br = new HtmlGenericControl("br");
                        pnl_domaine.Controls.Add(br);
                    }
                    
                }
                else if(listeId[i]==0)
                {//Si l'int actuel est un 0, on crée un décalage
                    Literal nbsp = new Literal();
                    nbsp.Text = "&nbsp &nbsp &nbsp";
                    pnl_domaine.Controls.Add(nbsp);
                }
            }
            #endregion Bouton ou label
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Définit si l'onglet possède un enfant
    /// </summary>
    /// <param name="dom">Domain à étudier</param>
    /// <returns>Vérification</returns>
    public bool aUnEnfant (Domain dom)
    {
        List<Domain> listDom = DataMapping.GetListDomain(dom.domain, "");
        foreach (Domain domaine in listDom)
        {//Parcours la liste de domaines jusqu'à trouver l'enfant du domaine
            if (dom.id == domaine.parent)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Crée un contrôle du type spécifié (Bouton ou Label)
    /// </summary>
    /// <param name="nom">Nom associé au contrôle</param>
    /// <param name="type">Type du contrôle</param>
    /// <returns>Le contrôle créé</returns>
    public Control creerControl (string nom, Control type)
    {
        if (type.GetType() == typeof(LinkButton))
        {//Création d'un Bouton
            LinkButton btn = new LinkButton();
            btn.ID = "btn_" + nom;
            string nomEvent = btn.ID+"_Click";
            btn.Text = nom;
            btn.Click += new EventHandler(btn_click);
            btn.Width = 190;
            return btn;
        }
        else if (type.GetType() == typeof(Label))
        {//Création d'un Label
            Label lbl = new Label();
            lbl.ID = "lbl_" + nom;
            lbl.Text = nom;
            return lbl;
        }
        else
            throw new Exception ("Type de controle non reconnu ou non pris en charge");
    }

    /// <summary>
    /// Cherche l'ID de l'enfant d'un domaine
    /// </summary>
    /// <param name="dom">Domain parent</param>
    /// <returns>ID du domaine enfant</returns>
    public int idEnfant (Domain dom)
    {   
        if (!aUnEnfant(dom)) //On vérifie que le domaine a bien un enfant
            throw new Exception("Pas d'enfants");
        List<Domain> listeDom = DataMapping.GetListDomain(dom.domain,"");
        for (int i=0; i<listeDom.Count; i++)
        {//On parcourt la liste jusqu'à trouver l'ID de l'enfant
            if (listeDom[i].parent == dom.id)
                return listeDom[i].id;
        }
        throw new Exception("ID introuvable");
    }

    /// <summary>
    /// Trouve la position d'un domaine dans la liste de domaine 
    /// </summary>
    /// <param name="dom">Le domaine à chercher</param>
    /// <returns>Index de la position dans la liste</returns>
    public int trouverPos (Domain dom)
    {
        List<Domain> liste = DataMapping.GetListDomain(dom.domain, "");
        for (int i=0; i<liste.Count; i++)
        {//On parcourt la liste de domaines jusqu'à trouver la position du domaine
            if (liste[i].id == dom.id)
                return i;
        }
        throw new Exception("Id introuvable");
    }

    /// <summary>
    /// Compte le nombre de zéros avant ou après une position
    /// </summary>
    /// <param name="liste">List à parcourir</param>
    /// <param name="position">La position à partir de laquelle chercher</param>
    /// <param name="typeRecherche">Le sens dans lequel effectuer la recherche</param>
    /// <returns>Nombre de zéros trouvés avant un entier différent</returns>
    public int nbZeros (List<int> liste, int position, string typeRecherche)
    {
        int i = 1;
        int compteur = 0;
        if (typeRecherche == "avant")
        {//Recherche les zéros avant la position
            while (position - i > 0 && liste[position - i] == 0)
            {
                compteur++;
                i++;
            }
            return compteur;
        }
        else if (typeRecherche == "apres")
        {//Recherche les zéros après la position
            while (position + i < liste.Count && liste[position + i] == 0)
            {
                compteur++;
                i++;
            }
            return compteur;
        }
        else throw new Exception("Type de recherche non pris en charge ou incorrect");
    }

    /// <summary>
    /// Affiche le contenu en fonction de l'onglet cliqué. Vérifie si l'utilisateur à les autorisations pour avoir accès aux boutons de modification
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_click (object sender, EventArgs e)
    {

        LinkButton btn = (LinkButton)sender;
        switch (btn.ID)
        {
            case ("btn_Gouverneurs et Conseillers") :
                if (DataMapping.GetListDRYA("section = 'Gouverneur' AND [rotary_year] =" + rbl_anneeRot.SelectedValue) != null)
                    tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Gouverneur' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                else
                    tbx_rangModif.Text = "1";
                lbl_titreDL.Text = "Gouverneurs et Conseillers";
                dl_gouv.Visible = true;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;
                pnl_commission.Visible = false;
                btn_ajoutModifMember.Visible = true;
                btn_commissionAjout.Visible = false;
                rbl_anneeRot.Visible = true;
                lbl_cache.Text = "Gouv";
                break;
            case ("btn_Le Bureau") :
                if (DataMapping.GetListDRYA("section = 'Bureau' AND [rotary_year] =" + rbl_anneeRot.SelectedValue) != null)
                    tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Bureau' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                else
                    tbx_rangModif.Text = "1";
                lbl_titreDL.Text = "Le Bureau";
                dl_gouv.Visible = false;
                dl_bureau.Visible = true;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;
                pnl_commission.Visible = false;
                btn_ajoutModifMember.Visible = true;
                btn_commissionAjout.Visible = false;
                rbl_anneeRot.Visible = true;
                lbl_cache.Text = "Bur";
                break;
            case ("btn_La Fondation") :
                if (DataMapping.GetListDRYA("section = 'Fondation' AND [rotary_year] =" + rbl_anneeRot.SelectedValue) != null)
                    tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Fondation' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                else
                    tbx_rangModif.Text = "1";
                lbl_titreDL.Text = "La Fondation";
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = true;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;
                pnl_commission.Visible = false;
                btn_ajoutModifMember.Visible = true;
                btn_commissionAjout.Visible = false;
                rbl_anneeRot.Visible = true;
                lbl_cache.Text = "Fonda";
                break;
            case ("btn_Alpes Maritimes et Monaco"):
                if (DataMapping.GetListDRYA("section = 'Adjoint Alpes-Maritimes Monaco' AND [rotary_year] =" + rbl_anneeRot.SelectedValue) != null)
                    tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Adjoint Alpes-Maritimes Monaco' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                else
                    tbx_rangModif.Text = "1";
                lbl_titreDL.Text = "Adjoints des Alpes-Maritimes et Monaco";
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = true;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;
                pnl_commission.Visible = false;
                btn_ajoutModifMember.Visible = true;
                btn_commissionAjout.Visible = false;
                rbl_anneeRot.Visible = true;
                lbl_cache.Text = "amMonaco";
                break;
            case ("btn_Corse") :
                if (DataMapping.GetListDRYA("section = 'Adjoint Corse' AND [rotary_year] =" + rbl_anneeRot.SelectedValue) != null)
                    tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Adjoint Corse' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                else
                    tbx_rangModif.Text = "1";
                lbl_titreDL.Text = "Adjoints de Corse";
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = true;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;
                pnl_commission.Visible = false;
                btn_ajoutModifMember.Visible = true;
                btn_commissionAjout.Visible = false;
                rbl_anneeRot.Visible = true;
                lbl_cache.Text = "Corse";
                break;
            case ("btn_Var") :
                if (DataMapping.GetListDRYA("section = 'Adjoint Var' AND [rotary_year] =" + rbl_anneeRot.SelectedValue) != null)
                    tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Adjoint Var' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                else
                    tbx_rangModif.Text = "1";
                lbl_titreDL.Text = "Adjoints du Var";
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = true;
                dl_presidents.Visible = false;
                pnl_commission.Visible = false;
                btn_ajoutModifMember.Visible = true;
                btn_commissionAjout.Visible = false;
                rbl_anneeRot.Visible = true;
                lbl_cache.Text = "var";
                break;
            case ("btn_Les Commissions") :
                lbl_titreDL.Text = "Commissions";
                pnl_commission.Visible = true;
                btn_commissionAjout.Visible = true;
                creerCommission();
                lbl_cache.Text = "Com";
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;
                btn_ajoutModifMember.Visible = false;
                rbl_anneeRot.Visible = true;
                break;
            case ("btn_Les présidents des clubs") :
                if (DataMapping.GetListDRYA("section = 'Président' AND [rotary_year] =" + rbl_anneeRot.SelectedValue) != null)
                    tbx_rangModif.Text = "" + (DataMapping.GetListDRYA("section = 'Président' AND [rotary_year] =" + rbl_anneeRot.SelectedValue).Count + 1);
                else
                    tbx_rangModif.Text = "1";
                lbl_titreDL.Text = "Les présidents des clubs";
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = true;
                pnl_commission.Visible = false;
                btn_ajoutModifMember.Visible = true;
                btn_commissionAjout.Visible = false;
                rbl_anneeRot.Visible = true;
                lbl_cache.Text = "Pres";
                break;
        }
        if (!UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) && !UserInfo.IsSuperUser)
        {
            btn_ajoutModifMember.Visible = false;
            rbl_anneeRot.Visible = false;
            btn_commissionAjout.Visible = false;
        }
        afficherModifArbo(lbl_cache.Text, int.Parse(rbl_anneeRot.SelectedValue));
        RefreshDL();
        RefreshGrid();
    }
   
     #endregion Table domaine

    /// <summary>
    /// Permet de vider les TextBoxes dans un contrôle parent (ex : panel)
    /// </summary>
    /// <param name="parent"> Le nom du contrôle parent</param>
    protected void CleartextBoxes(Control parent)
    {

        foreach (System.Web.UI.Control c in parent.Controls)
        {
            if (c.GetType() == typeof(System.Web.UI.WebControls.TextBox))
            {

                ((System.Web.UI.WebControls.TextBox)(c)).Text = "";
            }
            else if (c.GetType() == typeof(System.Web.UI.WebControls.CheckBox))
            {

                ((System.Web.UI.WebControls.CheckBox)(c)).Checked = false;
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
    /// Déclenche une action lorsque l'on sélectionne une autre année rotarienne : BindDDl et affiche ou cache le bouton de redirection
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbl_anneeRot_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lbl_anneeRot.Text = rbl_anneeRot.SelectedValue.ToString();
            //Si l'on est sur la page des commissions, on crée de nouvelles commissions
            if (pnl_commission.Visible)
                creerCommission();
            afficherModifArbo(lbl_cache.Text, int.Parse(rbl_anneeRot.SelectedValue));
            //Sinon on affiche la DataList selon le texte du label Caché
            switch (lbl_cache.Text)
            {
                case ("Gouv") :
                    dl_gouv.Visible = true;
                    break;
                case ("Bur") :
                    dl_bureau.Visible = true;
                    break;
                case ("Fonda") :
                    dl_fondation.Visible = true;
                    break;
                case ("amMonaco") :
                    dl_amMonaco.Visible = true;
                    break;
                case ("Corse") :
                    dl_Corse.Visible = true;
                    break;
                case ("var") :
                    dl_Var.Visible = true;
                    break;
                case("Com") :
                    pnl_commission.Visible = true;
                    break;
                case ( "Pres") :
                    dl_presidents.Visible = true;
                    break;
            }

            //Enfin on actualise les données
            RefreshDL();
            RefreshGrid();
            BindDDL();
        }
        catch (Exception ee)
        { Functions.Error(ee); }

    }

    /// <summary>
    /// Affiche ou non le bouton de redirection suivant si les DataList sont vides ou non
    /// </summary>
    /// <param name="section"></param>
    /// <param name="anneeRot"></param>
    public void afficherModifArbo (string section, int anneeRot)
    {
        if (DataMapping.GetListDRYA("") != null && DataMapping.GetListDRYA("").Count != 0)
        {
            List<DRYA> lesArchi = DataMapping.GetListDRYA("");
            int testValeurs = 0;
            foreach (DRYA archi in lesArchi)
            {
                if (archi.rotary_year == anneeRot)
                {
                    switch (section)
                    {//Si il existe une entrée dans la table qui vérifie ces critères, on passe notre variable test à 1
                        case "Gouv":
                            testValeurs = 1;
                            break;
                        case "Bur":
                            testValeurs = 1;
                            break;
                        case "Fonda":
                            testValeurs = 1;
                            break;
                        case "Pres":
                            testValeurs = 1;
                            break;
                        case "amMonaco":
                            testValeurs = 1;
                            break;
                        case "Corse":
                            testValeurs = 1;
                            break;
                        case "var":
                            testValeurs = 1;
                            break;

                    }
                }
                if (testValeurs == 1)
                {//Si la variable test est à 1, on affiche le bouton
                    btn_redirect.Visible = true;
                    break;
                }


            }
            if (testValeurs == 0)
            {//Sinon, on le cache
                btn_redirect.Visible = false;
            }
        }
        else
            btn_redirect.Visible = false;
       
    }

    /// <summary>
    /// Redirige vers la page de gestion de l'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_redirect_Click(object sender, EventArgs e)
    {//Redirige l'utilisateur vers la page de modification d'arborescence correspondant à la page actuelle
        btn_redirect.ID += lbl_cache.Text;
        Session["ID"] = btn_redirect.ID;
        Response.Redirect("Arborescence.aspx");
    }

    /// <summary>
    /// Permet de décaler les membres lors d'un ajout d'aard s'il y a conflit entre deux rangs
    /// </summary>
    /// <param name="aard">L'DRYA que l'on rajoute</param>
    public void decalerApresDRYA(DRYA aard)
    {
        List<DRYA> tot = DataMapping.GetListDRYA("");
        int testRang =0;
        foreach (DRYA aard1 in tot)
        {
            if (aard1.rank==aard.rank && aard1.rotary_year==aard.rotary_year && aard1.section==aard.section)
            {
                testRang++;
                break;
            }
        }
        if (testRang == 0)
            throw new Exception("Ce rang n'existe pas dans la table à cette année rotarienne");
        else
        {
            List<DRYA> aardRang = DataMapping.GetListDRYA("rang =" + aard.rank+ " AND [rotary_year] ="+ aard.rotary_year + " AND section = '"+ aard.section+"'");
            if (aardRang.Count>1) //On vérifie si deux DRYA ont le même rang
            {
                List<DRYA> aardSup = DataMapping.GetListDRYA("[rotary_year] ="+aard.rotary_year + " and rang >= + "+aard.rank+ " AND section = '"+aard.section+"'");
                foreach (DRYA A in aardSup)
                {
                    if (A.surname != aard.surname)
                    {
                        A.rank++; //Pour chaque DRYA qui a le même rang que l'assiduité que l'on veut rajouter, on augemente ce rang
                        DataMapping.InsertDRYA(A);
                    }
                    
                }
            }
        }
    }

    #region Commission

    /// <summary>
    /// Permet de créer dynamiquement un ensemble de commissions
    /// </summary>
    public void creerCommission()
    {
        try
        {
            List<Commission> lesCom = DataMapping.GetListCommission("");
            int testCom = 0;
            foreach (Commission com in lesCom)
            {
                if (com.rotary_year == int.Parse(rbl_anneeRot.SelectedValue))
                {//On vérifie qu'il existe au moins une commission à cette annéee rotarienne
                    testCom = 1;
                    break;
                }
            }
            List<Commission> listeCommission = new List<Commission>();
            if (testCom == 0)
            {//S'il n'y a pas de commission, on affiche un Label disant qu'il n'y a pas de données
                pnl_commission.Visible = false;
                lbl_dlVide.Visible = true;
            }
            else
            {
                pnl_commission.Visible = true;
                lbl_dlVide.Visible = false;
                listeCommission = DataMapping.GetListCommission("[rotary_year] =" + rbl_anneeRot.SelectedValue);
                if (listeCommission.Count != 0 && listeCommission != null)
                {
                    for (int i = 0; i < listeCommission.Count; i++)
                    {//On instancie tous nos textes
                        Label lblTitre = new Label();
                        Label lblCom1 = new Label();
                        lblCom1.ID = "lbl_commission";
                        Label lblCom2 = new Label();
                        lblCom2.ID = "lbl_commission";
                        Literal titre = new Literal();
                        titre.Text = "<h2>";
                        Literal espace = new Literal();
                        espace.Text = "&nbsp &nbsp &nbsp";
                        Literal espace2 = new Literal();
                        espace2.Text = "&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp ";
                        HtmlGenericControl br = new HtmlGenericControl("br");
                        int nouveau = 0;
                        if (i == 0 || listeCommission[i].name != listeCommission[i - 1].name)
                        {//S'il s'agit de la première commission de la liste ou que le nom de la commission est différent que le nom de la commission précédente, on ajoute le titre
                            lblTitre.Text = listeCommission[i].name;
                            lblTitre.ID += "_titre" + i;
                            titre.Text += lblTitre.Text + "</h2>";
                            pnl_contenu.Controls.Add(titre);
                            pnl_contenu.Controls.Add(br);
                            nouveau = 1; //On crée une variable dans ce cas
                        }


                        if (i == 0 || nouveau == 1 || listeCommission[i].job != listeCommission[i - 1].job)
                        {//Si on a créé une nouvelle commission ou si le membre n'a pas la même fonction, on précise la fonction du membre
                            lblCom1.Text = listeCommission[i].job;
                            lblCom1.ID += "_fonction" + i;
                            lblCom1.Width = 200;
                            pnl_contenu.Controls.Add(lblCom1);
                            pnl_contenu.Controls.Add(espace);
                        }
                        else
                        {//Dans les autres cas, on laisse un espace blanc
                            pnl_contenu.Controls.Add(br);
                            pnl_contenu.Controls.Add(espace2);
                        }

                        //On ajoute le nom du membre
                        lblCom2.Text = listeCommission[i].memberName;
                        lblCom2.ID += "_nomMember" + i;
                        pnl_contenu.Controls.Add(lblCom2);
                        pnl_contenu.Controls.Add(br);

                    }
                }
            }
            
            
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

    /// <summary>
    /// Gère la modification ou l'ajout d'une commission 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_commissionAjout_Click(object sender, EventArgs e)
    {
        pnl_domaine.Visible = false;
        pnl_contenu.Visible = false;
        pnl_comModif.Visible = true;
        ddl_commission.Visible = true;
        lbl_titreCom.Visible = false;
        btn_ajoutNewCom.Visible = true;
        btn_validerCom.Visible = false;
        tbx_newCom.Visible = false;
        RefreshGrid();
        BindDDL();
    }

    /// <summary>
    /// Se déclenche lorsque le nom d'une commission est choisi par l'utilisateur : emmène vers la page de modification de cette commission
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddl_commission_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_titreCom.Text = ddl_commission.SelectedValue;
        RefreshGrid();
        gvw_commission.Visible = true;
        btn_ajoutNewCom.Visible = false;
        ddl_commission.Visible = false;
        lbl_titreCom.Visible = true;
        btn_ajoutLigne.Visible = true;
        btn_suppCom.Visible = true;
        btn_modifNomCom.Visible = true;
    }

    /// <summary>
    /// Permet de retourner sur la page d'affichage des commissions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_retourCom_Click(object sender, EventArgs e)
    {
        CleartextBoxes(pnl_comModif);
        pnl_comModif.Visible = false;
        pnl_contenu.Visible = true;
        pnl_domaine.Visible = true;
        lbl_validationAjout.Visible = false;
        btn_ajoutNewCom.Visible = false;
        tbx_newFonct.Visible = false;
        tbx_newMember.Visible = false;
        tbx_modifMember.Visible = false;
        tbx_modifFonc.Visible = false;
        btn_ajoutLigne.Visible = false;
        btn_modifNomCom.Visible = false;
        btn_suppCom.Visible = false;
        tbx_modifNomCom.Visible = false;
        lbl_confirmSupp.Visible = false;
        lbl_membreFonction.Visible = false;
        creerCommission();
    }

    /// <summary>
    /// Permet de créer une nouvelle commission
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_ajoutNewCom_Click(object sender, EventArgs e)
    {
        //CleartextBoxes(pnl_comModif);
        ddl_commission.Visible = false;
        tbx_newCom.Visible = true;
        btn_validerCom.Visible = true;
        btn_validerCom.Text = "Ajouter la nouvelle commission";
        btn_ajoutNewCom.Visible = false;
    }

    /// <summary>
    /// Permet de valider les actions sur une commission (ajouter, modifier, supprimer)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_validerCom_Click(object sender, EventArgs e)
    {
        try 
        {
            int enCours = 0;
            if (btn_validerCom.Text == "Ajouter la nouvelle commission")
            {//Ajout d'une commission
                ListItem item = new ListItem(tbx_newCom.Text);
                if (!ddl_commission.Items.Contains(item))
                {//On vérifie que cette commission n'existe pas

                    enCours = 1;
                    tbx_newFonct.Visible = true;
                    tbx_newMember.Visible = true;
                    tbx_newFonct.Text = "Fonction";
                    tbx_newMember.Text = "Member";
                    tbx_newCom.Visible = false;
                    btn_validerCom.Text = "Finaliser l'ajout";
                    lbl_titreCom.Text = tbx_newCom.Text;
                }
                else
                {
                    lbl_erreurCom.Text = "Impossible d'effectuer l'action : cette commission existe déjà";
                    lbl_erreurCom.Visible = true;
                }

            }
            if (btn_validerCom.Text == "Finaliser l'ajout")
            {//Deuxième partie de l'ajout, on ajoute un membre et sa fonction

                lbl_erreurCom.Visible = false;
                if (enCours != 1)
                {
                    Commission com = new Commission();
                    com.name = tbx_newCom.Text;
                    if (tbx_newCom.Text == "")
                    {
                        com.name = lbl_titreCom.Text;
                        if (lbl_titreCom.Text == "")
                            throw new Exception("Problème de réception du nom");
                    }
                    com.job = tbx_newFonct.Text;
                    com.memberName = tbx_newMember.Text;
                    com.rotary_year = int.Parse(rbl_anneeRot.SelectedValue);
                    DataMapping.InsertCommission(com);
                    CleartextBoxes(pnl_comModif);
                    List<Commission> listeCom = DataMapping.GetListCommission("name = '" + lbl_titreCom.Text + "' AND [rotary_year] =" + rbl_anneeRot.SelectedValue);
                    lbl_validationAjout.Text = "Il y a maintenant " + listeCom.Count + " entrée(s) dans la commission " + lbl_titreCom.Text;
                    lbl_validationAjout.Visible = true;
                }
                enCours = 2;
            }
            if (btn_validerCom.Text == "Modifier" && enCours != 2)
            {//Modification d'une entrée dans une commission
                List<Commission> listCom = DataMapping.GetListCommission("id = " + hfd_idCom.Value);
                Commission com = new Commission();
                com.id = listCom[0].id;
                com.name = listCom[0].name;
                com.job = tbx_modifFonc.Text;
                com.memberName = tbx_modifMember.Text;
                com.rotary_year = int.Parse(rbl_anneeRot.SelectedValue);
                DataMapping.InsertCommission(com);
                RefreshGrid();

                tbx_modifMember.Visible = false;
                tbx_modifFonc.Visible = false;
                btn_validerCom.Visible = false;
                ddl_commission.Visible = true;
                btn_ajoutNewCom.Visible = true;
                lbl_titreCom.Visible = false;
                CleartextBoxes(pnl_commission);
            }

            if (btn_validerCom.Text == "Supprimer" && enCours != 2)
            {//Suppression d'une entrée dans une commission
                DataMapping.DeleteCommission(int.Parse(hfd_idCom.Value));
                RefreshGrid();

                gvw_commission.Visible = false;
                lbl_confirmSupp.Visible = false;
                lbl_membreFonction.Visible = false;
                btn_ajoutModifMember.Visible = true;
                pnl_comModif.Visible = false;
                pnl_contenu.Visible = true;
                btn_ajoutModifMember.Visible = false;
                pnl_domaine.Visible = true;
                btn_ajoutNewCom.Visible = false;
                creerCommission();
            }

            if (btn_validerCom.Text == "Supprimer la commission")
            {//Suppression d'une commission
                List<Commission> listeCom = DataMapping.GetListCommission("name = '" + lbl_titreCom.Text + "'");
                foreach (Commission com in listeCom)
                {
                    DataMapping.DeleteCommission(com.id);
                }
                RefreshGrid();
                gvw_commission.Visible = false;
                lbl_confirmSupp.Visible = false;
                lbl_membreFonction.Visible = false;
                btn_ajoutModifMember.Visible = true;
                pnl_comModif.Visible = false;
                pnl_contenu.Visible = true;
                btn_ajoutModifMember.Visible = false;
                pnl_domaine.Visible = true;
                btn_ajoutNewCom.Visible = false;
                creerCommission();

            }

            if (btn_validerCom.Text == "Modifier le nom")
            {//Modification du nom de la commission
                List<Commission> listeCom = DataMapping.GetListCommission("name = '" + lbl_titreCom.Text + "' AND [rotary_year] =" + rbl_anneeRot.SelectedValue);
                
                foreach (Commission com in listeCom)
                {//On change le nom de la commission de chaque entrée de cette commission dans la table
                    com.name = tbx_modifNomCom.Text;
                    DataMapping.InsertCommission(com);

                }
                RefreshGrid();

                CleartextBoxes(pnl_comModif);
                pnl_comModif.Visible = false;
                pnl_contenu.Visible = true;
                pnl_domaine.Visible = true;
                btn_ajoutNewCom.Visible = false;
                tbx_newFonct.Visible = false;
                tbx_newMember.Visible = false;
                tbx_modifMember.Visible = false;
                tbx_modifFonc.Visible = false;
                btn_ajoutLigne.Visible = false;
                btn_modifNomCom.Visible = false;
                btn_suppCom.Visible = false;
                tbx_modifNomCom.Visible = false;
                lbl_confirmSupp.Visible = false;
                lbl_membreFonction.Visible = false;
                creerCommission();
            } 
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        

    }

    /// <summary>
    /// Permet de modifier une commission
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_modifCom_Click(object sender, EventArgs e)
    {
        tbx_modifMember.Visible = true;
        tbx_modifFonc.Visible = true;
        gvw_commission.Visible = false;
        btn_validerCom.Visible = true;
        btn_suppCom.Visible = false;
        btn_ajoutLigne.Visible = false;
        btn_modifNomCom.Visible = false;
        btn_validerCom.Text = "Modifier";
    }

    /// <summary>
    /// Permet de remplir les champs nécessaires à la modification ou à la suppression de la ligne sélectionnée
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvw_commission_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        CleartextBoxes(pnl_commission);
        string[] splits = e.CommandArgument.ToString().Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                if (splits.Count() == 2)
                {
                    if (!string.IsNullOrEmpty(splits[0]) && !string.IsNullOrEmpty(splits[1]))
                    {
                        
                    }
                    else
                    {
                        throw new Exception("La fonction, le nom du membre ou les 2 sont vides : " + e.CommandArgument.ToString());
                    }
                }
                else
                {
                    throw new Exception("Erreur lors de la récupération de la fonction et du mois : " + e.CommandArgument.ToString());
                }

        tbx_modifFonc.Text = splits[0];
        tbx_modifMember.Text = splits[1];
        lbl_membreFonction.Text = splits[0] + " " + splits[1];
        hfd_idCom.Value = e.CommandName.ToString();
                
    }

    /// <summary>
    /// Permet de supprimer une ligne d'une commission
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_supprLigneCom_Click(object sender, EventArgs e)
    {
        btn_modifNomCom.Visible = false;
        btn_suppCom.Visible = false;
        btn_ajoutLigne.Visible = false;
        lbl_confirmSupp.Visible = true;
        lbl_membreFonction.Visible = true;
        btn_validerCom.Visible = true;
        btn_validerCom.Text = "Supprimer";
    }

    /// <summary>
    /// Permet d'ajouter une ligne d'une commission
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_ajoutLigne_Click(object sender, EventArgs e)
    {
        gvw_commission.Visible = false;
        tbx_newFonct.Visible = true;
        tbx_newMember.Visible = true;
        btn_suppCom.Visible = false;
        btn_modifNomCom.Visible = false;
        btn_validerCom.Visible = true;
        btn_validerCom.Text = "Finaliser l'ajout";
        tbx_newMember.Text = "Member";
        tbx_newFonct.Text = "Fonction";
        btn_ajoutLigne.Visible = false;
    }

    /// <summary>
    /// Permet de supprimer une commission
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_suppCom_Click(object sender, EventArgs e)
    {
        gvw_commission.Visible = false;
        lbl_confirmSupp.Visible = true;
        lbl_confirmSupp.Text = "Êtes-vous sûr de vouloir supprimer cette commission?";
        lbl_membreFonction.Visible = true;
        lbl_membreFonction.Text = lbl_titreCom.Text;
        btn_validerCom.Visible = true;
        btn_validerCom.Text = "Supprimer la commission";
        btn_ajoutLigne.Visible = false;
        btn_modifNomCom.Visible = false;
        btn_suppCom.Visible = false;

    }

    /// <summary>
    /// Permet de modifier le nom d'une commission
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_modifNomCom_Click(object sender, EventArgs e)
    {
        gvw_commission.Visible = false;
        btn_modifNomCom.Visible = false;
        tbx_modifNomCom.Visible = true;
        btn_validerCom.Visible = true;
        btn_suppCom.Visible = false;
        btn_ajoutLigne.Visible = false;
        btn_validerCom.Text = "Modifier le nom";
    }

    #endregion Commission
    
}