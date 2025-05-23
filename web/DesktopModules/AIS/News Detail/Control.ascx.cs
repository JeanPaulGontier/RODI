﻿
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
using AIS;

using System.Text;
using DotNetNuke.Entities.Tabs;
using Aspose.Words;
using System.Web.UI.HtmlControls;

public partial class DesktopModules_AIS_News_Detail_Control : PortalModuleBase
{
    News news;
   

    public string HOST 
    {
        get
        {
            return Yemon.dnn.Functions.GetHostUrl(HttpContext.Current.Request);
        }
    }

    public string news_photo 
    {
        get
        {
            if (news == null)
                return "";
                return news.GetPhoto();
        }
    }
    public string page_title
    {
        get
        {
            if (news== null)
                return "";
            return HttpUtility.HtmlEncode(news.title);
        }
    }
    public string news_dt
    {
        get
        {
            if (news == null)
                return "";
            return news.dt.ToString();
        }
    }
    public string libpath
    {
        get
        {
            return TabController.CurrentPage.SkinPath + "echoppe/"; 
        }
    }

    public string schemacontext
    {
        get
        {
            return "context";
        }
    }
    public string schemaid
    {
        get
        {
            return "id";
        }
    }
    public string schematype
    {
        get
        {
            return "type";
        }
    }
    public string href_mail
    {
        get
        {
            if (news == null)
                return "";
            return "mailto:?subject="+Uri.EscapeUriString(page_title)+"&body="+(Uri.EscapeUriString(HOST + Request.RawUrl));
        }

    }
    public string href_fb
    {
        get
        {
            if (news == null)
                return "";
            return "https://www.facebook.com/sharer/sharer.php?u="+HttpUtility.UrlEncode(HOST+Request.RawUrl)+"&display=popup";
        }
    }
    public string href_twitter
    {
        get
        {
            if (news == null)
                return "";
            return "https://twitter.com/intent/tweet?url="+HttpUtility.UrlEncode(HOST+Request.RawUrl)+"&text="+ page_title +"&display=popup";
        }
    }
    public string href_linkedin
    {
        get
        {
            if (news == null)
                return "";
            return "https://www.linkedin.com/shareArticle?mini=true&url="+HttpUtility.UrlEncode(HOST+Request.RawUrl);
        }
    }
    public string href_whatsapp
    {
        get
        {
            if (news == null)
                return "";
            return "whatsapp://send?text="+Uri.EscapeUriString(news.title+Environment.NewLine+HOST+Request.RawUrl );
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string newsid = ("" + Request.QueryString["newsid"]);
        if (newsid == "")
            Functions.Error(new Exception("Newsid inconnu : " + newsid));

        news = DataMapping.GetNews(newsid);
       
        if (news != null)
        {
            bool visible = false;
            if (news.visible == Const.YES)
            {
                visible = true;
            }
            if (news.visible == "D" && UserInfo.UserID > 0)
            {
                visible = true;
            }
            if (news.visible == "M" && news.cric > 0 && UserInfo.UserID > 0)
            {
                var member = DataMapping.GetMemberByUserID(UserInfo.UserID);
                if (member != null && member.cric == news.cric)
                {
                    visible = true;
                }
            }
            if (UserInfo.IsAdmin || UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT))
            {
                visible = true;
            }
            if (!visible)
            {
                Response.Redirect("/connexion?returnurl=" + HttpUtility.UrlEncode(Request.RawUrl), true);
                return;
            }

            LBL_Titre.Text = news.title;

            List<Block> blocks = new List<Block>();
            try
            {
                string sblocks = "" + Yemon.dnn.Helpers.GetItem("blockscontent:" + news.id);
                if (sblocks != "")
                {
                    blocks = (List<Block>)Yemon.dnn.Functions.Deserialize(sblocks, typeof(List<Block>));
                }

            }
            catch
            {

            }
            StringBuilder sb = new StringBuilder();

            if (blocks.Count == 0)
            {
                if (news.photo != "")
                {
                    sb.Append("<div>");
                    sb.Append("<img src='/DesktopModules/BlocksContent/API/Blocks/getMedia?guid=" + news.photo + "' title = '" + news.title + "' />");
                    sb.Append("</div>");

                }
                else
                {
                    sb.Append("<div>Il n'y a pas de détail...</div>");
                }
            }
            else
            {
              
              
                    foreach (Block block in blocks)
                    {
                        switch (block.Type)
                        {
                            case "ImageText":
                                Block.ImageText p = (Block.ImageText)Yemon.dnn.Functions.Deserialize("" + block.Content, typeof(Block.ImageText));
                                switch (p.Position)
                                {
                                    case "G":
                                        sb.Append("<div class='row'>");
                                        if (p.Title != null)
                                            sb.Append("<h2 class='col-sm-12'>" + p.Title + "</h2>");
                                        if (p.Image != null)
                                        {
                                            sb.Append("<div class='col-sm-6'>");
                                            sb.Append(" <img src='/DesktopModules/BlocksContent/API/Blocks/getMedia?guid=" + p.Image.GUID + "' title='" + p.Image.Name + "' />");
                                            sb.Append("</div>");
                                        }
                                        if (p.Html != null)
                                            sb.Append("<div class='col-sm-6'>" + p.Html + "</div>");
                                        sb.Append("</div>");
                                        break;
                                    case "D":
                                        sb.Append("<div class='row'>");
                                        if (p.Title != null)
                                            sb.Append("<h2 class='col-sm-12'>" + p.Title + "</h2>");
                                        if (p.Html != null)
                                            sb.Append("<div class='col-sm-6'>" + p.Html + "</div>");
                                        if (p.Image != null)
                                        {
                                            sb.Append("<div class='col-sm-6'>");
                                            sb.Append(" <img src='/DesktopModules/BlocksContent/API/Blocks/getMedia?guid=" + p.Image.GUID + "' title='" + p.Image.Name + "' />");
                                            sb.Append("</div>");
                                        }
                                        sb.Append("</div>");
                                        break;
                                    case "B":
                                        sb.Append("<div>");
                                        if (p.Title != null)
                                            sb.Append("<h2>" + p.Title + "</h2>");
                                        if (p.Html != null)
                                            sb.Append("<div>" + p.Html + "</div>");
                                        if (p.Image != null)
                                        {
                                            sb.Append("<div>");
                                            sb.Append(" <img src='/DesktopModules/BlocksContent/API/Blocks/getMedia?guid=" + p.Image.GUID + "' title='" + p.Image.Name + "' />");
                                            sb.Append("</div>");
                                        }

                                        sb.Append("</div>");
                                        break;
                                    default:
                                        sb.Append("<div>");
                                        if (p.Title != null)
                                            sb.Append("<h2>" + p.Title + "</h2>");
                                        if (p.Image != null)
                                        {
                                            sb.Append("<div>");
                                            sb.Append(" <img src='/DesktopModules/BlocksContent/API/Blocks/getMedia?guid=" + p.Image.GUID + "' title='" + p.Image.Name + "' />");
                                            sb.Append("</div>");
                                        }
                                        if (p.Html != null)
                                            sb.Append("<div>" + p.Html + "</div>");
                                        sb.Append("</div>");
                                        break;
                                }
                                break;
                            case "FileCollection":
                                sb.Append("<div>");
                                Block.FileCollection fc = (Block.FileCollection)Yemon.dnn.Functions.Deserialize("" + block.Content, typeof(Block.FileCollection));
                                if (fc.Title != null)
                                {
                                    sb.Append("<h2>" + fc.Title + "</h2>");
                                }
                                if (fc.Files.Count > 0)
                                {
                                    sb.Append("<ul>");
                                    foreach (var f in fc.Files)
                                    {
                                        sb.Append("<li><a href='/DesktopModules/BlocksContent/API/Blocks/getMedia?guid=" + f.GUID + "' class='btn btn-link'>" + f.Name + "</a></li>");
                                    }
                                    sb.Append("</ul>");
                                }
                                sb.Append("</div>");
                                break;
                            case "ImageCollection":
                                sb.Append("<div>");
                                Block.ImageCollection ic = (Block.ImageCollection)Yemon.dnn.Functions.Deserialize("" + block.Content, typeof(Block.ImageCollection));
                                if (ic.Title != null)
                                {
                                    sb.Append("<h2>" + ic.Title + "</h2>");
                                }
                                if (ic.Images.Count > 0)
                                {
                                    foreach (var i in ic.Images)
                                    {
                                        sb.Append("<span>");
                                        sb.Append("<img src='/DesktopModules/BlocksContent/API/Blocks/getMedia?guid=" + i.GUID + "' width='100%' title='" + i.Name + "' />");
                                        sb.Append("</span>");
                                    }
                                }
                                sb.Append("</div>");
                                break;
                            case "Raw":
                                Block.Raw r = (Block.Raw)Yemon.dnn.Functions.Deserialize("" + block.Content, typeof(Block.Raw));
                                sb.Append("<div>" + r.Html + "</div>");
                                break;
                            case "Video":
                                Block.Video v = (Block.Video)Yemon.dnn.Functions.Deserialize("" + block.Content, typeof(Block.Video));
                                if (v.Title != null)
                                {
                                    sb.Append("<h2>" + v.Title + "</h2>");
                                }
                                sb.Append("<div id='container" + block.Guid + "'>");
                                sb.Append("    <iframe width='100%' id='video" + block.Guid + "' class='video' src='" + v.Url + "' allowfullscreen=''></iframe>");
                                sb.Append("</div>");
                                sb.Append("<script>");
                                sb.Append(
                                    "if (!resize) {" +
                                    "var resize = [];" +
                                    "}" +
                                        "resize['"+block.Guid+"'] = function() {" +


                                    "var ratio = 16 / 9;" +
                                    "const videoIFrame = document.getElementById('video"+block.Guid+"');" +
                                    "const videoContainer = document.getElementById('container"+block.Guid+"');" +
                                    "var width = Math.min(window.innerWidth, videoIFrame.offsetWidth);" +
                                    "videoIFrame.style.height = Math.ceil(width / ratio) + 'px';" +
                                    "videoContainer.style.height = (width / ratio) + 'px';" +
                                    "};$(window).resize(resize['" + block.Guid+"']);" +
                                    "$(document).ready(function () {" +
                                        "resize['"+block.Guid+"']();" +
                                    "});" +
                                    "</script>");
                                break;
                        }
                    }
                   
                }
                LBL_Detail.Text = sb.ToString();
                LBL_Date.Text = news.dt.ToShortDateString();
                //Image1.ImageUrl = news.GetPhoto();
                //Image1.Visible = Image1.ImageUrl != "";
                //HL_Url.NavigateUrl = news.GetUrl();
                //HL_Url.Text = news.url_text;
                //HL_Url.Visible = news.url.Trim() != "";
                //LBL_Url.Visible = HL_Url.Visible;

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




            HtmlMeta OpenGraphBrand = new HtmlMeta();
            OpenGraphBrand.Attributes.Add("property", "og:type");
            OpenGraphBrand.Content = "article";
            Page.Header.Controls.Add(OpenGraphBrand);
            OpenGraphBrand = new HtmlMeta();
            OpenGraphBrand.Attributes.Add("property", "og:url");
            OpenGraphBrand.Content = HOST + Request.RawUrl;
            Page.Header.Controls.Add(OpenGraphBrand);
            OpenGraphBrand = new HtmlMeta();
            OpenGraphBrand.Attributes.Add("property", "og:title");
            OpenGraphBrand.Content = page_title;
            Page.Header.Controls.Add(OpenGraphBrand);
            OpenGraphBrand = new HtmlMeta();
            OpenGraphBrand.Attributes.Add("property", "og:image");
            OpenGraphBrand.Content = HOST + news.GetPhoto();
            Page.Header.Controls.Add(OpenGraphBrand);
            OpenGraphBrand = new HtmlMeta();
            OpenGraphBrand.Attributes.Add("property", "og:description");
            OpenGraphBrand.Content = HOST + Request.RawUrl;
            Page.Header.Controls.Add(OpenGraphBrand);
        }
        }
    }
