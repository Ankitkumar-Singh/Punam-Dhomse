using Assignment11.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Assignment11.Controllers
{
    public class GuestDetailsController : Controller
    {
        private GuestContext db = new GuestContext();

        #region "Index"
        /// <summary>Indexes this instance.</summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var guestDetails = db.GuestDetails.Include(g => g.Invitation);
            return View(guestDetails.ToList());
        }
        #endregion

        #region "IsEmailAvailable"
        /// <summary>Determines whether [is email available] [the specified email].</summary>
        /// <param name="Email">The email.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult IsEmailAvailable(string Email)
        {
            return Json(!db.GuestDetails.Any(x =>x.Email == Email),JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region "Create Method"
        // GET: GuestDetails/Create
        /// <summary>Creates this instance.</summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            ViewBag.InvitationId = new SelectList(db.Invitations, "InvitationId", "Invited");
            return View();
        }
        /// <summary>Creates the specified guest detail.</summary>
        /// <param name="guestDetail">The guest detail.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Email,Age,InvitationId,DateOFBirth,Gender")] GuestDetail guestDetail)
        {
            if (ModelState.IsValid)
            {
                db.GuestDetails.Add(guestDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvitationId = new SelectList(db.Invitations, "InvitationId", "Invited", guestDetail.InvitationId);
            return View(guestDetail);
        }
        #endregion

        #region "Edit Method"
        /// <summary>Edits the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            if (guestDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvitationId = new SelectList(db.Invitations, "InvitationId", "Invited", guestDetail.InvitationId);
            return View(guestDetail);
        }
        /// <summary>Edits the specified guest detail.</summary>
        /// <param name="guestDetail">The guest detail.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Email,Age,InvitationId,DateOFBirth,Gender")] GuestDetail guestDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvitationId = new SelectList(db.Invitations, "InvitationId", "Invited", guestDetail.InvitationId);
            return View(guestDetail);
        }
        #endregion

        #region "Delete"
        // GET: GuestDetails/Delete/5
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            if (guestDetail == null)
            {
                return HttpNotFound();
            }
            return View(guestDetail);
        }
        /// <summary>Deletes the confirmed.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestDetail guestDetail = db.GuestDetails.Find(id);
            db.GuestDetails.Remove(guestDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region "Dispose"
        /// <summary>Releases unmanaged resources and optionally releases managed resources.</summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
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
