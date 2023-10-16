using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Portals__default_Skins_Rodi2017_Mobile : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected override void Render(HtmlTextWriter writer)
    {
        //base.Render(writer);
        string content = string.Empty;

        using (var stringWriter = new StringWriter())
        using (var htmlWriter = new HtmlTextWriter(stringWriter))
        {
            // render the current page content to our temp writer
            base.Render(htmlWriter);
            htmlWriter.Close();

            // get the content
            content = stringWriter.ToString();
        }

        // replace our placeholders
        string newContent = content.Replace("cookieconsent", "nope");

        // write the new html to the page
        writer.Write(newContent);
    }

}