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
using Telerik.Web.UI.com.hisoftware.api2;


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

            var item = ""+Yemon.dnn.Helpers.GetItem("RotaryAuthToken", 0);
            if (item == null)
                return null;
            return Yemon.dnn.Functions.Deserialize<Auth_Token>("" + item); ;

        }
        set
        {
            Yemon.dnn.Helpers.SetItem("RotaryAuthToken", Yemon.dnn.Functions.Serialize(value),"", keephistory: false);
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
        catch(Exception ee) {
            
            return ee.ToString();
        }
    }

    public static List<Rotary.Club> Get_Clubs()
    {
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("clubs"));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result)) {
                throw new Exception("Erreur récupération clubs");
            }

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
    public static List<Rotary.Member> Get_Club_Members(string clubtype, int cric, string membertype)
    {
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("clubs/"+clubtype+"/"+cric+"/members/"+membertype));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération clubs");
            }

            List<Rotary.Member> members = Yemon.dnn.Functions.Deserialize<List<Rotary.Member>>(task.Result);

            return members;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }

    public static List<Rotary.Club.Officer> Get_Club_Officers(int cric, string clubtype)
    {
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("clubs/"+clubtype+"/"+cric+"/officers?startDate=07-01-2024&endDate=06-30-2025"));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération clubs");
            }

            List<Rotary.Club.Officer> members = Yemon.dnn.Functions.Deserialize<List<Rotary.Club.Officer>>(task.Result);

            return members;
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }

    public static Rotary.Profile Get_Member_Profile(int nim)
    {
        try
        {
            _param = GetParametres();
            var task = Task.Run(() => CallAsyncGet("individuals/"+nim+"/profile"));
            task.Wait();

            if (String.IsNullOrEmpty(task.Result))
            {
                throw new Exception("Erreur récupération clubs");
            }

            Rotary.Profile member = Yemon.dnn.Functions.Deserialize<Rotary.Profile>(task.Result);

            return member;
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

        var body = @"{"+
                        "'Username': '"+_param.api_username+"',"+
                        "'Password': '"+_param.api_password+"'"+
                    "}";


        var content =new StringContent(body, Encoding.UTF8, "application/json");

        var result = await httpClient.PostAsync(_param.url_api+ "authentication", content);
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


    public static string SynchroClubs(){
        string result = "";
        var clubs = Get_Clubs();

        if (clubs == null)
            return "Erreur récupération des clubs";

        var dbclubs = Yemon.dnn.DataMapping.ExecSql<Rotary.Club>(new SqlCommand("select * from ri_club"));
        foreach(var club in clubs)
        {
            var row = new Dictionary<string, object>();

            var dbclub = dbclubs.Find(c => c.ClubId == club.ClubId);
            if (dbclub != null)
                row["id"] = dbclub.id;
            row["clubid"] = club.ClubId;
            row["clubtype"] = club.ClubType;
            row["clubsubtype"] = club.ClubSubType;
            row["clubname"] = club.ClubName;
            row["clubcountry"] = club.ClubCountry;
            row["districtid"] = club.DistrictId;
            row["membercount"] = club.MemberCount;
            row["honorarymembercount"] = club.HonoraryMemberCount;
            row["dtlastupdate"] = DateTime.Now;
            var r = Yemon.dnn.DataMapping.UpdateOrInsertRecord("ri_club", "id", row);
            if (r.Key != "error")
                result += "" + club.ClubId + " : " + club.ClubName + "<br/>";
            else
                result += "ERREUR : " + club.ClubId + " : " + club.ClubName + " < br /> ";
        }
       
        result += clubs.Count + " récupéré(s)";

        return result;
    }

    public static string SynchroMembers(){
        string result = "";
        var clubs = Yemon.dnn.DataMapping.ExecSql<Rotary.Club>(new SqlCommand("select * from ri_club"));
        var dbmembers = Yemon.dnn.DataMapping.ExecSql<Rotary.Member>(new SqlCommand("select * from ri_member"));
        foreach (var club in clubs)
        {
            var members = Get_Club_Members(club.ClubType, club.ClubId, "active");

            foreach(var member in members)
            {
                var row = new Dictionary<string, object>();
                var dbmember = dbmembers.Find(c => c.MemberId == member.MemberId);
                if (dbmember != null)
                    row["id"] = dbmember.id;

                row["memberid"] = member.MemberId;
                row["membertype"] = member.MemberType;
                row["firstname"] = member.FirstName;
                row["lastname"] = member.LastName;
                row["suffix"] = member.Suffix;
                row["admissiondate"] = member.AdmissionDate;
                row["dtlastupdate"] = DateTime.Now;
                row["profile"] = Yemon.dnn.Functions.Serialize(member);
                var r = Yemon.dnn.DataMapping.UpdateOrInsertRecord("ri_member", "id", row);
                if (r.Key != "error")
                    result += "" + club.ClubId + " : " + club.ClubName +" : " + member.MemberType + " " + member.FirstName + " "+ member.LastName + "<br/>";
                else
                    result += "ERREUR : " + club.ClubId + " : " + club.ClubName + " : " + member.MemberType + " " + member.FirstName + " " + member.LastName + "<br/>";
            }
        }
        return result;
    }

    public static string SynchroOfficers(){
        string result = "";
        var clubs = Yemon.dnn.DataMapping.ExecSql<Rotary.Club>(new SqlCommand("select * from ri_club"));
        if (clubs == null)
            return "Erreur récupération des clubs";

        var dbofficers = Yemon.dnn.DataMapping.ExecSql<Rotary.Club.Officer>(new SqlCommand("select * from ri_officer"));

        foreach (var club in clubs)
        {
            var officers = Get_Club_Officers(club.ClubId,club.ClubType);

            foreach(var officer in officers)
            {
                var row = new Dictionary<string, object>();
                var dbofficer = dbofficers.Find(c => c.MemberId == officer.MemberId);
                if (dbofficer != null)
                    row["id"] = dbofficer.id;

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

                var r = Yemon.dnn.DataMapping.UpdateOrInsertRecord("ri_officer", "id", row);
                if (r.Key != "error")
                    result += "" + club.ClubId + " : " + club.ClubName + " : " + officer.MemberId + " " + officer.FirstName + " " + officer.LastName + " : " + officer.OfficerRole + "<br/>";
                else
                    result += "ERREUR : " + club.ClubId + " : " + club.ClubName + " : " + officer.MemberId + " " + officer.FirstName + " " + officer.LastName + " : " + officer.OfficerRole + "<br/> ";
            }
        }
        return result;
    }

}