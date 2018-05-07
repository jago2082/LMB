using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using LMB.Models;
using LMB.Helpers;
using Newtonsoft.Json;

namespace LMB.Controllers
{
    [Authorize]
    public class InspectionDailiesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: InspectionDailies
        public async Task<ActionResult> Index()
        {
            var markers  = UtilsHelper.GetMarcadores();
            var inspectionDaily = db.InspectionDaily.Include(i  => i.InspectionState)
                .Include(u => u.UserDBs);
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "UserName");
            ViewBag.Markers = JsonConvert.SerializeObject(markers);
            return View(await inspectionDaily.Where(i => i.IdStatus != 2).ToListAsync());
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
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdStatus", "Description");
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
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdStatus", "Description", inspectionDaily.IdStatus);
            return View(inspectionDaily);
        }

        

        [HttpPost, ActionName("Save")]
        public async Task<ActionResult> Save(string listaIds, string user)
        {
            string[] arregloIds = listaIds.Split(new char[] { ',' });
            InspectionDaily inspectionDaily = null;
            int id =0;
            foreach (var item in arregloIds)
            {
                 id = int.Parse(item);
                inspectionDaily = await db.InspectionDaily.FindAsync(id);
                try
                {
                    inspectionDaily.IDUser = int.Parse(user);
                    inspectionDaily.Date = DateTime.Now;
                    inspectionDaily.IdStatus = 4;
                    db.Entry(inspectionDaily).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {

                    TempData["msg"] = "<script>swal('Error', '" + ex.Message +"', 'error');</script>";
                    return RedirectToAction("Index");
                }
            }

            
            TempData["msg"] = "<script>alert('Change succesfully');</script>";
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdStatus", "Description", inspectionDaily.IdStatus);
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
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdStatus", "Description", inspectionDaily.IdStatus);
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
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdStatus", "Description", inspectionDaily.IdStatus);
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
        public async Task<ActionResult> Delete(string listaIds, string user)
        {
            string[] arregloIds = listaIds.Split(new char[] { ',' });
            InspectionDaily inspectionDaily = null;
            int id = 0;
            foreach (var item in arregloIds)
            {
                id = int.Parse(item);
                inspectionDaily = await db.InspectionDaily.FindAsync(id);
                try
                {
                    db.InspectionDaily.Remove(inspectionDaily);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    TempData["msg"] = "<script>swal('Error', '" + ex.Message + "', 'error');</script>";
                    return RedirectToAction("Index");
                }
            }

            TempData["msg"] = "<script>alert('Delete succesfully');</script>";
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "FirstName");
            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdStatus", "Description", inspectionDaily.IdStatus);
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
