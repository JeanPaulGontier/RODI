using AIS;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Cells;
using Aspose;

using System.IO;
using System.Globalization;
using Microsoft.VisualBasic.Activities;

public partial class DesktopModules_AIS_Admin_Import_RI : PortalModuleBase
{
    public string filename;
    public string tablename;
    protected void Page_Load(object sender, EventArgs e)
    {
        //panel.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);

        filename = Server.MapPath(PortalSettings.HomeDirectory + "MonthlyContributionReportCurrent.xlsx.resources");
        tablename = Const.TABLE_PREFIX+"ri_monthlycontributionreportcurrent";
    }

    protected void BT_Upload_Click(object sender, EventArgs e)
    {
        panel_result.Visible=false;
        error.Visible = false;

        if (FU_RI.HasFile)
        {
            if(FU_RI.FileName.ToLower().StartsWith("monthlycontributionreportcurrent"))
            {
                File.WriteAllBytes(filename, FU_RI.FileBytes);

                Import_Fichier();

            }
            else
            {
                error.Visible = true;
                errorlabel.Text ="Le fichier n'est pas celui attendu, l'import n'est pas possible...";
            }
        }
   
    }

  
    void Import_Fichier()
    {

        var clubs = DataMapping.ListClubs();


        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlTransaction trans = null;
        SqlCommand sql = null;
        lbl_result.Text="";
        try
        {

            Workbook xls = new Workbook(filename);

            conn.Open();
            trans = conn.BeginTransaction();


            Worksheet sheet = xls.Worksheets[0];
            int col = 0;
            int row = 3;
            int annee = 0;
            List<MonthlyContributionReportCurrent> liste = new List<MonthlyContributionReportCurrent>();
            MonthlyContributionReportCurrent c = null;
            while (row < 65535)
            {
                Cell cell = sheet.Cells[row, col];
                if((""+cell.Value)=="Récapitulatif du district" || (""+cell.Value)=="District Summary")
                {
                    annee=int.Parse((""+sheet.Cells[row+1, col+1].Value).Substring(0, 4));
                   
                }
                
                row++;
            }
            if (annee==0)
                throw new Exception("Année indéfinie");
            int districtid = (int)(double)sheet.Cells[2, 0].Value;
            if (districtid!=Const.DISTRICT_ID)
                throw new Exception("Le fichier ne correspond pas au district");
            row = 3;
            while (row < 65535)
            {
                Cell cell = sheet.Cells[row, col];
                if ((""+cell.Value)=="")
                    break;
                c = new MonthlyContributionReportCurrent();
                c.districtid=districtid;
                c.annee= annee;
                c.cric = (int)(double)sheet.Cells[row, col].Value;
                int rotariens = 0;
                int.TryParse((""+sheet.Cells[row, col+2].Value),out rotariens);
                c.rotariens= rotariens;
                c.objectif_fonds_annuel = (decimal)(double)sheet.Cells[row, col+3].Value;
                c.pct_atteint = (decimal)(double)sheet.Cells[row, col+4].Value;
                c.moyenne_par_donateur = (decimal)(double)sheet.Cells[row, col+5].Value;
                c.fonds_annuel_cumul_annuel = (decimal)(double)sheet.Cells[row, col+6].Value;
                c.fonds_polioplus_cumul_annuel = (decimal)(double)sheet.Cells[row, col+7].Value;
                c.autres_fonds_cumul_annuel = (decimal)(double)sheet.Cells[row, col+8].Value;
                c.fonds_de_dotation_cumul_annuel = (decimal)(double)sheet.Cells[row, col+9].Value;
                c.total = (decimal)(double)sheet.Cells[row, col+10].Value;

                liste.Add(c);
                row++;
            }


                foreach (var cr in liste)
            {
                if(clubs.Find(club => club.cric== cr.cric)!=null)
                {
                    Yemon.dnn.DataMapping.ExecSqlNonQuery(new SqlCommand("DELETE FROM ["+tablename+"] WHERE districtid="+cr.districtid+" AND cric="+cr.cric+" AND annee="+cr.annee),conn,trans);
                    var r = new Dictionary<string, object>();

                    r["districtid"]=cr.districtid;
                    r["cric"]=cr.cric;
                    r["annee"]=cr.annee;
                    r["rotariens"]=cr.rotariens;
                    r["objectif_fonds_annuel"]=cr.objectif_fonds_annuel;
                    r["pct_atteint"]=cr.pct_atteint;
                    r["moyenne_par_donateur"]=cr.moyenne_par_donateur;
                    r["fonds_annuel_cumul_annuel"]=cr.fonds_annuel_cumul_annuel;
                    r["fonds_polioplus_cumul_annuel"]=cr.fonds_polioplus_cumul_annuel;
                    r["autres_fonds_cumul_annuel"]=cr.autres_fonds_cumul_annuel;
                    r["fonds_de_dotation_cumul_annuel"]=cr.fonds_de_dotation_cumul_annuel;
                    r["total"]=cr.total;
                   
                    Yemon.dnn.DataMapping.UpdateOrInsertRecord(tablename, "id", r, conn, trans);

                }
            }
            trans.Commit();

            members.DataSource=liste;
            members.DataBind();

            panel_result.Visible=true;
            
            lbl_result.Text="Import terminé...";
        }
        catch (Exception ee)
        {
            
            error.Visible = true;
            errorlabel.Text = ee.Message;
            if (trans != null)
                trans.Rollback();

            Functions.Error(ee);
        }
        finally
        {
             conn.Close();
        }

    }

 

    protected string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }

}