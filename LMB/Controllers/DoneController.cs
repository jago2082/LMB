using LMB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Rotativa.MVC;
using System.Web.Mvc;
using Z.EntityFramework.Plus;
using LMB.Helpers;
using System.Web;
using System.IO;

namespace LMB.Controllers
{
    [Authorize]
    public class DoneController : Controller
    {
        private DataContext db = new DataContext();

        // GET: InspectionDailies
        public async Task<ActionResult> Index()
        {
            var inspectionDaily = db.InspectionDaily.Include(i => i.InspectionState)
                .Include(t => t.Insp_Type_Attach)
                .Include(u => u.UserDBs);
            return View(await inspectionDaily.Where(i => i.IdStatus == 2).ToListAsync());
        }

        public ActionResult LoadRating()
        {
            return View("LoadRating");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ins = db.InspectionDaily.Find(id);
            var Insp_Type_Attach1 = db.Insp_Type_Attach.Include(i => i.DirectionPhotoType);
            var Insp_Type_Attach = Insp_Type_Attach1
                .Where(i => i.IDInspection == id).ToList();
            if (Insp_Type_Attach == null)
            {
                return HttpNotFound();
            }
            foreach (var item in Insp_Type_Attach)
            {
                item.numinspection = ins.NumInspection;
            }
            return View("LoadPhoto", Insp_Type_Attach);
        }

        // POST: InspectionDailies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit(InspectionDaily inspectionDaily)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inspectionDaily).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdInspectionStates = new SelectList(db.InspectionStates, "IdStatus", "Description", inspectionDaily.IdStatus);
            return View(inspectionDaily);
        }


        public ActionResult PDFReport(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var inspectionDaily = db.InspectionDaily.Include(i => i.InspectionState)
            //    .Include(tp => tp.Insp_Type_Attach.TypePicture)
            //    .Include(t => t.Insp_Type_Attach.DirectionPhotoType)
            //    .Where(j => j.IdInspection ==id).ToList();

            //var inspectionDail = (from ind in db.InspectionDaily
            //             join ist in db.InspectionStates on ind.IdInspectionStates equals ist.IdInspectionStates
            //             join ita in db.Insp_Type_Attach on ind.IdAttach equals ita.IDAttach
            //             join tpc in db.TypePicture on ita.IDTypePicture equals tpc.IdTypePicture
            //             join dpt in db.DirectionPhotoType on ita.IdDirectionPhotoType equals dpt.IdDirectionPhotoType
            //             select new
            //             {
            //                 ImageString = ita.ImageString,
            //                 Typepicture = tpc.Description,
            //                 Directionpoto = dpt.Description,
            //                 Company = ind.Company,
            //                 NumInspection = ind.NumInspection,
            //                 DateInspectionEnd = ind.DateInspectionEnd,
            //                 idInspection = ind.IdInspection

            //             }).Where(i => i.idInspection == id).ToList();
            List<ModelPDF> lismpdf = new List<ModelPDF>();

            var result = db.Insp_Type_Attach.Where(i => i.IDInspection == id).ToList();
            var inspd = db.InspectionDaily.Find(id);
            int? numinsp = id;
            var district = db.Districts.Where(d => d.NAME == inspd.Company).FirstOrDefault();
            string dist = district.ABBR;
            string dateprint = inspd.DateInspectionEnd;
            try
            {
                foreach (var item in result)
                {
                    ModelPDF inspectionDaily = new ModelPDF();
                    inspectionDaily.ImageString = item.ImageString;
                    var typepic = db.TypePicture.Find(item.IDTypePicture);
                    inspectionDaily.Description = typepic.Description;
                    var directionPhotoType = db.DirectionPhotoType.Find(item.IdDirectionPhotoType);
                    inspectionDaily.PTDescription = directionPhotoType.Description;
                    var inspectd = db.InspectionDaily.Find(item.IDInspection);
                    inspectionDaily.Company = district.ABBR;
                    inspectionDaily.NumInspection = inspectd.NumInspection;
                    inspectionDaily.DateInspectionEnd = inspectd.DateInspectionEnd;
                    lismpdf.Add(inspectionDaily);

                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //foreach (var item in inspectionDail)
            //{
            //    inspectionDaily.ImageString = item.ImageString;
            //    inspectionDaily.Description = item.Typepicture;
            //    inspectionDaily.PTDescription = item.Directionpoto;
            //    inspectionDaily.Company = item.Company;
            //    inspectionDaily.NumInspection = item.NumInspection;
            //    inspectionDaily.DateInspectionEnd = item.DateInspectionEnd;
            //    lismpdf.Add(inspectionDaily);
            //}
            if (lismpdf == null)
            {
                return HttpNotFound();
            }

            string header = Server.MapPath("~/PDF/Header.html");//Path of PrintFooter.html File
            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--footer-spacing \"10\" " +
                                   "--footer-font-size \"10\" " +
                                   "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", new { id=numinsp, area = "" }, "http"));
            //return View("Reporte", lismpdf);

            return new ViewAsPdf("ReportPDF", lismpdf)
            {
                RotativaOptions = { CustomSwitches = customSwitches, PageSize = Rotativa.Core.Options.Size.Legal }
            };
        }

        [AllowAnonymous]
        public ActionResult Footer( int? id)
        {
            var numinsp = db.InspectionDaily.Find(id);
            var district = db.Districts.Where(d => d.NAME == numinsp.Company).FirstOrDefault();
            numinsp.Company = district.ABBR;
            return View(numinsp);
        }


        public async Task<ActionResult> EditP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var InspTypeAttach = await db.Insp_Type_Attach.FindAsync(id);
            var inspection = await db.InspectionDaily.FindAsync(InspTypeAttach.IDInspection);
            if (InspTypeAttach == null)
            {
                return HttpNotFound();
            }
            InspTypeAttach.numinspection = inspection.NumInspection;
            ViewBag.IDTypePicture = new SelectList(CombosHelper.TypePicture(), "IdTypePicture", "Description");
            ViewBag.IdDirectionPhotoType = new SelectList(CombosHelper.PothoType(), "IdDirectionPhotoType", "Description");
            return View(InspTypeAttach);
        }

        // POST: InspectionDailies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditP(Insp_Type_Attach insptypeattach)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["LogoFile"];
                string theFileName = Path.GetFileName(file.FileName);
                byte[] thePictureAsBytes = new byte[file.ContentLength];
                using (BinaryReader theReader = new BinaryReader(file.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                }
                string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
                insptypeattach.ImageString = thePictureDataAsString;
                db.Entry(insptypeattach).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(insptypeattach);
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
