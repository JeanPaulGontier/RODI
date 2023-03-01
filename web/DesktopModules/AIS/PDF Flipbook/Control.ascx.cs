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
        get { return (List<Media>)Application["AIS_PDF_Slideshow_Images_" + ModuleId]; }
        set { Application["AIS_PDF_Slideshow_Images_" + ModuleId] = value; }
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
        if (!String.IsNullOrEmpty(Request["image"]))
        {
            int idx = 0;
            if (int.TryParse("" + Request["image"],out idx))
            {
                if(Images!=null)
                {
                    try
                    {
                        ServeMedia(Images[idx]);
                    }
                    catch(Exception ee)
                    {
                        Functions.Error(ee);
                    }
                }
            }
            return;
        }



        if (Images == null && !string.IsNullOrEmpty(document))
        {
            try
            {
               
                List<Media> images = new List<Media>();
                var doc = O2S.Components.PDFRender4NET.PDFFile.Open(Server.MapPath(document));
                doc.SerialNumber = O2SPDFVIEWERSERIALNUMBER;
                for (int page = 0; page < doc.PageCount; page++)
                {
                    Bitmap bit = doc.GetPageImage(page, 76);
                    Bitmap bitmap = new Bitmap(Width, Height);
                    //Bitmap bitmap = new Bitmap((int)doc.GetPageSize(page).Width,(int)doc.GetPageSize(page).Height);
                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                          graphics.Clear(Color.White);
                          graphics.DrawImage(bit,0,0,Width,Height);
                    }



                    Media media = new Media();
                    MemoryStream ms = new MemoryStream();
                    bitmap.Save(ms, ImageFormat.Jpeg);
                    media.content = ms.GetBuffer();
                    media.content_size = media.content.Length;
                    media.content_mime = "image/jpeg";
                    media.filename = "image" + page + ".jpg";
                    media.w = Width;
                    media.h = Height;
                    media.dt = DateTime.Now;
                    images.Add(media);
                }

                Images = images;
            }
            catch(Exception ee)
            {
                L_Error.Text=ee.Message;
                P_Error.Visible = true;
                Functions.Error(ee);
            }


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