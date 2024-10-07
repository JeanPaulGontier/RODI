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
/// Scheduler de création des réunions périodiques
/// </summary>
public class RotaryScheduler : SchedulerClient
{
    public RotaryScheduler(ScheduleHistoryItem oItem) : base()
    {
        this.ScheduleHistoryItem = oItem;
    }

    public override void DoWork()
    {
        string taskname = "" + this.ScheduleHistoryItem.FriendlyName.ToLower();

        try
        {

            // do some work
            if(taskname.Contains("clubs"))
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Doing Rotary Club Synchro</div>");
                string result = RotaryHelper.SynchroClubs();
                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            

        }
        catch (Exception exc)
        {
            this.ScheduleHistoryItem.Succeeded = false;
            this.ScheduleHistoryItem.AddLogNote("<div>Failed: " + exc.Message + "</div>");
            this.Errored(ref exc);

        }

    }


}