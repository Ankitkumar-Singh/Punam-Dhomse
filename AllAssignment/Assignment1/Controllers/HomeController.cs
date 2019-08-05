using AllAssignment.Models;
using System;
using System.Web.Mvc;

namespace AllAssignment.Controllers
{
    public class HomeController : Controller
    {
        #region "Index Method"
        /// <summary>
        /// Displying Good morning or good night according to syste, time
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            ViewBag.Greeting = DateTime.Now.Hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }
        #endregion

        #region "HttpGet RspvForm"
        /// <summary>
        /// Get request for RspvForm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult RspvForm()
        {
            return View();
        }
        #endregion

        #region "HttpPost For RspvForm"
        /// <summary>
        /// Post request if form is valid
        /// </summary>
        /// <param name="guestResponse"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult RspvForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }
        #endregion

	}
}