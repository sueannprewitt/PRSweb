using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRSweb.Models;
using System.Web.Http;
using Utility;

namespace PRSweb.Controllers
{
    public class VendorsController : Controller
    {
        private PRSwebContext db = new PRSwebContext();

        public ActionResult List() //will ALWAYS return an array whether is it zero, 1, or more items within the array
        {
            return Json(db.Vendors.ToList(), JsonRequestBehavior.AllowGet);

        }

        public ActionResult Get(int? id) //will return 1 user or an error message
        {
            if (id == null) //error if nothing is passed in for ID
            {
                return Json(new Msg { Result = "Failure", Message = "Id is null" }, JsonRequestBehavior.AllowGet);
            }
            Vendor vendor = db.Vendors.Find(id); //returns a vendor for the ID or null if not found
            if (vendor == null) //this is true if the id is not found
            {
                return Json(new Msg { Result = "Failure", Message = "Id not found" }, JsonRequestBehavior.AllowGet);
            }
            return Json(vendor, JsonRequestBehavior.AllowGet); //if here, everything is good; we have a vendor
        }
        public ActionResult Add([FromBody] Vendor vendor) //use FromBody instead of bind - install Microsoft.aspnet.webapi.core in PM
        {
            if (vendor == null || vendor.Code == null) //error if nothing is passed in for vendor or if it is invalid
            {
                return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" });
            }
            //if we get here, just add the vendor
            db.Vendors.Add(vendor);
            db.SaveChanges(); //actually makes the data persistent in the database
            return Json(new Msg { Result = "Success", Message = "Add successful" });
        }
        public ActionResult Change([FromBody] Vendor vendor)
        {
            if (vendor == null || vendor.Code == null)
            {
                return Json(new Msg { Result = "Failure", Message = "Vendor parameter is missing or invalid" });
            }
            //if we get here, just update the user
            Vendor tempVendor = db.Vendors.Find(vendor.Id);
            tempVendor.Code = vendor.Code;
            tempVendor.Name = vendor.Name;
            tempVendor.Address = vendor.Address;
            tempVendor.City = vendor.City;
            tempVendor.State = vendor.State;
            tempVendor.Zip = vendor.Zip;
            tempVendor.Phone = vendor.Phone;
            tempVendor.Email = vendor.Email;
            tempVendor.IsPreapproved = vendor.IsPreapproved;
            db.SaveChanges(); //you have to make sure all the changes did in fact occur
            return Json(new Msg { Result = "Success", Message = "Change Successful." });
        }

        public ActionResult Remove([FromBody] Vendor vendor) //chosing to delete this way (by Vendor) to keep it consistent
        {
            if (vendor == null || vendor.Id <= 0)
            {
                return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" });
            }
            //if we get here, delete the vendor
            Vendor tempVendor = db.Vendors.Find(vendor.Id);
            if (tempVendor == null) //if can't find the vendor
            {
                return Json(new Msg { Result = "Failure", Message = "User ID not found." });
            }
            db.Vendors.Remove(tempVendor); //actually does the remove from the database
            db.SaveChanges();
            return Json(new Msg { Result = "Success", Message = "Change Successful." });
        }


        #region MVC Methods
        // GET: Vendors
        public ActionResult Index()
        {
            return View(db.Vendors.ToList());
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Address,City,State,Zip,Phone,Email,IsPreapproved")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Address,City,State,Zip,Phone,Email,IsPreapproved")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
