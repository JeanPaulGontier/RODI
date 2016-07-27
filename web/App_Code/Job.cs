using DotNetNuke.Services.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Job
/// </summary>
public class Job : SchedulerClient
{
    public Job(ScheduleHistoryItem oItem) : base()
    {
        ScheduleHistoryItem = oItem;
    }

    public override void DoWork()
    {
        try
        {
            //Enable logging and show that the job truly started
            Progressing();

            //Your code goes here
            //In order to execute may tasks together, you can create Workers
            //To log note
            //ScheduleHistoryItem.AddLogNote("note");

            //Show success
            ScheduleHistoryItem.Succeeded = true;
        }
        catch (Exception ex)
        {
            ScheduleHistoryItem.Succeeded = false;
            ScheduleHistoryItem.AddLogNote("Exception ...");
            
            Errored(ref ex);
            DotNetNuke.Services.Exceptions.Exceptions.LogException(ex);
        }
    
    }
    
}