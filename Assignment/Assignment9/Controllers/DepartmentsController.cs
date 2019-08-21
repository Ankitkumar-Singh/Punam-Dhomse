using Assignment9.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Assignment9.Controllers
{
    public class DepartmentsController : Controller
    {
        private DepartmentContext db = new DepartmentContext();

        #region "Index"
        /// <summary>Indexes the specified search by.</summary>
        /// <param name="searchBy">The search by.</param>
        /// <param name="search">The search.</param>
        /// <param name="page">The page.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Index(string searchBy, string search,int? page,string sortBy)
        {
            ViewBag.DepartmentSort = String.IsNullOrEmpty(sortBy) ? "Department desc" : "";
            ViewBag.LocationSort = String.IsNullOrEmpty(sortBy) ? "Location desc" : "";
            ViewBag.EmployeeSort= sortBy == "TotalEmployee" ? "TotalEmployee desc" : "TotalEmployee";

            var department = db.tblDepartments.AsQueryable();
            if (searchBy == "Department")
            {
                department = department.Where(x=>x.Department.StartsWith(search) ||search == null);
            }
            else if(searchBy == "Location")
            {
                department=department.Where(x => x.Location.StartsWith(search) || search == null) ;
            }
            else if (searchBy == "TotalEmployee")
            {
                department = department.Where(x => x.TotalEmployee.ToString() == search || search == null) ;
            }

            switch (sortBy)
            {
                case "Department desc":
                    department=department.OrderByDescending(x=>x.Department);
                    break;
                case "Location desc":
                    department = department.OrderByDescending(x => x.Location);
                    break;
                case "TotalEmployee":
                    department = department.OrderBy(x => x.TotalEmployee);
                    break;
                case "TotalEmployee desc":
                    department = department.OrderByDescending(x => x.TotalEmployee);
                    break;
                default:
                    department = department.OrderByDescending(x => x.Department);
                    break;
            }
            return View(department.ToPagedList(page ?? 1, 2));
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
        /// <summary>Creates the specified table department.</summary>
        /// <param name="tblDepartment">The table department.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Department,Location,TotalEmployee")] tblDepartment tblDepartment)
        {
            if (ModelState.IsValid)
            {
                db.tblDepartments.Add(tblDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDepartment);
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
            tblDepartment tblDepartment = db.tblDepartments.Find(id);
            if (tblDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartment);
        }
        #endregion

        #region "Post Edit Method"
        /// <summary>Edits the specified table department.</summary>
        /// <param name="tblDepartment">The table department.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Department,Location,TotalEmployee")] tblDepartment tblDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDepartment);
        }
        #endregion

        #region "Delete"
        /// <summary>Deletes the specified departments ids to delete.</summary>
        /// <param name="DepartmentsIdsToDelete">The departments ids to delete.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Delete(IEnumerable <int> DepartmentsIdsToDelete)
        {
            if (DepartmentsIdsToDelete == null || DepartmentsIdsToDelete.Count() == 0)
            {
                return RedirectToAction("Index", "Departments");
            }
            else {
                db.tblDepartments.Where(x => DepartmentsIdsToDelete.Contains(x.Id)).ToList().ForEach(x => db.tblDepartments.Remove(x));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
