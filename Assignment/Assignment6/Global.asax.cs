using System.Web.Mvc;
using System.Web.Routing;

namespace Assignment6
{
    #region "Application_Start"
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
    #endregion
}
