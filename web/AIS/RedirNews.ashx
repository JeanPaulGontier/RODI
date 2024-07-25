<%@ WebHandler Language="C#" Class="RedirNews" %>

using System;
using System.Web;

public class RedirNews : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string link = "" + context.Request.QueryString["n"];
        if (link != "" && link.Length==9)
        {
            NewsHelper newsHelper = new NewsHelper();
            AIS.News news = newsHelper.GetNewsByLink(link);
            if(news!=null)
            {
                string url = "";

                if(news.cric>0)
                {
                    url = AIS.Const.DISTRICT_URL + AIS.Const.CLUB_NEWS_URL_PREFIX + news.id;

                }
                else
                {
                    url = AIS.Const.DISTRICT_URL + AIS.Const.DISTRICT_NEWS_URL_PREFIX + news.id;
                }
                context.Response.Redirect(url);
                return;
            }

        }


        context.Response.StatusCode = 404;

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}