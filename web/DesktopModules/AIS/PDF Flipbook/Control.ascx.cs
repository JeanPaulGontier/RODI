using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Words;
using System.Drawing;
using DotNetNuke.Modules.UserDefinedTable.DataTypes;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;
using System.Web.Http.Validation;
using AIS;

public partial class DesktopModules_AIS_PDF_Slideshow_Control : PortalModuleBase
{
    public const string O2SPDFVIEWERSERIALNUMBER = "PDFVW4WIN-JI2QB-2JRGK-MFJ68-3DWN8-AKSVB";

    public List<Media> Images
    {
        get {


            List<Media> images = new List<Media>();
            var imgs = Directory.GetFiles(ImagesPath, "*.jpg");
            for (int i=0;i<imgs.Length;i++)
            {
                Media media = new Media();
                media.content_mime = "image/jpeg";
                media.filename = i+ ".jpg";
                media.dt = DateTime.Now;
                images.Add(media);
            }
            return images;

        }
    }

    public string ImagesPublic
    {
        get
        {
            return "/portals/"+PortalId+"/images/pdf-flipbook/"+ModuleId+"/";
        }
    }
    public string ImagesPath
    {
        get
        {
            string p = Server.MapPath(ImagesPublic);
            if(!Directory.Exists(p))
                Directory.CreateDirectory(p);

            return p;
        }
    }

    public int Width
    {
        get
        {
            int w = 0;
            int.TryParse("" + Settings["width"], out w);
            return w;
        }
    }
    
    public int Height
    {
        get {
            int h = 0;
            int.TryParse("" + Settings["height"], out h);
            return h;
        }
    }

    public string document
    {
        get
        {
            return "" + Settings["document"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        P_images.Visible=false;
        P_flipbook.Visible=true;

        if ((""+Settings["type"])=="images")
        {
            P_images.Visible=true;
            P_flipbook.Visible=false;
        }

        if (!String.IsNullOrEmpty(Request["image"]))
        {
            int idx = 0;
            if (int.TryParse("" + Request["image"],out idx))
            {                
                Response.Redirect(ImagesPublic+idx+".jpg");
            }
            return;
        }

    }


    public void ServeMedia(Media media)
    {

        Response.AddHeader("Content-Type", media.content_mime);
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + media.filename);
        Response.Clear();
        Response.ContentType = media.content_type;
        Response.BinaryWrite(media.content);
        Response.End();
    }
}