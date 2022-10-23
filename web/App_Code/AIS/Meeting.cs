using AIS;
using DotNetNuke.Services.Scheduling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;


/// <summary>
/// Description résumée de Meeting
/// </summary>
public class Meeting
{
    public int id { get; set; }
    public int cric { get; set; }
    public string name { get; set; }
    public Guid guid { get; set; }
    public string active { get; set; }
    public string type { get; set; }
    public string statutory { get; set; }
    public DateTime dtstart { get; set; }
    public DateTime dtend { get; set; }
    public DateTime dtrevision { get; set; }
    public Guid templateguid { get; set; }
    public string mustnotify { get; set; }
    public DateTime dtnotif1 { get; set; }
    public DateTime dtnotif2 { get; set; }
    public string notif1done { get; set; }
    public string notif2done { get; set; }
    public DateTime dtlastupdate { get; set; }
    public int portalid { get; set; }
    public int nbusers { get; set; }
    public string link { get; set; }

    public string periods { get; set; }

    public class Period
    {
        public int num { get; set; }
        public string day { get; set; }
        public string start { get; set; }
        public string end { get; set; }

    }

    public class User
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string comment { get; set; }
        public Guid guid { get; set; }
        public Guid meetingguid { get; set; }
        public string useridguid { get; set; }
        public string presence { get; set; }
        public DateTime dtlastupdate { get; set; }
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
        string[] days = new string[] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
        int num = 0;
        foreach(string d in days)
        {
            num++;
            if(d==day)
            {
                break;
            }
        }
        return num;
    }

    public static string DoPeriodics() {

        StringBuilder sb = new StringBuilder();

            try
            {
                // desactivation de l'inscription sur une réunion passée
                DataMapping.ExecSql("UPDATE [ais_meetings] SET active='N' WHERE dtend<getdate() and dtend is not null and type='unitary'");


                SqlCommand sql = new SqlCommand("SELECT * FROM [ais_meetings] WHERE " +
                        //"active='O' AND " +
                        "type='periodic' " +
                        "ORDER BY dtrevision");
                List<Meeting> meetings = Yemon.dnn.DataMapping.ExecSql<Meeting>(sql);
                foreach (var meeting in meetings)
                {

                    //int nextweek = GetWeekOfMonth(DateTime.Now) + 1;
                    int nextweek = GetWeekOfMonth(DateTime.Now.AddDays(7)) ;

                    Meeting.Period[] periods = (Meeting.Period[])Yemon.dnn.Functions.Deserialize("" + meeting.periods, typeof(Meeting.Period[]));
                    sb.Append("<div>Meeting : " + meeting.guid + "</div>");
                    foreach (Meeting.Period period in periods)
                    {

                        if(period.num==nextweek)
                        {
                            
                            int daynum = GetDayOfWeek(period.day);

                            // recherche de la premiere date a j+7 du jour de la période
                            DateTime nextdate = DateTime.Now.AddDays(7);
                            while(nextdate< DateTime.Now.AddMonths(1))
                            {
                                nextdate = nextdate.AddDays(1);
                                if (nextdate.ToString("dddd") == period.day.ToLower())
                                {
                                    break;
                                }
                            }

                            sql = new SqlCommand("SELECT * FROM ais_meetings WHERE templateguid=@templateguid AND dtstart>@dtstart AND dtstart<@dtstart1 AND type='unitary'");
                            sql.Parameters.AddWithValue("templateguid", meeting.guid);
                            sql.Parameters.AddWithValue("dtstart", new DateTime(nextdate.Year, nextdate.Month, nextdate.Day));
                            sql.Parameters.AddWithValue("dtstart1", new DateTime(nextdate.Year, nextdate.Month, nextdate.Day).AddDays(1));
                            Meeting nextMeeting = Yemon.dnn.DataMapping.ExecSqlFirst<Meeting>(sql);
                            if(nextMeeting==null)
                            {

                                DateTime dtstart = DateTime.Now;
                                DateTime.TryParse("" + period.start, out dtstart);
                                if (dtstart == DateTime.MinValue)
                                    dtstart = nextdate;
                                else
                                    dtstart = new DateTime(nextdate.Year, nextdate.Month, nextdate.Day, dtstart.Hour, dtstart.Minute, dtstart.Second);
                                DateTime dtend = DateTime.Now.AddHours(1);
                                DateTime.TryParse("" + period.end, out dtend);
                                if (dtend == DateTime.MinValue)
                                    dtend = dtstart.AddHours(1);
                                else
                                    dtend = new DateTime(nextdate.Year, nextdate.Month, nextdate.Day, dtend.Hour, dtend.Minute, dtend.Second);

                                nextMeeting = (Meeting)Yemon.dnn.Functions.Deserialize(Yemon.dnn.Functions.Serialize(meeting),typeof(Meeting));
                                nextMeeting.templateguid = nextMeeting.guid;
                                nextMeeting.guid = Guid.NewGuid();
                                nextMeeting.dtrevision = nextdate.AddDays(-4);
                                nextMeeting.type = "unitary";
                                nextMeeting.dtstart = nextdate;
                                nextMeeting.dtend = nextdate;
                                nextMeeting.link = ("" + nextMeeting.guid).ToLower().Substring(9, 9);

                                sql = new SqlCommand("INSERT INTO ais_meetings " +
                                "(cric,name,guid,active,type,periods,statutory,dtstart,dtend,dtrevision,templateguid,mustnotify,dtlastupdate,portalid,link,nbusers) VALUES " +
                                "(@cric,@name,@guid,@active,@type,@periods,@statutory,@dtstart,@dtend,@dtrevision,@templateguid,@mustnotify,@dtlastupdate,@portalid,@link,@nbusers)");
                                sql.Parameters.AddWithValue("cric", nextMeeting.cric);
                                sql.Parameters.AddWithValue("name", nextMeeting.name);
                                sql.Parameters.AddWithValue("guid", nextMeeting.guid);
                                sql.Parameters.AddWithValue("active", nextMeeting.active);
                                sql.Parameters.AddWithValue("type", nextMeeting.type);
                                sql.Parameters.AddWithValue("periods", "[]");
                                sql.Parameters.AddWithValue("statutory", nextMeeting.statutory);
                                sql.Parameters.AddWithValue("dtstart", dtstart);
                                sql.Parameters.AddWithValue("dtend", dtend);
                                sql.Parameters.AddWithValue("dtrevision", nextMeeting.dtrevision);
                                sql.Parameters.AddWithValue("templateguid", nextMeeting.templateguid);
                                sql.Parameters.AddWithValue("mustnotify", nextMeeting.mustnotify);
                                sql.Parameters.AddWithValue("dtlastupdate", DateTime.Now);
                                sql.Parameters.AddWithValue("portalid", 0);
                                sql.Parameters.AddWithValue("link", nextMeeting.link);
                                sql.Parameters.AddWithValue("nbusers", 0);
                                if(Yemon.dnn.DataMapping.ExecSqlNonQuery(sql)>0)
                                { 
                            


                                    string blocks = "" + Yemon.dnn.Helpers.GetItem("blockscontent:" + meeting.guid);
                                    if(blocks!="")
                                    {
                                        Yemon.dnn.Helpers.SetItem("blockscontent:" + nextMeeting.guid, blocks, "", keephistory: false);
                                    }

                                    sb.Append("<div>Meeting "+nextMeeting.dtstart+" ... added</div>");
                                }
                                else
                                {
                                    throw new Exception("Erreur insertion meeting");
                                }

                            }

                        }

                    }
                   
                   


                }
            }
            catch(Exception ee)
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
                SqlCommand sql = new SqlCommand("SELECT * FROM [ais_meetings] WHERE " +
                    "dtrevision < getdate() AND " +
                    //"active='O' AND " +
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
                        string txtNotif1 = "" + Yemon.dnn.Helpers.GetItem("meeting:msgNotif1");
                        List<Member> members = DataMapping.ListMembers(club.cric);

                        DataTable users = Yemon.dnn.DataMapping.ExecSql("SELECT * FROM ais_meetings_users WHERE meetingguid='" + meeting.guid + "'");

                        foreach (Member m in members)
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
                                try { 

                                    string body = txtNotif1.Replace("#meeting.dtstart#", meeting.dtstart.ToString("dd/MM/yyyy - HH:mm"));
                                    body = body.Replace("#meeting.dtend#", meeting.dtend.ToString("dd/MM/yyyy - HH:mm"));
                                    body = body.Replace("#meeting.name#", meeting.name);
                                    body = body.Replace("#meeting.link#", Const.DISTRICT_URL + "/m-" + meeting.link + "?useridguid=" + useridguid);
                                //body += "<div>" + m.email + "</div>";
                                Yemon.dnn.Functions.SendMail(club.email, m.email, "[" + club.name + "] Notification de réunion", body);
//                                Yemon.dnn.Functions.SendMail(club.email, "polo@pololand.com", "[" + club.name + "] Notification de réunion", body);

                            }
                            catch (Exception ee)
                                {
                                    Functions.Error(ee);
                                }
                                //Yemon.dnn.Functions.SendMail(club.email, "dico1780@rotary1780.org", "[" + club.name + "] Notification de réunion", body);
                                //Yemon.dnn.Functions.SendMail(club.email, "polo@pololand.com", "[" + club.name + "] Notification de réunion", body);
                            }
                        }


                    }
                    meeting.dtnotif1 = DateTime.Now;
                    meeting.notif1done = Const.YES;
                    sql = new SqlCommand("UPDATE ais_meetings SET dtnotif1=@dtnotif1,notif1done=@notif1done WHERE id=@id");
                    sql.Parameters.AddWithValue("id", meeting.id);
                    sql.Parameters.AddWithValue("dtnotif1", meeting.dtnotif1);
                    sql.Parameters.AddWithValue("notif1done", meeting.notif1done);
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

public class MeetingScheduler : SchedulerClient
{
    public MeetingScheduler(ScheduleHistoryItem oItem) : base()
    {
        this.ScheduleHistoryItem = oItem;
    }

    public override void DoWork()
    {
        string taskname = "" + this.ScheduleHistoryItem.FriendlyName.ToLower();

        try
        {

            // do some work
            this.ScheduleHistoryItem.AddLogNote("<div>Doing periodics</div>");
            string result = Meeting.DoPeriodics();
            this.ScheduleHistoryItem.AddLogNote(result);
            result =Meeting.DoNotifications();
            this.ScheduleHistoryItem.AddLogNote("<div>Doing notifications</div>");
            this.ScheduleHistoryItem.AddLogNote(result);
            this.ScheduleHistoryItem.Succeeded = true;

        }
        catch (Exception exc)
        {
            this.ScheduleHistoryItem.Succeeded = false;
            this.ScheduleHistoryItem.AddLogNote("<div>Failed: " + exc.Message + "</div>");
            this.Errored(ref exc);

        }

    }



}