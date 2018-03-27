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
    [Authorize]
    public class InspectionDailiesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: InspectionDailies
        public async Task<ActionResult> Index()
        {
            var userdb = db.UserDB.ToList();
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
            return View(await db.InspectionDaily.ToListAsync());
        }

        // GET: InspectionDailies/Details/5
        public async Task<ActionResult> Details(int? id)
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
            return View(inspectionDaily);
        }

        // GET: InspectionDailies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InspectionDailies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdInspection,IDUser,IdClient,IdProject,NumInspection,DO,Company,Control,Section,Address,City,TypeInspection,Scope,Date,Hour,IdValueCheckList,Status,Longitude,Latitude,LongitudeIni,LatitudeIni,DateInspection,CommentGeneral,IdAttach,Sync,LongitudeEnd,LatitudeEnd,DateInspectionEnd")] InspectionDaily inspectionDaily)
        {
            if (ModelState.IsValid)
            {
                db.InspectionDaily.Add(inspectionDaily);
                await db.SaveChangesAsync();
                ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
                return RedirectToAction("Index");
            }

            return View(inspectionDaily);
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
            return View(inspectionDaily);
        }

        // POST: InspectionDailies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdInspection,IDUser,IdClient,IdProject,NumInspection,DO,Company,Control,Section,Address,City,TypeInspection,Scope,Date,Hour,IdValueCheckList,Status,Longitude,Latitude,LongitudeIni,LatitudeIni,DateInspection,CommentGeneral,IdAttach,Sync,LongitudeEnd,LatitudeEnd,DateInspectionEnd")] InspectionDaily inspectionDaily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionDaily).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
                return RedirectToAction("Index");
            }
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
            InspectionDaily inspectionDaily = await db.InspectionDaily.FindAsync(id);
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
            return RedirectToAction("Index");
        }

        // POST: InspectionDailies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                inspectionDaily.Status = id;
                db.Entry(inspectionDaily).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
            return RedirectToAction("Index");
           
        }
        // GET: InspectionDailies/Delete/5
        public async Task<ActionResult> Delete(int? id)
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
            return View(inspectionDaily);
        }

        // POST: InspectionDailies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InspectionDaily inspectionDaily = await db.InspectionDaily.FindAsync(id);
            db.InspectionDaily.Remove(inspectionDaily);
            await db.SaveChangesAsync();
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
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
