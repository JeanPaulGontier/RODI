<%@ WebHandler Language="C#" Class="WindowsPhone" %>

using System;
using System.Web;
using AIS;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Mail;
using Newtonsoft.Json;

public class WindowsPhone : IHttpHandler {

    private string urlNews = "LesNouvelles/Clubs.aspx";
    private string os = "WinPhone";
    
    private string GetBaseUrl()
    {
        Uri uri = new Uri(DotNetNuke.Common.Globals.NavigateURL());
        return uri.ToString().Replace(uri.PathAndQuery, "") + "/";
    }

    private string getIP()
    {
        return HttpContext.Current.Request.UserHostAddress;
    }

    private float getDuree(DateTime start)
    {
        TimeSpan ticks = DateTime.Now - start;
        return (float)ticks.TotalMilliseconds;
    }
    
    public void ProcessRequest (HttpContext context) {
        string fonction = "" + context.Request.QueryString["fonction"];
        string device = "" + context.Request.QueryString["device"];
        string version = "" + context.Request.QueryString["version"];
        string username = "" + context.Request.QueryString["username"];
        string password = "" + context.Request.QueryString["password"];
        int cric = 0;
        int.TryParse("" + context.Request.QueryString["cric"], out cric);
        string critere = "" + context.Request.QueryString["critere"];
        string top = "" + context.Request.QueryString["top"];
        string tri = "" + context.Request.QueryString["tri"];
        int index = 0;
        int.TryParse("" + context.Request.QueryString["index"], out index);
        int max = 0;
        int.TryParse("" + context.Request.QueryString["max"], out max);
        bool onlyvisible = true;
        bool.TryParse("" + context.Request.QueryString["onlyvisible"], out onlyvisible);
        string filepath = "" + context.Request.QueryString["filepath"];
        string dept = "" + context.Request.QueryString["dept"];
        string categorie = "" + context.Request.QueryString["categorie"];
        string tags_inclus = "" + context.Request.QueryString["tags_inclus"];
        string tags_exclus = "" + context.Request.QueryString["tags_exclus"];
        string date = "" + context.Request.QueryString["date"];
        //MembreID, string exp, string nom, string obj, string msg
        string MembreID = "" + context.Request.QueryString["MembreID"];
        string exp = "" + context.Request.QueryString["exp"];
        string nom = "" + context.Request.QueryString["nom"];
        string obj = "" + context.Request.QueryString["date"];
        string msg = "" + context.Request.QueryString["msg"];
        
        Android a = new Android();
        string retour = "";        
        
        switch (fonction)
        {                
            case "HelloWorld":
                retour = a.HelloWorld(username, password, device, version, fonction);
                break;

            case "ConnectFromAndroid":
                retour = a.ConnectFromAndroid(username, password, device, version, fonction);
                break;

            case "GetListMembers":
                retour = a.GetListMembers(cric, critere, top, tri, index, max, onlyvisible, username, password, device, version, fonction);
                break;
            case "GetListMembersV2":
                retour = a.GetListMembersV2(cric, critere, top, tri, index, max, onlyvisible, username, password, device, version, fonction);
                break;
            case "ListMembersPresentation":
                retour = a.ListMembersPresentation(cric, critere, top, tri, index, max, onlyvisible, username, password, device, version, fonction);
                break;
            case "GetPhotoMember":
                retour = a.GetPhotoMember(filepath, device, version, fonction);
                break;
            case "ListClub":
                retour = a.ListClub(dept, top, tri, index, max, device, version, fonction);
                break;
            case "GetClub":
                retour = a.GetClub(cric, device, version, fonction);
                break;
            case "ListNews":
                retour = a.ListNews(cric, categorie, tags_inclus, tags_exclus, top, tri, index, max, onlyvisible, date, device, version, fonction);
                break;
            case "ListNewsV2":
                retour = a.ListNewsV2(device, version, fonction);
                break;
            case "GetPhotoNew":
                retour = a.GetPhotoNew(filepath, device, version, fonction);
                break;
            case "SendMail":
                retour = a.SendMail(MembreID, exp, nom, obj, msg, device, version, fonction);
                break;
            case "GetPassword":
                retour = a.GetPassword(username, device, version, fonction);
                break;
        }
        
        context.Response.ContentType = "text/plain";
        context.Response.Write(retour);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    

}