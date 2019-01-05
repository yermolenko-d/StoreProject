using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Store.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
                new
                {
                    controller = "Cake",
                    action = "List",
                    category = (string)null,
                    page = 1
                });

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Cake" , action = "List", category = (string)null},
                constraints: new {page = @"\d+" });

            routes.MapRoute(null,
                "{category}",
                new { controller = "Cake", action = "List", page = 1 }
                );

            routes.MapRoute(
                name: null,
                url: "Cakes/Page{page}",
                defaults: new { controller = "Cake", action = "List"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cake", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
