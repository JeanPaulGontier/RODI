using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de MonthlyContributionReportCurrent
/// </summary>
public class MonthlyContributionReportCurrent
{
    public int districtid {  get; set; }
    public int cric {  get; set; }
    public int annee {  get; set; }

    public int rotariens { get; set; }
    public decimal objectif_fonds_annuel { get; set; }
    public decimal pct_atteint { get; set; }
    public decimal moyenne_par_donateur { get; set; }
    public decimal fonds_annuel_cumul_annuel { get; set; }
    public decimal fonds_polioplus_cumul_annuel { get; set; }
    public decimal autres_fonds_cumul_annuel { get; set; }
    public decimal fonds_de_dotation_cumul_annuel { get; set; }
    public decimal total {  get; set; }


}