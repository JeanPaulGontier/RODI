
#region Copyrights

// RODI - https://rodi-platform.org
// Copyright (c) 2012-2025
// by SARL AIS : http://www.aisdev.net
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

using System.Drawing;
using System.IO;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using Aspose.Cells;
public partial class DesktopModules_AIS_Admin_Members_Liste : PortalModuleBase
{
    DotNetNuke.Entities.Modules.ModuleController objModules2 = new DotNetNuke.Entities.Modules.ModuleController();
    int presentationtabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + Settings["presentationtabid"], out t);
            return t;
        }
    }

    string mode
    {
        get
        {
            return "" + Settings["mode"];
            
        }
    }

 

    private bool isAdmin()
    {
        return UserInfo.IsSuperUser ||
                    (UserInfo.IsInRole(Const.ADMIN_ROLE) ||
                     UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) ||
                     DataMapping.isADG() ||
                     UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) ||
                     UserInfo.IsInRole(Const.ROLE_FORMATEUR_CLUBS)
                     );
    }


    /// <summary>
    /// Affiche la liste des membres selon les droits de l'utilisateur
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

 


        //if ("" + Functions.CurrentCric != HF_Cric.Value)
        //{
        //    HF_Cric.Value = "" + Functions.CurrentCric;
        //    GridView1.PageIndex = 0;
        //    //Panel1.Visible = true;
        //    //Panel2.Visible = false;
        //    //pnl_Bouton.Visible = false;
        //    //pnl_Saisie.Visible = false;

        //}
        if (Panel1.Visible)
        {
            if (mode == "club" && Functions.CurrentCric == 0)
            {
                lbl_noClubSelected.Visible = true;
                Panel1.Visible = false;
            }
            else
            {
                lbl_noClubSelected.Visible = false;
                Panel1.Visible = true;

            }
        }
        if (Panel1.Visible)
        { 
            RefreshGrid();
        }

        BT_Export_CSV.Visible = isAdmin();
        BT_Export_XLS.Visible = isAdmin();
       
        BT_Carte_Member_Recto.Visible = isAdmin() && Functions.CurrentCric != 0;
        BT_Carte_Member_Verso.Visible = isAdmin() && Functions.CurrentCric != 0;
        BT_Carte_Member_Recto_DOC.Visible = isAdmin() && Functions.CurrentCric != 0;
        BT_Carte_Member_Verso_DOC.Visible = isAdmin() && Functions.CurrentCric != 0;
        BT_Carte_Member_Recto_Docx.Visible = isAdmin() && Functions.CurrentCric != 0;
        BT_Carte_Member_Verso_Docx.Visible = isAdmin() && Functions.CurrentCric != 0;

        BT_Ajout.Visible = isAdmin() && 
                            Functions.CurrentCric != 0 && 
                            mode == "club";
        BT_Import.Visible = BT_Ajout.Visible;

        

       
        if (mode == "district")
            pnl_exports.Visible = false;
        else
            pnl_exports.Visible = true;


    }
    
    /// <summary>
    /// Applique la commande sélectionnée sur le GridView
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
                try
                {
                    
                    GridView gv = sender as GridView;
                    int index = (gv.PageIndex * gv.PageSize) + Convert.ToInt32(e.CommandArgument);
                    List<Member> membres = gv.DataSource as List<Member>;

                    Member membre = membres[index];
                    HF_id.Value = "" + membre.id;
                    HF_NIM.Value = "" + membre.nim;
                    
                    LBL_Nom.Text = membre.name + " " + membre.surname;
                    LBL_Civilite.Text = membre.civility;
                    LBL_Adresse.Text = membre.adress_1;
                    LBL_Email.Text = membre.email;
                    LBL_Fonction_Metier.Text = membre.job;
                    LBL_Branche_Activite.Text = membre.industry;
                    LBL_Member_Honneur.Text = (""+membre.honorary_member == Const.YES) ? "Member d'honneur" : "";
                    string compl = (""+membre.honorary_member) == "" ? "&nbsp;|&nbsp;" : "";
                    if ((""+membre.civility) == "M")
                        LBL_Retraite.Text = (""+membre.retired) == Const.YES ? "&nbsp;| Retraité" + compl : "&nbsp;| En activité" + compl;
                    else
                        LBL_Retraite.Text = (""+membre.retired) == Const.YES ? "&nbsp;| Retraitée" + compl : "&nbsp;| En activité" + compl;

                    try
                    {
                        LBL_DT_Entree_Rotary.Text = membre.year_membership_rotary != null ? "" + ((DateTime)membre.year_membership_rotary).Year : "inconnue";
                    }
                    catch { }
                    try { 
                    LBL_DT_Naissance.Text = membre.birth_year != null ? "" + ((DateTime)membre.birth_year).Year + " (" + ((int)((DateTime.Now - (DateTime)membre.birth_year).TotalDays / 365.25)) + " ans)" : "inconnue";
                    }
                    catch { }

                    IMG_Photo.ImageUrl = membre.GetPhoto();
                    
                    if (string.IsNullOrEmpty(membre.visible) || membre.visible == Const.YES)
                    {
                        RB_Autoriser_Publication.SelectedValue = Const.YES;
                    }
                    else
                    {
                        RB_Autoriser_Publication.SelectedValue = Const.NO;
                    }
                    if (string.IsNullOrEmpty(membre.honorary_member) || membre.honorary_member == Const.YES)
                    {
                        RB_Membre_d_Honneur.SelectedValue = Const.YES;
                    }
                    else
                    {
                        RB_Membre_d_Honneur.SelectedValue = Const.NO;
                    }

                    if (string.IsNullOrEmpty(membre.satellite_member) || membre.satellite_member == Const.NO)
                    {
                        RB_Membre_satellite.SelectedValue = Const.NO;
                    }
                    else
                    {
                        RB_Membre_satellite.SelectedValue = Const.YES;
                    }

                    LBL_Adresse.Text = membre.adress_1;
                    if (membre.adress_2 != "")
                        LBL_Adresse.Text += "<br/>" + membre.adress_2;
                    if (membre.adress_3 != "")
                        LBL_Adresse.Text += "<br/>" + membre.adress_3;
                    LBL_Adresse.Text += "<br/>" + membre.zip_code + " " + membre.town;
                    LBL_Email.Text = membre.email;
                    LBL_Emailt.Visible = membre.email != "";
                    LBL_Tel.Text = membre.telephone;
                    LBL_Telt.Visible = membre.telephone != "";
                    LBL_Gsm.Text = membre.gsm;
                    LBL_GSMt.Visible = membre.gsm != "";
                    LBL_Fax.Text = membre.fax;
                    LBL_Faxt.Visible = membre.fax != "";

                    Panel_Coord_Pro.Visible = (membre.professionnal_adress + membre.professionnal_zip_code + membre.professionnal_town + membre.professionnal_tel + membre.professionnal_fax + membre.professionnal_mobile).Trim() != "";
                    LBL_Adresse_Pro.Text = membre.professionnal_adress;
                    LBL_Adresse_Pro.Text += "<br/>" + membre.professionnal_zip_code + " " + membre.professionnal_town;
                    LBL_Email_Pro.Text = membre.professionnal_email;
                    LBL_Email_Prot.Visible = membre.professionnal_email != "";
                    LBL_Tel_Pro.Text = membre.professionnal_tel;
                    LBL_Tel_Prot.Visible = membre.professionnal_tel != "";
                    LBL_FAX_Pro.Text = membre.professionnal_fax;
                    LBL_Fax_Prot.Visible = membre.professionnal_fax != "";
                    LBL_GSM_Pro.Text = membre.professionnal_mobile;
                    LBL_GSM_Prot.Visible = membre.professionnal_mobile != "";



                    Club c = DataMapping.GetClub(membre.cric);
                    hf_type_club.Value = c.club_type;
                    lbl_ann_adh_rotary.Visible = false;
                    lbl_ann_adh_rotaract.Visible = false;

                    if (c.club_type==Const.Club_Rotary)
                    {
                        LBL_Club_Type.Text = "Rotary";
                        LBL_Titre_Rotary.Text = "Rotary :";
                        lbl_ann_adh_rotary.Visible = true;
                    }
                    else
                    {
                        LBL_Club_Type.Text = "Rotaract";
                        LBL_Titre_Rotary.Text = "Rotaract :";
                        lbl_ann_adh_rotaract.Visible = true;
                    }

                    Panel1.Visible = false;
                    pnl_Bouton.Visible = true;
                    BT_Ajouter.Visible = false;

                    UserInfo ui = UserController.GetUserById(Globals.GetPortalSettings().PortalId, membre.userid);
                    
                    Panel2.Visible = true;
                    BT_Valider.Visible = false;
                    BT_Modifier.Visible = false;
                    RB_Autoriser_Publication.Visible = true;
                    RB_Autoriser_Publication.Enabled = false;
                    RB_Membre_d_Honneur.Visible = true;
                    RB_Membre_d_Honneur.Enabled = false;
                    RB_Membre_satellite.Visible = true;
                    RB_Membre_satellite.Enabled = false;
                    BT_Supprimer.Visible = false;

                    if ((UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || 
                        DataMapping.isADG() || 
                        UserInfo.IsSuperUser || 
                        UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)) || 
                        UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT) ||
                        membre.userid == UserInfo.UserID )
                    {
                       
                        BT_Modifier.Visible = true;
                    }
                    else
                    {
                        BT_Supprimer.Visible = false;
                    }

                    if (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT))
                    {

                        PChangerClub.Visible = true;
                        List<Club> clubs = DataMapping.ListClubs(sort: "name");
                        ddlClubs.Items.Clear();
                        ddlClubs.Items.Add(new ListItem("--- choisir le nouveau club ---", "0"));
                        foreach (Club cc in clubs)
                            ddlClubs.Items.Add(new ListItem(cc.name, "" + cc.cric));
                        ddlClubs.SelectedIndex = 0;
                    }
                    else
                    {
                        PChangerClub.Visible = false;
                    }



                }
                catch( Exception ee)
                {
                    Functions.Error(ee);
                }

                break;
        }
    }
    
    /// <summary>
    /// Permet le tri du GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        tri.Value = ""+e.SortExpression;
        sens.Value= sens.Value=="ASC"?sens.Value="DESC":sens.Value="ASC";
        RefreshGrid();
    }

    /// <summary>
    /// Permet de changer de page
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
    /// Si le membre possède une présentation, crée un hyperlien qui y amène
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem == null)
            return;        
     
    }

    /// <summary>
    /// Rafraichit le GridView en fonction du tri défini par le HiddenField tri. Dans le cas d'une présentation, on trie les membres qui ont une présentation
    /// </summary>
    void RefreshGrid()
    {
        try
        {
            List<Member> membres = new List<Member>();
            if (mode == "club")
            {
                membres = DataMapping.ListMembers(cric:Functions.CurrentCric, sort: tri.Value + " " + sens.Value, index: GridView1.PageIndex, max: GridView1.PageSize, criterion: TXT_Critere.Text);
            }
            else
            {
                membres = DataMapping.ListMembers( sort: tri.Value + " " + sens.Value, index: GridView1.PageIndex, max: GridView1.PageSize, criterion: TXT_Critere.Text);
            }

            
            
            GridView1.DataSource = membres;
            GridView1.DataBind();

            int nbactif = membres.Where(m => m.honorary_member == "N").Count();
            int nbhonneur = membres.Where(m => m.honorary_member == "O").Count();
            

            string s = membres.Count > 1 ? "s" : "";
            if(nbhonneur>0)
                LBL_Nb.Text = membres.Count + " membre" + s + " (" + nbactif + " actif" + (nbactif > 1 ? "s" : "") + ", " + nbhonneur + " honoraire" + (nbhonneur > 1 ? "s" : "") + ")";
            else
                LBL_Nb.Text = membres.Count + " membre" + s ;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }


    /// <summary>
    /// Récupère le nom du club
    /// </summary>
    /// <returns></returns>
    string GetNomClub()
    {
        if (Functions.CurrentClub != null)
            return "du club "+Functions.CurrentClub.name;
        return "";
    }

    /// <summary>
    /// Permet d'exporter le GridView en fichier Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Export_XLS_Click(object sender, EventArgs e)
    {
        int cric = Functions.CurrentCric;
        if (mode == "district")
            cric = 0;
        List<Member> membres = DataMapping.ListMembers(cric: cric, sort: "surname asc", max: int.MaxValue,criterion:TXT_Critere.Text);
        GridViewExport.DataSource = membres;
        GridViewExport.DataBind();

        Media media = DataMapping.ExportDataGridToXLS(GridViewExport, "Liste des membres"+GetNomClub()+".xls", Aspose.Cells.SaveFormat.Excel97To2003);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet d'exporter le GridView en CSV
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Export_CSV_Click(object sender, EventArgs e)
    {
        int cric = Functions.CurrentCric;
        if (mode == "district")
            cric = 0;
        List<Member> membres = DataMapping.ListMembers(cric: cric, sort: "name asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        GridViewExport.DataSource = membres;
        GridViewExport.DataBind();

        Media media = DataMapping.ExportDataGridToXLS(GridViewExport, "Liste des membres" + GetNomClub() + ".csv", Aspose.Cells.SaveFormat.CSV);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Lors du clic, ramène au panel de départ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Annuler_Click(object sender, EventArgs e)
    {
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
        pnl_Bouton.Visible = false;
        hf_Ajout.Value = "";
        hf_Modif.Value = "";
        pnl_Saisie.Visible = false;
        BT_Import.Visible = BT_Ajout.Visible;
    }

   

   

   
    /// <summary>
    /// Lors du changement du critère, rafrachit le GridView et passe l'index à 0
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TXT_Critere_TextChanged(object sender, EventArgs e)
    {
        GridView1.PageIndex = 0;
        RefreshGrid();
    }

    /// <summary>
    /// Permet de télécharger le recto de la carte des membres d'un club sous forme d'un PDF
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Recto_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "surname asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_RECTO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".recto.pdf");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de télécharger le verso de la carte des membres d'un club sous forme d'un PDF
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Verso_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "surname asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_VERSO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".verso.pdf");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de télécharger le recto de la carte des membres d'un club sous forme d'un fichier Word
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Recto_DOC_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "surname asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_RECTO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".recto.doc", typemime: "application/msword");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de télécharger le verso de la carte des membres d'un club sous forme d'un fichier Word
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Verso_DOC_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "surname asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_VERSO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".verso.doc", typemime: "application/msword");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de télécharger le recto de la carte des membres d'un club sous forme d'un fichier Word (.docx)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Recto_DOCX_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "surname asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_RECTO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".recto.docx", typemime: "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de télécharger le verso de la carte des membres d'un club sous forme d'un fichier Word (.docx)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Carte_Member_Verso_DOCX_Click(object sender, EventArgs e)
    {
        List<Member> membres = DataMapping.ListMembers(cric: Functions.CurrentCric, sort: "surname asc", max: int.MaxValue, criterion: TXT_Critere.Text);
        List<Affectation> affectations = DataMapping.ListAffectationRY(Functions.CurrentCric, Functions.GetRotaryYear());
        Media media = DataMapping.ProductionDocument(Const.MEMBERS_CARTES_VERSO_MODELE, membres, affectations, "Cartes des membres " + GetNomClub() + ".verso.docx", typemime: "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    /// <summary>
    /// Permet de créer un User DNN et cache le bouton en fonction de la réussite de l'opération
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_CreateDNNUser_Click(object sender, EventArgs e)
    {
    //    BT_CreateDNNUser.Visible = !DataMapping.UpdateOrCreateUser(int.Parse(HF_id.Value),LBL_Email.Text);
    }

    /// <summary>
    /// Change le format du texte (enlève les accents et remplaces les sauts de lignes par des ';')
    /// </summary>
    /// <param name="ch"></param>
    /// <returns></returns>
    public string FormatText(string ch)
    {
        return ch.Replace("<br/>", ";").Replace(Environment.NewLine, ";").Replace("é", "e").Replace("è", "e").Replace("à", "a").Replace("ù", "u");;
    }


    protected void BT_VCF_Click(object sender, EventArgs e)
    {
        int nim = 0;
        int.TryParse(HF_NIM.Value,out nim);
        Member membre = DataMapping.GetMemberByNim(nim);
        if (membre == null)
            return;
        string vcard = "BEGIN:VCARD" + Environment.NewLine + 
            "VERSION:3.0" + Environment.NewLine + 
            "KIND:individual" + Environment.NewLine + "FN:" + LBL_Nom.Text + Environment.NewLine +
            "PHOTO;VALUE=URL:" + Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery,"") + IMG_Photo.ImageUrl + Environment.NewLine +
            "ADR;TYPE=PREF,HOME:;;" + FormatText(LBL_Adresse.Text) + Environment.NewLine +
            "LABEL;TYPE=HOME:" + FormatText(LBL_Adresse_Pro.Text) + Environment.NewLine +
            "ADR;TYPE=WORK:;;" + FormatText(LBL_Adresse_Pro.Text) + Environment.NewLine +
            "LABEL;TYPE=WORK:" + FormatText(LBL_Adresse_Pro.Text) + Environment.NewLine +
            "TEL;TYPE=HOME,VOICE:" + LBL_Tel.Text + Environment.NewLine +
            "TEL;TYPE=HOME,VOICE:" + LBL_Gsm.Text + Environment.NewLine +
            "TEL;TYPE=WORK,VOICE:" + LBL_Tel_Pro.Text + Environment.NewLine +
            "TEL;TYPE=WORK,VOICE:" + LBL_GSM_Pro.Text + Environment.NewLine +
            "EMAIL;TYPE=PREF,INTERNET:" + LBL_Email.Text + Environment.NewLine +
            "ORG:RC " + membre.club_name + Environment.NewLine + 
            "END:VCARD";
        
        Media media = new Media();
        media.name = LBL_Nom.Text + ".vcf";
        media.content_type = "text/x-vcard";
        //media.name = LBL_Nom.Text + ".txt";
        //media.content_type = "text/plain";
        media.dt = DateTime.Now;
        media.content = Functions.StringToBytes(vcard);
        media.content_size = media.content.Length;

        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }


    protected Member Get_Membre()
    {
        int id = 0;
        int.TryParse(HF_id.Value, out id);
        return DataMapping.GetMember(id);
    }






    protected void BT_Modifier_Click(object sender, EventArgs e)
    {
        try
        {

            Member membre = Get_Membre();


            tbx_nim.Text = "" + membre.nim;

            IMG_Photo2.ImageUrl = membre.GetPhoto();
            HF_Photo2.Value = membre.photo;
            BT_Effacer_Photo2.Visible = membre.photo != "";

            if (membre.civility == "M")
            {
                rbtl_civilite.SelectedValue = "M";
            }
            else
            {
                rbtl_civilite.SelectedValue = "Mme";
            }

            tbx_titre.Text = "" + membre.title;
            tbx_nom.Text = "" + membre.surname;
            tbx_prenom.Text = "" + membre.name;
            dpk_ann_Naiss.Text = "";
            if (membre.birth_year != null)
            {
                try
                {
                    dpk_ann_Naiss.Text = ""+((DateTime)membre.birth_year).ToString("yyyy-MM-dd");
                }
                catch { }
            }
            tbx_nom_JF.Text = "" + membre.maiden_name;
            tbx_prenom_Conjoint.Text = "" + membre.spouse_name;
            tbx_bio.Text = "" + membre.biography;

            tbx_adresse1.Text = "" + membre.adress_1;
            tbx_adresse2.Text = "" + membre.adress_2;
            tbx_adresse3.Text = "" + membre.adress_3;
            tbx_cp.Text = "" + membre.zip_code;
            tbx_ville.Text = "" + membre.town;
            tbx_pays.Text = "" + membre.country;
            tbx_email.Text = "" + membre.email;
            tbx_telephone.Text = "" + membre.telephone;
            tbx_fax.Text = "" + membre.fax;
            tbx_gsm.Text = "" + membre.gsm;

            tbx_fct_metier.Text = "" + membre.job;
            tbx_branche.Text = "" + membre.industry;
            if (membre.retired == Const.YES)
            {
                rbtl_retraite.SelectedValue = "O";
            }
            else
            {
                rbtl_retraite.SelectedValue = "N";
            }

            tbx_adresse_pro.Text = "" + membre.professionnal_adress;
            tbx_cp_pro.Text = "" + membre.professionnal_zip_code;
            tbx_ville_pro.Text = "" + membre.professionnal_town;
            tbx_email_pro.Text = "" + membre.professionnal_email;
            tbx_tel_pro.Text = "" + membre.professionnal_tel;
            tbx_fax_pro.Text = "" + membre.professionnal_fax;
            tbx_gsm_pro.Text = "" + membre.professionnal_mobile;

            lbl_district3.Text = "" + membre.district_id;
            lbl_club3.Text = "" + membre.club_name;
            if (membre.honorary_member == Const.YES)
            {
                rbtl_membre_H.SelectedValue = "O";
            }
            else
            {
                rbtl_membre_H.SelectedValue = "N";
            }

            if (membre.active_member == Const.YES)
            {
                rbtl_membre_A.SelectedValue = "O";
            }
            else
            {
                rbtl_membre_A.SelectedValue = "N";
            }
            dpk_ann__adh.Text = "";
            if (membre.year_membership_rotary != null)
            {
                try { 
                    dpk_ann__adh.Text = ""+ ((DateTime)membre.year_membership_rotary).ToString("yyyy-MM-dd"); 
                }
                catch { }
            }

            if (membre.removed == Const.YES)
            {
                rbtl_radie.SelectedValue = "O";
            }
            else
            {
                rbtl_radie.SelectedValue = "N";
            }


            if (RB_Autoriser_Publication.SelectedValue == Const.YES)
            {
                membre.visible = Const.YES;
            }
            else
            {
                membre.visible = Const.NO;
            }
            if (RB_Membre_d_Honneur.SelectedValue == Const.YES)
            {
                membre.honorary_member = Const.YES;
            }
            else
            {
                membre.honorary_member = Const.NO;
            }
            if (RB_Membre_satellite.SelectedValue == Const.YES)
            {
                membre.satellite_member = Const.YES;
            }
            else
            {
                membre.satellite_member = Const.NO;
            }
            //ddlClubs.Items.Clear();
            //List<Club> clubRot = DataMapping.ListClubs();

            //foreach (Club c in clubRot)
            //{
            //    ddlClubs.Items.Add(new ListItem(c.name, "" + c.cric));
            //}

            //bool select = false;
            //foreach (ListItem li in ddlClubs.Items)
            //{
            //    if (li.Text == lbl_club3.Text)
            //    {
            //        li.Selected = true;
            //        select = true;
            //    }
            //}

            //if (select == false)
            //{
            //    ddlClubs.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            //    ddlClubs.SelectedIndex = 0;
            //}






            Panel1.Visible = false;
            Panel2.Visible = false;
            pnl_Saisie.Visible = true;
            pnl_Bouton.Visible = true;
            hf_Modif.Value = "o";
            BT_Modifier.Visible = false;
            BT_VCF.Visible = false;
            BT_Supprimer.Visible = true;
            BT_Valider.Visible = true;
            RB_Autoriser_Publication.Enabled = true;
            RB_Membre_d_Honneur.Enabled = true;
            RB_Membre_satellite.Enabled = true;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }


    }
    protected Member SaisieToMember(Member membre)
    {
        try
        {
           
            if (!string.IsNullOrEmpty(hf_userid.Value))
            {
                membre.userid = int.Parse(hf_userid.Value);
            }

            if (!string.IsNullOrEmpty(HF_id.Value))
            {
                membre.id = int.Parse(HF_id.Value);
            }

            if (!string.IsNullOrEmpty(tbx_nim.Text))
            {
                membre.nim = int.Parse(tbx_nim.Text);
            }

            if (!string.IsNullOrEmpty(HF_Cric.Value) && HF_Cric.Value != "0")
            {
                membre.cric = int.Parse(HF_Cric.Value);
            }


            membre.photo = "" + HF_Photo2.Value;

            membre.civility = rbtl_civilite.SelectedValue;

            membre.title = ("" + tbx_titre.Text).Trim();
            membre.surname = ("" + tbx_nom.Text).Trim();
            membre.name = ("" + tbx_prenom.Text).Trim();
            DateTime dtan = DateTime.MinValue;
            DateTime.TryParse("" + dpk_ann_Naiss.Text, out dtan);

            if (dtan != DateTime.MinValue && dtan > DateTime.MinValue)
            {
                membre.birth_year = dtan;
            }
            else
            {
                membre.birth_year = null; 
            }
            membre.maiden_name = ("" + tbx_nom_JF.Text).Trim();
            membre.spouse_name = ("" + tbx_prenom_Conjoint.Text).Trim();
            membre.biography = ("" + tbx_bio.Text).Trim();
            membre.adress_1 = ("" + tbx_adresse1.Text).Trim();
            membre.adress_2 = ("" + tbx_adresse2.Text).Trim();
            membre.adress_3 = ("" + tbx_adresse3.Text).Trim();
            membre.zip_code = ("" + tbx_cp.Text).Trim();
            membre.town = ("" + tbx_ville.Text).Trim();
            membre.country = ("" + tbx_pays.Text).Trim();
            membre.email = ("" + tbx_email.Text).Trim();
            membre.telephone = ("" + tbx_telephone.Text).Trim();
            membre.fax = ("" + tbx_fax.Text).Trim();
            membre.gsm = ("" + tbx_gsm.Text).Trim();
            membre.job = ("" + tbx_fct_metier.Text).Trim();
            membre.industry = ("" + tbx_branche.Text).Trim();
            membre.retired = rbtl_retraite.SelectedValue;
            membre.professionnal_adress = ("" + tbx_adresse_pro.Text).Trim();
            membre.professionnal_zip_code = ("" + tbx_cp_pro.Text).Trim();
            membre.professionnal_town = ("" + tbx_ville_pro.Text).Trim();
            membre.professionnal_email = ("" + tbx_email_pro.Text).Trim();
            membre.professionnal_tel = ("" + tbx_tel_pro.Text).Trim();
            membre.professionnal_fax = ("" + tbx_fax_pro.Text).Trim();
            membre.professionnal_mobile = ("" + tbx_gsm_pro.Text).Trim();
            membre.district_id = int.Parse(lbl_district3.Text);
            membre.club_name = "" + lbl_club3.Text;
            membre.honorary_member = rbtl_membre_H.SelectedValue;
            membre.active_member = "" + rbtl_membre_A.SelectedValue;

            DateTime dta = DateTime.MinValue;
            DateTime.TryParse("" + dpk_ann__adh.Text, out dta);

            if (dta > DateTime.MinValue)
            {
                membre.year_membership_rotary =dta;
            }
            else
            {
                membre.year_membership_rotary = null;
            }
            membre.visible = RB_Autoriser_Publication.SelectedValue;
            membre.honorary_member = RB_Membre_d_Honneur.SelectedValue;
            membre.removed = rbtl_radie.SelectedValue;
            membre.satellite_member = RB_Membre_satellite.SelectedValue;

            membre.base_dtupdate = DateTime.Now;

            return membre;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        try
        {
            bool nimOK = true;

            Member m = new Member();
            if (hf_Modif.Value=="o")
                m = Get_Membre();
                    
            m = SaisieToMember(m);

            //if (!string.IsNullOrEmpty(ddlClubs.SelectedValue))
            //{
                if (m != null)
                {
                    //if (ddlClubs.SelectedValue != "" + m.cric)
                    //{
                    //    m.cric = int.Parse(ddlClubs.SelectedValue);
                    //    m.club_name = DataMapping.GetClub(m.cric).name;
                    //    //ddl_RotClubs.Visible = false;
                    //    //lbl_club3.Visible = true;
                    //}


                    //Test doublon NIM
                    int hfNIM = 0;
                    int.TryParse(("" + HF_NIM.Value), out hfNIM);

                    if (m.nim < 1)
                    {
                        nimOK = false;
                        Response.Write("<script LANGUAGE='JavaScript' >alert('Le NIM saisi doit être supérieur à 0');</script>");
                    }
                    else
                    {
                        if (m.nim != hfNIM)
                        {
                            Member mm = DataMapping.GetMemberByNim(m.nim);
                            if (mm != null && mm.id != m.id)
                            {
                                nimOK = false;
                                Response.Write("<script LANGUAGE='JavaScript' >alert('Le NIM saisi (" + m.nim + ") est déjà attribué au membre " + mm.name + " " + mm.surname + "');</script>");

                            }
                        }
                    }


                    if (nimOK == true)
                    {
                        bool err = true;
                        if (hf_Modif.Value=="o")
                        {
                            if (!DataMapping.UpdateMember(m))
                            {
                                Response.Write("<script LANGUAGE='JavaScript' >alert('Erreur lors de la mise à jour dans la base de donnée');</script>");

                            }
                            else
                                err = false;
                        }
                        else if (hf_Ajout.Value == "o")
                        {
                            if (!DataMapping.InsertMember(m))
                            {
                                Response.Write("<script LANGUAGE='JavaScript' >alert('Erreur lors de la mise à jour dans la base de donnée');</script>");
                              
                            }
                            else
                                err = false;
                        }
                        if(!err)
                        {

                            if (Session[HF_Photo2.Value] != null)
                            {
                            //    //PhotoMember pm = DataMapping.GetPhotoMember(m.nim);

                            //    //if (pm == null)
                            //    //{
                            //    //    pm = new PhotoMember();
                            //    //    pm.nim = m.nim;
                            //    //    pm.visible = Const.YES;
                            //    //}

                            //    pm.photo = HF_Photo2.Value;

                            //    if (DataMapping.InsertPhotoMember(pm))
                            //    {
                                    File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + Const.MEMBERS_PHOTOS_PREFIX + HF_Photo2.Value), ((Media)Session[HF_Photo2.Value]).content);
                            //        Session[HF_Photo2.Value] = null;
                            //    }
                            //    else
                            //    {
                            //        Response.Write("<script LANGUAGE='JavaScript' >alert('Erreur lors de la mise à jour de la photo dans la base de donnée');</script>");
                                    
                            //    }
                            }
                            //else
                            //{
                            //    DataMapping.DeletePhotoMember(m.nim);
                            //}
                        

                          
                            hf_Ajout.Value = "";
                            hf_Modif.Value = "";
                            HF_Cric.Value = "";

                            RefreshGrid();
                            Panel1.Visible = true;
                            Panel2.Visible = false;
                            pnl_Saisie.Visible = false;
                            pnl_Bouton.Visible = false;
                        }
                    }
              
                }
            //}
            //else
            //{
            //    Response.Write("<script LANGUAGE='JavaScript' >alert('Vous devez sélectionner un club.');</script>");
            //    Panel1.Visible = false;
            //}

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void BT_Supprimer_Click(object sender, EventArgs e)
    {
        
        try
        {
            if (!DataMapping.DeleteMember(int.Parse(HF_id.Value)))
            {
                return;
            }

            RefreshGrid();
            Panel1.Visible = true;
            Panel2.Visible = false;
            pnl_Saisie.Visible = false;
            pnl_Bouton.Visible = false;
            hf_Ajout.Value = "";
            hf_Modif.Value = "";
            HF_id.Value = "";
            
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

    protected void BT_Upload_Photo2_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(tbx_nom.Text) && !string.IsNullOrEmpty(tbx_prenom.Text))
        {
            if (FU_Photo2.HasFiles)
            {

                HttpPostedFile file = FU_Photo2.PostedFile;
              
                string filename = Functions.ClearFileName(tbx_prenom.Text + "-"+tbx_nom.Text + ".jpg").ToLower();

                Bitmap bmp = new Bitmap(file.InputStream);
                bmp = Functions.ThumbByWidth(bmp, Const.MEMBERS_PHOTOS_WIDTH);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                HF_Photo2.Value = filename;

                Media media = new Media();
                media.content = ms.GetBuffer();
                media.content_size = media.content.Length;
                media.dt = DateTime.Now;
                media.w = bmp.Width;
                media.h = bmp.Height;
                media.name = filename;
                media.content_type = "image/jpeg";
                Session[HF_Photo2.Value] = media;

                IMG_Photo2.ImageUrl = Const.MEDIA_VIEW_URL + "?id=" + filename;
                BT_Effacer_Photo2.Visible = true;
            }
        }
        else
        {
            BT_Effacer_Photo2.Visible = false;
            Response.Write("<script LANGUAGE='JavaScript' >alert('Vous devez saisir le nom du membre avant !');</script>");
        }
    }
    protected void BT_Effacer_Photo2_Click(object sender, EventArgs e)
    {
        BT_Effacer_Photo2.Visible = false;
        Session[HF_Photo2.Value] = null;
        HF_Photo2.Value = "";
        if (LBL_Civilite.Text == "M")
            IMG_Photo2.ImageUrl = Const.MEMBERS_NOPHOTO_H;
        else
            IMG_Photo2.ImageUrl = Const.MEMBERS_NOPHOTO_F;
    }

    public void CleartextBoxes(Control parent)
    {
        try
        {


            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                {

                    ((TextBox)(c)).Text = "";
                }

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
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }


    protected void BT_Ajout_Click(object sender, EventArgs e)
    {
        try
        {
            if (isAdmin())
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                pnl_Saisie.Visible = true;
                pnl_Bouton.Visible = true;

                BT_Ajouter.Visible = true;
              
                BT_Modifier.Visible = false;
                BT_Valider.Visible = false;
                hf_Ajout.Value = "o";

                HF_Cric.Value = "" + Functions.CurrentCric;
                //hf_CRIC2.Value = "" + Functions.CurrentCric;
                Club c = DataMapping.GetClub(Functions.CurrentCric);
                hf_type_club.Value = c.club_type;
                lbl_district3.Text = ""+c.district_id;
                lbl_club3.Text = "" + c.name ;
                if (c.club_type == Const.Club_Rotary)
                {
                    LBL_Club_Type.Text = "Rotary";
                    LBL_Titre_Rotary.Text = "Rotary :";
                    lbl_ann_adh_rotary.Visible = true;
                }
                else
                {
                    LBL_Club_Type.Text = "Rotaract";
                    LBL_Titre_Rotary.Text = "Rotaract :";
                    lbl_ann_adh_rotaract.Visible = true;
                }
                hf_userid.Value = "";
               
                BT_Effacer_Photo2.Visible = false;
                IMG_Photo2.ImageUrl = Const.MEMBERS_NOPHOTO_F;
                rbtl_civilite.SelectedValue = "M";
                rbtl_retraite.SelectedValue = Const.NO;
                rbtl_membre_H.SelectedValue = Const.NO;
                rbtl_membre_A.SelectedValue = Const.YES;
                rbtl_radie.SelectedValue = Const.NO;
                RB_Autoriser_Publication.SelectedValue = Const.YES;
                RB_Autoriser_Publication.Enabled = true;
                RB_Membre_d_Honneur.SelectedValue = Const.NO;
                RB_Membre_d_Honneur.Enabled = true;
                rbtl_radie.Enabled = true;

                PChangerClub.Visible = false;
                //ddlClubs.Items.Clear();

                dpk_ann_Naiss.Text = "";
                HF_Photo2.Value = "";
                dpk_ann__adh.Text = "";

                CleartextBoxes(pnl_Saisie);

                BT_VCF.Visible = false;
                //BT_CreateDNNUser.Visible = false;
                BT_Supprimer.Visible = false;
                //BT_Valider.Visible = false;
                //BT_Ajouter.Visible = true;
                hf_Ajout.Value = "o";
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void btn_validateClub_Click(object sender, EventArgs e)
    {
        int newcric = 0;
        int.TryParse("" + ddlClubs.SelectedValue, out newcric);
        if(newcric>0)
        {
            Club c = DataMapping.GetClub(newcric);
            HF_Cric.Value = ""+c.cric;
            hf_type_club.Value = c.club_type;
            lbl_club3.Text = c.name;

        }
    }

    protected void BT_Import_Click(object sender, EventArgs e)
    {
        if (isAdmin())
        {
            if(Functions.CurrentCric > 0)
            { 
                Panel1.Visible = false;
                Panel2.Visible = false;
                PanelImport.Visible = true;
                PImportResult.Visible = false;
                Bti_Valider.Visible = false;
                HF_Import.Value = "";
                Bti_Annuler.Visible = true;
                Bti_Fermer.Visible = false;
                LT_Import_Ok.Visible = false;
            }
        }
    }

    protected void Bti_Annuler_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = true;
        PanelImport.Visible = false;
        Response.Redirect(Request.RawUrl);
    }

    protected void Bti_Analyser_Click(object sender, EventArgs e)
    {
        try {
            
            if(FU_import.HasFiles)
            {
                if (!(FU_import.FileName.ToLower().EndsWith(".xls") || FU_import.FileName.ToLower().EndsWith(".xlsx")))
                    throw new Exception("Il ne s'agit pas d'un fichier au format Excel");

                if(HF_Import.Value=="")
                {
                    HF_Import.Value = Guid.NewGuid().ToString();
                }
                Byte[] content = FU_import.FileBytes;
                Session[HF_Import.Value] = content;

                MemoryStream ms = new MemoryStream(content);
                
                Aspose.Cells.Workbook workbook = new Workbook(ms);
                Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
                string i_cric =(""+ worksheet.Cells["C4"].Value).Replace("Club Id : ","").Trim();
                if(i_cric!=""+Functions.CurrentCric)
                { 
                    DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, "Le fichier ne correspond pas a ce club", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
                    return;
                }
                List<Member> importList = GetImportMembers(worksheet);
                List<Member> members = DataMapping.ListMembers(Functions.CurrentCric, "", "", "", 0, int.MaxValue, false, false);
                List<Member> updateList = new List<Member>();
                List<Member> deleteList = new List<Member>();
                List<Member> addList = new List<Member>();
                
                foreach(Member m in importList)
                {
                    bool found = false;
                    foreach(Member mm in members)
                    {
                        if(mm.nim == m.nim)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        updateList.Add(m);
                    else
                        addList.Add(m);
                }
                foreach(Member m in members)
                {
                    bool found = false;
                    foreach (Member mm in importList)
                    {
                        if (mm.nim == m.nim)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        deleteList.Add(m);
                   
                }
                
                string l_import = "";
                if(importList.Count>0)
                {
                    l_import += "<h2>"+importList.Count+" Membre(s) trouvé(s) dans le fichier Excel</h2><br/>";
                    foreach(Member m in importList)
                    {
                        l_import += m.cric + " : " + m.surname + " " + m.name + "<br/>";
                    }
                    l_import += "<h2>" + updateList.Count + " Membre(s) à mettre à jour</h2><br/>";
                    foreach (Member m in updateList)
                    {
                        l_import += m.cric + " : " + m.surname + " " + m.name + "<br/>";
                    }
                    l_import += "<h2>" + deleteList.Count + " Membre(s) a effacer</h2><br/>";
                    foreach (Member m in deleteList)
                    {
                        l_import += m.cric + " : " + m.surname + " " + m.name + "<br/>";
                    }
                    l_import += "<h2>" + addList.Count + " Membre(s) a ajouter</h2><br/>";
                    foreach (Member m in addList)
                    {
                        l_import += m.cric + " : " + m.surname + " " + m.name + "<br/>";
                    }
                }
                LT_Import.Text = l_import;

                Bti_Valider.Visible = true;
                PImportResult.Visible = true;

            }
            else
            { 
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, "Veuillez choisir un fichier Excel", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
            DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, "Impossible d'analyser le fichier,<br/>"+ee.Message, DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError);
        }
    }
    List<Member> GetImportMembers(Worksheet w)
    {
        List<Member> members = new List<Member>();
        int r = 9;
        while (w.Cells[r,1].Value!=null)
        {
            //if ((""+w.Cells[r,16].Value).Trim().Equals("Member"))
            //{ 
                Member m = new Member();
                m.active_member = Const.YES;
                m.honorary_member = ("" + w.Cells[r, 16].Value).Trim().Equals("Member")?Const.NO:Const.YES;
                m.nim = int.Parse(""+w.Cells[r, 0].Value);
                m.district_id = Const.DISTRICT_ID;
                m.cric = Functions.CurrentCric;
                m.club_name = Functions.CurrentClub.name;               
                m.civility = "M";
                m.adress_1 = "";
                m.adress_2 = "";
                m.adress_3 = "";
                m.zip_code = "";
                m.town = "";
                m.biography = "";
                m.industry = "";
                m.maiden_name = "";
                
                m.presentation = false ;
                m.retired = Const.NO;
                m.spouse_name = "";
                m.title = "";
                m.visible = Const.YES;
                m.removed = Const.NO;
                m.job = "";
                m.biography = "";
                m.professionnal_mobile = "";
               
                m.base_dtupdate = DateTime.Now;
                m.satellite_member = Const.NO;
                
                string[] names = ("" + w.Cells[r, 1].Value).Split(',');
                if (names.Length > 0)
                    m.surname = names[0].Trim().ToUpper();
                else
                    m.surname = "";
                if (names.Length > 1)
                    m.name = Functions.ToTitleCase(names[1].Trim());
                else
                    m.name = "";

                string filename = Functions.ClearFileName(m.name + "-" + m.surname + ".jpg").ToLower(); ;
                if (File.Exists(Server.MapPath(PortalSettings.HomeDirectory + Const.MEMBERS_PHOTOS_PREFIX + filename)))
                {
                    m.photo = filename;
                }
                else
                {
                    m.photo = "";
                }

                m.professionnal_adress = "" + w.Cells[r, 3].Value;              
                m.professionnal_town = "" + w.Cells[r, 4].Value;
                m.professionnal_zip_code = "" + w.Cells[r, 6].Value;
                m.country = "" + w.Cells[r, 7].Value;
                m.professionnal_tel = "" + w.Cells[r, 9].Value;
                m.telephone = "" + w.Cells[r, 10].Value;
                m.gsm = "" + w.Cells[r, 11].Value;
                m.professionnal_fax = "" + w.Cells[r, 12].Value;
                m.fax = "" + w.Cells[r, 13].Value;
                string[] pemails = ("" + w.Cells[r, 14].Value).Split(',');
                if (pemails.Length > 0)
                    m.professionnal_email = pemails[0];
                string[] emails = ("" + w.Cells[r, 15].Value).Split(',');
                if (emails.Length > 0)
                        m.email = emails[0];
                
                if(m.email.Equals(""))
                {
                    if (pemails.Length > 0)
                        m.email = pemails[0];
                   
                }

                members.Add(m);
            //}
            r++;
        }
        return members;
    }
    protected void Bti_Valider_Click(object sender, EventArgs e)
    {
        Bti_Analyser.Visible = false;
        Byte[] content = (Byte[])Session[HF_Import.Value];


        MemoryStream ms = new MemoryStream(content);
        try
        {
            Aspose.Cells.Workbook workbook = new Workbook(ms);
            Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
            string i_cric = ("" + worksheet.Cells["C4"].Value).Replace("Club Id : ", "").Trim();
            if (i_cric != "" + Functions.CurrentCric)
            {
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, "Le fichier ne correspond pas a ce club", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
                return;
            }
            List<Member> importList = GetImportMembers(worksheet);
            List<Member> members = DataMapping.ListMembers(Functions.CurrentCric, "", "", "", 0, int.MaxValue, false, false);
            List<Member> updateList = new List<Member>();
            List<Member> deleteList = new List<Member>();
            List<Member> addList = new List<Member>();

            foreach (Member m in importList)
            {
                bool found = false;
                foreach (Member mm in members)
                {
                    if (mm.nim == m.nim)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                    updateList.Add(m);
                else
                    addList.Add(m);
            }
            foreach (Member m in members)
            {
                bool found = false;
                foreach (Member mm in importList)
                {
                    if (mm.nim == m.nim)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    deleteList.Add(m);

            }

            string l_import = "";
            if (importList.Count > 0)
            {
                
                l_import += "<h2>" + updateList.Count + " Membre(s) à mis à jour</h2><br/>";
                foreach (Member m in updateList)
                {
                    Member mm = DataMapping.GetMemberByNim(m.nim);
                    mm.email = m.email;
                    mm.name = m.name;
                    mm.surname = m.surname;                   
                    mm.professionnal_adress = m.professionnal_adress;                    
                    mm.professionnal_town = m.professionnal_town;
                    mm.professionnal_zip_code = m.professionnal_zip_code;
                    mm.country = m.country;
                    mm.gsm = m.gsm;
                    mm.telephone = m.telephone;
                    mm.fax = m.fax;
                    mm.professionnal_tel = m.professionnal_tel;
                    mm.professionnal_fax = m.professionnal_fax;
                    mm.professionnal_email = m.professionnal_email;
                    mm.email = m.email;
                    mm.base_dtupdate = DateTime.Now;
                    if(DataMapping.UpdateMember(mm))
                        l_import += m.cric + " : " + m.surname + " " + m.name + "<br/>";
                    else
                        l_import += "<span class'alert-danger'>Erreur de mise à jour : " + m.cric + " : " + m.surname + " " + m.name + "</span><br/>";
                }
                l_import += "<h2>" + deleteList.Count + " Membre(s) effacé(s)</h2><br/>";
                foreach (Member m in deleteList)
                {
                    Member mm = DataMapping.GetMemberByNim(m.nim);
                    if(mm==null)
                        l_import += "<span class'alert-danger'>Erreur effacement : " + m.cric + " : " + m.surname + " " + m.name + "</span><br/>";
                    else
                    { 
                        if(DataMapping.DeleteMember(mm.id))
                            l_import += m.cric + " : " + m.surname + " " + m.name + " ... effacé<br/>";
                        else
                            l_import += "<span class'alert-danger'>Erreur effacement : " + m.cric + " : " + m.surname + " " + m.name + "</span><br/>";
                    }
                }
                l_import += "<h2>" + addList.Count + " Membre(s) ajouté(s)</h2><br/>";
                foreach (Member m in addList)
                {
                    if(DataMapping.InsertMember(m))
                        l_import += m.cric + " : " + m.surname + " " + m.name + "<br/>";
                    else
                        l_import += "<span class'alert-danger'>Erreur ajout : "+ m.cric + " : " + m.surname + " " + m.name + "</span><br/>";
                }
            }
            LT_Import.Text = l_import;

            Bti_Valider.Visible = false;
            PImportResult.Visible = true;
            Bti_Annuler.Visible = false;
            Bti_Fermer.Visible = true;
            LT_Import_Ok.Visible = true;
            

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, "Impossible valider les modifications", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError);

        }
    }
}