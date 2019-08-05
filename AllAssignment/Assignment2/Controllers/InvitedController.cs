using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class InvitedController : Controller
    {
        public ActionResult Index()
        {
            GuestContext guestContext = new GuestContext();
            List<Invitation> invitation = guestContext.invitation.ToList();
            return View(invitation);
        }
	}
}