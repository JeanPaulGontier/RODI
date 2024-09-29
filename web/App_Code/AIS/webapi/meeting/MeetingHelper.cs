using AIS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Globalization;
using System.Diagnostics;
using System.Activities.Statements;

/// <summary>
/// Description résumée de MeetingHelper
/// </summary>
public class MeetingHelper
{
    public MeetingHelper()
    {
        //
        // TODO: ajoutez ici la logique du constructeur
        //
    }

    public static int GetWeekOfMonth(DateTime date)
    {
        DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

        while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
        {
            date = date.AddDays(1);
        }

        return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
    }

    public static int GetDayOfWeek(string day)
    {
        day= day.ToLower();
        string[] days = new string[] { "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi", "dimanche" };
        int num = 0;
        foreach (string d in days)
        {
            num++;
            if (d == day)
            {
                break;
            }
        }
        return num;
    }
    public static int GetNumOfDayTypeOfMonth(DateTime date)
    {
        int numday = (int)date.DayOfWeek;
        DateTime startdate = new DateTime(date.Year, date.Month, 1);
        DateTime enddate = date.AddDays(1);
        int num = 0;
        while (startdate < enddate)
        {
            if (numday == (int)startdate.DayOfWeek)
                num++;
            startdate= startdate.AddDays(1);
        }
        return num;
    }

    public static string DoPeriodics()
    {

        StringBuilder sb = new StringBuilder();

        try
        {
            string notifications_debug_dest = Const.NOTIFICATIONS_DEBUG_DEST;
            string DEFAULTNOTIFICATIONMSG = "" + Yemon.dnn.Helpers.GetItem("meeting:msgNotif1");
            // desactivation de l'inscription sur une réunion passée
            DataMapping.ExecSql("UPDATE [ais_meetings] SET active='N' WHERE dtendactive<getdate() and dtendactive is not null and type='unitary'");
            DataMapping.ExecSql("UPDATE [ais_meetings] SET active='N' WHERE dtstart<getdate() and type='unitary'");

            SqlCommand sql = new SqlCommand("SELECT * FROM [ais_meetings] WHERE " +
                    "doperiodics='O' AND " +
                    "type='periodic' " +
                    "ORDER BY dtrevision");
            List<Meeting> meetings = Yemon.dnn.DataMapping.ExecSql<Meeting>(sql);
            foreach (var meeting in meetings)
            {


                Meeting.Period[] periods = (Meeting.Period[])Yemon.dnn.Functions.Deserialize("" + meeting.periods, typeof(Meeting.Period[]));
                sb.Append("<div>Meeting : " + meeting.guid + "</div>");
                List<Meeting> unitmeetings = Yemon.dnn.DataMapping.ExecSql<Meeting>(new SqlCommand("" +
                    "SELECT * FROM ais_meetings WHERE " +
                    "dtstart>getdate()-1 AND " +
                    "type='unitary' AND " +
                    "templateguid='" + meeting.guid + "' " +
                    "ORDER BY dtstart"
                    ));
                foreach (Meeting.Period period in periods)
                {
                    
                    DateTime startdate = DateTime.Now;
                    startdate = new DateTime(startdate.Year, startdate.Month, startdate.Day, startdate.Hour, startdate.Minute, startdate.Second);

                    while (startdate < DateTime.Now.AddDays(31))
                    {
                        int daynum = GetNumOfDayTypeOfMonth(startdate); 
                        var culture = new System.Globalization.CultureInfo("fr-FR");
                        var day = culture.DateTimeFormat.GetDayName(startdate.DayOfWeek);
                       
                        Debug.WriteLine(startdate.ToString()+"\t"+ period.num + "\t" + daynum + "\t" + period.day + "\t" + day);


                        if (daynum == period.num && period.day.ToLower()==day)
                        {
                            if (period.start != "" && period.end != "")
                            {
                                Meeting nextMeeting = null;
                                foreach (Meeting m in unitmeetings)
                                {
                                    if (m.dtstart.ToString("yyyy-MM-dd") == startdate.ToString("yyyy-MM-dd") &&
                                        m.templateguid == meeting.guid &&
                                        m.periodguid == period.guid)
                                    {
                                        nextMeeting = m;
                                        System.Diagnostics.Debug.WriteLine("Date trouvée " + m.dtstart);
                                        sb.Append("<div>Date trouvée " + m.dtstart + " ... added</div>");
                                        break;
                                    }
                                }
                                if (nextMeeting == null)
                                {
                                    System.Diagnostics.Debug.WriteLine("Meeting a créer " + startdate.ToString("dd/MM/yyyy ") + period.start);

                                    nextMeeting = Yemon.dnn.Functions.DeepCopy<Meeting>(meeting);
                                    nextMeeting.templateguid = nextMeeting.guid;
                                    nextMeeting.guid = Guid.NewGuid();
                                    nextMeeting.dtrevision = DateTime.Now;
                                    nextMeeting.type = "unitary";
                                    nextMeeting.dtstart = DateTime.Parse(startdate.ToString("yyyy-MM-dd ") + period.start + ":00");
                                    nextMeeting.dtendactive = nextMeeting.dtstart;
                                    nextMeeting.dtend = DateTime.Parse(startdate.ToString("yyyy-MM-dd ") + period.end + ":00"); ;
                                    nextMeeting.link = ("" + nextMeeting.guid).ToLower().Substring(9, 9);

                                    sql = new SqlCommand("INSERT INTO ais_meetings " +
                                    "(cric,name,guid,active,type,periods,statutory,dtstart,dtend,dtrevision,templateguid,periodguid,mustnotify,dtlastupdate,portalid,link,nbusers,dtendactive,notificationmsg) VALUES " +
                                    "(@cric,@name,@guid,@active,@type,@periods,@statutory,@dtstart,@dtend,@dtrevision,@templateguid,@periodguid,@mustnotify,@dtlastupdate,@portalid,@link,@nbusers,@dtendactive,@notificationmsg)");
                                    sql.Parameters.AddWithValue("cric", nextMeeting.cric);
                                    sql.Parameters.AddWithValue("name", nextMeeting.name);
                                    sql.Parameters.AddWithValue("guid", nextMeeting.guid);
                                    sql.Parameters.AddWithValue("active", nextMeeting.active);
                                    sql.Parameters.AddWithValue("type", nextMeeting.type);
                                    sql.Parameters.AddWithValue("periods", "[]");
                                    sql.Parameters.AddWithValue("statutory", nextMeeting.statutory);
                                    sql.Parameters.AddWithValue("dtstart", nextMeeting.dtstart);
                                    sql.Parameters.AddWithValue("dtend", nextMeeting.dtend);
                                    sql.Parameters.AddWithValue("dtrevision", nextMeeting.dtrevision);
                                    sql.Parameters.AddWithValue("dtendactive", nextMeeting.dtendactive);
                                    sql.Parameters.AddWithValue("templateguid", nextMeeting.templateguid);
                                    sql.Parameters.AddWithValue("periodguid", period.guid);
                                    sql.Parameters.AddWithValue("mustnotify", Const.NO);
                                    sql.Parameters.AddWithValue("dtlastupdate", DateTime.Now);
                                    sql.Parameters.AddWithValue("portalid", 0);
                                    sql.Parameters.AddWithValue("link", nextMeeting.link);
                                    sql.Parameters.AddWithValue("nbusers", 0);
                                    sql.Parameters.AddWithValue("notificationmsg", DEFAULTNOTIFICATIONMSG);

                                    if (Yemon.dnn.DataMapping.ExecSqlNonQuery(sql) > 0)
                                    {
                                        string blocks = "" + Yemon.dnn.Helpers.GetItem("blockscontent:" + meeting.guid);
                                        if (blocks != "")
                                        {
                                            Yemon.dnn.Helpers.SetItem("blockscontent:" + nextMeeting.guid, blocks, "", keephistory: false);
                                        }

                                        sb.Append("<div>Meeting " + nextMeeting.dtstart + " ... added</div>");
                                    }
                                    else
                                    {
                                        Functions.Error(new Exception("Erreur insertion meeting" + Environment.NewLine + Functions.Serialize(nextMeeting)));
                                    }

                                }
                            }

                        }
                        startdate = startdate.AddDays(1);
                    }

                }

            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            sb.Append("<div>ERREUR : </div>");
            sb.Append("<div>" + ee.ToString() + "</div>");
        }

        return sb.ToString();
    }
    public static string DoPeriodicsAvantAout2024()
    {

        StringBuilder sb = new StringBuilder();

        try
        {
            string notifications_debug_dest = Const.NOTIFICATIONS_DEBUG_DEST;

            // desactivation de l'inscription sur une réunion passée
            DataMapping.ExecSql("UPDATE [ais_meetings] SET active='N' WHERE dtend<getdate() and dtend is not null and type='unitary'");


            SqlCommand sql = new SqlCommand("SELECT * FROM [ais_meetings] WHERE " +
                    "doperiodics='O' AND " +
                    "type='periodic' " +
                    "ORDER BY dtrevision");
            List<Meeting> meetings = Yemon.dnn.DataMapping.ExecSql<Meeting>(sql);
            foreach (var meeting in meetings)
            {


                Meeting.Period[] periods = (Meeting.Period[])Yemon.dnn.Functions.Deserialize("" + meeting.periods, typeof(Meeting.Period[]));
                sb.Append("<div>Meeting : " + meeting.guid + "</div>");
                List<Meeting> unitmeetings = Yemon.dnn.DataMapping.ExecSql<Meeting>(new SqlCommand("" +
                    "SELECT * FROM ais_meetings WHERE " +
                    "dtstart>getdate()-1 AND " +
                    "type='unitary' AND " +
                    "templateguid='" + meeting.guid + "' " +
                    "ORDER BY dtstart"
                    ));
                foreach (Meeting.Period period in periods)
                {
                    int daynum = GetDayOfWeek(period.day);


                    DateTime startdate = DateTime.Now;
                    startdate = new DateTime(startdate.Year, startdate.Month, startdate.Day, startdate.Hour, startdate.Minute, startdate.Second);

                    while (startdate < DateTime.Now.AddDays(31))
                    {
                        if ((int)startdate.DayOfWeek == daynum && GetWeekOfMonth(startdate) == period.num)
                        {
                            if (period.start != "" && period.end != "")
                            {
                                Meeting nextMeeting = null;
                                foreach (Meeting m in unitmeetings)
                                {
                                    if (m.dtstart.ToString("yyyy-MM-dd") == startdate.ToString("yyyy-MM-dd") &&
                                        m.templateguid == meeting.guid &&
                                        m.periodguid == period.guid)
                                    {
                                        nextMeeting = m;
                                        System.Diagnostics.Debug.WriteLine("Date trouvée " + m.dtstart);
                                        sb.Append("<div>Date trouvée " + m.dtstart + " ... added</div>");
                                        break;
                                    }
                                }
                                if (nextMeeting == null)
                                {
                                    System.Diagnostics.Debug.WriteLine("Meeting a créer " + startdate.ToString("dd/MM/yyyy ") + period.start);

                                    nextMeeting = Yemon.dnn.Functions.DeepCopy<Meeting>(meeting);
                                    nextMeeting.templateguid = nextMeeting.guid;
                                    nextMeeting.guid = Guid.NewGuid();
                                    nextMeeting.dtrevision = DateTime.Now;
                                    nextMeeting.type = "unitary";
                                    nextMeeting.dtstart = DateTime.Parse(startdate.ToString("yyyy-MM-dd ") + period.start + ":00");
                                    nextMeeting.dtend = DateTime.Parse(startdate.ToString("yyyy-MM-dd ") + period.end + ":00"); ;
                                    nextMeeting.link = ("" + nextMeeting.guid).ToLower().Substring(9, 9);

                                    sql = new SqlCommand("INSERT INTO ais_meetings " +
                                    "(cric,name,guid,active,type,periods,statutory,dtstart,dtend,dtrevision,templateguid,periodguid,mustnotify,dtlastupdate,portalid,link,nbusers) VALUES " +
                                    "(@cric,@name,@guid,@active,@type,@periods,@statutory,@dtstart,@dtend,@dtrevision,@templateguid,@periodguid,@mustnotify,@dtlastupdate,@portalid,@link,@nbusers)");
                                    sql.Parameters.AddWithValue("cric", nextMeeting.cric);
                                    sql.Parameters.AddWithValue("name", nextMeeting.name);
                                    sql.Parameters.AddWithValue("guid", nextMeeting.guid);
                                    sql.Parameters.AddWithValue("active", nextMeeting.active);
                                    sql.Parameters.AddWithValue("type", nextMeeting.type);
                                    sql.Parameters.AddWithValue("periods", "[]");
                                    sql.Parameters.AddWithValue("statutory", nextMeeting.statutory);
                                    sql.Parameters.AddWithValue("dtstart", nextMeeting.dtstart);
                                    sql.Parameters.AddWithValue("dtend", nextMeeting.dtend);
                                    sql.Parameters.AddWithValue("dtrevision", nextMeeting.dtrevision);
                                    sql.Parameters.AddWithValue("templateguid", nextMeeting.templateguid);
                                    sql.Parameters.AddWithValue("periodguid", period.guid);
                                    sql.Parameters.AddWithValue("mustnotify", Const.NO);
                                    sql.Parameters.AddWithValue("dtlastupdate", DateTime.Now);
                                    sql.Parameters.AddWithValue("portalid", 0);
                                    sql.Parameters.AddWithValue("link", nextMeeting.link);
                                    sql.Parameters.AddWithValue("nbusers", 0);
                                    if (Yemon.dnn.DataMapping.ExecSqlNonQuery(sql) > 0)
                                    {
                                        string blocks = "" + Yemon.dnn.Helpers.GetItem("blockscontent:" + meeting.guid);
                                        if (blocks != "")
                                        {
                                            Yemon.dnn.Helpers.SetItem("blockscontent:" + nextMeeting.guid, blocks, "", keephistory: false);
                                        }

                                        sb.Append("<div>Meeting " + nextMeeting.dtstart + " ... added</div>");
                                    }
                                    else
                                    {
                                        Functions.Error(new Exception("Erreur insertion meeting" + Environment.NewLine + Functions.Serialize(nextMeeting)));
                                    }

                                }
                            }

                        }
                        startdate = startdate.AddDays(1);
                    }

                }

            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            sb.Append("<div>ERREUR : </div>");
            sb.Append("<div>" + ee.ToString() + "</div>");
        }

        return sb.ToString();
    }

    public static string DoNotifications()
    {
        StringBuilder sb = new StringBuilder();

        try
        {
            string notifications_debug_dest = Const.NOTIFICATIONS_DEBUG_DEST;

            SqlCommand sql = new SqlCommand("SELECT * FROM [ais_meetings] WHERE " +
                "dtrevision < getdate() AND " +
                "active='O' AND " +
                "type='unitary' AND " +
                "mustnotify='O' AND " +
                "notif1done IS null " +
                "ORDER BY dtrevision");
            List<Meeting> meetings = Yemon.dnn.DataMapping.ExecSql<Meeting>(sql);
            foreach (var meeting in meetings)
            {
                Club club = DataMapping.GetClub(meeting.cric);
                if (club != null)
                {
                    string txtNotif1 = meeting.notificationmsg;// "" + Yemon.dnn.Helpers.GetItem("meeting:msgNotif1");

                    List<Member> members = DataMapping.ListMembers(club.cric);

                    DataTable users = Yemon.dnn.DataMapping.ExecSql("SELECT * FROM ais_meetings_users WHERE meetingguid='" + meeting.guid + "'");

                    var list = new List<Contact>();
                    if(!string.IsNullOrEmpty(meeting.notificationlist)){
                        ContactsHelper contactsHelper = new ContactsHelper();
                        list= contactsHelper.GetContactsFromList(new Guid(meeting.notificationlist));
                    }

                    foreach (Member m in members)
                    {
                        bool ok = false;

                        if (meeting.notificationtype == "S" && m.satellite_member == Const.YES)
                            ok = true;
                        if (meeting.notificationtype == "M" && m.satellite_member != Const.YES)
                            ok = true;
                        if (meeting.notificationtype == "A")
                            ok = true;
                        if(meeting.notificationtype=="L")
                        {
                            if(list !=null)
                            {
                                foreach(Contact c in list){
                                    if (c.nim == m.nim){
                                        ok = true;
                                        break;
                                    }
                            }
                        }
                            
                        }
                        if (ok)
                        {

                            string useridguid = "";
                            if (m.userid > 0)
                            {
                                useridguid = Yemon.dnn.Functions.CalculateMD5Hash("" + m.userid);
                            }

                            bool subscribed = false;
                            foreach (DataRow row in users.Rows)
                            {
                                if (("" + row["useridguid"]) == useridguid)
                                {
                                    subscribed = true;
                                    break;
                                }
                            }
                            if (!subscribed)
                            {
                                try
                                {
                                    string club_type = ("" + club.club_type);
                                    string club_name = ("" + club.name);
                                    if (club_type == "rotary")
                                        club_name = "RC " + club_name;
                                    else if (club_type == "rotaract")
                                        club_name = "RAC " + club.name;

                                        string body = txtNotif1.Replace("#meeting.dtstart#", meeting.dtstart.ToString("dd/MM/yyyy - HH:mm"));
                                    body = body.Replace("#meeting.dtend#", meeting.dtend.ToString("dd/MM/yyyy - HH:mm"));
                                    body = body.Replace("#meeting.name#", meeting.name);
                                    body = body.Replace("#meeting.link#", Const.DISTRICT_URL + "/m-" + meeting.link + "?useridguid=" + useridguid);
                                    body = body.Replace("#meeting.sharelink#", Const.DISTRICT_URL + "/m-" + meeting.link);

                                    //if (notifications_debug_dest != "")
                                    //    Functions.SendMail(club.email, notifications_debug_dest, "[" + club.name + "] Notification de réunion", body, club_name);
                                    //else
                                    //    Functions.SendMail(club.email, m.email, "[" + club.name + "] Notification de réunion", body, club_name);
                                    if (notifications_debug_dest != "")
                                        Functions.SendMail(club.email, notifications_debug_dest, meeting.name, body, club_name);
                                    else
                                        Functions.SendMail(club.email, m.email, meeting.name, body, club_name);

                                }
                                catch (Exception ee)
                                {
                                    Functions.Error(ee);
                                }
                            }
                        }
                    }
                }
                meeting.dtnotif1 = DateTime.Now;
                meeting.notif1done = Const.YES;
                meeting.mustnotify = Const.NO;
                sql = new SqlCommand("UPDATE ais_meetings SET dtnotif1=@dtnotif1,notif1done=@notif1done,mustnotify=@mustnotify WHERE id=@id");
                sql.Parameters.AddWithValue("id", meeting.id);
                sql.Parameters.AddWithValue("dtnotif1", meeting.dtnotif1);
                sql.Parameters.AddWithValue("notif1done", meeting.notif1done);
                sql.Parameters.AddWithValue("mustnotify", meeting.mustnotify);
                Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);

                sb.Append("<div>Meeting : " + meeting.guid + "</div>");
                sb.Append("<div>Notify 1 ... done</div>");
            }

            sb.Append("<div>Succeeded</div>");

        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }

        return sb.ToString();
    }
}