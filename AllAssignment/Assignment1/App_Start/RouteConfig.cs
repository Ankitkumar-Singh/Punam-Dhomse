using System.Web.Mvc;
using System.Web.Routing;

namespace AllAssignment
{
    public class RouteConfig
    {
        #region "RegisterRoutes"
        /// <summary>
        /// Mapping Route 
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
        #endregion
    }
}
