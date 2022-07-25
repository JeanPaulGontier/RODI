using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using DotNetNuke.Common;

public partial class DesktopModules_AIS_Actions_Club_Liste_Actions_Club_Liste : PortalModuleBase
{
    DotNetNuke.Entities.Modules.ModuleController objModules2 = new DotNetNuke.Entities.Modules.ModuleController();
    int presentationtabid
    {
        get
        {
            int t = 0;
            int.TryParse("" + objModules2.GetModuleSettings(ModuleId)["presentationtabid"], out t);
            return t;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        List<News> news = new List<News>();
        
        foreach(News a in DataMapping.ListNews(category:"Clubs"))
        {
            if (a.cric != 0 && a.dt >= DateTime.Now)
                news.Add(a);
        }
        List<News> newsSorted = new List<News>();
        for(int i = news.Count-1; i>=0; i--)
        {
            newsSorted.Add(news[i]);
        }
        gvw_liste.DataSource = newsSorted;
        gvw_liste.DataBind();
    }


    protected void gvw_liste_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        News news = (News)e.Row.DataItem;
        if (news == null)
            return;


        HyperLink hlk_more = (HyperLink)e.Row.FindControl("hlk_more");
        hlk_more.NavigateUrl = Functions.UrlAddParam(Globals.NavigateURL(presentationtabid), "newsid", news.id);


        Label lbl_club = (Label)e.Row.FindControl("lbl_club");
        lbl_club.Text = DataMapping.GetClub(news.cric).name;
    }
}