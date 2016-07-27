using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Entities.Portals;

public partial class DesktopModules_AIS_Page_Pro_PagePro : PortalModuleBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int userid = UserId;
        rotary.Visible=DataMapping.ListMembers().Where(x => x.userid==userid).Count()>0;
        notRotary.Visible = !rotary.Visible;

        if (!rotary.Visible)
            return;

        Member m = DataMapping.GetMemberByUserID(userid);
        img_photoMember.ImageUrl = m.GetPhoto();
        lbl_industry.Text = m.industry;
        lbl_name.Text = m.name + " " + m.surname;



        if (m != null && m.id != null && m.id > 0)
        {
            PortalSettings ps = PortalController.GetCurrentPortalSettings();
            if (ps.UserInfo.Roles != null && ps.UserInfo.Roles.Count() > 0)
            {
                hlk_contact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + m.id + "&popUp=true',false,350,850,false);";
            }
            else
            {
                hlk_contact.NavigateUrl = "javascript:dnnModal.show('/AIS/contact.aspx?id=" + m.id + "&popUp=true',false,350,500,false);";
            }
        }
        else
        {
            if (!UserInfo.IsSuperUser)
                hlk_contact.Visible = false;
        }

        News n = null;
            
        if(DataMapping.ListNews_EN(where: "tag1='" + userid + "'")== null || DataMapping.ListNews_EN(where: "tag1='" + userid + "'").Count==0)
        {
            checkContentAndBloc(userid);
            n= DataMapping.ListNews_EN(where: "tag1='" + userid + "'").First();
            if (n == null)
                n = new News();
        }
        else
            n= DataMapping.ListNews_EN(where: "tag1='" + userid + "'").First();

        List<News.Bloc> blocs = n.GetListBlocs();
        repeat_blocs.DataSource = blocs;
        repeat_blocs.DataBind();

        if(blocs == null || blocs.Count==0)
        {
            pnl_pres.Visible = false;
            pnl_noPres.Visible = true;
        }


    }

    protected void btn_create_Click(object sender, EventArgs e)
    {
        rotary.Visible = false;
    }

    protected void repeat_blocs_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    public void checkContentAndBloc(int userId)
    {
        if (DataMapping.GetListContent(userId, "PagePro").Count > 0)
        {
            AIS.Content c = DataMapping.GetListContent(userId, "PagePro").First();
            if (DataMapping.ListNews_EN(tags_included:userId + "").Count() == 0)
            {
                News n = new News();
                n.cric = -1;
                n.dt = (DateTime)c.dt;
                n.title = c.title;
                n.Abstract = null;
                n.text = c.text;
                n.url_text = "";
                n.url = "";
                n.photo = c.photo;
                n.category = "PagePro";
                n.tag1 = "" + userId;
                n.tag2 = "";
                n.visible = "O";
                n.club_type = "rotary";
                n.adress_event = "";
                n.town_event = "";
                n.zip_event = "";
                n.date_end_event = new DateTime();
                n.date_start_event = new DateTime();
                n.ord = 0;

                DataMapping.UpdateNews_EN(n);
                checkContentAndBloc(userId);
                return;

            }
            else
            {
                News n = DataMapping.ListNews_EN(tags_included:""+ userId).First();
                if (n.GetListBlocs().Count == 0)
                {
                    News.Bloc b = new News.Bloc();
                    b.visible = "O";
                    b.type = c.photo == "" ? "BlocNoPhoto" : "BlocPhotoTop";
                    b.ord = 10;
                    b.title = c.title;
                    b.photo = c.photo;
                    b.content_type = "html";
                    b.content = c.text;

                    DataMapping.UpdateNewsBloc(b, n.id);
                }
                else
                    return;
            }
        }
        else
            return;

    }


}