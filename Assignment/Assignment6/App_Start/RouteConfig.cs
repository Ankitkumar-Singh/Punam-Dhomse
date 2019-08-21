using System.Web.Mvc;
using System.Web.Routing;

namespace Assignment6
{
    public class RouteConfig
    {
        #region "MapRoute"
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "GuestDetails", action = "Index", id = UrlParameter.Optional }
            );
        }
        #endregion
    }
}
