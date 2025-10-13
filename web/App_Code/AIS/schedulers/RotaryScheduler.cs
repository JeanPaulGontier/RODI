#region Copyrights

//
// RODI - https://rodi-platform.org
// Copyright (c) 2012-2025
// by SARL AIS : https://www.aisdev.net
// supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730)
//
//GNU LESSER GENERAL PUBLIC LICENSE
//Version 3, 29 June 2007 Copyright (C) 2007
//Free Software Foundation, Inc. <http://fsf.org/> Everyone is permitted to copy and distribute verbatim copies of this license document, but changing it is not allowed.
//This version of the GNU Lesser General Public License incorporates the terms and conditions of version 3 of the GNU General Public License, supplemented by the additional permissions listed below.

//0. Additional Definitions.

//As used herein, "this License" refers to version 3 of the GNU Lesser General Public License, and the "GNU GPL" refers to version 3 of the GNU General Public License.
//"The Library" refers to a covered work governed by this License, other than an Application or a Combined Work as defined below.
//An "Application" is any work that makes use of an interface provided by the Library, but which is not otherwise based on the Library.Defining a subclass of a class defined by the Library is deemed a mode of using an interface provided by the Library.
//A "Combined Work" is a work produced by combining or linking an Application with the Library. The particular version of the Library with which the Combined Work was made is also called the "Linked Version".
//The "Minimal Corresponding Source" for a Combined Work means the Corresponding Source for the Combined Work, excluding any source code for portions of the Combined Work that, considered in isolation, are based on the Application, and not on the Linked Version.
//The "Corresponding Application Code" for a Combined Work means the object code and/or source code for the Application, including any data and utility programs needed for reproducing the Combined Work from the Application, but excluding the System Libraries of the Combined Work.

//1. Exception to Section 3 of the GNU GPL.

//You may convey a covered work under sections 3 and 4 of this License without being bound by section 3 of the GNU GPL.

//2. Conveying Modified Versions.

//If you modify a copy of the Library, and, in your modifications, a facility refers to a function or data to be supplied by an Application that uses the facility (other than as an argument passed when the facility is invoked), then you may convey a copy of the modified version:
//a) under this License, provided that you make a good faith effort to ensure that, in the event an Application does not supply the function or data, the facility still operates, and performs whatever part of its purpose remains meaningful, or
//b) under the GNU GPL, with none of the additional permissions of this License applicable to that copy.

//3. Object Code Incorporating Material from Library Header Files.

//The object code form of an Application may incorporate material from a header file that is part of the Library. You may convey such object code under terms of your choice, provided that, if the incorporated material is not limited to numerical parameters, data structure layouts and accessors, or small macros, inline functions and templates(ten or fewer lines in length), you do both of the following:
//a) Give prominent notice with each copy of the object code that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the object code with a copy of the GNU GPL and this license document.

//4. Combined Works.

//You may convey a Combined Work under terms of your choice that, taken together, effectively do not restrict modification of the portions of the Library contained in the Combined Work and reverse engineering for debugging such modifications, if you also do each of the following:
//a) Give prominent notice with each copy of the Combined Work that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the Combined Work with a copy of the GNU GPL and this license document.
//c) For a Combined Work that displays copyright notices during execution, include the copyright notice for the Library among these notices, as well as a reference directing the user to the copies of the GNU GPL and this license document.
//d) Do one of the following:
//0) Convey the Minimal Corresponding Source under the terms of this License, and the Corresponding Application Code in a form suitable for, and under terms that permit, the user to recombine or relink the Application with a modified version of the Linked Version to produce a modified Combined Work, in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.
//1) Use a suitable shared library mechanism for linking with the Library. A suitable mechanism is one that (a) uses at run time a copy of the Library already present on the user's computer system, and (b) will operate properly with a modified version of the Library that is interface-compatible with the Linked Version.
//e) Provide Installation Information, but only if you would otherwise be required to provide such information under section 6 of the GNU GPL, and only to the extent that such information is necessary to install and execute a modified version of the Combined Work produced by recombining or relinking the Application with a modified version of the Linked Version. (If you use option 4d0, the Installation Information must accompany the Minimal Corresponding Source and Corresponding Application Code. If you use option 4d1, you must provide the Installation Information in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.)

//5. Combined Libraries.

//You may place library facilities that are a work based on the Library side by side in a single library together with other library facilities that are not Applications and are not covered by this License, and convey such a combined library under terms of your choice, if you do both of the following:
//a) Accompany the combined library with a copy of the same work based on the Library, uncombined with any other library facilities, conveyed under the terms of this License.
//b) Give prominent notice with the combined library that part of it is a work based on the Library, and explaining where to find the accompanying uncombined form of the same work.

//6. Revised Versions of the GNU Lesser General Public License.

//The Free Software Foundation may publish revised and/or new versions of the GNU Lesser General Public License from time to time. Such new versions will be similar in spirit to the present version, but may differ in detail to address new problems or concerns.
//Each version is given a distinguishing version number. If the Library as you received it specifies that a certain numbered version of the GNU Lesser General Public License "or any later version" applies to it, you have the option of following the terms and conditions either of that published version or of any later version published by the Free Software Foundation. If the Library as you received it does not specify a version number of the GNU Lesser General Public License, you may choose any version of the GNU Lesser General Public License ever published by the Free Software Foundation.
//If the Library as you received it specifies that a proxy can decide whether future versions of the GNU Lesser General Public License shall apply, that proxy's public statement of acceptance of any version is permanent authorization for you to choose that version for the Library.

#endregion Copyrights
using AIS;
using DotNetNuke.Services.Scheduling;
using ExifLib;
using System;
using System.Text;

/// <summary>
/// Scheduler de création des réunions périodiques
/// </summary>
public class RotaryScheduler : SchedulerClient
{
    public RotaryScheduler(ScheduleHistoryItem oItem) : base()
    {
        this.ScheduleHistoryItem = oItem;
    }
    
    /// <summary>
    /// clubs : récupère les clubs de my rotary
    /// members : récupère les membres de my rotary
    /// officers : récupère les affectation de my rotary
    /// ucm : Update Clubs Members, met à jour les membres des clubs a partir des members récupérés de my rotary
    /// uco : Update Clubs Officers, met à jour les affectations des clubs des années n et n+1 
    /// ump : Update Members Profiles, récupère les données complémentaires des membres
    /// couu : Create Or Update Users, crée ou met à jour les logins des membres
    /// mac : Mise à jour Affectations Clubs, mets à jour les rôles des membres pour les clubs en fonctions de leurs affectations rotariennes
    /// puu : Purge Unused Users, supprime les logins devenus inutiles suites aux changements de mails des membres
    /// pdm : Purge Dupplicate Members, supprime les membres en double
    /// rpm : Reaffect Photos Members, réaffecte les photos des membres
    /// </summary>
    public override void DoWork()
    {
        string taskname = "" + this.ScheduleHistoryItem.FriendlyName.ToLower();

        try
        {
            #region sécurité pour empecher plusieurs execution simultanées du scheduler
            var lastExec = Yemon.dnn.Helpers.GetItem("scheduler:"+taskname);
            if (lastExec != null)
            {
                DateTime lastTime =(DateTime)Functions.Deserialize(""+lastExec,typeof(DateTime));
                if(lastTime.AddHours(1)>DateTime.Now)
                {
                    throw new Exception("La tâche : "+taskname+" a déjà été lancée le "+lastTime.ToLongTimeString());
                }
            }
            Yemon.dnn.Helpers.SetItem("scheduler:"+taskname, Functions.Serialize(DateTime.Now), "-1", keephistory: false, portalid: Yemon.dnn.Functions.GetPortalId());

            #endregion

            StringBuilder sb = new StringBuilder();
            if(Const.ROTARY_SYNCHRO_LOG)
            {

            }
            bool error=false;
            // do some work
            if(taskname.Contains("clubs"))
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Rotary Club Synchro</div>");
                string result = RotaryHelper.SynchroClubs();
                if(Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if (taskname.Contains("terminated") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Rotary Members Terminated Synchro</div>");
                string result = RotaryHelper.SynchroMembersTerminated();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if (taskname.Contains("members") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Rotary Members Synchro</div>");
                string result = RotaryHelper.SynchroMembers();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            
            if (taskname.Contains("officers") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Rotary Officers Synchro</div>");
                string result = RotaryHelper.SynchroOfficers();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if (taskname.Contains("ucm") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Update Club Members</div>");
                string result = RotaryHelper.UpdateClubsMembers();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if (taskname.Contains("uco") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Update Club Officers</div>");
                string result = RotaryHelper.UpdateClubsOfficers();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }          
            if (taskname.Contains("ump") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Update Members Profiles</div>");
                string result = RotaryHelper.UpdateMembersProfiles();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if (taskname.Contains("couu") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Création ou MAJ Users</div>");
                string result = DataMapping.CreateOrUpdateUsers();
                if (Const.ROTARY_SYNCHRO_LOG)
                    sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if (taskname.Contains("mac") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Mise à jour affectations clubs</div>");
                string result = DataMapping.UpdateClubAffectations();
                if (Const.ROTARY_SYNCHRO_LOG)
                    if (Const.ROTARY_SYNCHRO_FULL_LOG || result.Contains("erreur"))
                        sb.Append(result);

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if(taskname.Contains("puu") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Suppression login inutilisés</div>");
                string result = DataMapping.DeleteUnusedLogins();
                if (Const.ROTARY_SYNCHRO_LOG)
                {
                    if(Const.ROTARY_SYNCHRO_FULL_LOG || result.Contains("erreur"))
                        sb.Append(result);                  

                }

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if (taskname.Contains("pdm") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Suppression duplicate members</div>");
                string result = DataMapping.PurgeDuplicateMembers();
                if (Const.ROTARY_SYNCHRO_LOG)
                {
                    if (Const.ROTARY_SYNCHRO_FULL_LOG || result.Contains("erreur"))
                        sb.Append(result);

                }

                error = error || sb.ToString().ToLower().Contains("erreur");

                this.ScheduleHistoryItem.AddLogNote(result);
                this.ScheduleHistoryItem.Succeeded = true;
            }
            if (taskname.Contains("rpm") && !error)
            {
                this.ScheduleHistoryItem.AddLogNote("<div>Réaffectation des photos membres</div>");
                string result = DataMapping.ReaffectPhotoMembers();
                if (Const.ROTARY_SYNCHRO_LOG)
                {
                    if (Const.ROTARY_SYNCHRO_FULL_LOG || result.Contains("erreur"))
                        sb.Append(result);

                }

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

            Yemon.dnn.Helpers.DeleteItem("scheduler:"+taskname,purgeHistory:true);

        }
        catch (Exception exc)
        {
            this.ScheduleHistoryItem.Succeeded = false;
            this.ScheduleHistoryItem.AddLogNote("<div>Failed: " + exc.Message + "</div>");
            this.Errored(ref exc);

        }

    }


}