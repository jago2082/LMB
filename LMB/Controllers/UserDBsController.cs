using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMB.Models;
using LMB.Helpers;

namespace LMB.Controllers
{
    public class UserDBsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: UserDBs
        public async Task<ActionResult> Index()
        {
            return View(await db.UserDB.ToListAsync());
        }

        // GET: UserDBs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDB userDB = await db.UserDB.FindAsync(id);
            if (userDB == null)
            {
                return HttpNotFound();
            }
            return View(userDB);
        }

        // GET: UserDBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserDB userDB)
        {
            if (ModelState.IsValid)
            {
                userDB.IsActive = 1;
                userDB.IdClient = 1;
                userDB.IsUpdate = 0;
                db.UserDB.Add(userDB);
                await db.SaveChangesAsync();
                UsersHelper.CreateUserASP(userDB.Email, userDB.UserName, "User");
                ViewBag.Script = "<script type='text/javascript'>swal('¡Alert!', 'Select a File!.', 'error');</script>";
                return RedirectToAction("Create");
            }

            return View(userDB);
        }

        // GET: UserDBs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userDB = await db.UserDB.FindAsync(id);
            if (userDB == null)
            {
                return HttpNotFound();
            }
            return View(userDB);
        }

        // POST: UserDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserDB userDB)
        {
            if (ModelState.IsValid)
            {
                var db2 = new DataContext();
                var currentuser = db2.UserDB.Find(userDB.IDUser);
                if (currentuser.Email != userDB.Email )
                {
                    UsersHelper.UpdateEmail(currentuser.Email, userDB.Email);
                    
                }
                db2.Dispose();
                db.Entry(userDB).State = EntityState.Modified;
                await db.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }
            return View(userDB);
        }

        // GET: UserDBs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userDB = await db.UserDB.FindAsync(id);
            if (userDB == null)
            {
                return HttpNotFound();
            }
            return View(userDB);
        }

        // POST: UserDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var userDB = await db.UserDB.FindAsync(id);
            db.UserDB.Remove(userDB);
            await db.SaveChangesAsync();
            UsersHelper.DeleteUser(userDB.Email);
            return RedirectToAction("Index");
        }

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
