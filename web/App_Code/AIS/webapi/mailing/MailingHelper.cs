using Aspose.Pdf.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIS;
using Stripe;
using System.Data.SqlClient;

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
            foreach (var recipient in recipients)
            {
                switch (recipient.ToUpper())
                {
                    case CLUB_MEMBERS:
                        List<Mailing.Contact> cm = Yemon.dnn.DataMapping.ExecSql<Mailing.Contact>(new SqlCommand("SELECT name++' '++surname as name,email,nim FROM " + Const.TABLE_PREFIX + "members WHERE district_id=" + Const.DISTRICT_ID + " AND cric=" + cric +" AND email!=''"));
                        if(cm!=null)
                        {
                            AddContactsOnlyOnce(contacts, cm);
                        }
                        break;
                    case CLUB_ADG:
                        break;
                    case CLUBS_PRESIDENTS:
                        break;
                    case CLUBS_SECRETARIES:
                        break;
                    case CLUB_SUBSCRIBERS:
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
            recipients.Add(new Mailing.Recipient()
            {
                guid = new Guid(CLUB_SUBSCRIBERS),
                name = "Abonnés autres clubs "
            });
        }
        return recipients;
    }
}