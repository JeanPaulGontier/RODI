
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
using DotNetNuke.Common;

public partial class DesktopModules_AIS_Admin_Subscriptions_Control : PortalModuleBase
{
    List<AIS.Content> annonces = null;
    List<AIS.Content> presentations = null;
    bool FIRST_GVW_Orders_RowDataBound = false;
    bool FIRST_GVW_Orders_Presentation_RowDataBound = false;

    DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
    int annoncetabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["annoncetabid"], out t);
            return t;
        }
    }

    int Payementtabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["Payementtabid"], out t);
            return t;
        }
    }

    int presentationtabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["presentationtabid"], out t);
            return t;
        }
    }

    int presentationEdittabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["presentationEdittabid"], out t);
            return t;
        }
    }

    int annonceEdittabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["annonceEdittabid"], out t);
            return t;
        }
    }
       
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.IsInRole(Const.ROLE_MEMBERS) || UserInfo.IsSuperUser)
        {
            if (!IsPostBack)
            {
                RefreshGrid_Annonce();
                RefreshGrid_Presentation();
            }
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

    #region ANNONCE
    void RefreshGrid_Annonce()
    {
        annonces = DataMapping.GetListContent(UserInfo.UserID, "Annonce");
        GVW_Annonces.DataSource = annonces;
        GVW_Annonces.DataBind();
    }

    protected void GVW_Annonces_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem == null)
            return;

        AIS.Content c = ((AIS.Content)e.Row.DataItem);

        //GridView gvOrders = e.Row.FindControl("GVW_Orders") as GridView;
        //FIRST_GVW_Orders_RowDataBound = false;
        //gvOrders.DataSource = DataMapping.GetListAbonnement_by_ID_Content(c.id, "Annonce");
        //gvOrders.DataBind();

        HyperLink hl = (HyperLink)e.Row.FindControl("HLK_Titre");
        hl.NavigateUrl = Functions.UrlAddParam(Globals.NavigateURL(annoncetabid), "id_content", "" + c.id);

        Label lbl = (Label)e.Row.FindControl("LBL_Publie");
        if (c.published.ToLower() == "o")
        {
            lbl.Text = "Oui";
        }
        else
        {
            lbl.Text = "Non";
        }



        List<Subscription> lesa = DataMapping.GetListSubscription_by_ID_Content(c.id, "Annonce");
        if (lesa != null && lesa.Count > 0)
        {
            Subscription a = lesa[0];

            Label lbl_dt_deb = (Label)e.Row.FindControl("LBL_dt_deb");
            lbl_dt_deb.Text = a.dt_beginning.ToString("dd/MM/yyyy");

            Label lbl_dt_fin = (Label)e.Row.FindControl("LBL_dt_fin");
            lbl_dt_fin.Text = a.dt_end.ToString("dd/MM/yyyy");

            Label lbl_actif = (Label)e.Row.FindControl("LBL_Actif");
            if (a.active.ToLower() == "o")
            {
                lbl_actif.Text = "Oui";
            }
            else
            {
                lbl_actif.Text = "Non";
            }

            if (c.published.ToLower() == "n" && a.active.ToLower() == "o")
            {
                Button BTN_pub = (Button)e.Row.FindControl("BTN_publier");
                BTN_pub.Visible = true;
                BTN_pub.CommandArgument = c.id.ToString();

                Button BTN_DEpub = (Button)e.Row.FindControl("BTN_DE_publier");
                BTN_DEpub.Visible = false;

                Button BTN_Supp = (Button)e.Row.FindControl("BTN_Supp");
                BTN_Supp.Visible = false;

            }
            else if (c.published.ToLower() == "o" && a.active.ToLower() == "o")
            {
                Button BTN_pub = (Button)e.Row.FindControl("BTN_publier");
                BTN_pub.Visible = false;

                Button BTN_DEpub = (Button)e.Row.FindControl("BTN_DE_publier");
                BTN_DEpub.Visible = true;
                BTN_DEpub.CommandArgument = c.id.ToString();

                Button BTN_Supp = (Button)e.Row.FindControl("BTN_Supp");
                BTN_Supp.Visible = false;
            }
            //else if (a.actif.ToLower() == "n")
            //{
            //    Button BTN_pub = (Button)e.Row.FindControl("BTN_publier");
            //    BTN_pub.Visible = false;

            //    Button BTN_DEpub = (Button)e.Row.FindControl("BTN_DE_publier");
            //    BTN_DEpub.Visible = false;

            //    Button BTN_Supp = (Button)e.Row.FindControl("BTN_Supp");
            //    BTN_Supp.Visible = true;
            //    BTN_Supp.CommandArgument = c.id.ToString();
            //}
            else
            {
                Button BTN_pub = (Button)e.Row.FindControl("BTN_publier");
                BTN_pub.Visible = false;

                Button BTN_DEpub = (Button)e.Row.FindControl("BTN_DE_publier");
                BTN_DEpub.Visible = false;

                Button BTN_Supp = (Button)e.Row.FindControl("BTN_Supp");
                BTN_Supp.Visible = false;
            }
        }
        else
        {
            Label lbl_actif = (Label)e.Row.FindControl("LBL_Actif");           
            lbl_actif.Text = "Non";

            Button BTN_pub = (Button)e.Row.FindControl("BTN_publier");
            BTN_pub.Visible = false;

            Button BTN_DEpub = (Button)e.Row.FindControl("BTN_DE_publier");
            BTN_DEpub.Visible = false;

            Button BTN_Supp = (Button)e.Row.FindControl("BTN_Supp");
            BTN_Supp.Visible = true;
            BTN_Supp.CommandArgument = c.id.ToString();
        }

        if (UserInfo.IsSuperUser)
        {
            Button BTN_pub = (Button)e.Row.FindControl("BTN_publier");
            BTN_pub.Visible = true;

            Button BTN_DEpub = (Button)e.Row.FindControl("BTN_DE_publier");
            BTN_DEpub.Visible = true;

            Button BTN_Supp = (Button)e.Row.FindControl("BTN_Supp");
            BTN_Supp.Visible = true;
        }
    }

    
    protected void GVW_Orders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem == null)
            return;

        Subscription a = ((Subscription)e.Row.DataItem);

        if (FIRST_GVW_Orders_RowDataBound == false)
        {
            Label lbl = (Label)e.Row.FindControl("LBL_Actif");
            if (a.active.ToLower() == "o")
            {
                lbl.Text = "Oui";
            }
            else
            {
                lbl.Text = "Non";
            }

            HyperLink hl = (HyperLink)e.Row.FindControl("HLK_Renouveller");
            if (a.dt_end.Date < DateTime.Now.Date)
            {
                hl.NavigateUrl = Functions.UrlAddParam(Globals.NavigateURL(Payementtabid), "id_content", "" + a.id_content);
            }
            else
            {
                hl.Visible = false;
            }
            FIRST_GVW_Orders_RowDataBound = true;
        }
        else
        {
            HyperLink hl = (HyperLink)e.Row.FindControl("HLK_Renouveller");
            hl.Visible = false;
        }
    }

    protected void BTN_Add_Annonce_Click(object sender, EventArgs e)
    {
        Response.Redirect(Globals.NavigateURL(annonceEdittabid));
    }

    protected void GVW_Annonces_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e == null)
            return;

        if (e.CommandName == "publier")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (DataMapping.Update_Publish("o", id))
            {
                RefreshGrid_Annonce();
                RefreshGrid_Presentation();
            }
        }
        else if (e.CommandName == "depublier")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (DataMapping.Update_Publish("n", id))
            {
                RefreshGrid_Annonce();
                RefreshGrid_Presentation();
            }
        }
        else if (e.CommandName == "supprimer")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (DataMapping.Delete_Content(id, UserInfo.UserID) > 0)
            {
                RefreshGrid_Annonce();
                RefreshGrid_Presentation();
            }
        }
    }
    #endregion ANNONCE

    #region PRESENTATION
    void RefreshGrid_Presentation()
    {
        presentations = DataMapping.GetListContent(UserInfo.UserID, "PagePro");
        if (presentations == null)
        {
            BTN_Add_Presentation.Visible = true;
            BTN_Presentation.Visible = false;
        }
        else
        {
            BTN_Add_Presentation.Visible = false;
            BTN_Presentation.Visible = true;

            if (presentations != null && presentations.Count > 0)
            {

                GVW_Orders_Presentation.DataSource = DataMapping.GetListSubscription_by_ID_Content(presentations[0].id, "PagePro"); ;
                GVW_Orders_Presentation.DataBind();
            }
        }

        if (UserInfo.IsSuperUser)
        {
            BTN_Add_Presentation.Visible = true;
            BTN_Presentation.Visible = true;
        }
    }

    //protected void GVW_Presentation_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.DataItem == null)
    //        return;

    //    Content c = ((Content)e.Row.DataItem);

    //    GridView gvOrders = e.Row.FindControl("GVW_Orders_Presentation") as GridView;
    //    gvOrders.DataSource = DataMapping.GetListAbonnement_by_ID_Content(c.id, "PagePro");
    //    gvOrders.DataBind();

    //    HyperLink hl = (HyperLink)e.Row.FindControl("HLK_Titre");
    //    hl.NavigateUrl = Functions.UrlAddParam(Globals.NavigateURL(presentationtabid), "UserId", "" + UserInfo.UserID);

    //    Label lbl = (Label)e.Row.FindControl("LBL_Publie");
    //    if (c.publie.ToLower() == "o")
    //    {
    //        lbl.Text = "Oui";
    //    }
    //    else
    //    {
    //        lbl.Text = "Non";
    //    }
    //}

    protected void GVW_Orders_Presentation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem == null)
            return;

        Subscription a = ((Subscription)e.Row.DataItem);

        if (FIRST_GVW_Orders_Presentation_RowDataBound == false)
        {
            Label lbl = (Label)e.Row.FindControl("LBL_Actif");
            if (a.active.ToLower() == "o")
            {
                lbl.Text = "Oui";
            }
            else
            {
                lbl.Text = "Non";
            }

            HyperLink hl = (HyperLink)e.Row.FindControl("HLK_Renouveller");
            if (a.dt_end.Date < DateTime.Now.Date)
            {
                hl.NavigateUrl = Functions.UrlAddParam(Globals.NavigateURL(Payementtabid), "id_content", "" + a.id_content);
            }
            else
            {
                hl.Visible = false;
            }

            FIRST_GVW_Orders_Presentation_RowDataBound = true;
        }
        else
        {
            Label lbl = (Label)e.Row.FindControl("LBL_Actif");
            lbl.Visible = false;

            HyperLink hl = (HyperLink)e.Row.FindControl("HLK_Renouveller");
            hl.Visible = false;
        }

    }

    protected void BTN_Add_Presentation_Click(object sender, EventArgs e)
    {
        Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(presentationEdittabid), "UserId", "" + UserInfo.UserID));
    }

    protected void BTN_Presentation_Click(object sender, EventArgs e)
    {
        Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(presentationtabid), "UserId", "" + UserInfo.UserID));
    }
    #endregion PRESENTATION



    
}