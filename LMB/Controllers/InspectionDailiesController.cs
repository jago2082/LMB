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
using Newtonsoft.Json.Linq;

namespace LMB.Controllers
{
    [Authorize]
    public class InspectionDailiesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: InspectionDailies
        public async Task<ActionResult> Index()
        {

            var inspectionDaily = db.InspectionDaily.Include(i => i.InspectionState);
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "UserName");
            return View(await inspectionDaily.Where(i => i.IdInspectionStates != 2).ToListAsync());
        }

        // GET: InspectionDailies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inspectionDaily = await db.InspectionDaily.FindAsync(id);
            if (inspectionDaily == null)
            {
                return HttpNotFound();
            }
            return View(inspectionDaily);
        }

        // GET: InspectionDailies/Create
        public ActionResult Create()
        {
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdInspectionStates", "Description");
            return View();
        }

        // POST: InspectionDailies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InspectionDaily inspectionDaily)
        {
            if (ModelState.IsValid)
            {
                db.InspectionDaily.Add(inspectionDaily);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdInspectionStates", "Description", inspectionDaily.IdInspectionStates);
            return View(inspectionDaily);
        }

        public async Task<ActionResult> Save(int? id, int param)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (param == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inspectionDaily = await db.InspectionDaily.FindAsync(id);
            if (inspectionDaily == null)
            {
                return HttpNotFound();
            }

            try
            {
                inspectionDaily.IDUser = param;
                inspectionDaily.Status = 4;
                db.Entry(inspectionDaily).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdInspectionStates", "Description", inspectionDaily.IdInspectionStates);
            return RedirectToAction("Index");
        }

         // POST: InspectionDailies/Edit/5
         //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         //more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Save")]
        public async Task<ActionResult> Saved(int id, int param)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (param == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionDaily inspectionDaily = await db.InspectionDaily.FindAsync(id);
            if (inspectionDaily == null)
            {
                return HttpNotFound();
            }

            try
            {
                inspectionDaily.IDUser = param;
                inspectionDaily.Status = 2;
                inspectionDaily.IdInspectionStates = 2;
                db.Entry(inspectionDaily).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["msg"] = "<script>alert('Change succesfully');</script>";
            }
            catch (Exception)
            {

                throw;
            }
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdInspectionStates", "Description", inspectionDaily.IdInspectionStates);
            return RedirectToAction("Index");

        }


        [HttpPost, ActionName("Save")]
        public async Task<ActionResult> Saved(string[] ids)
        {
            dynamic jsonObject = ids;
            int id = 2;

            var inspectionDaily = await db.InspectionDaily.FindAsync(id);
            if (inspectionDaily == null)
            {
                return HttpNotFound();
            }

            try
            {
                inspectionDaily.IDUser = id;
                inspectionDaily.Status = 2;
                inspectionDaily.IdInspectionStates = 2;
                db.Entry(inspectionDaily).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["msg"] = "<script>alert('Change succesfully');</script>";
            }
            catch (Exception)
            {

                throw;
            }
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdInspectionStates", "Description", inspectionDaily.IdInspectionStates);
            return RedirectToAction("Index");

        }

        // GET: InspectionDailies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionDaily inspectionDaily = await db.InspectionDaily.FindAsync(id);
            if (inspectionDaily == null)
            {
                return HttpNotFound();
            }
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdInspectionStates", "Description", inspectionDaily.IdInspectionStates);
            return View(inspectionDaily);
        }

        // POST: InspectionDailies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(InspectionDaily inspectionDaily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionDaily).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdInspectionStates", "Description", inspectionDaily.IdInspectionStates);
            return View(inspectionDaily);
        }

        // GET: InspectionDailies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inspectionDaily = await db.InspectionDaily.FindAsync(id);
            if (inspectionDaily == null)
            {
                return HttpNotFound();
            }
            return View(inspectionDaily);
        }

        // POST: InspectionDailies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var inspectionDaily = await db.InspectionDaily.FindAsync(id);
            db.InspectionDaily.Remove(inspectionDaily);
            await db.SaveChangesAsync();
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
