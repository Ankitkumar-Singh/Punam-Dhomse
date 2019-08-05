using System.Web.Mvc;
using System.Web.Routing;

namespace AllAssignment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        #region "Application_Start"
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        #endregion
    }
}
