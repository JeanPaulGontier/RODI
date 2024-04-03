
#region Copyrights

// RODI - https://www.rodi-platform.org
// Copyright (c) 2012-2024
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

using AIS;
using Aspose.Cells;
using Dnn.PersonaBar.Roles.Components;
using Dnn.PersonaBar.Users.Components;
using Dnn.PersonaBar.Users.Services;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using FiftyOne.Foundation.Mobile.Detection.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Admin_District_Board_District_Board : PortalModuleBase
{
    static String section;
    static int rotary_year;

    protected void Page_Load(object sender, EventArgs e)
    {

        BT_Affectations_Roles.Text = "MAJ Rôles année rotarienne " + Functions.GetRotaryYear() + "-" + (Functions.GetRotaryYear() + 1);

        P_Import.Visible = false;
        TXT_Import.Text = "";
        P_Import.CssClass = "alert alert-success";

        if (IsPostBack)
        {
            if (FL_Import.PostedFile != null)
            {

                if(FL_Import.PostedFile.ContentType!= "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    TXT_Import.Text = "Le fichier doit être au format Excel (.XLSX)";
                    P_Import.CssClass = "alert alert-danger";
                }
                else
                {
                    try { 
                        Workbook xls = new Workbook(FL_Import.FileContent);
                        Worksheet worksheet = xls.Worksheets[0];
                        string colsnames = "" + worksheet.Cells["A1"].Value + ":" +
                                worksheet.Cells["B1"].Value + ":" +
                                worksheet.Cells["C1"].Value + ":" +
                                worksheet.Cells["D1"].Value + ":" +
                                worksheet.Cells["E1"].Value + ":" +
                                worksheet.Cells["F1"].Value + ":" +
                                worksheet.Cells["G1"].Value + ":" +
                                worksheet.Cells["H1"].Value + ":" +
                                worksheet.Cells["I1"].Value + ":" +
                                worksheet.Cells["J1"].Value;

                        if (colsnames != "Section:Nom:Prénom:Poste:Role:Description:NIM:Cric:Nom du club:Email")
                            throw new Exception("Le format de fichier n'est pas correct, veuillez utiliser le même format que le fichier export");

                        int year = int.Parse(rbl_rotaryYear.SelectedValue);


               
                        // nettoyage des roles de sections et des sous roles des membres de la section avant effacement de la liste des membres
                        // seulement si l'année d'import est l'année courante
                        string[] sections = ("" + Settings["sections"]).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        if (year==Functions.GetRotaryYear())
                        {
                            RoleController roleController = new RoleController();
                            List<string> subroles = new List<string>();
                            foreach (string s in sections)
                            {
                                RoleInfo roleInfo = roleController.GetRoleByName(PortalId, s);
                                if (roleInfo != null)
                                {
                                    var users = roleController.GetUsersByRole(PortalId, roleInfo.RoleName);
                                    foreach (var user in users)
                                    {
                                        RoleController.DeleteUserRole(user, roleInfo, PortalSettings, false);
                                    }
                                }
                            
                                var dryas = DataMapping.GetListDRYA(Functions.GetRotaryYear(), s);
                                foreach(var d in dryas)
                                {
                                    if(!String.IsNullOrEmpty(d.role) && !subroles.Contains(d.role))
                                    {
                                        roleInfo = roleController.GetRoleByName(PortalId, d.role);
                                        if (roleInfo != null)
                                        {
                                            subroles.Add(roleInfo.RoleName);
                                            var users= roleController.GetUsersByRole(PortalId, roleInfo.RoleName);
                                            foreach(var user in users)
                                            {
                                                RoleController.DeleteUserRole(user, roleInfo, PortalSettings, false);
                                            }
                                        }
                                    }
                                
                                }
                            }
                        }
                        Yemon.dnn.DataMapping.ExecSqlNonQuery("DELETE FROM " + Const.TABLE_PREFIX + "drya WHERE rotary_year='" + year + "'");



                        StringBuilder sb = new StringBuilder();
                        int row = 1;
                        TXT_Import.Text += "<br/>";
                        while (!String.IsNullOrEmpty(""+worksheet.Cells[row,0].Value))
                        {
                            DRYA drya = new DRYA();
                            drya.section = "" + worksheet.Cells[row, 0].Value;
                            drya.surname = "" + worksheet.Cells[row, 1].Value;
                            drya.name = "" + worksheet.Cells[row, 2].Value;
                            drya.job = "" + worksheet.Cells[row, 3].Value;
                            drya.role = "" + worksheet.Cells[row, 4].Value;
                            drya.description = "" + worksheet.Cells[row, 5].Value;
                            drya.nim = int.Parse("0" + worksheet.Cells[row, 6].Value);
                            drya.cric = int.Parse("0" + worksheet.Cells[row, 7].Value);
                            drya.club = "" + worksheet.Cells[row, 8].Value;
                            drya.rank = row;
                            drya.rotary_year = year;

                            if (drya.nim == 0)
                            {
                                SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE name=@name AND surname=@surname");
                                sql.Parameters.AddWithValue("name", drya.name);
                                sql.Parameters.AddWithValue("surname", drya.surname);
                                Member member = Yemon.dnn.DataMapping.ExecSqlFirst<Member>(sql);
                                if(member!= null)
                                {
                                    drya.nim=member.nim;
                                    drya.cric=member.cric;
                                    drya.club = member.club_name;                                    
                                }

                            }

                            if (DataMapping.InsertDRYA(drya,false)==0)
                            {
                                sb.Append("ERREUR : " + worksheet.Cells[row, 0].Value + " : " + worksheet.Cells[row, 1].Value + " : " + worksheet.Cells[row, 2].Value + "<br/>");                               
                            }
                            
                            
                            row++;
                        }
                        if(year==Functions.GetRotaryYear())
                        {
                            foreach (string s in sections)
                            {
                                string r = DataMapping.UpdateDRYARoles(s);
                                if(r.Length>0)
                                    sb.Append(r.Replace(Environment.NewLine,"<br/>") + "<br/>");
                            }
                        }

                        if (sb.Length > 0)
                        {
                            TXT_Import.Text = "L'import s'est déroulé pour " + (row - 1) + " membres avec quelques erreurs :<br/>"+sb.ToString();
                            P_Import.CssClass = "alert alert-warning";
                        }
                        else
                        {
                            TXT_Import.Text = "L'import s'est correctement déroulé pour " + (row - 1) + " membres";
                        }


                    }
                    catch (Exception ee)
                    {
                        TXT_Import.Text = "Erreur lors du traitement de l'import : "+ee.Message ;
                        P_Import.CssClass = "alert alert-danger";
                    }

                }
                P_Import.Visible = true;
            }
            else
            {
                return;
            }

          
            
        }
            

        btn_modif.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);
        BindRBL(rbl_rotaryYear.SelectedIndex<0? 0 : rbl_rotaryYear.SelectedIndex);

        if (section == null || section == "")
            section = "éGouverneur";


        BindDDLSection();
   

        RefreshList_Grid();
    }

    public void BindRBL(int selectedIndex)
    {
        rbl_rotaryYear.Items.Clear();
        for (int i = 0; i < 3; i++)
            rbl_rotaryYear.Items.Add(new ListItem(""+ (Functions.GetRotaryYear() + i)+"-"+ (Functions.GetRotaryYear() + i+1) , "" + (Functions.GetRotaryYear() + i)));

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
        List<DRYA> list = DataMapping.GetListDRYA(rotary_year,section);
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

            PortalSettings ps = PortalSettings.Current;
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
        lbl_section.Text = "Section : " + ddl_section.SelectedValue;
        pnl_grid.Visible = true;
        pnl_display.Visible = false;
    }

    protected void gvw_archi_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editer")
        {
            pnl_edit.Visible = true;
            
            DRYA drya = DataMapping.GetListDRYA(int.Parse(rbl_rotaryYear.SelectedValue), section).Where(x => x.id == int.Parse(""+e.CommandArgument)).FirstOrDefault();
            lbl_nomEdit.Text = drya.name + " " + drya.surname;
            tbx_desc.Text = drya.description;
            tbx_job.Text = drya.job;
            tbx_role.Text = drya.role;
            tbx_previousrole.Value = drya.role;
            tbx_rank.Text = ""+drya.rank;
            hfd_id.Value = ""+drya.id;
          
            pnl_buttons.Visible = false;
            pnl_add.Visible = false;
            gvw_archi.Visible = false;

        }
        if(e.CommandName == "Delete")
        {
            List<DRYA> list = DataMapping.GetListDRYA(rotary_year,section);
            DRYA d = list.Where(x => x.id == int.Parse("" + e.CommandArgument)).FirstOrDefault();
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
        DRYA drya = DataMapping.GetListDRYA(int.Parse(rbl_rotaryYear.SelectedValue), section).Where(x => x.id == int.Parse("" + hfd_id.Value)).FirstOrDefault();
        drya.job = tbx_job.Text.Trim();
        drya.role = tbx_role.Text.Trim();
        if (!DataMapping.IsDRYARoleAuthorized(drya.role))
            drya.role = "";
        if(!String.IsNullOrEmpty(tbx_previousrole.Value) && drya.role!= tbx_previousrole.Value && drya.nim>0)
        {
            Member member = DataMapping.GetMemberByNim(drya.nim);
            if (member != null && !String.IsNullOrEmpty(member.email)) {
                var userInfo = UserController.GetUserByEmail(PortalId, member.email);
                if(userInfo!=null)
                {
                    var roleController = new RoleController();
                    var role = roleController.GetRoleByName(PortalId, tbx_previousrole.Value);
                    if(role!=null)
                        RoleController.DeleteUserRole(userInfo, role, PortalSettings, false);
                }
            }
        }
        drya.description = tbx_desc.Text.Trim();
        int rank = 0;
        int.TryParse("" + tbx_rank.Text,out rank);
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
        List<DRYA> list = DataMapping.GetListDRYA(rotary_year,section);
        tbx_rank.Text = list!=null?"" + (list.Count + 1) : "1";
    }
    

    protected void btn_add_Click(object sender, EventArgs e)
    {
        DRYA drya = new DRYA();
        List<DRYA> actuel = DataMapping.GetListDRYA(rotary_year,section);
        drya.section = section;
        drya.rotary_year = rotary_year;
        drya.job = tbx_job2.Text.Trim(); ;
        drya.role = tbx_role2.Text.Trim(); ;
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
        var ds = DataMapping.ExecSql("SELECT section as Section, surname as Nom, name as Prénom, job as Poste, role as Role, [description] as 'Description',nim as NIM,  cric as Cric, club as 'Nom du club', (select top 1 email from " + Const.TABLE_PREFIX + "members where nim=" + Const.TABLE_PREFIX + "drya.nim) as Email  FROM " + Const.TABLE_PREFIX+"drya    WHERE rotary_year = '"+ rbl_rotaryYear.SelectedValue + "'  order by section,rank");
        liste.Add(ds.Tables[0]);

        Media media = DataMapping.ExportDataTablesToXLS(liste, "Organigramme District " + rbl_rotaryYear.SelectedValue + "-" + (1 + int.Parse(rbl_rotaryYear.SelectedValue)) + ".xlsx", Aspose.Cells.SaveFormat.Xlsx);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);



    }




    protected void BT_Affectations_Roles_Click(object sender, EventArgs e)
    {
        string[] sections = ("" + Settings["sections"]).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var year = Functions.GetRotaryYear();
        
        RoleController roleController = new RoleController();
        List<string> subroles = new List<string>();
        foreach (string s in sections)
        {
            RoleInfo roleInfo = roleController.GetRoleByName(PortalId, s);
            if (roleInfo != null)
            {
                var users = roleController.GetUsersByRole(PortalId, roleInfo.RoleName);
                foreach (var user in users)
                {
                    RoleController.DeleteUserRole(user, roleInfo, PortalSettings, false);
                }
            }

            var dryas = DataMapping.GetListDRYA(Functions.GetRotaryYear(), s);
            foreach (var d in dryas)
            {
                if (!String.IsNullOrEmpty(d.role) && !subroles.Contains(d.role))
                {
                    roleInfo = roleController.GetRoleByName(PortalId, d.role);
                    if (roleInfo != null)
                    {
                        subroles.Add(roleInfo.RoleName);
                        var users = roleController.GetUsersByRole(PortalId, roleInfo.RoleName);
                        foreach (var user in users)
                        {
                            RoleController.DeleteUserRole(user, roleInfo, PortalSettings, false);
                        }
                    }
                }

            }

            DataMapping.UpdateDRYARoles(s);
        }

        P_Import.Visible = true;
        TXT_Import.Text = "Mise à jour des rôles effectuée";
        P_Import.CssClass = "alert alert-success";
    }
    
}
 