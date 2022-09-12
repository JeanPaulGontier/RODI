
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
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Admin_District_Board_District_Board : PortalModuleBase
{
    static String section;
    static int rotary_year;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (IsPostBack)
            return;

        btn_modif.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);
        BindRBL(rbl_rotaryYear.SelectedIndex<0? 0 : rbl_rotaryYear.SelectedIndex);

        if (section == null || section == "")
            section = "Gouverneur";


        BindDDLSection();
        

       


        RefreshList_Grid();
    }

    public void BindRBL(int selectedIndex)
    {
        rbl_rotaryYear.Items.Clear();
        for (int i = 0; i < 3; i++)
            rbl_rotaryYear.Items.Add(new ListItem("" + (Functions.GetRotaryYear() + i)));

        rbl_rotaryYear.Items[selectedIndex].Selected = true;
    }

   



    public void BindDDLNames(String filter)
    {
        ddl_name.Items.Clear();
        List<Member> members = DataMapping.ListMembers(criterion: filter, top: "TOP 25");
        List<Member> ls = new List<Member>();
        if (members != null)
        {
            foreach (Member d in members)
            {
                if (d.nim > 0)
                { 
                    d.name = d.name + " " + d.surname;
                    //ddl_name.Items.Add(d.name + " " + d.surname);
                    ls.Add(d);
                }
            }

            ddl_name.DataValueField = "nim";
            ddl_name.DataTextField = "name";
            ddl_name.DataSource = ls;
            ddl_name.DataBind();
        }
    }

    public void BindDDLSection()
    {  
        ddl_section.Items.Clear();
        string[] sections = ("" + Settings["sections"]).Split(new char[] { '\n' },StringSplitOptions.RemoveEmptyEntries);
        foreach(string s in sections)
            ddl_section.Items.Add(s);
    }

    public void RefreshList_Grid()
    {

        section = ddl_section.SelectedValue;
        rotary_year = int.Parse(rbl_rotaryYear.SelectedValue);
        List<DRYA> list = DataMapping.GetListDRYA("section='"+section+"' and rotary_year='" + rotary_year + "'");
        hfd_count.Value = list!=null? list.Count + "" : "0";
        lbl_noMember.Visible = hfd_count.Value == "0";
        dataList_members.DataSource = list;
        dataList_members.DataBind();
        gvw_archi.DataSource = list;
        gvw_archi.DataBind();
        


    }

    protected void dataList_members_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DRYA drya = (DRYA)e.Item.DataItem;

        Member member = DataMapping.GetMemberByNim(drya.nim);
        HyperLink hlContact = (HyperLink)e.Item.FindControl("HL_Contact");
        if (member == null)
        {
            member = new Member();
            hlContact.Visible = false;
        }
        else
        {
            Image Image1 = (Image)e.Item.FindControl("Image1");
            Image1.ImageUrl = member.GetPhoto();

            PortalSettings ps = PortalController.Instance.GetCurrentPortalSettings();
            if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + member.id + "&popUp=true',false,350,850,false);";
            }
            else
            {
                hlContact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + member.id + "&popUp=true',false,350,500,false);";
            }

            if (member.IsWoman() == true)
                hlContact.Text = "La contacter";
        }
        

            
       
        
        
    }


    protected void btn_changeDate_Click(object sender, EventArgs e)
    {

        RefreshList_Grid();
    }

    protected void btn_modif_Click(object sender, EventArgs e)
    {
        section = ddl_section.SelectedValue;
        rotary_year = int.Parse(rbl_rotaryYear.SelectedValue);
        pnl_grid.Visible = true;
        pnl_display.Visible = false;
    }

    protected void gvw_archi_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editer")
        {
            pnl_edit.Visible = true;
            DRYA drya = DataMapping.GetListDRYA("section ='" + section + "' and rotary_year='" + rbl_rotaryYear.SelectedValue + "'").Where(x => x.id == int.Parse(""+e.CommandArgument)).FirstOrDefault();
            lbl_nomEdit.Text = drya.name + " " + drya.surname;
            tbx_desc.Text = drya.description;
            tbx_job.Text = drya.job;
            hfd_id.Value = ""+drya.id;
            pnl_buttons.Visible = false;
            pnl_add.Visible = false;
            gvw_archi.Visible = false;

        }
        if(e.CommandName == "Deleter")
        {
            List<DRYA> list = DataMapping.GetListDRYA("section='" + section + "' and rotary_year='" + rotary_year + "'");
            DRYA d = DataMapping.GetListDRYA("id = " + e.CommandArgument).First();
            foreach(DRYA drya in list)
            {
                if(drya.rank>d.rank)
                {
                    drya.rank--;
                    DataMapping.InsertDRYA(drya);
                }
            }
            DataMapping.DeleteDRYA(int.Parse(""+e.CommandArgument));

            RefreshList_Grid();
        }
        if(e.CommandName=="Up")
        {

            DataMapping.UpdateDRYAPosition(rotary_year, section, int.Parse("" + e.CommandArgument), true);
            
            RefreshList_Grid();
        }
        if (e.CommandName == "Down")
        {
            DataMapping.UpdateDRYAPosition(rotary_year, section, int.Parse(""+e.CommandArgument), false);

           
            RefreshList_Grid();
        }
    }

    protected void lbt_apply_Click(object sender, EventArgs e)
    {
        DRYA drya = DataMapping.GetListDRYA("section ='" + section + "' and rotary_year='" + rbl_rotaryYear.SelectedValue + "'").Where(x => x.id == int.Parse("" + hfd_id.Value)).FirstOrDefault();
        drya.job = tbx_job.Text.Trim();
        drya.description = tbx_desc.Text.Trim();
        int rank = 0;
        int.TryParse("" + tbx_rank.Text,out rank);
        rank = int.MaxValue;
        drya.rank = rank;
        DataMapping.InsertDRYA(drya);
        RefreshList_Grid();
        pnl_edit.Visible = false;
        pnl_buttons.Visible = true;
        gvw_archi.Visible = true;

    }

    protected void lbt_cancel_Click(object sender, EventArgs e)
    {
        pnl_edit.Visible = false;
        pnl_buttons.Visible = true;
        gvw_archi.Visible = true;
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        pnl_grid.Visible = false;
        pnl_buttons.Visible = true;
        pnl_display.Visible = true;
    }

    protected void btn_addDRYA_Click(object sender, EventArgs e)
    {
        pnl_add.Visible = true;
        pnl_buttons.Visible = false;
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        lblNom.Visible = true;
        ddl_name.Visible = true;
        BindDDLNames(tbx_search.Text);
        
        pnl_postSearch.Visible = true;
        btn_add.Visible = true;
        List<DRYA> list = DataMapping.GetListDRYA("section='" + section + "' and rotary_year='" + rotary_year + "'");
        tbx_rank.Text = list!=null?"" + (list.Count + 1) : "1";
    }
    

    protected void btn_add_Click(object sender, EventArgs e)
    {
        DRYA drya = new DRYA();
        List<DRYA> actuel = DataMapping.GetListDRYA("section='" + section + "' and rotary_year='" + rotary_year + "'");
        drya.section = section;
        drya.rotary_year = rotary_year;
        drya.job = tbx_job2.Text.Trim(); ;
        drya.description = tbx_desc2.Text;
        drya.rank = int.Parse(tbx_rank.Text);
        //String nomPrenom = ddl_name.SelectedValue;
        //String[] splits = nomPrenom.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //Member m = DataMapping.ListMembers().Where(x => x.name == splits[0] && x.surname == splits[1]).FirstOrDefault();

        int nimMember = 0;
        int.TryParse(ddl_name.SelectedValue, out nimMember);

        Member m = DataMapping.GetMemberByNim(nimMember);
        if (m == null)
            throw new Exception("Member null");
        drya.name = m.name;
        drya.nim = m.nim;
        drya.surname = m.surname;
        drya.cric = m.cric;
        drya.club = m.club_name;
        if(actuel!=null && drya.rank<=actuel.Count)
        {
            foreach(DRYA d in actuel)
            {
                if(d.rank>=drya.rank)
                {
                    d.rank++;
                    DataMapping.InsertDRYA(d);
                }
            }
        }

        DataMapping.InsertDRYA(drya);
        RefreshList_Grid();
        pnl_add.Visible = false;
        pnl_buttons.Visible = true;
    }

    protected void btn_back2_Click(object sender, EventArgs e)
    {
        pnl_add.Visible = false;
        pnl_buttons.Visible = true;
    }

    protected void btn_section_Click(object sender, EventArgs e)
    {
        
        RefreshList_Grid();
    }



    protected void ddl_section_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshList_Grid();
    }

    protected void rbl_rotaryYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshList_Grid();
    }





    /// <summary>
    /// Permet d'exporter le GridView en fichier Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Export_XLS_Click(object sender, EventArgs e)
    {
        List<DataTable> liste = new List<DataTable>();
        foreach (ListItem laSection in ddl_section.Items)
        {
            DataSet ds_ = DataMapping.ExecSql("SELECT nim as NIM, surname as Nom, name as Prénom, job as Poste, cric as Cric, club as 'Nom du club', [description] as 'Description', (select email from " + Const.TABLE_PREFIX + "members where nim=" + Const.TABLE_PREFIX + "drya.nim) as Email  FROM " + Const.TABLE_PREFIX+"drya    WHERE rotary_year = '"+ rbl_rotaryYear.SelectedValue + "' AND section = '"+laSection.Value+"'  order by rank");
            ds_.Tables[0].TableName = laSection.Text;
            liste.Add(ds_.Tables[0]);
        }

        DataSet ds = DataMapping.ExecSql("SELECT name as 'Nom de la commission', memberName as Membre, job as 'Poste' FROM "+Const.TABLE_PREFIX+"commission where rotary_year ='" + rbl_rotaryYear.SelectedValue + "' order by name");
        ds.Tables[0].TableName = "Commissions";
        liste.Add(ds.Tables[0]);

        Media media = DataMapping.ExportDataTablesToXLS(liste, "Organigramme District " + rbl_rotaryYear.SelectedValue + "-" + (1 + int.Parse(rbl_rotaryYear.SelectedValue)) + ".xls", Aspose.Cells.SaveFormat.Excel97To2003);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);



    }

    /// <summary>
    /// Permet d'exporter le GridView en CSV
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BT_Export_CSV_Click(object sender, EventArgs e)
    {
        List<DataTable> liste = new List<DataTable>();
        
        DataSet ds = DataMapping.ExecSql("SELECT nim as NIM, section as Section, surname as Nom, name as Prenom, job as Poste, cric as Cric, club as 'Nom du club', [description] as 'Description', (select email from " + Const.TABLE_PREFIX + "members where nim=" + Const.TABLE_PREFIX + "drya.nim) as Email  FROM " + Const.TABLE_PREFIX + "drya  WHERE rotary_year = '" + rbl_rotaryYear.SelectedValue + "' order by section, rank");
        liste.Add(ds.Tables[0]);
        
        Media media = DataMapping.ExportDataTablesToXLS(liste, "Organigramme District " + rbl_rotaryYear.SelectedValue + "-" + (1 + int.Parse(rbl_rotaryYear.SelectedValue)) + ".csv", Aspose.Cells.SaveFormat.CSV);


        List<DataTable> liste2 = new List<DataTable>();
        DataSet dsCom = DataMapping.ExecSql("SELECT name as 'Nom de la commission', memberName as Membre, job as 'Poste' FROM " + Const.TABLE_PREFIX + "commission where rotary_year ='" + rbl_rotaryYear.SelectedValue + "' order by name");
        dsCom.Tables[0].TableName = "Commissions";
        liste2.Add(dsCom.Tables[0]);

        Media media2 = DataMapping.ExportDataTablesToXLS(liste2, "Commission " + rbl_rotaryYear.SelectedValue + "-" + (1 + int.Parse(rbl_rotaryYear.SelectedValue)) + ".csv", Aspose.Cells.SaveFormat.CSV);

        


        Media media3 = new Media();
        media3.content_size = media.content_size + media2.content_size;
        media3.content = new byte[media3.content_size];

        for(int i=0; i<media3.content_size; i++)
        {
            if (i < media.content_size)
                media3.content[i] = media.content[i];
            else
                media3.content[i] = media2.content[i - media.content_size];
        }
        media3.dt = media.dt;
        media3.name = media.name;


        string guid = Guid.NewGuid().ToString();
        Session[guid] = media3;

        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    
}
 