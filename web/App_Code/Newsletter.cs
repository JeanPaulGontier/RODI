using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using AIS;
using DotNetNuke.Entities.Host;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using DotNetNuke.Services.Mail;
using System.Threading;
using DotNetNuke.UI.Utilities;
using DotNetNuke.Entities.Portals;
using System.Net.Mail;
using System.Net;
using System.IO;

/// <summary>
/// Description résumée de Newsletter
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]
public class NewsletterWS : System.Web.Services.WebService 
{
    public List<string> la_Liste_Fonction;
    public List<string> La_Liste_Role;
    public string Departement;
    public List<string> La_Liste_AR;
    public string Cric_Members;
    public string President;
    public string Secretaire;

    public NewsletterConfig NConfig = new NewsletterConfig();

    [Serializable]
    public class NewsletterConfig
    {
	public string smtphost="";
        public string smtpemail = "";
        public string smtppassword = "";
        public string urlprefix = "";
        public string urlprefixreplace = "";
        public bool deliverynotification = true;
    }


    public NewsletterWS () {

        //Supprimez les marques de commentaire dans la ligne suivante si vous utilisez des composants conçus 
        //InitializeComponent(); 

        //File.WriteAllText(Server.MapPath("/") + "Newsletter.config", Functions.Serialize(NConfig));
        try
        {
            string fichier = File.ReadAllText(Server.MapPath("/") + "Newsletter.config");
            NConfig = (NewsletterConfig)Functions.Deserialize(fichier, typeof(NewsletterConfig));
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
        }

    }

    public string GetAdminEmail()
    {
        PortalSettings ps = PortalController.GetCurrentPortalSettings();
        return ps.Email;
    }
    public string GetSMTPEmail()
    {
        
        return NConfig.smtpemail;
    }
    public string GetSMTPPassword()
    {

        return NConfig.smtppassword;
    }
    public string ReplaceUrls(string texte, int id)
    {
        //long pre = DateTime.Now.Ticks;

        //File.WriteAllText(Server.MapPath("/"+pre+"texte_" + id + "_a.txt"), texte);

        //StreamWriter sw = new StreamWriter(Server.MapPath("/" + pre + "texte_" + id + "_log.txt"));

        int st = 0;
        int index = texte.IndexOf("=\"http", st);
        //sw.WriteLine("index : "+index+" st : "+st);
        while (st<=texte.Length && index>-1)
        {
            
                index = texte.IndexOf("http", index);
                //sw.WriteLine("index : "+index+" st : "+st);
                int index1 = texte.IndexOf("\"", index + 1);
                //sw.WriteLine("index1 : " + index + " st : " + st);
                if (index1 > index)
                {
                    string url = texte.Substring(index, index1 - index);
                    if(url.ToLower().StartsWith(NConfig.urlprefixreplace))
                    {
                        url = NConfig.urlprefix+ url.Substring(NConfig.urlprefixreplace.Length);
                    }
                    //sw.WriteLine("Url avant modif");
                    //sw.WriteLine(url);
                    url = NConfig.urlprefix+ "/AIS/redir.ashx?id=" + id + "&url=" + HttpUtility.UrlEncode(url);
                    //sw.WriteLine("Url après modif");
                    //sw.WriteLine(url);
                    texte = texte.Substring(0, index) + url + texte.Substring(index1);
                    
                    st = index1;
                }
                else
                {
                    st = index + 6;
                }

                index = texte.IndexOf("=\"http", st);
                //sw.WriteLine("index : " + index + " st : " + st);

        }
        //sw.Flush();
        //sw.Close();

        //File.WriteAllText(Server.MapPath("/" + pre + "texte_" + id + "_b.txt"), texte);
        
        return texte;
    }


    [WebMethod]
    public string HelloWorld(string token) 
    {
        if (!CheckToken(token))
        {
            return "";
        }
        else
        {
            return "Hello World";
        }
    }

    [WebMethod]
    public string Get_Mail_Test(string token)
    {
        if (!CheckToken(token))
        {
            return "Erreur de Token";
        }
        else
        {
            try
            {
                List<Newsletter_Out> Liste_Test = DataMapping.Get_Mails_Test();
                StringBuilder sb = new StringBuilder();
                
                if (Liste_Test != null)
                {
                    if (Liste_Test.Count > 0)
                    {
                        foreach (Newsletter_Out n in Liste_Test)
                        {
                            List<System.Net.Mail.Attachment> att = new List<System.Net.Mail.Attachment>();

                            PortalSettings ps = PortalController.GetCurrentPortalSettings();
                           

                           // string result = Mail.SendEmail(GetAdminEmail(), GetAdminEmail(), n.email, n.la_Newsletter.titre, n.la_Newsletter.texte, att);
                            bool resultat_MAJ = true;
                            
                            try
                            {
                                Newsletter news = DataMapping.GetNewsletter(n.newsletter_id);


                                MailMessage message = new MailMessage(new MailAddress(ps.Email, ps.PortalName), new MailAddress(n.email, ""));
                                
                                message.ReplyToList.Add(new MailAddress(news.sender_email, news.sender_name));
                                //message.ReplyTo = new MailAddress(newsletter.replyemail, newsletter.fromname);
                                message.Subject = n.la_Newsletter.title;
                                message.IsBodyHtml = true;
                                
                                message.Body = ReplaceUrls(n.la_Newsletter.text,n.id);
                                message.BodyEncoding = Encoding.UTF8;
                                message.Headers.Add("X-AIS-Ref", n.newsletter_id);

                                if(NConfig.deliverynotification)
                                {
                                    message.DeliveryNotificationOptions =
                                      DeliveryNotificationOptions.OnFailure |
                                      DeliveryNotificationOptions.OnSuccess |
                                      DeliveryNotificationOptions.Delay;
                                    message.Headers.Add("Disposition-Notification-To", ps.Email);
                                }

                                string SMTPServer = "" + NConfig.smtphost;
                                int portPos = SMTPServer.IndexOf(":");
                                int SMTPPort = 25;
                                if (portPos > -1)
                                {
                                    SMTPPort = int.Parse(SMTPServer.Substring(portPos + 1, SMTPServer.Length - portPos - 1));
                                    SMTPServer = SMTPServer.Substring(0, portPos);
                                }

                                SmtpClient client = new SmtpClient(SMTPServer, SMTPPort);
                                client.UseDefaultCredentials = false;
                                //client.Credentials = new NetworkCredential("" + ps.HostSettings["SMTPUsername"], "" + ps.HostSettings["SMTPPassword"]);
                                client.Credentials = new NetworkCredential(GetSMTPEmail(), GetSMTPPassword());
                                client.Send(message);
                                message.Dispose();

                                sb.AppendLine("Succes de l'envoie du mail Test id = " + n.id.ToString());
                                n.status = "T";
                                n.error = "";
                                resultat_MAJ = DataMapping.Update_Newsletter_Out(n);
                            
                            }
                            catch (Exception ee)
                            {
                                Functions.Error(ee);
                                sb.AppendLine("Erreur lors de l'envoie du mail Test id = " + n.id.ToString());
                                n.status = "E";
                                n.error = ee.Message;
                                resultat_MAJ = DataMapping.Update_Newsletter_Out(n);
                            }


                            if (resultat_MAJ == false)
                            {
                                sb.AppendLine("Erreur lors de la MAJ du mail Test id = " + n.id.ToString());
                            }
                        } 
                    }
                    else
                    {
                        return "Pas de mails de Test à envoyer";
                    }
                }
                else
                {
                    return "Problème lors de la récupération des mails de Test";
                }
                return sb.ToString();
            }
            catch(Exception ee)
            {
                Functions.Error(ee);
                return ee.Message;
            }
        }
    }

    [WebMethod]
    public string Get_Newsletter_P(string token)
    {
        if (!CheckToken(token))
        {
            return "Erreur de Token";
        }
        else
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                Newsletter n = DataMapping.GetNewsletter_By_status("P");

                if(n != null)
                {
                    if(!string.IsNullOrEmpty(n.recipient))
                    {
                        List<Member> les_Destinataires = new List<Member>();

                        la_Liste_Fonction = new List<string>();
                        La_Liste_Role = new List<string>();
                        Departement = "";
                        President = "";
                        Secretaire = "";
                        La_Liste_AR = new List<string>();
                        Cric_Members = "";

                        string[] splits = n.recipient.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in splits)
                        {
                            switch (s.Substring(0, 2))
                            {
                                case "R:":
                                    La_Liste_Role.Add(s.Remove(0, 2));
                                    break;

                                case "F:":
                                    la_Liste_Fonction.Add(s.Remove(0, 2));
                                    break;

                                case "D:":
                                    Departement = (s.Remove(0, 2));                                    
                                    break;

                                case "B:":
                                    if (s.Remove(0, 2) == "Président")
                                    {
                                        President = s.Remove(0, 2);
                                    }
                                    else if (s.Remove(0, 2) == "Secrétaire")
                                    {
                                        Secretaire = s.Remove(0, 2);
                                    }
                                    break;

                                case "A:":
                                    La_Liste_AR.Add(s.Remove(0, 2));
                                    break;

                                case "M:":
                                    Cric_Members = s.Remove(0, 2);
                                    break;
                            } // Fin Switch
                        } // Fin foreach

                        if (n.recipient.Contains("R:") || n.recipient.Contains("F:"))
                        {
                            les_Destinataires = Recherche_District();
                        }
                        else
                        {
                            les_Destinataires = Recherche_Club();
                        }

                        if(les_Destinataires != null)
                        {
                            if(les_Destinataires.Count > 0)
                            {
                                bool result = DataMapping.Insert_Newsletter_Out(n, les_Destinataires, "A");

                                if(result == true)
                                {
                                    return null;
                                }
                                else
                                {
                                    sb.AppendLine("Erreur lors de la création des destinataires de la newsletter " + n.id);
                                }
                            }
                            else
                            {
                                sb.AppendLine("Pas de destinataire(s) dans la newsletter " + n.id);
                            } 
                        }
                        else
                        {
                            sb.AppendLine("Problème de récupération des destinataires de la newsletter " + n.id);
                        } 
                    }
                    else
                    {
                        sb.AppendLine("Pas de destinataire(s) dans la newsletter " + n.id);
                    }                    
                }
                else
                {
                    sb.AppendLine("Pas de newsletter en attente.");
                }


                return sb.ToString();
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return ee.Message;
            }
        }
    }

    [WebMethod]
    public string Get_Newsletter_E(string token)
    {
        if (!CheckToken(token))
        {
            return "Erreur de Token";
        }
        else
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                Newsletter n = DataMapping.GetNewsletter_By_status("E");

                if(n != null)
                {
                    List<Newsletter_Out> Liste = DataMapping.Get_Recipient_by_Newsletter_id(n.id, "A");
                    if (Liste != null)
                    {
                        if (Liste.Count > 0)
                        {
                            Newsletter_Out n_o = Liste[0] as Newsletter_Out;
                            //foreach (Newsletter_Out n_o in Liste)
                            //{
                                List<System.Net.Mail.Attachment> att = new List<System.Net.Mail.Attachment>();
                                PortalSettings ps = PortalController.GetCurrentPortalSettings();
                                bool resultat_MAJ = true;
                                try
                                {
                                    string msgbody = n.text;

                                    Member member = DataMapping.GetMemberByNim(n_o.nim);
                                    if(member!=null)
                                    {
                                        msgbody = msgbody.Replace("#prenom#", member.name);
                                        msgbody = msgbody.Replace("#nom#", member.surname);
                                        msgbody = msgbody.Replace("#email#", member.email);
                                        

                                    }
                                    else
                                    {
                                            msgbody = msgbody.Replace("#prenom#", "");
                                            msgbody = msgbody.Replace("#nom#", "");
                                            msgbody = msgbody.Replace("#email#", "");
                                       
                                    }


                                    MailMessage message = new MailMessage(new MailAddress(ps.Email, ps.PortalName), new MailAddress(n_o.email, ""));
                                    //message.ReplyTo = new MailAddress(newsletter.replyemail, newsletter.fromname);
                                    message.ReplyToList.Add(new MailAddress(n.sender_email,n.sender_name));
                                    message.Subject = n.title;
                                    message.IsBodyHtml = true;

                                    message.Body = ReplaceUrls(msgbody, n_o.id);
                                    message.BodyEncoding = Encoding.UTF8;
                                    message.Headers.Add("X-AIS-Ref", n.id);
                                    if(NConfig.deliverynotification)
                                    { 
                                        message.DeliveryNotificationOptions =
                                          DeliveryNotificationOptions.OnFailure |
                                          DeliveryNotificationOptions.OnSuccess |
                                          DeliveryNotificationOptions.Delay;
                                        message.Headers.Add("Disposition-Notification-To", ps.Email);
                                    }

                                    string SMTPServer = "" + NConfig.smtphost;
                                    int portPos = SMTPServer.IndexOf(":");
                                    int SMTPPort = 25;
                                    if (portPos > -1)
                                    {
                                        SMTPPort = int.Parse(SMTPServer.Substring(portPos + 1, SMTPServer.Length - portPos - 1));
                                        SMTPServer = SMTPServer.Substring(0, portPos);
                                    }

                                    SmtpClient client = new SmtpClient(SMTPServer, SMTPPort);
                                    client.UseDefaultCredentials = false;
                                    //client.Credentials = new NetworkCredential("" + ps.HostSettings["SMTPUsername"], "" + ps.HostSettings["SMTPPassword"]);
                                    client.Credentials = new NetworkCredential(GetSMTPEmail(), GetSMTPPassword());
                                    client.Send(message);
                                    message.Dispose();

                                    sb.AppendLine("Succes de l'envoie du mail : " + n_o.email + ", newsletter : "+n.title);
                                    n_o.status = "T";
                                    n_o.error = "";
                                    resultat_MAJ = DataMapping.Update_Newsletter_Out(n_o);

                                }
                                catch (Exception ee)
                                {
                                    Functions.Error(ee);
                                    sb.AppendLine("Erreur lors de l'envoie du mail : " + n_o.email + ", newsletter : " + n.title);
                                    n_o.status = "E";
                                    n_o.error = ee.Message;
                                    resultat_MAJ = DataMapping.Update_Newsletter_Out(n_o);
                                }


                                if (resultat_MAJ == false)
                                {
                                    sb.AppendLine("Erreur lors de la MAJ du mail : " + n_o.email + ", newsletter : " + n.title);
                                }

                           
                        }
                        else
                        {
                            
                            n.status = "T";

                            bool retour = DataMapping.UpdateNewsletter(n);

                            if (retour == true)
                            {
                                sb.AppendLine("");
                            }
                            else
                            {
                                sb.AppendLine("Problème lors de la mise à jour de la newsletter " + n.title);
                            }

                            return "Pas de mails à envoyer";
                            
                        }
                    }
                    else
                    {
                        return "Problème lors de la récupération des mails";
                    }
                }
                else
                {
                    sb.AppendLine("Pas de newsletter en attente.");
                }


                return sb.ToString();
            }
            catch (Exception ee)
            {
                Functions.Error(ee);
                return ee.Message;
            }
        }
    }

    protected List<Member> Recherche_District()
    {       
        List<Member> la_Liste = new List<Member>();
        List<Member> la_Liste_Members_Fonction = new List<Member>();
        List<Member> La_Liste_Members_Role = new List<Member>();

        #region Recherche par functions
        string requete = " SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE ";
        if (la_Liste_Fonction != null)
        {
            if (la_Liste_Fonction.Count > 0)
            {
                string requete_AR = "";
                string requete_FCT = "";

                #region AR
                if (La_Liste_AR != null)
                {
                    if (La_Liste_AR.Count > 0)
                    {
                        if (La_Liste_AR.Count == 1)
                        {
                            requete_AR = requete_AR + " rotary_year = '" + La_Liste_AR[0] + "' ";
                        }
                        else
                        {
                            for (int i = 0; i < La_Liste_AR.Count; i++)
                            {
                                if (i == 0)
                                {
                                    requete_AR = requete_AR + " (rotary_year = '" + La_Liste_AR[i] + "' ";
                                }
                                else
                                {
                                    requete_AR = requete_AR + " OR rotary_year = '" + La_Liste_AR[i] + "' ";
                                }
                            }
                            requete_AR = requete_AR + ")";
                        }
                    }
                    else //Si pas AR selectionné => année en cours sélectionné
                    {
                        int annee_0 = Functions.GetRotaryYear();
                        requete_AR = requete_AR + " rotary_year = '" + annee_0.ToString() + "'";
                    }
                }
                else
                {
                    int annee_0 = Functions.GetRotaryYear();
                    requete_AR = requete_AR + " rotary_year = '" + annee_0.ToString() + "'";
                }
                #endregion AR

                #region Fonction
                if (la_Liste_Fonction.Count == 1)
                {
                    requete_FCT = requete_FCT + " AND [function] = '" + la_Liste_Fonction[0] + "' ";
                }
                else
                {
                    for (int i = 0; i < la_Liste_Fonction.Count; i++)
                    {
                        if (i == 0)
                        {
                            requete_FCT = requete_FCT + " AND ([function] = '" + la_Liste_Fonction[i] + "' ";
                        }
                        else
                        {
                            requete_FCT = requete_FCT + " OR [function] = '" + la_Liste_Fonction[i] + "' ";
                        }
                    }
                    requete_FCT = requete_FCT + ")";
                }
                #endregion Fonction

                requete = requete + requete_AR + requete_FCT + ") ";

                if (!string.IsNullOrEmpty(Departement))
                {
                    requete = requete + " AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(zip, 1, 2) IN (" + Departement + "))";
                }

                la_Liste_Members_Fonction = DataMapping.GetListMembers_Mailling(requete);
            }
        }
        #endregion Recherche par functions

        #region Recherche par role
        if (La_Liste_Role != null)
        {
            List<string> Liste_Email = new List<string>();
            RoleController ObjRoleController = new RoleController();
            foreach (string s in La_Liste_Role)
            {
                var arrUsers = ObjRoleController.GetUsersByRoleName(0, s);
                foreach (UserInfo u in arrUsers)
                {
                    if (!string.IsNullOrEmpty(u.Email))
                    {
                        //Liste_Email.Add("'" + u.Email + "'");
                        if (!la_Liste.Exists(m => m.email == u.Email))
                        {
                            la_Liste.Add(new Member
                            {
                                email = u.Email,
                                name = u.FirstName,
                                surname = u.LastName,
                                district_id = Const.DISTRICT_ID,
                                userid = u.UserID
                            });
                        }
                    }
                }
            }

            //string ListeEmail = string.Join(",", Liste_Email);
            //La_Liste_Members_Role = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE email IN (" + ListeEmail + ") ");
        }
        #endregion Recherche par role

        #region Trie entre les listes
        if (la_Liste_Members_Fonction != null)
        {
            foreach (Member m in la_Liste_Members_Fonction)
            {
                la_Liste.Add(m);
            }
        }

        //if (La_Liste_Members_Role != null)
        //{
        //    foreach (Member mp in La_Liste_Members_Role)
        //    {
        //        if (!la_Liste.Exists(mem => mem.nim == mp.nim))
        //        {
        //            la_Liste.Add(mp);
        //        }
        //    }
        //}
        #endregion Trie entre les listes

        return la_Liste;
    }

    protected List<Member> Recherche_Club()
    {
        List<Member> La_Liste = new List<Member>();
        List<Member> Liste_Members = new List<Member>();
        List<Member> Liste_President = new List<Member>();
        List<Member> Liste_Secretaire = new List<Member>();       

        int annee_0 = Functions.GetRotaryYear();

        #region Secrétaire
        if (!string.IsNullOrEmpty(Secretaire))
        {
            if (string.IsNullOrEmpty(Departement))
            {
                Liste_Secretaire = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function] = 'Secrétaire' AND rotary_year = '" + annee_0.ToString() + "')");
            }
            else
            {
                Liste_Secretaire = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function] = 'Secrétaire' AND rotary_year = '" + annee_0.ToString() + "'  AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(zip, 1, 2) IN (" + Departement + ")))");
            }
        }
        #endregion Secrétaire

        #region Président
        if (!string.IsNullOrEmpty(President))
        {
            if (string.IsNullOrEmpty(Departement))
            {
                Liste_President = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function] = 'Président' AND rotary_year = '" + annee_0.ToString() + "')");
            }
            else
            {
                Liste_President = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE nim IN (SELECT DISTINCT nim FROM " + Const.TABLE_PREFIX + "rya WHERE [function] = 'Président' AND rotary_year = '" + annee_0.ToString() + "' AND cric in (SELECT cric FROM " + Const.TABLE_PREFIX + "clubs WHERE SUBSTRING(zip, 1, 2) IN (" + Departement + ")))");
            }
        }
        #endregion Président

        #region Tous les membres du club
        if (!string.IsNullOrEmpty(Cric_Members))
        {
            Liste_Members = DataMapping.GetListMembers_Mailling("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE cric='" + Cric_Members + "'");
        }
        #endregion Tous les membres du club

        #region Trie entre les listes
        if (Liste_Members != null)
        {
            foreach (Member m in Liste_Members)
            {
                La_Liste.Add(m);
            }
        }

        if (Liste_President != null)
        {
            foreach (Member mp in Liste_President)
            {
                if (!La_Liste.Exists(mem => mem.nim == mp.nim))
                {
                    La_Liste.Add(mp);
                }
            }
        }

        if (Liste_Secretaire != null)
        {
            foreach (Member ms in Liste_Secretaire)
            {
                if (!La_Liste.Exists(mem => mem.nim == ms.nim))
                {
                    La_Liste.Add(ms);
                }
            }
        }
        #endregion Trie entre les listes

        return La_Liste;
    }

    public bool CheckToken(string token)
    {
        string guidmd5 = CalculateMD5Hash(StringToBytes(""+DotNetNuke.Entities.Portals.PortalSettings.Current.GUID));
        return guidmd5 == token;
    }
    public string CalculateMD5Hash(byte[] inputBytes)
    {
        // step 1, calculate MD5 hash from input
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
    public byte[] StringToBytes(string chaine)
    {
        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        return encoding.GetBytes(chaine);
    }

         
}
