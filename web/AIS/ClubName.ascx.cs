using AIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AIS_ClubName : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try { 
            string seo = Request.QueryString["sn"];
            if (seo != null && seo != "")
            {
                Club club = DataMapping.GetClubBySeo(seo);
                L_Txt.Text = club.club_type.ToUpper() + " CLUB<br/>"+ club.name;
            }
        }
        catch { }
    }
}