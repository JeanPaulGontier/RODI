using AIS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de NewsHelper
/// </summary>
public class NewsHelper
{
   public News GetNewsByLink(string link)
   {
        SqlCommand sql = new SqlCommand("SELECT TOP 1 id,cric,dt,category,tag1,tag2,visible FROM "+Const.TABLE_PREFIX+"news WHERE id LIKE @link");
        sql.Parameters.AddWithValue("link","%"+ link +"%");
        DataTable table = Yemon.dnn.DataMapping.ExecSql(sql);
        AIS.News news = null;
        if (table != null && table.Rows.Count>0)
        {
            DataRow row = table.Rows[0];
            news = new AIS.News();
            news.id = "" + row["id"];
            news.cric = (int)row["cric"];
            news.dt = (DateTime)row["dt"];
            news.category = "" + row["category"];
            news.tag1 = "" + row["tag1"];
            news.tag2 = "" + row["tag2"];
            news.visible = "" + row["visible"];

        }
        return news; 
   }

}