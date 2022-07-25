
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


using AIS;
using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Common;
using Telerik.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class DesktopModules_AIS_News_Article_Control : PortalModuleBase
{
    DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
    string accessPath
    {
        get { return "" + Settings["path"]; }
    }
    string style
    {
        get { return "" + Settings["style"]; }
    }
    string print
    {
        get { return "" + Settings["print"]; }
    }

    bool HasPermission()
    {
        return UserInfo.IsSuperUser || UserInfo.IsInRole("Rédacteur courrier District");
    }

    News.Bloc theBloc;
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<News.Bloc> blocs = new List<News.Bloc>();
            if (!IsPostBack)
            {
                pnl_add.Visible = HasPermission() && Request.QueryString["edit"] != "true" && Request.QueryString["add"] != "true" && Request.QueryString["delete"] != "true";
                pnl_type.Visible = Request.QueryString["edit"] == "true" || Request.QueryString["add"] == "true";
                hlk_add.NavigateUrl = Functions.UrlAddParam(Globals.NavigateURL(), "add", "true");
                hlk_add.NavigateUrl = Functions.UrlAddParam(hlk_add.NavigateUrl, "newsid", Request.QueryString["newsid"]);
                


                string newsid = ("" + Request.QueryString["newsid"]);
                if (newsid == "")
                    Functions.Error(new Exception("Newsid inconnu : " + newsid));

                HL_Print.NavigateUrl = print+"?popUp=true&print=yes&newsid=" + newsid;

                if (("" + Request.QueryString["print"]) != "")
                {
                    Response.Write("<script>window.print();</script>");
                    P_Share.Visible = false;
                }

                News news = DataMapping.GetNews_EN(newsid);
                if (news != null)
                {
                    DotNetNuke.Framework.CDefault tp = (DotNetNuke.Framework.CDefault)this.Page;
                    tp.Title = news.title;
                    tp.Description = news.text;
                    LBL_Titre.Text = news.title;
  
                    LBL_Date.Text = news.dt.ToShortDateString();
              

                    Club c = DataMapping.GetClub(news.cric);
                    if (c != null)
                    {
                        HLK_Club.Text = c.name;
                        HLK_Club.NavigateUrl = Request.Url.AbsoluteUri.ToString().Replace(Request.Url.PathAndQuery, "") + "/" + c.seo + "/";
                    }
                    else
                    {
                        HLK_Club.Visible = false;
                    }


                    string blocid = ("" + Request.QueryString["blocid"]);
                    string add = "" + Request.QueryString["add"];
                    if (blocid != "")
                    {

                        foreach (News.Bloc b in news.GetListBlocs())
                        {
                            if (b.id == blocid)
                                blocs.Add(b);
                        }
                    }
                    else
                    {
                        blocs = news.GetListBlocs();
                    }

                    if (add == "true")
                    {
                        blocs = new List<News.Bloc>();
                        News.Bloc bloc = new News.Bloc();
                        bloc.type = "BlocPhotoTop";
                        blocs.Add(bloc);
                    }

                    

                }

                LI_Blocs.DataSource = blocs;
                LI_Blocs.DataBind();
            }
            
            
            


        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

    protected void LI_Blocs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
        try
        {
            News news = DataMapping.GetNews_EN(Request.QueryString["newsid"]);
            News.Bloc bloc = (News.Bloc)e.Item.DataItem;

            string add = "" + Request.QueryString["add"];
            if (bloc == null)
                return;
            if (Request.QueryString["nbfiles"] != "" && Request.QueryString["nbfiles"] != null)
                bloc.type = "BlocFiles";

            try { 
                var title = e.Item.FindControl("L_Title") as Literal;
                title.Text = "<h2>" + bloc.title + "</h2>";
                title.Visible = !(""+bloc.title).Trim().Equals("");
            }
            catch { }


            var panel = e.Item.FindControl("Panel1") as Panel;
            panel.CssClass = panel.CssClass + " " + bloc.type + " "+ style;
            Panel pnl_content = (Panel)e.Item.FindControl("pnl_content");
            if (bloc.type.Contains("Video"))
                pnl_content.CssClass += " videoContainer";

            var image = e.Item.FindControl("Image1") as Image;
            image.ImageUrl = bloc.photo;
            image.Visible = image.ImageUrl != "" && image.ImageUrl != Const.no_image;

            HyperLink hlk = (HyperLink)e.Item.FindControl("hlk_modif");
            hlk.NavigateUrl = Functions.UrlAddParam(Globals.NavigateURL(), "edit", "true");
            hlk.NavigateUrl = Functions.UrlAddParam(hlk.NavigateUrl, "newsid", Request.QueryString["newsid"]);
            hlk.NavigateUrl = Functions.UrlAddParam(hlk.NavigateUrl, "blocid", bloc.id);

            

            HiddenField hfd_blocid = (HiddenField)e.Item.FindControl("hfd_blocid");
            hfd_blocid.Value = bloc.id;


            LinkButton ibt_up = (LinkButton)e.Item.FindControl("ibt_up");
            LinkButton ibt_down = (LinkButton)e.Item.FindControl("ibt_down");
            if (HasPermission())
            {

                Panel pnl = (Panel)e.Item.FindControl("pnl_modif");
                pnl.Visible = true;

                var blocs = news.GetListBlocs();
                ibt_up.Visible = (blocs.Count > 0 && bloc.id != blocs[0].id) && (Request.QueryString["edit"] == "" || Request.QueryString["edit"]==null) && (Request.QueryString["add"] == "" || Request.QueryString["add"]==null) && (Request.QueryString["delete"] == "" || Request.QueryString["delete"]==null);                
                ibt_down.Visible = (blocs.Count > 0 && bloc.id != blocs[blocs.Count - 1].id)  && (Request.QueryString["edit"] == "" || Request.QueryString["edit"] == null) && (Request.QueryString["add"] == "" || Request.QueryString["add"] == null) && (Request.QueryString["delete"] == "" || Request.QueryString["delete"] == null);
                
            }

            var image2 = e.Item.FindControl("Image2") as Image;
            TextBox tbx = (TextBox)e.Item.FindControl("tbx_contenu");
            RadioButtonList rbl_type = (RadioButtonList)e.Item.FindControl("rbl_type");

            foreach (ListItem li in rbl_type.Items)
            {
                if ("Bloc" + li.Value == bloc.type)
                    li.Selected = true;
            }

            image2.ImageUrl = bloc.photo;
            image2.Visible = image2.ImageUrl != "" && image2.ImageUrl != Const.no_image;

            string edit = ("" + Request.QueryString["edit"]);

            var Panel2 = e.Item.FindControl("Panel2") as Panel;
            if (edit == "true" || add == "true")
            {
                panel.Visible = false;
                Panel2.Visible = true;
                hlk.Visible = false;
            }
            string supp = ("" + Request.QueryString["delete"]);
            if (supp == "true")
            {
                pnl_delete.Visible = true;
                hlk.Visible = false;
            }

            int cric = Functions.CurrentCric;





            

            Label contenu = (Label)e.Item.FindControl("lbl_contenu");
            Label lbl_img = (Label)e.Item.FindControl("lbl_img");
            FileUpload ful = (FileUpload)e.Item.FindControl("ful_img");
            Button btn_upload = (Button)e.Item.FindControl("btn_upload");
            Panel pnl_links = (Panel)e.Item.FindControl("pnl_links");
            Panel pnl_files = (Panel)e.Item.FindControl("pnl_files");
            Panel pnl_video = (Panel)e.Item.FindControl("pnl_video");

            


            switch (bloc.type)
            {
                case "BlocNoPhoto":
                    lbl_img.Visible = false;
                    contenu.Visible = true;
                    ful.Visible = false;
                    btn_upload.Visible = false;
                    image2.Visible = false;
                    tbx.Visible = true;
                    break;
                case "BlocPhoto":
                    lbl_img.Visible = true;
                    contenu.Visible = false;
                    ful.Visible = true;
                    btn_upload.Visible = true;
                    tbx.Visible = false;
                    image2.Visible = true;
                    break;
                case "BlocLinks":
                    lbl_img.Visible = false;
                    contenu.Visible = false;
                    ful.Visible = false;
                    btn_upload.Visible = false;
                    image2.Visible = false;
                    tbx.Visible = false;
                    pnl_links.Visible = true;
                    break;
                case "BlocFiles":
                    lbl_img.Visible = false;
                    contenu.Visible = false;
                    ful.Visible = false;
                    btn_upload.Visible = false;
                    image2.Visible = false;
                    tbx.Visible = false;
                    pnl_files.Visible = true;
                    break;
                case "BlocVideo":
                    lbl_img.Visible = false;
                    contenu.Visible = false;
                    ful.Visible = false;
                    btn_upload.Visible = false;
                    image2.Visible = false;
                    tbx.Visible = false;
                    pnl_video.Visible = true;
                    break;
                default:
                    lbl_img.Visible = true;
                    contenu.Visible = true;
                    ful.Visible = true;
                    btn_upload.Visible = true;
                    image2.Visible = true;
                    tbx.Visible = true;
                    break;
            }



            DropDownList ddl_target1 = (DropDownList)e.Item.FindControl("ddl_target1");
            DropDownList ddl_target2 = (DropDownList)e.Item.FindControl("ddl_target2");
            DropDownList ddl_target3 = (DropDownList)e.Item.FindControl("ddl_target3");
            DropDownList ddl_target4 = (DropDownList)e.Item.FindControl("ddl_target4");

            BindDDL(ddl_target1);
            BindDDL(ddl_target2);
            BindDDL(ddl_target3);
            BindDDL(ddl_target4);


            
            

            

           


            if (bloc.type == "BlocVideo" && bloc.content != null)
            {
                Label Texte1 = (Label)e.Item.FindControl("Texte1");
                Video video = new Video();
                video = (Video)Functions.Deserialize(bloc.content, video.GetType());
                Texte1.Text = video.getLink();
                TextBox tbx_urlYT = (TextBox)e.Item.FindControl("tbx_urlYT");
                tbx_urlYT.Text = video.Url;
            }

            if (bloc.type == "BlocLinks" && bloc.content != null)
            {
                Label Texte1 = (Label)e.Item.FindControl("Texte1");
                List<Link> links = new List<Link>();
                links = (List<Link>)Functions.Deserialize(bloc.content, links.GetType());
                Texte1.Text = createListLinks(links);
                for (int i = 0; i < links.Count; i++)
                {
                    TextBox tbx_link = (TextBox)e.Item.FindControl("tbx_link" + (i + 1));
                    tbx_link.Text = links.ElementAt(i).Url;
                    DropDownList ddl = (DropDownList)e.Item.FindControl("ddl_target" + (i + 1));
                    ddl.SelectedIndex = links.ElementAt(i).Target == "" ? 0 : 1;
                    TextBox tbx_texte = (TextBox)e.Item.FindControl("tbx_text" + (i + 1));
                    tbx_texte.Text = links.ElementAt(i).Texte;
                }

            }
            if (bloc.type == "BlocFiles" && bloc.content != null)
            {
                try
                {
                    Label Texte1 = (Label)e.Item.FindControl("Texte1");
                    List<AIS_File> files = new List<AIS_File>();
                    if(bloc.content != null && bloc.content!="")
                        files = (List<AIS_File>)Functions.Deserialize(bloc.content, files.GetType());

                    //if (hfd_files.Value != "")
                    //    files = (List<AIS_File>) Functions.Deserialize(hfd_files.Value, files.GetType());
                    
                    
                    
                    Panel pnl_filesUploaded = (Panel)e.Item.FindControl("pnl_filesUploaded");


                    #region Edit mode

                    if(files.Count>0)
                    {
                        if(hfd_files.Value=="")
                            hfd_files.Value = bloc.content;
                        GridView gvw_filesUploaded = (GridView)e.Item.FindControl("gvw_filesUploaded");
                        gvw_filesUploaded.DataSource = files;
                        gvw_filesUploaded.DataBind();
                    }
                    
                    

                    #endregion Edit mode

                    #region Display mode

                    Texte1.Text = createListFile(files);

                    #endregion Display mode



                    
                    btn_upload.Text = "Changer l'image";
                    
                        
                    

                }
                catch (Exception ee)
                {
                    Functions.Error(ee);
                }

            }

            LinkButton lbt_delete = (LinkButton)e.Item.FindControl("lbt_delete");
            lbt_delete.CommandArgument = bloc.id;

            String Stringscript = "<script> CKEDITOR.replace('" + tbx.ClientID +"', { uiColor: '#CCEAEE'});</script> ";
            Literal script = (Literal)e.Item.FindControl("script");
            script.Text = Stringscript;
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
        
    }

    protected void btn_deleteFiles_Click(object sender, EventArgs e)
    {
        throw new Exception("deleting");
        /*if (Request.QueryString["newsid"] == null || Request.QueryString["newsid"] == "" || Request.QueryString["blocid"] == null || Request.QueryString["blocid"] == "")
            throw new Exception("Error delete files");

        News news = DataMapping.GetNews_EN(Request.QueryString["newsid"]);
        News.Bloc bloc = new News.Bloc();
        foreach(News.Bloc b in news.GetListBlocs())
        {
            if (b.id == Request.QueryString["blocid"])
                bloc = b;
        }

        Button btn_deleteFiles = sender as Button;
        String fileToDeleteURL = btn_deleteFiles.CommandName;

        List<AIS_File> files = new List<AIS_File>();
        files = (List<AIS_File>)Functions.Deserialize(bloc.content, files.GetType());

        foreach (AIS_File file in files)
        {
            if (file.Url == fileToDeleteURL)
            {
                files.Remove(file);
                break;
            }
        }

        bloc.content = Functions.Serialize(files);
        List<News.Bloc> blocs = new List<News.Bloc>();
        blocs.Add(bloc);
        DataMapping.UpdateNewsBloc(bloc, news.id);
        
        LI_Blocs.DataSource = blocs;
        LI_Blocs.DataBind();*/
    }

    private void BindDDL(DropDownList ddl)
    {
        ddl.Items.Add("Même page");
        ddl.Items.Add("Nouvelle page");
    }



    protected void LI_Blocs_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        try
        {
            News.Bloc bloc = new News.Bloc();
            News news = DataMapping.GetNews_EN(Request.QueryString["newsid"]);
            if (Request.QueryString["blocid"] != "" && Request.QueryString["blocid"]!=null)
            {
                foreach (News.Bloc b in news.GetListBlocs())
                {
                    if (b.id == Request.QueryString["blocid"])
                        bloc = b;
                }
            }

            if (e.CommandSource == e.Item.FindControl("lbt_delete"))
            {
                LinkButton lbt_delete = (LinkButton)e.Item.FindControl("lbt_delete");
                foreach (News.Bloc b in news.GetListBlocs())
                {
                    if (b.id == lbt_delete.CommandArgument)
                        theBloc = b;
                }
                if (!DataMapping.DeleteNewsBloc(theBloc))
                    throw new Exception("Error deleting");

                string url = Functions.UrlAddParam(Globals.NavigateURL(), "newsid", Request.QueryString["newsid"]);

                Response.Redirect(url);
            }

            #region Type
                if (e.CommandSource == e.Item.FindControl("btn_type"))
            {
                RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rbl_type");
                foreach(ListItem li in rbl.Items)
                {
                    if (li.Selected)
                        bloc.type = "Bloc" + li.Value;
                }
                List<News.Bloc> blocs = new List<News.Bloc>();
                blocs.Add(bloc);
                LI_Blocs.DataSource = blocs;
                LI_Blocs.DataBind();
            }
            #endregion Type

            #region Validate
            if (e.CommandSource == e.Item.FindControl("btn_validate"))
            {
                

                Button btn = (Button)e.Item.FindControl("btn_validate");


                TextBox tbx_title = (TextBox)e.Item.FindControl("tbx_titre");
                if (tbx_title.Text != null)
                {
                    bloc.title = tbx_title.Text;
                }
                else
                    bloc.title = "";
                Panel pnl_links = (Panel)e.Item.FindControl("pnl_links");
                Panel pnl_files = (Panel)e.Item.FindControl("pnl_files");
                Panel pnl_video = (Panel)e.Item.FindControl("pnl_video");

                #region General
                if(!pnl_links.Visible && !pnl_files.Visible && !pnl_video.Visible)
                {
                    TextBox tbx_content = (TextBox)e.Item.FindControl("tbx_contenu");
                    if (tbx_content.Text != null && tbx_content.Visible)
                    {
                        bloc.content = tbx_content.Text;
                    }
                    else
                        bloc.content = "";

                    Image img = (Image)e.Item.FindControl("Image2");
                    if (img.ImageUrl != null && img.Visible)
                        bloc.photo = img.ImageUrl;
                    else
                        bloc.photo = "";
                    
                    if (bloc.content_type == null || bloc.content_type == "")
                        bloc.content_type = "text";
                    

                    
                }
                #endregion General

                #region Links
                else if(pnl_links.Visible)
                {
                    TextBox tbx_link1 = (TextBox)e.Item.FindControl("tbx_link1");
                    TextBox tbx_link2 = (TextBox)e.Item.FindControl("tbx_link2");
                    TextBox tbx_link3 = (TextBox)e.Item.FindControl("tbx_link3");
                    TextBox tbx_link4 = (TextBox)e.Item.FindControl("tbx_link4");

                    TextBox tbx_text1 = (TextBox)e.Item.FindControl("tbx_text1");
                    TextBox tbx_text2 = (TextBox)e.Item.FindControl("tbx_text2");
                    TextBox tbx_text3 = (TextBox)e.Item.FindControl("tbx_text3");
                    TextBox tbx_text4 = (TextBox)e.Item.FindControl("tbx_text4");

                    DropDownList ddl_target1 = (DropDownList)e.Item.FindControl("ddl_target1");
                    DropDownList ddl_target2 = (DropDownList)e.Item.FindControl("ddl_target2");
                    DropDownList ddl_target3 = (DropDownList)e.Item.FindControl("ddl_target3");
                    DropDownList ddl_target4 = (DropDownList)e.Item.FindControl("ddl_target4");

                    List<Link> links = new List<Link>();
                    

                    if (tbx_link1.Text != "")
                    {
                        Link link1 = new Link();
                        link1.Url = tbx_link1.Text;
                        link1.Texte = tbx_text1.Text;
                        link1.Target = (ddl_target1.SelectedIndex == 1 ? "_blank" : "");
                        links.Add(link1);
                    }
                    if (tbx_link2.Text != "")
                    {
                        Link link2 = new Link();
                        link2.Url = tbx_link2.Text;
                        link2.Texte = tbx_text2.Text;
                        link2.Target = (ddl_target2.SelectedIndex == 1 ? "_blank" : "");
                        links.Add(link2);
                    }
                    if (tbx_link3.Text != "")
                    {
                        Link link3 = new Link();
                        link3.Url = tbx_link3.Text;
                        link3.Texte = tbx_text3.Text;
                        link3.Target = (ddl_target3.SelectedIndex == 1 ? "_blank" : "");
                        links.Add(link3);
                    }
                    if (tbx_link4.Text != "")
                    {
                        Link link4 = new Link();
                        link4.Url = tbx_link4.Text;
                        link4.Texte = tbx_text4.Text;
                        link4.Target = (ddl_target4.SelectedIndex == 1 ? "_blank" : "");
                        links.Add(link4);
                    }

                    bloc.content = Functions.Serialize(links);
                    bloc.content_type = "links";
                    bloc.photo = "";

                }
                #endregion Links

                #region Video
                else if (pnl_video.Visible)
                {
                    TextBox tbx_urlYT = (TextBox)e.Item.FindControl("tbx_urlYT");
                    Video video = new Video();
                    video.Url = tbx_urlYT.Text;
                    if (video.Url.Contains("youtube"))
                        video.Type = "youtube";
                    else if (video.Url.Contains("vimeo"))
                        video.Type = "vimeo";
                    else if (video.Url.Contains("daily"))
                        video.Type = "daily";
                    else
                        video.Type = "other";
                    bloc.content = Functions.Serialize(video);
                    bloc.photo = "";
                    bloc.content_type = "video/"+video.Type;
                }
                #endregion Video

                #region Files
                else
                {
                    
                    List<AIS_File> files = new List<AIS_File>();
                    
                    if (bloc.content != null && bloc.content != "")
                        files = (List<AIS_File>) Functions.Deserialize(bloc.content, files.GetType());

                    if(hfd_files.Value!= "")
                        files = (List<AIS_File>)Functions.Deserialize(hfd_files.Value, files.GetType());

                    hfd_filesToDelete.Value = "";




                    bloc.content = Functions.Serialize(files);
                    bloc.photo = "";
                    bloc.content_type = "files";
                }
                #endregion Files

                bloc.visible = "O";
                RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rbl_type");
                foreach (ListItem li in rbl.Items)
                {
                    if (li.Selected)
                        bloc.type = "Bloc" + li.Value;
                }
                if (bloc.ord == 0)
                    if (news.GetListBlocs().Count > 0)
                        bloc.ord = news.GetListBlocs()[news.GetListBlocs().Count -1].ord+10 ;
                    else
                        bloc.ord = 10;

                if (!DataMapping.UpdateNewsBloc(bloc, Request.QueryString["newsid"]))
                    throw new Exception("Error during update");

                string url = Functions.UrlAddParam(Globals.NavigateURL(), "newsid", Request.QueryString["newsid"]);

                Response.Redirect(url);

            }
            #endregion Validate

            #region Upload Image
            if (e.CommandSource == e.Item.FindControl("btn_upload"))
            {
                FileUpload ful = (FileUpload)e.Item.FindControl("ful_img");
                if(ful.HasFile)
                {
                    
                    ///////////////////////////////////////////////////////*Changer ici l'image*//////////////////////////////////
                    string fileName = Path.GetFileName(Guid.NewGuid().ToString() +"-"+ ful.PostedFile.FileName);
                    string path = PortalSettings.HomeDirectory + accessPath +"/"+ news.tag1 + "/Images/2015-2016/";
                    if(accessPath=="")
                        path = PortalSettings.HomeDirectory + "District/Courrier du District/" + news.tag1 + "/Images/2015-2016/";
                    DirectoryInfo d = new DirectoryInfo(Server.MapPath(path));
                    if (!d.Exists)
                        d.Create();
                    ful.PostedFile.SaveAs(Server.MapPath(path) + fileName);
                    
                    TextBox tbx_title = (TextBox)e.Item.FindControl("tbx_titre");
                    if (tbx_title.Text != null) 
                    {
                        bloc.title = tbx_title.Text;
                    }
                    else
                        bloc.title = "";

                    TextBox tbx_content = (TextBox)e.Item.FindControl("tbx_contenu");
                    if (tbx_content.Text != null)
                    {
                        bloc.content = tbx_content.Text;
                    }
                    else
                        bloc.content = "";

                    RadioButtonList rbl_type = (RadioButtonList)e.Item.FindControl("rbl_type");
                    foreach (ListItem li in rbl_type.Items)
                    {
                        if (li.Selected)
                            bloc.type = "Bloc" + li.Value;
                    }

                    bloc.photo = path + fileName;
                    List<News.Bloc> blocs = new List<News.Bloc>();
                    blocs.Add(bloc);
                    LI_Blocs.DataSource = blocs;
                    LI_Blocs.DataBind();
                    Button btn_upload = (Button)e.Item.FindControl("btn_upload");
                    btn_upload.Text = "Changer l'image";
                }
                
                
            }
            #endregion Upload Image

            #region Upload Files
            if (e.CommandSource == e.Item.FindControl("btn_uploadFiles"))
            {
                FileUpload ful = (FileUpload)e.Item.FindControl("ful_files");
                if (ful.HasFile)
                {
                    
                    string fileName = Path.GetFileName(Guid.NewGuid().ToString() + "-" + ful.PostedFile.FileName);
                    string path = PortalSettings.HomeDirectory + accessPath + "/" + news.tag1 + "/Documents/2015-2016/";
                    if(accessPath=="")
                        path = PortalSettings.HomeDirectory + "District/Courrier du District/" + news.tag1 + "/Documents/2015-2016/";
                    DirectoryInfo d = new DirectoryInfo(Server.MapPath(path));
                    if (!d.Exists)
                        d.Create();
                    ful.PostedFile.SaveAs(Server.MapPath(path) + fileName);

                    TextBox tbx_title = (TextBox)e.Item.FindControl("tbx_titre");
                    if (tbx_title.Text != null)
                    {
                        bloc.title = tbx_title.Text;
                    }
                    else
                        bloc.title = "";

                    


                    RadioButtonList rbl_type = (RadioButtonList)e.Item.FindControl("rbl_type");
                    foreach (ListItem li in rbl_type.Items)
                    {
                        if (li.Selected)
                            bloc.type = "Bloc" + li.Value;
                    }

                    bloc.visible = "O";

                    List<AIS_File> files = new List<AIS_File>();

                    if (bloc.content!=null && bloc.content!="")
                    {
                        files = (List<AIS_File>) Functions.Deserialize(bloc.content, files.GetType());
                    }
                    else if (Request.QueryString["add"] != null && Request.QueryString["add"] != "" && Request.QueryString["add"] == "true")
                    {
                        files = hfd_filesToDelete.Value == "" ? new List<AIS_File>() : (List<AIS_File>) Functions.Deserialize(hfd_filesToDelete.Value, files.GetType());
                    }
                    AIS_File file = new AIS_File();
                    file.Name = ful.PostedFile.FileName;
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


                    List<News.Bloc> blocs = new List<News.Bloc>();
                    blocs.Add(bloc);
                    if (bloc.id!=null && Request.QueryString["newsid"] != null && Request.QueryString["newsid"] != "")
                        if(!DataMapping.UpdateNewsBloc(bloc, Request.QueryString["newsid"]))
                            throw new Exception ("Error during update");
                    
                    

                    LI_Blocs.DataSource = blocs;
                    LI_Blocs.DataBind();

                    /*blocs = DataMapping.GetNews_EN(news.id).GetListBlocs();

                    foreach(News.Bloc b in blocs)
                    {
                        if (b.content == bloc.content)
                            bloc = b;
                    }
                    String url = Functions.UrlAddParam(Globals.NavigateURL(), "newsid", news.id);
                    url = Functions.UrlAddParam(Globals.NavigateURL(), "blocid", bloc.id);
                    if(Request.QueryString["add"]!= null && Request.QueryString["add"]!="" && Request.QueryString["add"] =="true")
                        url = Functions.UrlAddParam(Globals.NavigateURL(), "add", "true");
                    else if (Request.QueryString["edit"] != null && Request.QueryString["edit"] != "" && Request.QueryString["edit"] == "true")
                        url = Functions.UrlAddParam(Globals.NavigateURL(), "edit", "true");

                    Response.Redirect(url);*/

                }
            }
            #endregion Upload Files

            #region Up/Down
            if (e.CommandSource == e.Item.FindControl("ibt_up"))
            {

                foreach (News.Bloc b in news.GetListBlocs())
                {
                    if (b.id == e.CommandName)
                        bloc = b;
                }
                if (bloc.ord > 10)
                {
                    News.Bloc blocOnTop = null;
                    var blocs = news.GetListBlocs();
                    foreach (News.Bloc b in blocs)
                    {
                        if (b.ord == bloc.ord - 10)
                            blocOnTop = b;
                    }
                    if (blocOnTop == null)
                        if (blocs.Count > 0)
                            blocOnTop = blocs[0];

                   
                    int tempOrd = bloc.ord;
                    if (bloc.ord == blocOnTop.ord)
                        bloc.ord = blocOnTop.ord - 10;
                    else
                        bloc.ord = blocOnTop.ord;
                    blocOnTop.ord = tempOrd;


                    if (!DataMapping.UpdateNewsBloc(bloc))
                        throw new Exception("Error update bloc");
                    if (!DataMapping.UpdateNewsBloc(blocOnTop))
                        throw new Exception("Error update bloc on top");

                }
                news = DataMapping.GetNews_EN(Request.QueryString["newsid"]);
                LI_Blocs.DataSource = news.GetListBlocs();
                LI_Blocs.DataBind();

            }
            if(e.CommandSource == e.Item.FindControl("ibt_down"))
            {
                foreach (News.Bloc b in news.GetListBlocs())
                {
                    if (b.id == e.CommandName)
                        bloc = b;
                }
                if (bloc.ord < 10*(news.GetListBlocs().Count))
                {
                    News.Bloc blocOnBot = null;
                    var blocs = news.GetListBlocs();
                    foreach (News.Bloc b in blocs)
                    {
                        if (b.ord == bloc.ord + 10)
                            blocOnBot = b;
                    }
                    if (blocOnBot == null)
                        if (blocs.Count > 0)
                            blocOnBot = blocs[blocs.Count - 1];

                    int tempOrd = bloc.ord;
                    if (bloc.ord == blocOnBot.ord)
                        bloc.ord = blocOnBot.ord + 10;
                    else
                        bloc.ord = blocOnBot.ord;                   
                    blocOnBot.ord = tempOrd;


                    if (!DataMapping.UpdateNewsBloc(bloc))
                        throw new Exception("Error update bloc");
                    if (!DataMapping.UpdateNewsBloc(blocOnBot))
                        throw new Exception("Error update bloc on bottom");
                }
                news = DataMapping.GetNews_EN(Request.QueryString["newsid"]);
                LI_Blocs.DataSource = news.GetListBlocs();
                LI_Blocs.DataBind();

            }
            #endregion Up/Down

            #region cancel
            if(e.CommandSource == e.Item.FindControl("btn_cancel"))
            {
                if(bloc.content != "" && bloc.type=="BlocFiles")
                {
                    

                    List<AIS_File> files = new List<AIS_File>();

                    if (bloc.content != null && bloc.content != "")
                        files = (List<AIS_File>)Functions.Deserialize(bloc.content, files.GetType());

                    if (hfd_files.Value != "")
                        files = (List<AIS_File>)Functions.Deserialize(hfd_files.Value, files.GetType());

                    List<AIS_File> filesToDelete = new List<AIS_File>();

                    if (hfd_filesToDelete.Value != "")
                    {
                        filesToDelete = (List<AIS_File>)Functions.Deserialize(hfd_filesToDelete.Value, filesToDelete.GetType());
                        if (filesToDelete.Count == 0)
                            throw new Exception("Zero files");
                        foreach (AIS_File fi in files)
                        {
                            bool breaker = false;
                            foreach (AIS_File f in filesToDelete)
                            {
                                if (fi.Url == f.Url)
                                {
                                    files.Remove(fi);
                                    breaker = true;
                                    break;
                                }
                            }
                            if (breaker)
                                break;
                        }



                    }






                    bloc.content = Functions.Serialize(files);
                    bloc.photo = "";
                    bloc.content_type = "files";


                    bloc.visible = "O";
                    RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rbl_type");
                    foreach (ListItem li in rbl.Items)
                    {
                        if (li.Selected)
                            bloc.type = "Bloc" + li.Value;
                    }
                    if (bloc.ord == 0)
                        bloc.ord = (news.GetListBlocs().Count + 1) * 10;

                    if (!DataMapping.UpdateNewsBloc(bloc, Request.QueryString["newsid"]))
                        throw new Exception("Error during update");
                }


                String url = Functions.UrlAddParam(Globals.NavigateURL(), "newsid", Request.QueryString["newsid"]);
                Response.Redirect(url);
            }

            #endregion cancel

           

        }
        catch (Exception ee)
        {
           
            Functions.Error(ee);
        }    
    }

    protected void btn_yes_Click(object sender, EventArgs e)
    {
        News news = DataMapping.GetNews_EN(Request.QueryString["newsid"]);
        News.Bloc bloc = null;
        List<News.Bloc> blocsAfter = new List<News.Bloc>();
        foreach (News.Bloc b in news.GetListBlocs())
        {
            if (b.id == Request.QueryString["blocid"])
                bloc = b;
            if (bloc != null && b.ord > bloc.ord)
                blocsAfter.Add(b);
        }
        if(bloc!=null)
        {
            if (!DataMapping.DeleteNewsBloc(bloc))
                throw new Exception("Can't delete bloc");
        }
        foreach(News.Bloc b in blocsAfter)
        {
            b.ord -= 10;
            if (!DataMapping.UpdateNewsBloc(b))
                throw new Exception("Error update ord");
        }
        string url = Functions.UrlAddParam(Globals.NavigateURL(), "newsid", Request.QueryString["newsid"]);
        Response.Redirect(url);

    }

    protected void btn_no_Click(object sender, EventArgs e)
    {
        string url = Functions.UrlAddParam(Globals.NavigateURL(), "newsid", Request.QueryString["newsid"]);
        Response.Redirect(url);
    }


    private String createListLinks(List<Link> links)
    {
        String result = "<div class=\"row\">";
        foreach(Link link in links)
        {
            result+="<div class=\"col-sm-"+12/links.Count+"\"><a href=\""+link.Url+"\" class=\"btn btn-primary\" "+(link.Target!=""? "target=\""+link.Target +"\">" : ">") + link.Texte + "</a></div>"; 
        }
        return result + "</div>";
    }

    private String createListFile(List<AIS_File>files)
    {
        String result = "<div><ul>";
        foreach(AIS_File file in files)
        {
            result+="<li><a href=\""+file.Url + "\" >" + file.Name + "</a></li>";
        }
        return result + "</ul></div>";
    }


   
    protected void gvw_filesUploaded_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        
        GridView gv = (GridView)sender;
        List<AIS_File> files = new List<AIS_File>();
        if (hfd_files.Value == "")
            throw new Exception("Problem : no files");
        files = (List<AIS_File>) Functions.Deserialize(hfd_files.Value, files.GetType());

        int index = (gv.PageIndex * gv.PageSize) + int.Parse(""+e.CommandArgument);
        AIS_File file = files[index];
        files.Remove(file);
        try
        {
            File.Delete(Server.MapPath(file.Url));
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
        hfd_files.Value = Functions.Serialize(files);
        gv.DataSource = files;
        gv.DataBind();


    }
}