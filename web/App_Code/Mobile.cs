using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using AIS;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Mail;
using Newtonsoft.Json;

/// <summary>
/// Description résumée de Mobile
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]
public class Mobile : System.Web.Services.WebService {

    public Mobile () {

        //Supprimez les marques de commentaire dans la ligne suivante si vous utilisez des composants conçus 
        //InitializeComponent(); 
    }

    private string GetBaseUrl()
    {
        Uri uri = new Uri(DotNetNuke.Common.Globals.NavigateURL());
        return uri.ToString().Replace(uri.PathAndQuery, "") + "/";
    }

    private string urlNews = "LesNouvelles/Clubs.aspx";
    private string os = "Android";

    private string getIP()
    {
        return HttpContext.Current.Request.UserHostAddress;
    }

    private float getDuree(DateTime start)
    {
        TimeSpan ticks = DateTime.Now - start;
        return (float)ticks.TotalMilliseconds;
    }

    [WebMethod]
    public string HelloWorld(string username, string password, string device, string version, string fonction)
    {
        return "Hello World " + GetBaseUrl();
    }

    [WebMethod]
    public string ConnectFromAndroid(string username, string password, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        string token = "0";
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return token;
        }
        SqlConnection conn = new SqlConnection(DotNetNuke.Common.Utilities.Config.GetConnectionString());

        try
        {
            UserInfo user = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, username);
            if (user != null)
            {
                MembershipUser objUser = Membership.GetUser(user.Username);
                if (objUser != null)
                {
                    string strPassword = objUser.GetPassword();
                    if (!string.IsNullOrEmpty(strPassword))
                    {
                        string defaultPassMD5 = Functions.CalculateMD5Hash(Functions.StringToBytes(strPassword));

                        if (!string.IsNullOrEmpty(defaultPassMD5))
                        {
                            if (password.ToLower() == defaultPassMD5.ToLower())
                            {
                                token = "1";
                                //break;
                            }
                        }
                        else
                        {
                            throw new Exception("defaultPassMD5 NULL ou  vide pour le username " + username);
                        }
                    }
                    else
                    {
                        throw new Exception("strPassword NULL ou  vide pour le username " + username);
                    }
                }
                else
                {
                    throw new Exception("objUser NULL pour le username " + username);
                }
            }
            else
            {
                throw new Exception("user NULL pour le username " + username);
            }
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
            comment = ee.ToString();
            code = "erreur";
        }
        finally
        {
            conn.Close();
            conn.Dispose();


            if (token == "1")
            {
                comment = "Identification réussie";
            }
            else
            {
                if (comment == "")
                {
                    comment = "Identification refusée";
                }
            }

            DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, username);
        }

        return token;
    }

    [WebMethod]
    public Membre memberToMembre(Member m)
    {
        Membre membre = new Membre();

        membre.id = m.id;
        membre.nim = m.nim;
        membre.membre_honneur = m.honorary_member;
        membre.nom = m.surname;
        membre.prenom = m.name;
        membre.cric = m.cric;
        membre.membre_actif = m.active_member;
        membre.civilite = m.civility;
        membre.nom_jeune_fille = m.maiden_name;
        membre.prenom_conjoint = m.spouse_name;
        membre.titre = m.title;
        membre.annee_naissance = m.birth_year;
        membre.annee_adhesion_rotary = m.year_membership_rotary;
        membre.email = m.email;
        membre.adresse_1 = m.adress_1;
        membre.adresse_2 = m.adress_2;
        membre.adresse_3 = m.adress_3;
        membre.code_postal = m.zip_code;
        membre.ville = m.town;
        membre.telephone = m.telephone;
        membre.fax = m.fax;
        membre.gsm = m.gsm;
        membre.pays = m.country;
        membre.fonction_metier = m.job;
        membre.branche_activite = m.industry;
        membre.biographie = m.biography;
        membre.date_majbase = m.base_dtupdate;
        membre.adresse_professionnelle = m.professionnal_adress;
        membre.code_postal_professionnel = m.professionnal_zip_code;
        membre.ville_professionnel = m.professionnal_town;
        membre.tel_professionnel = m.professionnal_tel;
        membre.fax_professionnel = m.professionnal_fax;
        membre.portable_professionnel = m.professionnal_mobile;
        membre.email_professionnel = m.professionnal_email;
        membre.retraite = m.retired;
        membre.radie = m.removed;
        membre.district_id = m.district_id;
        membre.nom_club = m.club_name;
        membre.userid = m.userid;
        membre.photo = m.photo;
        membre.visible = m.visible;
        membre.presentation = m.presentation;
        membre.fonction_rotarienne = m.fonction_rotarienne;

        return membre;
    }

    [WebMethod]
    public Nouvelle newsToNouvelle(News news)
    {
        Nouvelle nouvelle = new Nouvelle();
        nouvelle.id = news.id;
        nouvelle.cric = news.cric;
        nouvelle.dt = news.dt;
        nouvelle.titre = news.title;
        nouvelle.texte = news.text;
        nouvelle.url_texte = news.url_text;
        nouvelle.photo = news.photo;
        nouvelle.categorie = news.category;
        nouvelle.tag1 = news.tag1;
        nouvelle.tag2 = news.tag2;
        nouvelle.nom_club = news.club_name;
        nouvelle.visible = news.visible;
        nouvelle.PhotoString64 = news.PhotoString64;
        nouvelle.urlNouvelle = news.urlNews;
        nouvelle.type_club = news.club_type;

        return nouvelle;
    }

    [WebMethod]
    public string GetListMembers(int cric, string critere, string top, string tri, int index, int max, bool onlyvisible, string username, string password, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<Member> lm = new List<Member>();
        List<Membre> ln = new List<Membre>();
        try
        {
            string token = ConnectFromAndroid(username, password, device, version, fonction);

            bool court = true;
            if (token == "1")
            {
                court = false;
            }

            lm = DataMapping.ListMembers(cric, critere, top, tri, index, max, onlyvisible, court);

            DateTime now = DateTime.Now;
            int year = 0;
            int.TryParse(now.ToString("yyyy"), out year);

            foreach (Member m in lm)
            {
                m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());

                if (year > 0)
                {
                    Affectation aff = DataMapping.GetAffectation(m.nim, year);
                    if (aff != null && !string.IsNullOrEmpty(aff.function))
                    {
                        m.fonction_rotarienne = aff.function;
                    }
                }
                ln.Add(memberToMembre(m));
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();

            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ln, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, username);
        return output;
    }

    [WebMethod]
    public string GetListMembersV2(int cric, string critere, string top, string tri, int index, int max, bool onlyvisible, string username, string password, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<Member> lm = new List<Member>();
        List<Membre> ln = new List<Membre>();
        try
        {
            string token = ConnectFromAndroid(username, password, device, version, fonction);

            bool court = true;
            if (token == "1")
            {
                court = false;
            }

            lm = DataMapping.ListMembers(cric, critere, top, tri, index, max, onlyvisible, court);

            DateTime now = DateTime.Now;
            int year = 0;
            int.TryParse(now.ToString("yyyy"), out year);

            foreach (Member m in lm)
            {
                m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());

                Content c = DataMapping.GetContentPagePro(m.userid);
                if (c != null)
                {
                    m.presentation = true;
                }
                else
                {
                    m.presentation = false;
                }

                if (year > 0)
                {
                    Affectation aff = DataMapping.GetAffectation(m.nim, year);
                    if (aff != null && !string.IsNullOrEmpty(aff.function))
                    {
                        m.fonction_rotarienne = aff.function;
                    }
                }

                ln.Add(memberToMembre(m));
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();

            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ln, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, username);
        return output;
    }


    [WebMethod]
    public string ListMembersPresentation(int cric, string critere, string top, string tri, int index, int max, bool onlyvisible, string username, string password, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<Member> lm = new List<Member>();
        List<Membre> ln = new List<Membre>();
        try
        {
            string token = ConnectFromAndroid(username, password, device, version, fonction);

            bool court = true;
            if (token == "1")
            {
                court = false;
            }

            lm = DataMapping.ListMembersPresentation(cric, critere, top, tri, index, max, onlyvisible, court);
            foreach (Member m in lm)
            {
                m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());
                m.presentation = true;
                ln.Add(memberToMembre(m));
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ln, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, username);

        return output;
    }

    [WebMethod]
    public string GetPhotoMember(string filepath, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        MemoryStream ms = new MemoryStream();
        try
        {
            FileInfo f = new FileInfo(filepath);
            if (f.Exists)
            {
                Image img = Image.FromFile(filepath);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }
        string jsonString = Convert.ToBase64String(ms.ToArray());
        string output = JsonConvert.SerializeObject(jsonString);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string ListClub(string dept, string top, string tri, int index, int max, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<Club> lm = new List<Club>();

        try
        {
            lm = DataMapping.ListClubs(dept, top, tri, index, max);
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(lm, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string GetClub(int cric, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        Club lm = new Club();

        try
        {
            lm = DataMapping.GetClub(cric);

        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(lm, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string ListNews(int cric, string categorie, string tags_inclus, string tags_excluded, string top, string tri, int index, int max, bool onlyvisible, string date, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<News> lm = new List<News>();
        List<Nouvelle> ln = new List<Nouvelle>();
        try
        {
            lm = AIS.DataMapping.ListNewsMobile(cric, categorie, tags_inclus, tags_excluded, top, tri, index, max, onlyvisible, date);
            foreach (News m in lm)
            {
                m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());
                //m.url = HttpContext.Current.Server.MapPath(m.GetUrl());
                m.PhotoString64 = GetPhotoNew(m.photo, device, version, fonction);

                string url = "" + m.GetUrl();
                if (!string.IsNullOrEmpty(url))
                {
                    m.url = GetBaseUrl() + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                    //m.url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority  + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                }

                m.urlNews = GetBaseUrl() + urlNews + "?newsid=" + m.id + "&cric=" + m.cric;
                
            }

            foreach (News m in lm)
            {
                ln.Add(newsToNouvelle(m));
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ln, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }


    [WebMethod]
    public string ListNewsV2(string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        List<News> lm = new List<News>();
        List<Nouvelle> ln = new List<Nouvelle>();
        try
        {
            List<News> temp = new List<News>();

            List<News> newsDistrict = (from n in AIS.DataMapping.ListNews(onlyvisible: true, category: "District", tags_excluded: "Bulletin") orderby n.dt ascending where n.dt.CompareTo(DateTime.Now.AddDays(-1)) > 0 select n).ToList<News>();
            List<News> newsClubs = (from n in AIS.DataMapping.ListNews(onlyvisible: true, category: "Clubs", tags_excluded: "Bulletin") orderby n.dt ascending where n.dt.CompareTo(DateTime.Now.AddDays(-1)) > 0 select n).ToList<News>();

            if (newsDistrict != null && newsDistrict.Count() > 0)
            {
                foreach (News m in newsDistrict)
                {
                    m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());
                    //m.url = HttpContext.Current.Server.MapPath(m.GetUrl());
                    m.PhotoString64 = GetPhotoNew(m.photo, device, version, fonction);

                    string url = "" + m.GetUrl();
                    if (!string.IsNullOrEmpty(url))
                    {
                        m.url = GetBaseUrl() + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                        //m.url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority  + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                    }

                    m.urlNews = GetBaseUrl() + urlNews + "?newsid=" + m.id + "&cric=" + m.cric;

                    temp.Add(m);
                }
            }

            if (newsClubs != null && newsClubs.Count() > 0)
            {
                foreach (News m in newsClubs)
                {
                    m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());
                    //m.url = HttpContext.Current.Server.MapPath(m.GetUrl());
                    m.PhotoString64 = GetPhotoNew(m.photo, device, version, fonction);

                    string url = "" + m.GetUrl();
                    if (!string.IsNullOrEmpty(url))
                    {
                        m.url = GetBaseUrl() + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                        //m.url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority  + HttpContext.Current.Server.UrlPathEncode(m.GetUrl());
                    }

                    m.urlNews = GetBaseUrl() + urlNews + "?newsid=" + m.id + "&cric=" + m.cric;

                    temp.Add(m);
                }
            }

            if (temp != null && temp.Count() > 0)
            {
                lm = temp.OrderBy(x => x.dt).ToList<News>();               
            }
            foreach (News n in lm)
            {
                ln.Add(newsToNouvelle(n));
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ln, Formatting.Indented);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string GetPhotoNew(string filepath, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        MemoryStream ms = new MemoryStream();

        try
        {
            FileInfo f = new FileInfo(filepath);
            if (f.Exists)
            {
                Image img = Image.FromFile(filepath);
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();
            Functions.Error(ee);
        }
        string jsonString = Convert.ToBase64String(ms.ToArray());
        string output = JsonConvert.SerializeObject(jsonString);

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string SendMail(string MemberID, string exp, string nom, string obj, string msg, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        string retour = "1";

        try
        {
            int id = 0;
            Member member = null;
            Membre membre = null;
            string message = "Vous avez un message à partir de l'application mobile du district : www.rotary1730.org<br/>";
            message += "Nom & Prenom : " + nom + "<br/>";
            message += "Email : " + exp + "<br/>";
            message += "Message : <br/>";
            message += msg;

            PortalSettings ps = PortalController.GetCurrentPortalSettings();

            if (!string.IsNullOrEmpty(MemberID))
            {
                int.TryParse(MemberID, out id);
                if (id > 0)
                {
                    member = DataMapping.GetMember(id);
                }
            }

            if (member != null)
            {
                membre = memberToMembre(member);
                Mail.SendEmail(exp, ps.Email, membre.email, obj, message);
            }
            else //Envoie au webmaster
            {
                Mail.SendEmail(exp, ps.Email, ps.Email, obj, message);
            }

        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();

            Functions.Error(ee);
            retour = "0";
        }

        string output = JsonConvert.SerializeObject(retour);

        if (retour == "1")
        {
            comment = "Mail envoyé de " + exp + " à Member ID " + MemberID;
        }
        else
        {
            if (comment == "")
            {
                comment = "Mail NON envoyé de " + exp + " à Member ID " + MemberID;
            }
        }

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, "");

        return output;
    }

    [WebMethod]
    public string GetPassword(string UserName, string device, string version, string fonction)
    {
        DateTime dt = DateTime.Now;
        string comment = "";
        string code = "ok";

        string retour = "0";
        string Password = "";

        try
        {
            DotNetNuke.Entities.Users.UserInfo userInfo = DotNetNuke.Entities.Users.UserController.GetUserByName(Globals.GetPortalSettings().PortalId, UserName);
            if (userInfo != null)
            {
                DotNetNuke.Security.Membership.MembershipProvider membershipProvider = DotNetNuke.Security.Membership.MembershipProvider.Instance();

                Password = "" + DotNetNuke.Entities.Users.UserController.GetPassword(ref userInfo, userInfo.Membership.PasswordAnswer);

                if (!string.IsNullOrEmpty(Password))
                {
                    string message = "Récupération de votre mot de passe à partir de l'application mobile du district : www.rotary1730.org<br/>";
                    message += "Votre mot de passe est : <br/>";
                    message += Password;

                    PortalSettings ps = PortalController.GetCurrentPortalSettings();
                    Mail.SendEmail(ps.Email, ps.Email, userInfo.Email, "Récupération de votre mot de passe", message);

                    retour = "1";
                }
            }
        }
        catch (Exception ee)
        {
            code = "erreur";
            comment = ee.ToString();

            Functions.Error(ee);
            retour = "0";
        }

        string output = JsonConvert.SerializeObject(retour);

        if (retour == "1")
        {
            comment = "Password envoyé à " + UserName;
        }
        else
        {
            if (comment == "")
            {
                comment = "Password NON envoyé à " + UserName;
            }
        }

        DataMapping.InsertLogWS(os, device, version, getIP(), dt, getDuree(dt), fonction, code, comment, UserName);

        return output;
    }

}
