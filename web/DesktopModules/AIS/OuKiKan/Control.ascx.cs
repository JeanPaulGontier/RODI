using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yemon.dnn;
using AIS;
using System.Data.SqlClient;
using DotNetNuke.Framework;
using Functions = AIS.Functions;

public partial class DesktopModules_AIS_OuKiKan_Control : YemonPortalModuleBase
{
    public bool editable
    {
        get
        {
            return UserInfo.IsSuperUser ||
                   UserInfo.IsInRole(Const.ADMIN_ROLE) ||
                   UserInfo.IsInRole(Const.ROLE_ADMIN_CLUB) ||
                   UserInfo.IsInRole(Const.ROLE_ADMIN_DISTRICT) ||
                   AIS.DataMapping.isADG(AIS.Functions.GetCurrentMember().id);

        }
    }
    public int cric
    {
        get
        {
            return Functions.CurrentCric;

        }
    }


    public string mode
    {
        get
        {
            return "" + Settings["mode"];

        }
    }

    public string context
    {
        get
        {
            if (ContextGuid.Value != "")
            {

            }
            else
            {
                ContextGuid.Value = Guid.NewGuid().ToString();
                Application[ContextGuid.Value + ":mode"] = mode;
                Application[ContextGuid.Value + ":cric"] = Functions.CurrentCric;

            }
            return ContextGuid.Value;
        }
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ServicesFramework.Instance.RequestAjaxScriptSupport();
        ServicesFramework.Instance.RequestAjaxAntiForgerySupport();
    }

    public int currentcric
    {
        get
        {
            return AIS.Functions.CurrentCric;
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
      
        //if (Request.HttpMethod == "POST")
        //{
        //    if (Request.ContentType.StartsWith("application/json"))
        //    {
        //        var jsonString = String.Empty;
        //        Request.InputStream.Position = 0;
        //        using (var inputStream = new StreamReader(Request.InputStream))
        //            jsonString = inputStream.ReadToEnd();

        //        dynamic action = Yemon.dnn.Functions.Deserialize(jsonString, typeof(KeyValuePair<string, object>));
        //        if (action.Key == "setMeeting")
        //        {
        //            if(!editable)
        //            {
        //                this.ServeJSON(false);
        //            }   
        //            else
        //            { 
        //                Dictionary<string, object> row = DynToRow(action.Value);

        //                string meetingguid = ""+row["guid"];
                  
        //                this.ServeJSON(Yemon.dnn.Helpers.SetItem("meeting:"+meetingguid+":"+currentcric,row["meeting"],""+UserId, keephistory: false));
        //            }
        //        }
        //        else if (action.Key == "setUser")
        //        {
        //            Dictionary<string, object> row = DynToRow(action.Value);
        //            string meetingguid = "" + row["meetingguid"];
        //            string guid = "" + row["guid"];
        //            this.ServeJSON(Yemon.dnn.Helpers.SetItem("meetinguser:" + meetingguid + ":" + guid, row["user"], "" + UserId, keephistory: false));
        //        }

        //    }
        //}
        //else
        //{

        //    string action = "" + Request["action"];
        //    if (action == "hello")
        //    {
        //        this.ServeJSON("Hello World");
        //    }
        //    else if (action == "getMeetings")
        //    {
        //        if (!editable)
        //        {
        //            this.ServeJSON(false);
        //            return;
        //        }
        //        var meetings = Yemon.dnn.Helpers.GetItemsMetaByName("meeting:%:" + currentcric + "");
        //        this.ServeJSON(meetings);
        //    }
        //    else if (action == "getUsers")
        //    {
        //        var users = Yemon.dnn.Helpers.GetItemsMetaByPrefix("meetinguser:" + Request["guid"] + ":%");
        //        this.ServeJSON(users);
        //    }
        //    else if (action == "getNbUsers")
        //    {
        //        var users = Yemon.dnn.Helpers.GetItemsMetaByPrefix("meetinguser:" + Request["guid"] + ":%");
        //        if (users == null)
        //            this.ServeJSON(0);
        //        else
        //            this.ServeJSON(users.Rows.Count);
        //    }
        //    else if (action == "deleteUser")
        //    {
        //        if(!editable)
        //        {
        //            this.ServeJSON(false);
        //            return;
        //        }
        //        this.ServeJSON(Yemon.dnn.Helpers.DeleteItem("meetinguser:" + Request["meetingguid"] + ":" + Request["guid"]));
        //    }
        //}
    }
}