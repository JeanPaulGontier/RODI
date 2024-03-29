using AIS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Dnn.PersonaBar.Pages.Services.Dto;
using Stripe;
using System.Web.Helpers;
using DotNetNuke.Common.Utilities;
using Newtonsoft.Json;

/// <summary>
/// Description résumée de RotaryMagHelper
/// </summary>
public class RotaryMagHelper
{
    private static RotaryMag.Parametres _param;

    public static RotaryMag.Parametres GetParametres() {
        var item = Yemon.dnn.Helpers.GetItem("RotaryMagParametres", 0);
        if (item == null) return null;
        return Yemon.dnn.Functions.Deserialize<RotaryMag.Parametres>("" + item); ;
    }

    //private const string JWT_URL_LOGIN = "https://rodi1730.aisdev.net/desktopmodules/jwtauth/api/mobile/login";
    //private const string JWT_URL_EXTENDTOKEN = "https://rodi1730.aisdev.net/desktopmodules/jwtauth/api/mobile/extendtoken";
    //private const string URL_MEMBRES = "https://rodi1730.aisdev.net/desktopmodules/ais/api/rotarymag/membres";


    private static JWTToken JWT_TOKEN
    {
        get
        {
            var item = Yemon.dnn.Helpers.GetItem("RotaryMagJwtToken", 0);
            if (item == null)
                return null;
            return Yemon.dnn.Functions.Deserialize<JWTToken>("" + item); ;

        }
        set
        {
            Yemon.dnn.Helpers.SetItem("RotaryMagJwtToken", Yemon.dnn.Functions.Serialize(value),"", keephistory: false);
        }
    }

    public class JWTToken
    {
        public int userId { get; set; }
        public string displayName { get; set; }
        public string accessToken { get; set; }
        public string renewalToken { get; set; }
    }

    public RotaryMagHelper()
    {
        //
        // TODO: ajoutez ici la logique du constructeur
        //
    }


    public static string Synchro()
    {
        _param = GetParametres();
        if (_param == null)
            return "Erreur de récupération des paramètres";

        if(JWT_TOKEN == null)
        {
            var task = Task.Run(() => CallAsyncLogin());
            task.Wait();

            if(JWT_TOKEN == null)
            {
                return "Erreur de login";
            }
              
        }

        var task1 = Task.Run(() => CallAsyncMembres());
        task1.Wait();

        if (task1.Result != null)
        {
            var membres = task1.Result;
            return membres.Count+" membres récupérés";
        }

        return "Erreur de récupération membres";
    }

    public static async Task CallAsyncLogin()
    {
        HttpClient httpClient = new HttpClient();

        var jsonOject = new 
        {
            u = _param.jwt_username,
            p = _param.jwt_password
        };
        var content = new StringContent(Yemon.dnn.Functions.Serialize(jsonOject), Encoding.UTF8, "application/json");
        var result = await httpClient.PostAsync(_param.jwt_url_login, content);
        if(result.IsSuccessStatusCode)
        {
            string t = result.Content.ReadAsStringAsync().Result;
            JWT_TOKEN = Yemon.dnn.Functions.Deserialize<JWTToken>(t);
            return;
        }

        JWT_TOKEN = null;
    }

    public static async Task<List<RotaryMag.Membre>> CallAsyncMembres()
    {
        bool firsttime=true;
        retry:
        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWT_TOKEN.accessToken);


        var result = await httpClient.GetAsync(_param.url_membres);
        if (result.IsSuccessStatusCode)
        {
            string t = result.Content.ReadAsStringAsync().Result;
            List<RotaryMag.Membre> membres = Yemon.dnn.Functions.Deserialize<List<RotaryMag.Membre>>(t);
            return membres;
        }
        else if (result.StatusCode==System.Net.HttpStatusCode.Unauthorized)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JWT_TOKEN.accessToken);

            var jsonOject = new
            {
                rtoken = JWT_TOKEN.renewalToken
            };
            var content = new StringContent(Yemon.dnn.Functions.Serialize(jsonOject), Encoding.UTF8, "application/json");
            var result1 = await httpClient.PostAsync(_param.jwt_url_extendtoken, content);
            if (result1.IsSuccessStatusCode)
            {
                string t = result1.Content.ReadAsStringAsync().Result;
                JWT_TOKEN = Yemon.dnn.Functions.Deserialize<JWTToken>(t);
                if (firsttime)
                {
                    firsttime = false;
                    goto retry;
                }
                
            }
            else
            {
                var task = Task.Run(() => CallAsyncLogin());
                task.Wait();
                if (JWT_TOKEN != null)
                {
                    if (firsttime)
                    {
                        firsttime = false;
                        goto retry;
                    }
                }
            }
        }
        return null;

    }
}