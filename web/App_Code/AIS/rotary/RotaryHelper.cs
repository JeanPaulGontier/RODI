#region Copyrights

//
// RODI - https://rodi-platform.org
// Copyright (c) 2024
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
using AIS.SIPro.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;
using DotNetNuke.Entities.Portals;
using System.IO;
using System.Globalization;
using DotNetNuke.Entities.Users;


/// <summary>
/// Description résumée de RotaryHelper
/// </summary>
public class RotaryHelper
{
    private static Rotary.Parametres _param;

    public static Rotary.Parametres GetParametres()
    {
        var item = Yemon.dnn.Helpers.GetItem("RotaryParametres", 0);
        if (item == null) return null;
        return Yemon.dnn.Functions.Deserialize<Rotary.Parametres>("" + item); ;
    }

    public static Auth_Token API_AUTH_TOKEN
    {
        get
        {

            var item = "" + Yemon.dnn.Helpers.GetItem("RotaryAuthToken", 0);
            if (item == null)
                return null;
            return Yemon.dnn.Functions.Deserialize<Auth_Token>("" + item); ;

        }
        set
        {
            Yemon.dnn.Helpers.SetItem("RotaryAuthToken", Yemon.dnn.Functions.Serialize(value), "", keephistory: false);
        }
    }

    public static string Test_Auth()
    {
        try
        {
            _param = GetParametres();
            StringBuilder sb = new StringBuilder();
            var task = Task.Run(() => CallAsyncLogin());
            task.Wait();

            if (API_AUTH_TOKEN == null || !task.Result)
            {
                return "Erreur de login";
            }

            return "Connexion réalisée avec succès";
        }
        catch (Exception ee)
        {

            return ee.ToString();
        }
    }

    public static List<Rotary.Club> Get_Clubs(out string result)
    {
        result = null;
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("/v1.1/clubs"));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération clubs");
            }
            result = task.Result;
            List<Rotary.Club> clubs = Yemon.dnn.Functions.Deserialize<List<Rotary.Club>>(task.Result);
            clubs = clubs.Where(c => c.DistrictId == Const.DISTRICT_ID).ToList();

            return clubs;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="clubtype">Rotary Club, Rotaract Club</param>
    /// <param name="cric"></param>
    /// <param name="membertype">Active</param>
    /// <returns></returns>
    /// 
    public static Rotary.Club Get_Club_Profile(string clubtype, int cric, out string result)
    {
        result = null;
        try
        {
            _param = GetParametres();
            string url = "/v1.1/clubs/" + clubtype + "/" + cric;

            var task = Task.Run(() => CallAsyncGet(url));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération profil du club");
            }
            result = task.Result;

            Rotary.Club members = Yemon.dnn.Functions.Deserialize<Rotary.Club>(task.Result);

            return members;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    public static Rotary.Club_Members Get_Club_Members_Active(string clubtype, int cric, out string result)
    {
        result = null;
        try
        {
            _param = GetParametres();
            string url = "/v1.2/clubs/" + clubtype + "/" + cric + "/members/0/10000/active";

            var task = Task.Run(() => CallAsyncGet(url));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération membres du club");
            }
            result = task.Result;

            Rotary.Club_Members members = Yemon.dnn.Functions.Deserialize<Rotary.Club_Members>(task.Result);

            return members;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    public static List<Rotary.Member> Get_Club_Members(string clubtype, int cric, string membertype, out string result)
    {
        result = null;
        try
        {
            _param = GetParametres();

            var task = Task.Run(() => CallAsyncGet("/v1.1/clubs/" + clubtype + "/" + cric + "/members/" + membertype));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération membres du club");
            }
            result = task.Result;

            List<Rotary.Member> members = Yemon.dnn.Functions.Deserialize<List<Rotary.Member>>(task.Result);

            return members;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    public static List<Rotary.Club.Officer> Get_Club_Officers(int cric, string clubtype, out string result)
    {
        result = null;
        try
        {
            int rotaryyear = Functions.GetRotaryYear();
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("/v1.1/clubs/" + clubtype + "/" + cric + "/officers?startDate=07-01-"+rotaryyear+"&endDate=07-01-"+(rotaryyear+2)));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération clubs");
            }
            result = task.Result;
            List<Rotary.Club.Officer> members = Yemon.dnn.Functions.Deserialize<List<Rotary.Club.Officer>>(task.Result);

            return members;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    public static Rotary.Profile Get_Member_Profile(int nim, out string result)
    {
        result = null;
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("/v1.1/individuals/" + nim + "/profile"));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération profil membre " + nim);
            }
            result = task.Result;
            Rotary.Profile member = Yemon.dnn.Functions.Deserialize<Rotary.Profile>(task.Result);

            return member;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    public static Rotary.Profile Get_Member_Recognition(int nim, out string result)
    {
        result = null;
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("/v1.1/individuals/" + nim + "/recognition"));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération membre recognition " + nim);
            }
            result = task.Result;
            Rotary.Profile member = Yemon.dnn.Functions.Deserialize<Rotary.Profile>(task.Result);

            return member;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    public static List<Rotary.Profile.Language> Get_Member_Languages(int nim, out string result)
    {
        result = null;
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("/v1.1/individuals/" + nim + "/languages"));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération membre languages " + nim);
            }
            result = task.Result;
            List<Rotary.Profile.Language> languages = Yemon.dnn.Functions.Deserialize<List<Rotary.Profile.Language>>(task.Result);

            return languages;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    public static List<Rotary.Sponsor> Get_Member_Sponsors(int nim, int cric, string clubtype, out string result)
    {
        result = null;
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("/v1.1/individuals/" + nim + "/clubs/"+clubtype+"/"+cric+"/sponsors"));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération membre sponsors " + nim+ " "+clubtype+" "+cric);
            }
            result = task.Result;
            List<Rotary.Sponsor> sponsors = Yemon.dnn.Functions.Deserialize<List<Rotary.Sponsor>>(task.Result);

            return sponsors;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    public static List<int> Get_Members_To_Update(DateTime start,DateTime end, out string result)
    {
        result = null;
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("/v1.1/individuals/updates?startDate="+start.ToString("yyyy-MM-dd")+"&endDate="+end.ToString("yyyy-MM-dd")));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération clubs");
            }
            result = task.Result;
            var updates = Yemon.dnn.Functions.Deserialize<List<Rotary.Update>>(task.Result);
            var nims = new List<int>();
            foreach (var u in updates)
            {
                if(!nims.Contains(u.MemberId))
                    nims.Add(u.MemberId);
            }
            return nims;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }
    public static List<Rotary.Role> Get_Member_Roles(int nim, out string result)
    {
        result = null;
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("/v1.2/clubs/members/" + nim + "/roles"));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération membre roles " + nim);
            }
            result = task.Result;
            List<Rotary.Role> roles = Yemon.dnn.Functions.Deserialize<List<Rotary.Role>>(task.Result);

            return roles;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }

    public static async Task<bool> CallAsyncLogin()
    {
        HttpClient httpClient = new HttpClient();

        var body = @"{" +
                        "'Username': '" + _param.api_username + "'," +
                        "'Password': '" + _param.api_password + "'" +
                    "}";


        var content = new StringContent(body, Encoding.UTF8, "application/json");

        var result = await httpClient.PostAsync(_param.url_api + "/v1.1/authentication", content);
        if (result.IsSuccessStatusCode)
        {
            string t = result.Content.ReadAsStringAsync().Result;
            API_AUTH_TOKEN = Yemon.dnn.Functions.Deserialize<Auth_Token>(t);
            return true;
        }

        API_AUTH_TOKEN = null;
        return false;
    }

    public static async Task<string> CallAsyncGet(string url)
    {
        bool firstime = true;
    retry:
        HttpClient httpClient = new HttpClient();
        if (API_AUTH_TOKEN != null)
        {
            httpClient.DefaultRequestHeaders.Add("Auth_Token", "" + API_AUTH_TOKEN.auth_token);
        }
        else
        {
            var task = Task.Run(() => CallAsyncLogin());
            task.Wait();

            if (task.Result)
                goto retry;
            else
                return null;
        }


        var result = await httpClient.GetAsync(_param.url_api + url);

        if (!result.IsSuccessStatusCode && firstime)
        {
            firstime = false;

            var task = Task.Run(() => CallAsyncLogin());
            task.Wait();

            if (task.Result)
                goto retry;
            else
                return null;
        }

        if (result.IsSuccessStatusCode)
        {
            string t = result.Content.ReadAsStringAsync().Result;

            return t;
        }

        return null;
    }

    public class Auth_Token
    {
        public string auth_token { get; set; }
    }


    public static string SynchroClubs()
    {

        Yemon.dnn.DataMapping.ExecSqlNonQuery("truncate table ais_ri_club");

        string result = "";
        string res = "";
        var clubs = Get_Clubs(out res);


        if (clubs == null)
            return "<p style='color:red'>Erreur récupération des clubs RI annulation synchro Clubs</p>";

        
        //var dbclubs = Yemon.dnn.DataMapping.ExecSql<Rotary.Club>(new SqlCommand("select * from ais_ri_club"));
        foreach (var club in clubs)
        {            
            var row = new Dictionary<string, object>();

            //var dbclub = dbclubs.Find(c => c.ClubId == club.ClubId);
            //if (dbclub != null)
            //    row["id"] = dbclub.id;
            row["clubid"] = club.ClubId;
            row["clubtype"] = club.ClubType;
            row["clubsubtype"] = club.ClubSubType;
            row["clubname"] = club.ClubName;
            row["clubcountry"] = club.ClubCountry;
            row["districtid"] = club.DistrictId;
            row["membercount"] = club.MemberCount;
            row["honorarymembercount"] = club.HonoraryMemberCount;
            row["dtlastupdate"] = DateTime.Now;

            var r = Yemon.dnn.DataMapping.UpdateOrInsertRecord("ais_ri_club", "id", row);
            if (r.Key != "error")
            {
                if (Const.ROTARY_SYNCHRO_FULL_LOG)
                    result += "<p>" + club.ClubId + " : " + club.ClubName + "</p>";

                SqlCommand sql = new SqlCommand("update ais_clubs set rotary_agreement_date=@rotary_agreement_date where cric=@cric");
                sql.Parameters.AddWithValue("cric", club.ClubId);

                if (club.requestorOrganizations.Count > 0)
                {
                    sql.Parameters.AddWithValue("rotary_agreement_date", (DateTime)club.requestorOrganizations[0].LastUpdated);
                    Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);
                }


            }

            else
                result += "<p style='color:red'>ERREUR : " + club.ClubId + " : " + club.ClubName + "</p>";


        }

        result += "<p>"+clubs.Count + " récupéré(s)</p>";

        return result;
    }

    public static string SynchroMembers()
    {
        Yemon.dnn.DataMapping.ExecSqlNonQuery("truncate table ais_ri_member");

        string result = "";
        var clubs = Yemon.dnn.DataMapping.ExecSql<Rotary.Club>(new SqlCommand("select * from ais_ri_club"));
        if(clubs.Count==0){
            return "<div style='color:red'>Aucun club issu du RI annulation synchro Members</div>" + Environment.NewLine;
        }
        // var dbmembers = Yemon.dnn.DataMapping.ExecSql<Rotary.Member>(new SqlCommand("select * from ais_ri_member"));
       

        foreach (var club in clubs)
        {
            string res = "";
            var members = Get_Club_Members_Active(club.ClubType, club.ClubId, out res);
            Yemon.dnn.DataMapping.ExecSqlNonQuery("delete from ais_ri_member where clubid=" + club.ClubId);
            if (members != null)
            {

                foreach (var member in members.ClubMembers)
                {
                    var row = new Dictionary<string, object>();
                    //var dbmember = dbmembers.Find(c => c.MemberId == member.MemberId && c.IsHonoraryMember == member.IsHonoraryMember());
                    //if (dbmember != null)
                    //    row["id"] = dbmember.id;

                    row["memberid"] = member.MemberId;
                    row["clubid"] = club.ClubId;
                    row["membertype"] = "active";
                    row["firstname"] = member.FirstName;
                    row["lastname"] = member.LastName;
                    row["suffix"] = member.Suffix;
                    row["ishonorarymember"] = member.IsHonoraryMember();
                    row["issatellitemember"] = member.IsSatelliteMember();
                    row["dtlastupdate"] = member.DtLastUpdate();
                    row["profile"] = Yemon.dnn.Functions.Serialize(member);


                    var r = Yemon.dnn.DataMapping.UpdateOrInsertRecord("ais_ri_member", "id", row);
                    if (r.Key != "error")
                    {
                        if (Const.ROTARY_SYNCHRO_FULL_LOG)
                            result += "<p>" + club.ClubId + " : " + club.ClubName + " : " + member.FirstName + " " + member.LastName + "</p>";
                    }
                    else
                        result += "<p style='color:red'>ERREUR : " + club.ClubId + " : " + club.ClubName + " : " + member.FirstName + " " + member.LastName + "</p>";
                }
            }else {
                result += "<p style='color:red'>ERREUR : " + club.ClubId + " impossible récupérer members</p>";
            }
        }
        return result;
    }

    public static string SynchroOfficers()
    {
        Yemon.dnn.DataMapping.ExecSqlNonQuery("truncate table ais_ri_officer");

        string result = "";
        var clubs = Yemon.dnn.DataMapping.ExecSql<Rotary.Club>(new SqlCommand("select * from ais_ri_club"));
        if (clubs == null)
            return "<p style='color:red'>Aucun club issu du RI annulation synchro Officers</p>";

        // var dbofficers = Yemon.dnn.DataMapping.ExecSql<Rotary.Club.Officer>(new SqlCommand("select * from ais_ri_officer"));
        foreach (var club in clubs)
        {
            Yemon.dnn.DataMapping.ExecSqlNonQuery("delete from ais_ri_officer where clubid=" + club.ClubId);
            string res = "";
            var officers = Get_Club_Officers(club.ClubId, club.ClubType, out res);
            if(officers!=null)
            {

                foreach (var officer in officers)
                {
                    var row = new Dictionary<string, object>();
                    //var dbofficer = dbofficers.Find(c => c.MemberId == officer.MemberId);
                    //if (dbofficer != null)
                    //    row["id"] = dbofficer.id;

                    row["memberid"] = officer.MemberId;
                    row["clubid"] = officer.ClubId;
                    row["officerrole"] = officer.OfficerRole;
                    row["startdate"] = officer.StartDate;
                    row["enddate"] = officer.EndDate;
                    row["clubname"] = officer.ClubName;
                    row["firstname"] = officer.FirstName;
                    row["lastname"] = officer.LastName;
                    row["middlename"] = officer.MiddleName;
                    row["suffix"] = officer.Suffix;
                    row["key"] = officer.Key;
                    row["lastupdated"] = officer.LastUpdated;
                    row["dtlastupdate"] = DateTime.Now;

                    var r = Yemon.dnn.DataMapping.UpdateOrInsertRecord("ais_ri_officer", "id", row);
                    if (r.Key != "error")
                    {                        
                        if(Const.ROTARY_SYNCHRO_FULL_LOG)
                            result += "<p>" + club.ClubId + " : " + club.ClubName + " : " + officer.MemberId + " " + officer.FirstName + " " + officer.LastName + " : " + officer.OfficerRole + "</p>";                      
                    }
                    else
                        result += "<p style='color:red'>ERREUR : " + club.ClubId + " : " + club.ClubName + " : " + officer.MemberId + " " + officer.FirstName + " " + officer.LastName + " : " + officer.OfficerRole + "</p>";
                }
            } else {
                result += "<p style='color:red'>ERREUR : " + club.ClubId + " impossible de récupérer les officers</p>";
            }
            

        }        
        return result;
    }

    public static string UpdateClubsOfficers()
    {
        var existingRiofficers = Yemon.dnn.DataMapping.ExecSql<Rotary.Club.Officer>(new SqlCommand("select * from ais_ri_officer"));
        if (existingRiofficers == null || existingRiofficers.Count==0)
            return "<p style='color:red'>Aucun officer club issu du RI annulation synchro Officers</p>";

        Dictionary<string, string> fl = new Dictionary<string, string>();
        fl.Add("Rotaract Advisor", "Administration");
        fl.Add("Club Public Image Chair", "Délégué Communication");
        fl.Add("Rotaract Public Image Chair", "Délégué Communication");
        fl.Add("Club Membership Chair", "Effectif");
        fl.Add("Rotaract Membership Chair", "Effectif");
        fl.Add("Club Foundation Chair", "Fondation Rotary");
        fl.Add("Rotaract Foundation Chair", "Fondation Rotary");
        fl.Add("Club President", "Président");
        fl.Add("Rotaract President", "Président");
        fl.Add("Club Secretary", "Secrétaire");
        fl.Add("Rotaract Secretary", "Secrétaire");
       
        fl.Add("Club Treasurer", "Trésorier");
        fl.Add("Rotaract Treasurer", "Trésorier");
        fl.Add("Club Service Projects Chair", "Responsable Actions");
        fl.Add("Rotaract Service Projects Chair", "Responsable Actions");
        fl.Add("Club Learning Facilitator", "Responsable Formation");
        fl.Add("Club Vice President", "Vice Président");

        // nouveau roles au 08/01/2024
        fl.Add("Club Executive Secretary/Director (Facultatif)", "Secrétaire Exécutif");
        fl.Add("Club Executive Secretary/Director(Facultatif)", "Secrétaire Exécutif");
        // nouveaux roles au 25/11/2024
        fl.Add("Club Executive Secretary/Director", "Secrétaire Exécutif");
        fl.Add("Club Young Leaders Contact", "Délégué Jeunesse");
        fl.Add("Rotaract Vice President", "Vice Président");
        fl.Add("Rotaract Learning Facilitator", "Responsable Formation");
        fl.Add("Rotaract Young Leaders Contact", "Délégué Jeunesse");
       



        var members = DataMapping.ListMembers(max: int.MaxValue);
        var clubs = DataMapping.ListClubs().FindAll(c => c.rotary_agreement_date != null && c.rotary_agreement_type != "").OrderBy(c => c.club_type).ThenBy(c => c.name).ToList(); 
        string result = "";
        foreach (var club in clubs)
        {
            if (Const.ROTARY_SYNCHRO_FULL_LOG)
                result += "<p><strong>"+club.name+ " " + club.cric +"</strong></p>";

            var officers = Yemon.dnn.DataMapping.ExecSql<Rotary.Club.Officer>(new SqlCommand("select * from " + Const.TABLE_PREFIX + "ri_officer where clubid=" + club.cric));
            foreach(var officer in officers)
            {
                var member = members.Find(m => m.nim == officer.MemberId);
                if(member == null)
                {
                   // result += "<p style='color:red'>ERREUR membre introuvable : " + officer.OfficerRole + " (" + officer.StartDate.Year + "-" + officer.EndDate.Year + ") : "+ officer.MemberId+" " + officer.FirstName + " " + officer.LastName + "</p>";
                }
                else if (officer.EndDate > DateTime.Now)
                {
                    string localf = null;
                    fl.TryGetValue(officer.OfficerRole, out localf); 
                    if(localf == null)
                    {
                        result += "<p style='color:red'>ERREUR fonction introuvable : " + officer.OfficerRole + " (" + officer.StartDate.Year + "-" + officer.EndDate.Year + ") : " + officer.MemberId + " " + officer.FirstName + " " + officer.LastName + "</p>";
                    }
                    else
                    {
                        if (Const.ROTARY_SYNCHRO_ALLOW_UPDATE && club.rotary_agreement_type == "auto")
                        {

                            var sql = new SqlCommand("delete from " + Const.TABLE_PREFIX + "rya where rotary_year=@year and cric=@cric and [function]=@function");
                            sql.Parameters.AddWithValue("year", officer.StartDate.Year);
                            sql.Parameters.AddWithValue("cric", club.cric);
                            sql.Parameters.AddWithValue("function", localf);
                            int nb= Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);

                            
                            sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "rya ([rotary_year],[function],[cric],[nim],[name],[portalid]) VALUES (@year,@function,@cric,@nim,@name,0)");
                            sql.Parameters.AddWithValue("year", officer.StartDate.Year);
                            sql.Parameters.AddWithValue("cric", club.cric);
                            sql.Parameters.AddWithValue("nim", officer.MemberId);
                            sql.Parameters.AddWithValue("function", localf);
                            sql.Parameters.AddWithValue("name", member.name + " " + member.surname) ;

                            if (Yemon.dnn.DataMapping.ExecSqlNonQuery(sql)>0)
                            {
                                if (Const.ROTARY_SYNCHRO_FULL_LOG)
                                    result += "<p>" + officer.OfficerRole + " (" + officer.StartDate.Year + "-" + officer.EndDate.Year + ") : " + officer.MemberId + " " + officer.FirstName + " " + officer.LastName + "</p>";
                            }
                            else
                            {
                                result += "<p style='color:red'>ERREUR maj bdd : " + officer.OfficerRole + " (" + officer.StartDate.Year + "-" + officer.EndDate.Year + ") : " + officer.MemberId + " " + officer.FirstName + " " + officer.LastName + "</p>";
                            }
                        }
                        else if (Const.ROTARY_SYNCHRO_FULL_LOG)
                        {
                            result += "<p>" + officer.OfficerRole + " (" + officer.StartDate.Year + "-" + officer.EndDate.Year + ") : " + officer.MemberId + " " + officer.FirstName + " " + officer.LastName + "</p>";
                        }

                    }
                   
                }
               
            }
        }
        return result;
    }

    public static string UpdateClubsMembers()
    {
        string result = "";
        string errors = "";

        var existingRiClubs = Yemon.dnn.DataMapping.ExecSql<Rotary.Club>(new SqlCommand("select * from ais_ri_club"));
        if (existingRiClubs == null || existingRiClubs.Count == 0)
        {
            return "<div style='color:red'>Aucun club issu du RI annulation Update Clubs Members (UCM)</div>" + Environment.NewLine;
        }

        var existingRiMembers = Yemon.dnn.DataMapping.ExecSql<Rotary.Member>(new SqlCommand("select * from ais_ri_member"));
        if(existingRiMembers==null || existingRiMembers.Count == 0)
        {
            return "<div style='color:red'>Aucun membre issu du RI annulation Update Clubs Members (UCM)</div>" + Environment.NewLine;
        }

        
        var allclubs = DataMapping.ListClubs();

        Yemon.dnn.DataMapping.ExecSqlNonQuery("delete from " + Const.TABLE_PREFIX + "members where honorary_member='O'");

        var members = DataMapping.ListMembers();

        var listnew = new List<Rotary.Member>();
        var listmaj = new List<Rotary.Member>();
        var listtrf = new List<Rotary.Member>();
        var listdel = new List<Rotary.Member>();

        var listclublog = new List<Rotary.ClubLog>();

        var clubs = DataMapping.ListClubs().FindAll(c => c.rotary_agreement_date != null && c.rotary_agreement_type != "").OrderBy(c => c.club_type).ThenBy(c=>c.name).ToList();
        if(Const.CLUB_SATELLITE_APART) // on ajoute les clubs satellites a la liste des clubs autorisés car ils sont gérés différement du rotary
        {
            var clubssatellites = new List<Club>();
            foreach(var club in clubs){
                int cricsatellite = Functions.GetClubSatellite(club.cric);
                if (cricsatellite > 0)
                {
                    var clubsat = DataMapping.GetClub(cricsatellite);
                    if(clubsat!=null)
                        clubssatellites.Add(clubsat);
                    else
                        errors += "Le club "+club.name+" "+club.cric+" a un club satellite "+cricsatellite+" qui n'a pas été trouvé dans la base"+Environment.NewLine;

                }
            }
            foreach (var club in clubssatellites)
            {
                clubs.Add(club);
            }
        }


        #region phase 1 - recherche des nouveaux membres et des maj

        foreach (var club in clubs)
        {
            var clublog = listclublog.Find(c => c.Cric == club.cric);
            if (clublog == null)
            {
                clublog = new Rotary.ClubLog(club.cric, club.name);
                listclublog.Add(clublog);
            }
            int cricsatellite = Functions.GetClubSatellite(club.cric);

            var rimembers = Yemon.dnn.DataMapping.ExecSql<Rotary.Member>(new SqlCommand("select * from ais_ri_member where IsHonoraryMember=0 and clubid=" + club.cric ));

            var clubmembers = DataMapping.ListMembers(club.cric);
            if (Const.CLUB_SATELLITE_APART && cricsatellite > 0)
            {
                var satclubmembers = DataMapping.ListMembers(cricsatellite);
                foreach (var member in satclubmembers)
                {
                    clubmembers.Add(member);
                }
            }
            foreach (var member in rimembers)
            {
                var m = clubmembers.Find(mm => mm.nim == member.MemberId);
                if (m != null)
                {
                    if (Const.CLUB_SATELLITE_APART && cricsatellite > 0 && member.IsSatelliteMember) // transfert vers club satellite
                    {
                        listtrf.Add(member);
                        clublog.Logs += "<p>Transfert vers club sat " + cricsatellite + " " + member.MemberId + " " + member.FirstName + " " + member.LastName + "</p>";
                    }

                    if (m.dt_update_import_ri_club == null || member.DtLastUpdate > m.dt_update_import_ri_club)
                    {
                        listmaj.Add(member);                        
                    }


                }
                else
                {
                    m = members.Find(mm => mm.nim == member.MemberId);
                    if (m != null)
                    {

                        if (Const.CLUB_SATELLITE_APART && cricsatellite > 0 && member.IsSatelliteMember)
                        {
                            if (m.cric != cricsatellite) // transfert si le membre n'est pas dans le club satellite
                            {
                                listtrf.Add(member);
                                clublog.Logs += "<p>Transfert club " + m.cric + " vers club sat " + cricsatellite + " " + member.MemberId + " " + member.FirstName + " " + member.LastName + "</p>";
                            }
                        }
                        else // transfert d'un autre club
                        {
                            listtrf.Add(member);
                            clublog.Logs += "<p>Transfert du club " + m.cric + " " + member.MemberId + " " + member.FirstName + " " + member.LastName + "</p>";
                        }
                        if (m.dt_update_import_ri_club == null || member.DtLastUpdate > m.dt_update_import_ri_club)
                        {
                            listmaj.Add(member);                            
                        }
                    }
                    else
                    {
                        listnew.Add(member);
                        //clublog.Logs += "<p>Nouveau membre " + member.MemberId + " " + member.FirstName + " " + member.LastName + "</p>";
                    }
                }
            }
        }

        #endregion

        #region phase 2 - transfert des membres 

        foreach (var member in listtrf)
        {
            var m = DataMapping.GetMemberByNim(member.MemberId);

            var club = allclubs.Find(c => c.cric == member.ClubId);

            if (club != null)
            {
                var clublog = listclublog.Find(c => c.Cric == club.cric);
                if (clublog == null)
                {
                    clublog = new Rotary.ClubLog(club.cric, club.name);
                    listclublog.Add(clublog);
                }

                if (member.IsSatelliteMember && Const.CLUB_SATELLITE_APART)
                {
                    int cricsatellite = Functions.GetClubSatellite(member.ClubId);


                    club = allclubs.Find(c => c.cric == cricsatellite);
                    if (club == null)
                    {
                        clublog.Errors += "Club satellite introuvable " + cricsatellite + " transfert membre impossible " + m.nim + " " + m.name + " " + m.surname + Environment.NewLine;
                    }
                    else
                    {
                        m.cric = club.cric;
                        m.club_name = club.name;
                    }

                }
                else
                {
                    m.cric = club.cric;
                    m.club_name = club.name;
                }
                if(member.IsSatelliteMember){
                    m.satellite_member = Const.YES;
                }else{
                    m.satellite_member = Const.NO;
                }
                if(Const.ROTARY_SYNCHRO_ALLOW_UPDATE){
                    if (!DataMapping.UpdateMember(m))
                    {
                        clublog.Errors += "Erreur transfert membre " + member.MemberId + " " + member.FirstName + " " + member.LastName + Environment.NewLine;
                    }
                }                
            }
            else
            {
                errors += "Erreur transfert membre " + member.MemberId + " " + member.FirstName + " " + member.LastName + " club " + member.ClubId + " introuvable " + Environment.NewLine;
            }

        }

        #endregion

        #region phase 3 - membres a effacer

        foreach (var club in clubs)
        {
            var clublog = listclublog.Find(c => c.Cric == club.cric);
            if (clublog == null)
            {
                clublog = new Rotary.ClubLog(club.cric, club.name);
                listclublog.Add(clublog);
            }
            int cricsatellite = Functions.GetClubSatellite(club.cric);


            var clubmembers = DataMapping.ListMembers(club.cric);

            if (Const.CLUB_SATELLITE_APART && cricsatellite > 0)
            {
                var satclubmembers = DataMapping.ListMembers(cricsatellite);
                foreach (var member in satclubmembers)
                {
                    clubmembers.Add(member);
                }
            }

            int cricparent = Functions.GetClubParent(club.cric);

            var rimembers = new List<Rotary.Member>();
            if (Const.CLUB_SATELLITE_APART && cricparent > 0) // on est dans le club satellite donc on prends les membres du club parent
                rimembers = Yemon.dnn.DataMapping.ExecSql<Rotary.Member>(new SqlCommand("select * from " + Const.TABLE_PREFIX + "ri_member where IsHonoraryMember=0 and clubid=" + cricparent));

            else
                rimembers = Yemon.dnn.DataMapping.ExecSql<Rotary.Member>(new SqlCommand("select * from " + Const.TABLE_PREFIX + "ri_member where IsHonoraryMember=0 and clubid=" + club.cric));

            foreach (var member in clubmembers)
            {
                var m = rimembers.Find(mm => mm.MemberId == member.nim);
                if (m == null)
                {
                    listdel.Add(m);
                    if(member.nim>0)
                         clublog.Logs += "<p>Suppression membre " + member.nim + " " + member.name + " " + member.surname + "</p>";
                    if(Const.ROTARY_SYNCHRO_ALLOW_UPDATE && club.rotary_agreement_type=="auto")
                    {
                        if (!DataMapping.DeleteMember(member.id))
                            clublog.Logs += "<p>ERREUR suppression membre " + member.nim + " " + member.name + " " + member.surname + "</p>";
                    }
                }

            }

        }

        #endregion

        #region phase 4 - ajout nouveaux membres

        foreach (var member in listnew)
        {
            var m = DataMapping.GetMemberByNim(member.MemberId);
            
            var club = clubs.Find(c => c.cric ==member.ClubId);
            if (club != null)
            {
                var clublog = listclublog.Find(c => c.Cric == club.cric);
                if (clublog == null)
                {
                    clublog = new Rotary.ClubLog(club.cric, club.name);
                    listclublog.Add(clublog);
                }

                if(m!=null){
                    listmaj.Add(member);
                }
                else
                {
                    clublog.Logs += "Ajout membre " + member.MemberId + " " + member.FirstName + " " + member.LastName+Environment.NewLine;
                    var profile = Yemon.dnn.Functions.Deserialize<Rotary.Club_Members.Member>(member.Profile);
                    if(profile==null)
                    {
                        clublog.Errors+= "Erreur extraction profil "+ member.MemberId + " " + member.FirstName + " " + member.LastName+Environment.NewLine;
                    }
                    else
                    {
                        m = new Member();
                        m.nim = member.MemberId;
                        m.cric = member.ClubId;
                        m.club_name = club.name;
                        if (member.IsSatelliteMember)
                        {
                            m.satellite_member = Const.YES;
                        }
                        else
                        {
                            m.satellite_member = Const.NO;
                        }
                        m.name = Functions.ToTitleCase((member.FirstName + " " +     member.MiddleName).ToLower().Trim());
                        m.surname = member.LastName.ToUpper().Trim();

                        m.civility = profile.Gender == "Female" ? "Mme" : profile.Gender == "Male" ? "M":"" ;
 
                        
                        var email = "";
                        foreach (var em in profile.Email)
                        {
                            if (em.IsPrimary)
                            {
                                email = ("" + em.Address).ToLower();
                            }
                        }
                        if(email!="")
                            m.email = email;
                        foreach(var ad in profile.Address){
                            if(ad.IsPrimary){
                                if(ad.Type=="Business")
                                {
                                    m.professionnal_adress = ad.Line1;
                                    m.professionnal_additional = (ad.Line2 + " " + ad.Line3).Trim();
                                    m.professionnal_town = ad.City;
                                    m.professionnal_zip_code = ad.PostalCode;
                                    m.professionnal_country = ad.Country;
                                }
                                else
                                {
                                    m.adress_1 = ad.Line1;
                                    m.adress_2 = ad.Line2;
                                    m.adress_3 = ad.Line3;
                                    m.zip_code = ad.PostalCode;
                                    m.town = ad.City;
                                    m.country = ad.Country;
                                }
                               
                                m.ri_ad1 = ad.Line1;
                                m.ri_ad2 = ad.Line2;
                                m.ri_ad3 = ad.Line3;
                                m.ri_zip_code = ad.PostalCode;
                                m.ri_town = ad.City;
                                m.ri_country = ad.Country;
                            }
                        }
                        foreach (var tel in profile.Phone)
                        {
                            if(tel.Type=="Mobile")
                            {
                               m.gsm= Functions.NormalizeNumber("+"+tel.CountryCode+" "+ tel.Number);
                            }
                            else
                            {
                                m.telephone = Functions.NormalizeNumber("+" + tel.CountryCode + " " + tel.Number);
                            }
                        }
                        foreach (var fax in profile.Fax)
                        {
                            m.fax = Functions.NormalizeNumber("+" + fax.CountryCode + " " + fax.Number);
                        }
                        DateTime birthdate = DateTime.MinValue;
                        var culture = CultureInfo.CreateSpecificCulture("en-US");
                        var styles = DateTimeStyles.None;
                        DateTime.TryParse("" + profile.DateOfBirth, culture, styles, out birthdate);
                        if(birthdate != DateTime.MinValue)
                            m.birth_year = birthdate;
                        foreach (var role in profile.Role)
                        {
                            if (role.AdmissionDate != null)
                            {
                                m.year_membership_rotary = (DateTime)role.AdmissionDate;
                            }
                        }
                        m.base_dtupdate = DateTime.Now;
                        if(Const.ROTARY_SYNCHRO_ALLOW_UPDATE && club.rotary_agreement_type=="auto")
                        {

                            if(!DataMapping.InsertMember(m))
                            {
                                clublog.Errors+= "Erreur création membre " + member.MemberId + " " + member.FirstName + " " + member.LastName+Environment.NewLine;
                            }
                        }

                    }

                }
            }
            else
            {
                errors += "Le membre est dans un club qui n'a pas autorisé la synchro ri "+ member.MemberId+" " + member.FirstName + " " + member.LastName + Environment.NewLine;
            }
        }
        #endregion

        #region phase 5 - maj

        foreach (var member in listmaj)
        {

            var m = DataMapping.GetMemberByNim(member.MemberId);

            var club = clubs.Find(c => c.cric == m.cric);
            
            if (club != null)
            {
                var clublog = listclublog.Find(c => c.Cric == club.cric);
                if (clublog == null)
                {
                    clublog = new Rotary.ClubLog(club.cric, club.name);
                    listclublog.Add(clublog);
                }

                var profile = Yemon.dnn.Functions.Deserialize<Rotary.Club_Members.Member>(member.Profile);
                if (profile == null)
                {
                    clublog.Errors += "Erreur extraction profil membre ri " + member.MemberId + " " + member.FirstName + " " + member.LastName + Environment.NewLine;
                    // erreur de récupération du profil membre ri
                }
                else
                {

                    #region changements
                    string changements = "";
                    if ((m.satellite_member == Const.YES) != profile.IsSatelliteMember())
                    {
                        changements += "satellite(" + m.satellite_member + ">" + (profile.IsSatelliteMember() ? "O" : "N") + "),";
                        m.satellite_member = (profile.IsSatelliteMember() ? Const.YES : Const.NO);
                    }
                    if ((m.honorary_member==Const.YES) != profile.IsHonoraryMember())
                    {
                        changements += "honorary(" + m.honorary_member + ">" + (profile.IsHonoraryMember() ? "O" : "N") + "),";
                        m.honorary_member = (profile.IsHonoraryMember() ? Const.YES : Const.NO);
                    }
                    profile.FirstName = Functions.ToTitleCase(profile.FirstName.ToLower()).Trim();
                    profile.MiddleName = Functions.ToTitleCase(profile.MiddleName.ToLower()).Trim();
                    profile.LastName = profile.LastName.ToUpper().Trim();
                    string name = (profile.FirstName + " " + profile.MiddleName).Trim();
                    if (m.name != name)
                    {
                        changements += "name("+m.name+">"+name+"),";
                        m.name = name;
                    }
                    if (m.surname != profile.LastName)
                    {
                        changements += "surname("+m.surname+">"+profile.LastName+"),";
                        m.surname = profile.LastName;
                    }
                    var email = "";
                    foreach (var em in profile.Email)
                    {
                        if (em.IsPrimary)
                        {
                            email = (""+em.Address).ToLower();
                        }
                    }
                    if (m.email != email && email!="")
                    {
                        changements += "email("+m.email+">"+email+"),";
                        m.email = email;
                    }

                    string gender = profile.Gender == "Female" ? "Mme" : profile.Gender == "Male" ? "M" : "";
                    if(m.civility!=gender)
                    {
                        changements += "civ(" + m.civility + ">" + gender + "),";
                        m.civility = gender;
                    }

                    foreach (var tel in profile.Phone)
                    {
                        string telri = Functions.NormalizeNumber("+" + tel.CountryCode + " " + tel.Number);
                        
                        if (tel.Type == "Mobile")
                        {
                            if(m.gsm != telri)
                            {
                                changements += "gsm(" + m.gsm + ">" + telri + "),";
                                m.gsm = telri;
                            }
                            
                        }
                        else
                        {
                            if (m.telephone != telri)
                            {
                                changements += "tel(" + m.telephone + ">" + telri + "),";
                                m.telephone = telri;
                            }
                       
                        }
                    }
                    foreach (var fax in profile.Fax)
                    {
                        string telri = Functions.NormalizeNumber("+" + fax.CountryCode + " " + fax.Number);
                        if(m.fax!=telri)
                        {
                            changements += "fax(" + m.fax + ">" + telri + "),";
                            m.fax = Functions.NormalizeNumber("+" + fax.CountryCode + " " + fax.Number);

                        }
                    }
                    foreach (var ad in profile.Address)
                    {
                        string adr = m.ri_ad1 + " " + m.ri_ad2 + " " + m.ri_ad3 + " " + m.ri_zip_code + " " + m.ri_town + " " + m.ri_country;
                        string adrri = ad.Line1 + " " + ad.Line2 + " " + ad.Line3 + " " + ad.PostalCode + " " + ad.City + " " + ad.Country;
                        if (adr != adrri)
                        {
                            changements += "(adr(" + adr + ">" + adrri + "),";
                            if (ad.Type == "Business")
                            {
                                m.professionnal_adress = ad.Line1;
                                m.professionnal_additional = (ad.Line2 + " " + ad.Line3).Trim();
                                m.professionnal_zip_code = ad.PostalCode;
                                m.professionnal_town = ad.City;
                                m.professionnal_country = ad.Country;
                            }
                            else
                            {
                                m.adress_1 = ad.Line1;
                                m.adress_2 = ad.Line2;
                                m.adress_3 = ad.Line3;
                                m.zip_code = ad.PostalCode;
                                m.town = ad.City;
                                m.country = ad.Country;
                            }
                            m.ri_ad1 = ad.Line1;
                            m.ri_ad2 = ad.Line2;
                            m.ri_ad3 = ad.Line3;
                            m.ri_zip_code = ad.PostalCode;
                            m.ri_town = ad.City;
                            m.ri_country = ad.Country;
                        }                  
                    }
                    DateTime birthdate= DateTime.MinValue;
                    var culture = CultureInfo.CreateSpecificCulture("en-US");
                    var styles = DateTimeStyles.None;
                    DateTime.TryParse("" + profile.DateOfBirth,culture,styles, out birthdate);
                    if(birthdate!=DateTime.MinValue && m.birth_year != birthdate)
                    {
                        changements += "birthdate(" + m.birth_year + ">" + birthdate.ToShortDateString() + "),";
                        m.birth_year = birthdate;
                    }
                    foreach(var role in profile.Role){
                        if(role.AdmissionDate!= null && m.year_membership_rotary != (DateTime)role.AdmissionDate)
                        {
                            changements+="admission("+m.year_membership_rotary + ">"+ ((DateTime)role.AdmissionDate).ToShortDateString()+"),";
                            m.year_membership_rotary = (DateTime)role.AdmissionDate;
                        }
                    }
                    
                    if (changements.Length > 0)
                    {
                        changements = changements.Substring(0, changements.Length - 1);
                        clublog.Logs += "<p>Maj membre " + m.nim + " " + m.name + " " + m.surname + "[" + changements + "]</p>" + Environment.NewLine;
                    }
                    else
                    {
                        //clublog.Logs += "<p>Maj membre " + m.nim + " " + m.name + " " + m.surname + "(pas de changements)" + Environment.NewLine;
                    }

                    #endregion


                    if (club.rotary_agreement_type == "auto")
                    {
                        if(Const.ROTARY_SYNCHRO_ALLOW_UPDATE)
                        {

                            if (!DataMapping.UpdateMember(m))
                            {
                                clublog.Errors += "Erreur mise à jour membre " + m.nim + " " + m.name + " " + m.surname + Environment.NewLine;
                            }
                            else
                            {
                                var sql = new SqlCommand("update ais_members set dt_update_import_ri_club=@date where nim=@nim");
                                sql.Parameters.AddWithValue("nim", m.nim);
                                sql.Parameters.AddWithValue("date", member.DtLastUpdate);
                                int nb = Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);
                                if (nb == 0)
                                {
                                    clublog.Errors += "Erreur maj date membre " + m.nim + " " + m.name + " " + m.surname + Environment.NewLine;
                                }
                            }
                        }

                    }
                }




            }
            else
            {

                errors += "Le membre est dans un club qui n'a pas autorisé la synchro ri " + m.name + " " + m.surname + Environment.NewLine;

            }


        }

        #endregion

        #region phase 6 - membres honoraires
        foreach(var club in clubs){
            var rimembers = Yemon.dnn.DataMapping.ExecSql<Rotary.Member>(new SqlCommand("select * from ais_ri_member where IsHonoraryMember=1 and clubid=" + club.cric));
            var clublog = listclublog.Find(c => c.Cric == club.cric);
            if (clublog == null)
            {
                clublog = new Rotary.ClubLog(club.cric, club.name);
                listclublog.Add(clublog);
            }
            foreach (var member in rimembers){
                clublog.Logs += "<p><em>Membre d'honneur " + member.MemberId + " " + member.FirstName + " " + member.LastName + "</em></p>";
                var profile = Yemon.dnn.Functions.Deserialize<Rotary.Club_Members.Member>(member.Profile);
                if (profile == null)
                {
                    clublog.Errors += "Erreur extraction profil " + member.MemberId + " " + member.FirstName + " " + member.LastName + Environment.NewLine;
                }
                else
                {
                    var m = new Member();
                    m.honorary_member = Const.YES;
                    m.nim = -member.MemberId;
                    m.cric = member.ClubId;
                    m.club_name = club.name;

                    m.name = Functions.ToTitleCase((member.FirstName + " " + member.MiddleName).ToLower().Trim());
                    m.surname = member.LastName.ToUpper().Trim();

                    m.civility = profile.Gender == "Female" ? "Mme" : profile.Gender == "Male" ? "M" : "";


                    string chemin = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
                    chemin += "Portals\\0\\"+Const.MEMBERS_PHOTOS_PREFIX.Replace("/","\\");

                    var MD5Name = Functions.CalculateMD5Hash(UTF8Encoding.UTF8.GetBytes(m.nim + ":" + m.name + ":" + m.surname));

                    string filename = Functions.ClearFileName(MD5Name + ".jpg").ToLower();
                    chemin = Path.Combine(chemin, filename);
                    
                    FileInfo fileInfo = new FileInfo(chemin);
                    if (fileInfo.Exists)
                    {
                        m.photo = filename;
                    }

                    var email = "";
                    foreach (var em in profile.Email)
                    {
                        if (em.IsPrimary)
                        {
                            email = ("" + em.Address).ToLower();
                        }
                    }
                    if (email != "")
                    {
                        m.email = email;

                        var huinfo = UserController.GetUserByEmail(0, email);
                        if (huinfo != null)
                        {
                            m.userid = huinfo.UserID;
                        }
                    }
                       
                    foreach (var ad in profile.Address)
                    {
                        if (ad.IsPrimary)
                        {
                            if (ad.Type == "Business")
                            {
                                m.professionnal_adress = ad.Line1;
                                m.professionnal_additional = (ad.Line2 + " " + ad.Line3).Trim();
                                m.professionnal_town = ad.City;
                                m.professionnal_zip_code = ad.PostalCode;
                                m.professionnal_country = ad.Country;
                            }
                            else
                            {
                                m.adress_1 = ad.Line1;
                                m.adress_2 = ad.Line2;
                                m.adress_3 = ad.Line3;
                                m.zip_code = ad.PostalCode;
                                m.town = ad.City;
                                m.country = ad.Country;
                            }

                            m.ri_ad1 = ad.Line1;
                            m.ri_ad2 = ad.Line2;
                            m.ri_ad3 = ad.Line3;
                            m.ri_zip_code = ad.PostalCode;
                            m.ri_town = ad.City;
                            m.ri_country = ad.Country;
                        }
                    }
                    foreach (var tel in profile.Phone)
                    {
                        if (tel.Type == "Mobile")
                        {
                            m.gsm = Functions.NormalizeNumber("+" + tel.CountryCode + " " + tel.Number);
                        }
                        else
                        {
                            m.telephone = Functions.NormalizeNumber("+" + tel.CountryCode + " " + tel.Number);
                        }
                    }
                    foreach (var fax in profile.Fax)
                    {
                        m.fax = Functions.NormalizeNumber("+" + fax.CountryCode + " " + fax.Number);
                    }
                    DateTime birthdate = DateTime.MinValue;
                    DateTime.TryParse("" + profile.DateOfBirth, out birthdate);
                    if (birthdate != DateTime.MinValue)
                        m.birth_year = birthdate;
                    foreach (var role in profile.Role)
                    {
                        if (role.AdmissionDate != null)
                        {
                            m.year_membership_rotary = (DateTime)role.AdmissionDate;
                        }
                    }
                    m.base_dtupdate = DateTime.Now;
                    if (Const.ROTARY_SYNCHRO_ALLOW_UPDATE && club.rotary_agreement_type == "auto")
                    {

                        if (!DataMapping.InsertMember(m))
                        {
                            clublog.Errors += "Erreur création membre d'honneur " + member.MemberId + " " + member.FirstName + " " + member.LastName + Environment.NewLine;
                        }
                    }

                }
            }
        }
        #endregion
        
        if (errors!="")
        {
            string[] errs = errors.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            result += "<p style='color:red'>Erreur(s) :</p>";
            foreach (var error in errs)
            {
                result += "<p style='color:red'>" + error+"</p>";
            }
            result += "";
        }

        foreach (var logclub in listclublog)
        {
            if (Const.ROTARY_SYNCHRO_FULL_LOG)
                result += "<div><strong>" + logclub.Name + " " + logclub.Cric + "</strong></div>";
            if (logclub.Errors.Length > 0)
            {
                string[] errs = logclub.Errors.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var error in errs)
                {
                    result += "<p style='color:red'>" + error + "</p>";
                }
              
            }
            if (logclub.Logs.Length > 0)
            {
                string[] cc = logclub.Logs.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
       
                foreach (var c in cc)
                {
                    if (Const.ROTARY_SYNCHRO_FULL_LOG)
                        result += "<p>" + c + "</p>";
                }
  
            }

        }
        return result;
    }

    public static string UpdateMemberProfile(Rotary.Profile profile,AIS.Club club, out string changements){
     
        string result = "";
        changements = "";
        var m = DataMapping.GetMemberByNim(profile.individual.MemberId);
        if(m==null){
            result = "<p>Membre introuvable "+ profile.individual.MemberId+ " "+ profile.individual.FirstName+" "+ profile.individual.LastName+"</p>"; 
        }
        else
        {
            if(m.dt_update_import_ri_club== null || profile.DtLastUpdate() > m.dt_update_import_ri_club)
            {
                

                profile.individual.FirstName = Functions.ToTitleCase(profile.individual.FirstName.ToLower()).Trim();
                profile.individual.MiddleName = Functions.ToTitleCase(profile.individual.MiddleName.ToLower()).Trim();
                profile.individual.LastName = profile.individual.LastName.ToUpper().Trim();
                string name = (profile.individual.FirstName + " " + profile.individual.MiddleName).Trim();
                if (m.name != name)
                {
                    changements += "name(" + m.name + ">" + name + "),";
                    m.name = name;
                }
                if (m.surname != profile.individual.LastName)
                {
                    changements += "surname(" + m.surname + ">" + profile.individual.LastName + "),";
                    m.surname = profile.individual.LastName;
                }
                var email = "";
                foreach (var em in profile.email)
                {
                    if (em.IsPrimary)
                    {
                        email = ("" + em.Address).ToLower();
                    }
                }
                if (m.email != email && email != "")
                {
                    changements += "email(" + m.email + ">" + email + "),";
                    m.email = email;
                }

                string gender = profile.individual.Gender == "Female" ? "Mme" : profile.individual.Gender == "Male" ? "M" : "";
                if (m.civility != gender)
                {
                    changements += "civ(" + m.civility + ">" + gender + "),";
                    m.civility = gender;
                }

                foreach (var tel in profile.phone)
                {
                    string telri = Functions.NormalizeNumber("+" + tel.CountryCode + " " + tel.Number);

                    if (tel.Type == "Mobile")
                    {
                        if (m.gsm != telri)
                        {
                            changements += "gsm(" + m.gsm + ">" + telri + "),";
                            m.gsm = telri;
                        }

                    }
                    else if (tel.Type=="Business")
                    {
                        if (m.professionnal_tel != telri)
                        {
                            changements += "tel_pro(" + m.professionnal_tel + ">" + telri + "),";
                            m.professionnal_tel = telri;
                        }

                    }
                    else
                    {
                        if (m.telephone != telri)
                        {
                            changements += "tel(" + m.telephone + ">" + telri + "),";
                            m.telephone = telri;
                        }

                    }
                }

                foreach (var fax in profile.fax)
                {
                    string telri = Functions.NormalizeNumber("+" + fax.CountryCode + " " + fax.Number);
                    if (m.fax != telri)
                    {
                        changements += "fax(" + m.fax + ">" + telri + "),";
                        m.fax = Functions.NormalizeNumber("+" + fax.CountryCode + " " + fax.Number);

                    }
                }

                foreach (var ad in profile.address)
                {
                    string adrpro = m.professionnal_adress + " " + m.professionnal_additional + " " + m.professionnal_zip_code + " " + m.professionnal_town + " " + m.professionnal_country;
                    string adr = m.adress_1 + " " + m.adress_2 + " " + m.adress_3 + " " + m.zip_code + " " + m.town+" "+m.country;
                    string adrri = ad.Line1 + " " + ad.Line2 + " " + ad.Line3 + " " + ad.PostalCode + " " + ad.City + " " + ad.Country;
                    if (adrpro != adrri && ad.Type == "Business")
                    {
                        changements += "(adr_pro(" + adrpro + ">" + adrri + "),";
                       
                            m.professionnal_adress = ad.Line1;
                            m.professionnal_additional = (ad.Line2 + " " + ad.Line3).Trim();
                            m.professionnal_zip_code = ad.PostalCode;
                            m.professionnal_town = ad.City;
                            m.professionnal_country = ad.Country;
                    }
                    if (adr != adrri && ad.Type == "Home")
                    {
                        changements += "(adr(" + adr + ">" + adrri + "),";

                        m.adress_1 = ad.Line1;
                        m.adress_2 = ad.Line2;
                        m.adress_3 = ad.Line3;
                        m.zip_code = ad.PostalCode;
                        m.town = ad.City;
                        m.country = ad.Country;

                    }
                }
                DateTime birthdate = DateTime.MinValue;
                DateTime.TryParse("" + profile.individual.DateOfBirth, out birthdate);
                if (birthdate != DateTime.MinValue && m.birth_year != birthdate)
                {
                    changements += "birthdate(" + m.birth_year + ">" + birthdate.ToShortDateString() + "),";
                    m.birth_year = birthdate;
                }
                if (Const.ROTARY_SYNCHRO_ALLOW_UPDATE)
                {
                    if (changements.Length > 0)
                    {
                        changements = changements.Substring(0, changements.Length - 1);
                        if (Const.ROTARY_SYNCHRO_FULL_LOG)
                            result += "<p>Maj membre " + m.nim + " " + m.name + " " + m.surname + "[" + changements + "]</p>";

                        if (club.rotary_agreement_type == "auto")
                        {

                            if (!DataMapping.UpdateMember(m))
                            {
                                result += "<p style='color:red'>Erreur maj "+m.nim+"</p>";
                            }

                        }

                    }
                    
                }
            }

            if (!result.Contains("Erreur maj"))
            {
                var sql = new SqlCommand("update ais_members set dt_update_import_ri_club=@date where nim=@nim");
                sql.Parameters.AddWithValue("nim", m.nim);
                sql.Parameters.AddWithValue("date", DateTime.Now);
                int nb = Yemon.dnn.DataMapping.ExecSqlNonQuery(sql);
                if (nb == 0)
                {
                    result += "<p style='color:red'>Erreur maj date membre " + m.nim + " " + m.name + " " + m.surname + "</p>";
                }
            }
        }
        return result;

    }

    public static string UpdateMembersProfiles(){
        string result = "";
        string res = "";

        DateTime start = new DateTime(2013,7,1);
        var item = Yemon.dnn.Helpers.GetItem("RotaryUpdateStartDate");
        if (item != null)
        {
            start = Yemon.dnn.Functions.Deserialize<DateTime>(""+item);
            start = start.AddDays(-1);
        }
        result += "<p>Période d'analyse des mises à jour du "+start.ToShortDateString()+" au "+DateTime.Now.ToShortDateString()+"</p>";
        var nims = Get_Members_To_Update(start,DateTime.Now,out res);
        var members = DataMapping.ListMembers(max: int.MaxValue);
        var clubs = DataMapping.ListClubs().FindAll(c => c.rotary_agreement_date != null && c.rotary_agreement_type != "").OrderBy(c => c.club_type).ToList();
        int nb = 0;
        int nb2 = 0;
        foreach (var member in members){
            if(member.honorary_member==Const.NO)
            {

                var club = clubs.Find(c => c.cric == member.cric);
                if(club!=null)
                {
                    if(nims.Contains(member.nim) || member.dt_update_import_ri_club==null)
                    {
                        var profile = Get_Member_Profile(member.nim, out res);
                        if (profile != null)
                        {
                            string changements = "";
                            result += UpdateMemberProfile(profile, club, out changements);
                        
                            if (changements.Length > 0)
                                nb++;
                        }
                        nb2++;
                    }
                }
                if(nb>10)
                    break;
                if (nb2 > 50)
                    break;
            }

        }

        if (nb==0)// quand il n'y a plus de changements on met a jour la date
        {
            Yemon.dnn.Helpers.SetItem("RotaryUpdateStartDate", Yemon.dnn.Functions.Serialize(DateTime.Now), "", keephistory: false);
            result += "<p><em>Aucune maj détectée</em></p>";
        }

        return result;
    }

    public static string ForceUmpAllProfiles(){
        Yemon.dnn.DataMapping.ExecSqlNonQuery("Update ais_members set dt_update_import_ri_club = null");
        Yemon.dnn.Helpers.DeleteItem("RotaryUpdateStartDate");
        return "Tous les profils membres vont être mis à jour en tâche de fond";
    }
}