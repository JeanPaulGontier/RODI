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
    protected void Page_Load(object sender, EventArgs e)
    {
        panel.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);
    }

    protected void BT_Upload_Click(object sender, EventArgs e)
    {
        if (FU_RI.HasFile)
        {
            File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + "ClubsandMembersinYourDistrictList.xlsx"), FU_RI.FileBytes);

            Import_Fichier_MembersInAClub();
            

        }
        //if (FU_RI.UploadedFiles.Count > 0)
        //{

        //    UploadedFile file = FU_RI.UploadedFiles[0];
        //    if(Const.DISTRICT_ID==1700)
        //        file.SaveAs(Server.MapPath(PortalSettings.HomeDirectory + "ClubsandMembersinYourDistrictList.xlsx"), true);
        //    else
        //        file.SaveAs(Server.MapPath(PortalSettings.HomeDirectory + "MembersInAClub.xls"), true);

        //    Import_Fichier_MembersInAClub();

        //    dvFileUpload.Visible = false;
        //}
    }

    //protected void btn_import_ri_Click(object sender, EventArgs e)
    //{
    //    Import_Fichier_MembersInAClub();

    //    //Import_Fichier_MyRotaryAccountStatusofMembers();
    //}
    void Import_Fichier_MembersInAClub()
    {
        //if (Const.DISTRICT_ID == 1700 || Const.DISTRICT_ID == 1730)
            Import_Fichier_MembersInAClub_2021(); // le fichier issu du RI est spécifique sur le 1700
        /*else if (Const.DISTRICT_ID == 1770 )
            Import_Fichier_MembersInAClub_1770_1730(); // le fichier issu du RI est spécifique sur le 1770
        else
            Import_Fichier_MembersInAClub_Autres();*/
    }
    void Import_Fichier_MembersInAClub_1770_1730()
    {
        Aspose.Cells.License licenseCells = new Aspose.Cells.License();
        //licenseCells.SetLicense("Aspose.Total.lic");

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlTransaction trans = null;
        SqlCommand sql = null;

        try
        {

            Workbook xls = new Workbook(Server.MapPath(PortalSettings.HomeDirectory + "MembersInAClub.xls"));

            conn.Open();
            trans = conn.BeginTransaction();

            sql = new SqlCommand("DELETE FROM ais_import_ri", conn, trans);
            sql.ExecuteNonQuery();


            sql = new SqlCommand("SELECT name,cric FROM ais_clubs ORDER BY name", conn,trans);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable clubs = dataSet.Tables[0];



            Worksheet sheet = xls.Worksheets[0];
            int col = 0;
            int row = 1;
            int cric = 0;
            int nbclub = 0;
            
            while (row < 65535)
            {
                Cell cell = sheet.Cells[row, col];
                string valeur = "" + cell.Value;
                cell = sheet.Cells[row, col+1];
                string valeur1 = "" + cell.Value;
                if (valeur.Equals("Club Name :"))
                {
                    Cell cell1 = sheet.Cells[row, col + 1];
                    string[] st = ("" + cell1.Value).Split('(');
                    if (st.Length > 2)
                    {
                        int.TryParse(st[2].Replace(")", ""), out cric);
                        if (cric != 0)
                            nbclub++;
                    }
                    else if (st.Length > 1)
                    {
                        int.TryParse(st[1].Replace(")", ""), out cric);
                        if (cric != 0)
                            nbclub++;
                    }
                    if(cric<10000)
                    {
                        // le cric n'est pas complet car tronqué dans le fichier excel
                        string deb = "";
                        foreach (DataRow r in clubs.Rows)
                        {
                            if((""+ r["name"]).Equals("PORTO VECCHIO"))
                            {

                            }
                            //deb += ("" + cell1.Value).ToLower()+" - "+ ("" + r["name"]).ToLower() + Environment.NewLine;
                            if ((""+cell1.Value).ToLower().StartsWith((""+r["name"]).ToLower()))
                            {
                                int.TryParse((""+r["cric"]), out cric);
                               
                                break;
                            }
                        }
                    }
                    //string[] st = ("" + cell1.Value).Split('(');
                    //if (st.Length > 2)
                    //{
                    //    int.TryParse(st[2].Replace(")", ""), out cric);
                    //    if (cric != 0)
                    //        nbclub++;
                    //}
                    //else if (st.Length > 1)
                    //{
                    //    int.TryParse(st[1].Replace(")", ""), out cric);
                    //    if (cric != 0)
                    //        nbclub++;
                    //}
                    row++;

                }
                else if (valeur1.StartsWith("Total Active Members"))
                {
                    cric = 0;
                }
                else if (cric != 0 && !valeur.Equals("") && (valeur.Equals("Y") || valeur.Equals("N")))
                {
                    string nim = "";

                    string name = "" + sheet.Cells[row, col + 1].Value;
                    name = name.Trim().ToLower().Replace("\n"," ").Replace("\r", "");
                    int idx = name.IndexOf(" (");
                    if(idx>-1)
                    {
                        nim = name.Substring(idx).Replace("(", "").Replace(")","").Trim() ;
                    }
                    name = name.Replace("(" + nim + ")", "").Trim();
                    string[] names = name.Split(',');
                    
                    string[] firstnameArray = names[1].Trim().Split('-');
                    string firstNameFinal = "";
                    foreach(string s in firstnameArray)
                    {
                        
                        firstNameFinal = firstNameFinal + UppercaseFirst(s) + "-";
                    }

                    firstNameFinal = firstNameFinal.TrimEnd('-');

                    name = firstNameFinal + " " + names[0].ToUpper();

                    string email = "";// + sheet.Cells[row, col + 3].Value;

                    sql = new SqlCommand("INSERT INTO ais_import_ri (cric,nim,membername,email,lastname,firstname,clubname) VALUES (@cric,@nim,@membername,@email,@lastname,@firstname,(select name from ais_clubs where cric=@cric))", conn, trans);
                    sql.Parameters.AddWithValue("cric", cric);
                    sql.Parameters.AddWithValue("nim", nim);
                    sql.Parameters.AddWithValue("membername", name);
                    sql.Parameters.AddWithValue("email", email);
                    sql.Parameters.AddWithValue("lastname", names[0].ToUpper());
                    sql.Parameters.AddWithValue("firstname", firstNameFinal);
                    sql.ExecuteNonQuery();
                }
                row++;
            }
            trans.Commit();

            sql = new SqlCommand("SELECT * FROM ais_import_ri ORDER BY CRIC", conn);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            members.DataSource = ds.Tables[0];
            members.DataBind();

            lbl_result.Text = ds.Tables[0].Rows.Count + " membres importés, dans " + nbclub + " clubs";
            panel_result.Visible = true;

            sql = new SqlCommand("SELECT count(*) FROM ais_import_ri where clubname=''", conn);
            int nb_club_noname = int.Parse("" + sql.ExecuteScalar());

            sql = new SqlCommand("SELECT count(*) FROM ais_import_ri where nim=0", conn);
            int nb_nim_null = int.Parse("" + sql.ExecuteScalar());

            sql = new SqlCommand("SELECT count(*) FROM ais_import_ri where cric<10000", conn);
            int nb_false_cric = int.Parse("" + sql.ExecuteScalar());

            // il ne faut pas d'erreur pour pouvoir faire le rapprochement
            btn_rapprochement.Visible = (nb_club_noname+ nb_nim_null+ nb_false_cric)==0;
            if(!btn_rapprochement.Visible)
                result_rapprochement.Text = "Impossible de procéder au rapprochement, il y a des erreurs dans les doonées (vérifier, nom club, cric et nim dans le fichier excel)";

        }
        catch (Exception ee)
        {
            if (trans != null)
                trans.Rollback();

            Functions.Error(ee);
        }
        finally
        {
            conn.Close();
        }
    }
    void Import_Fichier_MembersInAClub_Autres()
    {
        Aspose.Cells.License licenseCells = new Aspose.Cells.License();
        //licenseCells.SetLicense("Aspose.Total.lic");

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlTransaction trans = null;
        SqlCommand sql = null;

        try
        {

            Workbook xls = new Workbook(Server.MapPath(PortalSettings.HomeDirectory + "MembersInAClub.xls"));

            conn.Open();
            trans = conn.BeginTransaction();

            sql = new SqlCommand("DELETE FROM ais_import_ri", conn, trans);
            sql.ExecuteNonQuery();


            sql = new SqlCommand("SELECT name,cric FROM ais_clubs ORDER BY name", conn, trans);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable clubs = dataSet.Tables[0];



            Worksheet sheet = xls.Worksheets[0];
            int col = 0;
            int row = 1;
            int cric = 0;
            int nbclub = 0;

            while (row < 65535)
            {
                Cell cell = sheet.Cells[row, col];
                string valeur = "" + cell.Value;
                cell = sheet.Cells[row, col + 1];
                string valeur1 = "" + cell.Value;
                if (valeur.Equals("Club Name :"))
                {
                    //                    Cell cell1 = sheet.Cells[row, col + 1];
                    Cell cell1 = sheet.Cells[row, col + 2]; // modif 08/01/2020
                    string[] st = ("" + cell1.Value).Split('(');
                    if (st.Length > 2)
                    {
                        int.TryParse(st[2].Replace(")", ""), out cric);
                        if (cric != 0)
                            nbclub++;
                    }
                    else if (st.Length > 1)
                    {
                        int.TryParse(st[1].Replace(")", ""), out cric);
                        if (cric != 0)
                            nbclub++;
                    }
                    if (cric < 10000)
                    {
                        // le cric n'est pas complet car tronqué dans le fichier excel
                        string deb = "";
                        foreach (DataRow r in clubs.Rows)
                        {
                            if (("" + r["name"]).Equals("PORTO VECCHIO"))
                            {

                            }
                            //deb += ("" + cell1.Value).ToLower()+" - "+ ("" + r["name"]).ToLower() + Environment.NewLine;
                            if (("" + cell1.Value).ToLower().StartsWith(("" + r["name"]).ToLower()))
                            {
                                int.TryParse(("" + r["cric"]), out cric);

                                break;
                            }
                        }
                    }
                    //string[] st = ("" + cell1.Value).Split('(');
                    //if (st.Length > 2)
                    //{
                    //    int.TryParse(st[2].Replace(")", ""), out cric);
                    //    if (cric != 0)
                    //        nbclub++;
                    //}
                    //else if (st.Length > 1)
                    //{
                    //    int.TryParse(st[1].Replace(")", ""), out cric);
                    //    if (cric != 0)
                    //        nbclub++;
                    //}
                    row++;

                }
                else if (valeur1.StartsWith("Total Active Members"))
                {
                    cric = 0;
                }
                else if (cric != 0 && !valeur.Equals("") && (valeur.Equals("Y") || valeur.Equals("N")))
                {
                    string nim = "";

                    string name = "" + sheet.Cells[row, col + 1].Value;
                    name = name.Trim().ToLower().Replace("\n", " ").Replace("\r", "");
                    int idx = name.IndexOf(" (");
                    if (idx > -1)
                    {
                        nim = name.Substring(idx).Replace("(", "").Replace(")", "").Trim();
                    }
                    name = name.Replace("(" + nim + ")", "").Trim();
                    string[] names = name.Split(',');

                    string[] firstnameArray = names[1].Trim().Split('-');
                    string firstNameFinal = "";
                    foreach (string s in firstnameArray)
                    {

                        firstNameFinal = firstNameFinal + UppercaseFirst(s) + "-";
                    }

                    firstNameFinal = firstNameFinal.TrimEnd('-');

                    name = firstNameFinal + " " + names[0].ToUpper();

                    string email = "" + sheet.Cells[row, col + 3].Value;

                    sql = new SqlCommand("INSERT INTO ais_import_ri (cric,nim,membername,email,lastname,firstname,clubname) VALUES (@cric,@nim,@membername,@email,@lastname,@firstname,(select name from ais_clubs where cric=@cric))", conn, trans);
                    sql.Parameters.AddWithValue("cric", cric);
                    sql.Parameters.AddWithValue("nim", nim);
                    sql.Parameters.AddWithValue("membername", name);
                    sql.Parameters.AddWithValue("email", email);
                    sql.Parameters.AddWithValue("lastname", names[0].ToUpper());
                    sql.Parameters.AddWithValue("firstname", firstNameFinal);
                    sql.ExecuteNonQuery();
                }
                row++;
            }
            trans.Commit();

            sql = new SqlCommand("SELECT * FROM ais_import_ri ORDER BY CRIC", conn);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            members.DataSource = ds.Tables[0];
            members.DataBind();

            lbl_result.Text = ds.Tables[0].Rows.Count + " membres importés, dans " + nbclub + " clubs";
            panel_result.Visible = true;

            sql = new SqlCommand("SELECT count(*) FROM ais_import_ri where clubname=''", conn);
            int nb_club_noname = int.Parse("" + sql.ExecuteScalar());

            sql = new SqlCommand("SELECT count(*) FROM ais_import_ri where nim=0", conn);
            int nb_nim_null = int.Parse("" + sql.ExecuteScalar());

            sql = new SqlCommand("SELECT count(*) FROM ais_import_ri where cric<10000", conn);
            int nb_false_cric = int.Parse("" + sql.ExecuteScalar());

            // il ne faut pas d'erreur pour pouvoir faire le rapprochement
            btn_rapprochement.Visible = (nb_club_noname + nb_nim_null + nb_false_cric) == 0;
            if (!btn_rapprochement.Visible)
                result_rapprochement.Text = "Impossible de procéder au rapprochement, il y a des erreurs dans les doonées (vérifier, nom club, cric et nim dans le fichier excel)";

        }
        catch (Exception ee)
        {
            if (trans != null)
                trans.Rollback();

            Functions.Error(ee);
        }
        finally
        {
            conn.Close();
        }
    }
    void Import_Fichier_MembersInAClub_2021()
    {
        Aspose.Cells.License licenseCells = new Aspose.Cells.License();
        //licenseCells.SetLicense("Aspose.Total.lic");

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlTransaction trans = null;
        SqlCommand sql = null;

        try
        {

            Workbook xls = new Workbook(Server.MapPath(PortalSettings.HomeDirectory + "ClubsandMembersinYourDistrictList.xlsx"));

            conn.Open();
            trans = conn.BeginTransaction();

            sql = new SqlCommand("DELETE FROM ais_import_ri", conn, trans);
            sql.ExecuteNonQuery();


            sql = new SqlCommand("SELECT name,cric FROM ais_clubs WHERE type_club!='interact' ORDER BY name", conn, trans);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable clubs = dataSet.Tables[0];

            Dictionary<string, string> satellites = new Dictionary<string, string>();

            
            Worksheet sheet = xls.Worksheets[0];
            int col = 2;
            int row = 6;


            while (row < 65535)
            {
                Cell cell = sheet.Cells[row, col];
                string nim = "" + cell.Value;
                cell = sheet.Cells[row, col + 10];
                string value = "" + cell.Value;
                if (value == "Y")
                    satellites.Add(nim, value);
                row++;
            }






            sheet = xls.Worksheets[1];
            col = 0;
            row = 1;
            int cric = 0;
            int nbclub = 0;

            while (row < 65535)
            {
                Cell cell = sheet.Cells[row, col];
                string valeur = "" + cell.Value;
                cell = sheet.Cells[row, col + 1];
                string valeur1 = "" + cell.Value;
                if (valeur.Equals(""+Const.DISTRICT_ID))
                {
                    //                    Cell cell1 = sheet.Cells[row, col + 1];
                    Cell cell1 = sheet.Cells[row, col + 1]; // modif 08/01/2020
                    string[] st = ("" + cell1.Value).Split('(');
                    if (st.Length > 2)
                    {
                        int.TryParse(st[2].Replace(")", ""), out cric);
                        if (cric != 0)
                            nbclub++;
                    }
                    else if (st.Length > 1)
                    {
                        int.TryParse(st[1].Replace(")", ""), out cric);
                        if (cric != 0)
                            nbclub++;
                    }

                   if(cric!=0)
                   {                         

                        string nim = "" + sheet.Cells[row, col + 3].Value;
                      
                        string prenom = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(("" + sheet.Cells[row, col + 6].Value).ToLower());
                        string name = ("" + sheet.Cells[row, col + 8].Value).ToUpper();
                        string sexe = ("" + sheet.Cells[row, col + 10].Value);
                        string admission = "" + sheet.Cells[row, col + 12].Value;
                        string active = "" + sheet.Cells[row, col + 14].Value;
                        string email = ("" + sheet.Cells[row, col + 17].Value).ToLower();
                        string telephone = "" + sheet.Cells[row, col + 19].Value;
                        string ad1 = "" + sheet.Cells[row, col + 20].Value;
                        string ad2 = "" + sheet.Cells[row, col + 21].Value;
                        string ad3 = "" + sheet.Cells[row, col + 22].Value;
                        string ville = ("" + sheet.Cells[row, col + 23].Value).ToUpper();
                        string pays = ("" + sheet.Cells[row, col + 26].Value).ToUpper();
                        string cp = "" + sheet.Cells[row, col + 27].Value;

                        bool satellite = satellites.ContainsKey(nim);

                        DateTime ad = DateTime.Now;
                        bool hasdate = DateTime.TryParse(admission, out ad);
                            

                        #region traitement spécifique pour D1770
                        if (satellite && Const.DISTRICT_ID==1770)
                        {
                            switch(cric)
                            {
                                case 11366:
                                    cric = 84712;
                                    break;
                                case 22999:
                                    cric = 84775;
                                    break;
                                case 11384:
                                    cric = 84138;
                                    break;
                                case 11400:
                                    cric = 85035;
                                    break;
                                case 11394:
                                    cric = 222336;
                                    break;
                                default:
                                    break;
                            }
                               
   
   
   


                        }
                        #endregion
                        //if (active!="Honorary")
                        //{ 
                        sql = new SqlCommand("INSERT INTO ais_import_ri " +
                                "(cric,nim,membername,email,lastname,firstname,clubname,admission,telephone,ad1,ad2,ad3,ville,cp,pays,sexe,honneur,satellite) VALUES " +
                                "(@cric,@nim,@membername,@email,@lastname,@firstname,(select name from ais_clubs where cric=@cric),@admission,@telephone,@ad1,@ad2,@ad3,@ville,@cp,@pays,@sexe,@honneur,@satellite)", conn, trans);
                            sql.Parameters.AddWithValue("cric", cric);
                            sql.Parameters.AddWithValue("nim", nim);
                            sql.Parameters.AddWithValue("membername", name);
                            sql.Parameters.AddWithValue("email", email);
                            sql.Parameters.AddWithValue("lastname", name);
                            sql.Parameters.AddWithValue("firstname", prenom);
                            sql.Parameters.AddWithValue("sexe", sexe == "Female" ? "Mme":"M") ;
                            if(hasdate)
                                sql.Parameters.AddWithValue("admission", ad);
                            else
                                sql.Parameters.AddWithValue("admission", System.DBNull.Value);
                            sql.Parameters.AddWithValue("telephone", telephone);
                            sql.Parameters.AddWithValue("ad1", ad1);
                            sql.Parameters.AddWithValue("ad2", ad2);
                            sql.Parameters.AddWithValue("ad3", ad3);
                            sql.Parameters.AddWithValue("ville", ville);
                            sql.Parameters.AddWithValue("cp", cp);
                            sql.Parameters.AddWithValue("pays", pays);
                            sql.Parameters.AddWithValue("honneur", active == "Honorary");
                            sql.Parameters.AddWithValue("satellite", satellite);
                           

                            sql.ExecuteNonQuery();
                        //}
                       
                    }
                }
                row++;
            }
            trans.Commit();

            sql = new SqlCommand("SELECT * FROM ais_import_ri ORDER BY CRIC", conn);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            members.DataSource = ds.Tables[0];
            members.DataBind();

            lbl_result.Text = ds.Tables[0].Rows.Count + " membres importés";
            panel_result.Visible = true;

            sql = new SqlCommand("SELECT count(*) FROM ais_import_ri where clubname=''", conn);
            int nb_club_noname = int.Parse("" + sql.ExecuteScalar());

            // sql = new SqlCommand("SELECT count(*) FROM ais_import_ri where nim=0", conn);
            int nb_nim_null = 0;//int.Parse("" + sql.ExecuteScalar());

            //sql = new SqlCommand("SELECT count(*) FROM ais_import_ri where cric<10000", conn);
            int nb_false_cric = 0;// int.Parse("" + sql.ExecuteScalar());

            // il ne faut pas d'erreur pour pouvoir faire le rapprochement
            btn_rapprochement.Visible = (nb_club_noname + nb_nim_null + nb_false_cric) == 0;
            if (!btn_rapprochement.Visible)
                result_rapprochement.Text = "Impossible de procéder au rapprochement, il y a des erreurs dans les données (vérifier, nom club, cric et nim dans le fichier excel)";

        }
        catch (Exception ee)
        {
            error.Visible = true;
            errorlabel.Text = ee.Message + Environment.NewLine + ee.StackTrace;
            if (trans != null)
                trans.Rollback();

            Functions.Error(ee);
        }
        finally
        {
            conn.Close();
        }
    }
    void Import_Fichier_MyRotaryAccountStatusofMembers()
    {
        Aspose.Cells.License licenseCells = new Aspose.Cells.License();
        //licenseCells.SetLicense("Aspose.Total.lic");

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlTransaction trans = null;
        SqlCommand sql = null;

        try
        {

            Workbook xls = new Workbook(Server.MapPath("/MyRotaryAccountStatusofMembers.xls"));
            
            conn.Open();
            trans = conn.BeginTransaction();

            sql = new SqlCommand("DELETE FROM ais_import_ri", conn, trans);
            sql.ExecuteNonQuery();


            Worksheet sheet = xls.Worksheets[0];
            int col = 1;
            int row = 1;
            int cric = 0;
            int nbclub = 0;
            while (row < 65535)
            {
                Cell cell = sheet.Cells[row, col];
                string valeur = "" + cell.Value;
                if (valeur.Equals("Club Name:"))
                {
                    Cell cell1 = sheet.Cells[row, col + 1];

                    string[] st = ("" + cell1.Value).Split('(');
                    if (st.Length > 2)
                    {
                        int.TryParse(st[2].Replace(")", ""), out cric);
                        if (cric != 0)
                            nbclub++;
                    }
                    else if (st.Length > 1)
                    {
                        int.TryParse(st[1].Replace(")", ""), out cric);
                        if (cric != 0)
                            nbclub++;
                    }
                    row++;

                }
                else if (valeur.StartsWith("Total Active Members"))
                {
                    cric = 0;
                }
                else if (cric != 0 && !valeur.Equals(""))
                {
                    string name = "" + sheet.Cells[row, col + 1].Value;
                    name = name.Replace("(" + valeur + ")", "").Trim().ToLower();

                    string email = "" + sheet.Cells[row, col + 3].Value;

                    sql = new SqlCommand("INSERT INTO ais_import_ri (cric,nim,membername,email) VALUES (@cric,@nim,@membername,@email)", conn, trans);
                    sql.Parameters.AddWithValue("cric", cric);
                    sql.Parameters.AddWithValue("nim", valeur);
                    sql.Parameters.AddWithValue("membername", name);
                    sql.Parameters.AddWithValue("email", email);
                    sql.ExecuteNonQuery();
                }
                row++;
            }
            trans.Commit();

            sql = new SqlCommand("SELECT * FROM ais_import_ri ORDER BY CRIC", conn);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            members.DataSource = ds.Tables[0];
            members.DataBind();

            lbl_result.Text = ds.Tables[0].Rows.Count + " membres importés, dans " + nbclub + " clubs";
            panel_result.Visible = true;


            // btn_rapprochement.Visible = true;
        }
        catch (Exception ee)
        {
            error.Visible = true;
            errorlabel.Text = ee.Message  +Environment.NewLine + ee.StackTrace;
            if (trans != null)
                trans.Rollback();

            Functions.Error(ee);
        }
        finally
        {
            conn.Close();
        }
    }

    protected void btn_rapprochement_Click(object sender, EventArgs e)
    {
        panel_result.Visible = false;
        panel_rapprochement.Visible = true;

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlTransaction trans = null;
        SqlCommand sql = null;
        string result = "";
        try
        {
            conn.Open();
            // sauvegarde des membres
            sql = new SqlCommand("SELECT * INTO ais_members_"+DateTime.Now.ToString("yyyyMMddHHmmss")+"  FROM ais_members", conn);
            sql.ExecuteNonQuery();
            List<Member> ids_to_delete = new List<Member>();

            List<Club> clubs = DataMapping.ListClubs("", "", "", 0, 1000);
            foreach(Club club in clubs)
            {
                if(club.club_type!="interact")
                { 
                    List<Member> membres = DataMapping.ListMembers(club.cric, "", "", "", 0, 1000, false, false);

                    sql = new SqlCommand("SELECT * FROM ais_import_ri WHERE cric = @cric", conn);
                    sql.Parameters.AddWithValue("cric", club.cric);
                    SqlDataAdapter da = new SqlDataAdapter(sql);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                
                    foreach (Member m in membres)
                    {
                        string nom = (m.surname + " " + m.name).ToLower();
                        bool found = false;
                        foreach(DataRow row in ds.Tables[0].Rows)
                        {
                            if((int)row["nim"]==m.nim)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            Member mtd = DataMapping.GetMember(m.id);
                            if(mtd!=null)
                                ids_to_delete.Add(mtd);
                        }



                    }

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        bool found = false;
                        bool honneur = (bool)row["honneur"];

                        foreach (Member m in membres)
                        { 
                            if ((int)row["nim"] == m.nim)
                            {
                                m.email = "" + row["email"];
                                m.name = "" + row["firstname"];
                                m.surname = "" + row["lastname"];
                                m.civility = "" + row["sexe"];
                                if(row["admission"] != System.DBNull.Value)
                                    m.year_membership_rotary = (DateTime)row["admission"];
                                else
                                    m.year_membership_rotary = null;
                                m.telephone = "" + row["telephone"];
                                
                                //m.adress_1 = "" + row["ad1"];
                                //m.adress_2 = "" + row["ad2"];
                                //m.adress_3 = "" + row["ad3"];
                                //m.zip_code = "" + row["cp"];
                                //m.town = "" + row["ville"];
                                //m.country = "" + row["pays"];
                                m.professionnal_adress = ("" + row["ad1"] + " " + row["ad2"] + " " + row["ad3"]).Trim();
                                m.professionnal_zip_code = "" + row["cp"];
                                m.professionnal_town = "" + row["ville"];
                                
                                m.honorary_member = honneur ? Const.YES : Const.NO;
                                //m.base_dtupdate = DateTime.Now;
                                DataMapping.UpdateMember(m);
                                result += "Mise à jour : " + row["firstname"] + " " + row["lastname"] + " (" + club.name + ")<br/>";
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            Member mm = DataMapping.GetMemberByNim((int)row["nim"]);
                            if(mm!=null)
                            {
                                // on doit updater le club du membre
                                mm.cric = club.cric;
                                mm.club_name = club.name;
                                mm.email = "" + row["email"];
                                mm.name = "" + row["firstname"];
                                mm.surname = "" + row["lastname"];
                                mm.civility = "" + row["sexe"];
                                mm.year_membership_rotary = (DateTime)row["admission"];
                                mm.telephone = "" + row["telephone"];
                                //mm.adress_1 = "" + row["ad1"];
                                //mm.adress_2 = "" + row["ad2"];
                                //mm.adress_3 = "" + row["ad3"];
                                //mm.zip_code = "" + row["cp"];
                                //mm.town = "" + row["ville"];
                                //mm.country = "" + row["pays"];

                                mm.professionnal_adress = ("" + row["ad1"] + " " + row["ad2"] + " " + row["ad3"]).Trim();
                                mm.professionnal_zip_code = "" + row["cp"];
                                mm.professionnal_town = "" + row["ville"];

                                mm.honorary_member = honneur ? Const.YES:Const.NO;
                                //mm.base_dtupdate = DateTime.Now;

                                try
                                { 
                                    foreach (Member m in ids_to_delete)
                                        if (m.id == mm.id)
                                            ids_to_delete.Remove(m);
                                }
                                catch { }
                            
                                DataMapping.UpdateMember(mm);
                                result += "Changement de club : " + row["firstname"] + " " + row["lastname"] + " (" + club.name + ")<br/>";
                            }
                            else
                            {
                                // le membre n'existe pas du tout donc in l'ajoute
                                //sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "members " +
                                //    "([nim],[surname],[name],[cric],[district_id],[club_name],civility,year_membership_rotary,adress_1,adress_2,adress_3,zip_code,town,country,email,telephone,honorary_member) VALUES " +
                                //    "(@nim,@surname,@name,@cric,@district_id,@club_name,@sexe,@admission,@ad1,@ad2,@ad3,@cp,@ville,@pays,@email,@telephone,@honorary_member)", conn, trans);
                                sql = new SqlCommand("INSERT INTO " + Const.TABLE_PREFIX + "members " +
                                                                    "([nim],[surname],[name],[cric],[district_id],[club_name],civility,year_membership_rotary,professionnal_adress,professionnal_zip_code,professionnal_town,email,telephone,honorary_member) VALUES " +
                                                                    "(@nim,@surname,@name,@cric,@district_id,@club_name,@sexe,@admission,@professionnal_adress,@professionnal_zip_code,@professionnal_town,@email,@telephone,@honorary_member)", conn, trans);

                                sql.Parameters.AddWithValue("@nim", row["nim"]);
                                sql.Parameters.AddWithValue("@surname", row["lastname"]);
                                sql.Parameters.AddWithValue("@name", row["firstname"]);
                                sql.Parameters.AddWithValue("@cric",club.cric);
                                sql.Parameters.AddWithValue("@district_id", Const.DISTRICT_ID);
                                sql.Parameters.AddWithValue("@club_name", club.name);
                                sql.Parameters.AddWithValue("@sexe", row["sexe"]);
                                sql.Parameters.AddWithValue("@admission", row["admission"]);
                                sql.Parameters.AddWithValue("@telephone", row["telephone"]);
                                //sql.Parameters.AddWithValue("@ad1", row["ad1"]);
                                //sql.Parameters.AddWithValue("@ad2", row["ad2"]);
                                //sql.Parameters.AddWithValue("@ad3", row["ad3"]);
                                //sql.Parameters.AddWithValue("@cp", row["cp"]);
                                //sql.Parameters.AddWithValue("@ville", row["ville"]);
                                //sql.Parameters.AddWithValue("@pays", row["pays"]);
                                sql.Parameters.AddWithValue("@professionnal_adress", ("" + row["ad1"] + " " + row["ad2"] + " " + row["ad3"]).Trim());
                                sql.Parameters.AddWithValue("@professionnal_zip_code", row["cp"]);
                                sql.Parameters.AddWithValue("@professionnal_town", row["ville"]);

                                sql.Parameters.AddWithValue("@email", row["email"]);
                                sql.Parameters.AddWithValue("@honorary_member", honneur ? Const.YES : Const.NO);
                                sql.ExecuteNonQuery();

                                result += "Creation : " + row["firstname"] + " " + row["lastname"] + " (" + club.name + ")<br/>";
                            }

                        }
                    }
                
                

                }
                foreach(Member m in ids_to_delete)
                {
                    DataMapping.DeleteMember(m.id);
                    result += "Effacement : " + m.name + " " + m.surname + " (" + m.club_name + ")<br/>";
                }
                if (result.Equals(""))
                    result_rapprochement.Text = "L'effectif est à jour, il n'y a rien à rapprocher";
                else
                    result_rapprochement.Text = result;

            }
        }
        catch (Exception ee)
        {
            error.Visible = true;
            errorlabel.Text = ee.Message + Environment.NewLine + ee.StackTrace;
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