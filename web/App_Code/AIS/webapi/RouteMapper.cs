using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DotNetNuke.Web.Api;
using AIS.controller;

namespace AIS.webapi
{ 
    public class RouteMapper : IServiceRouteMapper
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routeManager">The route manager.</param>
        public void RegisterRoutes(IMapRoute routeManager)
        {
            routeManager.MapHttpRoute(
                "AIS",
                "Default",
                "{controller}/{action}",
                new[] { "AIS.Controller" }
            );
        }
    }

    //In short that means that you can address this webservice under the url
    //~/desktopmodules/AIS/api/{controller}/{action}
    

}
