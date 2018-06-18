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
    public class InspectionStatesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: InspectionStates
        public async Task<ActionResult> Index()
        {
            return View(await db.InspectionStates.ToListAsync());
        }

        // GET: InspectionStates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionStates inspectionStates = await db.InspectionStates.FindAsync(id);
            if (inspectionStates == null)
            {
                return HttpNotFound();
            }
            return View(inspectionStates);
        }

        // GET: InspectionStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InspectionStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdStatus,Description")] InspectionStates inspectionStates)
        {
            if (ModelState.IsValid)
            {
                db.InspectionStates.Add(inspectionStates);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(inspectionStates);
        }

        // GET: InspectionStates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionStates inspectionStates = await db.InspectionStates.FindAsync(id);
            if (inspectionStates == null)
            {
                return HttpNotFound();
            }
            return View(inspectionStates);
        }

        // POST: InspectionStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdStatus,Description")] InspectionStates inspectionStates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionStates).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inspectionStates);
        }

        // GET: InspectionStates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionStates inspectionStates = await db.InspectionStates.FindAsync(id);
            if (inspectionStates == null)
            {
                return HttpNotFound();
            }
            return View(inspectionStates);
        }

        // POST: InspectionStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InspectionStates inspectionStates = await db.InspectionStates.FindAsync(id);
            db.InspectionStates.Remove(inspectionStates);
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
