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
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;
using DotNetNuke.Common;
using System.Linq;
using Dnn.ExportImport.Components.Common;

/// <summary>
/// Description résumée de RotaryMagHelper
/// </summary>
public class RotaryMagHelper
{
    private static RotaryMag.Parametres _param;

    public static RotaryMag.Parametres GetParametres() {
        var item = Yemon.dnn.Helpers.GetItem("RotaryMagParametres", 0);
        if (item == null) return null;
        return Yemon.dnn.Functions.Deserialize<RotaryMag.Parametres>("" + item); ;
    }

    private static JWTToken JWT_TOKEN
    {
        get
        {
            
            var item = Yemon.dnn.Helpers.GetItem("RotaryMagJwtToken", 0);
            if (item == null)
                return null;
            return Yemon.dnn.Functions.Deserialize<JWTToken>("" + item); ;

        }
        set
        {
            Yemon.dnn.Helpers.SetItem("RotaryMagJwtToken", Yemon.dnn.Functions.Serialize(value),"", keephistory: false);
        }
    }

    public static string CountryToISO(string country)
    {
        country = (""+country).ToLower().Trim();
        var countries = DataMapping.GetCountries();
        var pays = countries.FindLast(p => p.Name.ToLower() == country || p.Code.ToLower() == country);
        if (pays != null)
            return pays.Code;

        // code à transférer dans l'import RI des membres
        switch(country) {
            case "australia":
                return "AU";
            case "autriche":
                return "AT";
            case "belgium":
                return "BE";
            case "cameroon":
                return "CM";
            case "england":
                return "GB";
            case "germany":
                return "DE";
            case "italie":
            case "italy":
                return "IT";
            case "mauritius":
                return "MU";
            case "monte carlo":
            case "monte-carlo":
                return "MC";
            case "morocco":
                return "MA";
            case "espagne":
            case "spain":
                return "ES";
            case "switzerland":
                return "CH";
            case "united states":
            case "united-states":
            case "etats-unis":
                return "US";
            default:
                return "FR";
        }
    }
    
    public class JWTToken
    {
        public int userId { get; set; }
        public string displayName { get; set; }
        
        #region changement du 08/04
        public string token { get; set; }       
        public string accessToken { get { return token; } set { token = value; } }
        #endregion

        public string renewalToken { get; set; }
    }

    public RotaryMagHelper()
    {
        //
        // TODO: ajoutez ici la logique du constructeur
        //
    }

    public static string Synchro(bool import=true,bool analyse=true,bool maj=true)
    {
        try { 
            StringBuilder sb = new StringBuilder();
            List<RotaryMag.Membre> membres = Yemon.dnn.DataMapping.ExecSql<RotaryMag.Membre>(new SqlCommand("SELECT * FROM "+Const.TABLE_PREFIX+"import_rotarymag"));
            List<RotaryMag.Membre> MembresToUpdate = new List<RotaryMag.Membre>();
            if (import)
            {
                _param = GetParametres();
                if (_param == null)
                    return "Erreur de récupération des paramètres";

                //if(JWT_TOKEN == null)
                //{
                var task = Task.Run(() => CallAsyncLogin());
                task.Wait();

                if (JWT_TOKEN == null)
                {
                    return "Erreur de login";
                }

                //}

                var task1 = Task.Run(() => CallAsyncMembres());
                task1.Wait();

                if (task1.Result != null)
                {
                    membres = task1.Result;
                    string results = StoreMembres(membres);
                    sb.AppendLine("Import membres : "+ membres.Count + " membres récupérés"+Environment.NewLine + results );
                }
                else
                {
                    return "Erreur de récupération membres";
                }

            }
            if (analyse)
            {
                string a = "Analyse membres";
                a += Environment.NewLine + AnalyseMembres(membres,out MembresToUpdate);
                Yemon.dnn.Helpers.SetItem("RotaryMagAnalyseMembres", a, "" + Globals.GetHostPortalSettings().UserId);
                sb.AppendLine(a);
            }
            if(maj)
            {
                if(!analyse)
                    AnalyseMembres(membres, out MembresToUpdate);

                string m = "MAJ des membres";
                m += Environment.NewLine + MajMembres(MembresToUpdate);
                Yemon.dnn.Helpers.SetItem("RotaryMagMajMembres", m, "" + Globals.GetHostPortalSettings().UserId);
                sb.AppendLine(m);
            }
            return sb.ToString();

        }
        catch(Exception ex)
        {
            Functions.Error(ex);
            return "Erreur de synchro : "+ex.Message;
        }
        
    }

    public static string SynchroInitialeRM2RODI()
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder erreur = new StringBuilder();
            sb.AppendLine("Synchro initiale RM>RODI pour les champs spécifiques RM :");
            List<RotaryMag.Membre> membres = Yemon.dnn.DataMapping.ExecSql<RotaryMag.Membre>(new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "import_rotarymag"));

            DateTime maintenant = DateTime.Now;
            foreach (var membre in membres)
            {
                SqlCommand sql = new SqlCommand("UPDATE " + Const.TABLE_PREFIX + "members SET " +
                    "phf=@phf," +
                    "legion_honneur=@legion_honneur," +
                    "ordre_merite=@ordre_merite," +
                    "palmes_academiques=@palmes_academiques," +
                    "medaille_militaire=@medaille_militaire," +
                    "croix_guerre=@croix_guerre," +
                    "autre_decorations=@autre_decorations," +
                    "pro_secteur_activite=@pro_secteur_activite," +
                    "professionnal_company=@professionnal_company," +
                    "no_adr_pro=@no_adr_pro," +
                    "annee_entree_club=@annee_entree_club," +
                    "job=@job," +
                    "fonction=@fonction," +
                    "base_dtupdate=@base_dtupdate," +
                    "[dt_update_import_rm]=@dt_update_import_rm" +
                    " WHERE nim=@nim");
                sql.Parameters.AddWithValue("nim", membre.nim);
                sql.Parameters.AddWithValue("phf", "" + membre.phf);
                sql.Parameters.AddWithValue("legion_honneur", "" + membre.legion_honneur);
                sql.Parameters.AddWithValue("ordre_merite", "" + membre.ordre_merite);
                sql.Parameters.AddWithValue("palmes_academiques", "" + membre.palmes_academiques);
                sql.Parameters.AddWithValue("medaille_militaire", membre.medaille_militaire);
                sql.Parameters.AddWithValue("croix_guerre", membre.croix_guerre);
                sql.Parameters.AddWithValue("autre_decorations", membre.autre_decorations);
                sql.Parameters.AddWithValue("pro_secteur_activite", membre.pro_secteur_activite);
                sql.Parameters.AddWithValue("professionnal_company", "" + membre.pro_raison_sociale);
                sql.Parameters.AddWithValue("no_adr_pro", membre.no_adr_pro);
                sql.Parameters.AddWithValue("annee_entree_club", membre.annee_entree_club);
                sql.Parameters.AddWithValue("job", "" + membre.pro_metier);
                sql.Parameters.AddWithValue("fonction", "" + membre.pro_fonction);

                sql.Parameters.AddWithValue("base_dtupdate", membre.dt_update.ToLocalTime()); // on met la date de rm dans dt update pour ne pas entrer dans une boucle infinie avec RM
                sql.Parameters.AddWithValue("dt_update_import_rm", maintenant); // la date d'import rm est la date ou on a mis a jour le membre de rm dans rodi

                if (Yemon.dnn.DataMapping.ExecSqlNonQuery(sql) > 0)
                {
                    sb.AppendLine("maj ... " + membre.nom + " " + membre.prenom + " " + membre.nim);
                }
                else
                {
                    erreur.AppendLine("erreur maj ... " + membre.nom + " " + membre.prenom + " " + membre.nim);
                }
            }
            
            sb.AppendLine(membres.Count + " membre(s) traité(s)");
            sb.AppendLine("Erreur(s) :");
            sb.AppendLine(erreur.ToString());
            return sb.ToString();

        }
        catch (Exception ex)
        {
            Functions.Error(ex);
            return "Erreur de synchro : " + ex.Message;
        }
    }

    public static async Task CallAsyncLogin()
    {
        HttpClient httpClient = new HttpClient();
        //
        // 08/04/2024 : changement de méthode pour passer en formdata
        //
        //var jsonOject = new 
        //{
        //    u = _param.jwt_username,
        //    p = _param.jwt_password
        //};
        //var content = new StringContent(Yemon.dnn.Functions.Serialize(jsonOject), Encoding.UTF8, "application/json");
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("u", _param.jwt_username),
            new KeyValuePair<string, string>("p", _param.jwt_password)
        });

        var result = await httpClient.PostAsync(_param.jwt_url_login, content);
        if (result.IsSuccessStatusCode)
        {
            string t = result.Content.ReadAsStringAsync().Result;
            JWT_TOKEN = Yemon.dnn.Functions.Deserialize<JWTToken>(t);
            return;
        }

        JWT_TOKEN = null;
    }

    #region le refreshtoken n'est pas implémenté par l'api RotaryMag
    public static async Task<List<RotaryMag.Membre>> CallAsyncMembresAvecRefreshToken()
    {
        bool firsttime = true;
    retry:
        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWT_TOKEN.accessToken);


        var result = await httpClient.GetAsync(_param.url_membres);
        if (result.IsSuccessStatusCode)
        {
            string t = result.Content.ReadAsStringAsync().Result;
            string filename = System.Web.Hosting.HostingEnvironment.MapPath("/" + DateTime.Now.Ticks + "rotarymag.txt");
            System.IO.File.WriteAllText(filename, t);

            List<RotaryMag.Membre> membres = Yemon.dnn.Functions.Deserialize<List<RotaryMag.Membre>>(t);
            return membres;
        }
        else if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            // modif du 8/4/24 pour supporter la réauth directe si pas de token d'extension
            if (string.IsNullOrEmpty(_param.jwt_url_extendtoken))
            {
                var task = Task.Run(() => CallAsyncLogin());
                task.Wait();
                if (JWT_TOKEN != null)
                {
                    if (firsttime)
                    {
                        firsttime = false;
                        goto retry;
                    }
                }
            }
            else
            {
                httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWT_TOKEN.accessToken);

                var jsonOject = new
                {
                    rtoken = JWT_TOKEN.renewalToken
                };
                var content = new StringContent(Yemon.dnn.Functions.Serialize(jsonOject), Encoding.UTF8, "application/json");
                var result1 = await httpClient.PostAsync(_param.jwt_url_extendtoken, content);
                if (result1.IsSuccessStatusCode)
                {
                    string t = result1.Content.ReadAsStringAsync().Result;
                    JWT_TOKEN = Yemon.dnn.Functions.Deserialize<JWTToken>(t);
                    if (firsttime)
                    {
                        firsttime = false;
                        goto retry;
                    }

                }
                else
                {
                    var task = Task.Run(() => CallAsyncLogin());
                    task.Wait();
                    if (JWT_TOKEN != null)
                    {
                        if (firsttime)
                        {
                            firsttime = false;
                            goto retry;
                        }
                    }
                }
            }


        }
        return null;

    }
    #endregion
    public static async Task<List<RotaryMag.Membre>> CallAsyncMembres()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWT_TOKEN.accessToken);


        var result = await httpClient.GetAsync(_param.url_membres);
        if (result.IsSuccessStatusCode)
        {
            string t = result.Content.ReadAsStringAsync().Result;


            Yemon.dnn.Helpers.SetItem("RotaryMagImportMembres", t,""+ Globals.GetHostPortalSettings().UserId);

            List<RotaryMag.Membre> membres = Yemon.dnn.Functions.Deserialize<List<RotaryMag.Membre>>(t);
            return membres;
        }
        
        return null;
    }

    public static string StoreMembres(List<RotaryMag.Membre> membres)
    {
        Yemon.dnn.DataMapping.ExecSqlNonQuery("DELETE FROM " + Const.TABLE_PREFIX + "import_rotarymag");


        SqlConnection conn = Yemon.dnn.DataMapping.GetOpenedConn();

        SqlTransaction trans = conn.BeginTransaction();

        StringBuilder sb = new StringBuilder(); 

        foreach (RotaryMag.Membre membre in  membres)
        {
            try { 
                Type type = membre.GetType();
                PropertyInfo[] props = type.GetProperties();
                Dictionary<string, object> row = new Dictionary<string, object>();
                foreach(PropertyInfo prop in props)
                {
                    row.Add(prop.Name, prop.GetValue(membre));
                }

                Yemon.dnn.DataMapping.UpdateOrInsertRecord(Const.TABLE_PREFIX + "import_rotarymag","id",row, conn, trans);
                if (Yemon.dnn.DataMapping.lastException != null)
                    throw Yemon.dnn.DataMapping.lastException;
            }catch(Exception ex)
            {
                sb.AppendLine("ERREUR : "+membre.nim+" "+membre.nom+ " "+membre.prenom+ " ("+ex.Message+ ")");
            }
        }

        trans.Commit();

        conn.Close();
        return sb.ToString();
    }
    public static string AnalyseMembres(List<RotaryMag.Membre> membres, out List<RotaryMag.Membre> MembresToUpdate)
    {
        StringBuilder sberreur = new StringBuilder();
        StringBuilder sbmaj = new StringBuilder();
        StringBuilder sbmembresrodiabsentsrm = new StringBuilder();
        StringBuilder sbmembreentroprm = new StringBuilder();
        StringBuilder sbmembreplusrecentrodi = new StringBuilder(); 

        var MembresRodi = GetDistrictMembersAffectedBySynchro();
        var ClubsRodi = GetDistrictClubsAffectedBySynchro();

        MembresToUpdate = new List<RotaryMag.Membre>();
        var MembresEnErreur = new List<RotaryMag.Membre>();
        var MembresEnTropRm = new List<RotaryMag.Membre>();
        var MembresRodiAbsentRm = new List<Member>();
        var MembresPlusRecentRodi = new List<RotaryMag.Membre>();

        foreach (var member in MembresRodi)
        {
            if (member.honorary_member != Const.YES)
            {
                var membre = membres.Find(m => m.nim == member.nim);
                if(membre == null)
                {
                    MembresRodiAbsentRm.Add(member);
                    sbmembresrodiabsentsrm.AppendLine(member.surname + " " + member.name + " " + member.nim + " " + member.club_name + " ... présent RODI et absent RM");
                }
            }
            
        }

        foreach (var membre in membres)
        {
            if (membre.nim == 0)
            {
                MembresEnErreur.Add(membre);
                sberreur.AppendLine(membre.nom + " " + membre.prenom + " ... erreur nim");

            }
            else
            {
                Club club = ClubsRodi.Find(c=> c.cric == membre.cric);
                if (club == null)
                {
                    MembresEnErreur.Add(membre);
                    sberreur.AppendLine(membre.nom + " " + membre.prenom + " " + membre.nim + " ... erreur cric "+ membre.cric + " inconnu dans RODI");

                }
                else
                {
                    if (club.rm_agreement_date == null)
                    {
                        MembresEnErreur.Add(membre);
                        sberreur.AppendLine(membre.nom + " " + membre.prenom + " " + membre.nim + " ... le club "+ club.name+" " + membre.cric + " n'a pas donné son accord de synchro");
                    }
                    else
                    {
                        Member member = MembresRodi.Find(m => m.nim == membre.nim && m.honorary_member==Const.NO);
                        if (member == null)
                        {
                            MembresEnTropRm.Add(membre);
                            member = MembresRodi.Find(m => m.nim == membre.nim && m.honorary_member == Const.YES);
                            if (member == null)
                                sbmembreentroprm.AppendLine(membre.nom + " " + membre.prenom + " " + membre.nim + " ... n'existe pas dans RODI");
                            else
                                sbmembreentroprm.AppendLine(membre.nom + " " + membre.prenom + " " + membre.nim + " ... existe dans RODI mais est membre d'honneur");
                        }
                        else
                        {

                            var dtupdaterodiutc = ((DateTime)member.base_dtupdate).ToUniversalTime();
                            if (membre.dt_update > dtupdaterodiutc)
                            {
                                string champsupdate = "";

                                if (member.spouse_name != membre.prenom_conjoint)
                                    champsupdate += "prenom_conjoint,";
                                if (member.civility != RM2RODI_Civilite(membre.civilite))
                                    champsupdate += "civilite,";
                                if (member.retired != RM2RODI_Retraite(membre.statut_pro))
                                    champsupdate += "statut_pro,";

                                if (member.phf != membre.phf)
                                    champsupdate += "phf,";
                                if (member.legion_honneur != membre.legion_honneur)
                                    champsupdate += "legion_honneur,";
                                if (member.ordre_merite != membre.ordre_merite)
                                    champsupdate += "ordre_merite,";
                                if (member.palmes_academiques != membre.palmes_academiques)
                                    champsupdate += "palmes_academiques,";
                                if (member.medaille_militaire != membre.medaille_militaire)
                                    champsupdate += "medaille_militaire,";
                                if (member.croix_guerre != membre.croix_guerre)
                                    champsupdate += "croix_guerre,";
                                if (member.autre_decorations != membre.autre_decorations)
                                    champsupdate += "autre_decorations,";

                                if (member.adress_1 != membre.adresse)
                                    champsupdate += "adresse,";
                                if (member.adress_2 != membre.complement1)
                                    champsupdate += "complement1,";
                                if (member.zip_code != membre.codepostal)
                                    champsupdate += "codepostal,";
                                if (member.town != membre.localite)
                                    champsupdate += "localite,";
                                if (member.country != membre.pays)
                                    champsupdate += "pays,";

                                if (member.no_adr_pro != membre.no_adr_pro)
                                    champsupdate += "no_adr_pro,";

                                if (member.pro_secteur_activite != membre.pro_secteur_activite)
                                    champsupdate += "pro_secteur_activite,";
                                if (member.job != membre.pro_metier)
                                    champsupdate += "pro_metier,";
                                if (member.fonction != membre.pro_fonction)
                                    champsupdate += "pro_fonction,";
                                if (member.professionnal_company != membre.pro_raison_sociale)
                                    champsupdate += "pro_raison_sociale,";
                                if (member.professionnal_adress != membre.pro_adresse)
                                    champsupdate += "pro_adresse,";
                                if (member.professionnal_additional != membre.pro_complement1)
                                    champsupdate += "pro_complement1,";
                                if (member.professionnal_zip_code != membre.pro_codepostal)
                                    champsupdate += "pro_codepostal,";
                                if (member.professionnal_town != membre.pro_localite)
                                    champsupdate += "pro_localite,";
                                if (member.professionnal_country != membre.pro_pays)
                                    champsupdate += "pro_pays,";


                                if (champsupdate.Length > 0)
                                {
                                    champsupdate = champsupdate.Substring(0, champsupdate.Length - 1);

                                    MembresToUpdate.Add(membre);
                                    sbmaj.AppendLine(membre.nom + " " + membre.prenom + " " + membre.nim + " ... RM plus récent maj (" + champsupdate + ") " + membre.dt_update.ToLocalTime());

                                }
                                else
                                {
                                  //  sbmaj.AppendLine(membre.nom + " " + membre.prenom + " " + membre.nim + " ... RM plus récent sans changements " + membre.dt_update.ToLocalTime());
                                }
                            }
                            else if (membre.dt_update == dtupdaterodiutc)
                            {
                                //sbmembreplusrecentrodi.AppendLine(membre.nom + " " + membre.prenom + " " + membre.nim + " ... RODI et RM identiques " + member.base_dtupdate);
                                MembresPlusRecentRodi.Add(membre);
                            }
                            else
                            {
                                //sbmembreplusrecentrodi.AppendLine(membre.nom + " " + membre.prenom + " " + membre.nim + " ... RODI plus récent " + member.base_dtupdate);
                                MembresPlusRecentRodi.Add(membre);
                            }
                        }
                    }
                 }
            }
        }

        StringBuilder report = new StringBuilder(membres.Count + " membre(s) analysé(s)"+Environment.NewLine);

        if(sberreur.Length>0)
        {
            report.AppendLine(MembresEnErreur.Count+ " membre(s) en erreur : ");
            report.AppendLine(sberreur.ToString());
        }
        if (sbmembresrodiabsentsrm.Length>0)
        {
            report.AppendLine(MembresRodiAbsentRm.Count+" membre(s) rodi absent(s) RM : ");
            report.AppendLine(sbmembresrodiabsentsrm.ToString());
        }
        if (sbmembreentroprm.Length > 0)
        {
            report.AppendLine(MembresEnTropRm.Count + " membre(s) en trop RM : ");
            report.AppendLine(sbmembreentroprm.ToString());
        }
        if (sbmembreplusrecentrodi.Length > 0)
        {
            report.AppendLine(MembresPlusRecentRodi.Count+ " membre(s) plus récents ou identique(s) dans RODI : ");
            report.AppendLine(sbmembreplusrecentrodi.ToString());
        }
        if (sbmaj.Length > 0)
        {
            report.AppendLine(MembresToUpdate.Count + " membre(s) a mettre à jour dans RODI : ");
            report.AppendLine(sbmaj.ToString());
        }


        return report.ToString(); ;
    }

    public static string RM2RODI_Civilite(int civilite)
    {
        switch(civilite)
        {
            case 1:
                return "M";
            case 2:
                return "Mme";            
        }
        return "";
    }
    public static string RM2RODI_Retraite(int statut)
    {
        if (statut == 0)
            return Const.YES;
        return Const.NO;
    }

    public static string MajMembres(List<RotaryMag.Membre> membres)
    {
        StringBuilder sb = new StringBuilder();
        DateTime maintenant = DateTime.Now; 
        foreach(var membre in membres)
        {
            SqlCommand sql = new SqlCommand("UPDATE "+Const.TABLE_PREFIX+"members SET " +
                "spouse_name=@spouse_name," +
                "civility=@civility,"+
                "retired=@retired,"+
                "phf=@phf,"+
                "legion_honneur=@legion_honneur,"+
                "ordre_merite=@ordre_merite,"+
                "palmes_academiques=@palmes_academiques,"+
                "medaille_militaire=@medaille_militaire,"+
                "croix_guerre=@croix_guerre,"+
                "autre_decorations=@autre_decorations,"+
                "adress_1=@adress_1," +
                "adress_2=@adress_2,"+
                "zip_code=@zip_code,"+
                "town=@town,"+
                "country=@country,"+
                "pro_secteur_activite=@pro_secteur_activite,"+
                "job=@job," +
                "fonction=@fonction,"+
                "professionnal_company=@professionnal_company,"+
                "no_adr_pro=@no_adr_pro,"+
                "professionnal_adress=@professionnal_adress,"+
                "professionnal_additional=@professionnal_additional,"+
                "professionnal_zip_code=@professionnal_zip_code,"+
                "professionnal_town=@professionnal_town,"+
                "professionnal_country=@professionnal_country," +
                "annee_entree_club=@annee_entree_club," +
                "base_dtupdate=@base_dtupdate," +
                "[dt_update_import_rm]=@dt_update_import_rm" +
                " WHERE nim=@nim");
            sql.Parameters.AddWithValue("nim", membre.nim);
            sql.Parameters.AddWithValue("spouse_name", ""+membre.prenom_conjoint);
            sql.Parameters.AddWithValue("civility", RM2RODI_Civilite(membre.civilite));
            sql.Parameters.AddWithValue("retired", RM2RODI_Retraite(membre.statut_pro));
            sql.Parameters.AddWithValue("phf", "" + membre.phf);
            sql.Parameters.AddWithValue("legion_honneur", ""+membre.legion_honneur);
            sql.Parameters.AddWithValue("ordre_merite", "" + membre.ordre_merite);
            sql.Parameters.AddWithValue("palmes_academiques", "" + membre.palmes_academiques);
            sql.Parameters.AddWithValue("medaille_militaire", membre.medaille_militaire);
            sql.Parameters.AddWithValue("croix_guerre", membre.croix_guerre);
            sql.Parameters.AddWithValue("autre_decorations", membre.autre_decorations);
            sql.Parameters.AddWithValue("adress_1", ""+membre.adresse);
            sql.Parameters.AddWithValue("adress_2", ""+membre.complement1);
            sql.Parameters.AddWithValue("zip_code", ""+membre.codepostal);
            sql.Parameters.AddWithValue("town", ""+membre.localite);
            sql.Parameters.AddWithValue("country", ""+membre.pays);
            sql.Parameters.AddWithValue("pro_secteur_activite", membre.pro_secteur_activite);
            sql.Parameters.AddWithValue("job", ""+membre.pro_metier);
            sql.Parameters.AddWithValue("fonction", ""+membre.pro_fonction);
            sql.Parameters.AddWithValue("professionnal_company", ""+membre.pro_raison_sociale);
            sql.Parameters.AddWithValue("no_adr_pro", membre.no_adr_pro);
            sql.Parameters.AddWithValue("professionnal_adress", ""+membre.pro_adresse);
            sql.Parameters.AddWithValue("professionnal_additional",""+ membre.pro_complement1);
            sql.Parameters.AddWithValue("professionnal_zip_code", ""+membre.pro_codepostal);
            sql.Parameters.AddWithValue("professionnal_town", ""+membre.pro_localite);
            sql.Parameters.AddWithValue("professionnal_country", ""+membre.pro_pays);
            sql.Parameters.AddWithValue("annee_entree_club", membre.annee_entree_club);

            sql.Parameters.AddWithValue("base_dtupdate", membre.dt_update.ToLocalTime()); // on met la date de rm dans dt update pour ne pas entrer dans une boucle infinie avec RM
            sql.Parameters.AddWithValue("dt_update_import_rm", maintenant); // la date d'import rm est la date ou on a mis a jour le membre de rm dans rodi

            if (Yemon.dnn.DataMapping.ExecSqlNonQuery(sql) > 0)
            {
                sb.AppendLine("maj ... " + membre.nom + " " + membre.prenom + " " + membre.nim);
            }
            else
            {
                sb.AppendLine("erreur maj ... " + membre.nom + " " + membre.prenom + " " + membre.nim +" ("+Yemon.dnn.DataMapping.lastException.Message+")");
            }
        }
        sb.AppendLine(membres.Count + " membre(s) traité(s)");

        return sb.ToString();
    }

    public static List<Club> GetDistrictClubsAffectedBySynchro()
    {
        return Yemon.dnn.DataMapping.ExecSql<Club>(new SqlCommand("select * from " + Const.TABLE_PREFIX + "clubs WHERE type_club='rotary'"));
    }

    public static List<Member> GetDistrictMembersAffectedBySynchro()
    {
        return Yemon.dnn.DataMapping.ExecSql<Member>(new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE cric IN (select cric from " + Const.TABLE_PREFIX + "clubs WHERE type_club='rotary') ORDER BY cric"));
    }

    public static List<RotaryMag.Membre_Recherche> Annuaire(int nim, string search)
    {
        var liste = new List<RotaryMag.Membre_Recherche>();

        try
        {
            _param = GetParametres();
            if (_param == null)
                throw new Exception("Erreur de récupération des paramètres");

            var task = Task.Run(() => CallAsyncLogin());
            task.Wait();

            if (JWT_TOKEN == null)
            {
                throw new Exception("Erreur de login");
            }

            var task1 = Task.Run(() => CallAsyncAnnuaire(nim,search));
            task1.Wait();
            
            liste = task1.Result;
        }
        catch (Exception e)
        {
            Functions.Error(e);
        }

        return liste;
    }

    public static async Task<List<RotaryMag.Membre_Recherche>> CallAsyncAnnuaire(int nim, string recherche)
    {


        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWT_TOKEN.accessToken);

        var jsonOject = new
        {
            nim = nim,            
            recherche = recherche
        };
        var content = new StringContent(Yemon.dnn.Functions.Serialize(jsonOject), Encoding.UTF8, "application/json");

        var result = await httpClient.PostAsync(_param.url_annuaire, content);
        if (result.IsSuccessStatusCode)
        {
            string t = result.Content.ReadAsStringAsync().Result;
       
            List<RotaryMag.Membre_Recherche> membres = Yemon.dnn.Functions.Deserialize<List<RotaryMag.Membre_Recherche>>(t);
            return membres;
        }

        return null;
    }

    public static string CorrectionCodesPays()
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sberr = new StringBuilder();

        var members = GetDistrictMembersAffectedBySynchro();

        foreach ( var member in members )
        {
            var last_country = member.country;
            var last_professionnal_country = member.professionnal_country;

            member.country = CountryToISO(member.country);
            member.professionnal_country=CountryToISO(member.professionnal_country);

            if(member.country!=last_country || member.professionnal_country != last_professionnal_country)
            {
                if (DataMapping.UpdateMember(member))
                    sb.AppendLine("maj ... " + member.surname + " " + member.name + " " + member.nim + " - pays :" + member.country + ", pays pro :" + member.professionnal_country);
                else
                    sberr.AppendLine("erreur ... " + member.surname + " " + member.name + " " + member.nim);
            }
        }
        string result = "";
        if(sberr.Length> 0)
        {
            result += "Membres en erreur :" + Environment.NewLine;
            result += sberr.ToString();
        }
        if (sb.Length > 0)
        {
            result += Environment.NewLine;
            result = "Membres maj :" + Environment.NewLine;
            result += sb.ToString();
        }
        return result;
    }
}