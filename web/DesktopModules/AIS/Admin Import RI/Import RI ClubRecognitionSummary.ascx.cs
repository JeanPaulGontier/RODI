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

public partial class DesktopModules_AIS_Admin_Import_RI : PortalModuleBase
{
    public string filename;
    public string tablename;
    protected void Page_Load(object sender, EventArgs e)
    {
        //panel.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);

        filename=Server.MapPath(PortalSettings.HomeDirectory + "ClubRecognitionSummary.xlsx.resources");
        tablename =Const.TABLE_PREFIX+"ri_clubrecognitionsummary";
    }

    protected void BT_Upload_Click(object sender, EventArgs e)
    {
        panel_result.Visible=false;
        error.Visible = false;

        if (FU_RI.HasFile)
        {
            if(FU_RI.FileName.ToLower().StartsWith("clubrecognitionsummary"))
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
            int row = 0;

            List<ClubRecognitionSummary> crs = new List<ClubRecognitionSummary>();
            ClubRecognitionSummary c = null;
            while (row < 65535)
            {
                Cell cell = sheet.Cells[row, col];
                if((""+cell.Value)=="District :")
                {
                  

                    c = new ClubRecognitionSummary();
                    c.districtid= (int)(double)sheet.Cells[row, col+1].Value;
                    c.phf = (int)(double)sheet.Cells[row, col+5].Value;
                    c.rotariens_donateurs = (int)(double)sheet.Cells[row, col+15].Value;
                    c.total_des_dons = (int)Math.Round((double)sheet.Cells[row, col+25].Value);

                    if(sheet.Cells[row+1, col+1].Value!=null)
                        c.cric= (int)(double)sheet.Cells[row+1, col+1].Value;
                    if(sheet.Cells[row+1, col+5].Value!=null)
                        c.bienfaiteurs = (int)(double)sheet.Cells[row+1, col+5].Value;
                    if(sheet.Cells[row+1, col+15].Value!=null)
                        c.rotariens_non_donateurs = (int)(double)sheet.Cells[row+1, col+15].Value;
                    if(sheet.Cells[row+7, col+17].Value!=null)
                        c.points_fondations_disponibles = (int)Math.Round((double)sheet.Cells[row+7, col+17].Value);

                    try
                    {
                        var a = DateTime.Parse(""+sheet.Cells[row+7, col+20].Value);
                        if (a.Month<7)
                            c.annee=a.Year-1;
                        else
                            c.annee=a.Year;

                        if (c!=null)
                            crs.Add(c);

                    }
                    catch(Exception e)
                    {

                    }
                }
                
                row++;
            }

            foreach(var cr in crs)
            {
                if(clubs.Find(club => club.cric== cr.cric)!=null)
                {
                    Yemon.dnn.DataMapping.ExecSqlNonQuery(new SqlCommand("DELETE FROM ["+tablename+"] WHERE districtid="+cr.districtid+" AND cric="+cr.cric+" AND annee="+cr.annee),conn,trans);
                    var r = new Dictionary<string, object>();

                    r["districtid"]=cr.districtid;
                    r["cric"]=cr.cric;
                    r["annee"]=cr.annee;
                    r["phf"]=cr.phf;
                    r["rotariens_donateurs"]=cr.rotariens_donateurs;
                    r["total_des_dons"]=cr.total_des_dons;
                    r["bienfaiteurs"]=cr.bienfaiteurs;
                    r["rotariens_non_donateurs"]=cr.rotariens_non_donateurs;
                    r["points_fondations_disponibles"]=cr.points_fondations_disponibles;

                    Yemon.dnn.DataMapping.UpdateOrInsertRecord(tablename, "id", r, conn, trans);

                }
            }
            trans.Commit();

            members.DataSource=crs;
            members.DataBind();

            panel_result.Visible=true;
            
            lbl_result.Text="Import terminé...";
        }
        catch (Exception ee)
        {
            
            error.Visible = true;
            errorlabel.Text = ee.Message ;
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