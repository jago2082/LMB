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
    public class BridgeInspectionFollowUpsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: BridgeInspectionFollowUps
        public async Task<ActionResult> Index()
        {
            var bridgeInspectionFollowUps = db.BridgeInspectionFollowUps.Include(b => b.InspectionRaiting).Include(b => b.RecommendationType).Include(b => b.ReferenceFeatureType);
            return View(await bridgeInspectionFollowUps.ToListAsync());
        }

        // GET: BridgeInspectionFollowUps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BridgeInspectionFollowUp bridgeInspectionFollowUp = await db.BridgeInspectionFollowUps.FindAsync(id);
            if (bridgeInspectionFollowUp == null)
            {
                return HttpNotFound();
            }
            return View(bridgeInspectionFollowUp);
        }

        // GET: BridgeInspectionFollowUps/Create
        public ActionResult Create()
        {
            ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description");
            ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "idvalue");
            ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description");
            return View();
        }

        // POST: BridgeInspectionFollowUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdBridgeInspectionFollowUp,Description,IdReferenceFeatureType,IdRecommendationType,InspectionRaitingType")] BridgeInspectionFollowUp bridgeInspectionFollowUp)
        {
            if (ModelState.IsValid)
            {
                db.BridgeInspectionFollowUps.Add(bridgeInspectionFollowUp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description", bridgeInspectionFollowUp.InspectionRaitingType);
            ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "idvalue", bridgeInspectionFollowUp.IdRecommendationType);
            ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description", bridgeInspectionFollowUp.IdReferenceFeatureType);
            return View(bridgeInspectionFollowUp);
        }

        // GET: BridgeInspectionFollowUps/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BridgeInspectionFollowUp bridgeInspectionFollowUp = await db.BridgeInspectionFollowUps.FindAsync(id);
            if (bridgeInspectionFollowUp == null)
            {
                return HttpNotFound();
            }
            ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description", bridgeInspectionFollowUp.InspectionRaitingType);
            ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "idvalue", bridgeInspectionFollowUp.IdRecommendationType);
            ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description", bridgeInspectionFollowUp.IdReferenceFeatureType);
            return View(bridgeInspectionFollowUp);
        }

        // POST: BridgeInspectionFollowUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdBridgeInspectionFollowUp,Description,IdReferenceFeatureType,IdRecommendationType,InspectionRaitingType")] BridgeInspectionFollowUp bridgeInspectionFollowUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bridgeInspectionFollowUp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description", bridgeInspectionFollowUp.InspectionRaitingType);
            ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "idvalue", bridgeInspectionFollowUp.IdRecommendationType);
            ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description", bridgeInspectionFollowUp.IdReferenceFeatureType);
            return View(bridgeInspectionFollowUp);
        }

        // GET: BridgeInspectionFollowUps/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BridgeInspectionFollowUp bridgeInspectionFollowUp = await db.BridgeInspectionFollowUps.FindAsync(id);
            if (bridgeInspectionFollowUp == null)
            {
                return HttpNotFound();
            }
            return View(bridgeInspectionFollowUp);
        }

        // POST: BridgeInspectionFollowUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BridgeInspectionFollowUp bridgeInspectionFollowUp = await db.BridgeInspectionFollowUps.FindAsync(id);
            db.BridgeInspectionFollowUps.Remove(bridgeInspectionFollowUp);
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
