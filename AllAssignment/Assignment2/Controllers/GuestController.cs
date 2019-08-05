using Assignment2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class GuestController : Controller
    {
        public ActionResult Index(int invitationId)
        {
            GuestContext guestContext = new GuestContext();
            List<Guest> guest = guestContext.Guest.Where(gst => gst.InvitationId == invitationId).ToList();
            return View(guest);
        }
        #region "details"
        /// <summary>
        /// Using context model accessing the data
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            GuestContext guestContext = new GuestContext();
            Guest guest = guestContext.Guest.Single(x => x.Id == id);
            return View(guest);
        }
        #endregion
    }
}