using AIS;
using Aspose.Cells;
using DotNetNuke.Services.Scheduling;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;


/// <summary>
/// Description résumée de Meeting
/// </summary>

public class Meeting
{
    public int id { get; set; }
    public int cric { get; set; }
    public string name { get; set; }
    public Guid guid { get; set; }
    public string active { get; set; }      // O : inscriptions actives
                                            // N : inscriptions fermées (auto N quand date est dépassée)
    public string doperiodics { get; set; } // O / N active ou pas la programmation automatique des réunions périodiques
    public string type { get; set; }        // unitary / periodic
    public string statutory { get; set; }   // O / N
    public DateTime dtstart { get; set; }
    public DateTime dtend { get; set; }
    public Guid templateguid { get; set; }  // permet de lier le meeting unitaire avec le meeting periodique qui a servi a le créer
    public Guid periodguid { get; set; }    // permet de lier la periode unitaire avec la periode periodique correspondante afin de ne pas recreer une période si on change après coup l'heure de la période


    public DateTime dtrevision { get; set; } // date après laquelle une notificatione est envoyée (auto ou manuelle)
    public string mustnotify { get; set; }   // O : oui 
                                             // N : non
    public string notificationtype { get; set; } // A : all members
                                                 // M : only members
                                                 // C : commity
                                                 // S : only satellite members
                                                 // L : selection list

    public string notificationlist { get; set; } // recipient list in case of notificationtype = L, sérialisé JSON
    public DateTime dtnotif1 { get; set; }   // contient la date et heure de la dernière notif
    public DateTime dtnotif2 { get; set; }   // non utilisé pour l'instant
    public string notif1done { get; set; }   // O / N
    public string notif2done { get; set; }   // non utilisé pour l'instant

    public DateTime dtlastupdate { get; set; }  // derniere modif de la réunion
    public int portalid { get; set; }
    public int nbusers { get; set; }
    
    public string link { get; set; }        // code réduit pour l'accès à la réunion 

    public string periods { get; set; }     // périodes de programmation sérialisé JSON


    public class Period
    {
        public Guid guid { get; set; }
        public int num { get; set; }
        public string day { get; set; }
        public string start { get; set; }
        public string end { get; set; }

    }

    public class User
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string comment { get; set; }
        public Guid guid { get; set; }
        public Guid meetingguid { get; set; }
        public string useridguid { get; set; }
        public string presence { get; set; }
        public DateTime dtlastupdate { get; set; }
    }

    public class Recipient
    {
        public int nim { get; set; }
        public string email { get; set; }   // vide quand nim renseigné, utile pour mail externe
    }



    


}