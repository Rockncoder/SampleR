using Microsoft.AspNet.SignalR;
using SampleR.Chat;
using SampleR.UserCount;
using System.Web.Mvc;
using System.Web.Routing;

namespace SampleR
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            RouteTable.Routes.MapConnection<UserCountConnection>("userCounter", "/userCounter");
            RouteTable.Routes.MapConnection<ChatConnection>("chat", "/chat");
            RouteTable.Routes.MapHubs("moveShapeSample", new HubConfiguration());

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}