using System.Web.Mvc;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        #region "HomeController"
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}