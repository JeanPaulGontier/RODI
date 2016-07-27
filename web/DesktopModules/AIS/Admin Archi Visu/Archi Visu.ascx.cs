using AIS;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Services.Log.EventLog;
using DotNetNuke.Common;

public partial class DesktopModules_AIS_Admin_Archi_Visu_Archi_Visu : PortalModuleBase
{
    String section;
    int rotary_year;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        btn_modif.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);
        BindRBL(rbl_rotaryYear.SelectedIndex<0? 0 : rbl_rotaryYear.SelectedIndex);

        
       


        RefreshList_Grid();
    }

    public void BindRBL(int selectedIndex)
    {
        rbl_rotaryYear.Items.Clear();
        for (int i = 0; i < 3; i++)
            rbl_rotaryYear.Items.Add(new ListItem("" + (Functions.GetRotaryYear() + i)));

        rbl_rotaryYear.Items[selectedIndex].Selected = true;
    }

    public void BindDDLJobs()
    {
        
        switch(section)
        {
            case "Bureau":
                ddl_fonction.Items.Add("Secrétaire de District");
                ddl_fonction.Items.Add("Trésorier de District");
                ddl_fonction.Items.Add("Chef du protocole de District");
                ddl_fonction.Items.Add("Secrétaire de District Adjoint");
                ddl_fonction.Items.Add("Trésorier de District Adjoint");
                ddl_fonction.Items.Add("Chef du protocole de District Adjoint");
                ddl_fonction.Items.Add("Webmestre de District");
                ddl_fonction.Items.Add("Édition | Lettre du Gouverneur");
                ddl_fonction.Items.Add("Communication");
                ddl_fonction.Items.Add("Site internet et Réseau");
                ddl_fonction.Items.Add("Image Publique");
                break;
            case ("Fondation"):
                ddl_fonction.Items.Add("Président de la Commission");
                ddl_fonction.Items.Add("Gestion Financière");
                ddl_fonction.Items.Add("Objectif des Dons");
                ddl_fonction.Items.Add("Subventions et Bourses");
                ddl_fonction.Items.Add("Anciens de la Fondation");
                ddl_fonction.Items.Add("Audit");
                ddl_fonction.Items.Add("Archivage");
                ddl_fonction.Items.Add("Certification");
                ddl_fonction.Items.Add("Polio Plus");
                break;
            case ("Gouverneur"):
                ddl_fonction.Items.Add("Gouverneur");
                ddl_fonction.Items.Add("Gouverneur Élu");
                ddl_fonction.Items.Add("Gouverneur Nommé");
                ddl_fonction.Items.Add("Conseiller Spécial");
                ddl_fonction.Items.Add("Conseiller");
                break;
            default:
                for (int i = 1; i < 7; i++)
                {
                    string fonctionAdjoint = "";
                    if (section.Contains("Monaco"))
                        fonctionAdjoint = "Adjoint du Gouverneur : Groupe 06-" + i;
                    else if (section.Contains("Corse"))
                    {
                        fonctionAdjoint = "Adjoint du Gouverneur : Groupe 20-" + i;
                    }
                    else if (section.Contains("Var"))
                        fonctionAdjoint = "Adjoint du Gouverneur : Groupe 83-" + i;

                    if (fonctionAdjoint != "")
                        ddl_fonction.Items.Add(fonctionAdjoint);
                }
                break;
        }
        

       
    }

    public void BindDDLJobs2()
    {

        switch (section)
        {
            case "Bureau":
                ddl_fonction2.Items.Add("Secrétaire de District");
                ddl_fonction2.Items.Add("Trésorier de District");
                ddl_fonction2.Items.Add("Chef du protocole de District");
                ddl_fonction2.Items.Add("Secrétaire de District Adjoint");
                ddl_fonction2.Items.Add("Trésorier de District Adjoint");
                ddl_fonction2.Items.Add("Chef du protocole de District Adjoint");
                ddl_fonction2.Items.Add("Webmestre de District");
                ddl_fonction2.Items.Add("Édition | Lettre du Gouverneur");
                ddl_fonction2.Items.Add("Communication");
                ddl_fonction2.Items.Add("Site internet et Réseau");
                ddl_fonction2.Items.Add("Image Publique");
                break;
            case ("Fondation"):
                ddl_fonction2.Items.Add("Président de la Commission");
                ddl_fonction2.Items.Add("Gestion Financière");
                ddl_fonction2.Items.Add("Objectif des Dons");
                ddl_fonction2.Items.Add("Subventions et Bourses");
                ddl_fonction2.Items.Add("Anciens de la Fondation");
                ddl_fonction2.Items.Add("Audit");
                ddl_fonction2.Items.Add("Archivage");
                ddl_fonction2.Items.Add("Certification");
                ddl_fonction2.Items.Add("Polio Plus");
                break;
            case ("Gouverneur"):
                ddl_fonction2.Items.Add("Gouverneur");
                ddl_fonction2.Items.Add("Gouverneur Élu");
                ddl_fonction2.Items.Add("Gouverneur Nommé");
                ddl_fonction2.Items.Add("Conseiller Spécial");
                ddl_fonction2.Items.Add("Conseiller");
                break;
            default:
                for (int i = 1; i < 7; i++)
                {
                    string fonctionAdjoint = "";
                    if (section.Contains("Monaco"))
                        fonctionAdjoint = "Adjoint du Gouverneur : Groupe 06-" + i;
                    else if (section.Contains("Corse"))
                    {
                        fonctionAdjoint = "Adjoint du Gouverneur : Groupe 20-" + i;
                    }
                    else if (section.Contains("Var"))
                        fonctionAdjoint = "Adjoint du Gouverneur : Groupe 83-" + i;

                    if (fonctionAdjoint != "")
                        ddl_fonction2.Items.Add(fonctionAdjoint);
                }
                break;
        }



    }

    public void BindDDLNames(String filter)
    {
        ddl_name.Items.Clear();
        List<Member> members = DataMapping.ListMembers(criterion: filter, top:"TOP 5" );
        if (members != null)
        {
            foreach (Member d in members)
            {
                d.name = d.name + " " + d.surname;
                //ddl_name.Items.Add(d.name + " " + d.surname);
            }

            ddl_name.DataValueField = "nim";
            ddl_name.DataTextField = "name";
            ddl_name.DataSource = members;
            ddl_name.DataBind();
        }
    }

    public void RefreshList_Grid()
    {
        section = Request.QueryString["section"];
        if (section == null || section == "")
            section = "Gouverneur";

        rotary_year = int.Parse(rbl_rotaryYear.SelectedValue);
        List<DRYA> list = DataMapping.GetListDRYA("section='"+section+"' and rotary_year='" + rotary_year + "'");
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
        Image Image1 = (Image)e.Item.FindControl("Image1");
        Image1.ImageUrl = member.GetPhoto();

            
        PortalSettings ps = PortalController.GetCurrentPortalSettings();
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


    protected void btn_changeDate_Click(object sender, EventArgs e)
    {
        RefreshList_Grid();
    }

    protected void btn_modif_Click(object sender, EventArgs e)
    {
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
            hfd_id.Value = ""+drya.id;
            BindDDLJobs();

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
    }

    protected void lbt_apply_Click(object sender, EventArgs e)
    {
        DRYA drya = DataMapping.GetListDRYA("section ='" + section + "' and rotary_year='" + rbl_rotaryYear.SelectedValue + "'").Where(x => x.id == int.Parse("" + hfd_id.Value)).FirstOrDefault();
        drya.job = ddl_fonction.SelectedValue;
        drya.description = tbx_desc.Text;
        DataMapping.InsertDRYA(drya);
        RefreshList_Grid();
        pnl_edit.Visible = false;

    }

    protected void lbt_cancel_Click(object sender, EventArgs e)
    {
        pnl_edit.Visible = false;
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        pnl_grid.Visible = false;
        pnl_display.Visible = true;
    }

    protected void btn_addDRYA_Click(object sender, EventArgs e)
    {
        pnl_add.Visible = true;
        pnl_buttons.Visible = false;
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        ddl_name.Visible = true;
        BindDDLNames(tbx_search.Text);
        BindDDLJobs2();
        pnl_postSearch.Visible = true;
        List<DRYA> list = DataMapping.GetListDRYA("section='" + section + "' and rotary_year='" + rotary_year + "'");
        tbx_rank.Text = "" + (list.Count + 1);
    }
    

    protected void btn_add_Click(object sender, EventArgs e)
    {
        DRYA drya = new DRYA();
        List<DRYA> actuel = DataMapping.GetListDRYA("section='" + section + "' and rotary_year='" + rotary_year + "'");
        drya.section = section;
        drya.rotary_year = rotary_year;
        drya.job = ddl_fonction2.SelectedValue;
        drya.description = tbx_desc2.Text;
        drya.rank = int.Parse(tbx_rank.Text);
        //String nomPrenom = ddl_name.SelectedValue;
        //String[] splits = nomPrenom.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //Member m = DataMapping.ListMembers().Where(x => x.name == splits[0] && x.surname == splits[1]).FirstOrDefault();
        
        int nimMember = 0;
        int.TryParse(ddl_name.SelectedValue, out nimMember);
       
        Member m = DataMapping.GetMemberByNim(nimMember);
        if (m == null)
            throw new Exception("Member no found. ");
        drya.name = m.name;
        drya.nim = m.nim;
        drya.surname = m.surname;
        drya.cric = m.cric;
        drya.club = m.club_name;
        if(drya.rank<=actuel.Count)
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
    }

    public void Log(String s)
    {
        DotNetNuke.Services.Log.EventLog.EventLogController eventLog = new DotNetNuke.Services.Log.EventLog.EventLogController();
        LogInfo logInfo = new LogInfo();

        logInfo.LogUserID = -1;
        logInfo.LogPortalID = Globals.GetPortalSettings().PortalId;
        logInfo.LogTypeKey = EventLogController.EventLogType.HOST_ALERT.ToString();
        logInfo.AddProperty("Log ", s);

        eventLog.AddLog(logInfo);
    }

    protected void btn_back2_Click(object sender, EventArgs e)
    {
        pnl_add.Visible = false;
        pnl_buttons.Visible = true;
    }
}