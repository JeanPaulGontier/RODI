
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

public partial class DesktopModules_AIS_Admin_Arborescence_Admin_Arborescence : PortalModuleBase
{
    /// <summary>
    /// Au démarrage, crée les onglets, actualise les données nécessaires et détermine quelle DataList afficher
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT) || UserInfo.IsSuperUser)
            {
            if (!IsPostBack)
            {
                switch (Session["ID"].ToString())
                {
                    case ("btn_redirectGouv") :
                        dl_gouv.Visible = true;
                        break;
                    case ("btn_redirectBur") :
                        dl_bureau.Visible = true;
                        break;
                    case ("btn_redirectFonda") :
                        dl_fondation.Visible = true;
                        break;
                    case ("btn_redirectamMonaco") :
                        dl_amMonaco.Visible = true;
                        break;
                    case ("btn_redirectCorse") :
                        dl_Corse.Visible = true;
                        break;
                    case ("btn_redirectvar") :
                        dl_Var.Visible = true;
                        break;
                    case ("btn_redirectPres") :
                        dl_presidents.Visible = true;
                        break;

                }
                rbt_anneeCourante.Text = "" + Functions.GetRotaryYear();
                rbt_anneePlusDeux.Text = "" + (Functions.GetRotaryYear() + 2);
                rbt_anneePlusUn.Text = "" + (Functions.GetRotaryYear() + 1);
                RefreshDL();
                
            }
            creerOrganigramme("Organigramme");
            }
            else
            {
                if (PortalSettings.HomeTabId > 0)
                {
                    Response.Redirect(Globals.NavigateURL(PortalSettings.HomeTabId), true);
                }
                else
                {
                    Response.Redirect(Globals.GetPortalDomainName(PortalSettings.PortalAlias.HTTPAlias, Request, true), true);
                }
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

    /// <summary>
    /// Actualise les DataList
    /// </summary>
    public void RefreshDL()
    {
        int anneeRot = 0;
        if (rbl_anneeRot.SelectedValue == rbt_anneeCourante.Text)
            anneeRot = int.Parse(rbt_anneeCourante.Text);
        else if (rbl_anneeRot.SelectedValue == rbt_anneePlusUn.Text)
            anneeRot = int.Parse(rbt_anneePlusUn.Text);
        else if (rbl_anneeRot.SelectedValue == rbt_anneePlusDeux.Text)
            anneeRot = int.Parse(rbt_anneePlusDeux.Text);
        else
            throw new Exception("Problème de récupération de l'année");
        List<DRYA> archiAdjAmMonaco = DataMapping.GetListDRYA("section = 'Adjoint Alpes-Maritimes Monaco' AND rotary_year = " + anneeRot);
        List<DRYA> archiAdjCorse = DataMapping.GetListDRYA("section = 'Adjoint Corse' AND rotary_year = " + anneeRot);
        List<DRYA> archiAdjVar = DataMapping.GetListDRYA("section = 'Adjoint Var' AND rotary_year = " + anneeRot);
        List<DRYA> archiBureau = DataMapping.GetListDRYA("section = 'Bureau' AND rotary_year = " + anneeRot);
        List<DRYA> archiFondation = DataMapping.GetListDRYA("section = 'Fondation' AND rotary_year = " + anneeRot);
        List<DRYA> archiGouv = DataMapping.GetListDRYA("section = 'Gouverneur' AND rotary_year = " + anneeRot);
        List<DRYA> archiPres = DataMapping.GetListDRYA("section = 'Président' AND rotary_year = " + anneeRot);


        dl_gouv.DataSource = archiGouv;
        dl_presidents.DataSource = archiPres;
        dl_amMonaco.DataSource = archiAdjAmMonaco;
        dl_bureau.DataSource = archiBureau;
        dl_Corse.DataSource = archiAdjCorse;
        dl_fondation.DataSource = archiFondation;
        dl_Var.DataSource = archiAdjVar;


        //On ne Bind que la DL visible
        if (dl_amMonaco.Visible == true)
        {
            dl_amMonaco.DataBind();
            lbl_titre.Text = "Adjoints Alpes-Maritimes et Monaco";
        }
        else if (dl_Corse.Visible == true)
        {
            dl_Corse.DataBind();
            lbl_titre.Text="Adjoints Corse";
        }
        else if (dl_Var.Visible == true)
        {
            dl_Var.DataBind();
            lbl_titre.Text = "Adjoints Var";
        }

        else if (dl_bureau.Visible == true)
        {
            dl_bureau.DataBind();
            lbl_titre.Text = "Le Bureau";
        }
        else if (dl_fondation.Visible == true)
        {
            dl_fondation.DataBind();
            lbl_titre.Text = "La Fondation";
        }
        else if (dl_gouv.Visible == true)
        {
            dl_gouv.DataBind();
            lbl_titre.Text = "Les Gouverneurs et Conseillers";
        }
        else if (dl_presidents.Visible == true)
        {
            dl_presidents.DataBind();
            lbl_titre.Text="Les Presidents des clubs";

        }
    }

    /// <summary>
    /// Permet l'affichage du panel de modification
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_modifier_Click(object sender, EventArgs e)
    {
        pnl_arbo.Visible = true;
        btn_redirect.Visible = false;
    }

    #region DL

    #region DL ItemCommand
    /// <summary>
    /// Permet la récupération des données concernant le membre sélectionné
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dl_Corse_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Label lbl_nom = (Label)e.Item.FindControl("lbl_nom");
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        Label lblSection = (Label)e.Item.FindControl("lbl_sectionDL");
        int j = 0;
        for (int i = 0; i < dl_Corse.Items.Count; i++)
        {
            if (dl_Corse.Items[i] == e.Item)
            {
                j = i;
                break;
            }

        }
        lbl_section.Text = lblSection.Text; 
        lbl_position.Text = "" + (j + 1);
        tbx_nom.Text = lbl_nom.Text;
        tbx_nim.Text = btnModifier.CommandArgument.ToString();
        RefreshDL();
    }
    
    /// <summary>
    /// Permet la récupération des données concernant le membre sélectionné
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dl_gouv_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Label lblNom = (Label)e.Item.FindControl("lbl_nom");
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        Label lblSection = (Label)e.Item.FindControl("lbl_sectionDL");
        int j = 0;
        for (int i=0; i<dl_gouv.Items.Count; i++)
        {
            if (dl_gouv.Items[i]==e.Item)
            {
                j = i;
                break;
            }
                
        }
        lbl_section.Text = lblSection.Text;
        lbl_position.Text = ""+(j+1);
        tbx_nom.Text = lblNom.Text;
        tbx_nim.Text = btnModifier.CommandArgument.ToString();
        RefreshDL();
    }

    /// <summary>
    /// Permet la récupération des données concernant le membre sélectionné
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dl_fondation_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Label lbl_nom = (Label)e.Item.FindControl("lbl_nom");
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        Label lblSection = (Label)e.Item.FindControl("lbl_sectionDL");
        int j = 0;
        for (int i = 0; i < dl_fondation.Items.Count; i++)
        {
            if (dl_fondation.Items[i] == e.Item)
            {
                j = i;
                break;
            }
        }
        lbl_section.Text = lblSection.Text;
        lbl_position.Text = ""+(j+1);
        tbx_nom.Text = lbl_nom.Text;
        tbx_nim.Text = btnModifier.CommandArgument.ToString();
        RefreshDL();
    }

    /// <summary>
    /// Permet la récupération des données concernant le membre sélectionné
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dl_bureau_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Label lbl_nom = (Label)e.Item.FindControl("lbl_nom");
        Label lblSection = (Label)e.Item.FindControl("lbl_sectionDL");
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        int j = 0;
        for (int i = 0; i < dl_bureau.Items.Count; i++)
        {
            if (dl_bureau.Items[i] == e.Item)
            {
                j = i;
                break;
            }

        }
        lbl_section.Text = lblSection.Text;
        lbl_position.Text = "" + (j+1);
        tbx_nom.Text = lbl_nom.Text;
        tbx_nim.Text = btnModifier.CommandArgument.ToString();
        RefreshDL();
    }

    /// <summary>
    /// Permet la récupération des données concernant le membre sélectionné
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dl_presidents_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Label lbl_nom = (Label)e.Item.FindControl("lbl_nom");
        Label lblSection = (Label)e.Item.FindControl("lbl_sectionDL");
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        int j = 0;
        for (int i = 0; i < dl_presidents.Items.Count; i++)
        {
            if (dl_presidents.Items[i] == e.Item)
            {
                j = i;
                break;
            }

        }
        lbl_section.Text = lblSection.Text;
        lbl_position.Text = ""+(j+1);
        tbx_nom.Text = lbl_nom.Text;
        tbx_nim.Text = btnModifier.CommandArgument.ToString();
        RefreshDL();
    }

    /// <summary>
    /// Permet la récupération des données concernant le membre sélectionné
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dl_amMonaco_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Label lbl_nom = (Label)e.Item.FindControl("lbl_nom");
        Label lblSection = (Label)e.Item.FindControl("lbl_sectionDL");
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        int j = 0;
        for (int i = 0; i < dl_amMonaco.Items.Count; i++)
        {
            if (dl_amMonaco.Items[i] == e.Item)
            {
                j = i;
                break;
            }

        }
        lbl_section.Text = lblSection.Text;
        lbl_position.Text = ""+(j+1);
        tbx_nom.Text = lbl_nom.Text;
        tbx_nim.Text = btnModifier.CommandArgument.ToString();
        RefreshDL();
    }

    /// <summary>
    /// Permet la récupération des données concernant le membre sélectionné
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dl_Var_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Label lbl_nom = (Label)e.Item.FindControl("lbl_nom");
        Label lblSection = (Label)e.Item.FindControl("lbl_sectionDL");
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        int j = 0;
        for (int i = 0; i < dl_Var.Items.Count; i++)
        {
            if (dl_Var.Items[i] == e.Item)
            {
                j = i;
                break;
            }

        }
        lbl_section.Text = lblSection.Text;
        lbl_position.Text = ""+(j+1);
        tbx_nom.Text = lbl_nom.Text;
        tbx_nim.Text = btnModifier.CommandArgument.ToString();
        RefreshDL();
    }

    #endregion DL ItemCommand
    
    #region DL DataBound

    /// <summary>
    /// Lors du Bind des données, affiche ou cache le bouton de modification en fonction de la visibilité du panel d'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_gouv_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        if (pnl_arbo.Visible)
            btnModifier.Visible = false;
    }

    /// <summary>
    /// Lors du Bind des données, affiche ou cache le bouton de modification en fonction de la visibilité du panel d'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_fondation_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        if (pnl_arbo.Visible)
            btnModifier.Visible = false;
    }

    /// <summary>
    /// Lors du Bind des données, affiche ou cache le bouton de modification en fonction de la visibilité du panel d'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_bureau_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        if (pnl_arbo.Visible)
            btnModifier.Visible = false;
    }

    /// <summary>
    /// Lors du Bind des données, affiche ou cache le bouton de modification en fonction de la visibilité du panel d'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_presidents_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        if (pnl_arbo.Visible)
            btnModifier.Visible = false;
    }

    /// <summary>
    /// Lors du Bind des données, affiche ou cache le bouton de modification en fonction de la visibilité du panel d'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_amMonaco_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        if (pnl_arbo.Visible)
            btnModifier.Visible = false;
    }

    /// <summary>
    /// Lors du Bind des données, affiche ou cache le bouton de modification en fonction de la visibilité du panel d'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_Corse_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        if (pnl_arbo.Visible)
            btnModifier.Visible = false;
    }

    /// <summary>
    /// Lors du Bind des données, affiche ou cache le bouton de modification en fonction de la visibilité du panel d'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_Var_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Button btnModifier = (Button)e.Item.FindControl("btn_modifier");
        if (pnl_arbo.Visible)
            btnModifier.Visible = false;
    }
    
    #endregion DL DataBound
    
    #endregion DL

    #region organigramme

    /// <summary>
    /// Permet la création des onglets grâce à la table ais_domaine
    /// </summary>
    /// <param name="nomDomain">Le nom du domaine dans lequel se trouvent les onglets</param>
    public void creerOrganigramme (string nomDomain)
    {
        try
        {
            #region decalage
            //On cherche à placer les onglets suivant l'organigramme. On représente chaque onglet par son ID dans une liste d'int. Pour symboliser un décalage, on ajoutera un 0. Ainsi, un entier précédé d'un 0 sera l'enfant du dernier entier non précédé d'un 0. La liste se crée de la manière suivante :
            List<Domain> listeDomains = DataMapping.GetListDomain(nomDomain, "");
            List<int> listeId = new List<int>();
            for (int i = 0; i < listeDomains.Count; i++)
            {
                if (!listeId.Contains(listeDomains[i].id))
                {
                    if (listeDomains[i].parent == 0)
                        listeId.Add(listeDomains[i].id);
                    else
                    {
                        int compteur = 0;
                        for (int d = 0; d < listeDomains.Count; d++)
                        {
                            if (listeDomains[i].parent == listeDomains[d].id)
                            {
                                listeId.Add(0);
                                listeId.Add(listeDomains[i].id);
                                break;
                            }
                            compteur++;
                        }
                        if (compteur == listeDomains.Count)
                            listeId.Add(listeDomains[i].id);
                            
                        
                    }

                    int j = i;
                    int decalage = 1;
                    
                    
                        
                     while (enfantOuParent(listeDomains[j], "enfant") && j<listeDomains.Count)
                     { //tant que l'onglet a un enfant, il faut récupérer cet enfant et le placer après n+1 zéros. n étant le nombre de zéros précédant l'onglet parent
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
            for (int h = 0; h < listeId.Count; h++)
            {
                if (((h + 1 >= listeId.Count || listeId[h + 1] != 0) && listeId[h] != 0))
                {//Si l'int suivant n'est pas un zéro et que l'int actuel n'est pas un zéro ou qu'il est le dernier de la liste, on crée un Bouton
                    int w = 0;
                    while (listeDomains[w].id != listeId[h])
                        w++;
                    Button btn = new Button();
                    btn = (Button) creerControl(listeDomains[w].wording, btn );
                    pnl_onglet.Controls.Add(btn);
                    HtmlGenericControl br = new HtmlGenericControl("br");
                    pnl_onglet.Controls.Add(br);
                }
                else if (listeId[h] != 0 && listeId[h + 1] == 0)
                {//Si l'int actuel n'est pas un zéro mais que le suivant en est un, on crée un Label  
                    if (nbZeroPos(listeId, h, "apres") > nbZeroPos(listeId, h,"avant"))
                    {
                        int w = 0;
                        while (listeDomains[w].id != listeId[h])
                            w++;
                        Label lbl = new Label();
                        lbl = (Label)creerControl(listeDomains[w].wording, lbl);
                        pnl_onglet.Controls.Add(lbl);
                        HtmlGenericControl br = new HtmlGenericControl("br");
                        pnl_onglet.Controls.Add(br);
                    }
                    else
                    {
                        int w = 0;
                        while (listeDomains[w].id != listeId[h])
                            w++;
                        Button btn = new Button();
                        btn = (Button)creerControl(listeDomains[w].wording, btn);
                        pnl_onglet.Controls.Add(btn);
                        HtmlGenericControl br = new HtmlGenericControl("br");
                        pnl_onglet.Controls.Add(br);
                    }

                }
                else if (listeId[h] == 0)
                {//Si l'int actuel est un 0, on crée un décalage
                    Literal nbsp = new Literal();
                    nbsp.Text = "&nbsp &nbsp &nbsp";
                    pnl_onglet.Controls.Add(nbsp);
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
    /// Définit si le domain possède un enfant ou un parent (selon le type de recherche)
    /// </summary>
    /// <param name="dom">Le domaine à étudier</param>
    /// <param name="recherche">Le type de recherche à effectuer (chercher un enfant ou chercher un parent)</param>
    /// <returns></returns>
    public bool enfantOuParent (Domain dom, string recherche)
    {
        if (recherche == "enfant")
        {//Recherche d'enfant
            List<Domain> listDom = DataMapping.GetListDomain(dom.domain, "");
            for (int i = 0; i < listDom.Count; i++)
            {
                if (dom.id == listDom[i].parent)
                    return true;
            }
            return false;
        }
        else if (recherche == "parent")
        {// Recherche de parent
            if (dom.parent != 0)
                return true;
            else
                return false;
        }
        else
            throw new Exception("Mauvais type de recherche");
    }

    /// <summary>
    /// Crée un controle du type spécifié
    /// </summary>
    /// <param name="nom">Le nom donné au controle</param>
    /// <param name="control">Le type de controle</param>
    /// <returns></returns>
    public Control creerControl (string nom, Control control)
    {
        if (control.GetType() == typeof(Button))
        {//Création d'un Bouton
            Button btn = new Button();
            btn.ID = "btn_" + nom;
            string nomEvent = btn.ID + "_Click";
            btn.Text = nom;
            btn.Click += new EventHandler(btn_click);
            btn.Width = 190;
            return btn;
        }
        else if (control.GetType() == typeof(Label))
        {//Création d'un Label
            Label lbl = new Label();
            lbl.ID = "lbl_" + nom;
            lbl.Text = nom;
            return lbl;
        }
        else
            throw new Exception("Type de controle inconnu ou non pris en charge");

    }

    /// <summary>
    /// Cherche l'ID de l'enfant d'un domaine
    /// </summary>
    /// <param name="dom">Domain parent</param>
    /// <returns>ID du domaine enfant</returns>
    public int idEnfant(Domain dom)
    {
        if (!enfantOuParent(dom, "enfant"))
            throw new Exception("Pas d'enfants");
        List<Domain> listeDom = DataMapping.GetListDomain(dom.domain, "");
        for (int i = 0; i < listeDom.Count; i++)
        {// On parcourt la liste de domaines. Dès qu'on trouve l'ID de l'enfant, on s'arrête et on la retourne 
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
        for (int i = 0; i < liste.Count; i++)
        {//On parcourt la liste de domaines. Dès que l'on retrouve l'ID du domaine, on s'arrête et on retourne la position
            if (liste[i].id == dom.id)
                return i;
        }
        throw new Exception("Id introuvable");
    }

    /// <summary>
    /// Selon l'option de recherche, compte le nombre de zéros avant ou après la position indiquée
    /// </summary>
    /// <param name="liste">List d'entiers</param>
    /// <param name="position">Position de laquelle rechercher</param>
    /// <param name="recherche">Type de recherche à effectuer (avant ou après)</param>
    /// <returns></returns>
    public int nbZeroPos (List<int> liste, int position, string recherche)
    {
        if (recherche=="avant")
        {//Recherche avant la position
            int i =1;
        int compteur = 0;
        while (position-i > 0 && liste[position-i]==0)
        {
            compteur++;
            i++;
        }
        return compteur;
        }
        else if (recherche=="apres")
        {//Recherche après la position
            int i = 1;
        int compteur = 0;
        while (position+i <liste.Count && liste[position+i]==0)
        {
            compteur++;
            i++;
        }
        return compteur;
        }
        else
            throw new Exception ("Mauvais type de recherche");
    }

    /// <summary>
    /// Gère l'évènement associé suite au clic sur un bouton généré dynamiquement
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_click (object sender, EventArgs e)
    {
        btn_redirect.Visible = true;
        Button btn = (Button)sender;
        pnl_arbo.Visible = false;
        switch (btn.ID)
        {
            case ("btn_Gouverneurs et Conseillers") :
                dl_gouv.Visible = true;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;
                break;
            case ("btn_Le Bureau") :
                dl_gouv.Visible = false;
                dl_bureau.Visible = true;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;  
                break;
            case ("btn_La Fondation") :
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = true;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;
                break;
            case ("btn_Alpes Maritimes et Monaco "):
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = true;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;
                break;
            case ("btn_Corse") :
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = true;
                dl_Var.Visible = false;
                dl_presidents.Visible = false;
                break;
            case ("btn_Var") :
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = true;
                dl_presidents.Visible = false;
                break;
            case ("btn_Les présidents des clubs") :
                dl_gouv.Visible = false;
                dl_bureau.Visible = false;
                dl_fondation.Visible = false;
                dl_amMonaco.Visible = false;
                dl_Corse.Visible = false;
                dl_Var.Visible = false;
                dl_presidents.Visible = true;
                break;
        }
        dl_gouv.SelectedIndex = -1;
        dl_amMonaco.SelectedIndex = -1;
        dl_Corse.SelectedIndex = -1;
        dl_Var.SelectedIndex = -1;
        dl_presidents.SelectedIndex = -1;
        dl_fondation.SelectedIndex = -1;
        dl_bureau.SelectedIndex = -1;
        RefreshDL();
    }

    #endregion organigramme

    #region Modifier

    /// <summary>
    /// Permet de placer le membre tout en bas de l'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibt_bottom_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            List<DRYA> archi2 = DataMapping.GetListDRYA("section = '"+lbl_section.Text+"' AND rotary_year ="+rbl_anneeRot.SelectedValue);
            int rang = int.Parse(lbl_position.Text);
            List<DRYA> archi = DataMapping.GetListDRYA("rang >=" + rang + " AND section = '" + lbl_section.Text + "' AND rotary_year ="+rbl_anneeRot.SelectedValue);
            int dernierRang = archi.Count + rang - 1;
            if (dernierRang != rang)
            {//On vérifie que le membre ne soit pas déjà à la fin de la liste
                lbl_erreur.Visible = false;
                if (archi.Count == 0 || archi == null)
                {
                    throw new Exception("Pas de données récupérées");
                }
                else
                {
                    for (int i = 0; i < archi.Count; i++)
                    {
                        if (i == 0)
                        {//On place le membre en fin de liste
                            archi[i].rank = dernierRang;
                            DataMapping.InsertDRYA(archi[i]);
                        }
                        else
                        {//on remonte les autres d'un cran
                            rang++;
                            archi[i].rank = rang - 1;
                            DataMapping.InsertDRYA(archi[i]);
                        }
                    }
                    lbl_position.Text = "" + dernierRang;
                }
                //On sélectionne le membre déplacé
                dl_gouv.SelectedIndex = archi2.Count - 1;
                dl_amMonaco.SelectedIndex = archi2.Count - 1;
                dl_bureau.SelectedIndex = archi2.Count - 1;
                dl_Corse.SelectedIndex = archi2.Count - 1;
                dl_Var.SelectedIndex = archi2.Count - 1;
                dl_fondation.SelectedIndex = archi2.Count - 1;
                dl_presidents.SelectedIndex = archi2.Count - 1;
                btn_terminer.Text = "Terminer les modifications";
                RefreshDL();
            }
            else
                lbl_erreur.Visible = true;
            
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Permet de placer le membre tout en haut de l'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibt_top_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            
            int rang = int.Parse(lbl_position.Text);
            if (rang != 1)
            {//On vérifie que le membre ne soit pas déjà en haut de la liste
                lbl_erreur.Visible = false;
                List<DRYA> archi = DataMapping.GetListDRYA("rang <=" + rang + " AND section = '" + lbl_section.Text + "' and rotary_year="+ rbl_anneeRot.SelectedValue);

                if (archi.Count == 0 || archi == null)
                {
                    throw new Exception("Pas de données récupérées");
                }
                else
                {
                    for (int i = 0; i < archi.Count; i++)
                    {
                        if (i == archi.Count - 1)
                        {//On place le membre choisi en haut de la liste
                            archi[i].rank = 1;
                            DataMapping.InsertDRYA(archi[i]);
                        }
                        else
                        {//On descend les autres d'un cran
                            archi[i].rank = i + 2;
                            DataMapping.InsertDRYA(archi[i]);
                        }
                    }
                    lbl_position.Text = "" + 1;
                }

                //On sélectionne le membre
                dl_gouv.SelectedIndex = 0;
                dl_amMonaco.SelectedIndex = 0;
                dl_bureau.SelectedIndex = 0;
                dl_Corse.SelectedIndex = 0;
                dl_Var.SelectedIndex = 0;
                dl_fondation.SelectedIndex = 0;
                dl_presidents.SelectedIndex = 0;
                btn_terminer.Text = "Terminer les modifications";
                RefreshDL();
            }
            else
                lbl_erreur.Visible = true;
        }

        
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    /// <summary>
    /// Permet de descendre le membre d'un cran de l'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibt_down_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            List<DRYA> archiSectionCompte = DataMapping.GetListDRYA("section ='" + lbl_section.Text + "' and rotary_year="+rbl_anneeRot.SelectedValue);
            string rang1 = lbl_position.Text;
            string rang2 = (int.Parse(rang1) + 1).ToString();
            if (int.Parse(rang2) <= archiSectionCompte.Count)
            {//On vérifie que le membre ne soit pas déjà en bas de la liste
                lbl_erreur.Visible = false;
                List<DRYA> archi = DataMapping.GetListDRYA("(rang =" + rang1 + " OR rang =" + rang2 + ")" + "AND section ='" + lbl_section.Text + "' and rotary_year ="+rbl_anneeRot.SelectedValue);
                DRYA archi1 = archi[0];
                DRYA archi2 = archi[1];

                //On inverse le membre avec celui qui se trouve sous lui
                archi1.rank = int.Parse(rang2);
                archi2.rank = int.Parse(rang1);

                DataMapping.InsertDRYA(archi1);
                DataMapping.InsertDRYA(archi2);

                //On resélectionne le membre
                lbl_position.Text = rang2;
                switch (lbl_section.Text)
                {
                    case ("Gouverneur"):
                        dl_gouv.SelectedIndex++;
                        break;
                    case ("Bureau"):
                        dl_bureau.SelectedIndex++;
                        break;
                    case ("Fondation"):
                        dl_fondation.SelectedIndex++;
                        break;
                    case ("Adjoint Corse"):
                        dl_Corse.SelectedIndex++;
                        break;
                    case ("Adjoint Alpes-Maritimes Monaco"):
                        dl_amMonaco.SelectedIndex++;
                        break;
                    case ("Adjoint Var"):
                        dl_Var.SelectedIndex++;
                        break;
                    case ("Président"):
                        dl_presidents.SelectedIndex++;
                        break;
                }
                btn_terminer.Text = "Terminer les modifications";
                RefreshDL();
            }
            else
                lbl_erreur.Visible = true;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        
        
    }

    /// <summary>
    /// Permet de monter le membre d'un cran de l'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibt_up_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string rang1 = lbl_position.Text;
            string rang2 = (int.Parse(rang1) - 1).ToString();
            if (int.Parse(rang2) > 0)
            {//On vérifie que le membre ne soit pas déjà en haut
                lbl_erreur.Visible = false;
                List<DRYA> archi = DataMapping.GetListDRYA("(rang =" + rang1 + " OR rang =" + rang2 + ")" + "AND section ='" + lbl_section.Text + "' and rotary_year ="+rbl_anneeRot.SelectedValue);
                DRYA archi1 = archi[0];
                DRYA archi2 = archi[1];

                archi1.rank = int.Parse(rang1);
                archi2.rank = int.Parse(rang2);

                //On inverse le membre et celui qui est au-dessus de lui
                DataMapping.InsertDRYA(archi1);
                DataMapping.InsertDRYA(archi2);

                //On resélectionne le membre
                lbl_position.Text = rang2;
                switch (lbl_section.Text)
                {
                    case ("Gouverneur") :
                        dl_gouv.SelectedIndex--;
                        break;
                    case ("Bureau") :
                        dl_bureau.SelectedIndex--;
                        break;
                    case ("Fondation") :
                        dl_fondation.SelectedIndex--;
                        break;
                    case ("Adjoint Corse") :
                        dl_Corse.SelectedIndex--;
                        break;
                    case ("Adjoint Alpes-Maritimes Monaco") :
                        dl_amMonaco.SelectedIndex--;
                        break;
                    case ("Adjoint Var") :
                        dl_Var.SelectedIndex--;
                        break;
                    case ("Président") :
                        dl_presidents.SelectedIndex--;
                        break;
                }
                btn_terminer.Text = "Terminer les modifications";
                RefreshDL();

            }
            else
                lbl_erreur.Visible = true;
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
        
        
    }

    /// <summary>
    /// Permet de mettre fin aux modifications de l'arborescence
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_terminer_Click(object sender, EventArgs e)
    {
        pnl_arbo.Visible = false;
        dl_gouv.SelectedIndex = -1;
        dl_amMonaco.SelectedIndex = -1;
        dl_bureau.SelectedIndex = -1;
        dl_Corse.SelectedIndex = -1;
        dl_Var.SelectedIndex = -1;
        dl_fondation.SelectedIndex = -1;
        dl_presidents.SelectedIndex = -1;
        RefreshDL();
        btn_redirect.Visible = true;
        btn_terminer.Text = "Retour";
    }

    #endregion Modifier

    #region Selected Index Changed

    /// <summary>
    /// Déselectionne tous les items des datalist lors du changement d'année rotarienne
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbl_anneeRot_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnl_arbo.Visible = false;
        dl_gouv.SelectedIndex = -1;
        dl_amMonaco.SelectedIndex = -1;
        dl_Corse.SelectedIndex = -1;
        dl_Var.SelectedIndex = -1;
        dl_presidents.SelectedIndex = -1;
        dl_fondation.SelectedIndex = -1;
        dl_bureau.SelectedIndex = -1;
        RefreshDL();
    }

    /// <summary>
    /// Rafraichit le contenu de la DataList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_gouv_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshDL();
    }

    /// <summary>
    /// Rafraichit le contenu de la DataList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_bureau_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshDL();
    }

    /// <summary>
    /// Rafraichit le contenu de la DataList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_presidents_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshDL();
    }

    /// <summary>
    /// Rafraichit le contenu de la DataList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_amMonaco_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshDL();
    }

    /// <summary>
    /// Rafraichit le contenu de la DataList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_Corse_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshDL();
    }

    /// <summary>
    /// Rafraichit le contenu de la DataList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_Var_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshDL();
    }

    /// <summary>
    /// Rafraichit le contenu de la DataList
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dl_fondation_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshDL();
    }

    #endregion Selected Index Changed

    /// <summary>
    /// Permet de se rediriger vers la page de modification des aard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_redirect_Click(object sender, EventArgs e)
    {//On redirige l'utilisateur vers la page de visualisation des DRYA correspondante 
        btn_redirect.ID += lbl_titre.Text;
        Session["ID"] = btn_redirect.ID;
        Response.Redirect("Architecture.aspx");
    }

    
}