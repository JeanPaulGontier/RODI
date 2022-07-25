<%@ WebHandler Language="C#" Class="DeleteFileHandler" %>

using System;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;

public class DeleteFileHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context)
    {
        try
        {
            //deserialize the object
            FilesManagerCore objUser = Deserialize<FilesManagerCore>(context);

            //now we print out the value, we check if it is null or not
            if (objUser != null)
            {
                if (objUser.id == 0 && !string.IsNullOrEmpty(objUser.urlLink))
                {
                    string Serverpath = HttpContext.Current.Server.MapPath("~/" + objUser.urlLink);

                    if (File.Exists(Serverpath))
                    {
                        File.Delete(Serverpath);
                        context.Response.Write("Fichier supprimé!");
                    }
                }
            }
        }
        catch (Exception ee)
        {
            context.Response.Write(ee.Message);
        }
    }

        /// <summary>
    /// This function will take httpcontext object and will read the input stream
    /// It will use the built in JavascriptSerializer framework to deserialize object based given T object type value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="context"></param>
    /// <returns></returns>
    public static T Deserialize<T>(HttpContext context)
    {
        //read the json string
        string jsonData = new StreamReader(context.Request.InputStream).ReadToEnd();

        //cast to specified objectType
        var obj = (T)new JavaScriptSerializer().Deserialize<T>(jsonData);

        //return the object
        return obj;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}