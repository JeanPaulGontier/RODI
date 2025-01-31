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
using Telerik.Web.UI.com.hisoftware.api2;

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
            StringBuilder sb = new StringBuilder();
            if(Const.ROTARY_SYNCHRO_LOG)
            {

            }
            bool error=false;
            // do some work
            if(taskname.Contains("clubs"))
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Doing Rotary Club Synchro</div>");
                string result = RotaryHelper.SynchroClubs();
                if(Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }

            if (taskname.Contains("officers") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Doing Rotary Officers Synchro</div>");
                string result = RotaryHelper.SynchroOfficers();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }

            if (taskname.Contains("members") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Doing Rotary Members Synchro</div>");
                string result = RotaryHelper.SynchroMembers();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }

            if (taskname.Contains("uco") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Doing Update Club Officers</div>");
                string result = RotaryHelper.UpdateClubsOfficers();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }

            if (taskname.Contains("ucm") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Doing Update Club Members</div>");
                string result = RotaryHelper.UpdateClubsMembers();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }

            if (taskname.Contains("ump") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Doing Update Members Profiles</div>");
                string result = RotaryHelper.UpdateMembersProfiles();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }

            if (taskname.Contains("couu") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Doing Création ou MAJ Users</div>");
                string result = DataMapping.CreateOrUpdateUsers();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }

            if (taskname.Contains("mac") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Doing Mise à jour affectations clubs</div>");
                string result = DataMapping.UpdateClubAffectations();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if(taskname.Contains("puu") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Doing suppression login inutilisés</div>");
                string result = DataMapping.DeleteUnusedLogins();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if (Const.ROTARY_SYNCHRO_LOG)
            {
                string log = sb.ToString();
                if(log.ToLower().Contains("erreur")){
                    Functions.SendMail(Const.ROTARY_SYNCHRO_LOG_EMAIL, "[" + Const.DISTRICT_ID + "] Synchro RI Logs", log);
                }
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