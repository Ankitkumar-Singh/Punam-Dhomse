using Assignment.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    #region "GuestController"
    public class GuestCommentsController : Controller
    {
        private GuestContext db = new GuestContext();

        #region "Index Method"
        /// <summary>Indexes this instance.</summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View(db.GuestComments.ToList());
        }
        #endregion

        #region "Get Create Method"
        /// <summary>Creates this instance.</summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region "Post Create Method"
        /// <summary>Creates the specified guest comment.</summary>
        /// <param name="guestComment">The guest comment.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(GuestComment guestComment)
        {
            StringBuilder sbComments = new StringBuilder();
            sbComments.Append(HttpUtility.HtmlEncode(guestComment.Comments));

            sbComments.Replace("&lt;b&gt;", "<b>");
            sbComments.Replace("&lt;/b&gt;", "</b>");
            sbComments.Replace("&lt;u&gt;", "<u>");
            sbComments.Replace("&lt;/u&gt;", "</u>");
            guestComment.Comments = sbComments.ToString();

            string strEncodedName = HttpUtility.HtmlEncode(guestComment.Name);
            guestComment.Name = strEncodedName;
            if (ModelState.IsValid)
            {
                db.GuestComments.Add(guestComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestComment);
        }
        #endregion

        #region "Get Edit Method"
        /// <summary>Edits the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestComment guestComment = db.GuestComments.Find(id);
            if (guestComment == null)
            {
                return HttpNotFound();
            }
            return View(guestComment);
        }
        #endregion

        #region "Post Edit Method"
        /// <summary>Edits the specified guest comment.</summary>
        /// <param name="guestComment">The guest comment.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,Comments")] GuestComment guestComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guestComment);
        }
        #endregion

        #region "Delete Method"
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestComment guestComment = db.GuestComments.Find(id);
            if (guestComment == null)
            {
                return HttpNotFound();
            }
            return View(guestComment);
        }
        #endregion

        #region "Confirm Delete"
        /// <summary>Deletes the confirmed.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            GuestComment guestComment = db.GuestComments.Find(id);
            db.GuestComments.Remove(guestComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region "Dispose"
        /// <summary></summary>
        /// <param name="disposing"></param>
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
    #endregion
}
