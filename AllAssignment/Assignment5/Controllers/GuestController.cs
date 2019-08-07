using Assignment5.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Assignment5.Controllers
{
    public class GuestController : Controller
    {
        private GuestContext db = new GuestContext();
        #region "Index"
        /// <summary>
        /// Fetching data from database
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var guests = db.Guests.Include(g => g.Invitation);
            return View(guests.ToList());
        }
        #endregion

        #region "Details"
        /// <summary>
        /// Details of guest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }
        #endregion

        #region "Create"
        /// <summary>
        /// Create guest get method
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.InvitationId = new SelectList(db.Invitations, "InvitationId", "Invited");
            return View();
        }

        // POST: /Guest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Email,Age,InvitationId,DateOFBirth,Gender")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvitationId = new SelectList(db.Invitations, "InvitationId", "Invited", guest.InvitationId);
            return View(guest);
        }
        #endregion

        #region "Edit"
        /// <summary>
        /// Edit guest details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvitationId = new SelectList(db.Invitations, "InvitationId", "Invited", guest.InvitationId);
            return View(guest);
        }

        // POST: /Guest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Email,Age,InvitationId,DateOFBirth,Gender")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvitationId = new SelectList(db.Invitations, "InvitationId", "Invited", guest.InvitationId);
            return View(guest);
        }
        #endregion

        #region "Delete"
        /// <summary>
        /// Delete guest from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        /// <summary>
        /// Confirm delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest guest = db.Guests.Find(id);
            db.Guests.Remove(guest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region "Dispose"
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
