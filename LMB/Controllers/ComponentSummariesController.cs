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
    public class ComponentSummariesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ComponentSummaries
        public async Task<ActionResult> Index()
        {
            var ComponentSummaries = db.ComponentSummaries.Include(b => b.InspectionRaiting).Include(b => b.Description).Include(b => b.IdComponentSummary);

            return View(await ComponentSummaries.ToListAsync());

        }

    // GET: ComponentSummaries/Details/5
    public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComponentSummary componentSummary = await db.ComponentSummaries.FindAsync(id);
            if (componentSummary == null)
            {
                return HttpNotFound();
            }
            return View(componentSummary);
        }

        // GET: ComponentSummaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComponentSummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdComponentSummary,Description,InspeRating,InvRatingH,InvRatingHS,OpRatingH,OpRatingHS")] ComponentSummary componentSummary)
        {
            if (ModelState.IsValid)
            {
                db.ComponentSummaries.Add(componentSummary);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(componentSummary);
        }

        // GET: ComponentSummaries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComponentSummary componentSummary = await db.ComponentSummaries.FindAsync(id);
            if (componentSummary == null)
            {
                return HttpNotFound();
            }
            return View(componentSummary);
        }

        // POST: ComponentSummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdComponentSummary,Description,InspeRating,InvRatingH,InvRatingHS,OpRatingH,OpRatingHS")] ComponentSummary componentSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(componentSummary).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(componentSummary);
        }

        // GET: ComponentSummaries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComponentSummary componentSummary = await db.ComponentSummaries.FindAsync(id);
            if (componentSummary == null)
            {
                return HttpNotFound();
            }
            return View(componentSummary);
        }

        // POST: ComponentSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ComponentSummary componentSummary = await db.ComponentSummaries.FindAsync(id);
            db.ComponentSummaries.Remove(componentSummary);
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
