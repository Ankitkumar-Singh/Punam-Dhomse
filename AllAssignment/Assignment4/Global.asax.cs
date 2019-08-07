using System.Web.Mvc;
using System.Web.Routing;

namespace Assignment4
{
    public class MvcApplication : System.Web.HttpApplication
    {
        #region "Application Start"
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        #endregion
    }
}
