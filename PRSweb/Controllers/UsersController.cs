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
    public class UsersController : Controller
    {
        private PRSwebContext db = new PRSwebContext();

        public ActionResult Login(string UserName, string Password)
        {
            var users = db.Users.Where(u => u.UserName == UserName && u.Password == Password);
            return Json(users.ToList(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult List() //will ALWAYS return an array whether is it zero, 1, or more items within the array
        {
            return Json(db.Users.ToList(), JsonRequestBehavior.AllowGet);

        }

        public ActionResult Get(int? id) //will return 1 user or an error message
        {
            if (id == null) //error if nothing is passed in for ID
            {
                return Json(new Msg { Result = "Failure", Message = "Id is null" }, JsonRequestBehavior.AllowGet);
            }
            User user = db.Users.Find(id); //returns a user for the ID or null if not found
            if (user == null) //this is true if the id is not found
            {
                return Json(new Msg { Result = "Failure", Message = "Id not found" }, JsonRequestBehavior.AllowGet);
            }
            return Json(user, JsonRequestBehavior.AllowGet); //if here, everything is good; we have a user
        }
        public ActionResult Add([FromBody] User user) //use FromBody instead of bind - install Microsoft.aspnet.webapi.core in PM
        {
            if (user == null || user.UserName == null) //error if nothing is passed in for User or if it is invalid
            {
                return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" });
            }
            //if we get here, just add the user
            db.Users.Add(user);
            db.SaveChanges(); //actually makes the data persistent in the database
            return Json(new Msg { Result = "Success", Message = "Add successful" });
        }
        public ActionResult Change([FromBody] User user)
        {
            if (user == null || user.UserName == null) 
            {
                return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" });
            }
            //if we get here, just update the user
            User tempUser = db.Users.Find(user.ID);
            tempUser.UserName = user.UserName;
            tempUser.Password = user.Password;
            tempUser.FirstName = user.FirstName;
            tempUser.LastName = user.LastName;
            tempUser.Phone = user.Phone;
            tempUser.Email = user.Email;
            tempUser.IsReviewer = user.IsReviewer;
            tempUser.IsAdmin = user.IsAdmin;
            db.SaveChanges(); //you have to make sure all the changes did in fact occur
            return Json(new Msg { Result = "Success", Message = "Change Successful." });
        }

        public ActionResult Remove([FromBody] User user) //chosing to delete this way (by User) to keep it consistent
        {
            if (user == null || user.ID <= 0)
            {
                return Json(new Msg { Result = "Failure", Message = "User parameter is missing or invalid" });
            }
            //if we get here, delete the user
            User tempUser = db.Users.Find(user.ID);
            if (tempUser == null) //if can't find the user
            {
                return Json(new Msg { Result = "Failure", Message = "User ID not found." });
            }
            db.Users.Remove(tempUser); //actually does the remove from the database
            db.SaveChanges();
            return Json(new Msg { Result = "Success", Message = "Change Successful." });
        }



        #region MVC Methods

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Password,FirstName,LastName,Phone,Email,IsReviewer,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Password,FirstName,LastName,Phone,Email,IsReviewer,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
