using AIS;
using Aspose.Cells;
using DotNetNuke.Services.Scheduling;
using Org.BouncyCastle.Asn1.X509;
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
    public string active { get; set; }      // O : inscriptions actives
                                            // N : inscriptions fermées (auto N quand date est dépassée)
    public string doperiodics { get; set; } // O / N active ou pas la programmation automatique des réunions périodiques
    public string type { get; set; }        // unitary / periodic
    public string statutory { get; set; }   // O / N
    public DateTime dtstart { get; set; }
    public DateTime dtend { get; set; }
    public Guid templateguid { get; set; }  // permet de lier le meeting unitaire avec le meeting periodique qui a servi a le créer
    public Guid periodguid { get; set; }    // permet de lier la periode unitaire avec la periode periodique correspondante afin de ne pas recreer une période si on change après coup l'heure de la période


    public DateTime dtrevision { get; set; } // date après laquelle une notificatione est envoyée (auto ou manuelle)
    public string mustnotify { get; set; }   // O : oui 
                                             // N : non
    public string notificationtype { get; set; } // A : all members
                                                 // M : only members
                                                 // C : commity
                                                 // S : only satellite members
                                                 // L : selection list

    public string notificationlist { get; set; } // recipient list in case of notificationtype = L, sérialisé JSON
    public DateTime dtnotif1 { get; set; }   // contient la date et heure de la dernière notif
    public DateTime dtnotif2 { get; set; }   // non utilisé pour l'instant
    public string notif1done { get; set; }   // O / N
    public string notif2done { get; set; }   // non utilisé pour l'instant

    public DateTime dtlastupdate { get; set; }  // derniere modif de la réunion
    public int portalid { get; set; }
    public int nbusers { get; set; }
    
    public string link { get; set; }        // code réduit pour l'accès à la réunion 

    public string periods { get; set; }     // périodes de programmation sérialisé JSON


    public class Period
    {
        public Guid guid { get; set; }
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

    public class Recipient
    {
        public int nim { get; set; }
        public string email { get; set; }   // vide quand nim renseigné, utile pour mail externe
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
                        "dtstart>getdate() AND " +
                        "type='unitary' AND " +
                        "templateguid='" + meeting.guid + "' " +
                        "ORDER BY dtstart"
                        ));
                    foreach (Meeting.Period period in periods)
                    {
                           int daynum = GetDayOfWeek(period.day);
                            

                            DateTime startdate = DateTime.Now;
                            while(startdate< DateTime.Now.AddDays(31))
                            {
                                if((int)startdate.DayOfWeek==daynum && GetWeekOfMonth(startdate)==period.num)
                                {
                                    if (period.start!="")
                                    {
                                        Meeting nextMeeting = null;
                                        foreach(Meeting m in unitmeetings)
                                        {
                                            if( m.dtstart.ToString("yyyyMMdd")==startdate.ToString("yyyyMMdd") && 
                                                m.templateguid==meeting.guid && 
                                                m.periodguid == period.guid)
                                            {
                                                nextMeeting =m;
                                                System.Diagnostics.Debug.WriteLine("Date trouvée " + m.dtstart);
                                                sb.Append("<div>Date trouvée " + m.dtstart + " ... added</div>");
                                                break;  
                                            }
                                        }
                                        if(nextMeeting==null)
                                        {
                                            System.Diagnostics.Debug.WriteLine("Meeting a créer " + startdate.ToString("dd/MM/yyyy ") + period.start);
                                            
                                            nextMeeting = Yemon.dnn.Functions.DeepCopy<Meeting>(meeting);
                                            nextMeeting.templateguid = nextMeeting.guid;
                                            nextMeeting.guid = Guid.NewGuid();
                                            nextMeeting.dtrevision = DateTime.Now;
                                            nextMeeting.type = "unitary";
                                            nextMeeting.dtstart = DateTime.Parse(startdate.ToString("yyyy-MM-dd ")+period.start+":00");
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
                                                Functions.Error (new Exception("Erreur insertion meeting"+Environment.NewLine+Functions.Serialize(nextMeeting)));
                                            }

                                        }
                                    }
                                    
                                }
                                startdate = startdate.AddDays(1);
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
                    string txtNotif1 = "" + Yemon.dnn.Helpers.GetItem("meeting:msgNotif1");
                    List<Member> members = DataMapping.ListMembers(club.cric);

                    DataTable users = Yemon.dnn.DataMapping.ExecSql("SELECT * FROM ais_meetings_users WHERE meetingguid='" + meeting.guid + "'");

                    foreach (Member m in members)
                    {
                        bool ok = false;

                        if (meeting.notificationtype == "S" && m.satellite_member == Const.YES)
                            ok = true;
                        if (meeting.notificationtype == "M" && m.satellite_member != Const.YES)
                            ok = true;
                        if (meeting.notificationtype == "A")
                            ok = true;

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

                                    string body = txtNotif1.Replace("#meeting.dtstart#", meeting.dtstart.ToString("dd/MM/yyyy - HH:mm"));
                                    body = body.Replace("#meeting.dtend#", meeting.dtend.ToString("dd/MM/yyyy - HH:mm"));
                                    body = body.Replace("#meeting.name#", meeting.name);
                                    body = body.Replace("#meeting.link#", Const.DISTRICT_URL + "/m-" + meeting.link + "?useridguid=" + useridguid);
                                    body = body.Replace("#meeting.sharelink#", Const.DISTRICT_URL + "/m-" + meeting.link);

                                    if (notifications_debug_dest != "")
                                        Yemon.dnn.Functions.SendMail(club.email, notifications_debug_dest, "[" + club.name + "] Notification de réunion", body);
                                    else
                                        Yemon.dnn.Functions.SendMail(club.email, m.email, "[" + club.name + "] Notification de réunion", body);

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

/// <summary>
/// Scheduler de création des réunions périodiques
/// </summary>
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

/// <summary>
/// Scheduler d'envoi des notificationss de réunions
/// </summary>
public class MeetingNotifications : SchedulerClient
{
    public MeetingNotifications(ScheduleHistoryItem oItem) : base()
    {
        this.ScheduleHistoryItem = oItem;
    }

    public override void DoWork()
    {
        string taskname = "" + this.ScheduleHistoryItem.FriendlyName.ToLower();

        try
        {

            // do some work           
            this.ScheduleHistoryItem.AddLogNote("<div>Doing notifications</div>");
            string result = Meeting.DoNotifications();
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