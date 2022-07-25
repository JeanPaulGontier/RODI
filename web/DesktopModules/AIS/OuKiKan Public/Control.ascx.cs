using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yemon.dnn;

public partial class DesktopModules_AIS_OuKiKan_Control : YemonPortalModuleBase
{
    public string GUID
    {
        get
        {
            return "" + Request["guid"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        appJS.FilePath = this.AppJsPath;
        if (!("" + Request["CID"]).Equals("" + this.ModuleId))
            return;

        if (Request.HttpMethod == "POST")
        {
            if (Request.ContentType.StartsWith("application/json"))
            {
                var jsonString = String.Empty;
                Request.InputStream.Position = 0;
                using (var inputStream = new StreamReader(Request.InputStream))
                    jsonString = inputStream.ReadToEnd();

                dynamic action = Functions.Deserialize(jsonString, typeof(KeyValuePair<string, object>));
                if (action.Key == "setUser")
                {
                    Dictionary<string, object> row = DynToRow(action.Value);
                    string meetingguid = "" + row["meetingguid"];
                    string guid = "" + row["guid"];
                    this.ServeJSON(Yemon.dnn.Helpers.SetItem("meetinguser:" + meetingguid + ":" +guid, row["user"],""+UserId,keephistory:false));
                }

            }
        }
        else
        {

            string action = "" + Request["action"];
            if (action == "hello")
            {
                this.ServeJSON("Hello World");
            } 
            else if (action == "getMeeting")
            {
                var meeting = Yemon.dnn.Helpers.GetItemByPrefix("meeting:" + Request["guid"]+":%");
                this.ServeJSON(meeting);
            }
            else if (action == "getUsers")
            {
                var users = Yemon.dnn.Helpers.GetItemsMetaByPrefix("meetinguser:" + Request["guid"] + ":%");
                this.ServeJSON(users);
            }

        }
    }
}