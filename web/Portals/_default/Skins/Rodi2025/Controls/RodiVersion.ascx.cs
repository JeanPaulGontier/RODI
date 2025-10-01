using Aspose.Pdf.Generator;
using Lucene.Net.Util;
using System;
using System.Net;

public partial class AIS_RodiVersion : System.Web.UI.UserControl
{
    public string Version
    {
        get
        {
            string version = "" + Application["RODI:Version"];
            if (version == "")
            {
                try
                {
                    WebClient webClient = new WebClient();
                    string txt = webClient.DownloadString(new Uri("https://raw.githubusercontent.com/JeanPaulGontier/RODI/main/UPDATE.md"));
                    int i = txt.IndexOf("###### ", 10);
                    if (i > 0)
                    {

                        txt = txt.Substring(i + 7, 10);
                        string[] p = txt.Split(new char[] { '/' });
                        version = p[2] + "." + p[1] + p[0];
                        Application["RODI:Version"] = version;
                    }


                }
                catch (Exception ex)
                {
                    AIS.Functions.Error(ex);
                }

            }
            return version;
        }
    }
}