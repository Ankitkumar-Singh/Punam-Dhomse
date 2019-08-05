using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer;

namespace Assignment3.Controllers
{
    public class GuestController : Controller
    {
        #region "Guest Controller"
        /// <summary>
        /// Display the list of guests.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            GuestBusinessLayer guestBusinessLayer = new GuestBusinessLayer();
            List<Guest> guest = guestBusinessLayer.Guest.ToList();
            return View(guest);
        }
        #endregion
    }
}