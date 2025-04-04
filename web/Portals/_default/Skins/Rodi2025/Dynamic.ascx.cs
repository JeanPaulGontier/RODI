using EasyDNN.Modules.EasyDNNGallery;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class Portals__default_Skins_Rodi2025_Dynamic : DotNetNuke.UI.Skins.Skin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected override void OnInit(EventArgs e)
    {


        //  var section = this.FindControl("Section1");
        for(int i=0;i<10;i++)
        {
            Panel p = new Panel();
           
            var div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            div.ID = "polo"+i;
            div.InnerText = "";
            
            //p.Controls.Add(div);

            //div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            //div.ID = "polod" + i;
            //div.InnerText = "";
            //p.Controls.Add(div);


            this.Controls.Add(div);

        }


        base.OnInit(e);



    }
}