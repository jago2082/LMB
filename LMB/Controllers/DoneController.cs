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
using Rotativa.Core.Options;
using Newtonsoft.Json;

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

        public ActionResult LoadReportBridgeInspection(int? id)
        {
            var insp = db.InspectionDaily.Find(id);
            var inspList = db.ValueCheckList.ToList().Where(ins => ins.IdInspection == id);
            LoadRatingReport LoadRatingReport = new LoadRatingReport();
            LoadRatingReport.InspectionDaily = insp;
            LoadRatingReport.ValuesCheclist = inspList.ToList();
            return View("ReportBridgeInspectionRecord", LoadRatingReport);
        }


        public ActionResult LoadRating(int? id)
        {
           // int id = 5;
            var insp = db.InspectionDaily.Find(id);
            var inspList = db.ValueCheckList.ToList().Where(ins => ins.IdInspection == id);
            LoadRatingReport LoadRatingReport = new LoadRatingReport();
            LoadRatingReport.InspectionDaily = insp;
            if (inspList.Count() > 0)
            {
                var item58 = db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 1 && ins.IdChecklistQuestion == 1).FirstOrDefault();

                var item59 = db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 2).Min(value => value.Value);
                var item60 = db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 3).Min(value => value.Value);
                var item62 = db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 4).Min(value => value.Value);
                
                LoadRatingReport.ValuesCheclist = inspList.ToList();
                
                if (Convert.ToString(item58.Value) != "")
                    LoadRatingReport.Item58 = Convert.ToString(item58.Value);
                if (item59.Value == 10)
                    LoadRatingReport.Item59 = "N";
                else
                    LoadRatingReport.Item59 = Convert.ToString(item59.Value);
                if (item60.Value == 10)
                    LoadRatingReport.Item60 = "N";
                else
                    LoadRatingReport.Item60 = Convert.ToString(item60.Value);
                if (item62.Value == 10)
                    LoadRatingReport.Item62 = "N";
                else
                    LoadRatingReport.Item62 = Convert.ToString(item60.Value);
            }
            return View("LoadRating", LoadRatingReport);
           
        }

        public ActionResult ReportBill()
        {
            var insp = db.InspectionDaily.ToList();
            var TotalA= db.InspectionDaily.ToList().Where(ing=>ing.CommentGeneral=="A").Count();
            var TotalAA = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync=="A").Count();
            var TotalAB = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "B").Count();
            var TotalAC = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "C").Count();
            var TotalAD = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "D").Count();
            var TotalAE = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "E").Count();
            var TotalAF = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "F").Count();
            var TotalAG = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "G").Count();
            var TotalAH = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "H").Count();
            var TotalAX = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "X").Count();

            var TotalB = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "B").Count();
            var TotalBA = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "A").Count();
            var TotalBB = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "B").Count();
            var TotalBC = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "C").Count();
            var TotalBD = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "D").Count();
            var TotalBE = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "E").Count();
            var TotalBF = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "F").Count();
            var TotalBG = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "G").Count();
            var TotalBH = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "H").Count();
            var TotalBX = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "X").Count();

            return View("ReportBill", insp);
        }

        public ActionResult ReportInspFollowUp()
        {
            return View("ReportInspFollowUp");
        }

        public ActionResult ReportSummarySheet()
        {
            return View("ReportSummarySheet");
        }
        public ActionResult ReportStructuralCondition()
        {
            return View("ReportStructuralCondition");
        }

        public ActionResult ReportInventoryRecord(int? id)
        {
           // int id = 5;
            var insp = db.InspectionDaily.Find(id);

            var inspList = db.InspectionBasicRegistryValue.ToList().Where(ins => ins.IdInspection == id);
            InventoryReport InventoryReport = new InventoryReport();
            InventoryReport.IdInspection = insp.IdInspection;
            InventoryReport.District = insp.DO;
            InventoryReport.County = insp.Company;
            InventoryReport.Control = insp.Control;
            InventoryReport.Section = insp.Section;
            InventoryReport.Location = insp.Address;
            InventoryReport.Route = insp.City;
            InventoryReport.Structure = insp.Structure;
            InventoryReport.Year = insp.Hour;
            InventoryReport.MaintanSection = insp.MaintanSection;
            InventoryReport.FeatXed = insp.Scope;
            InventoryReport.LatitudeEnd = insp.LatitudeEnd;
            InventoryReport.LongitudeEnd = insp.LongitudeEnd;
            InventoryReport.DateInspectionEnd = insp.DateInspectionEnd;
            foreach (var data in inspList)
            {
                if (data.idInspBasic == 1)
                    InventoryReport.Id1 = data.Value;
                if (data.idInspBasic == 2)
                    InventoryReport.Id2 = data.Value;
                if (data.idInspBasic == 3)
                    InventoryReport.Id3 = data.Value;
                if (data.idInspBasic == 4)
                    InventoryReport.Id4 = data.Value;
                if (data.idInspBasic == 5)
                    InventoryReport.Id5 = data.Value;
                if (data.idInspBasic == 6)
                    InventoryReport.Id6 = data.Value;
                if (data.idInspBasic == 7)
                    InventoryReport.Id7 = data.Value;
                if (data.idInspBasic == 8)
                    InventoryReport.Id8 = data.Value;
                if (data.idInspBasic == 9)
                    InventoryReport.Id9 = data.Value;
                if (data.idInspBasic == 10)
                    InventoryReport.Id10 = data.Value;
                if (data.idInspBasic == 11)
                    InventoryReport.Id11 = data.Value;
                if (data.idInspBasic == 12)
                    InventoryReport.Id12 = data.Value;
                if (data.idInspBasic == 13)
                    InventoryReport.Id13 = data.Value;
                if (data.idInspBasic == 14)
                    InventoryReport.Id14 = data.Value;
                if (data.idInspBasic == 15)
                    InventoryReport.Id15 = data.Value;
                if (data.idInspBasic == 16)
                    InventoryReport.Id16 = data.Value;
                if (data.idInspBasic == 17)
                    InventoryReport.Id17 = data.Value;
                if (data.idInspBasic == 18)
                    InventoryReport.Id18 = data.Value;
                if (data.idInspBasic == 19)
                    InventoryReport.Id19 = data.Value;
                if (data.idInspBasic == 20)
                    InventoryReport.Id20 = data.Value;
                if (data.idInspBasic == 21)
                    InventoryReport.Id21 = data.Value;
                if (data.idInspBasic == 22)
                    InventoryReport.Id22 = data.Value;
                if (data.idInspBasic == 23)
                    InventoryReport.Id23 = data.Value;
                if (data.idInspBasic == 24)
                    InventoryReport.Id24 = data.Value;
                if (data.idInspBasic == 25)
                    InventoryReport.Id25 = data.Value;
                if (data.idInspBasic == 26)
                    InventoryReport.Id26 = data.Value;
                if (data.idInspBasic == 27)
                    InventoryReport.Id27 = data.Value;
                if (data.idInspBasic == 28)
                    InventoryReport.Id28 = data.Value;
                if (data.idInspBasic == 29)
                    InventoryReport.Id29 = data.Value;
                if (data.idInspBasic == 30)
                    InventoryReport.Id30 = data.Value;
                if (data.idInspBasic == 31)
                    InventoryReport.Id31 = data.Value;
                if (data.idInspBasic == 32)
                    InventoryReport.Id32 = data.Value;
                if (data.idInspBasic == 33)
                    InventoryReport.Id23 = data.Value;
                if (data.idInspBasic == 24)
                    InventoryReport.Id24 = data.Value;
                if (data.idInspBasic == 35)
                    InventoryReport.Id35 = data.Value;
                if (data.idInspBasic == 36)
                    InventoryReport.Id36 = data.Value;
                if (data.idInspBasic == 37)
                    InventoryReport.Id37 = data.Value;
                if (data.idInspBasic == 38)
                    InventoryReport.Id38 = data.Value;
                if (data.idInspBasic == 39)
                    InventoryReport.Id39 = data.Value;
                if (data.idInspBasic == 42)
                    InventoryReport.Id42 = data.Value;
                if (data.idInspBasic == 43)
                    InventoryReport.Id43 = data.Value;
                if (data.idInspBasic == 44)
                    InventoryReport.Id44 = data.Value;
                if (data.idInspBasic == 45)
                    InventoryReport.Id45 = data.Value;
                if (data.idInspBasic == 46)
                    InventoryReport.Id46 = data.Value;
                if (data.idInspBasic == 47)
                    InventoryReport.Id47 = data.Value;
                if (data.idInspBasic == 48)
                    InventoryReport.Id48 = data.Value;
                if (data.idInspBasic == 49)
                    InventoryReport.Id49 = data.Value;
                if (data.idInspBasic == 50)
                    InventoryReport.Id50 = data.Value;
                if (data.idInspBasic == 51)
                    InventoryReport.Id51 = data.Value;
                if (data.idInspBasic == 52)
                    InventoryReport.Id52 = data.Value;
                if (data.idInspBasic == 53)
                    InventoryReport.Id53 = data.Value;
                if (data.idInspBasic == 54)
                    InventoryReport.Id54 = data.Value;
            }

            return View("ReportInventoryRecord", InventoryReport);
        }

        public ActionResult ReportChannelCross(int? id)
        {
            var insp = db.InspectionDaily.Find(id);

            var inspList = db.CrossSectionValues.ToList().Where(ins => ins.IdInspection == id);
            ChannelCrossReport ChannelCrossReport = new ChannelCrossReport();
            ChannelCrossReport.InspectionDaily = insp;
            ChannelCrossReport.CrossSectionValues = inspList.ToList(); ;
            return View("ReportChannelCross", ChannelCrossReport);
        }

        public ActionResult ReportUnderClear(int? id)
        {
            // int id = 10;
            var insp = db.InspectionDaily.Find(id);

            var inspList = db.UnderClearanceRecord.ToList().Where(ins => ins.IdInspection == id);
            var imageUnder = db.Insp_Attach.Where(insp1 => insp1.IDInspection == id).FirstOrDefault().ImageString; 
            UnderClearReport UnderClearReport = new UnderClearReport();
            UnderClearReport.InspectionDaily=insp;
            UnderClearReport.UnderClearValues = inspList.ToList();
            UnderClearReport.image = imageUnder;
            return View("ReportUnderClear", UnderClearReport);


        }


        public ActionResult Reports(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inspd = db.InspectionDaily.Find(id);
            
            return View("Reports", inspd);
        }
        //public ActionResult Reports( int id)
        //{
        //    var inspec = db.InspectionDaily.Find(id);
        //    return View("Reports",inspec);
        //}

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ins = db.InspectionDaily.Find(id);
            var Insp_Type_Attach1 = db.Insp_Type_Attach.Include(i => i.DirectionPhotoType)
                .Include(t => t.TypePicture);
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


        public ActionResult LoadMultiFiles()
        {
            ViewBag.ok = " ";
            return View("LoadMultiFiles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoadMultiFiles(HttpPostedFileBase[] files)
        {
            List<MessageLF> mensajes = new List<MessageLF>();
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null && file.ContentLength > 0)
                    {
                        try
                        {
                            MessageLF mensaje = new MessageLF();
                            mensaje.nombre = file.FileName.ToString();
                            //string [] name = file.FileName.Split('.');
                            string name = file.FileName;
                            //var nameaux= name[0].ToString();
                            var nameaux = name.ToString();
                            var inptyata = db.Insp_Type_Attach.Where(i => i.PhotoCameraNum == nameaux).FirstOrDefault();
                            if (inptyata != null)
                            {
                                byte[] thePictureAsBytes = new byte[file.ContentLength];
                                using (BinaryReader theReader = new BinaryReader(file.InputStream))
                                {
                                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                                }
                                string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
                                inptyata.ImageString = thePictureDataAsString;
                                db.Entry(inptyata).State = EntityState.Modified;
                                await db.SaveChangesAsync();
                                mensaje.status = "OK";
                                mensajes.Add(mensaje);
                                continue;

                            }
                            else
                            {
                                mensaje.status = "Faild";
                                mensajes.Add(mensaje);
                                continue;
                            }
                            
                        }
                        catch (Exception ex)
                        {

                            ViewBag.UploadStatus = "<script type='text/javascript'>swal('¡Alert!', '"+ ex.Message.ToString() +"', 'error');</script>";
                            return View("LoadMultiFiles");
                        }
                       
                    }

                }
                ViewBag.ok = JsonConvert.SerializeObject( mensajes);
            }
            return View("LoadMultiFiles");
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
                                   "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", new { id = numinsp, area = "" }, "http"));
            //return View("Reporte", lismpdf);

            return new ViewAsPdf("ReportPDF", lismpdf)
            {
                RotativaOptions = { CustomSwitches = customSwitches,PageSize = Size.Legal }
            };
        }

        [AllowAnonymous]
        public ActionResult Footer(int? id)
        {
            Footer footer = new Footer();
            var numinsp = db.InspectionDaily.Find(id);
            var district = db.Districts.Where(d => d.NAME == numinsp.Company).FirstOrDefault();
            numinsp.Company = district.ABBR;
            footer.inspectiondaily = numinsp;
            footer.configuration = db.Configurations.FirstOrDefault();
            return View(footer);
        }


        public async Task<ActionResult> EditP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inspection = await db.InspectionDaily.FindAsync(id);
            var InspTypeAttach =  await db.Insp_Type_Attach.Where(i => i.IDInspection == inspection.IdInspection).FirstOrDefaultAsync();
            
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
