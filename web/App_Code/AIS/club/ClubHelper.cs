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

        dashboard.newsDistrict = DataMapping.ListNews_EN(category: "District", tri: "dt DESC", max: 100).Where(n => n.visible!="N").ToList();
        dashboard.newsDuClub = DataMapping.ListNews_EN(cric, category: "Clubs", tri: "dt DESC", max: 100).Where(n => n.visible!="N").ToList();
        dashboard.newsAutresClub = DataMapping.ListNews_EN(0, category: "Clubs", tri: "dt DESC", max: 100,where:"cric!="+cric).Where(n => n.visible=="O" || n.visible!="D").ToList();
        dashboard.meetings = MeetingHelper.GetMeetings(cric, "unitary").Where(m=>m.dtstart>DateTime.Now.AddDays(-1)).ToList();


        return dashboard;
    }

    
}