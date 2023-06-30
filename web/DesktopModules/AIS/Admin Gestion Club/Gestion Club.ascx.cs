
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
using AIS;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DotNetNuke.Common;
using DotNetNuke.Security.Roles;
using System.Collections;
using System.Globalization;
using Dnn.PersonaBar.Prompt.Components.Commands.Client;

public partial class DesktopModules_AIS_Admin_Gestion_Club_Gestion_Club : PortalModuleBase
{
    RoleController roleController = new RoleController();

    public string GetPresentation(string seo_mode)
    {
        switch(seo_mode)
        {
            case "m":
                return "Site district";

            case "d":
                return "Site district avec domaine";

            default:
                return "Carte de visite";
           
        }
    }

    public string GetRoleName(string id)
    {
        string result = "non défini";
        if (String.IsNullOrEmpty(id))
            return result;
        int roleid = 0;
        int.TryParse(id,out roleid);
        if (roleid == 0)
            return result;
        return roleController.GetRoleById(PortalId, roleid).RoleName;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Club> clubs = DataMapping.ListClubs(sort: "name ASC",max: int.MaxValue);
        gvw_clubs.DataSource = clubs;
        gvw_clubs.DataBind();

        

        int nbrotaract = clubs.Where(x => x.club_type=="rotaract").Count();
        int nbrotary = clubs.Where(x => x.club_type == "rotary").Count();
        int nbinteract = clubs.Where(x => x.club_type == "interact").Count();
        lbl_nb.Text = "Nombre de clubs Rotary : " + nbrotary + ", Rotaract : " + nbrotaract + ", Interact : " + nbinteract;
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        pnl_edit.Visible = true;
        pnl_display.Visible = false;

        tbx_seo.Text = "";
        tbx_adr1.Text = "";
        tbx_adr2.Text = ""; 
        tbx_adr3.Text = "";
        tbx_email.Text = "";
        tbx_fax.Text = "";
        tbx_meetAdr1.Text = "";
        tbx_meetAdr2.Text = "";
        tbx_meetings.Text = "";
        tbx_meetTown.Text = "";
        tbx_meetZip.Text = "";
        tbx_tel.Text = "";
        tbx_text.Text = "";
        tbx_town.Text = "";
        tbx_web.Text = "";
        tbx_zip.Text = "";
        tbx_name.Text = "";
        img_fanion.ImageUrl = "";
        hfd_cric.Text = "";
        RB_Type_Club.SelectedIndex = 0;
        rbl_type.SelectedIndex = -1;
        tbx_nb_free_of_charge.Text = "0";
        BindRoleList();
        //btn_addClub.Text = "Ajouter le club rotaract";
        btn_addClub.Text = "Ajouter un club";

    }


    void BindRoleList(string selected="")
    {
        var rc = new RoleController();
        IList<RoleInfo> roles = rc.GetRoles(PortalId);
        DDL_Role.Items.Clear();
        DDL_Role.Items.Add(new ListItem("--- aucun ---", ""));
        DDL_Role.SelectedIndex = 0;
        foreach (RoleInfo role in roles)
        {
           var li = new ListItem(role.RoleName, role.RoleID.ToString(CultureInfo.InvariantCulture));
            if(role.RoleName.StartsWith("ADG"))
            {
                DDL_Role.Items.Add(li);
                if (selected.Equals(role.RoleID.ToString(CultureInfo.InvariantCulture)))
                    DDL_Role.SelectedIndex = DDL_Role.Items.Count - 1;

            }
        }
    }

    protected void gvw_clubs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Club club = DataMapping.GetClub(int.Parse("" + e.CommandArgument));


        hf_last_cric.Value = (e.CommandArgument + "");
        hfd_cric.Text = (e.CommandArgument + "");
        pnl_edit.Visible = true;
        pnl_display.Visible = false;

        tbx_seo.Text = club.seo;
        tbx_adr1.Text = club.adress_1;
        tbx_adr2.Text = club.adress_2;
        tbx_adr3.Text = club.adress_3;
        tbx_email.Text = club.email;
        tbx_fax.Text = club.fax;
        tbx_meetAdr1.Text = club.meeting_adr1;
        tbx_meetAdr2.Text = club.meeting_adr2;
        tbx_meetings.Text = club.meetings;
        tbx_meetTown.Text = club.meeting_town;
        tbx_meetZip.Text = club.meeting_zip;
        tbx_tel.Text = club.telephone;
        tbx_text.Text = club.text;
        tbx_town.Text = club.town;
        tbx_web.Text = club.web;
        tbx_zip.Text = club.zip;
        img_fanion.ImageUrl = club.GetPennant();
        hfd_filename.Value = club.pennant;
        RB_Type_Club.SelectedValue = "" + club.club_type;
        SEO_MODE.SelectedValue = "" + club.seo_mode;
        tbx_domaine.Text = club.domaine;
        tbx_name.Text = club.name;
        btn_delete.CommandArgument =""+ club.cric;
        tbx_nb_free_of_charge.Text = ("" + club.nb_free_of_charge).Replace(",",".");
        if (!String.IsNullOrEmpty(club.payment_method))
            try
            {
                rbl_type.SelectedValue = club.payment_method;
            }
            catch { }
            
        btn_delete.Visible = true;

        tbx_seo.Enabled = false;

        tbx_adr1.Enabled = true;
        tbx_adr2.Enabled = true;
        tbx_adr3.Enabled = true;
        tbx_email.Enabled = true;
        tbx_fax.Enabled = true;
        tbx_meetAdr1.Enabled = true;
        tbx_meetAdr2.Enabled = true;

        tbx_meetTown.Enabled = true;
        tbx_meetZip.Enabled = true;
        tbx_tel.Enabled = true;

        tbx_town.Enabled = true;
        tbx_web.Enabled = true;
        tbx_zip.Enabled = true;

        BindRoleList(club.roles);
     

        btn_addClub.Text = "Modifier le club";

    }

    protected void btn_addClub_Click(object sender, EventArgs e)
    {
        Club club = new Club();

        int cric = 0;
        int.TryParse(hfd_cric.Text,out cric);
        if (cric == 0)
            return;
        club.seo = tbx_seo.Text;
        club.cric = cric;
        club.adress_1 = tbx_adr1.Text;
        club.adress_2 =  tbx_adr2.Text;
        club.adress_3 =  tbx_adr3.Text;
        club.email =  tbx_email.Text;
        club.fax = tbx_fax.Text;
        club.meeting_adr1 =  tbx_meetAdr1.Text;
        club.meeting_adr2 = tbx_meetAdr2.Text;
        club.meetings =  tbx_meetings.Text;
        club.meeting_town =  tbx_meetTown.Text;
        club.meeting_zip =  tbx_meetZip.Text;
        club.telephone = tbx_tel.Text;
        club.text = tbx_text.Text;
        club.town =  tbx_town.Text;
        club.web = tbx_web.Text;
        club.zip  = tbx_zip.Text;
        club.pennant = hfd_filename.Value;
        club.district_id = Const.DISTRICT_ID;
        club.club_type = ""+RB_Type_Club.SelectedValue;
        club.name = tbx_name.Text.ToUpper(); ;
        club.roles = DDL_Role.SelectedValue;
        club.seo_mode = "" + SEO_MODE.SelectedValue;
        club.domaine = tbx_domaine.Text;
        
        double nbfoc = 0;
        double.TryParse(tbx_nb_free_of_charge.Text.Trim().Replace(".",","), out nbfoc);
        club.nb_free_of_charge = nbfoc;
        if (rbl_type.SelectedIndex > -1)
            club.payment_method = rbl_type.Items[rbl_type.SelectedIndex].Value;

        if (btn_addClub.Text != "Modifier le club")
        {
            
            club.seo = tbx_name.Text.ToLower().Replace(' ', '-');
            DataMapping.InsertClub(club);
        }          
        else
        {
            int last_cric = 0;
            int.TryParse("" + hf_last_cric.Value, out last_cric);
            DataMapping.UpdateClub(club,last_cric);
        }

        Functions.UpdateSEOClubs(HttpContext.Current);

        Response.Redirect(Globals.NavigateURL());

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        pnl_edit.Visible = false;
        pnl_display.Visible = true;
    }

    protected void btn_img_Click(object sender, EventArgs e)
    {
        if (ful_img.HasFile)
        {
            
            Club club = new Club();
            if (hfd_cric.Text != "")
                club = DataMapping.GetClub(int.Parse(hfd_cric.Text));
            string fileName;
            if (club.cric!=0)
                fileName = Path.GetFileName(club.club_type != "rotaract"? "fanion_"+ club.cric : "fanion_"+tbx_name.Text );
            else
                fileName = Path.GetFileName("fanion_" + tbx_name.Text);
            fileName += ".png";
            string path = PortalSettings.HomeDirectory + Const.CLUBS_PREFIX + Const.PENNANT_PREFIX;
            DirectoryInfo d = new DirectoryInfo(Server.MapPath(path));
            if (!d.Exists)
                d.Create();
            ful_img.PostedFile.SaveAs(Server.MapPath(path) + fileName);
            hfd_filename.Value = fileName;
            club.pennant = fileName;
            img_fanion.ImageUrl = club.GetPennant();
            
        }
    }






    protected void btn_delete_Click(object sender, EventArgs e)
    {
        DataMapping.DeleteClub(int.Parse(btn_delete.CommandArgument));
        Response.Redirect(Globals.NavigateURL());
    }

   

  
}