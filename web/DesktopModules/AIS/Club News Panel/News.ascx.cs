﻿
#region Copyrights

// RODI - https://rodi-platform.org   
// Copyright (c) 2012-2023
// by SAS AIS : https://www.aisdev.net
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
using System.Web.UI.WebControls;
using AIS;
using System.IO;

public partial class DesktopModules_AIS_Club_News_Panel : PortalModuleBase
{
    ModuleController objModules = new ModuleController();
    
    public string MainClass
    {
        get
        {
            return HasPermission() ? "" + Settings["mainclassadmin"] :"" + Settings["mainclass"];
        }
    }
    int nbnews
    {
        get
        {
            int nb = 0;
            int.TryParse("" + Settings["nbnews"], out nb);
            if (nb == 0)
                return int.MaxValue;
            return nb;
        }
    }
    bool justimage
    {
        get
        {
            return ("" + Settings["justimage"]).Equals(Const.YES);
        }
    }
    int tabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + Settings["tabid"], out t);
            return t;
        }
    }
    string categorie
    {
        get 
        {
            return "club_news_informations";
            
        }
    }

    int cric {
        get
        {
            int c = 0;
            int.TryParse(CRIC.Value, out c);
            if (c == 0)
            {
                Club club = DataMapping.GetClubBySeo("" + Request["sn"]);
                if (club != null)
                {
                    c = club.cric;                 
                }
                else
                {
                    string rcric = "" + Request["cric"];
                    int.TryParse(rcric, out c);

                }
                CRIC.Value = ""+c;
            }
            

            return c;
        }
        set
        {
            CRIC.Value = ""+value;
        }
    }

    string style
    {
        get
        {
            return "";
        }
    }

    string accessPath
    {
        get { return Const.CLUBS_MEDIA_PREFIX; }
    }

    string newsid = "";

    bool HasPermission()
    {
        bool isAuthorised = false;
        try
        {
            Member m = Functions.GetCurrentMember();
            if (UserInfo.IsSuperUser || 
                (UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) && cric != 0 && m != null && m.cric == cric) ||
                UserInfo.IsInRole("Administrators") ||
                UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT)
                )
            {
                isAuthorised = true;
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
        return isAuthorised;        
    }

    string url {
        get
        {
            if (URL.Value == "")
            {
                URL.Value = ("" + Request.RawUrl).Split('?')[0];
            } 

            return URL.Value;
        }
        set
        {
            URL.Value = ""+value;
        }
    }
        

    List<News> news;

    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!IsPostBack)
        {
            newsid = ("" + Request.QueryString["newsid"]);

            
            if ( HasPermission() &&  Request.QueryString["id"] != null && Request.QueryString["id"] != "" && (Request.QueryString["modif"] != null || Request.QueryString["modif"] == "true"))
            {

                LI_News.Visible = false;
                btn_add.Visible = false;
                pnl_add.Visible = true;
                News theNews = DataMapping.GetNews_EN(Request.QueryString["id"]);
                if (tbx_titre.Text == "")
                    tbx_titre.Text = theNews.title;
                if (theNews.photo != "")
                    btn_image.Text = "Changer l'image";

                switch (theNews.tag2)
                {
                    case "BlocNoPhoto":
                        if (tbx_contenu.Text == "")
                            tbx_contenu.Text = theNews.text;
                        pnl_image.Visible = false;
                        pnl_video.Visible = false;
                        tbx_contenu.Visible = true;
                        break;
                    case "BlocVideo":
                        Video vid = new Video();
                        try { 
                            vid = (Video)Functions.Deserialize(theNews.text, vid.GetType());
                        }
                        catch { }

                        if (tbx_url.Text == "")
                            tbx_url.Text = vid.Url;
                        pnl_video.Visible = true;
                        pnl_image.Visible = false;
                        tbx_contenu.Visible = false;
                        break;
                    default:
                        if (tbx_contenu.Text == "")
                            tbx_contenu.Text = theNews.text;
                        if (hfd_image.Value == "")
                            hfd_image.Value = theNews.photo;
                        if (img.ImageUrl == "")
                            img.ImageUrl = theNews.photo;
                        pnl_image.Visible = true;
                        tbx_contenu.Visible = true;
                        pnl_video.Visible = false;
                        break;
                }
                foreach (ListItem li in rbl_type.Items)
                {
                    if ("Bloc" + li.Value == theNews.tag2)
                    {
                        li.Selected = true;
                        break;
                    }
                }

            }





            int nb = nbnews;
            //var news = (from n in AIS.DataMapping.ListeNews(onlyvisible: true, categorie: categorie, tags_inclus: "" + objModules.GetModuleSettings(ModuleId)["tags_inclus"], tags_exclus: "" + objModules.GetModuleSettings(ModuleId)["tags_exclus"]) orderby n.dt ascending where n.dt.CompareTo( DateTime.Now.AddDays(-1))>0 select n );

            //List<News> news = DataMapping.ListNews(sort: "ord");

            news = AIS.DataMapping.ListNews_EN(cric: cric ,tri: "ord", onlyvisible: true, category: categorie, tags_included: "" , tags_excluded: "" );
            
            LI_News.DataSource = news;
            if (HasPermission() && Request.QueryString["delete"] != null && Request.QueryString["delete"] == "true")
            {
                List<News> newsToDelete = new List<News>();
                pnl_delete.Visible = true;
                btn_add.Visible = false;
                foreach (News n in news)
                {
                    if (n.id == Request.QueryString["id"])
                    {
                        newsToDelete.Add(n);
                    }
                }
                LI_News.DataSource = newsToDelete;
            }
            LI_News.DataBind();
            btn_add.Visible = HasPermission() && LI_News.Visible && (Request.QueryString["modif"] == null || Request.QueryString["modif"] == "") && (Request.QueryString["delete"] == null || Request.QueryString["delete"] == "");


            
        }


    }
    
   
    protected void LI_News_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        News theNews = (News)e.Item.DataItem;
        if (theNews == null)
            return;
        var mainpanel = e.Item.FindControl("P_Main") as Panel;
        mainpanel.CssClass = MainClass;

        var panel = e.Item.FindControl("Panel1") as Panel;
       
        panel.CssClass = panel.CssClass +" " +theNews.tag2 + " " +style;
        if (theNews.id == newsid)
            panel.CssClass = panel.CssClass + " active";


        Literal title = e.Item.FindControl("L_Title") as Literal;
        title.Text = "<h2>"+theNews.title+"</h2>";
        title.Visible = !theNews.title.Trim().Equals("");



        var image = e.Item.FindControl("Image1") as Image;
        image.ImageUrl = theNews.GetPhoto();        
        image.Visible = image.ImageUrl != "" &&  image.ImageUrl != Const.no_image;

        var hl = e.Item.FindControl("HL_Detail") as HyperLink;
        string ul = Functions.UrlAddParam(url+"/article/", "newsid",""+theNews.id);
        hl.NavigateUrl = Functions.UrlAddParam(ul, "cric", ""+theNews.cric) ;
        var hl1 = e.Item.FindControl("HL_Detail1") as HyperLink;
        hl1.NavigateUrl = hl.NavigateUrl;

        HyperLink hlk_edit_texte = (HyperLink)e.Item.FindControl("hlk_edit_texte");
        hlk_edit_texte.Visible = HasPermission();
        hlk_edit_texte.NavigateUrl = Functions.UrlAddParam(url, "id", theNews.id);
        hlk_edit_texte.NavigateUrl = Functions.UrlAddParam(hlk_edit_texte.NavigateUrl, "modif", "true");
        hlk_edit_texte.NavigateUrl = Functions.UrlAddParam(hlk_edit_texte.NavigateUrl, "cric", ""+cric);

        Panel pnl_content = (Panel)e.Item.FindControl("pnl_content");
        Panel p_buttons = (Panel)e.Item.FindControl("P_Buttons"); 
        if (theNews.tag2=="BlocVideo" && theNews.text!="")
        {
            Video vid = new Video();
            try { 
                vid =(Video) Functions.Deserialize(theNews.text, vid.GetType());
            }
            catch { }

            Label Texte1 = (Label)e.Item.FindControl("Texte1");
            Texte1.Text = vid.getLink();
           pnl_content.CssClass += " videoContainer";
        }

        if (!HasPermission() && justimage)
        {
            pnl_content.Visible = false;
            title.Visible = false;
            p_buttons.Visible = false;
        }


        hlk_edit_texte.Visible = HasPermission() && (Request.QueryString["modif"] == null || Request.QueryString["modif"] == "")&& (Request.QueryString["delete"] == null || Request.QueryString["delete"] == "");
        if(! (theNews.GetListBlocs().Count > 0 || hlk_edit_texte.Visible))
            hl.NavigateUrl = "";
        hl1.Visible = theNews.GetListBlocs().Count > 0 || hlk_edit_texte.Visible;
        



        LinkButton btn_up = (LinkButton)e.Item.FindControl("btn_up") ;
        LinkButton btn_down = (LinkButton)e.Item.FindControl("btn_down");
        LinkButton btn_delete = (LinkButton)e.Item.FindControl("lbt_delete");



        btn_up.Visible = (theNews.ord>10) && HasPermission();
        btn_down.Visible = (theNews.ord < 10*(news.Count)) && HasPermission();
        btn_delete.Visible = HasPermission();
        
    }



    protected void btn_add_Click(object sender, EventArgs e)
    {
        LI_News.Visible = false;
        btn_add.Visible = false;
        pnl_add.Visible = HasPermission();
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        LI_News.Visible = true;
        btn_add.Visible = HasPermission();
        pnl_add.Visible = false;
        Response.Redirect(url);
    }

    protected void btn_image_Click(object sender, EventArgs e)
    {
        if (ful_image.HasFile)
        {
            string fileName = Path.GetFileName(Guid.NewGuid().ToString().Substring(0,8) + "-" + Functions.ClearFileName(ful_image.PostedFile.FileName));
            string path = PortalSettings.HomeDirectory  + accessPath  ;
            DirectoryInfo d = new DirectoryInfo(Server.MapPath(path));
            if (!d.Exists)
                d.Create();
            ful_image.PostedFile.SaveAs(Server.MapPath(path) + "/" + fileName);
            img.ImageUrl = path + fileName;
            hfd_image.Value = path + fileName;

            btn_image.Text = "Changer l'image";
        }

    }



    protected void btn_type_Click(object sender, EventArgs e)
    {
        foreach(ListItem li in rbl_type.Items)
        {
            if(li.Selected && li.Value!="NoPhoto" && li.Value!="Video")
            {
                tbx_contenu.Visible = true;
                pnl_video.Visible = false;
                pnl_image.Visible = true;
                return;
            }
            if(li.Selected && li.Value=="Video")
            {
                tbx_contenu.Visible = false;
                pnl_image.Visible = false;
                pnl_video.Visible = true;
                return;
            }
        }
        tbx_contenu.Visible = true;
        pnl_image.Visible = false;
        pnl_video.Visible = false;
    }





    protected void btn_validate_Click1(object sender, EventArgs e)
    {
        News newsToValidate = new News();
        if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
        {
            newsToValidate = DataMapping.GetNews(Request.QueryString["id"]);
            newsToValidate.id = Request.QueryString["id"];

        }

        newsToValidate.cric = cric;
        newsToValidate.title = tbx_titre.Text;
        String contenu = "";
        if (tbx_url.Text != "")
        {
            Video vid = new Video();
            vid.Url = tbx_url.Text;
            if (vid.Url.Contains("youtube"))
                vid.Type = "youtube";
            else if (vid.Url.Contains("vimeo"))
                vid.Type = "vimeo";
            else
                vid.Type = "daily";
            contenu = Functions.Serialize(vid);
        }
        newsToValidate.text = tbx_contenu.Text == "" ? contenu : tbx_contenu.Text;
        if (hfd_image.Value != null && hfd_image.Value != "")
            newsToValidate.photo = hfd_image.Value;
        else
            newsToValidate.photo = "";
        newsToValidate.category = categorie;
        newsToValidate.tag1 = "";
        foreach (ListItem li in rbl_type.Items)
        {
            if (li.Selected)
            {
                newsToValidate.tag2 = "Bloc" + li.Value;
                break;
            }
        }
        newsToValidate.ord = newsToValidate.id == null ? 10 * (LI_News.Items.Count + 1) : newsToValidate.ord;
        newsToValidate.dt = DateTime.Now;
        newsToValidate.date_end_event = DateTime.Now;
        newsToValidate.date_start_event = DateTime.Now;
        newsToValidate.end_publication = DateTime.Now;
        newsToValidate.Abstract = "";
        newsToValidate.url = "";
        newsToValidate.url_text = "";
        newsToValidate.visible = "O";
        newsToValidate.club_name = "";
        newsToValidate.club_type = "";
        newsToValidate.adress_event = "";
        newsToValidate.town_event = "";
        newsToValidate.zip_event = "";


        DataMapping.UpdateNews(newsToValidate);
        pnl_add.Visible = false;
        tbx_contenu.Text = "";
        tbx_titre.Text = "";
        tbx_url.Text = "";
        hfd_image.Value = "";
        LI_News.Visible = true;
        Response.Redirect(url);
    }


    protected void btn_yes_Click(object sender, EventArgs e)
    {
        News laNews = DataMapping.GetNews(Request.QueryString["id"]);
        List<News> newsAfter = new List<News>();
        foreach(News n in DataMapping.ListNews_EN(category: categorie))
        {
            if(n.ord>laNews.ord)
            {
                newsAfter.Add(n);
            }
        }
        DataMapping.DeleteNews(Request.QueryString["id"]);
        foreach(News n in newsAfter)
        {
            n.ord -= 10;
            DataMapping.UpdateNews_EN(n);
        }
        Response.Redirect(url);
    }

    protected void btn_no_Click(object sender, EventArgs e)
    {
        Response.Redirect(url);
    }




    protected void LI_News_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        news = AIS.DataMapping.ListNews_EN(cric: cric, tri: "ord", onlyvisible: true, category: categorie, tags_included: "" , tags_excluded: "" );
        int ord = 0;
        foreach(News n in news)
        {
            n.ord = ord;
            ord += 10;
            DataMapping.UpdateNews_EN(n);
        }
        news = AIS.DataMapping.ListNews_EN(cric: cric, tri: "ord", onlyvisible: true, category: categorie, tags_included: "", tags_excluded: "");

        if (e.CommandSource==e.Item.FindControl("btn_up"))
        {

            News theNews = DataMapping.GetNews(e.CommandName);
            if (theNews == news[0])
                return; // deja en haut

            News newsOnTop = null;
            for (int i=news.Count-1;i>=0;i--)
            {
                News n = news[i];
                if (n.ord < theNews.ord)
                {
                    newsOnTop = n;
                    break;
                }
            }
            if (newsOnTop == null)
                return; // pas de news après donc déjà en haut
            int tempOrd = theNews.ord;
            theNews.ord = newsOnTop.ord;
            newsOnTop.ord = tempOrd;
            if (!DataMapping.UpdateNews_EN(theNews))
                throw new Exception("Error update news");

            if (!DataMapping.UpdateNews_EN(newsOnTop))
                throw new Exception("Error update news on top");

        }
        else if(e.CommandSource == e.Item.FindControl("btn_down"))
        {
            News theNews = DataMapping.GetNews(e.CommandName);
            if (theNews == news[news.Count - 1])
                return; // deja en bas
            News newsOnBot = null;
            foreach (News n in news)
            {
                if (n.ord > theNews.ord)
                {
                    newsOnBot = n;
                    break;
                }
            }
            if (newsOnBot == null)
                return; // pas de news après donc déjà en bas
            int tempOrd = theNews.ord;
            theNews.ord = newsOnBot.ord;
            newsOnBot.ord = tempOrd;
            if (!DataMapping.UpdateNews_EN(theNews))
                throw new Exception("Error update news");

            if (!DataMapping.UpdateNews_EN(newsOnBot))
                throw new Exception("Error update news on bottom");
        }
        else if(e.CommandSource == e.Item.FindControl("lbt_delete"))
        {
            LinkButton lbt_delete = (LinkButton)e.Item.FindControl("lbt_delete");
            
            if (!DataMapping.DeleteNews(lbt_delete.CommandArgument))
                throw new Exception("Error deleting");
            
        }
        news = AIS.DataMapping.ListNews_EN(cric: cric, tri: "ord", onlyvisible: true, category: categorie, tags_included: "", tags_excluded: "");
        LI_News.DataSource = news;
        LI_News.DataBind();
    }
}