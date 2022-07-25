
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

public partial class DesktopModules_AIS_Page_Member_PageMember : PortalModuleBase
{
    int UserIdQuery = 0;
    Member membre = null;
    Affectation affectation;
    AIS.Content content;

    ModuleController objModules = new ModuleController();
    int PresentationEdittabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["PresentationEdittabid"], out t);
            return t;
        }
    }

    string type
    {
        get
        {
            return "" + objModules.GetModuleSettings(ModuleId)["type"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(type=="mypage")
            UserIdQuery = UserId;
        else
            int.TryParse("" + Request.QueryString["UserId"], out UserIdQuery);

        string modif = Request.QueryString["modif"];

        pnl_modif.Visible = modif!=null;

        if (UserInfo.IsSuperUser && UserIdQuery <= 0)
        {
            UserIdQuery = UserInfo.UserID;
        }


        
        if (UserIdQuery > 0)
        {
            if (UserIdQuery == UserInfo.UserID)
            {
                BTN_Edit.Visible = true;
            }
            else
            {
                BTN_Edit.Visible = false;
            }

            if (DataMapping.Sub_Active(UserIdQuery, "PagePro") == true || UserInfo.IsSuperUser || UserInfo.UserID == UserIdQuery) //La page est accessible par superuser, par le membre propriétaire même si l'abonnement est inactif
            {
                membre = DataMapping.GetMemberByUserID(UserIdQuery);
                if (membre != null && membre.id > 0 && membre.nim > 0)
                {
                    affectation = DataMapping.GetAffectation(membre.nim, DateTime.Now.Year);
                    content = DataMapping.GetContentPagePro(UserIdQuery);
                      
                    Binding_Panel2();
                }
                else if (UserInfo.IsSuperUser)
                {                    
                    Binding_Panel2();
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
        else
        {
            if(!Request.IsAuthenticated)
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
        HLK_URL2.Visible = content!=null && content.url != "";


    }

    protected void Binding_Panel2()
    {
        if (type != "mypage" && Request.QueryString["UserId"] != null)
            content = DataMapping.GetContentPagePro(int.Parse(Request.QueryString["UserId"]));
        else if (type == "mypage")
            content = DataMapping.GetContentPagePro(UserId);
        string nom = "";
        if (membre != null && membre.id > 0)
        {
            nom = nom + membre.name + "  " + membre.surname;
        }

        if (!string.IsNullOrEmpty(nom))
        {
            LBL_Nom_Prenom2.Text = nom;
        }
        else
        {
            if (!UserInfo.IsSuperUser) 
                LBL_Nom_Prenom2.Visible = false;
        }

        if (membre != null && membre.id > 0 && !string.IsNullOrEmpty(membre.industry))
        {
            LBL_Classification2.Text = "" + membre.industry;
        }
        else
        {
            if (!UserInfo.IsSuperUser) 
                LBL_Classification2.Visible = false;
        }

        if (membre != null && membre.id > 0)
        {
            IMG_Photo2.ImageUrl = membre.GetPhoto();
        }
        else
        {
            if (!UserInfo.IsSuperUser)
                IMG_Photo2.Visible = false;
        }


        if (affectation != null && !string.IsNullOrEmpty(affectation.function))
        {
            LBL_Fonction2.Text = "" + affectation.function;
        }
        else
        {
            if (!UserInfo.IsSuperUser) 
                LBL_Fonction2.Visible = false;
        }

        if (content != null)
        {
            if (!string.IsNullOrEmpty(content.text))
            {
                LTL_Texte2.Text = content.text;
            }
            else
            {
                if (!UserInfo.IsSuperUser) 
                    LTL_Texte2.Visible = false;
            }

            if (!string.IsNullOrEmpty(content.title))
            {
                LBL_Titre2.Text = content.title;
            }
            else
            {
                if (!UserInfo.IsSuperUser) 
                    LBL_Titre2.Visible = false;
            }

            if (!string.IsNullOrEmpty(content.company))
            {
                LBL_Societe.Text = content.company;
            }
            else
            {
                if (!UserInfo.IsSuperUser)
                    LBL_Societe.Visible = false;
            }

            if (!string.IsNullOrEmpty(content.GetPresentationPhoto()))
            {
                IMG_Logo2.ImageUrl = content.GetPresentationPhoto();
            }
            else
            {
                if (!UserInfo.IsSuperUser) 
                    IMG_Logo2.Visible = false;
            }

            if (!string.IsNullOrEmpty(content.url))
            {
                HLK_URL2.NavigateUrl = content.url;
            }
            else
            {
                if (!UserInfo.IsSuperUser) 
                    HLK_URL2.Visible = false;
            }

            if(content.mode=="Simple")
            {
                pnl_advanced.Visible = false;
                pnl_simple.Visible = true;

                List<News.Bloc> b = new List<News.Bloc>();
                b = (List<News.Bloc>)Functions.Deserialize(content.text, b.GetType());

                LI_Blocs.DataSource = b;
                LI_Blocs.DataBind();
            }
            else
            {
                pnl_advanced.Visible = true;
                pnl_simple.Visible = false;
            }


        }
        else
        {
            if((membre != null && membre.id >0)|| UserInfo.IsSuperUser)
            {
                pnl_content.Visible = false;
                pnl_noContent.Visible = true;
                BTN_Edit.Visible = false;
                pnl_membre.Visible = false;
            }
            else if (!UserInfo.IsSuperUser)
            {
                LTL_Texte2.Visible = false;
                LBL_Titre2.Visible = false;
                IMG_Logo2.Visible = false;
                HLK_URL2.Visible = false;
            }
        }

        if (membre != null && membre.id > 0 )
        {
             PortalSettings ps = PortalController.GetCurrentPortalSettings();
             if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
             {
                 HLK_Contact2.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,850,false);";
             }
             else
             {
                HLK_Contact2.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,500,false);";
             }
        }
        else
        {
            if (!UserInfo.IsSuperUser)
                HLK_Contact2.Visible = false;
        }
        
    }

    protected void BTN_Edit_Click(object sender, EventArgs e)
    {
        Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(PresentationEdittabid), "UserId", "" + UserInfo.UserID));        
    }

    protected void btn_create_Click(object sender, EventArgs e)
    {
        Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(PresentationEdittabid),"UserId",""+ UserId));
    }

    protected void LI_Blocs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        News.Bloc bloc = (News.Bloc)e.Item.DataItem;
        if (bloc == null)
            return;


        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image1");
        if (bloc.photo != null)
            Image1.ImageUrl = bloc.photo;

        if(bloc.type.Contains("Video"))
        {
            Video vid = new Video();
            vid = (Video)Functions.Deserialize(bloc.content, vid.GetType());
            Label Texte1 = (Label)e.Item.FindControl("Texte1");
            Texte1.Text = vid.getLink();
            Panel pnl_content = (Panel)e.Item.FindControl("pnl_content");
            pnl_content.CssClass += " videoContainer";


        }
    }
}