using AIS;
using Aspose.Cells;
using DotNetNuke.Services.Scheduling;
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

public partial class MeetingBase
{
    public int id { get; set; }
    public int cric { get; set; }
    public string name { get; set; }
    public Guid guid { get; set; }

    public string visible { get; set; }     // N : non visible (uniquement admin club)
                                            // O : public
                                            // M : membres du club
                                            // D : tous les membres de tous les clubs
    public string active { get; set; }      // O : inscriptions actives
                                            // N : inscriptions fermées (auto N quand date est dépassée)

    public string type { get; set; }        // unitary / periodic
    public string statutory { get; set; }   // O / N
    public DateTime dtstart { get; set; }
    public DateTime dtend { get; set; }

    public string link { get; set; }

    public DateTime dtlastupdate { get; set; }  // derniere modif de la réunion

    public int portalid { get; set; }

    public int nbusers { get; set; }
}