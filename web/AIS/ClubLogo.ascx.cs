using AIS;
using DotNetNuke.UI.Skins;
using System;
using System.Activities.Expressions;

public partial class AIS_ClubLogo : System.Web.UI.UserControl
{
    public string SkinPath
    {
        get{
            var skin = this.Parent as DotNetNuke.UI.Skins.Skin;
            return skin.SkinPath;
        }
    }
    public Club club
    {
        get; set; 
    }
    protected void Page_Load(object sender, EventArgs e)
    {
     
        try { 
            string seo = Request.QueryString["sn"];
            if (seo != null && seo != "")
            {
                club = DataMapping.GetClubBySeo(seo);              
            }
        }
        catch { }
    }
}