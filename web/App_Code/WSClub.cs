using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AIS;
using System.Data.SqlClient;
using DotNetNuke.Common.Utilities;
using System.Data;
using Newtonsoft.Json;

/// <summary>
/// Description résumée de WSClub
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]
public class WSClub : System.Web.Services.WebService
{

    public WSClub()
    {

        //Supprimez les marques de commentaire dans la ligne suivante si vous utilisez des composants conçus 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string GetBureau(int cric)
    {

        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        DataSet ds = new DataSet();
        try
        {
            conn.Open();
            
            SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "rya WHERE cric=@cric ORDER BY [function]", conn);
            sql.Parameters.AddWithValue("cric", cric);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ds, Formatting.Indented);
        return output;

    }

    [WebMethod]
    public string GetNews(int cric)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        DataSet ds = new DataSet();
        try
        {
            conn.Open();

            SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "news WHERE  cric=@cric AND category='Clubs' and dt>='"+DateTime.Now+"'", conn);
            sql.Parameters.AddWithValue("cric", cric);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ds, Formatting.Indented);
        return output;
    }

    [WebMethod]
    public string GetMembers(int cric)
    {
        SqlConnection conn = new SqlConnection(Config.GetConnectionString());
        DataSet ds = new DataSet();
        try
        {
            conn.Open();

            SqlCommand sql = new SqlCommand("SELECT * FROM " + Const.TABLE_PREFIX + "members WHERE cric=@cric", conn);
            sql.Parameters.AddWithValue("cric", cric);
            SqlDataAdapter da = new SqlDataAdapter(sql);
            da.Fill(ds);
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }

        string output = JsonConvert.SerializeObject(ds, Formatting.Indented);
        return output;
    }


}
