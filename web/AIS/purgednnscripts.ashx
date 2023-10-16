<%@ WebHandler Language="C#" Class="PurgeDNNScripts" %>

using System;
using System.Web;
using System.Net.Http;
using System.Text;

public class PurgeDNNScripts : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string host = Yemon.dnn.Functions.GetHostUrl(context.Request);
        string url = ("" + context.Request["url"]).ToLower().Replace("purgednnscripts","pds");
        context.Response.ContentType = "text/html";
        string body="";
        try
        {
            var client = new HttpClient();

            var r = client.GetAsync(host+url);

            body=""+ r.Result.Content.ReadAsStringAsync().Result;
            body = Yemon.dnn.Functions.PurgeTag(body, "<meta id=\"MetaRobots\"", "/>");
            body = Yemon.dnn.Functions.PurgeTag(body, "<!--", "-->");
            body = Yemon.dnn.Functions.PurgeTag(body, "<link href=\"", "/>");
            body = Yemon.dnn.Functions.PurgeTag(body,"<input","/>");
            body = Yemon.dnn.Functions.PurgeTag(body,"<form",">");
            body = body.Replace("</form>","");
            body = Yemon.dnn.Functions.PurgeTag(body,"<script","</script>");
            
            context.Response.Write(body);
        }
        catch(Exception ee)
        {
            Yemon.dnn.Functions.Error(ee);
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

    

}