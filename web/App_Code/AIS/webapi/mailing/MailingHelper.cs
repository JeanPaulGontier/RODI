using Aspose.Pdf.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIS;
using Stripe;
using System.Data.SqlClient;
using DotNetNuke.Entities.Users;
using System.Data;
using DotNetNuke.Security.Roles;

/// <summary>
/// Description résumée de MailingHelper
/// </summary>
public class MailingHelper
{

    public const string CLUB_MEMBERS        = "FA65C8DD-1942-4608-ABF8-711137B93B40";
    public const string CLUB_ADG            = "244D2B42-5BD1-47CC-8D02-1A7C0668D885";
    public const string CLUBS_PRESIDENTS    = "64294D98-7172-4DD4-9DB0-B9D779AF7C5F";
    public const string CLUBS_SECRETARIES   = "E16DBBAC-C3FD-42FF-89EE-F6E0D93256C4";
    public const string CLUB_SUBSCRIBERS    = "63BEC467-110B-451F-B18C-20FD6B367FA4";


    public MailingHelper()
    {
    }

    public static List<Mailing.Contact> GetContactsFromRecipients(int cric, List<string> recipients)
    {
        List<Mailing.Contact> contacts = new List<Mailing.Contact>();
        if(cric>0)
        {
            Club club = DataMapping.GetClub(cric);
            RoleController roleController = new RoleController();
            foreach (var recipient in recipients)
            {
                switch (recipient.ToUpper())
                {
                    case CLUB_MEMBERS:
                        string sqlcm = "SELECT name++' '++surname as name,email,nim FROM " + Const.TABLE_PREFIX + "members WHERE district_id=" + Const.DISTRICT_ID + " AND cric=" + cric + " AND email!=''";
                        List<Mailing.Contact> cm = Yemon.dnn.DataMapping.ExecSql<Mailing.Contact>(new SqlCommand(sqlcm));
                        if(cm!=null)
                        {
                            AddContactsOnlyOnce(contacts, cm);
                        }
                        break;
                    case CLUB_ADG:
                        if (club.roles != "")
                        {
                            string nims = "";
                            int roleid = 0;
                            int.TryParse(club.roles, out roleid);
                            RoleInfo role = roleController.GetRoleById(0, roleid);
                            if(role!=null)
                            {
                                List<UserInfo> users = roleController.GetUsersByRole(0, role.RoleName).ToList<UserInfo>();
                                if (users.Count > 0)
                                {
                                    foreach (UserInfo user in users)
                                    {
                                        Member member = DataMapping.GetMemberByUserID(user.UserID);
                                        if (member != null)
                                        {
                                            nims += "" + member.nim + ",";
                                        }
                                    }
                                    if (nims != "")
                                    {
                                        nims = nims.Substring(0, nims.Length - 1);
                                        string sqlca = "SELECT name++' '++surname as name,email,nim FROM " + Const.TABLE_PREFIX + "members WHERE district_id=" + Const.DISTRICT_ID + " AND email!='' AND nim IN (" + nims + ")";
                                        List<Mailing.Contact> ca = Yemon.dnn.DataMapping.ExecSql<Mailing.Contact>(new SqlCommand(sqlca));
                                        if (ca != null)
                                        {
                                            AddContactsOnlyOnce(contacts, ca);
                                        }
                                    }
                                }
                            }
                            
                        }
                        
                        break;
                    case CLUBS_PRESIDENTS:
                        string sqlcp = "SELECT name++' '++surname as name,email,nim FROM " + Const.TABLE_PREFIX + "members WHERE district_id=" + Const.DISTRICT_ID + " AND email!='' AND nim IN (SELECT nim FROM " + Const.TABLE_PREFIX + "rya WHERE cric!='" + cric + "' AND [function]='Président' AND rotary_year='" + Functions.GetRotaryYear() + "')";
                        List<Mailing.Contact> cp = Yemon.dnn.DataMapping.ExecSql<Mailing.Contact>(new SqlCommand(sqlcp));
                        if (cp != null)
                        {
                            AddContactsOnlyOnce(contacts, cp);
                        }
                        break;
                    case CLUBS_SECRETARIES:
                        string sqlce = "SELECT name++' '++surname as name,email,nim FROM " + Const.TABLE_PREFIX + "members WHERE district_id=" + Const.DISTRICT_ID + " AND email!='' AND nim IN (SELECT nim FROM " + Const.TABLE_PREFIX + "rya WHERE cric!='" + cric + "' AND [function]='Secrétaire' AND rotary_year='" + Functions.GetRotaryYear() + "')";
                        List<Mailing.Contact> ce = Yemon.dnn.DataMapping.ExecSql<Mailing.Contact>(new SqlCommand(sqlce));
                        if (ce != null)
                        {
                            AddContactsOnlyOnce(contacts, ce);
                        }
                        break;
                    case CLUB_SUBSCRIBERS:
                        string sqlcs = "SELECT name++' '++surname as name,email,nim FROM " + Const.TABLE_PREFIX + "members WHERE district_id=" + Const.DISTRICT_ID + " AND email!='' AND nim IN (SELECT nim FROM " + Const.TABLE_PREFIX + "subs WHERE cric='" + cric + "')";
                        List<Mailing.Contact> cs = Yemon.dnn.DataMapping.ExecSql<Mailing.Contact>(new SqlCommand(sqlcs));
                        if (cs != null)
                        {
                            AddContactsOnlyOnce(contacts, cs);
                        }
                        break;
                }
            }
        }
        
        return contacts;
    }

    public static void AddContactsOnlyOnce(List<Mailing.Contact> contacts, List<Mailing.Contact> contactstoadd) 
    { 
        foreach(var contact in contactstoadd)
        {
            bool exist=false;
            foreach(var c in contacts)
            {
                if(c.email == contact.email)
                {
                    exist=true;
                    break;
                }
            }
            if(!exist)
                contacts.Add(contact);
        }
    }

    public static List<Mailing.Recipient> GetRecipients(int cric)
    {
        List<Mailing.Recipient> recipients = new List<Mailing.Recipient>();
        if(cric > 0 )
        {
            recipients.Add(new Mailing.Recipient()
            {
                guid = new Guid(CLUB_MEMBERS),
                name = "Membres du club"
            });
            recipients.Add(new Mailing.Recipient()
            {
                guid = new Guid(CLUB_SUBSCRIBERS),
                name = "Abonnés autres clubs "
            });
            recipients.Add(new Mailing.Recipient()
            {
                guid = new Guid(CLUB_ADG),
                name = "ADG " + Functions.GetRotaryYear() + "-" + (Functions.GetRotaryYear() + 1)
            });
            recipients.Add(new Mailing.Recipient()
            {
                guid = new Guid(CLUBS_PRESIDENTS),
                name = "Présidents autres clubs " + Functions.GetRotaryYear() + "-" + (Functions.GetRotaryYear() + 1)
            });
            recipients.Add(new Mailing.Recipient()
            {
                guid = new Guid(CLUBS_SECRETARIES),
                name = "Secrétaires autres clubs " + Functions.GetRotaryYear() + "-" + (Functions.GetRotaryYear() + 1)
            });
           
        }
        return recipients;
    }

    public static int[] GetSubs(int userid)
    {
        Member member = DataMapping.GetMemberByUserID(userid);

        SqlCommand sql = new SqlCommand("select distinct cric from " + Const.TABLE_PREFIX + "subs where nim=@nim");
        sql.Parameters.AddWithValue("nim", member.nim);

        DataTable table = Yemon.dnn.DataMapping.ExecSql(sql);
        if(table == null)
            return new int[0];
        int[] subs = new int[table.Rows.Count];
        int i = 0;
        foreach(DataRow row in table.Rows)
        {
            subs[i] = (int)row[0];
            i++;
        }

        return subs;
    }

    public static bool SetSubs(int[] subs, int userid)
    {
        Member member = DataMapping.GetMemberByUserID(userid);

        SqlConnection conn = Yemon.dnn.DataMapping.GetOpenedConn();
        SqlTransaction trans = null;
        try { 
            trans = conn.BeginTransaction();

            SqlCommand sql = new SqlCommand("delete from " + Const.TABLE_PREFIX + "subs where nim=@nim");
            sql.Parameters.AddWithValue("nim", member.nim);

            Yemon.dnn.DataMapping.ExecSqlNonQuery(sql,conn,trans);

            foreach(int cric in subs)
            {
                sql = new SqlCommand("insert into " + Const.TABLE_PREFIX + "subs (cric,nim) VALUES (@cric,@nim)");
                sql.Parameters.AddWithValue("cric", cric);
                sql.Parameters.AddWithValue("nim", member.nim);
                if (Yemon.dnn.DataMapping.ExecSqlNonQuery(sql, conn, trans) < 1)
                    throw Yemon.dnn.DataMapping.lastException;
            }
            trans.Commit();

            return true;
        }catch(Exception ex)
        {
            Functions.Error(ex);
            return false;
        }
    }
}