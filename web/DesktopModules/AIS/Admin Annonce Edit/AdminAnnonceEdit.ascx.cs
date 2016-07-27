
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

public partial class DesktopModules_AIS_Admin_Annonce_Edit_AdminAnnonceEdit : PortalModuleBase
{
    int id_contenu = 0;    
    AIS.Content contenu;

    DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
    int Annoncetabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["Annoncetabid"], out t);
            return t;
        }
    }

    int Dontabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["Dontabid"], out t);
            return t;
        }
    }

    int ProTabId
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["Protabid"], out t);
            return t;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.IsInRole(Const.ROLE_MEMBERS) || UserInfo.IsSuperUser)
        {
            int.TryParse("" + Request.QueryString["id_contenu"], out id_contenu);
            if (id_contenu > 0)
            {
                contenu = DataMapping.GetContent_by_ID(id_contenu);
                if (contenu != null)
                {
                    if ((contenu.id > 0 && UserInfo.UserID == contenu.id_user) || UserInfo.IsSuperUser)// seul le super user et le propriétaire de la page peut accéder à cette page de modif
                    {

                        DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/"));
                        if (!d.Exists)
                        {
                            d.Create();
                        }
                        TXT_Editor.ImageManager.UploadPaths = new string[] { PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/" };
                        TXT_Editor.DocumentManager.UploadPaths = new string[] { PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/" };

                        if (IsPostBack == false)
                        {
                             Binding_Panel1();                            
                        }//if (IsPostBack == false)
                    }//if (UserIdQuery > 0 && UserInfo.UserID == UserIdQuery) || UserInfo.IsSuperUser)
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
                }//if (contenu != null && contenu.id > 0)
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
            }//if (id_contenu > 0)
            else if (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_MEMBERS))
            {
                if (IsPostBack == false && !UserInfo.IsSuperUser)
                {
                    Session["Insert"] = "o";
                    Binding_Panel2();
                }//if (IsPostBack == false)
                else if (UserInfo.IsSuperUser)
                {
                    Binding_Panel1();
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
        }//if (UserInfo.IsInRole(Const.ROLE_MEMBRES) || UserInfo.IsSuperUser)
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

    protected void Binding_Panel1()
    {
        if (contenu != null)
        {            
            // Custum image manager
            string filename_Img = Functions.ClearFileName(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/");
            DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/"));
            if (!d.Exists)
            {
                d.Create();
            }
            TXT_Editor.ImageManager.ViewPaths = new string[] { filename_Img };
            TXT_Editor.ImageManager.UploadPaths = new string[] { filename_Img };
            TXT_Editor.ImageManager.DeletePaths = new string[] { filename_Img };

            // Custum document manager
            string filename_Doc = Functions.ClearFileName(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/");            
            TXT_Editor.DocumentManager.ViewPaths = new string[] { filename_Doc };
            TXT_Editor.DocumentManager.UploadPaths = new string[] { filename_Doc };
            TXT_Editor.DocumentManager.DeletePaths = new string[] { filename_Doc };
            //size
            TXT_Editor.DocumentManager.MaxUploadFileSize = 4194304;
            TXT_Editor.ImageManager.MaxUploadFileSize = 1048576;

            Session["id_contenu"] = contenu.id;

            Session["publie"] = contenu.published;

            if (!string.IsNullOrEmpty(contenu.text))
            {
                TXT_Editor.Content = contenu.text;
            }          

            if (!string.IsNullOrEmpty(contenu.title))
            {
                if (contenu.title == "Nouvelle annonce")
                {
                    TBX_Titre.Text = "";
                    TBX_Titre.Focus();
                }
                else
                {
                    TBX_Titre.Text = contenu.title;
                }
            }

            if (!string.IsNullOrEmpty(contenu.announcementType))
            {
                if (contenu.announcementType.ToLower() == "offre")
                {
                    RBT_Offre.Checked = true;
                }
                else
                {
                    RBT_Demande.Checked = true;
                }
            } 

            IMG_Logo.ImageUrl = contenu.GetAnnoncePhoto();
            HF_Logo.Value = contenu.photo;
            BT_Effacer_Logo.Visible = contenu.photo != "";

            //if (!string.IsNullOrEmpty(contenu.file))
            //{                
            //    HL_Url.NavigateUrl = contenu.GetAnnonceFichier();
            //}

            //if (!string.IsNullOrEmpty(contenu.textFile))
            //{
            //    HL_Url.Text = contenu.textFile;
            //   // TXT_Url_Texte.Text = contenu.textFile;                
            //}

            if (contenu.mode == "Advanced")
            {
                pnl_advanced.Visible = true;
                pnl_simple.Visible = false;
            }
            else
            {
                pnl_simple.Visible = true;
                pnl_advanced.Visible = false;

                if(contenu.text!="")
                {
                    List<News.Bloc> b = new List<News.Bloc>();
                    b = (List<News.Bloc>)Functions.Deserialize(contenu.text, b.GetType());
                    LI_Blocs.DataSource = b;
                    LI_Blocs.DataBind();
                }
                
            }
            cbx_publish.Checked = contenu.published == "o";
        }
        else
        {
            pnl_simple.Visible = true;
            pnl_advanced.Visible = false;
        }
    }

    protected void Binding_Panel2()
    {
        contenu = new AIS.Content();
        contenu.published = "n";
        contenu.id_user = UserInfo.UserID;
        contenu.photo = "";
        contenu.text = "";
        contenu.title = "Nouvelle annonce";
        contenu.type = "Annonce";
        contenu.textFile = "";

       
        int id_c = DataMapping.Insert_Content(contenu);

        if (id_c > 0)
        {
            contenu.id = id_c;

            if (contenu != null)
            {
                // Custum image manager
                string filename_Img = Functions.ClearFileName(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/");
                DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/"));
                if (!d.Exists)
                {
                    d.Create();
                }
                TXT_Editor.ImageManager.ViewPaths = new string[] { filename_Img };
                TXT_Editor.ImageManager.UploadPaths = new string[] { filename_Img };
                TXT_Editor.ImageManager.DeletePaths = new string[] { filename_Img };

                // Custum document manager
                string filename_Doc = Functions.ClearFileName(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + contenu.id + "/");
                TXT_Editor.DocumentManager.ViewPaths = new string[] { filename_Doc };
                TXT_Editor.DocumentManager.UploadPaths = new string[] { filename_Doc };
                TXT_Editor.DocumentManager.DeletePaths = new string[] { filename_Doc };
                //size
                TXT_Editor.DocumentManager.MaxUploadFileSize = 4194304;
                TXT_Editor.ImageManager.MaxUploadFileSize = 1048576;

                Session["id_contenu"] = contenu.id;

                Session["publie"] = contenu.published;

                if (!string.IsNullOrEmpty(contenu.text))
                {
                    TXT_Editor.Content = contenu.text;
                }

                if (!string.IsNullOrEmpty(contenu.title))
                {
                    TBX_Titre.Text = contenu.title;
                }

                if (!string.IsNullOrEmpty(contenu.announcementType))
                {
                    if (contenu.announcementType.ToLower() == "offre")
                    {
                        RBT_Offre.Checked = true;
                    }
                    else
                    {
                        RBT_Demande.Checked = true;
                    }
                }

                IMG_Logo.ImageUrl = contenu.GetAnnoncePhoto();
                HF_Logo.Value = contenu.photo;
                BT_Effacer_Logo.Visible = contenu.photo != "";

                //if (!string.IsNullOrEmpty(contenu.file))
                //{
                //    HL_Url.NavigateUrl = contenu.GetAnnonceFichier();
                //}

                //if (!string.IsNullOrEmpty(contenu.textFile))
                //{
                //    HL_Url.Text = contenu.textFile;
                //    //TXT_Url_Texte.Text = contenu.textFile;
                //}
            }
        }
        else
        {

        }
    }   

    protected void BT_Upload_Logo_Click(object sender, EventArgs e)
    {
        if (FU_Logo.UploadedFiles.Count > 0)
        {
            UploadedFile file = FU_Logo.UploadedFiles[0];
            string guid = Guid.NewGuid().ToString();
            string filename = Functions.ClearFileName("news_" + guid + ".jpg");

            Bitmap bmp = new Bitmap(file.InputStream);
            bmp = Functions.ThumbByWidth(bmp, Const.CONTENT_PHOTOS_WIDTH);
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            HF_Logo.Value = filename;

            Media media = new Media();
            media.content = ms.GetBuffer();
            media.content_size = media.content.Length;
            media.dt = DateTime.Now;
            media.w = bmp.Width;
            media.h = bmp.Height;
            media.name = filename;
            media.content_type = "image/jpeg";
            Session[HF_Logo.Value] = media;

            IMG_Logo.ImageUrl = Const.MEDIA_VIEW_URL + "?id=" + filename;
            BT_Effacer_Logo.Visible = true;
        }
    }
    protected void BT_Effacer_Logo_Click(object sender, EventArgs e)
    {
        BT_Effacer_Logo.Visible = false;
        Session[HF_Logo.Value] = null;
        HF_Logo.Value = "";
        IMG_Logo.ImageUrl = Const.MEMBERS_NOPHOTO_F;
    }


    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        int i = 0;
        int id_c = 0;
        try
        {            
            AIS.Content c = DataMapping.GetContent_by_ID(id_contenu) != null ? DataMapping.GetContent_by_ID(id_contenu) : new AIS.Content();
            //string id_contenu = "" + Session["id_contenu"];
            //if (!string.IsNullOrEmpty(id_contenu))
            //{                
            //    int.TryParse(id_contenu, out i);
            //    if (i > 0)
            //    {
            //        c.id = i;
            //    }
            //}

            c.published = cbx_publish.Checked? "o" : "n";
            c.id_user = UserInfo.UserID;
            c.photo = HF_Logo.Value;
            c.text = TXT_Editor.Content ;
            c.title = TBX_Titre.Text.Trim();
            c.type = "Annonce";
            c.textFile = "";

            if (RBT_Demande.Checked == true)
            {
                c.announcementType = "demande";
            }
            else
            {
                c.announcementType = "offre";
            }

            Session["id_contenu"] = null;

            id_c = DataMapping.Insert_Content(c);

            Session["Insert"] = null;
            Session["publie"] = null;

            if (id_c > 0)
            {
                if (Session[HF_Logo.Value] != null)
                {
                    string chemin = PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + id_c + "/" + HF_Logo.Value;
                    DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + id_c + "/"));
                    if (!d.Exists)
                    {
                        d.Create();
                    }
                    File.WriteAllBytes(Server.MapPath(chemin), ((Media)Session[HF_Logo.Value]).content);

                    Session[HF_Logo.Value] = null;
                }

                //if (Session[HL_Url.Text] != null)
                //{
                //    string chemin = PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + id_c + "/" + HL_Url.Text;
                //    DirectoryInfo d = new DirectoryInfo(Server.MapPath(PortalSettings.Current.HomeDirectory + Const.CONTENT_ANNOUNCEMENT_PREFIX + id_c + "/"));
                //    if (!d.Exists)
                //    {
                //        d.Create();
                //    }
                //    File.WriteAllBytes(Server.MapPath(chemin), ((Media)Session[HL_Url.Text]).content);

                //    Session[HL_Url.Text] = null;
                //}            
            }
            else
            {
                throw new Exception("");
            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
            //retour à l'annonce
            Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(Annoncetabid), "id_contenu", "" + i));
        }

        if (id_c > 0)
        {
            if (DataMapping.Sub_Active_by_id_content(id_c, "Annonce") == true)
            {
                //retour à l'annonce
                Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(Annoncetabid), "id_contenu", "" + id_c));
            }
            else
            {
                string s = Functions.UrlAddParam(Functions.UrlAddParam(Globals.NavigateURL(Annoncetabid), "id_contenu", "" + id_c),"modif","true");
                Response.Redirect(s);
            }
        }
    }

    protected void BT_Annuler_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id_contenu"] != null && int.Parse(Request.QueryString["id_contenu"]) > 0 && (DataMapping.GetContent_by_ID(int.Parse(Request.QueryString["id_contenu"])).text == null || DataMapping.GetContent_by_ID(int.Parse(Request.QueryString["id_contenu"])).text == ""))
        {
            DataMapping.Delete_Content(int.Parse(Request.QueryString["id_contenu"]), UserInfo.UserID);
        }
        //if (Session["Insert"] == "o")
        //{
            if (Session["id_contenu"] != null)
            {
                //Le user a voulu créer une annonce mais le user n'a pas validé donc, il faut la supprimer
                int idcontenu = 0;
                int.TryParse(Session["id_contenu"].ToString(), out idcontenu);
                /*if (idcontenu > 0)
                {
                    if (DataMapping.Delete_Content(idcontenu, UserInfo.UserID) > 0)
                    {
                        Session["Insert"] = null;
                        Session["id_contenu"] = null;
                        Session[HF_Logo.Value] = null;
                        Session[HL_Url.Text] = null;
                        Session["publie"] = null;

                        //retour à l'espace pro
                        Response.Redirect(Globals.NavigateURL(ProTabId));
                    }
                }*/
                Response.Redirect(Globals.NavigateURL(Annoncetabid));
            }
        //}
        else
        {
            Session["Insert"] = null;
            Session["id_contenu"] = null;
            Session[HF_Logo.Value] = null;
            //Session[HL_Url.Text] = null;
            Session["publie"] = null;

            //retour à l'annonce
            Response.Redirect(Globals.NavigateURL(Annoncetabid));
        }

        
    }





    protected void LI_Blocs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (Request.QueryString["id_contenu"] != null)
            contenu = DataMapping.GetContent_by_ID(int.Parse(Request.QueryString["id_contenu"]));
        News.Bloc b = (News.Bloc)e.Item.DataItem;
        if (b == null)
            return;
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)e.Item.FindControl("Image1");

        if (b.photo != null)
            Image1.ImageUrl = b.photo;

        if (b.type.Contains("Video"))
        {
            Video vid = new Video();
            vid = (Video)Functions.Deserialize(b.content, vid.GetType());
            Label Texte1 = (Label)e.Item.FindControl("Texte1");
            Texte1.Text = vid.getLink();
            Panel pnl_content = (Panel)e.Item.FindControl("pnl_content");
            pnl_content.CssClass += " videoContainer";
        }
        else if(b.type.Contains("Files"))
        {
            try
            {
                Label Texte1 = (Label)e.Item.FindControl("Texte1");
                List<AIS_File> files = new List<AIS_File>();
                if (b.content != null && b.content != "")
                    files = (List<AIS_File>)Functions.Deserialize(b.content, files.GetType());

                //if (hfd_files.Value != "")
                //    files = (List<AIS_File>) Functions.Deserialize(hfd_files.Value, files.GetType());



                Panel pnl_filesUploaded = (Panel)e.Item.FindControl("pnl_filesUploaded");


                #region Edit mode

                if (files.Count > 0)
                {
                    if (hfd_files.Value == "")
                        hfd_files.Value = b.content;
                    gvw_filesUploaded.DataSource = files;
                    gvw_filesUploaded.DataBind();
                }



                #endregion Edit mode

                #region Display mode

                Texte1.Text = createListFile(files);

                #endregion Display mode




                btn_image.Text = "Changer l'image";




            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
        }

        LinkButton btn_up = (LinkButton)e.Item.FindControl("btn_up");
        LinkButton btn_down = (LinkButton)e.Item.FindControl("btn_down");
        btn_up.Visible = b.ord > 10;
        List<News.Bloc> blocs = new List<News.Bloc>();
        if(contenu != null && contenu.text!=null && contenu.text!="")
            blocs = (List<News.Bloc>)Functions.Deserialize(contenu.text, blocs.GetType());
        btn_down.Visible = b.ord < (blocs.Count) * 10;
    }

    protected void LI_Blocs_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (Request.QueryString["id_contenu"] != null)
            contenu = DataMapping.GetContent_by_ID(int.Parse(Request.QueryString["id_contenu"]));
        if (e.CommandSource == (LinkButton)e.Item.FindControl("lbt_delete"))
        {
            LinkButton lbt_delete = (LinkButton)e.Item.FindControl("lbt_delete");

            List<News.Bloc> b = new List<News.Bloc>();
            b = (List<News.Bloc>)Functions.Deserialize(contenu.text, b.GetType());

            foreach (News.Bloc bloc in b)
            {
                if (bloc.id == lbt_delete.CommandArgument)
                {
                    foreach (News.Bloc bl in b)
                    {
                        if (bl.ord > bloc.ord)
                        {
                            bl.ord -= 10;
                            int id = int.Parse(bl.id);
                            id -= 1;
                            bl.id = "" + id;

                        }

                    }
                    b.Remove(bloc);
                    break;
                }

            }



            contenu.text = Functions.Serialize(b);
            contenu.type = "Annonce";
            contenu.dt = DateTime.Now;
            contenu.id_user = UserId;
            contenu.title = TBX_Titre.Text;
            contenu.announcementType = contenu.announcementType!=null? contenu.announcementType : "";
            contenu.photo = contenu.photo != null ? contenu.photo : "";
            contenu.url = contenu.url != null ? contenu.url : "";
            contenu.file = contenu.file != null ? contenu.file : "";
            contenu.textFile = contenu.textFile != null ? contenu.textFile : "";
            contenu.published = contenu.published != null ? contenu.published : "N";
            contenu.company = "";
            contenu.mode = "Simple";
            DataMapping.Insert_Content(contenu);
            Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(), "id_contenu", "" + Request.QueryString["id_contenu"]));

        }
        if (e.CommandSource == (LinkButton)e.Item.FindControl("hlk_edit_texte"))
        {
            pnl_Edit.Visible = true;
            pnl_display.Visible = false;
            LinkButton hlk_edit_texte = (LinkButton)e.Item.FindControl("hlk_edit_texte");

            List<News.Bloc> b = new List<News.Bloc>();
            b = (List<News.Bloc>)Functions.Deserialize(contenu.text, b.GetType());
            News.Bloc bloc = new News.Bloc();
            foreach (News.Bloc bl in b)
            {
                if (bl.id == hlk_edit_texte.CommandName)
                {
                    bloc = bl;
                    break;
                }
            }

            if (!bloc.type.Contains("Video"))
                tbx_contenu.Text = bloc.content;
            else
            {
                Video vid = new Video();
                vid = (Video)Functions.Deserialize(bloc.content, vid.GetType());
                TextBox2.Text = vid.Url;
            }

            foreach (ListItem li in rbl_type.Items)
            {
                if ("Bloc" + li.Value == bloc.type)
                {
                    li.Selected = true;
                    if (li.Value.Contains("Video"))
                    {
                        tbx_contenu.Visible = false;
                        pnl_image.Visible = false;
                        pnl_video.Visible = true;
                        pnl_files.Visible = false;
                    }
                    else if (li.Value.Contains("Photo"))
                    {
                        tbx_contenu.Visible = true;
                        pnl_video.Visible = false;
                        pnl_files.Visible = false;
                        if (!li.Value.Contains("No"))
                            pnl_image.Visible = true;
                        else
                            pnl_image.Visible = false;
                    }
                    else if (li.Value.Contains("Files"))
                    {
                        tbx_contenu.Visible = false;
                        pnl_image.Visible = false;
                        pnl_video.Visible = false;
                        pnl_files.Visible = true;
                    }
                    break;
                }
            }

            btn_validateAdd.Text = "Modifier le bloc";

            if (bloc.photo != null)
                img.ImageUrl = bloc.photo;


            btn_validateAdd.CommandArgument = hlk_edit_texte.CommandName;



        }
        if (e.CommandSource == (LinkButton)e.Item.FindControl("btn_up"))
        {
            LinkButton btn_up = (LinkButton)e.Item.FindControl("btn_up");

            List<News.Bloc> b = new List<News.Bloc>();
            b = (List<News.Bloc>)Functions.Deserialize(contenu.text, b.GetType());


            foreach (News.Bloc bl in b)
            {
                if (bl.id == btn_up.CommandName)
                {
                    int index = b.IndexOf(bl) - 1;
                    b.ElementAt(index).ord += 10;
                    b.Remove(bl);
                    bl.ord -= 10;
                    b.Insert(index, bl);
                    break;
                }

            }

            contenu.text = Functions.Serialize(b);
            contenu.type = "Annonce";
            contenu.dt = DateTime.Now;
            contenu.id_user = UserId;
            contenu.title = TBX_Titre.Text;
            contenu.announcementType = contenu.announcementType != null ? contenu.announcementType : "";
            contenu.photo = contenu.photo != null ? contenu.photo : "";
            contenu.url = contenu.url != null ? contenu.url : "";
            contenu.file = contenu.file != null ? contenu.file : "";
            contenu.textFile = contenu.textFile != null ? contenu.textFile : "";
            contenu.published = contenu.published != null ? contenu.published : "N";
            contenu.company = "";
            contenu.mode = "Simple";
            DataMapping.Insert_Content(contenu);
            Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(), "id_contenu", "" + Request.QueryString["id_contenu"]));

        }
        if (e.CommandSource == (LinkButton)e.Item.FindControl("btn_down"))
        {
            LinkButton btn_down = (LinkButton)e.Item.FindControl("btn_down");

            List<News.Bloc> b = new List<News.Bloc>();
            b = (List<News.Bloc>)Functions.Deserialize(contenu.text, b.GetType());


            foreach (News.Bloc bl in b)
            {
                if (bl.id == btn_down.CommandName)
                {
                    int index = b.IndexOf(bl) + 1;
                    b.ElementAt(index).ord -= 10;
                    b.Remove(bl);
                    bl.ord += 10;
                    b.Insert(index, bl);
                    break;
                }

            }

            contenu.text = Functions.Serialize(b);
            contenu.type = "Annonce";
            contenu.dt = DateTime.Now;
            contenu.id_user = UserId;
            contenu.title = TBX_Titre.Text;
            contenu.announcementType = contenu.announcementType != null ? contenu.announcementType : "";
            contenu.photo = contenu.photo != null ? contenu.photo : "";
            contenu.url = contenu.url != null ? contenu.url : "";
            contenu.file = contenu.file != null ? contenu.file : "";
            contenu.textFile = contenu.textFile != null ? contenu.textFile : "";
            contenu.published = contenu.published != null ? contenu.published : "N";
            contenu.company = "";
            contenu.mode = "Simple";
            DataMapping.Insert_Content(contenu);
            Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(), "id_contenu", "" + Request.QueryString["id_contenu"]));
        }
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        pnl_display.Visible = false;
        pnl_Edit.Visible = true;
    }

    protected void btn_image_Click(object sender, EventArgs e)
    {
        if (ful_image.HasFile)
        {
            ///////////////////////////////////////////////////////*Changer ici l'image*//////////////////////////////////
            string fileName = Path.GetFileName(Guid.NewGuid().ToString() + "-" + ful_image.PostedFile.FileName);
            string path = PortalSettings.HomeDirectory + "Espace Professionnel/Annonces/" + Request.QueryString["id_contenu"] + "/Images/";
            DirectoryInfo d = new DirectoryInfo(Server.MapPath(path));
            if (!d.Exists)
                d.Create();
            ful_image.PostedFile.SaveAs(Server.MapPath(path) + "/" + fileName);
            img.ImageUrl = path + fileName;
            hfd_image.Value = path + fileName;

            btn_image.Text = "Changer l'image";
        }
    }

    protected void btn_validateAdd_Click(object sender, EventArgs e)
    {
        contenu = DataMapping.GetContent_by_ID(int.Parse(Request.QueryString["id_contenu"]));
        if (contenu == null)
            contenu = new AIS.Content();
        News.Bloc bloc = new News.Bloc();
        foreach (ListItem li in rbl_type.Items)
        {
            if (li.Selected)
            {
                bloc.type = "Bloc" + li.Value;
                break;
            }
        }
        List<News.Bloc> b = new List<News.Bloc>();
        if (!bloc.type.Contains("Files"))
        {
            if (!bloc.type.Contains("Video"))
            {
                bloc.content = tbx_contenu.Text;
            }
            else
            {
                Video v = new Video();
                v.Url = TextBox2.Text;
                if (v.Url.Contains("youtube"))
                    v.Type = "youtube";
                else if (v.Url.Contains("daily"))
                    v.Type = "daily";
                else
                    v.Type = "vimeo";
                bloc.content = Functions.Serialize(v);
            }
            if (bloc.type.Contains("Photo") && !bloc.type.Contains("No"))
            {
                bloc.photo = img.ImageUrl;
            }




            if (contenu.text != null && contenu.text != "")
            {
                b = (List<News.Bloc>)Functions.Deserialize(contenu.text, b.GetType());
                if (btn_validateAdd.CommandArgument != "")
                {
                    bloc.id = btn_validateAdd.CommandArgument;
                    foreach (News.Bloc bl in b)
                    {
                        if (bl.id == bloc.id)
                        {
                            bloc.ord = bl.ord;
                            int index = b.IndexOf(bl);
                            b.Remove(bl);
                            b.Insert(index, bloc);
                            break;
                        }
                    }
                }
                else
                {
                    bloc.id = hfd_id.Value != "" ? hfd_id.Value : "" + (b.Count + 1);
                    bloc.ord = (b.Count + 1) * 10;
                    b.Add(bloc);
                }
            }
            else
            {
                bloc.ord = 10;
                bloc.id = "" + 1;
                b.Add(bloc);
            }
        }
        else
        {
            if (contenu.text != null && contenu.text != "")
                b = (List<News.Bloc>)Functions.Deserialize(contenu.text, b.GetType());
        }    
        contenu.text = Functions.Serialize(b);
        contenu.type = "Annonce";
        contenu.dt = DateTime.Now;
        contenu.id_user = UserId;
        contenu.title = TBX_Titre.Text;
        contenu.announcementType = contenu.announcementType!=null? contenu.announcementType : "";
        contenu.photo = contenu.photo != null ? contenu.photo : "";
        contenu.url = contenu.url != null ? contenu.url : "";
        contenu.file = contenu.file != null ? contenu.file : "";
        contenu.textFile = contenu.textFile != null ? contenu.textFile : "";
        contenu.published = contenu.published != null ? contenu.published : "N";
        contenu.company = "";
        contenu.mode = "Simple";
        DataMapping.Insert_Content(contenu);
        hfd_id.Value = "";
        Response.Redirect(Functions.UrlAddParam(Globals.NavigateURL(), "id_contenu", "" + Request.QueryString["id_contenu"]));
    }

    protected void btn_cancelAdd_Click(object sender, EventArgs e)
    {
        pnl_display.Visible = true;
        pnl_Edit.Visible = false;
    }

    protected void btn_type_Click(object sender, EventArgs e)
    {
        foreach (ListItem li in rbl_type.Items)
        {
            if (li.Selected && li.Value != "NoPhoto" && li.Value != "Video" && li.Value != "Files")
            {
                tbx_contenu.Visible = true;
                pnl_video.Visible = false;
                pnl_image.Visible = true;
                pnl_files.Visible = false;
                return;
            }
            if (li.Selected && li.Value == "Video")
            {
                tbx_contenu.Visible = false;
                pnl_image.Visible = false;
                pnl_video.Visible = true;
                pnl_files.Visible = false;
                return;
            }
            if(li.Selected && li.Value == "Files")
            {
                tbx_contenu.Visible = false;
                pnl_image.Visible = false;
                pnl_video.Visible = false;
                pnl_files.Visible = true;
                break;
            }
            else if(li.Selected)
            {
                tbx_contenu.Visible = true;
                pnl_image.Visible = false;
                pnl_video.Visible = false;
                pnl_files.Visible = false;
                break;
            }
        }
       
    }

    protected void gvw_filesUploaded_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView gv = (GridView)sender;
        List<AIS_File> files = new List<AIS_File>();
        if (hfd_files.Value == "")
            throw new Exception("Problem : no files");
        files = (List<AIS_File>)Functions.Deserialize(hfd_files.Value, files.GetType());

        int index = (gv.PageIndex * gv.PageSize) + int.Parse("" + e.CommandArgument);
        AIS_File file = files[index];
        files.Remove(file);
        try
        {
            File.Delete(Server.MapPath(file.Url));
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        hfd_files.Value = Functions.Serialize(files);
        gv.DataSource = files;
        gv.DataBind();
    }

    protected void btn_uploadFiles_Click(object sender, EventArgs e)
    {
        contenu = DataMapping.GetContent_by_ID(int.Parse(Request.QueryString["id_contenu"]));
        if (ful_files.HasFile)
        {
            News.Bloc bloc = new News.Bloc();
            List<News.Bloc> blocs = new List<News.Bloc>();
            if (contenu.text != "" && contenu.mode == "Simple")
                blocs = (List<News.Bloc>)Functions.Deserialize(contenu.text, blocs.GetType());
            bloc.id = hfd_id.Value != "" ? hfd_id.Value : "" + (blocs.Count + 1);

            int index = -1;
            foreach(News.Bloc b in blocs)
            {
                if (b.id == bloc.id)
                {
                    bloc = b;
                    index = blocs.IndexOf(b);
                }
                    
            }
            if (bloc.ord == 0)
                bloc.ord = (blocs.Count + 1) * 10;

            if (bloc.id != hfd_id.Value)
                hfd_id.Value = bloc.id;

            string fileName = Path.GetFileName(Guid.NewGuid().ToString() + "-" + ful_files.PostedFile.FileName);
            string path = PortalSettings.HomeDirectory + "Espace Professionnel/Annonces/" + Request.QueryString["id_contenu"] + "/Documents";
            DirectoryInfo d = new DirectoryInfo(Server.MapPath(path));
            if (!d.Exists)
                d.Create();
            ful_files.PostedFile.SaveAs(Server.MapPath(path) + fileName);

            foreach (ListItem li in rbl_type.Items)
            {
                if (li.Selected)
                    bloc.type = "Bloc" + li.Value;
            }

            bloc.visible = "O";

            List<AIS_File> files = new List<AIS_File>();

            if (bloc.content != null && bloc.content != "")
            {
                files = (List<AIS_File>)Functions.Deserialize(bloc.content, files.GetType());
            }
            else 
            {
                files = hfd_filesToDelete.Value == "" ? new List<AIS_File>() : (List<AIS_File>)Functions.Deserialize(hfd_filesToDelete.Value, files.GetType());
            }
            AIS_File file = new AIS_File();
            file.Name = ful_files.PostedFile.FileName;
            file.Url = path + fileName;

            files.Add(file);
            bloc.content = Functions.Serialize(files);
            bloc.content_type = "files";
            bloc.photo = "";
            hfd_files.Value = Functions.Serialize(files);

            List<AIS_File> filesToDelete = new List<AIS_File>();
            if (hfd_filesToDelete.Value != "")
            {
                filesToDelete = (List<AIS_File>)Functions.Deserialize(hfd_filesToDelete.Value, files.GetType());

            }
            filesToDelete.Add(file);
            hfd_filesToDelete.Value = Functions.Serialize(filesToDelete);

            if(index!=-1)
            {
                News.Bloc old = blocs.ElementAt(index);
                blocs.Remove(old);
                blocs.Insert(index, bloc);
            }
            else
            {
                blocs.Add(bloc);
            }

            
            
            
            

            

            contenu.text = Functions.Serialize(blocs);
            DataMapping.Insert_Content(contenu);

            LI_Blocs.DataSource = blocs;
            LI_Blocs.DataBind();


        }
    }

    private String createListFile(List<AIS_File> files)
    {
        String result = "<div><ul>";
        foreach (AIS_File file in files)
        {
            result += "<li><a href=\"" + file.Url + "\" >" + file.Name + "</a></li>";
        }
        return result + "</ul></div>";
    }
}