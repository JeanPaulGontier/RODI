
#region Copyrights

// RODI - http://rodi.aisdev.net
// Copyright (c) 2012-2021
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

/// Modifié le 12/07/2021 pour autoriser les catégories de nouvelles pour les nouvelles district
/// 
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
using DotNetNuke.Services.FileSystem;
using FileInfo = System.IO.FileInfo;

public partial class DesktopModules_AIS_Admin_News_List_Control : PortalModuleBase
{
    DotNetNuke.Entities.Modules.ModuleController objModules2 = new DotNetNuke.Entities.Modules.ModuleController();

    string mode
    {
        get
        {
            return "" + Settings["mode"];

        }
    }


    /// <summary>
    /// Rafraichit le GridView et, si l'utilisateur a les droits, affiche le bouton d'ajout de nouvelles
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

        BT_Ajouter_News.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT) || (DataMapping.isADG()) && Functions.CurrentCric!=0);

        if (mode == "district")
        {
            
            lbl_TousADG.Visible = false;
            GridView1.Visible = true;
        } 
        else if(mode == "clubs" && Functions.CurrentCric==0)
        {
            lbl_TousADG.Visible = true;
            GridView1.Visible = false;
            BT_Ajouter_News.Visible = false;
        }
        else if(mode == "clubs")
        {
            lbl_TousADG.Visible = false;
            GridView1.Visible = true;
        }


        
        
         
    }

    /// <summary>
    /// Applique la commande sélectionnée par l'utilisateur
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
                List<News> news = gv.DataSource as List<News>;

                News n = news[index];
                HF_id.Value = "" + n.id;
                RB_Visible.SelectedValue = n.visible;
                DL_Sujet.SelectedValue = n.tag1;
                //PanelSujet.Visible = Functions.CurrentCric > 0;
                TXT_Titre.Text = "" + n.title;
                TXT_Dt.SelectedDate = n.dt;
                TXT_Texte.Text = n.text;
                
                IMG_Photo.ImageUrl = n.GetPhoto();
                HF_Photo.Value = n.photo;
                BT_Effacer_Photo.Visible = (n.photo != "") && (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT));
                BT_Upload_Photo.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT));

                HL_Url.Text = n.url;
                TXT_Url_Texte.Text = n.url_text;
                HL_Url.NavigateUrl = n.GetUrl();

                BT_Upload_Fichier.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT));
                BT_Effacer_Fichier.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT));

                BT_Supprimer.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT));
                BT_Valider.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT));
                RB_Visible.Enabled = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT));

                BT_Creer_Vignette.Visible = false;

                if (n.club_type == Const.Club_Rotary && DataMapping.IsRotaract(PortalSettings.UserId))// L'admin rotaract ne peut pas modifier les nouvelles de type rotary
                {
                    BT_Supprimer.Visible = false;
                    BT_Valider.Visible = false;
                    BT_Creer_Vignette.Visible = false;
                    RB_Visible.Enabled = false;
                    BT_Effacer_Fichier.Visible = false;
                    BT_Upload_Fichier.Visible = false;
                    BT_Upload_Photo.Visible = false;
                    BT_Effacer_Photo.Visible = false;
                    FU_Url.Enabled = false;
                    FU_Photo.Enabled = false;
                }

                Panel1.Visible = false;
                Panel2.Visible = true;
                break;
        }
    }

    /// <summary>
    /// Permet de trier le GridView
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
    /// Permet de changer de page lors du changement d'index du GridView
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
    /// Rafraichit le GridView
    /// </summary>
    void RefreshGrid()
    {
        try
        {
            List<News> news = new List<News>();
            if (!DataMapping.isADG() || Functions.CurrentCric != 0)
            {
                news = DataMapping.ListNews(category: (mode=="clubs"? "Clubs" : "District"), cric: (mode=="district"? 0 : Functions.CurrentCric), sort: tri.Value + " " + sens.Value,
                    index: GridView1.PageIndex, max: GridView1.PageSize);
                lbl_TousADG.Visible = false;
                GridView1.Visible = true;
            }
            else
            {
                lbl_TousADG.Visible = true;
                GridView1.Visible = false;
            }
            
            
           
            GridView1.DataSource = news;
            GridView1.DataBind();
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

    /// <summary>
    /// Rafraichit le GridView et ramène au panel initial
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
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Valider_Click(object sender, EventArgs e)
    {
        News nouvelle = new News();
        if (HF_id.Value!="")
        {
            nouvelle = DataMapping.GetNews(HF_id.Value);    
        }
        nouvelle.category = Functions.CurrentCric > 0 ? "Clubs" : "District";
        nouvelle.cric = Functions.CurrentCric;
        nouvelle.dt = TXT_Dt.SelectedDate!=null?(DateTime)TXT_Dt.SelectedDate:DateTime.Now;
        nouvelle.club_name = Functions.CurrentClub != null ? Functions.CurrentClub.name : "";
        nouvelle.photo = HF_Photo.Value;
        nouvelle.tag1 = DL_Sujet.SelectedValue;
        nouvelle.tag2 = "";
        nouvelle.text = TXT_Texte.Text;
        nouvelle.title = TXT_Titre.Text;
        nouvelle.visible = RB_Visible.SelectedValue == Const.YES?Const.YES:Const.NO;
        nouvelle.url = HL_Url.Text;
        nouvelle.url_text = TXT_Url_Texte.Text;
        nouvelle.date_end_event = new DateTime(9999, 11, 29);
        nouvelle.end_publication = nouvelle.date_end_event;
        nouvelle.date_start_event = DateTime.Now;
        nouvelle.Abstract = "";
        nouvelle.adress_event = "";
        nouvelle.town_event = "";
        nouvelle.zip_event = "";
        if(DataMapping.IsRotaract(PortalSettings.UserId))
        {
            nouvelle.club_type = Const.Club_Rotaract;
        }
        else
        {
            nouvelle.club_type = Const.Club_Rotary;
        }

        if (!DataMapping.UpdateNews(nouvelle))
            return;
        if (Session[HF_Photo.Value] != null)
        {
            if(Functions.CurrentCric == 0)
                File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + Const.DISTRICT_PREFIX+Const.IMG_PREFIX + HF_Photo.Value), ((Media)Session[HF_Photo.Value]).content);
            else
                File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + Const.CLUBS_PREFIX + Functions.GetSEO(nouvelle.club_name).ToLower() + "/" + Const.IMG_PREFIX + HF_Photo.Value), ((Media)Session[HF_Photo.Value]).content);
            //File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + Const.CLUBS_PREFIX + nouvelle.club_name.Replace(" ", "-").Replace("'", "-").ToLower() + "/" + Const.IMG_PREFIX + HF_Photo.Value), ((Media)Session[HF_Photo.Value]).content);

            Session[HF_Photo.Value] = null;
        }
        if (Session[HL_Url.Text] != null)
        {
            if (Functions.CurrentCric == 0)
                File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + Const.DISTRICT_PREFIX + Const.DOCUMENT_PREFIX + HL_Url.Text), ((Media)Session[HL_Url.Text]).content);
            else
                File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + Const.CLUBS_PREFIX + Functions.GetSEO(nouvelle.club_name).ToLower() + "/" + Const.DOCUMENT_PREFIX + HL_Url.Text), ((Media)Session[HL_Url.Text]).content);
           // File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + Const.CLUBS_PREFIX + nouvelle.club_name.Replace(" ", "-").Replace("'", "-").ToLower() + "/" + Const.DOCUMENT_PREFIX + HL_Url.Text), ((Media)Session[HL_Url.Text]).content);

            Session[HL_Url.Text] = null;
        }
        
        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
   
    protected void BT_Upload_Photo_Click(object sender, EventArgs e)
    {
        if (FU_Photo.HasFiles)
        {

            HttpPostedFile file = FU_Photo.PostedFile;
            if (file.ContentType.StartsWith("image"))
            {


                string guid = HF_id.Value;
                if (guid == "")
                    guid = Guid.NewGuid().ToString();
                string filename = Functions.ClearFileName("news_" + guid + ".jpg");

                Bitmap bmp = new Bitmap(file.InputStream);
                bmp = Functions.ThumbByWidth(bmp, Const.NEWS_PHOTOS_WIDTH);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                HF_Photo.Value = filename;

                Media media = new Media();
                media.content = ms.GetBuffer();
                media.content_size = media.content.Length;
                media.dt = DateTime.Now;
                media.w = bmp.Width;
                media.h = bmp.Height;
                media.name = filename;
                media.content_type = "image/jpeg";
                Session[HF_Photo.Value] = media;

                IMG_Photo.ImageUrl = Const.MEDIA_VIEW_URL + "?id=" + filename;
                BT_Effacer_Photo.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('Veuillez choisir une image');</script>");
            
            }
        }
    }
    protected void BT_Effacer_Photo_Click(object sender, EventArgs e)
    {
        BT_Effacer_Photo.Visible = false;
        Session[HF_Photo.Value] = null;
        HF_Photo.Value = "";
        IMG_Photo.ImageUrl = Const.no_image;       
    }

    protected void BT_Ajouter_News_Click(object sender, EventArgs e)
    {

        HF_id.Value = "";
        RB_Visible.SelectedValue = Const.NO;
        DL_Sujet.SelectedValue = "";
        //PanelSujet.Visible = Functions.CurrentCric > 0;
        TXT_Titre.Text = "";
        TXT_Dt.SelectedDate = DateTime.Now;
        TXT_Texte.Text = "";

        IMG_Photo.ImageUrl = Const.no_image;
        HF_Photo.Value = "";
        BT_Effacer_Photo.Visible = false;
        BT_Upload_Photo.Visible = true;

        HL_Url.NavigateUrl = "";
        HL_Url.Text = "";
        TXT_Url_Texte.Text = "";

        BT_Supprimer.Visible = false;
        BT_Creer_Vignette.Visible = false;

        Panel2.Visible = true;
        Panel1.Visible = false;


        BT_Valider.Visible = true;        
        RB_Visible.Enabled = true;
        

        BT_Upload_Fichier.Visible = true;
        BT_Effacer_Fichier.Visible = false;
        
        FU_Url.Enabled = true;
        FU_Photo.Enabled = true;

    }
    protected void BT_Upload_Fichier_Click(object sender, EventArgs e)
    {
        if (FU_Url.HasFiles)
        {

            HttpPostedFile file = FU_Url.PostedFile;
         
            string guid = HF_id.Value;
            if (guid == "")
                guid = Guid.NewGuid().ToString();

            FileInfo fileInfo = new FileInfo(file.FileName);
            string filename = Functions.ClearFileName("news_" + guid + fileInfo.Extension );
            TXT_Url_Texte.Text = file.FileName;
            HL_Url.Text = filename;

            MemoryStream ms = new MemoryStream();
            file.InputStream.CopyTo(ms,(int)file.InputStream.Length);
            Media media = new Media();
            media.content = ms.GetBuffer();
            media.content_size = media.content.Length;
            media.dt = DateTime.Now;
            media.w = 0;
            media.h = 0;
            media.name = filename;
            media.content_type = file.ContentType;
            Session[HL_Url.Text] = media;

            HL_Url.NavigateUrl = Const.MEDIA_DOWNLOAD_URL + "?id=" + filename;
            BT_Effacer_Fichier.Visible = true;

            if (file.ContentType.Equals("application/pdf"))
            {
                BT_Creer_Vignette.Visible = true;
            }
        }
    }
    protected void BT_Effacer_Fichier_Click(object sender, EventArgs e)
    {
        BT_Effacer_Fichier.Visible = false;
        Session[HL_Url.Text] = null;
        HL_Url.Text = "";
        HL_Url.NavigateUrl = "";
        TXT_Url_Texte.Text = "";        
    }
    protected void BT_Supprimer_Click(object sender, EventArgs e)
    {
        if (!DataMapping.DeleteNews(HF_id.Value))
        {
            return;
        }
        if (HF_Photo.Value != "")
            try
            {
                if (Functions.CurrentCric == 0)
                    File.Delete(Server.MapPath(PortalSettings.HomeDirectory + Const.DISTRICT_PREFIX + Const.IMG_PREFIX + HF_Photo.Value));
                else
                    File.Delete(Server.MapPath(PortalSettings.HomeDirectory + Const.CLUBS_PREFIX + Functions.CurrentClub.name.Replace(" ", "-").Replace("'", "-").ToLower() + "/" + Const.IMG_PREFIX + HF_Photo.Value));
            
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }
        if (HL_Url.Text != "")
            try
            {
                if (Functions.CurrentCric == 0)
                    File.Delete(Server.MapPath(PortalSettings.HomeDirectory + Const.DISTRICT_PREFIX + Const.DOCUMENT_PREFIX + HL_Url.Text));
                else
                    File.Delete(Server.MapPath(PortalSettings.HomeDirectory + Const.CLUBS_PREFIX + Functions.CurrentClub.name.Replace(" ", "-").Replace("'", "-").ToLower() + "/" + Const.DOCUMENT_PREFIX + HL_Url.Text));

            }
            catch (Exception ee)
            {
                Functions.Error(ee);
            }

        RefreshGrid();
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    protected void BT_Creer_Vignette_Click(object sender, EventArgs e)
    {
        if (Session[HL_Url.Text] == null)
            return;

        Media media = Session[HL_Url.Text] as Media;

        string guid = HF_id.Value;
        if (guid == "")
            guid = Guid.NewGuid().ToString();
        string filename = Functions.ClearFileName("news_" + guid + ".jpg");

        Bitmap bmp = Functions.GetBitmapFromMedia(media);
        bmp = Functions.ThumbByWidth(bmp, Const.NEWS_PHOTOS_WIDTH);
        MemoryStream ms = new MemoryStream();
        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        HF_Photo.Value = filename;

        media = new Media();
        media.content = ms.GetBuffer();
        media.content_size = media.content.Length;
        media.dt = DateTime.Now;
        media.w = bmp.Width;
        media.h = bmp.Height;
        media.name = filename;
        media.content_type = "image/jpeg";
        Session[HF_Photo.Value] = media;

        IMG_Photo.ImageUrl = Const.MEDIA_VIEW_URL + "?id=" + filename;
        BT_Effacer_Photo.Visible = true;
    }
}