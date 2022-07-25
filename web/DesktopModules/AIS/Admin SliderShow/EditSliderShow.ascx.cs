
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
using DotNetNuke.Common.Utilities;
using System.Web.Script.Serialization;

public partial class DesktopModules_AIS_Club_Nouvelles_Control : PortalModuleBase
{
    protected int ModID = 0;
    protected string SliderSerialized = "";
    protected string idClub = "";
    protected string FolderImages = "";
    //protected string path = "" ;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int.TryParse("" + Request.QueryString["ModuleID"], out ModID);
            idClub = "" + Request.QueryString["clubId"];
            FolderImages = "images/" + ModID + "/" + idClub + "/";                
                
            DirectoryInfo d = new DirectoryInfo(Server.MapPath(FolderImages));
            if (!d.Exists)
            {
                d.Create();
            }

            Filesmanage_Img.PathFile = FolderImages;
            Filesmanage_Img.Txt_Button = "Ajouter un(des) fichier(s)";

            if (!IsPostBack)
            {
                hdf_Images.Value = "";
                BindingImageManager();
            }

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void BindingImageManager()
    {
        try
        {
            rpt_ManageImg.DataSource = null;
            rpt_ManageImg.DataBind();

            DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
            int SliderShowtabid = 0;
            int.TryParse("" + objModules.GetModuleSettings(ModID)["SliderShowtabid"], out SliderShowtabid);

            SliderSerialized = "" + objModules.GetModuleSettings(ModID)["SliderSerialized_" + idClub];

            List<SliderShow> lstSliderShow = new List<SliderShow>();
            if (!string.IsNullOrEmpty(SliderSerialized))
            {
                lstSliderShow = Json.Deserialize<List<SliderShow>>(SliderSerialized).OrderBy(x => x.orderDisplay).ToList();
            }

            List<string> ImgDispo = new List<string>();
            string pathFolder = HttpContext.Current.Server.MapPath("~/" + Filesmanage_Img.PathFile);
            foreach (string newPath in Directory.GetFiles(pathFolder, "*.*", SearchOption.AllDirectories))
            {
                ImgDispo.Add(Path.GetFileName(newPath));

                SliderShow ssw = lstSliderShow.Find(x => x.filenameImage == Path.GetFileName(newPath));
                if(ssw == null) //Le fichier image n'est pas dans SliderSerialized
                {
                    SliderShow sswNew = new SliderShow();
                    sswNew.filenameImage = Path.GetFileName(newPath);                    
                    sswNew.IdClub = idClub;
                    sswNew.title = "";
                    sswNew.urlText = "";
                    sswNew.used = false;
                    sswNew.orderDisplay = 1000000000;

                    lstSliderShow.Add(sswNew);
                }
            }

            #region Après avoir supprimé une image 
            List<SliderShow> lst = new List<SliderShow>();
            foreach(SliderShow ssh in lstSliderShow)
            {
                lst.Add((SliderShow)ssh.Clone());
            }

            bool Change = false;
            foreach (SliderShow ssh in lst)
            {
                string imgOK = "" + ImgDispo.Find(x => x == ssh.filenameImage);
                if(string.IsNullOrEmpty(imgOK))
                {
                    SliderShow s = lstSliderShow.Find(x => x.filenameImage == ssh.filenameImage);
                    if (s != null)
                    {
                        lstSliderShow.Remove(s);
                        Change = true;
                    }
                }
            }

            if(Change == true)
            {
                string jsonLstSliderShow = new JavaScriptSerializer().Serialize(lstSliderShow);
                objModules.UpdateModuleSetting(ModID, "SliderSerialized_" + idClub, jsonLstSliderShow);
            }
            #endregion  

            hdf_Images.Value = new JavaScriptSerializer().Serialize(lstSliderShow); 
            rpt_ManageImg.DataSource = lstSliderShow;
            rpt_ManageImg.DataBind();
            
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void rpt_ManageImg_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            SliderShow dm = (SliderShow)e.Item.DataItem;
            if (dm == null)
                return;

            LinkButton ibt_up = (LinkButton)e.Item.FindControl("ibt_up");
            ibt_up.CommandArgument = "" + e.Item.ItemIndex;
            LinkButton ibt_down = (LinkButton)e.Item.FindControl("ibt_down");
            ibt_down.CommandArgument = "" + e.Item.ItemIndex;
            Repeater rpt_Img = (Repeater)sender;
            List<SliderShow> lstslideS = (List<SliderShow>)rpt_Img.DataSource;

            if (lstslideS.Count > 1)
            {
                if (e.Item.ItemIndex == 0)
                {
                    ibt_up.Visible = false;
                    ibt_down.Visible = true;
                }
                else if (e.Item.ItemIndex == (lstslideS.Count - 1))
                {
                    ibt_up.Visible = true;
                    ibt_down.Visible = false;
                }
                else
                {
                    ibt_up.Visible = true;
                    ibt_down.Visible = true;
                }
            }

            
            RadioButtonList rbtl_visible = (RadioButtonList)e.Item.FindControl("rbtl_visible");
            if (dm.used == false)
            {
                rbtl_visible.SelectedValue = "false";
            }
            else
            {
                rbtl_visible.SelectedValue = "true";
            }

            Image img_ManageImg = (Image)e.Item.FindControl("img_ManageImg");
            //img_ManageImg.ImageUrl = "" + path + FolderImages + dm.filenameImage;
            img_ManageImg.ImageUrl = "~/" + Filesmanage_Img.PathFile + dm.filenameImage;

            TextBox tbx_title = (TextBox)e.Item.FindControl("tbx_title");
            tbx_title.Text = "" + dm.title;

            TextBox tbx_urlText = (TextBox)e.Item.FindControl("tbx_urlText");
            tbx_urlText.Text = "" + dm.urlText;

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void btn_valid_Click(object sender, EventArgs e)
    {
        try
        {
            List<SliderShow> lstSliderShow = new List<SliderShow>();
            int counter = 0;
            foreach (RepeaterItem item in rpt_ManageImg.Items)
            {
                //to get the dropdown of each line
                RadioButtonList rbtl_visible = (RadioButtonList)item.FindControl("rbtl_visible");
                if(rbtl_visible.SelectedValue == "true")
                {
                    Image img_ManageImg = (Image)item.FindControl("img_ManageImg");
                    TextBox tbx_title = (TextBox)item.FindControl("tbx_title");
                    TextBox tbx_urlText = (TextBox)item.FindControl("tbx_urlText");

                    SliderShow sswNew = new SliderShow();
                    sswNew.filenameImage = Path.GetFileName(img_ManageImg.ImageUrl);
                    sswNew.IdClub = idClub;
                    sswNew.title = "" + tbx_title.Text;
                    sswNew.urlText = "" + tbx_urlText.Text;
                    sswNew.used = true;
                    sswNew.visible = true;
                    sswNew.orderDisplay = counter;
                    sswNew.guid = Guid.NewGuid().ToString();

                    lstSliderShow.Add(sswNew);
                    counter = counter + 1;
                }
            }

            string jsonLstSliderShow = new JavaScriptSerializer().Serialize(lstSliderShow);
            DotNetNuke.Entities.Modules.ModuleController objModules = new DotNetNuke.Entities.Modules.ModuleController();
            objModules.UpdateModuleSetting(ModID, "SliderSerialized_" + idClub, jsonLstSliderShow);

            int club = 0;
            int.TryParse(idClub, out club);
            Club c = DataMapping.GetClub(club);
            if (c != null)
            {
                string url = "/" + c.seo + "/";

                Response.Redirect(url, false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected void rpt_ManageImg_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            LinkButton ibt = null;
            Repeater rpt_Img = (Repeater)source;
            List<SliderShow> lstSliderShow = Json.Deserialize<List<SliderShow>>(hdf_Images.Value);

            if (lstSliderShow != null)
            {
                if (e.CommandSource == e.Item.FindControl("ibt_up"))
                {
                    ibt = (LinkButton)e.Item.FindControl("ibt_up");
                    int indexItem = 0;
                    int.TryParse(ibt.CommandArgument, out indexItem);
                    SliderShow s = lstSliderShow[indexItem];
                    lstSliderShow.RemoveAt(indexItem);
                    lstSliderShow.Insert(indexItem - 1, s);

                }
                else if (e.CommandSource == e.Item.FindControl("ibt_down"))
                {
                    ibt = (LinkButton)e.Item.FindControl("ibt_down");
                    int indexItem = 0;
                    int.TryParse(ibt.CommandArgument, out indexItem);

                    SliderShow s = lstSliderShow[indexItem];
                    lstSliderShow.RemoveAt(indexItem);
                    lstSliderShow.Insert(indexItem + 1, s);
                }                

                rpt_ManageImg.DataSource = lstSliderShow;
                rpt_ManageImg.DataBind();

                hdf_Images.Value = new JavaScriptSerializer().Serialize(lstSliderShow);
            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }


}