using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AIS_MediaView : System.Web.UI.Page
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
                AIS.Functions.Error(new Exception("MediaView Media est null"));
            }

            Response.Buffer = true;
            Response.Expires = 0;
            Response.Cache.SetCacheability(HttpCacheability.Public);

            Response.AddHeader("content-length", "" + media.content.Length);
            Response.AddHeader("content-disposition", "inline; filename=" + media.name);
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
                AIS.Functions.Error(new Exception("MediaView Media est null"));
            }

            Response.Buffer = true;
            Response.Expires = 0;
            Response.Cache.SetCacheability(HttpCacheability.Public);

            Response.AddHeader("content-length", "" + media.content.Length);
            Response.AddHeader("content-disposition", "attachment; filename=" + media.name);
            Response.ContentType = media.content_type;
            Response.BinaryWrite(media.content);
            Response.Flush();
            Response.End();
        }
        else
        {
            AIS.Functions.Error(new Exception("MediaView id est null"));
        }
    }
}