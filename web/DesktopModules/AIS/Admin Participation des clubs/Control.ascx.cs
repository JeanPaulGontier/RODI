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

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);


        filename=Server.MapPath(PortalSettings.HomeDirectory + "ParticipationDesClubs.xlsx.resources");
        tablename = Const.TABLE_PREFIX+"clubs_participation";


        InitAnnee();


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //panel.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);

        RefreshListe();
        
    }

    void RefreshListe()
    {
        var liste = Yemon.dnn.DataMapping.ExecSql("Select c.cric,c.name,p.afd,p.sfpe,p.conference from "+tablename+" p,"+Const.TABLE_PREFIX+"clubs c  where c.cric=p.cric and p.annee='"+annee.SelectedValue+"' and p.districtid="+Const.DISTRICT_ID+" order by c.name");
        members.DataSource=liste;
        members.DataBind();

    }
    void InitAnnee()
    {
        int currentyear = Functions.GetRotaryYear();
        var annees = Yemon.dnn.DataMapping.ExecSql("Select distinct annee from "+tablename+" where annee<"+currentyear+" order by annee desc");
        annee.Items.Clear();
        annee.Items.Add(new ListItem(currentyear+" - "+(currentyear+1), ""+currentyear));
        if (annees!=null)
            foreach (DataRow row in annees.Rows)
                annee.Items.Add(new ListItem(row["annee"]+ " - "+((int)row["annee"]+1), ""+row["annee"]));
    }
    protected void BT_Upload_Click(object sender, EventArgs e)
    {
        panel_result.Visible=false;
        error.Visible = false;

        if (FU_RI.HasFile)
        {
            if(FU_RI.FileName.ToLower().StartsWith("participationdesclubs"))
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
            int row = 1;
            int a = 0;
            int.TryParse(""+annee.SelectedValue, out a);

            List<ClubPartitipation> liste = new List<ClubPartitipation>();
            ClubPartitipation c = null;
            while (row < 65535)
            {
                Cell cell = sheet.Cells[row, col];
                if ((""+cell.Value)=="")
                    break;
               
                c = new ClubPartitipation();
                c.districtid= (int)(double)sheet.Cells[row, col].Value;
                c.annee= (int)(double)sheet.Cells[row, col+1].Value;
                //if (a!=c.annee)
                //    throw new Exception("L'année trouvée dans le fichier ne correspond pas à l'année sélectionnée");
                if (Const.DISTRICT_ID!= c.districtid)
                    throw new Exception("Le district trouvé dans le fichier ne correspond pas au district attendu");

                c.cric= (int)(double)sheet.Cells[row, col+2].Value;
                c.afd= (int)(double)sheet.Cells[row, col+3].Value;
                c.sfpe= (int)(double)sheet.Cells[row, col+4].Value;
                c.conference= (int)(double)sheet.Cells[row, col+5].Value;
                liste.Add(c);
                row++;
            }

            foreach(var cr in liste)
            {
                if(clubs.Find(club => club.cric== cr.cric)!=null)
                {
                    Yemon.dnn.DataMapping.ExecSqlNonQuery(new SqlCommand("DELETE FROM ["+tablename+"] WHERE districtid="+cr.districtid+" AND cric="+cr.cric+" AND annee="+cr.annee),conn,trans);
                    var r = new Dictionary<string, object>();

                    r["districtid"]=cr.districtid;
                    r["cric"]=cr.cric;
                    r["annee"]=cr.annee;
                    r["afd"]=cr.afd;
                    r["sfpe"]=cr.sfpe;
                    r["conference"]=cr.conference;
                    Yemon.dnn.DataMapping.UpdateOrInsertRecord(tablename, "id", r, conn, trans);

                }
            }
            trans.Commit();

            RefreshListe();
            InitAnnee();
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


    protected void BT_Export_Click(object sender, EventArgs e)
    {
        int a = 0;
        int.TryParse(annee.SelectedValue, out a);
        Media media = DataMapping.ExportParticipationDesClubs("ParticipationDesClubs "+a+"-"+(a+1)+".xlsx",a);
        
        string guidexport = Guid.NewGuid().ToString();
        Session[guidexport] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guidexport);
        return;
    }
}