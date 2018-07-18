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
    public class ValueCheckListsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ValueCheckLists
        public async Task<ActionResult> IndexIR()
        {
            return View(await db.ValueCheckList.ToListAsync());
        }

        // GET: ValueCheckLists/Details/5
        public async Task<ActionResult> DetailsIR(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueCheckList valueCheckList = await db.ValueCheckList.FindAsync(id);
            if (valueCheckList == null)
            {
                return HttpNotFound();
            }
            return View(valueCheckList);
        }

        // GET: ValueCheckLists/Create
        public ActionResult CreateIR()
        {
            return View();
        }

        // POST: ValueCheckLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdValueCheckList,Sync,IdUser,DateCheckList,IdChecklistQuestion,IdInspection,IdCheckList,RowIDQuestion,Comment,Value")] ValueCheckList valueCheckList)
        {
            if (ModelState.IsValid)
            {
                db.ValueCheckList.Add(valueCheckList);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(valueCheckList);
        }

        // GET: ValueCheckLists/Edit/5
        public async Task<ActionResult> EditIR(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueCheckList valueCheckList = await db.ValueCheckList.FindAsync(id);
            if (valueCheckList == null)
            {
                return HttpNotFound();
            }
            return View(valueCheckList);
        }

        // POST: ValueCheckLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditIR([Bind(Include = "IdValueCheckList,Sync,IdUser,DateCheckList,IdChecklistQuestion,IdInspection,IdCheckList,RowIDQuestion,Comment,Value")] ValueCheckList valueCheckList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valueCheckList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(valueCheckList);
        }

        // GET: ValueCheckLists/Delete/5
        public async Task<ActionResult> DeleteIR(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueCheckList valueCheckList = await db.ValueCheckList.FindAsync(id);
            if (valueCheckList == null)
            {
                return HttpNotFound();
            }
            return View(valueCheckList);
        }

        // POST: ValueCheckLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ValueCheckList valueCheckList = await db.ValueCheckList.FindAsync(id);
            db.ValueCheckList.Remove(valueCheckList);
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
