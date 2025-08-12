using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AIS;

public partial class AIS_Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = "" + Request.QueryString["id"];
        if (Session[id] != null)
        {
            AIS.Media media = Session[id] as AIS.Media;
            if (media != null)
            {
            }
            else
            {
                AIS.Functions.Error(new Exception("Download media est null"));
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Expires = 0;
            Response.Cache.SetCacheability(HttpCacheability.Public);

            Response.AddHeader("content-length", "" + media.content.Length);
            Response.AddHeader("content-disposition", "attachment; filename=\"" + Functions.ClearFileName(media.name)+"\"");
            Response.ContentType = media.content_type;
            Response.BinaryWrite(media.content);
            Response.Flush();
            Response.End();
        }
        else if (Application[id] != null)
        {
            AIS.Media media = Application[id] as AIS.Media;
            if (media != null)
            {
            }
            else
            {
                AIS.Functions.Error(new Exception("Download media est null"));
            }
            //Response.Clear();
            //Response.Buffer = true;
            Response.Expires = 0;
            Response.Cache.SetCacheability(HttpCacheability.Public);

            Response.AddHeader("content-length", "" + media.content.Length);
            Response.AddHeader("content-disposition", "attachment; filename=\"" + Functions.ClearFileName(media.name)+"\"");
            Response.ContentType = media.content_type;
            Response.BinaryWrite(media.content);
            //Response.Flush();
            Response.End();
        }
        else
        {
            
            AIS.Functions.Error(new Exception("Download id est null"));
        }
    }
}