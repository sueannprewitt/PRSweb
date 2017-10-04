using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PRSweb.Models;
using Utility;
using System.Web.Http;

namespace PRSweb.Controllers
{
    public class PurchaseRequestsController : Controller
    {
        private PRSwebContext db = new PRSwebContext();

        
        public ActionResult List() //will ALWAYS return an array whether is it zero, 1, or more items within the array
        {
            //return Json(db.PurchaseRequests.ToList(), JsonRequestBehavior.AllowGet);
            return new JsonNetResult { Data = db.PurchaseRequests.ToList() }; //changes the way that dates are decoded in Json
        }

        public ActionResult Get(int? id) //will return 1 user or an error message
        {
            if (id == null) //error if nothing is passed in for ID
            {
                return Json(new Msg { Result = "Failure", Message = "Id is null" }, JsonRequestBehavior.AllowGet);
            }
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id); //returns a purchase request for the ID or null if not found
            if (purchaseRequest == null) //this is true if the id is not found
            {
                return Json(new Msg { Result = "Failure", Message = "Id not found" }, JsonRequestBehavior.AllowGet);
            }
           // return Json(product, JsonRequestBehavior.AllowGet); //if here, everything is good; we have a purchase request
            return new JsonNetResult { Data = purchaseRequest };
        }
        public ActionResult Add([FromBody] PurchaseRequest purchaseRequest) //use FromBody instead of bind - install Microsoft.aspnet.webapi.core in PM
        {
            if (purchaseRequest == null) //error if nothing is passed in for purchase request
            {
                return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" }, JsonRequestBehavior.AllowGet);
            }
            //**Foreign key issue:
            User user = db.Users.Find(purchaseRequest.UserId); //returns a user for the ID or null if not found
            if (user == null) //this is true if the id is not found
            {
                return Json(new Msg { Result = "Failure", Message = "User Id not found" }, JsonRequestBehavior.AllowGet);
            }

            //if we get here, just add the purchase request
            db.PurchaseRequests.Add(purchaseRequest);
            db.SaveChanges(); //actually makes the data persistent in the database
           
            return Json(new Msg { Result = "Success", Message = "Add successful" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Change([FromBody] PurchaseRequest purchaseRequest)
        {
            if (purchaseRequest == null)
            {
                return Json(new Msg { Result = "Failure", Message = "Purchase request  is null" }, JsonRequestBehavior.AllowGet);
            }
            //**Foreign key issue:
            User user = db.Users.Find(purchaseRequest.UserId); //returns a vendor for the ID or null if not found
            if (user == null) //this is true if the id is not found
            {
                return Json(new Msg { Result = "Failure", Message = "User Id FK is invalid" }, JsonRequestBehavior.AllowGet);
            }

            //if we get here, just update the user
            PurchaseRequest tempPurchaseRequest = db.PurchaseRequests.Find(purchaseRequest.ID);
            if (tempPurchaseRequest == null)
            {
                return Json(new Msg { Result = "Failure", Message = "Purchase request ID not found" }, JsonRequestBehavior.AllowGet);
            }
            tempPurchaseRequest.Clone(purchaseRequest);
            db.SaveChanges(); //you have to make sure all the changes did in fact occur
            return Json(new Msg { Result = "Success", Message = "Change Successful." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Remove([FromBody] PurchaseRequest purchaseRequest) //chosing to delete this way (by Purchase request) to keep it consistent
        {
            if (purchaseRequest == null || purchaseRequest.ID <= 0)
            {
                return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" }, JsonRequestBehavior.AllowGet);
            }
            //if we get here, delete the purchase request
            PurchaseRequest tempPurchaseRequest = db.PurchaseRequests.Find(purchaseRequest.ID);
            if (tempPurchaseRequest == null) //if can't find the purchase request
            {
                return Json(new Msg { Result = "Failure", Message = "Purchase ID not found." }, JsonRequestBehavior.AllowGet);
            }
            db.PurchaseRequests.Remove(tempPurchaseRequest); //actually does the remove from the database
            db.SaveChanges();
            return Json(new Msg { Result = "Success", Message = "Change Successful." });
        }



        #region MVC Methods
        // GET: PurchaseRequests
        public ActionResult Index()
        {
            var purchaseRequests = db.PurchaseRequests.Include(p => p.User);
            return View(purchaseRequests.ToList());
        }

        // GET: PurchaseRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            if (purchaseRequest == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequest);
        }

        // GET: PurchaseRequests/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "ID", "UserName");
            return View();
        }

        // POST: PurchaseRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Justification,DateNeeded,DeliveryMode,Status,Total,SubmittedDate,UserId")] PurchaseRequest purchaseRequest)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequests.Add(purchaseRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "ID", "UserName", purchaseRequest.UserId);
            return View(purchaseRequest);
        }

        // GET: PurchaseRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            if (purchaseRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "ID", "UserName", purchaseRequest.UserId);
            return View(purchaseRequest);
        }

        // POST: PurchaseRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Justification,DateNeeded,DeliveryMode,Status,Total,SubmittedDate,UserId")] PurchaseRequest purchaseRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "ID", "UserName", purchaseRequest.UserId);
            return View(purchaseRequest);
        }

        // GET: PurchaseRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            if (purchaseRequest == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequest);
        }

        // POST: PurchaseRequests/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            db.PurchaseRequests.Remove(purchaseRequest);
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
