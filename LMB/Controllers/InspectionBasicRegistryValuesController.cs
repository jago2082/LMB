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
    public class InspectionBasicRegistryValuesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: InspectionBasicRegistryValues
        public async Task<ActionResult> Index()
        {
            return View(await db.InspectionBasicRegistryValue.ToListAsync());
        }

        // GET: InspectionBasicRegistryValues/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionBasicRegistryValue inspectionBasicRegistryValue = await db.InspectionBasicRegistryValue.FindAsync(id);
            if (inspectionBasicRegistryValue == null)
            {
                return HttpNotFound();
            }
            return View(inspectionBasicRegistryValue);
        }

        // GET: InspectionBasicRegistryValues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InspectionBasicRegistryValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdInspectionBV,IdInspection,idInspBasic,Value")] InspectionBasicRegistryValue inspectionBasicRegistryValue)
        {
            if (ModelState.IsValid)
            {
                db.InspectionBasicRegistryValue.Add(inspectionBasicRegistryValue);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(inspectionBasicRegistryValue);
        }

        // GET: InspectionBasicRegistryValues/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionBasicRegistryValue inspectionBasicRegistryValue = await db.InspectionBasicRegistryValue.FindAsync(id);
            if (inspectionBasicRegistryValue == null)
            {
                return HttpNotFound();
            }
            return View(inspectionBasicRegistryValue);
        }

        // POST: InspectionBasicRegistryValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdInspectionBV,IdInspection,idInspBasic,Value")] InspectionBasicRegistryValue inspectionBasicRegistryValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionBasicRegistryValue).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inspectionBasicRegistryValue);
        }

        // GET: InspectionBasicRegistryValues/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InspectionBasicRegistryValue inspectionBasicRegistryValue = await db.InspectionBasicRegistryValue.FindAsync(id);
            if (inspectionBasicRegistryValue == null)
            {
                return HttpNotFound();
            }
            return View(inspectionBasicRegistryValue);
        }

        // POST: InspectionBasicRegistryValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InspectionBasicRegistryValue inspectionBasicRegistryValue = await db.InspectionBasicRegistryValue.FindAsync(id);
            db.InspectionBasicRegistryValue.Remove(inspectionBasicRegistryValue);
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
