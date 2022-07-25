using DotNetNuke.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yemon.dnn;

public partial class DesktopModules_AIS_Impersonate_Control : Yemon.dnn.YemonPortalModuleBase
{
    UserInfo ui = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
            BT_Impersonate.Enabled = false;
            LI_Users.Visible = false;
        }
    }

    protected void BT_Impersonate_Click(object sender, EventArgs e)
    {
        if (LI_Users.SelectedIndex > -1)
        {
            ui = UserController.GetUserByEmail(PortalId, LI_Users.SelectedValue);
            if(ui!=null)
            { 
                UserController.UserLogin(PortalId, ui, Request.ServerVariables["SERVER_NAME"], this.Request.UserHostAddress, true);
                Response.Redirect("/");
            }
        }
    }

    protected void TXT_Username_TextChanged(object sender, EventArgs e)
    {
        SqlCommand sql = new SqlCommand("SELECT email FROM  Users WHERE (Username LIKE @username OR [DisplayName] LIKE @username)  AND [IsSuperUser]=0 AND [IsDeleted]=0 ");
        sql.Parameters.AddWithValue("username", "%" + TXT_Username.Text.Trim() + "%");
        DataTable users = DataMapping.ExecSql(sql);
        LI_Users.Items.Clear();
        if(users.Rows.Count>0)
        {
            foreach(DataRow row in users.Rows)
            {
                LI_Users.Items.Add(""+row["email"]);
            }
        }
        LI_Users.Visible = LI_Users.Items.Count > 0;
        
    }

    protected void LI_Users_SelectedIndexChanged(object sender, EventArgs e)
    {
        BT_Impersonate.Enabled = false;
        if(LI_Users.SelectedIndex>-1)
        { 
            ui = UserController.GetUserByEmail(PortalId, LI_Users.SelectedValue);

            BT_Impersonate.Enabled = ui != null;
        }
    }
}