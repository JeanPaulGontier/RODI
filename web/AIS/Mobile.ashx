<%@ WebHandler Language="C#" Class="Mobile" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text;
using AIS;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using DotNetNuke.Entities.Users;
using DotNetNuke.Common;
using System.Web.Security;

public class Mobile : IHttpHandler {

    private string GetBaseUrl()
    {
        try
        {
            Uri uri = new Uri(DotNetNuke.Common.Globals.NavigateURL());
            return uri.ToString().Replace(uri.PathAndQuery, "") + "/";
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }

    private string getIP()
    {
        try
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
            return null;
        }
    }

    private float getDuree(DateTime start)
    {
        try
        {
            TimeSpan ticks = DateTime.Now - start;
            return (float)ticks.TotalMilliseconds;
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
            return 0;
        }
    }

    private byte[] ObjectToByteArray(object obj)
    {
        if(obj == null)
            return null;
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }

    public static byte[] SerializeToBytes(Object Obj)
    {
        //if (UseBinarySerialization)
        //{
        MemoryStream m = new MemoryStream();
        BinaryFormatter b = new BinaryFormatter();
        b.Serialize(m, Obj);
        byte[] ba = m.ToArray();
        m.Close();
        return Compress(ba);
        //}
        //else
        //{
        //string ret = Serialize(Obj);
        //System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        //return Compress(encoding.GetBytes(ret));
        //}
    }

    public static String Serialize(Object Obj)
    {
        XmlSerializer serializer = new XmlSerializer(Obj.GetType());
        StringBuilder sb = new StringBuilder();
        StringWriter writer = new StringWriter(sb);
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();// on vire le namespace car ca sert a rien dans notre cas c'est quelques dizaines d'octets
        namespaces.Add(string.Empty, string.Empty);
        serializer.Serialize(writer, Obj, namespaces);
        writer.Close();
        writer.Dispose();
        return sb.ToString();
    }

    public static byte[] Compress(byte[] bytes)
    {
        MemoryStream ms = new MemoryStream();

        using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
        {
            zip.Write(bytes, 0, bytes.Length);

        }

        return ms.ToArray();
    }




    public void ProcessRequest (HttpContext context)
    {
        try
        {
            ParamsMobile mobParams = null;
            var data = context.Request;
            context.Response.ContentType = "application/json";
            var sr = new StreamReader(data.InputStream);
            var stream = sr.ReadToEnd();

            var javaScriptSerializer = new JavaScriptSerializer();
            mobParams = javaScriptSerializer.Deserialize<ParamsMobile>(stream);

            string retour = "";
            byte[] returnByte = new byte[0];

            if (mobParams != null)
            {
                int idLog = 0;
                DateTime start = DateTime.Now;
                string comment ="";

                //Log 
                idLog = DataMapping.InsertUpdateLogMobile(idLog, mobParams.os, mobParams.device, mobParams.version, getIP(), start, 0, mobParams.fonction, "", "", mobParams.username);

                switch (mobParams.fonction)
                {
                    case "GetToken":
                        string token = "";
                        if (!string.IsNullOrEmpty(mobParams.username) && !string.IsNullOrEmpty(mobParams.password))
                        {
                            UserInfo user = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, mobParams.username);

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
                                            if (mobParams.password.ToLower() == defaultPassMD5.ToLower())
                                            {
                                                token = "1";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        retour = JsonConvert.SerializeObject(token);
                        break;
                    case "SendMessage":
                        Functions.SendMail(mobParams.SendMess_Email, mobParams.SendMess_Subject, mobParams.SendMess_Message);
                        retour = JsonConvert.SerializeObject("Message envoyé");
                        break;

                    case "GetPresentation":
                        int membreID = 0;
                        int.TryParse(mobParams.MembreID, out membreID);
                        retour = JsonConvert.SerializeObject(DataMapping.GetContent(membreID));
                        break;

                    case "GetListMembers":
                        List<Member> lm = DataMapping.ListMembers(mobParams.cric, mobParams.critere, mobParams.top, mobParams.tri, mobParams.index, mobParams.max, mobParams.onlyvisible, false);
                        List<Member> ln = new List<Member>();
                        if (lm != null)
                        {
                            foreach (Member m in lm)
                            {
                                //m.photo = HttpContext.Current.Server.MapPath(m.GetPhoto());
                                m.photo = m.GetPhoto();


                                //if (year > 0)
                                //{
                                //Affectation aff = DataMapping.GetAffectation(m.nim, year);
                                Affectation aff = DataMapping.GetAffectation(m.nim, Functions.GetRotaryYear());
                                if (aff != null && !string.IsNullOrEmpty(aff.function))
                                {
                                    m.fonction_rotarienne = aff.function;
                                }
                                else
                                {
                                    m.fonction_rotarienne = "";
                                }
                                //}

                                ln.Add(m);
                            }
                        }
                        retour = JsonConvert.SerializeObject(ln);
                        //returnByte = SerializeToBytes(DataMapping.ListMembers(mobParams.cric, mobParams.critere, mobParams.top, mobParams.tri, mobParams.index, mobParams.max, mobParams.onlyvisible, false));
                        break;
                    //case "GetListMembersV2":
                    //    retour = DataMapping.get.GetListMembersV2(cric, critere, top, tri, index, max, onlyvisible, username, password, device, version, fonction);
                    //    break;
                    case "GetListMembersPro":
                        List<Member> lmpro = DataMapping.ListMembersPresentation(mobParams.cric, mobParams.critere, mobParams.top, mobParams.tri, mobParams.index, mobParams.max, mobParams.onlyvisible, false);
                        List<Member> lnpro = new List<Member>();
                        if (lmpro != null)
                        {
                            foreach (Member mpro in lmpro)
                            {
                                mpro.photo = mpro.GetPhoto(); // HttpContext.Current.Server.MapPath(mpro.GetPhoto());
                                mpro.presentation = true;

                                lnpro.Add(mpro);
                            }
                        }
                        retour = JsonConvert.SerializeObject(lnpro);
                        //retour = JsonConvert.SerializeObject(DataMapping.ListMembersPresentation(mobParams.cric, mobParams.critere, mobParams.top, mobParams.tri, mobParams.index, mobParams.max, mobParams.onlyvisible, false));
                        //returnByte = SerializeToBytes(DataMapping.ListMembersPresentation(mobParams.cric, mobParams.critere, mobParams.top, mobParams.tri, mobParams.index, mobParams.max, mobParams.onlyvisible, false));
                        break;
                    //case "GetPhotoMember":
                    //    retour = a.GetPhotoMember(filepath, device, version, fonction);
                    //    break;
                    case "ListClub":
                        //List<Club> lc = new List<Club>();
                        //Club c1 = new Club();
                        //c1.cric = 11209;
                        //c1.name = "SOPHIA ANTIPOLIS";
                        //lc.Add(c1);
                        //retour = JsonConvert.SerializeObject(lc);
                        retour = JsonConvert.SerializeObject(DataMapping.ListClubs(mobParams.dept, mobParams.top, mobParams.tri, mobParams.index, mobParams.max, mobParams.club_type));
                        //returnByte = SerializeToBytes(DataMapping.ListClubs(mobParams.dept, mobParams.top, mobParams.tri, mobParams.index, mobParams.max, mobParams.club_type));
                        break;
                    //case "GetClub":
                    //    retour = a.GetClub(cric, device, version, fonction);
                    //    break;
                    case "GetListNews":
                        List<News> lnews = DataMapping.ListNews_EN(mobParams.cric, mobParams.categorie, mobParams.tags_inclus, mobParams.tags_exclus, mobParams.top, mobParams.tri, mobParams.index, mobParams.max, mobParams.onlyvisible, mobParams.obj);
                        if(lnews != null)
                        {
                            foreach(News n in lnews)
                            {
                                n.photo = n.GetPhoto();
                                n.photo = "https://" + HttpContext.Current.Request.Url.Host + n.photo;
                            }
                        }
                        retour = JsonConvert.SerializeObject(lnews);
                        break;
                    case "GetNews":
                        News nn = DataMapping.GetNews(mobParams.MembreID);
                        if(nn != null)
                        {
                            nn.photo = "https://" + HttpContext.Current.Request.Url.Host + nn.GetPhoto();
                        }
                        retour =  JsonConvert.SerializeObject(nn);
                        break;
                        //case "GetPhotoNew":
                        //    retour = a.GetPhotoNew(filepath, device, version, fonction);
                        //    break;

                        //case "GetPassword":
                        //    retour = a.GetPassword(username, device, version, fonction);
                        //    break;


                        //retour = DataMapping.ReturnJSON<string>(machin);

                        //DataMapping.UpdateLogMobile(idLog, getDuree(start), GetHashCode, comment);
                }
                context.Response.ContentType = "text/plain";
                context.Response.Write(retour);
                //context.Response.ContentType = "application/octet-stream";
                //context.Response.BinaryWrite(returnByte);
                //context.Response.Flush();

                string code = "ok";

                if(retour == null) { code = "erreur";  }

                //Log 
                idLog = DataMapping.InsertUpdateLogMobile(idLog, mobParams.os, mobParams.device, mobParams.version, getIP(), start, getDuree(start), mobParams.fonction, code, comment, mobParams.username);
                if (idLog == 0)
                {
                    throw new Exception("Erreur de mise à jour des logs");
                }
            }
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }
    }

    public List<string> HelloWorld()
    {
        List<string> ls = new List<string>();
        ls.Add("Hello World ");
        ls.Add("" + GetBaseUrl());


        return ls;
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}