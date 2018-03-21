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

namespace LMB.Controllers
{
    public class InspectionDailiesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: InspectionDailies
        public async Task<ActionResult> Index()
        {

            /*List<UserDB> users = new List<UserDB>();
            var user = new UserDB();
            user.IDUser = 99;
            user.FirstName = "Pepe";
            users.Add(user);
            ViewBag.user =  new SelectList(users, "IDUser",)*/
            return View(await db.InspectionDailies.ToListAsync());
        }

        // GET: InspectionDailies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
         
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionDaily inspectionDaily = await db.InspectionDailies.FindAsync(id);
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
                db.InspectionDailies.Add(inspectionDaily);
                await db.SaveChangesAsync();
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
            InspectionDaily inspectionDaily = await db.InspectionDailies.FindAsync(id);
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
                return RedirectToAction("Index");
            }
            return View(inspectionDaily);
        }

        // GET: InspectionDailies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionDaily inspectionDaily = await db.InspectionDailies.FindAsync(id);
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
            InspectionDaily inspectionDaily = await db.InspectionDailies.FindAsync(id);
            db.InspectionDailies.Remove(inspectionDaily);
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
