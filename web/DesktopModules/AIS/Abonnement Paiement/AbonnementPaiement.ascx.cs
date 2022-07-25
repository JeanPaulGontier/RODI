
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

public partial class DesktopModules_AIS_Abonnement_Paiement_AbonnementPaiement : PortalModuleBase
{
    int id_content = 0;    
    AIS.Content content;
    Member member = null;
    Affectation affectation;

    public string item_name = "";
    public string item_value = "";
    public string amount = "0";

    //https://developer.paypal.com/webapps/developer/docs/classic/paypal-payments-standard/integration-guide/Appx_websitestandard_htmlvariables/

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

    DotNetNuke.Entities.Modules.ModuleController objModules2 = new DotNetNuke.Entities.Modules.ModuleController();
    int presentationtabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules2.GetModuleSettings(ModuleId)["presentationtabid"], out t);
            return t;
        }
    }

    DotNetNuke.Entities.Modules.ModuleController objModules3 = new DotNetNuke.Entities.Modules.ModuleController();
    int abonnementtabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules3.GetModuleSettings(ModuleId)["abonnementtabid"], out t);
            return t;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int.TryParse("" + Request.QueryString["id_content"], out id_content);

        if (id_content > 0)
        {
            content = DataMapping.GetContent_by_ID(id_content);

            if (content != null && content.id > 0)
            {
                Session["type"] = content.type;
                //if (contenu.type == "Annonce" && contenu.id_user == UserInfo.UserID)
                //{
                //    Panel2.Visible = true;
                //    Panel1.Visible = false;

                //    Binding_Panel2();
                //}
                //else if (contenu.type == "PagePro" && contenu.id_user == UserInfo.UserID)
                //{
                //    Panel2.Visible = false;
                //    Panel1.Visible = true;

                //    membre = DataMapping.GetMemberByUserID(contenu.id_user);

                //     if (membre != null && membre.id != null && membre.id > 0 && membre.nim > 0)
                //     {
                //         affectation = DataMapping.GetAffectation(membre.nim, DateTime.Now.Year);

                //         Binding_Panel1();
                //     }
                //}

                if (DataMapping.Sub_Active_by_id_content(content.id, content.type) == false && content.id_user == UserInfo.UserID)
                {
                    Panel3.Visible = true;

                    
                    if (content.type == "Annonce")
                    {
                        item_name = "Paiement pour l'annonce " + content.title;
                        item_value = content.id.ToString();
                        amount = Const.Price_Announcement;                        
                    }
                    else if (content.type == "PagePro")
                    {
                        member = DataMapping.GetMemberByUserID(content.id_user);
                        string nameMember = "";
                        if (member != null)
                        {
                            if (!string.IsNullOrEmpty(member.surname))
                            {
                                nameMember += member.surname;
                            }

                            if (!string.IsNullOrEmpty(member.name))
                            {
                                nameMember += " " + member.name;
                            }
                        }

                        item_name = "Paiement pour la présentation de " + nameMember.Trim();
                        item_value = content.id.ToString();
                        amount = Const.Price_Presentation;
                    }

                    string url = Globals.NavigateURL(abonnementtabid);
                    //data-notify_url=\"http://www.rotary1730.org/EspaceProfessionnel/RetourPaypal.aspx\"
                    //A commenter pour passer en PROD
                    //LTL_Paypal.Text = "<script  src=\"https://www.paypalobjects.com/js/external/paypal-button.min.js?merchant=plas.gregory@gmail.com\" data-tax=\"0\" data-shipping=\"0\" data-currency=\"EUR\" data-amount=\"" + amount + "\" data-quantity=\"1\" data-name=\"" + item_name + "\" data-number=\"" + item_value + "\" data-lc=\"fr_FR\" data-button=\"donate\" data-env=\"sandbox\"  data-return=" + url + " data-cancel=\"http://www.rotary1730.org\" ></script>";

                    //A decommenter pour passer en PROD
                    LTL_Paypal.Text = "<script  src=\"https://www.paypalobjects.com/js/external/paypal-button.min.js?merchant=paypal@rotary1730.org\" data-tax=\"0\" data-shipping=\"0\" data-currency=\"EUR\" data-amount=\"" + amount + "\" data-quantity=\"1\" data-name=\"" + item_name + "\" data-number=\"" + item_value + "\" data-lc=\"fr_FR\" data-button=\"donate\"  data-return=" + url + " data-cancel=\"http://www.rotary1730.org\" ></script>";
                }
                else
                {
                    Panel3.Visible = false;
                }

                if (UserInfo.IsSuperUser)
                {
                    //Panel2.Visible = true;
                    //Panel1.Visible = true;
                    Panel3.Visible = true;

                    //Binding_Panel2();
                    //Binding_Panel1();
                }
            }
            else if (UserInfo.IsSuperUser)
            {
                //Panel2.Visible = true;
                //Panel1.Visible = true;
                Panel3.Visible = true;
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
        else if (UserInfo.IsSuperUser)
        {
            //Panel2.Visible = true;
            //Panel1.Visible = true;
            Panel3.Visible = true;
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

    //protected void Binding_Panel1()
    //{
    //    string nom = "";
    //    if (membre != null && membre.id != null && membre.id > 0)
    //    {
    //        nom = nom + membre.prenom + "  " + membre.nom;
    //    }

    //    if (!string.IsNullOrEmpty(nom))
    //    {
    //        LBL_Nom_Prenom2.Text = nom;
    //    }
    //    else
    //    {
    //        if (!UserInfo.IsSuperUser)
    //            LBL_Nom_Prenom2.Visible = false;
    //    }

    //    if (membre != null && membre.id != null && membre.id > 0 && !string.IsNullOrEmpty(membre.branche_activite))
    //    {
    //        LBL_Classification2.Text = "" + membre.branche_activite;
    //    }
    //    else
    //    {
    //        if (!UserInfo.IsSuperUser)
    //            LBL_Classification2.Visible = false;
    //    }

    //    if (membre != null && membre.id != null && membre.id > 0)
    //    {
    //        IMG_Photo2.ImageUrl = membre.GetPhoto();
    //    }
    //    else
    //    {
    //        if (!UserInfo.IsSuperUser)
    //            IMG_Photo2.Visible = false;
    //    }


    //    if (affectation != null && !string.IsNullOrEmpty(affectation.fonction))
    //    {
    //        LBL_Fonction2.Text = "" + affectation.fonction;
    //    }
    //    else
    //    {
    //        if (!UserInfo.IsSuperUser)
    //            LBL_Fonction2.Visible = false;
    //    }

    //    if (contenu != null)
    //    {
    //        if (!string.IsNullOrEmpty(contenu.texte))
    //        {
    //            LTL_Texte2.Text = contenu.texte;
    //        }
    //        else
    //        {
    //            if (!UserInfo.IsSuperUser)
    //                LTL_Texte2.Visible = false;
    //        }

    //        if (!string.IsNullOrEmpty(contenu.titre))
    //        {
    //            LBL_Titre2.Text = contenu.titre;
    //        }
    //        else
    //        {
    //            if (!UserInfo.IsSuperUser)
    //                LBL_Titre2.Visible = false;
    //        }

    //        if (!string.IsNullOrEmpty(contenu.GetPresentationPhoto()))
    //        {
    //            IMG_Logo2.ImageUrl = contenu.GetPresentationPhoto();
    //        }
    //        else
    //        {
    //            if (!UserInfo.IsSuperUser)
    //                IMG_Logo2.Visible = false;
    //        }

    //        if (!string.IsNullOrEmpty(contenu.url))
    //        {
    //            HLK_URL2.NavigateUrl = contenu.url;
    //        }
    //        else
    //        {
    //            if (!UserInfo.IsSuperUser)
    //                HLK_URL2.Visible = false;
    //        }
    //    }
    //    else
    //    {
    //        if (!UserInfo.IsSuperUser)
    //        {
    //            LTL_Texte2.Visible = false;
    //            LBL_Titre2.Visible = false;
    //            IMG_Logo2.Visible = false;
    //            HLK_URL2.Visible = false;
    //        }
    //    }

    //    if (membre != null && membre.id != null && membre.id > 0)
    //    {
    //        HLK_Contact2.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,500,false);";
    //    }
    //    else
    //    {
    //        if (!UserInfo.IsSuperUser)
    //            HLK_Contact2.Visible = false;
    //    }

    //}

    //protected void Binding_Panel2()
    //{
    //    if (contenu != null)
    //    {
    //        if (!string.IsNullOrEmpty(contenu.texte))
    //        {
    //            LTL_Texte2.Text = contenu.texte;
    //        }
    //        else
    //        {
    //            if (!UserInfo.IsSuperUser) 
    //                LTL_Texte2.Visible = false;
    //        }

    //        if (!string.IsNullOrEmpty(contenu.titre))
    //        {
    //            LBL_Titre2.Text = contenu.titre;
    //        }
    //        else
    //        {
    //            if (!UserInfo.IsSuperUser) 
    //                LBL_Titre2.Visible = false;
    //        }

    //        if (!string.IsNullOrEmpty(contenu.GetAnnoncePhoto()))
    //        {
    //            IMG_Logo2.ImageUrl = contenu.GetAnnoncePhoto();
    //        }
    //        else
    //        {
    //            if (!UserInfo.IsSuperUser) 
    //                IMG_Logo2.Visible = false;
    //        }

    //        if (!string.IsNullOrEmpty(contenu.fichier))
    //        {
    //            HLK_URL2.NavigateUrl = contenu.GetAnnonceFichier();
    //        }
    //        else
    //        {
    //            if (!UserInfo.IsSuperUser) 
    //                HLK_URL2.Visible = false;
    //        }

    //        Member membre = DataMapping.GetMemberByUserID(contenu.id_user);
    //        if (membre != null && membre.id != null && membre.id > 0)
    //        {
    //            HLK_Contact2.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + membre.id + "&popUp=true',false,350,500,false);";
    //        }
    //        else
    //        {
    //            if (!UserInfo.IsSuperUser)
    //                HLK_Contact2.Visible = false;
    //        }
    //    }
    //    else
    //    {
    //        if (!UserInfo.IsSuperUser)
    //        {
    //            LTL_Texte2.Visible = false;
    //            LBL_Titre2.Visible = false;
    //            IMG_Logo2.Visible = false;
    //            HLK_URL2.Visible = false;
    //            HLK_Contact2.Visible = false;
    //        }
    //    }
    //}

    //protected void BTN_Annonce_Edit_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(AnnonceEdittabid), "id_contenu", "" + id_contenu));        
    //}

    //protected void BTN_Presentation_Edit_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(PresentationEdittabid), "UserId", "" + UserInfo.UserID));
    //}

    protected void BTN_Annuler_Click(object sender, EventArgs e)
    {
        string type = "" + Session["type"];

        if(!string.IsNullOrEmpty(type))
        {
            if (type == "PagePro")
            {
                Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(presentationtabid), "UserId", "" + UserInfo.UserID));
            }
            else if (type == "Annonce")
            {
                Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(annoncetabid), "id_content", "" + id_content));   
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
}