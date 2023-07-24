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

public partial class DesktopModules_AIS_Admin_Exports_Exports : PortalModuleBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        panel.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT ) || UserInfo.IsAdmin;
    }

    protected void btn_exportPresActuel_Click(object sender, EventArgs e)
    {
        ExportPresident(Functions.GetRotaryYear());
    }

    protected void btn_exportBureauActuel_Click(object sender, EventArgs e)
    {
        ExportBureau(Functions.GetRotaryYear());
    }

    protected void btn_exportPres_Click(object sender, EventArgs e)
    {
       ExportPresident(Functions.GetRotaryYear()+1);
    }

    protected void btn_exportBureau_Click(object sender, EventArgs e)
    {
        ExportBureau(Functions.GetRotaryYear()+1);
    }

    protected void btn_exportBureauComplet_Click(object sender, EventArgs e)
    {
        ExportBureauComplet(Functions.GetRotaryYear()+1);
    }
    protected void btn_exportClubsSansBureau_Click(object sender, EventArgs e)
    {
        ExportClubsSansBureau(Functions.GetRotaryYear()+1); 
    }

    protected void btn_exportBureauActuelComplet_Click(object sender, EventArgs e)
    {
        ExportBureauComplet(Functions.GetRotaryYear());
    }

    protected void btn_exportClubsSansBureauActuel_Click(object sender, EventArgs e)
    {
        ExportClubsSansBureau(Functions.GetRotaryYear());
    }

    public void ExportBureau(int annee)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        conn.Open();

        SqlCommand sql = new SqlCommand("SELECT c.name as 'Club', a.name as 'Membre', a.[function] as 'Fonction',(select top 1 email from ais_members where nim = a.nim) as email,(select top 1 [gsm] from ais_members where nim = a.nim) as gsm from ais_clubs c,ais_rya a WHERE c.cric = a.cric AND a.rotary_year = @rotary_year ORDER BY c.name", conn);
        sql.Parameters.AddWithValue("@rotary_year", annee);
        SqlDataAdapter da = new SqlDataAdapter(sql);
        DataSet ds = new DataSet();
        da.Fill(ds);
        List<DataTable> tables = new List<DataTable>();
        foreach (DataTable table in ds.Tables)
        {
            tables.Add(table);
        }


        Media media = DataMapping.ExportDataTablesToXLS(tables, "Bureau année " + (annee) + "-" + (annee + 1) + ".xlsx", Aspose.Cells.SaveFormat.Xlsx);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    public void ExportBureauComplet(int annee)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        conn.Open();

        DataSet dsFonctions = DataMapping.ExecSql("SELECT * FROM [ais_domain] where domain='RYA' order by [order]");
        List<Club> clubs = DataMapping.ListClubs(max: int.MaxValue, sort: "name");
        DataSet dsRAA = DataMapping.ExecSql("SELECT [function],[cric],[nim],(SELECT TOP 1 name FROM ais_members WHERE nim=ais_rya.nim AND cric=ais_rya.cric) as name,(SELECT TOP 1 surname FROM ais_members WHERE nim=ais_rya.nim AND cric=ais_rya.cric) as surname,(SELECT TOP 1 email FROM ais_members WHERE nim=ais_rya.nim AND cric=ais_rya.cric) as email ,(SELECT TOP 1 telephone FROM ais_members WHERE nim=ais_rya.nim AND cric=ais_rya.cric) as telephone FROM [ais_rya] WHERE [rotary_year]=" + (annee));

        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(new DataColumn("Club", typeof(String)));
        dataTable.Columns.Add(new DataColumn("CRIC", typeof(String)));
        dataTable.Columns.Add(new DataColumn("Role", typeof(String)));
        dataTable.Columns.Add(new DataColumn("Prenom", typeof(String)));
        dataTable.Columns.Add(new DataColumn("Nom", typeof(String)));
        dataTable.Columns.Add(new DataColumn("Email", typeof(String)));
        dataTable.Columns.Add(new DataColumn("Telephone", typeof(String)));
        foreach (Club c in clubs)
        {
            foreach (DataRow row in dsFonctions.Tables[0].Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Club"] = c.name;
                dataRow["CRIC"] = c.cric;
                dataRow["Role"] = row["value"];

                foreach (DataRow row1 in dsRAA.Tables[0].Rows)
                {
                    if (("" + row1["function"]) == ("" + row["value"]) && (int)row1["cric"] == c.cric)
                    {

                        dataRow["Prenom"] = row1["name"];
                        dataRow["Nom"] = row1["surname"];
                        dataRow["Email"] = row1["email"];
                        dataRow["Telephone"] = row1["telephone"];
                    }
                }
                dataTable.Rows.Add(dataRow);
            }

        }


        List<DataTable> tables = new List<DataTable>() { dataTable };



        Media media = DataMapping.ExportDataTablesToXLS(tables, "Bureau année " + annee + "-" + (annee + 1) + ".xlsx", Aspose.Cells.SaveFormat.Xlsx);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    public void ExportClubsSansBureau(int annee)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        conn.Open();

        SqlCommand sql = new SqlCommand("select cric, name as 'Nom du club' ,adress_1 as 'Adresse 1' ,adress_2 as 'Adresse 2',adress_3 as 'Adresse 3' ,zip as 'Code postal' ,town as 'Ville' , email as 'Email',web as 'Web' from ais_clubs where cric not in (select distinct [cric] FROM [ais_rya] where rotary_year = @rotary_year)", conn);
        sql.Parameters.AddWithValue("@rotary_year", annee);
        SqlDataAdapter da = new SqlDataAdapter(sql);
        DataSet ds = new DataSet();
        da.Fill(ds);
        List<DataTable> tables = new List<DataTable>();
        foreach (DataTable table in ds.Tables)
        {
            tables.Add(table);
        }


        Media media = DataMapping.ExportDataTablesToXLS(tables, "Liste des clubs qui n'ont pas déclaré de bureau.xlsx", Aspose.Cells.SaveFormat.Xlsx);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }

    public void ExportPresident(int annee)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        conn.Open();

        SqlCommand sql = new SqlCommand("select c.cric, c.name as 'nom club',a.[function] as 'fonction',a.name as 'prenom nom',(select top 1 email from ais_members where nim = a.nim) as email,(select top 1 adress_1 ++' '++ adress_2 ++' '++ adress_3 from ais_members where nim = a.nim) as adresse,(select top 1 zip_code from ais_members where nim = a.nim) as cp,(select top 1 town from ais_members where nim = a.nim) as ville,(select top 1 [gsm] from ais_members where nim = a.nim) as gsm from ais_clubs c,ais_rya a where c.cric=a.cric and a.rotary_year=@rotary_year and a.[function]='Président' order by  c.name", conn);
        sql.Parameters.AddWithValue("@rotary_year",annee);
        SqlDataAdapter da = new SqlDataAdapter(sql);
        DataSet ds = new DataSet();
        da.Fill(ds);
        List<DataTable> tables = new List<DataTable>();
        foreach (DataTable table in ds.Tables)
        {
            tables.Add(table);
        }


        Media media = DataMapping.ExportDataTablesToXLS(tables, "Liste des présidents année " + (annee) + "-" + (annee + 1) + ".xlsx", Aspose.Cells.SaveFormat.Xlsx);
        string guid = Guid.NewGuid().ToString();
        Session[guid] = media;
        Response.Redirect(Const.MEDIA_DOWNLOAD_URL + "?id=" + guid);
    }
}
