
#region Copyrights

// RODI - http://rodi.aisdev.net
// Copyright (c) 2012-2016
// by SAS AIS : http://www.aisdev.net
// supervised by : Jean-Paul GONTIER (Rotary Club Sophia Antipolis - District 1730)
//
//GNU LESSER GENERAL PUBLIC LICENSE
//Version 3, 29 June 2007 Copyright (C) 2007
//Free Software Foundation, Inc. <http://fsf.org/> Everyone is permitted to copy and distribute verbatim copies of this license document, but changing it is not allowed.
//This version of the GNU Lesser General Public License incorporates the terms and conditions of version 3 of the GNU General Public License, supplemented by the additional permissions listed below.

//0. Additional Definitions.

//As used herein, "this License" refers to version 3 of the GNU Lesser General Public License, and the "GNU GPL" refers to version 3 of the GNU General Public License.
//"The Library" refers to a covered work governed by this License, other than an Application or a Combined Work as defined below.
//An "Application" is any work that makes use of an interface provided by the Library, but which is not otherwise based on the Library.Defining a subclass of a class defined by the Library is deemed a mode of using an interface provided by the Library.
//A "Combined Work" is a work produced by combining or linking an Application with the Library. The particular version of the Library with which the Combined Work was made is also called the "Linked Version".
//The "Minimal Corresponding Source" for a Combined Work means the Corresponding Source for the Combined Work, excluding any source code for portions of the Combined Work that, considered in isolation, are based on the Application, and not on the Linked Version.
//The "Corresponding Application Code" for a Combined Work means the object code and/or source code for the Application, including any data and utility programs needed for reproducing the Combined Work from the Application, but excluding the System Libraries of the Combined Work.

//1. Exception to Section 3 of the GNU GPL.

//You may convey a covered work under sections 3 and 4 of this License without being bound by section 3 of the GNU GPL.

//2. Conveying Modified Versions.

//If you modify a copy of the Library, and, in your modifications, a facility refers to a function or data to be supplied by an Application that uses the facility (other than as an argument passed when the facility is invoked), then you may convey a copy of the modified version:
//a) under this License, provided that you make a good faith effort to ensure that, in the event an Application does not supply the function or data, the facility still operates, and performs whatever part of its purpose remains meaningful, or
//b) under the GNU GPL, with none of the additional permissions of this License applicable to that copy.

//3. Object Code Incorporating Material from Library Header Files.

//The object code form of an Application may incorporate material from a header file that is part of the Library. You may convey such object code under terms of your choice, provided that, if the incorporated material is not limited to numerical parameters, data structure layouts and accessors, or small macros, inline functions and templates(ten or fewer lines in length), you do both of the following:
//a) Give prominent notice with each copy of the object code that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the object code with a copy of the GNU GPL and this license document.

//4. Combined Works.

//You may convey a Combined Work under terms of your choice that, taken together, effectively do not restrict modification of the portions of the Library contained in the Combined Work and reverse engineering for debugging such modifications, if you also do each of the following:
//a) Give prominent notice with each copy of the Combined Work that the Library is used in it and that the Library and its use are covered by this License.
//b) Accompany the Combined Work with a copy of the GNU GPL and this license document.
//c) For a Combined Work that displays copyright notices during execution, include the copyright notice for the Library among these notices, as well as a reference directing the user to the copies of the GNU GPL and this license document.
//d) Do one of the following:
//0) Convey the Minimal Corresponding Source under the terms of this License, and the Corresponding Application Code in a form suitable for, and under terms that permit, the user to recombine or relink the Application with a modified version of the Linked Version to produce a modified Combined Work, in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.
//1) Use a suitable shared library mechanism for linking with the Library. A suitable mechanism is one that (a) uses at run time a copy of the Library already present on the user's computer system, and (b) will operate properly with a modified version of the Library that is interface-compatible with the Linked Version.
//e) Provide Installation Information, but only if you would otherwise be required to provide such information under section 6 of the GNU GPL, and only to the extent that such information is necessary to install and execute a modified version of the Combined Work produced by recombining or relinking the Application with a modified version of the Linked Version. (If you use option 4d0, the Installation Information must accompany the Minimal Corresponding Source and Corresponding Application Code. If you use option 4d1, you must provide the Installation Information in the manner specified by section 6 of the GNU GPL for conveying Corresponding Source.)

//5. Combined Libraries.

//You may place library facilities that are a work based on the Library side by side in a single library together with other library facilities that are not Applications and are not covered by this License, and convey such a combined library under terms of your choice, if you do both of the following:
//a) Accompany the combined library with a copy of the same work based on the Library, uncombined with any other library facilities, conveyed under the terms of this License.
//b) Give prominent notice with the combined library that part of it is a work based on the Library, and explaining where to find the accompanying uncombined form of the same work.

//6. Revised Versions of the GNU Lesser General Public License.

//The Free Software Foundation may publish revised and/or new versions of the GNU Lesser General Public License from time to time. Such new versions will be similar in spirit to the present version, but may differ in detail to address new problems or concerns.
//Each version is given a distinguishing version number. If the Library as you received it specifies that a certain numbered version of the GNU Lesser General Public License "or any later version" applies to it, you have the option of following the terms and conditions either of that published version or of any later version published by the Free Software Foundation. If the Library as you received it does not specify a version number of the GNU Lesser General Public License, you may choose any version of the GNU Lesser General Public License ever published by the Free Software Foundation.
//If the Library as you received it specifies that a proxy can decide whether future versions of the GNU Lesser General Public License shall apply, that proxy's public statement of acceptance of any version is permanent authorization for you to choose that version for the Library.

#endregion Copyrights


using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;
using Telerik.Web.UI;
using System.Drawing;
using System.IO;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Membership;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using Aspose.Cells;
using System.Data.SqlClient;
using DotNetNuke.Common.Utilities;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;

public partial class DesktopModules_AIS_Admin_Import_Rotarien_Import_Rotarien : PortalModuleBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        panel.Visible = UserInfo.IsSuperUser || UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT);
       
    }

    protected void BT_Upload_Click(object sender, EventArgs e)
    {
        if (FU_RI.UploadedFiles.Count > 0)
        {

            UploadedFile file = FU_RI.UploadedFiles[0];

            file.SaveAs(Server.MapPath(PortalSettings.HomeDirectory + "import_membre_lerotarien.xls"), true);

            Import_Fichier();

            dvFileUpload.Visible = false;
        }
    }

    void Import_Fichier()
    {
        Aspose.Cells.License licenseCells = new Aspose.Cells.License();
        //licenseCells.SetLicense("Aspose.Total.lic");

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        SqlTransaction trans = null;
        SqlCommand sql = null;

        try
        {

            Workbook xls = new Workbook(Server.MapPath(PortalSettings.HomeDirectory + "import_membre_lerotarien.xls"));

            conn.Open();
            trans = conn.BeginTransaction();

            sql = new SqlCommand("DELETE FROM ais_lerotarien_import", conn, trans);
            sql.ExecuteNonQuery();


            Worksheet sheet = xls.Worksheets[0];
            int col = 0;
            int row = 1;
            
            while (row < 65535)
            {
                int numero_district = 0;
                int.TryParse(""+sheet.Cells[row, col].Value,out numero_district);
                if (numero_district == 0)
                    break;
                string nom_club =           "" + sheet.Cells[row, col+1].Value;
                string nom =                "" + sheet.Cells[row, col+2].Value;
                string prenom =             "" + sheet.Cells[row, col+3].Value;
                string adresse =            "" + sheet.Cells[row, col+4].Value;
                string complement1 =        "" + sheet.Cells[row, col+5].Value;
                string complement2 =        "" + sheet.Cells[row, col+6].Value;
                string codepostal =         "" + sheet.Cells[row, col+7].Value;
                string localite =           "" + sheet.Cells[row, col+8].Value;
                string email =              "" + sheet.Cells[row, col+9].Value;
                string activite =           "" + sheet.Cells[row, col+10].Value;
                string metier =             "" + sheet.Cells[row, col+11].Value;
                string fonctiondansleclub = "" + sheet.Cells[row, col+12].Value;

              

                sql = new SqlCommand("INSERT INTO ais_lerotarien_import (numero_district,nom_club,nom,prenom,adresse,complement1,complement2,codepostal,localite,email,activite,metier,fonctiondansleclub) VALUES (@numero_district,@nom_club,@nom,@prenom,@adresse,@complement1,@complement2,@codepostal,@localite,@email,@activite,@metier,@fonctiondansleclub)", conn, trans);
                sql.Parameters.AddWithValue("numero_district", numero_district);
                sql.Parameters.AddWithValue("nom_club", nom_club);
                sql.Parameters.AddWithValue("nom", nom);
                sql.Parameters.AddWithValue("prenom", prenom);
                sql.Parameters.AddWithValue("adresse", adresse);
                sql.Parameters.AddWithValue("complement1", complement1);
                sql.Parameters.AddWithValue("complement2", complement2);
                sql.Parameters.AddWithValue("codepostal", codepostal.Replace("'",""));
                sql.Parameters.AddWithValue("localite", localite);
                sql.Parameters.AddWithValue("email", email);
                sql.Parameters.AddWithValue("activite", activite);
                sql.Parameters.AddWithValue("metier", metier);
                sql.Parameters.AddWithValue("fonctiondansleclub", fonctiondansleclub);
                
                sql.ExecuteNonQuery();
               
                row++;
            }
            trans.Commit();

            sql = new SqlCommand("SELECT * FROM ais_lerotarien_import", conn);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            members.DataSource = ds.Tables[0];
            members.DataBind();

            lbl_result.Text = ds.Tables[0].Rows.Count + " membres mis à jour";
            panel_result.Visible = true;


            btn_rapprochement.Visible = true;
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

            List<Member> membres = DataMapping.ListMembers(0, "", "", "", 0, 10000, false, false);


            conn.Open();

            sql = new SqlCommand("SELECT * FROM ais_lerotarien_import", conn);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            da.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string nom_club = "" + row["nom_club"];
                string nom = "" + row["nom"];
                string prenom = "" + row["prenom"];
                string adresse = "" + row["adresse"];
                string complement1 = "" + row["complement1"];
                string complement2 = "" + row["complement2"];
                string codepostal = "" + row["codepostal"];
                string localite = "" + row["localite"];
                string email = "" + row["email"];
                string activite = "" + row["activite"];
                string metier = "" + row["metier"];
                string fonctiondansleclub = "" + row["fonctiondansleclub"];

                bool notfound = true;


                foreach (Member m in membres)
                {
                    if (nom.Equals(m.surname) && fctFormatString(prenom)==fctFormatString(m.name))
                    {
                        m.adress_1 = adresse;
                        m.adress_2 = complement1;
                        m.adress_3 = complement2;
                        m.zip_code = codepostal;
                        m.town = localite;
                        m.email = email;
                        m.fonction_rotarienne = fonctiondansleclub;
                        m.base_dtupdate = DateTime.Now;
                        DataMapping.UpdateMember(m);
                        notfound = false;
                    }
                    if (!notfound)
                        break;

                }
                if (notfound)
                {
                    result += nom + " " + prenom + " ... introuvable<br/>";
                }

            }
            if (result.Equals(""))
                result_rapprochement.Text = "Il n'y a rien à rapprocher";
            else
                result_rapprochement.Text = result;

        }
        catch (Exception ee)
        {

            Functions.Error(ee);
        }
        finally
        {
            conn.Close();
        }


    }

    public static string fctFormatString(string text)
    {
        // Récupération de la chaine de caractère originale et passage en minuscule
        StringBuilder newText = new StringBuilder(text.ToLower());

        // Gestion des "accents"
        // -> déclaration de variables de conversion "accents"
        string accent = "àáâãäåòóôõöøèéêëìíîïùúûüÿñç";
        string sansAccent = "aaaaaaooooooeeeeiiiiuuuuync";
        // -> conversion des chaines en tableaux de caractères
        char[] tabAccent = accent.ToCharArray();
        char[] tabSansAccent = sansAccent.ToCharArray();
        // -> pour chaque accent, remplacement
        for (int i = 0; i < accent.Length; i++)
        {
            newText.Replace(tabAccent[i].ToString(), tabSansAccent[i].ToString());
        }

        // Gestion des "caractères spéciaux"
        // -> déclaration de la variable de conversion "caractères spéciaux"
        string carSpeciaux = "&$*@^#- _";
        // -> conversion des chaines en tableaux de caractères
        char[] tabCarSpeciaux = carSpeciaux.ToCharArray();
        // -> pour chaque caractère spécial, remplacement
        for (int i = 0; i < carSpeciaux.Length; i++)
        {
            newText.Replace(tabCarSpeciaux[i].ToString(), "");
        }

        // Gestion des "æ" et "œ"
        newText.Replace("æ", "ae");
        newText.Replace("œ", "oe");

        return newText.ToString();
    }
}