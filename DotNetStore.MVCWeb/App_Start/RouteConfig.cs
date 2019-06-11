using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotNetStore.MVCWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //localhost/catalogo => //localhost/product/index
            //controlador: viajecontroller
            //metodo de accion: promociones
            //localhost/viaje/promociones
            //localhost/cyberday => viaje/promociones
            routes.MapRoute(
                name: "Catalogo",
                url: "Catalogo",
                defaults: new { controller = "Product", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
