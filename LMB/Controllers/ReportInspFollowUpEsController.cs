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
    public class ReportInspFollowUpEsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ReportInspFollowUpEs
        public async Task<ActionResult> Index()
        {
            return View(await db.ReportInspFollowUpEs.ToListAsync());
        }

        // GET: ReportInspFollowUpEs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportInspFollowUpE reportInspFollowUpE = await db.ReportInspFollowUpEs.FindAsync(id);
            if (reportInspFollowUpE == null)
            {
                return HttpNotFound();
            }
            return View(reportInspFollowUpE);
        }

        // GET: ReportInspFollowUpEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportInspFollowUpEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdReportInspFollowUpE,ComentGeneral,Dato1,Dato2,accion")] ReportInspFollowUpE reportInspFollowUpE)
        {
            if (ModelState.IsValid)
            {
                db.ReportInspFollowUpEs.Add(reportInspFollowUpE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(reportInspFollowUpE);
        }

        // GET: ReportInspFollowUpEs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportInspFollowUpE reportInspFollowUpE = await db.ReportInspFollowUpEs.FindAsync(id);
            if (reportInspFollowUpE == null)
            {
                return HttpNotFound();
            }
            return View(reportInspFollowUpE);
        }

        // POST: ReportInspFollowUpEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdReportInspFollowUpE,ComentGeneral,Dato1,Dato2,accion")] ReportInspFollowUpE reportInspFollowUpE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportInspFollowUpE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reportInspFollowUpE);
        }

        // GET: ReportInspFollowUpEs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportInspFollowUpE reportInspFollowUpE = await db.ReportInspFollowUpEs.FindAsync(id);
            if (reportInspFollowUpE == null)
            {
                return HttpNotFound();
            }
            return View(reportInspFollowUpE);
        }

        // POST: ReportInspFollowUpEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReportInspFollowUpE reportInspFollowUpE = await db.ReportInspFollowUpEs.FindAsync(id);
            db.ReportInspFollowUpEs.Remove(reportInspFollowUpE);
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
