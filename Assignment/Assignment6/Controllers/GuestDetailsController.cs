using Assignment6.Models;
using System.Linq;
using System.Web.Mvc;

namespace Assignment6.Controllers
{
    public class GuestDetailsController : Controller
    {
        private GuestContext db = new GuestContext();

        #region "Index"
        /// <summary>Indexes this instance.</summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View(db.GuestDetails.ToList());
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
