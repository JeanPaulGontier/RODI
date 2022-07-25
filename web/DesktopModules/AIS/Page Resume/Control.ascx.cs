using DotNetNuke.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesktopModules_AIS_Page_Resume_Control : PortalModuleBase
{
    public string titre = "";
    public string image = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = "" + Settings["url"];
        if(url!="")
        { 
            WebClient client = new WebClient();
            string content = Encoding.UTF8.GetString(client.DownloadData(url));
            
            int index = content.IndexOf("<title>");
            if( index>0)
            {
                titre = content.Substring(index+7);
                index = titre.IndexOf("</title>");
                if(index>0)
                {
                    titre = titre.Substring(0, index - 1);
                }
            }
            index = 0;
            index = content.IndexOf("<!--end skin menu-->");
            if(index>0)
            { 
                content = content.Substring(index);
                index = content.IndexOf("<img");
                if(index>0)
                {
                    content = content.Substring(index);
                    index = content.IndexOf("src");
                    if(index>0)
                    {
                        content = content.Substring(index + 5);
                        index = content.IndexOfAny(new char[] { '\'', '\"', '>' });
                        if(index>0)
                        {
                            image = "<img src='"+content.Substring(0, index - 1)+"'>";
                        }
                    }
                }
            }

        }
    }
}