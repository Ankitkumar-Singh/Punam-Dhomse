using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignment4.Controllers
{
    public class HomeController : Controller
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

        #region "Create method"
        /// <summary>
        /// Get method for create view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Post method for create view
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                GuestBusinessLayer guestBusinessLayer = new GuestBusinessLayer();
                guestBusinessLayer.AddGuests(guest);
                return RedirectToAction("Index");
            }
            return View(guest);
        }
        #endregion

        #region "Edit Method"
        /// <summary>
        /// Get method for Update view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            GuestBusinessLayer guestBusinessLayer = new GuestBusinessLayer();
            Guest guest = guestBusinessLayer.Guest.Single(gst => gst.Id == id);
            return View(guest);
        }
        /// <summary>
        /// Post method for update view
        /// </summary>
        /// <param name="guest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Guest guest)
        {
            if (ModelState.IsValid)
            {
                GuestBusinessLayer guestBusinessLayer = new GuestBusinessLayer();
                guestBusinessLayer.SaveGuest(guest);

                return RedirectToAction("Index");
            }
            return View(guest);
        }
        #endregion

        #region "Delete Method"
        /// <summary>
        /// Post method for delete operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            GuestBusinessLayer guestBusinessLayer = new GuestBusinessLayer();
            guestBusinessLayer.DeleteGuests(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}