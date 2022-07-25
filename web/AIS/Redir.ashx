<%@ WebHandler Language="C#" Class="Redir" %>

using System;
using System.Web;
using System.Data.SqlClient;

public class Redir : IHttpHandler {

    public void ProcessRequest (HttpContext context) {

        int id = 0;
        int.TryParse(""+context.Request.QueryString["id"],out id);
        string url = "" + context.Request.QueryString["url"];

        if (id != 0)
        {
            SqlConnection conn = new SqlConnection(DotNetNuke.Common.Utilities.Config.GetConnectionString());
            try
            {
                conn.Open();
                SqlCommand sql = new SqlCommand("UPDATE ais_newsletters_out SET [read]='O' WHERE id=@id", conn);
                sql.Parameters.AddWithValue("id", id);
                sql.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                conn.Close();
            }
        }
        //context.Response.Write(url);
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //context.Response.Clear();
        //context.Response.ClearContent();
        if(url.StartsWith(AIS.Const.DISTRICT_URL))
            context.Response.Redirect(url,true);
        else
        { 
            //context.Response.Redirect(url,true);
            //context.Response.End();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
            //context.Response.RedirectPermanent(url,true);
            string html = "<html>" +
                        "<head>" +
                        //"<meta http-equiv='refresh' content='0; url='" + url + "'/>" +
                        "</head>" +
                        "<body><script>window.location.assign('" + url + "')</script></body></html>";
            context.Response.Write(html);

        }
        context.Response.End();
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}