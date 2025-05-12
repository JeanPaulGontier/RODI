<%@ WebHandler Language="C#" Class="Resizer" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Globalization;
using Yemon.dnn;
using Yemon.dnn.SIPro;
using AIS;

public class Resizer : IHttpHandler {

    public void ProcessRequest (HttpContext context) {

        try {

            Media media = (Media)context.Application[""+context.Request["guid"]];

            if(media!=null)
            {
                byte[] content = SIPro.GetProduction(0, media.content_id);
                context.Response.Clear();
                context.Response.Expires = 0;
                context.Response.Cache.SetCacheability(HttpCacheability.Public);

                context.Response.AddHeader("Content-Type", media.content_mime);
                context.Response.AddHeader("content-length", "" + content.Length);
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + media.filename );
                context.Response.ContentType = media.content_mime;
                context.Response.BinaryWrite(content);
                context.Response.Flush();

                context.Response.End();


                //context.Application["" + context.Request["guid"]] = null;
            }

        }
        catch(Exception ee)
        {
            AIS.Functions.Error(ee);
        }


    }


    public bool IsReusable {
        get {
            return false;
        }
    }

}