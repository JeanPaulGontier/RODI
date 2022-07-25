
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
using System.IO;

public partial class DesktopModules_AIS_Club_Detail_Control : PortalModuleBase
{
    DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
    int newstabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModuleId)["newstabid"], out t);
            return t;
        }
    }

    string newsPath
    {
        get
        {
            return "" + objModules.GetModuleSettings(ModuleId)["news"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //pnl_content.Visible = true;
            string seo = "" + Request.QueryString["sn"];
            Club club = DataMapping.GetClubBySeo(seo);
            if (club != null)
            {
                this.ModuleConfiguration.ModuleTitle = club.name;


                LBL_adresse_1.Text = club.adress_1;
                LBL_adresse_2.Text = club.adress_2;
                LBL_adresse_3.Text = club.adress_3;
                LBL_cp.Text = club.zip;
                LBL_ville.Text = club.town;
                IMG_fanion.ImageUrl = club.GetPennant();
                LBL_reunions.Text = club.meetings;
                LBL_telephone.Text = club.telephone;
                LBL_fax.Text = club.fax;
                HL_email.NavigateUrl = "mailto:" + club.email;
                HL_web.NavigateUrl = club.web;
                HL_web.Visible = club.web != "";
                LBL_texte.Text = club.text;

                btn_addBloc.Visible = HasPermission();

                if (!createNewsClub())
                    throw new Exception("An error occured while creating the club news");

                //List<News> news = DataMapping.ListNews(category:"Clubs", cric : club.cric);
                //LI_News.DataSource = news;
                //LI_News.DataBind();

                //btn_editBloc.Visible = (UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB)) && Functions.CurrentCric == club.cric;
                //lbt_deleteBloc.Visible = (UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB)) && Functions.CurrentCric == club.cric;

                List<Affectation> affectations = DataMapping.ListAffectation(club.cric);

                News news = DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault() == null ? new News() : DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault();

                if (news != null)
                {
                    if (news.id == null)
                    {
                        //btn_editBloc.Text = "Ajouter une présentation";
                        //pnl_content.Visible = false;
                        //lbt_deleteBloc.Visible = false;


                    }
                    else
                    {
                        List<News.Bloc> blocs = DataMapping.GetNews_EN(news.id).GetListBlocs();
                        repeat_bloc.DataSource = blocs;
                        repeat_bloc.DataBind();
                    }

                    //pnl_content.CssClass += news.tag2 + " MiniNews";




                    /*Titre1.Text = news.title;


                    switch (news.tag2)
                    {
                        case "BlocNoPhoto":
                            Texte1.Text = news.text;
                            Image1.Visible = false;
                            break;
                        case "BlocVideo":
                            Video vid = new Video();
                            vid = (Video)Functions.Deserialize(news.text, vid.GetType());
                            Texte1.Text = vid.getLink();
                            pnl_video.Visible = true;
                            Panel2.CssClass += " videoContainer";
                            break;
                        default :
                            Image1.ImageUrl = news.photo;
                            Texte1.Text = news.text;
                            Image1.Visible = true;
                            break;
                    }



                    HL_Detail.NavigateUrl = Functions.UrlAddParam(Globals.NavigateURL(newstabid), "newsid", news.id);
                    HL_Detail1.NavigateUrl = HL_Detail.NavigateUrl;*/
                }
            }
        }
        
    }

    public bool HasPermission()
    {
        string seo = "" + Request.QueryString["sn"];
        Club club = DataMapping.GetClubBySeo(seo);
        if (Functions.CurrentCric == club.cric && (UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsSuperUser))
            return true;
        return false;
    }

    protected bool createNewsClub()
    {
        try
        {
            String seo = Request.QueryString["sn"];
            int cric = DataMapping.GetClubBySeo(seo).cric;
            if (cric == 0)
                throw new Exception("cric");

            News news = DataMapping.ListNews(cric: cric, category: "accueilclub").FirstOrDefault() != null && DataMapping.ListNews(cric: cric, category: "accueilclub").FirstOrDefault().id != null ? DataMapping.ListNews(cric: cric, category: "accueilclub").FirstOrDefault() : new News();
            if (news == null)
                throw new Exception("News null");
            if (news.id != null)
                return true;


            news.cric = cric;
            news.dt = DateTime.Now;
            news.date_end_event = DateTime.Now;
            news.date_start_event = DateTime.Now;
            news.title = tbx_titre.Text;
            news.Abstract = "";
            news.url = "";
            news.url_text = "";
            news.photo = "";
            news.category = "accueilclub";
            news.tag1 = seo;
            news.tag2 = "";
            news.visible = "O";
            news.club_type = "";
            news.adress_event = "";
            news.town_event = "";
            news.zip_event = "";
            news.ord = 10;
            news.text = "";

            DataMapping.UpdateNews_EN(news);
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return false;
        }
        return true;

    }

    /*protected void btn_editBloc_Click(object sender, EventArgs e)
    {
        //btn_editBloc.Visible = false;
        //pnl_content.Visible = false;
        //lbt_deleteBloc.Visible = false;
        pnl_add.Visible = true;
        string seo = "" + Request.QueryString["sn"];

        Club club = DataMapping.GetClubBySeo(seo);
        News news = DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault()==null? new News() : DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault();

        img.ImageUrl = news.photo;
        tbx_titre.Text = news.title;

        if (news != null)
        {
           
            switch (news.tag2)
            {
                case "BlocNoPhoto":
                    tbx_contenu.Text = news.text;
                    break;
                case null:
                    tbx_contenu.Text = news.text;
                    break;
                case "BlocVideo":
                    Video vid = new Video();
                    vid = (Video)Functions.Deserialize(news.text, vid.GetType());
                    tbx_url.Text = vid.Url;
                    tbx_contenu.Visible = false;
                    break;
                default:
                    tbx_contenu.Text = news.text;
                    pnl_image.Visible = true;
                    break;
            }

            foreach (ListItem li in rbl_type.Items)
            {
                if ("Bloc" + li.Value == news.tag2)
                {
                    li.Selected = true;
                    break;
                }

            }
            
        }
    }*/

    #region buttons

    protected void btn_validate_Click(object sender, EventArgs e)
    {
        string seo = "" + Request.QueryString["sn"];
        Club club = DataMapping.GetClubBySeo(seo);
        int cric = club.cric;
        News news = DataMapping.ListNews(cric: cric, category: "accueilclub").FirstOrDefault();
        News.Bloc bloc = new News.Bloc();
        btn_addBloc.Visible = false;
        repeat_bloc.Visible = false;
        if (btn_validate.CommandArgument!=null && btn_validate.CommandArgument!="")
        {
            foreach (News.Bloc b in DataMapping.GetNews_EN(news.id).GetListBlocs())
                if (b.id == btn_validate.CommandArgument)
                    bloc = b;
        }

        switch(rbl_type.SelectedValue)
        {
            case "NoPhoto":
                bloc.content = tbx_contenu.Text;
                bloc.content_type = "text";
                bloc.photo = "";
                break;
            case "Video":
                Video vid = new Video();
                vid.Url = tbx_url.Text;
                if (vid.Url.Contains("youtube"))
                    vid.Type = "youtube";
                else if (vid.Url.Contains("daily"))
                    vid.Type = "daily";
                else
                    vid.Type = "vimeo";
                bloc.content = Functions.Serialize(vid);
                bloc.photo = "";
                bloc.content_type = "video/" + vid.Type;
                break;
            default:
                bloc.photo = img.ImageUrl;
                bloc.content = tbx_contenu.Text;
                bloc.content_type = "photo";
                break;
        }

        bloc.type = "Bloc" + rbl_type.SelectedValue;
        bloc.title = tbx_titre.Text;
        bloc.ord = bloc.id==null? (1 + DataMapping.GetNews_EN(news.id).GetListBlocs().Count) * 10 : bloc.ord;
        bloc.visible = "O";

        DataMapping.UpdateNewsBloc(bloc, news.id);
        
        

        Response.Redirect("~/" + Request.QueryString["sn"] + "/");

    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        pnl_add.Visible = false;
        btn_addBloc.Visible = true;
        repeat_bloc.Visible = true;
    }

    protected void btn_image_Click(object sender, EventArgs e)
    {
        if (ful_image.HasFile)
        {
            ///////////////////////////////////////////////////////*Changer ici l'image*//////////////////////////////////
            string fileName = Path.GetFileName(Guid.NewGuid().ToString() + "-" + ful_image.PostedFile.FileName);
            string path = PortalSettings.HomeDirectory + "Test/";
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
        foreach (ListItem li in rbl_type.Items)
        {
            if (li.Selected && li.Value != "NoPhoto" && li.Value != "Video")
            {
                tbx_contenu.Visible = true;
                pnl_video.Visible = false;
                pnl_image.Visible = true;
                return;
            }
            if (li.Selected && li.Value == "Video")
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

   

    protected void btn_addBloc_Click(object sender, EventArgs e)
    {
        pnl_add.Visible = true;
        repeat_bloc.Visible = false;
        btn_addBloc.Visible = false;
    }

    #endregion buttons

    protected void repeat_bloc_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        string seo = "" + Request.QueryString["sn"];
        Club club = DataMapping.GetClubBySeo(seo);

        News news = DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault() == null ? new News() : DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault();
        News.Bloc bloc = (News.Bloc)e.Item.DataItem;
        List<News.Bloc> blocs = DataMapping.GetNews_EN(news.id).GetListBlocs();


        Panel pnl_display = (Panel)e.Item.FindControl("pnl_display");
        pnl_display.CssClass += " Bloc" + bloc.type;

        LinkButton btn_editBloc = (LinkButton)e.Item.FindControl("btn_editBloc");
        btn_editBloc.CommandArgument = bloc.id;

        LinkButton btn_delete = (LinkButton)e.Item.FindControl("btn_delete");

        LinkButton lbt_up = (LinkButton)e.Item.FindControl("lbt_up");
        LinkButton lbt_down = (LinkButton)e.Item.FindControl("lbt_down");

        

        if(Functions.CurrentCric!=club.cric)
        {
            btn_editBloc.Visible = false;
            btn_delete.Visible = false;
            lbt_down.Visible = false;
            lbt_up.Visible = false;

        }
        else
        {
            btn_editBloc.Visible = true;
            btn_delete.Visible = true;
            lbt_down.Visible = bloc.ord<blocs.Count*10;
            lbt_up.Visible = bloc.ord>10;
        }

        Label lbl_contenu = (Label)e.Item.FindControl("lbl_content");

        if(bloc.type=="BlocVideo")
        {
            Video vid = new Video();
            vid = (Video)Functions.Deserialize(bloc.content, vid.GetType());
            Panel pnl_contentToDisplay = (Panel)e.Item.FindControl("pnl_contentToDisplay");
            pnl_contentToDisplay.CssClass += " videoContainer";
            lbl_contenu.Text = vid.getLink();
        }

    }

    protected void repeat_bloc_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string seo = "" + Request.QueryString["sn"];
        Club club = DataMapping.GetClubBySeo(seo);
        #region editBloc
        if (e.CommandSource == (LinkButton)e.Item.FindControl("btn_editBloc"))
        {
            LinkButton btn_editBloc = (LinkButton)e.Item.FindControl("btn_editBloc");
            btn_validate.CommandArgument = btn_editBloc.CommandArgument;
            pnl_add.Visible = true;
            btn_addBloc.Visible = false;
            repeat_bloc.Visible = false;
            News.Bloc bloc = DataMapping.GetNews_EN(DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault().id).GetListBlocs().Where(x => x.id == btn_editBloc.CommandArgument).First();
            switch(bloc.type)
            {
                case "BlocNoPhoto":
                    
                    tbx_contenu.Text = bloc.content;
                    break;
                case "BlocVideo":
                    
                    Video vid = new Video();
                    vid = (Video) Functions.Deserialize(bloc.content, vid.GetType());
                    tbx_url.Text = vid.Url;
                    break;
                default:
                    img.ImageUrl = bloc.photo;
                    break;
                    
            }
            foreach(ListItem li in rbl_type.Items)
            {
                if ("Bloc" + li.Value == bloc.type)
                    li.Selected = true;
            }
            tbx_titre.Text = bloc.title;

        }
        #endregion editBloc

        else if (e.CommandSource == (LinkButton)e.Item.FindControl("btn_delete"))
        {
            LinkButton btn_delete = (LinkButton)e.Item.FindControl("btn_delete");
            News.Bloc bloc = DataMapping.GetNews_EN(DataMapping.ListNews(cric : club.cric, category : "accueilclub").FirstOrDefault().id).GetListBlocs().Where(x => x.id==btn_delete.CommandArgument).FirstOrDefault();

            if (bloc == null)
                throw new Exception("bloc null");
            if (!DataMapping.DeleteNewsBloc(bloc))
                throw new Exception("An error occured while deleting the bloc");

            Response.Redirect("~/" + club.seo + "/");
        }
        else if (e.CommandSource == (LinkButton)e.Item.FindControl("lbt_up"))
        {
        
            int cric = club.cric;
            LinkButton lbt_up = (LinkButton)e.Item.FindControl("lbt_up");
            News news = DataMapping.ListNews(cric: cric, category: "accueilclub").FirstOrDefault();
            News.Bloc bloc = DataMapping.GetNews_EN(DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault().id).GetListBlocs().Where(x => x.id == lbt_up.CommandArgument).FirstOrDefault(); ;
            News.Bloc bloc_up = null;

            foreach (News.Bloc b in DataMapping.GetNews_EN(DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault().id).GetListBlocs())
            {
                if (bloc != null && b.ord == bloc.ord - 10)
                    bloc_up = b;                
            }

            if (bloc == null || bloc_up == null)
                throw new Exception("Error can't find blocs");


            int tempord = bloc.ord;
            bloc.ord = bloc_up.ord;
            bloc_up.ord = tempord;

            DataMapping.UpdateNewsBloc(bloc, news.id);
            DataMapping.UpdateNewsBloc(bloc_up, news.id);

            Response.Redirect("~/" + club.seo + "/");
        }
        else if (e.CommandSource == (LinkButton)e.Item.FindControl("lbt_down"))
        {

            int cric = club.cric;
            LinkButton lbt_down = (LinkButton)e.Item.FindControl("lbt_down");
            News news = DataMapping.ListNews(cric: cric, category: "accueilclub").FirstOrDefault();
            News.Bloc bloc = DataMapping.GetNews_EN(DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault().id).GetListBlocs().Where(x => x.id == lbt_down.CommandArgument).FirstOrDefault(); ;
            News.Bloc bloc_up = null;

            foreach (News.Bloc b in DataMapping.GetNews_EN(DataMapping.ListNews(cric: club.cric, category: "accueilclub").FirstOrDefault().id).GetListBlocs())
            {
                if (bloc != null && b.ord == bloc.ord + 10)
                    bloc_up = b;
            }

            if (bloc == null || bloc_up == null)
                throw new Exception("Error can't find blocs");


            int tempord = bloc.ord;
            bloc.ord = bloc_up.ord;
            bloc_up.ord = tempord;

            DataMapping.UpdateNewsBloc(bloc, news.id);
            DataMapping.UpdateNewsBloc(bloc_up, news.id);

            Response.Redirect("~/" + club.seo + "/");
        }
    }
}