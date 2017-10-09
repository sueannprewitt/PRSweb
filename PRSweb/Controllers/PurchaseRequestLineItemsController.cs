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

        private void UpdatePurchaseRequestTotal(int prid)
        {
            double total = 0.0;
            var purchaseRequestLineItems = db.PurchaseRequestLineItems.Where(p => p.PurchaseRequestId == prid);
            foreach (var purchaseRequestLineItem in purchaseRequestLineItems)
            {
                var subTotal = purchaseRequestLineItem.Quantity * purchaseRequestLineItem.Product.Price;
                total += subTotal;
            }
            var purchaseRequest = db.PurchaseRequests.Find(prid);
            purchaseRequest.Total = total;
            db.SaveChanges();
        }


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
                return Json(new Msg { Result = "Failure", Message = "Parameter is missing or invalid" }, JsonRequestBehavior.AllowGet);
            }
            //**Foreign key issue:
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(purchaseRequestLineItem.PurchaseRequestId); //returns a user for the ID or null if not found
            if (purchaseRequest == null) //this is true if the id is not found
            {
                return Json(new Msg { Result = "Failure", Message = "PurchaseRequest Id not found" }, JsonRequestBehavior.AllowGet);
            }
            Product product = db.Products.Find(purchaseRequestLineItem.ProductId);
            if (product == null)
            {
                return Json(new Msg { Result = "Failure", Message = "ProductId not found" }, JsonRequestBehavior.AllowGet);
            }

            //if we get here, just add the purchase request
            db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
            db.SaveChanges(); //actually makes the data persistent in the database
            UpdatePurchaseRequestTotal(purchaseRequestLineItem.PurchaseRequestId);
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

            Product product = db.Products.Find(purchaseRequestLineItem.ProductId);
            if (product == null)
            {
                return Json(new Msg { Result = "Failure", Message = "ProductId not found" }, JsonRequestBehavior.AllowGet);
            }

            if (purchaseRequestLineItem.Quantity < 0)
            {
                return Json(new Msg { Result = "Failure", Message = "Quantity is invalid" }, JsonRequestBehavior.AllowGet);
            }
                              
            var tempPurchaseRequestLineItem = db.PurchaseRequestLineItems.Find(purchaseRequestLineItem.Id);
            if (tempPurchaseRequestLineItem == null)
            {
                return Json(new Msg { Result = "Failure", Message = "Purchase Request Line Item Id not found" }, JsonRequestBehavior.AllowGet);
            }

            tempPurchaseRequestLineItem.Quantity = purchaseRequestLineItem.Quantity;
            tempPurchaseRequestLineItem.ProductId = purchaseRequestLineItem.ProductId;
            tempPurchaseRequestLineItem.PurchaseRequestId = purchaseRequestLineItem.PurchaseRequestId;

            db.SaveChanges(); //actually makes the data persistent in the database
            UpdatePurchaseRequestTotal(purchaseRequestLineItem.PurchaseRequestId);
            return Json(new Msg { Result = "Success", Message = "Add successful" }, JsonRequestBehavior.AllowGet);

           
}

        public ActionResult Remove([FromBody] PurchaseRequestLineItem purchaseRequestLineItem) //chosing to delete this way (by Purchase request) to keep it consistent
        {
            if (purchaseRequestLineItem == null || purchaseRequestLineItem.Id <= 0)
            {
                return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" }, JsonRequestBehavior.AllowGet);
            }
            //if we get here, delete the purchase request
            PurchaseRequestLineItem tempPurchaseRequestLineItem = db.PurchaseRequestLineItems.Find(purchaseRequestLineItem.Id);
            if (tempPurchaseRequestLineItem == null) //if can't find the purchase request
            {
                return Json(new Msg { Result = "Failure", Message = "Purchase ID not found." }, JsonRequestBehavior.AllowGet);
            }
            db.PurchaseRequestLineItems.Remove(tempPurchaseRequestLineItem); //actually does the remove from the database
            db.SaveChanges();
             UpdatePurchaseRequestTotal(tempPurchaseRequestLineItem.PurchaseRequestId);
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
        [System.Web.Mvc.HttpPost]
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
        [System.Web.Mvc.HttpPost]
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
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
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
