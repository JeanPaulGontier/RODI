using AIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de ClubDashboardHelper
/// </summary>
public class ClubHelper
{
    public ClubHelper()
    {
    }
    public ClubDashboard GetDashboard(int cric)
    {
        ClubDashboard dashboard = new ClubDashboard();

        dashboard.newsDistrict = DataMapping.ListNews_EN(category: "District", tri: "dt ASC", max: 10, where:"dt>getdate()-1").Where(n => n.visible!="N").ToList<NewsBase>();
        dashboard.newsDuClub = DataMapping.ListNews_EN(cric, category: "Clubs",tags_included:"Bulletin\r\nGaleries de photos", tri: "dt DESC", max: 10, where: "dt<getdate()+1").Where(n => n.visible!="N").ToList<NewsBase>();
        dashboard.newsDuClub.AddRange(DataMapping.ListNews_EN(cric, category: "Clubs", tags_excluded: "Bulletin\r\nGaleries de photos", tri: "dt ASC", max: 10, where: "dt>getdate()-1").Where(n => n.visible!="N").ToList<NewsBase>());
        dashboard.newsAutresClub = DataMapping.ListNews_EN(0, category: "Clubs", tri: "dt ASC", max: 10,where:"dt>getdate()-1 and cric!="+cric).Where(n => n.visible=="O" || n.visible!="D").ToList<NewsBase>();
        dashboard.meetings = MeetingHelper.GetMeetings(cric, "unitary").Where(m=>m.dtstart>DateTime.Now.AddDays(-1) && m.active=="O").OrderBy(m=>m.dtstart).ToList<MeetingBase>();
        dashboard.club = DataMapping.GetClub(cric) as ClubBase;

        return dashboard;
    }

    
}