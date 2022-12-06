
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

using DotNetNuke.Services.FileSystem;
using FileInfo = System.IO.FileInfo;
using DotNetNuke.Framework;
using System.Data;
using System.Net;

public partial class DesktopModules_AIS_Admin_News_List_Control : PortalModuleBase
{
    DotNetNuke.Entities.Modules.ModuleController objModules2 = new DotNetNuke.Entities.Modules.ModuleController();

    public bool editable
    {
        get
        {
            return (UserInfo.IsSuperUser || 
                UserInfo.IsInRole(Const.ADMIN_ROLE) || 
                UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || 
                UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT));

        }
    }
    public int cric
    {
        get
        {
            return Functions.CurrentCric;

        }
    }


    public string mode
    {
        get
        {
            return "" + Settings["mode"];

        }
    }

    public string context
    {
        get
        {
            if(ContextGuid.Value!="")
            {

            }
            else
            {
                ContextGuid.Value = Guid.NewGuid().ToString();
                Application[ContextGuid.Value + ":mode"] = mode;
                Application[ContextGuid.Value + ":cric"] = Functions.CurrentCric;

            }
            return ContextGuid.Value;
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ServicesFramework.Instance.RequestAjaxScriptSupport();
        ServicesFramework.Instance.RequestAjaxAntiForgerySupport();
    }

    /// <summary>
    /// Rafraichit le GridView et, si l'utilisateur a les droits, affiche le bouton d'ajout de nouvelles
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        

        //if ("" + Functions.CurrentCric != HF_Cric.Value)
       // {
            //HF_Cric.Value = "" + Functions.CurrentCric;
            //GridView1.PageIndex = 0;
            //Panel1.Visible = true;
            //Panel2.Visible = false;
        //}
       //RefreshGrid();

        //BT_Ajouter_News.Visible = (UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ADMIN_ROLE) || UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) || UserInfo.IsInRole(Const.ROLE_ADMIN_ROTARACT) || (DataMapping.isADG()) && Functions.CurrentCric!=0);

        if (mode == "district")
        {
            
            //lbl_TousADG.Visible = false;
            //GridView1.Visible = true;
        } 
        else if(mode == "clubs" && Functions.CurrentCric==0)
        {
            //lbl_TousADG.Visible = true;
            //GridView1.Visible = false;
            //BT_Ajouter_News.Visible = false;
        }
        else if(mode == "clubs")
        {
            //lbl_TousADG.Visible = false;
            //GridView1.Visible = true;
        }



       // p_convert.Visible = UserInfo.IsSuperUser;
        
         
    }



    protected void convert_Click(object sender, EventArgs e)
    {
        DataTable table  =  Yemon.dnn.DataMapping.ExecSql("SELECT * FROM [ais_news] where category in ('District','Clubs')");
        foreach(DataRow row in table.Rows)
        {
            int cric = (int)row["cric"];

            string url = PortalSettings.HomeDirectory;
            if(cric>0)
            {
                Club club = DataMapping.GetClub(cric);
                if (club != null)
                {
                    url += Const.CLUBS_PREFIX + Functions.GetSEO(club.seo).ToLower() + "/";
                }                    
                else
                {
                    url = "/";
                }
                    
            }
            else
            {
                url += Const.DISTRICT_PREFIX;
            }
            

            string id = "" + row["id"];
            List<Yemon.dnn.BlocksContent.Block> b = new List<Yemon.dnn.BlocksContent.Block>();

           Yemon.dnn.BlocksContent.Block block = new Yemon.dnn.BlocksContent.Block();

            String photo = ""+row["photo"];
            Yemon.dnn.BlocksContent.Block.Image image = null;
            if(photo!="")
            {
                WebClient webClient = new WebClient();
                try
                {

                
                    byte[] arr = webClient.DownloadData("https://www.rotary-district1770.org"+url+"/images/" + photo);

                    string contentEncoding = webClient.ResponseHeaders["Content-Encoding"];
                    string contentType = webClient.ResponseHeaders["Content-Type"];

                    image = new Yemon.dnn.BlocksContent.Block.Image();
                    image.Content = arr;
                    image.ContentSize = arr.Length;
                    image.Date = DateTime.Now;
                    image.Filename = photo;
                    image.MimeType = contentType;
                    image.Name = "";

                    string guid = Yemon.dnn.Helpers.SetMedia(image, "" + UserId,folder:"photo");
                    image.GUID = guid;
                }
                catch
                {

                }

            }


            block.Content = new Yemon.dnn.BlocksContent.Block.ImageText()
            {
                Html = "<pre>" + row["text"] + "</pre>",
                Position = "H",
                Title = "",
                Image = image
                
                //Image = ""+row["photo"]

            };
            block.Guid = Guid.NewGuid();
            block.Type = "ImageText";
            

            b.Add(block);


            String file = "" + row["url"];
            String title = "" + row["url_text"];

            Yemon.dnn.BlocksContent.Block.File fi = null;
            if (file != "")
            {
                block = new Yemon.dnn.BlocksContent.Block();

                WebClient webClient = new WebClient();
                try
                {


                    byte[] arr = webClient.DownloadData("https://www.rotary-district1770.org"+url+"/documents/" + file);

                    string contentEncoding = webClient.ResponseHeaders["Content-Encoding"];
                    string contentType = webClient.ResponseHeaders["Content-Type"];

                    fi = new Yemon.dnn.BlocksContent.Block.File();
                    fi.Content = arr;
                    fi.ContentSize = arr.Length;
                    fi.Date = DateTime.Now;
                    fi.Filename = file;
                    fi.MimeType = contentType;
                    fi.Name = title;

                    string guid = Yemon.dnn.Helpers.SetMedia(fi, "" + UserId, folder: "document");
                    fi.GUID = guid;
                }
                catch
                {

                }

                block.Content = new Yemon.dnn.BlocksContent.Block.FileCollection()
                {
                    Files= new List<Yemon.dnn.BlocksContent.Block.File>() { fi },
                    Title = "",
                    

                    //Image = ""+row["photo"]

                };
                block.Guid = Guid.NewGuid();
                block.Type = "FileCollection";


                b.Add(block);
            }

            string blocks = Yemon.dnn.Functions.Serialize(b);

            Yemon.dnn.Helpers.SetItem("blockscontent:" + id, "" +blocks, "" + UserId, keephistory: false, portalid: PortalId);

            if(image!=null)
            {
                DataMapping.ExecSql("update ais_news set photo='" + image.GUID + "' where id='" + id + "'");
            }

        }
    }
}