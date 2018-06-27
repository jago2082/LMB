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
            var markers = await UtilsHelper.GetMarcadores();
            var inspectionDaily = db.InspectionDaily.Include(i => i.InspectionState)
                .Include(u => u.UserDBs);
            ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "UserName");
            ViewBag.type = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "UserName");
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
            ViewBag.DO = new SelectList(Helpers.CombosHelper.GetDistricts(), "NAME", "ABBR");
            ViewBag.Company = new SelectList(Helpers.CombosHelper.GetCounties(), "IdCountries", "Description");
            ViewBag.IdStatus = new SelectList(db.InspectionStates, "IdStatus", "Description");
            ViewBag.IDUser = new SelectList(db.UserDB, "IDUser", "UserName");
            return View();
        }

        // POST: InspectionDailies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( InspectionDaily inspectionDaily)
        {
            if (ModelState.IsValid)
            {
                var aux = String.Format("0{0}", inspectionDaily.Company);
                inspectionDaily.Company = aux;
                inspectionDaily.IdClient = 1;
                inspectionDaily.IdProject = 1;
                inspectionDaily.TypeInspection = 1;
                inspectionDaily.Date = DateTime.Now;
                inspectionDaily.IdValueCheckList = 70;
                if (inspectionDaily.IdStatus != 5)
                {
                    inspectionDaily.IdStatus = 4;
                }
                else
                {
                    inspectionDaily.IdStatus = 5;
                }
                inspectionDaily.CommentGeneral = "0";
                inspectionDaily.IdAttach = 4;
                db.InspectionDaily.Add(inspectionDaily);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DO = new SelectList(Helpers.CombosHelper.GetDistricts(), "NAME", "ABBR");
            ViewBag.Company = new SelectList(Helpers.CombosHelper.GetCounties(), "IdCountries", "Description");
            ViewBag.IdStatus = new SelectList(db.InspectionStates, "IdStatus", "Description", inspectionDaily.IdStatus);
            ViewBag.IDUser = new SelectList(db.UserDB, "IDUser", "UserName", inspectionDaily.IDUser);
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
            ViewBag.DO = new SelectList(Helpers.CombosHelper.GetDistricts(), "NAME", "ABBR");
            ViewBag.Company = new SelectList(Helpers.CombosHelper.GetCounties(), "IdCountries", "Description");
            ViewBag.IdStatus = new SelectList(db.InspectionStates, "IdStatus", "Description", inspectionDaily.IdStatus);
            ViewBag.IDUser = new SelectList(db.UserDB, "IDUser", "UserName", inspectionDaily.IDUser);
            return View(inspectionDaily);
        }

        // POST: InspectionDailies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdInspection,IDUser,IdClient,IdProject,NumInspection,DO,Company,Control,Section,Address,City,TypeInspection,Scope,Date,Hour,IdValueCheckList,IdStatus,Longitude,Latitude,LongitudeIni,LatitudeIni,DateInspection,CommentGeneral,IdAttach,Sync,LongitudeEnd,LatitudeEnd,DateInspectionEnd,Flag,Structure,MaintanSection,Milepnt")] InspectionDaily inspectionDaily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionDaily).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DO = new SelectList(Helpers.CombosHelper.GetDistricts(), "NAME", "ABBR");
            ViewBag.Company = new SelectList(Helpers.CombosHelper.GetCounties(), "IdCountries", "Description");
            ViewBag.IdStatus = new SelectList(db.InspectionStates, "IdStatus", "Description", inspectionDaily.IdStatus);
            ViewBag.IDUser = new SelectList(db.UserDB, "IDUser", "UserName", inspectionDaily.IDUser);
            return View(inspectionDaily);
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
        public async Task<ActionResult> DeleteConfirmed(string listaIds, string user)
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
