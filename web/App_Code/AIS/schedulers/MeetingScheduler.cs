using AIS;
using Aspose.Cells;
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
            string result = MeetingHelper.DoPeriodics();
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
            string result = MeetingHelper.DoNotifications();
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