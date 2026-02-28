using DotNetNuke.Entities.Tabs;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Yemon.dnn;

public partial class Portals__default_Skins_Rodi2017_Controls_Meta : DotNetNuke.UI.Skins.Controls.Meta
{
    public static string[] lines;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        try
        {
            string seo = Request.QueryString["sn"];
            if (seo != null && seo != "")
            {
                AIS.Club club = AIS.DataMapping.GetClubBySeo(seo);
                if(club!=null)
                {
                    foreach(var c in Page.Header.Controls)
                    {
                        if(c is LiteralControl)
                        {
                            (c as LiteralControl).Text=club.headers;
                        }
                    }
                    
                }
              
            }
        }
        catch { }

        // if(!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Content))
        // {
        //    var metaTag = new HtmlMeta();
        //    metaTag.Name = Name;
        //    metaTag.Content = Content;
        //    Page.Header.Controls.Add(metaTag);
        // }
        if ((!string.IsNullOrEmpty(this.Name) || !string.IsNullOrEmpty(this.HttpEquiv)) && !string.IsNullOrEmpty(this.Content))
        {
            var metaTag = new HtmlMeta();

            if (!string.IsNullOrEmpty(this.HttpEquiv))
            {
                metaTag.HttpEquiv = this.HttpEquiv;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                metaTag.Name = this.Name;
            }

            metaTag.Content = this.Content;

            if (this.InsertFirst)
            {
                this.Page.Header.Controls.AddAt(0, metaTag);
            }
            else
            {
                this.Page.Header.Controls.Add(metaTag);
            }
        }
    }
}