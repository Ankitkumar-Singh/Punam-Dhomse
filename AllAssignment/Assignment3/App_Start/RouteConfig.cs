using System.Web.Mvc;
using System.Web.Routing;

namespace Assignment3
{
    public class RouteConfig
    {
        #region "Route"
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Guest", action = "Index", id = UrlParameter.Optional }
            );
        }
        #endregion
    }
}
