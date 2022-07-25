using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using AIS;
using DotNetNuke.Common.Utilities;

public partial class AIS_NewsFeedDistrict : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.ContentType = "text/xml";
            XmlTextWriter feedWriter = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);

            feedWriter.WriteStartDocument();

            // These are RSS Tags
            feedWriter.WriteStartElement("rss");
            feedWriter.WriteAttributeString("version", "2.0");

            feedWriter.WriteStartElement("channel");
            feedWriter.WriteElementString("title", "Nouvelles du Rotary district 1730");
            feedWriter.WriteElementString("link", "http://www.rotary1730.org/");
            feedWriter.WriteElementString("description", "Nouvelles du Rotary district 1730 (Var - Alpes-Maritimes - Monaco - Corse)");
            feedWriter.WriteElementString("copyright",
              "Copyright 2015 www.rotary1730.org. All rights reserved.");

            List<News> news = DataMapping.ListNews(category: "District", cric: 0, top: " TOP 20 ");
            if (news != null)
            {
                foreach (News post in news)
                {
                    feedWriter.WriteStartElement("item");
                    feedWriter.WriteElementString("title", RemoveIllegalCharacters(post.title));
                    feedWriter.WriteElementString("pubDate", string.Format("{0:r}", post.dt));
                    feedWriter.WriteElementString("description", RemoveIllegalCharacters(post.text));
                    feedWriter.WriteElementString("link", "http://www.rotary1730.org/LesNouvelles/District.aspx?cric=0&newsid=" + post.id);                    
                    feedWriter.WriteEndElement();
                }
            }

            // Close all open tags tags
            feedWriter.WriteEndElement();
            feedWriter.WriteEndElement();
            feedWriter.WriteEndDocument();
            feedWriter.Flush();
            feedWriter.Close();

            Response.End();
        }
        catch (Exception ee)
        {
            Functions.Error(ee);
        }
    }

    protected string RemoveIllegalCharacters(object input)
    {
        try
        {
            // cast the input to a string
            string data = "" + input.ToString();

            if (!string.IsNullOrEmpty(data))
            {
                // replace illegal characters in XML documents with their entity references
                data = data.Replace("&", "&amp;");
                data = data.Replace("\"", "&quot;");
                //data = data.Replace("'", "&apos;");
                data = data.Replace("<", "&lt;");
                data = data.Replace(">", "&gt;");
            }

            return data;
        }
        catch(Exception ee)
        {
            Functions.Error(ee);
            return "";
        }
    }
}