<%@ WebHandler Language="C#" Class="QR" %>

using System;
using System.Web;
using QRCoder;
using System.Drawing;
using System.IO;


public class QR : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        try
        {
            if (!string.IsNullOrEmpty(context.Request["s"]))
            {
                string s = ("" + context.Request["s"]);

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(s, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                   
                Bitmap qrCodeImage = qrCode.GetGraphic(10,System.Drawing.ColorTranslator.FromHtml("#00246C"),Color.White,true);

                MemoryStream ms = new MemoryStream();
                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                context.Response.Expires = -1;
                context.Response.ContentType = "image/png";
                context.Response.BinaryWrite(ms.ToArray());
                context.Response.Flush();


            }
        }
        catch { }
    }
    public void Dispose()
    { }
    public bool IsReusable {
        get {
            return false;
        }
    }


}