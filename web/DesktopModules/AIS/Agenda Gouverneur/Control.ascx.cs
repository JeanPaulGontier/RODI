using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yemon.dnn;
public partial class DesktopModules_AIS_Agenda_Gouverneur_Control : YemonPortalModuleBase
{
    public int CalendarNum {
        get
        {
            int num = 0;
            int.TryParse("" + Settings["num"], out num);
            return num;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        appJS.FilePath = AppJsPath ;      

        if ("" + Request["CID"] != "" + this.ModuleId)
            return;

        string action = "" + Request["action"];
        if(action== "getAgenda")
        {
            string username = "" + Settings["username"];
            string password = "" + Settings["password"];
            string host ="" + Settings["host"];

            var input_vars = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                username = username,
                password = password
            });
            if((username+password).Trim()=="")
            {
                return;
            }

            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("content-type", "application/json");//set your header here, you can add multiple headers
            string s = Encoding.UTF8.GetString(client.UploadData(Settings["host"] + "/api/v1/auth/authenticate-user", "POST", Encoding.UTF8.GetBytes(input_vars)));
            JObject o = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(s);
            string token = o.GetValue("accessToken").ToString();

            if (token != "")
            {

                client = new System.Net.WebClient();
                client.Headers.Add("content-type", "application/json");
                client.Headers.Add("Authorization", "Bearer " + token);

                // get calendars sources
                client.Encoding = Encoding.UTF8;
                s = client.DownloadString(Settings["host"] + "/api/v1/calendars/sources");
               
                o = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(s);
                var calendars = o.GetValue("calendars");
                
                if (calendars.Count<JToken>() > 0)
                {
                    string user = calendars[CalendarNum]["owner"].ToString();
                    string calendarid = calendars[CalendarNum]["id"].ToString();
                    string startdate = DateTime.Now.AddDays(-1).ToUniversalTime().ToString("yyyy-MM-ddThh:mm:ss");
                    s = client.DownloadString(Settings["host"] + "/api/v1/calendars/events/" + user + "/" + calendarid + "?startDate=" + startdate);
                   
                    o = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(s);
                    List<Event> events = new List<Event>();
                    foreach (var evt in o.GetValue("events").ToArray<JToken>())
                    {
                        string title = Functions.ToTitleCase("" + evt["title"]);
                        if ((bool)evt["isPrivate"])
                            title = "Non disponible";
                        string type = "rdv";
                        JToken startWith = (JToken)evt["startWithTZ"];
                        DateTime dt = DateTime.Parse(""+startWith["dt"]).ToLocalTime();
                        if(dt>DateTime.Now.AddDays(-1))
                        {
                            JToken endWith = (JToken)evt["endWithTZ"];
                            DateTime dtfin = DateTime.Parse("" + endWith["dt"]).ToLocalTime();

                            string dtFmt = dt.ToString("ddd") + " " + dt.ToString("dd MMM yyyy");
                            string hr = dt.ToString("HH:mm") + " - " + dtfin.ToString("HH:mm");
                            if ((bool)evt["allDay"])
                            {
                                hr = "Toute la journée";
                                type = "journee";
                            }
                            TimeSpan diff = dtfin - dt;
                            if (diff.TotalDays > 1)
                            {
                                dtFmt = dt.ToString("dd MMM yyyy") + " - " + dtfin.ToString("dd MMM yyyy");
                                hr = "Plusieurs jours";
                                type = "periode";
                            }

                            events.Add(new Event { type = type, title = title, dt = dtFmt, date = dt, datefin = dtfin, hr = hr });

                        }
                    }
                    events = events.OrderBy(x => x.date).ToList();
                    ServeJSON(events);
                }
                else
                {
                    ServeJSON("L'agenda est vide", true);
                }
            } else {
                ServeJSON("Une erreur d'autentification est survenue",true);
            }
        }
        
    }


    class Event
    {
        public string type { get; set; }
        public string title { get; set; }
        public string dt { get; set; }
        public string hr { get; set; }
        public DateTime date { get; set; }
        public DateTime datefin { get; set; }
    }
}