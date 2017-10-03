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
    public class PurchaseRequestLineItemsController : Controller
    {
        private PRSwebContext db = new PRSwebContext();

        public ActionResult List() //will ALWAYS return an array whether is it zero, 1, or more items within the array
        {
            return Json(db.PurchaseRequestLineItems.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int? id) //will return 1 user or an error message
        {
            if (id == null) //error if nothing is passed in for ID
            {
                return Json(new Msg { Result = "Failure", Message = "Id is null" }, JsonRequestBehavior.AllowGet);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id); //returns a purchase request line item for the ID or null if not found
            if (purchaseRequestLineItem == null) //this is true if the id is not found
            {
                return Json(new Msg { Result = "Failure", Message = "Id not found" }, JsonRequestBehavior.AllowGet);
            }
            return Json(purchaseRequestLineItem, JsonRequestBehavior.AllowGet); //if here, everything is good; we have a purchase request line item
           
        }
        public ActionResult Add([FromBody] PurchaseRequestLineItem purchaseRequestLineItem) //use FromBody instead of bind - install Microsoft.aspnet.webapi.core in PM
        {
            if (purchaseRequestLineItem == null) //error if nothing is passed in for purchase request line item
            {
                return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" }, JsonRequestBehavior.AllowGet);
            }
            //**Foreign key issue:
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(purchaseRequestLineItem.PurchaseRequestId); //returns a user for the ID or null if not found
            if (purchaseRequest == null) //this is true if the id is not found
            {
                return Json(new Msg { Result = "Failure", Message = "PurchaseRequest Id not found" }, JsonRequestBehavior.AllowGet);
            }

            //if we get here, just add the purchase request
            db.PurchaseRequests.Add(purchaseRequest);
            db.SaveChanges(); //actually makes the data persistent in the database
            return Json(new Msg { Result = "Success", Message = "Add successful" }, JsonRequestBehavior.AllowGet);

            Product product = db.Products.Find(purchaseRequestLineItem.ProductId);
            if (product == null)
            {
                return Json(new Msg { Result = "Failure", Message = "ProductId not found" }, JsonRequestBehavior.AllowGet);
            }
            db.Products.Add(product);
            db.SaveChanges();
            return Json(new Msg { Result = "Success", Message = "Add successful" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Change([FromBody] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (purchaseRequestLineItem == null)
            {
                return Json(new Msg { Result = "Failure", Message = "Purchase request  is null" }, JsonRequestBehavior.AllowGet);
            }
            //**Foreign key issue:
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(purchaseRequestLineItem.PurchaseRequestId); //returns a user for the ID or null if not found
            if (purchaseRequest == null) //this is true if the id is not found
            {
                return Json(new Msg { Result = "Failure", Message = "PurchaseRequest Id not found" }, JsonRequestBehavior.AllowGet);
            }

            //if we get here, just add the purchase request
            db.PurchaseRequests.Add(purchaseRequest);
            db.SaveChanges(); //actually makes the data persistent in the database
            return Json(new Msg { Result = "Success", Message = "Add successful" }, JsonRequestBehavior.AllowGet);

            Product product = db.Products.Find(purchaseRequestLineItem.ProductId);
            if (product == null)
            {
                return Json(new Msg { Result = "Failure", Message = "ProductId not found" }, JsonRequestBehavior.AllowGet);
            }
            db.Products.Add(product);
            db.SaveChanges();
            return Json(new Msg { Result = "Success", Message = "Add successful" }, JsonRequestBehavior.AllowGet);
        }
        //if we get here, just update the purchase request line item
        PurchaseRequestLineItem tempPurchaseRequestLineItem = db.PurchaseRequestLineItems.Find(purchaseRequestLineItem.Id);
            if (tempPurchaseRequestLineItem == null)
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

        // GET: PurchaseRequestLineItems
        public ActionResult Index()
        {
            var purchaseRequestLineItems = db.PurchaseRequestLineItems.Include(p => p.Product);
            return View(purchaseRequestLineItems.ToList());
        }

        // GET: PurchaseRequestLineItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequestLineItem);
        }

        // GET: PurchaseRequestLineItems/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "VendorPartNumber");
            return View();
        }

        // POST: PurchaseRequestLineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantity,PurhaseRequestId,ProductId")] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "VendorPartNumber", purchaseRequestLineItem.ProductId);
            return View(purchaseRequestLineItem);
        }

        // GET: PurchaseRequestLineItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "VendorPartNumber", purchaseRequestLineItem.ProductId);
            return View(purchaseRequestLineItem);
        }

        // POST: PurchaseRequestLineItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,PurhaseRequestId,ProductId")] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequestLineItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "VendorPartNumber", purchaseRequestLineItem.ProductId);
            return View(purchaseRequestLineItem);
        }

        // GET: PurchaseRequestLineItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequestLineItem);
        }

        // POST: PurchaseRequestLineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            db.PurchaseRequestLineItems.Remove(purchaseRequestLineItem);
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
