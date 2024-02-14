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
using System.Text;
using DotNetNuke.Common;
using DotNetNuke.Security.Roles;


public partial class DesktopModules_AIS_Admin_Import_RI_Affectations : PortalModuleBase
{
    public string type {
        get
        {
            return "" + RB_type.SelectedValue;
        }
    }

    public int annee
    {
        get
        {
            return type == "current" ? Functions.GetRotaryYear() : Functions.GetRotaryYear() + 1;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        panel.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);
    }

    protected void BT_Upload_Click(object sender, EventArgs e)
    {
        if (FU_RI.HasFile)
        {
            
            string filename = type+"ClubOfficer.xlsx";
            File.WriteAllBytes(Server.MapPath(PortalSettings.HomeDirectory + filename),FU_RI.FileBytes);


            ImportCurrent(filename);

        }
    }

    public Dictionary<string, string> col = new Dictionary<string, string>();

    public string GetVal(Worksheet worksheet, string key, int line) {
        string c = col[key];
        return ("" + worksheet.Cells[c + line].Value).Trim() ;
    }


    void ImportCurrent(string filename)
    {
        Aspose.Cells.License licenseCells = new Aspose.Cells.License();
        //licenseCells.SetLicense("Aspose.Total.lic");

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlTransaction trans = null;
        SqlCommand sql = null;

        
        try
        {

            Workbook xls = new Workbook(Server.MapPath(PortalSettings.HomeDirectory + filename));

            conn.Open();
            trans = conn.BeginTransaction();

            sql = new SqlCommand("delete from ais_import_ri_affectations where type='" + type + "'", conn,trans);
            sql.ExecuteNonQuery();

            
            #region rotary
                Worksheet sheet = xls.Worksheets[0];

                col = new Dictionary<string, string>();

                if (("" + sheet.Cells["A1"].Value).Trim() == "Adjoint du gouverneur")
                {
                    col.Add("Adjoint du gouverneur", "A");
                    col.Add("Nom du rotary club", "B");
                    col.Add("Numéro de club", "C");
                    col.Add("Rôle Club", "E");
                    col.Add("Prénom et nom", "F");
                    col.Add("E-mail", "I");
                }
                else if (("" + sheet.Cells["B1"].Value).Trim() == "Adjoint du gouverneur")
                {
                    col.Add("Adjoint du gouverneur", "B");
                    col.Add("Nom du rotary club", "C");
                    col.Add("Numéro de club", "D");
                    col.Add("Rôle Club", "F");
                    col.Add("Prénom et nom", "G");
                    col.Add("E-mail", "J");
                }
                else
                {
                    throw new Exception("mauvais format de fichier contactez le webmaster");
                }

                int i = 2;
                string A = GetVal(sheet, "Adjoint du gouverneur",i);
                while(A!="")
                {
                    if(!"information non signalée".Equals(GetVal(sheet, "Prénom et nom", i).ToLower()))
                    { 
                        sql = new SqlCommand("insert into ais_import_ri_affectations " +
                            "(type,cric,role,nom,email) VALUES " +
                            "(@type,@cric,@role,@nom,@email)", conn, trans);
                        sql.Parameters.AddWithValue("type", type);
                        sql.Parameters.AddWithValue("cric",GetVal(sheet, "Numéro de club",i));
                        sql.Parameters.AddWithValue("role", GetVal(sheet, "Rôle Club", i));
                        string nom = clearnom(GetVal(sheet, "Prénom et nom",i));
                        sql.Parameters.AddWithValue("nom", nom);
                        sql.Parameters.AddWithValue("email", GetVal(sheet, "E-mail", i).ToLower());
                        sql.ExecuteNonQuery();
                    }
                

                    i++;
                    A = GetVal(sheet, "Adjoint du gouverneur", i);
                }
            #endregion
            #region rotaract
                sheet = xls.Worksheets[1];

                col = new Dictionary<string, string>();

                if (("" + sheet.Cells["E1"].Value).Trim() == "Prénom et nom")
                {
                    col.Add("Nom du rotaract  club", "A");
                    col.Add("Numéro de club", "B");
                    col.Add("Rôle Rotaract", "D");
                    col.Add("Prénom et nom", "E");
                    col.Add("E-mail", "H");
                }
                else if (("" + sheet.Cells["F1"].Value).Trim() == "Prénom et nom")
                {
                    col.Add("Nom du rotaract  club", "A");
                    col.Add("Numéro de club", "B");
                    col.Add("Rôle Rotaract", "D");
                    col.Add("Prénom et nom", "F");
                    col.Add("E-mail", "I");
                }
                else
                {
                    throw new Exception("mauvais format de fichier contactez le webmaster");
                }


                i = 2;
                A = GetVal(sheet, "Nom du rotaract  club", i);
                while (A != "")
                {
                    if (!"information non signalée".Equals(GetVal(sheet, "Prénom et nom", i).ToLower()))
                    {
                        sql = new SqlCommand("insert into ais_import_ri_affectations " +
                            "(type,cric,role,nom,email) VALUES " +
                            "(@type,@cric,@role,@nom,@email)", conn, trans);
                        sql.Parameters.AddWithValue("type", type);
                        sql.Parameters.AddWithValue("cric", GetVal(sheet, "Numéro de club", i));
                        sql.Parameters.AddWithValue("role", GetVal(sheet, "Rôle Rotaract", i));

                        // patch différence entre fichier incoming et fichier current

                        string nom = clearnom(GetVal(sheet, "Prénom et nom",i));
                        sql.Parameters.AddWithValue("nom", nom );
                        sql.Parameters.AddWithValue("email", GetVal(sheet, "E-mail", i).ToLower());
                        sql.ExecuteNonQuery();
                    }

                    i++;
                    A = GetVal(sheet, "Nom du rotaract  club", i);
                }
            #endregion

            sql = new SqlCommand("SELECT * FROM ais_import_ri_affectations where type='"+type+"' ORDER BY CRIC", conn,trans);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            members.DataSource = ds.Tables[0];
            members.DataBind();

            trans.Commit();
            panel_result.Visible = true;
            btn_rapprochement.Visible = true;
            result_rapprochement.Text = "";

        }
        catch (Exception ee)
        {
            error.Visible = true;
            errorlabel.Text = ee.Message;
            Functions.Error(ee);
        }
        finally
        {
            conn.Close();
        }
    }

    protected string clearnom(string nom)
    {
        nom = nom.ToLower();

        nom = nom.Replace(", ii", "");
        nom = nom.Replace("mr. ", "");
        nom = nom.Replace("mr ", "");
        nom = nom.Replace("monsieur ", "");
        nom = nom.Replace("madame ", "");
        nom = nom.Replace("mademoiselle ", "");
        nom = nom.Replace("docteur ", "");
        nom = nom.Replace("m. ", "");
        nom = nom.Replace("mlle. ", "");
        nom = nom.Replace("mlle ", "");
        nom = nom.Replace("mme. ", "");
        nom = nom.Replace("mme ", "");
        if (nom.StartsWith("m "))
            nom = nom.Substring(2);
        if (nom.StartsWith("dr "))
            nom = nom.Substring(3);
        nom = nom.Trim();
        return nom;
    }


    protected void btn_rapprochement_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> c = new Dictionary<string, string>();
        //c.Add("", "Action Professionnelle");
        //c.Add("Club Executive Secretary/Director(Facultatif)", "Administration");
        c.Add("Rotaract Advisor", "Administration");
        c.Add("Club Public Image Chair", "Délégué Communication");
        c.Add("Rotaract Public Image Chair", "Délégué Communication");
        //c.Add("", "Délégué Jeunesse");
        c.Add("Club Membership Chair", "Effectif");
        c.Add("Rotaract Membership Chair", "Effectif");
        c.Add("Club Foundation Chair", "Fondation Rotary");
        c.Add("Rotaract Foundation Chair", "Fondation Rotary");
        //c.Add("", "Past président");
        c.Add("Club President", "Président");
        c.Add("Rotaract President", "Président");
        //c.Add("", "Président élu");
        //c.Add("", "Protocole");
        //c.Add("Club Executive Secretary/Director (Facultatif)", "Administration");
         c.Add("Club Secretary", "Secrétaire");
        c.Add("Rotaract Secretary", "Secrétaire");
        c.Add("", "Secrétaire Adjoint");
        c.Add("Club Treasurer", "Trésorier");
        c.Add("Rotaract Treasurer", "Trésorier");
        //c.Add("", "Trésorier Adjoint");
        //c.Add("", "Webmaster");
        //c.Add("", "Webmaster Adjoint");
        c.Add("Club Service Projects Chair", "Responsable Actions");
        c.Add("Rotaract Service Projects Chair", "Responsable Actions");
        c.Add("Club Learning Facilitator", "Responsable Formation");
        c.Add("Club Vice President", "Vice Président");

        // nouveau roles au 08/01/2024
        c.Add("Club Executive Secretary/Director (Facultatif)", "Secrétaire Exécutif");
        c.Add("Club Executive Secretary/Director(Facultatif)", "Secrétaire Exécutif");



        result_rapprochement.Text = "";

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlTransaction trans = null;
        SqlCommand sql = null;

        StringBuilder sb = new StringBuilder();
        StringBuilder sbe = new StringBuilder();
        try
        {

            List<Member> members = DataMapping.ListMembers(max: int.MaxValue);

            conn.Open();
            trans = conn.BeginTransaction();


            sql = new SqlCommand("SELECT * FROM ais_import_ri_affectations where type='" + type + "'", conn,trans);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet);

            RoleController rc = new RoleController();
            RoleInfo uri = rc.GetRoleByName(Globals.GetPortalSettings().PortalId, Const.ROLE_ADMIN_CLUB);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string cric = "" + row["cric"];
                string role = "" + row["role"];

                string nim = "";
                string n = "";
                string em = "";
                foreach (Member m in members)
                {
                    string nom = (m.name + " " + m.surname).ToLower();
                    if (nom == (""+row["nom"]))
                    {
                        n = m.name + " " + m.surname;
                        nim = "" + m.nim;
                        em = m.email;
                        break;
                    }
                }
                if(nim=="")
                {
                    foreach (Member m in members)
                    {
                        string email = m.email.ToLower();
                        if (email == ("" + row["email"]))
                        {
                            n = m.name + " " + m.surname;
                            nim = "" + m.nim;
                            em = m.email;
                            break;
                        }
                    }
                }
                error:
                if(nim!="")
                {
                    string r = "";
                    if (c.ContainsKey(role))
                        r = c[role].ValueOrEmpty();
                    else
                    {
                        nim = "";
                        goto error;
                    }
                    if(r=="")
                    {
                        nim = "";
                        goto error;
                    }
                    sql = new SqlCommand("select nim from ais_rya where cric=@cric and rotary_year=@annee and [function]=@role", conn, trans);
                    sql.Parameters.AddWithValue("cric", cric);
                    sql.Parameters.AddWithValue("annee", annee);
                    sql.Parameters.AddWithValue("role", r);
                    string niiiim = "" + sql.ExecuteScalar();
                    UserInfo ui = null;
                    foreach (Member m in members)
                    {
                        if((""+m.nim)==niiiim)
                        {
                            ui = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, m.email);
                            if (ui != null)
                            {
                                rc.UpdateUserRole(PortalId, ui.UserID, uri.RoleID, RoleStatus.Disabled, false, false);
                                
                            }

                            break;
                        }
                    }
                    
                    sql = new SqlCommand("delete from ais_rya where cric=@cric and rotary_year=@annee and [function]=@role", conn, trans);
                    sql.Parameters.AddWithValue("cric", cric);
                    sql.Parameters.AddWithValue("annee", annee);
                    sql.Parameters.AddWithValue("role", r);
                    sql.ExecuteNonQuery();

                    sql = new SqlCommand("insert into ais_rya (cric,rotary_year,[function],name,nim) values (@cric,@annee,@role,@name,@nim)", conn, trans);
                    sql.Parameters.AddWithValue("cric", cric);
                    sql.Parameters.AddWithValue("annee", annee);
                    sql.Parameters.AddWithValue("role", r);
                    sql.Parameters.AddWithValue("name", n);
                    sql.Parameters.AddWithValue("nim", nim);
                    sql.ExecuteNonQuery();

                    ui = UserController.GetUserByName(Globals.GetPortalSettings().PortalId, em);
                    if (ui != null)
                    {

                        rc.AddUserRole(Globals.GetPortalSettings().PortalId, ui.UserID, uri.RoleID, Null.NullDate, Null.NullDate);
                       
                    }


                    if (r=="Président")
                    {
                        sql = new SqlCommand("delete from ais_rya where cric=@cric and rotary_year=@annee and [function]=@role", conn, trans);
                        sql.Parameters.AddWithValue("cric", cric);
                        sql.Parameters.AddWithValue("annee", annee-1);
                        sql.Parameters.AddWithValue("role", "Président élu");
                        sql.ExecuteNonQuery();

                        sql = new SqlCommand("insert into ais_rya (cric,rotary_year,[function],name,nim) values (@cric,@annee,@role,@name,@nim)", conn, trans);
                        sql.Parameters.AddWithValue("cric", cric);
                        sql.Parameters.AddWithValue("annee", annee-1);
                        sql.Parameters.AddWithValue("role", "Président élu");
                        sql.Parameters.AddWithValue("name", n);
                        sql.Parameters.AddWithValue("nim", nim);
                        sql.ExecuteNonQuery();

                    }

                    sb.Append(nim + " : " + n + Environment.NewLine);
                }
                else
                {
                    sbe.Append(row["nom"]+" ... introuvable" + Environment.NewLine);
                }

            }

                result_rapprochement.Text = "<code><pre>Membres en erreur : " +
                Environment.NewLine +
                sbe.ToString() +
                Environment.NewLine +
                Environment.NewLine +
                "Membres correctement rapprochés : " +
                Environment.NewLine +
                sb.ToString()+
                "</pre></code>";

            trans.Commit();

            panel_result.Visible = false;
            btn_rapprochement.Visible = false;


        }
        catch (Exception ee)
        {
            error.Visible = true;
            errorlabel.Text = ee.Message;
            Functions.Error(ee);
        }
        finally
        {
            conn.Close();
        }
    }
}