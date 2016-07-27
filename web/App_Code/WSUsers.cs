using AIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using DotNetNuke.Entities.Users;
using DotNetNuke.Entities.Portals;
using Newtonsoft.Json;
using System.Data;

/// <summary>
/// Description résumée de WSUsers
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]

public class WSUsers : System.Web.Services.WebService
{

    

    public WSUsers()
    {

        //Supprimez les marques de commentaire dans la ligne suivante si vous utilisez des composants conçus 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        Simple3Des s = new Simple3Des("fromage");
        return s.EncryptData("Hello World");
    }

    [WebMethod]
    public string GetUsers(int cric)
    {
        
        DataSet ds = new DataSet();
        ds.Tables.Add(new DataTable());
        ds.Tables[0].Columns.Add("login");
        ds.Tables[0].Columns.Add("password");
        ds.Tables[0].Columns.Add("memberId");
        ds.Tables[0].Columns.Add("UserInfo");
        List<Member> members = DataMapping.ListMembers(cric);
        foreach (Member m in members)
        {
            UserInfo user = UserController.GetUserById(PortalController.GetCurrentPortalSettings().PortalId, m.userid);
            if (user != null && !user.IsSuperUser)
            {
                string pass = UserController.GetPassword(ref user, user.Membership.PasswordAnswer);
                string login = user.Membership.Username;

                ds.Tables[0].Rows.Add(login, pass, m.id, Functions.Serialize(user));
            }
        }
        Simple3Des s = new Simple3Des("WSUsers");
        string output = s.EncryptData(JsonConvert.SerializeObject(ds, Formatting.Indented));

        return output;



    }
    

    

    
}
