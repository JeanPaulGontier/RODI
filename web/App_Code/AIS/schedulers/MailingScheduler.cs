﻿using AIS;
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
/// Scheduler de mailing
/// </summary>
public class MailingScheduler : SchedulerClient
{
    public MailingScheduler(ScheduleHistoryItem oItem) : base()
    {
        this.ScheduleHistoryItem = oItem;
    }

    public override void DoWork()
    {
        string taskname = "" + this.ScheduleHistoryItem.FriendlyName.ToLower();

        try
        {

            // do some work
            this.ScheduleHistoryItem.AddLogNote("<div>Doing mailings tests</div>");
            string result = Mailing.DoTest();
            this.ScheduleHistoryItem.AddLogNote(result);
            this.ScheduleHistoryItem.Succeeded = true;

        }
        catch (Exception exc)
        {
            this.ScheduleHistoryItem.Succeeded = false;
            this.ScheduleHistoryItem.AddLogNote("<div>Failed: " + exc.Message + "</div>");
            this.Errored(ref exc);

        }

        try
        {

            // do some work
            this.ScheduleHistoryItem.AddLogNote("<div>Doing mailings preparation</div>");
            string result = Mailing.DoPrepare();
            this.ScheduleHistoryItem.AddLogNote(result);            
            this.ScheduleHistoryItem.Succeeded = true;

        }
        catch (Exception exc)
        {
            this.ScheduleHistoryItem.Succeeded = false;
            this.ScheduleHistoryItem.AddLogNote("<div>Failed: " + exc.Message + "</div>");
            this.Errored(ref exc);

        }

        try
        {

            // do some work
            this.ScheduleHistoryItem.AddLogNote("<div>Doing mailings sending</div>");
            string result = Mailing.DoSend();
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
