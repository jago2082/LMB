﻿using LMB.Models;
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
using Microsoft.AspNet.Identity;
using System.Drawing;
using System.IO.Compression;

namespace LMB.Controllers
{
    [Authorize]
    [HandleError]
    public class DoneController : Controller
    {
        private DataContext db = new DataContext();
        private DataContext db2 = new DataContext();

        // GET: InspectionDailies
        public async Task<ActionResult> Index()
        {
            try
            {
                var inspectionDaily = db.InspectionDaily.Include(u => u.UserDBs);
                ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "UserName");
                return View(await inspectionDaily.Where(i => i.IdStatus == 2).ToListAsync());
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public ActionResult filterDate()
        {
            ViewBag.IDUser = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "UserName");
            return View("filterdate");
        }
        //LoadRatingE

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoadRatingE(LoadRatingReport loadratingreport)
        {
            if (ModelState.IsValid)
            {
                var inspecio = db.InspectionDaily.Find(loadratingreport.InspectionDaily.IdInspection);
                var components = db.ComponentSummaries.Find(loadratingreport.ComponentSummary.IdComponentSummary);
                components.Description = loadratingreport.ComponentSummary.Description;
                components.Item64 = loadratingreport.ComponentSummary.Item64;
                components.Item66 = loadratingreport.ComponentSummary.Item66;
                components.LRCS = loadratingreport.ComponentSummary.LRCS;
                components.ALRS = loadratingreport.ComponentSummary.ALRS;
                components.ASLRS = loadratingreport.ComponentSummary.ASLRS;
                db.Entry(components).State = EntityState.Modified;
                await db.SaveChangesAsync();
                //var valuecl = db.ValueCheckList.Where(ins => ins.IdInspection == loadratingreport.InspectionDaily.IdInspection && ins.RowIDQuestion == 1 && ins.IdChecklistQuestion == 1).FirstOrDefault();
                //valuecl.Value = Convert.ToInt32( loadratingreport.Item58);
                //db2.Entry(valuecl).State = EntityState.Modified;
                //await db2.SaveChangesAsync();
                return View("Reports", inspecio);
            }
            return View(loadratingreport);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> filterDate(FilterDate filterdate)
        {
            try
            {
                Invoice Invoice = new Invoice();
                var insp = new List<InspectionDaily>();
                if (!String.IsNullOrEmpty(filterdate.dateini))
                {
                    var fi = DateTime.Parse(filterdate.dateini);
                    var ff = DateTime.Parse(filterdate.datefin);
                    Invoice.InitialDate = fi;
                    Invoice.FinalDate = ff;
                    if (filterdate.IDUser != null && filterdate.IDUser != 0)
                    {
                        insp = db.InspectionDaily.Where(i => (i.Date > fi) && (i.Date < ff) && (i.UserDBs.IDUser == filterdate.IDUser) && (i.IdStatus==2)).ToList();
                    }
                    else
                    {
                        insp = db.InspectionDaily.Where(i =>( i.Date > fi) && ( i.Date < ff )&& (i.IdStatus == 2)).ToList();
                    }

                }
                else
                {
                    
                    insp = db.InspectionDaily.Where(i => i.IdStatus == 2).ToList();
                    Invoice.InitialDate = Convert.ToDateTime(insp.OrderByDescending(d => d.Date).FirstOrDefault().Date);
                    Invoice.FinalDate = Convert.ToDateTime(insp.OrderByDescending(d => d.Date).LastOrDefault().Date); 
                }

                

               

                    Invoice.Configuration = db.Configurations.FirstOrDefault();

                var TotalA = insp.ToList().Where(ing => ing.CommentGeneral == "A").Count();
                var TotalAA = insp.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "A").Count();
                var TotalAB = insp.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "B").Count();
                var TotalAC = insp.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "C").Count();
                var TotalAD = insp.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "D").Count();
                var TotalAE = insp.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "E").Count();
                var TotalAF = insp.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "F").Count();
                var TotalAG = insp.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "G").Count();
                var TotalAH = insp.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "H").Count();
                var TotalAX = insp.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "X").Count();

                var TotalB = insp.ToList().Where(ing => ing.CommentGeneral == "B").Count();
                var TotalBA = insp.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "A").Count();
                var TotalBB = insp.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "B").Count();
                var TotalBC = insp.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "C").Count();
                var TotalBD = insp.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "D").Count();
                var TotalBE = insp.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "E").Count();
                var TotalBF = insp.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "F").Count();
                var TotalBG = insp.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "G").Count();
                var TotalBH = insp.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "H").Count();
                var TotalBX = insp.ToList().Where(ing => ing.CommentGeneral == "B" && ing.Sync == "X").Count();
                Invoice.InspectionDaily = insp;
                Invoice.TotalA = TotalA;
                Invoice.TotalAB = TotalAB;
                Invoice.TotalAA = TotalAA;
                Invoice.TotalAC = TotalAC;
                Invoice.TotalAD = TotalAD;
                Invoice.TotalAE = TotalAE;
                Invoice.TotalAF = TotalAF;
                Invoice.TotalAG = TotalAG;
                Invoice.TotalAH = TotalAH;
                Invoice.TotalAX = TotalAX;
                Invoice.TotalB = TotalB;
                Invoice.TotalBA = TotalBA;
                Invoice.TotalBB = TotalBB;
                Invoice.TotalBC = TotalBC;
                Invoice.TotalBD = TotalBD;
                Invoice.TotalBE = TotalBE;
                Invoice.TotalBF = TotalBF;
                Invoice.TotalBG = TotalBG;
                Invoice.TotalBH = TotalBH;
                Invoice.TotalBX = TotalBX;
                if (insp == null || insp.ToList().Count() == 0)
                {
                    ViewBag.Info = null;
                    ViewBag.Info = "<script type='text/javascript'>swal('¡Info!', 'Not Data Found', 'info');</script>";
                    var inspectionDaily = db.InspectionDaily.Include(u => u.UserDBs);
                    ViewBag.Userdb = new SelectList(CombosHelper.GetUsersDB(), "IDUser", "UserName");
                    return View("Index", await inspectionDaily.Where(i => i.IdStatus == 2).ToListAsync());
                }

                string header = Server.MapPath("~/PDF/Header.html");//Path of PrintFooter.html File
                string customSwitches = string.Format("--header-html  \"{0}\" " +
                                       "--header-spacing \"0\" " +
                                       "--footer-html \"{1}\" " +
                                       "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", "http"));

                string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";

                //return View("ReportBill", insp);

                return new ViewAsPdf("ReportBill", Invoice)
                {

                    // FileName = "firstPdf.pdf",
                    // CustomSwitches = footer
                    RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(15, 10, 10, 10), PageSize = Rotativa.Core.Options.Size.Letter }
                };
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<ActionResult> IndexF(int id)
        {
            List<BridgeInspectionFollowUp> listtbr = new List<BridgeInspectionFollowUp>();
            var bridgeInspectionFollowUps = db.BridgeInspectionFollowUps.Include(b => b.InspectionRaiting)
                .Include(b => b.RecommendationType).Include(b => b.ReferenceFeatureType)
                .Where(i => i.IdInspection == id);
            var inspection = db.InspectionDaily.Find(id);
            
            var descr = db.InspectionBasicRegistryValue.Where(ind => ind.IdInspection == id && ind.idInspBasic == 38).FirstOrDefault();

            if (bridgeInspectionFollowUps.ToList().Count()>0)
            {
                foreach (var item in bridgeInspectionFollowUps)
                {
                    if (descr == null)
                        item.Description = "";
                    else
                    {
                        item.InspectionDescription = descr.Value;
                        item.InspectionOwner = inspection.Owner;
                        item.IdInspection = id;
                    }

                }
            }
            else
            {
                listtbr.Add(new BridgeInspectionFollowUp());
                foreach (var item in listtbr)
                {
                    if (descr!=null)
                    {
                        item.InspectionDescription = descr.Value;
                        item.InspectionOwner = inspection.Owner;
                        item.IdInspection = id;
                    }
                    else
                    {
                        item.InspectionDescription = "";
                        item.InspectionOwner = "";
                        item.IdInspection = id;
                    }
                    
                }
                ViewBag.idinspect = id;
                return View(listtbr.ToList());
            }
           
            ViewBag.idinspect = id;
            return View(await bridgeInspectionFollowUps.ToListAsync());
        }

        public async Task<ActionResult> IndexBS(int id)
        {
          //  List<ReportSummarySheet> listtbr = new List<ReportSummarySheet>();

            ReportSummarySheet reportf = new ReportSummarySheet();
            reportf.InspectionDaily = await db.InspectionDaily.FindAsync(id);

            reportf.BridgeSummaryComments = await db.BridgeSummaryComments
                .Where(i => i.IdInspection == id).ToListAsync();


            reportf.BridgeSummaryComponent = await db.BridgeSummaryComponent
                .Where(i => i.IdInspection == id).ToListAsync();

        
                
                ViewBag.idinspect = id;
             //  return View(listtbr.ToList());
            
            return View(reportf);
        }


        public async Task<ActionResult> IndexIR(int? id, int IDIns)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<QuestionDetails> QuestionDetails = new List<QuestionDetails>();
            var questions = db2.CheckListQuestion.Where(i => i.CheckListSection.IdCheckListSection == id);
            var ValueCheckList = db.ValueCheckList.Where(i => i.IdInspection == IDIns && i.RowIDQuestion == id);
            foreach (var dato in questions)
            {
                QuestionDetails QuestionDetail = new QuestionDetails();
                QuestionDetail.Question = dato.Question;
                foreach (var item in ValueCheckList)
                {
                   
                    if (dato.IdCheckListQuestion == item.IdChecklistQuestion)
                    {
                        QuestionDetail.value = item.Value;
                    }
                    else
                    {
                        QuestionDetail.value = 0;
                    }
                    
                }
                QuestionDetails.Add(QuestionDetail);
            }
            
            var inspection = db.InspectionDaily.Find(id);


           // ValueCheckList valueCheckList = await db.ValueCheckList.FindAsync(id);
            if (ValueCheckList == null)
            {
                return HttpNotFound();
            }
           

            return View(QuestionDetails.ToList());
        }

        public async Task<ActionResult> UnderTable(int? id, int IDIns)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UnderClearValues = db.UnderClearValues.Where(i => i.IdInspection == IDIns && i.IdInspection == id);
            var inspection = db.InspectionDaily.Find(id);


            // ValueCheckList valueCheckList = await db.ValueCheckList.FindAsync(id);
            if (UnderClearValues == null)
            {
                return HttpNotFound();
            }


            return View(await UnderClearValues.ToListAsync());
        }
        

        public async Task<ActionResult> IndexInv(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var inspectionBasicRegistryValue = await db.InspectionBasicRegistryValue
                .Include(i => i.InspectionBasicRegistries).Where(v => v.IdInspection == id).ToListAsync();

            return View(inspectionBasicRegistryValue);

            //var result = db.InspectionBasicRegistryValue.Where(i =>i.IdInspection == id).ToList();
            //rptInspeccionBRV rptInspeccionBRV = new rptInspeccionBRV();
            //rptInspeccionBRV.InspectionBasicRegistryValues = result;
            //var insbr = db.InspectionBasicRegistry;
            //foreach (var item in rptInspeccionBRV.InspectionBasicRegistryValues)
            //{
            //    rptInspeccionBRV.InspectionBasicRegistries = insbr.Where(i => i.IdInspBasic == item.idInspBasic).FirstOrDefault();
            //}
            //return View (rptInspeccionBRV);
            //var result = (from u in db.InspectionBasicRegistryValue
            //              join c in db.InspectionBasicRegistry on u.idInspBasic equals c.IdInspBasic
            //               select new
            //              {
            //                   id=u.IdInspectionBV,
            //                  insp=u.IdInspection,
            //                  value = u.Value,
            //                  descri = c.NameQuestion,
            //              }).Where(i => i.insp == id).ToList();
            //if (result != null)
            //{

            //    foreach (var item in result)
            //    {

            //    }

            //}
        }

        public async Task<ActionResult> IndexCS(int id)
        {
            var ComponentSummaries = db.ComponentSummaries
                .Include(r => r.InspectionRaiting)
                .Where(i => i.IdInspection == id);
            foreach (var item in ComponentSummaries)
            {
                item.IdInspection = id;
            }
            ViewBag.idinspect = id;
            return View(await ComponentSummaries.ToListAsync());

        }
        public async Task<ActionResult> Seccions(int id)
        {
            var secciones = db.CheckListSection;
         
              //  .Where(i => i.IdClient == id);

            ViewBag.idinspect = id;
            return View(await secciones.ToListAsync());

        }

        public async Task<ActionResult> UnderList(int id)
        {
            var secciones = db.UnderClearValues.Where(y=>y.IdInspection == id).OrderByDescending(x=> x.PSN);

            //  .Where(i => i.IdClient == id);

            ViewBag.idinspect = id;
            return View(await secciones.ToListAsync());

        }
        

        public ActionResult LoadBridgeInspectionRecord(int? id)
        {
            var insp = db.InspectionDaily.Include(d => d.District)
                .Include(c => c.Counties);
            //var insp = db.InspectionDaily.Find(id);
            var inspList = db.ValueCheckList.ToList().Where(ins => ins.IdInspection == id);
            var config = db.Configurations.FirstOrDefault();
            ConfigurationApp configurationapp = new ConfigurationApp();
            configurationapp.configuration = config;
            LRReport lrreport = new LRReport();
            lrreport.LoadRatingReport.Reports = db.Reports.Find(4);
            lrreport.InspectionDaily = insp.Where(i => i.IdInspection == id).FirstOrDefault();
            if (lrreport == null)
            {
                return HttpNotFound();
            }

            string header = Server.MapPath("~/PDF/Header.html");//Path of PrintFooter.html File
            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", "http"));

            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";


            // return View("ReportBridgeInspectionRecord", LoadRatingReport);

            return new ViewAsPdf("ReportBridgeInspectionRecord", lrreport)
            {

                //  FileName = "firstPdf.pdf",
                // CustomSwitches = footer
                RotativaOptions = { CustomSwitches = footer, PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 }, PageSize = Rotativa.Core.Options.Size.Letter }
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> BridgeIRE(LoadRatingCheckList loadratingcheckList)
        {
            var inspList = db.ValueCheckList.ToList().Where(ins => ins.IdInspection == loadratingcheckList.InspectionDaily.IdInspection);
            

            foreach (var dato in inspList)
            {
                if (dato.IdChecklistQuestion == 1)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val1);
                if (dato.IdChecklistQuestion == 2)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val2);
                if (dato.IdChecklistQuestion == 3)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val3);
                if (dato.IdChecklistQuestion == 4)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val4);
                if (dato.IdChecklistQuestion == 5)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val5);
                if (dato.IdChecklistQuestion == 6)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val6);
                if (dato.IdChecklistQuestion == 7)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val7);
                if (dato.IdChecklistQuestion == 8)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val8);
                if (dato.IdChecklistQuestion == 9)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val9);
                if (dato.IdChecklistQuestion == 10)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val10);
                if (dato.IdChecklistQuestion == 11)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val11);
                if (dato.IdChecklistQuestion == 12)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val12);
                if (dato.IdChecklistQuestion == 13)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val13);
                if (dato.IdChecklistQuestion == 14)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val14);
                if (dato.IdChecklistQuestion == 15)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val15);
                if (dato.IdChecklistQuestion == 16)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val16);
                if (dato.IdChecklistQuestion == 17)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val17);
                if (dato.IdChecklistQuestion == 18)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val18);
                if (dato.IdChecklistQuestion == 19)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val19);
                if (dato.IdChecklistQuestion == 20)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val20);
                if (dato.IdChecklistQuestion == 22)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val22);
                if (dato.IdChecklistQuestion == 23)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val23);
                if (dato.IdChecklistQuestion == 24)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val24);
                //if (item59 == 10)
                //    LoadRatingReport.val25 = "N";
                //else
                //    LoadRatingReport.val25 = Convert.ToString(item59);

                if (dato.IdChecklistQuestion == 25)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val25);
                if (dato.IdChecklistQuestion == 26)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val26);
                if (dato.IdChecklistQuestion == 27)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val27);
                if (dato.IdChecklistQuestion == 28)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val28);
                if (dato.IdChecklistQuestion == 29)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val29);
                if (dato.IdChecklistQuestion == 30)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val30);
                if (dato.IdChecklistQuestion == 31)
                    dato.Value = Convert.ToInt16(loadratingcheckList.va32);
                if (dato.IdChecklistQuestion == 32)
                    dato.Value = Convert.ToInt16(loadratingcheckList.va33);
                if (dato.IdChecklistQuestion == 33)
                    dato.Value = Convert.ToInt16(loadratingcheckList.va34);
                if (dato.IdChecklistQuestion == 34)
                    dato.Value = Convert.ToInt16(loadratingcheckList.va35);
                if (dato.IdChecklistQuestion == 35)
                    dato.Value = Convert.ToInt16(loadratingcheckList.va36);
                if (dato.IdChecklistQuestion == 36)
                    dato.Value = Convert.ToInt16(loadratingcheckList.va37);
                if (dato.IdChecklistQuestion == 37)
                    dato.Value = Convert.ToInt16(loadratingcheckList.va38);
                if (dato.IdChecklistQuestion == 38)
                    dato.Value = Convert.ToInt16(loadratingcheckList.va39);
                //if (item60 == 10)
                //    LoadRatingReport.val40 = "N";
                //else
                //    dato.Value = Convert.ToInt16(loadratingcheckList.val40);

                if (dato.IdChecklistQuestion == 44)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val41);
                if (dato.IdChecklistQuestion == 45)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val42);
                if (dato.IdChecklistQuestion == 46)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val43);
                if (dato.IdChecklistQuestion == 47)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val44);
                if (dato.IdChecklistQuestion == 48)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val45);
                if (dato.IdChecklistQuestion == 49)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val46);
                //if (item61 == 10)
                //    LoadRatingReport.val47 = "N";
                //else
                //    dato.Value = Convert.ToInt16(loadratingcheckList.val47);

                if (dato.IdChecklistQuestion == 39)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val48);
                if (dato.IdChecklistQuestion == 40)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val49);
                if (dato.IdChecklistQuestion == 41)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val50);
                if (dato.IdChecklistQuestion == 42)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val51);
                if (dato.IdChecklistQuestion == 43)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val52);

                //if (item62 == 10)
                //    LoadRatingReport.val53 = "N";
                //else
                //    dato.Value = Convert.ToInt16(loadratingcheckList.val53);

                if (dato.IdChecklistQuestion == 50)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val54);
                if (dato.IdChecklistQuestion == 51)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val55);
                if (dato.IdChecklistQuestion == 52)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val56);
                if (dato.IdChecklistQuestion == 53)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val57);
                if (dato.IdChecklistQuestion == 54)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val58);
                if (dato.IdChecklistQuestion == 55)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val59);
                if (dato.IdChecklistQuestion == 56)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val60);
                if (dato.IdChecklistQuestion == 57)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val61);
                if (dato.IdChecklistQuestion == 58)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val62);
                if (dato.IdChecklistQuestion == 59)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val59a);
                //if (item65 == 10)
                //    LoadRatingReport.val63 = "N";
                //else
                //    dato.Value = Convert.ToInt16(loadratingcheckList.val63);

                if (dato.IdChecklistQuestion == 64)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val64);
                if (dato.IdChecklistQuestion == 65)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val65);
                //if (Appraisal == 10)
                //    LoadRatingReport.val66 = "N";
                //else
                //    dato.Value = Convert.ToInt16(loadratingcheckList.val66);
                if (dato.IdChecklistQuestion == 66)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val67);
                if (dato.IdChecklistQuestion == 67)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val68);
                if (dato.IdChecklistQuestion == 68)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val69);
                if (dato.IdChecklistQuestion == 69)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val70);
                if (dato.IdChecklistQuestion == 70)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val71);
                //if (Misce == 10)
                //    LoadRatingReport.val72 = "N";
                //else
                //    dato.Value = Convert.ToInt16(loadratingcheckList.val72);
                if (dato.IdChecklistQuestion == 60)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val73);
                if (dato.IdChecklistQuestion == 61)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val74);
                if (dato.IdChecklistQuestion == 62)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val75);
                if (dato.IdChecklistQuestion == 63)
                    dato.Value = Convert.ToInt16(loadratingcheckList.val76);
                //if (item36 == 10)
                //    LoadRatingReport.val77 = "N";
                //else
                //    dato.Value = Convert.ToInt16(loadratingcheckList.val77);
                db.Entry(dato).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            var inspd = db2.InspectionDaily.Find(inspList.FirstOrDefault().IdInspection);
            return View("Reports", inspd);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ReportIRE(InventoryReport inventoryreport)
        //{
        //    db.Entry(inventoryreport)
        //}
        public ActionResult LoadReportBridgeInspection(int? id, int? accion)
        {
            var insp = db.InspectionDaily.Include(d => d.District)
                .Include(c => c.Counties).ToList();
            var inspList = db.ValueCheckList.ToList().Where(ins => ins.IdInspection == id);
            var ImageList = db.Insp_Question_Attach.ToList().Where(ins => ins.IDValueChecklist == id);
            int? total = 0;

            LoadRatingCheckList LoadRatingReport = new LoadRatingCheckList();
            LoadRatingReport.Insp_Question_Attach = ImageList.ToList();
            LoadRatingReport.InspectionDaily = insp.Where(i => i.IdInspection == id).FirstOrDefault();
            var distrcode = string.Format("{0}", LoadRatingReport.InspectionDaily.DO);
            var distric = db.Districts.Where(d => d.NAME.Equals(distrcode)).FirstOrDefault();
            LoadRatingReport.InspectionDaily.DO = distric.ABBR;
            var countrycode = LoadRatingReport.InspectionDaily.Company.TrimStart('0');
            int code = int.Parse(countrycode);
            var country = db.Counties.Find(code);
            //var country = db.Counties.Where(d => d.IdCountries==  int.Parse(countrycode)).FirstOrDefault();
            LoadRatingReport.InspectionDaily.Company = country.Description;

            LoadRatingReport.Reports = db.Reports.Find(4);
            LoadRatingReport.Configuration = db.Configurations.FirstOrDefault();
            LoadRatingReport.User = UsersHelper.finduser(User.Identity.GetUserName());
            if (inspList.Count() > 0)
            {
                int item59 = Convert.ToInt16(db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 2).Min(value => value.Value));
                int item60 = Convert.ToInt16(db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 3).Min(value => value.Value));
                int item61 = Convert.ToInt16(db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 5).Min(value => value.Value));
                int item62 = Convert.ToInt16(db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 4).Min(value => value.Value));
                int item65 = Convert.ToInt16(db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 9).Min(value => value.Value));

                int item36 = Convert.ToInt16(db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 10).Min(value => value.Value));
                int Appraisal = Convert.ToInt16(db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 11).Min(value => value.Value));
                int Misce = Convert.ToInt16(db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 12).Min(value => value.Value));

                foreach (var dato in inspList)
                {
                    if (dato.IdChecklistQuestion == 1)
                        LoadRatingReport.val1 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 2)
                        LoadRatingReport.val2 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 3)
                        LoadRatingReport.val3 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 4)
                        LoadRatingReport.val4 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 5)
                        LoadRatingReport.val5 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 6)
                        LoadRatingReport.val6 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 7)
                        LoadRatingReport.val7 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 8)
                        LoadRatingReport.val8 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 9)
                        LoadRatingReport.val9 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 10)
                        LoadRatingReport.val10 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 11)
                        LoadRatingReport.val11 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 12)
                        LoadRatingReport.val12 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 13)
                        LoadRatingReport.val13 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 14)
                        LoadRatingReport.val14 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 15)
                        LoadRatingReport.val15 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 16)
                        LoadRatingReport.val16 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 17)
                        LoadRatingReport.val17 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 18)
                        LoadRatingReport.val18 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 19)
                        LoadRatingReport.val19 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 20)
                        LoadRatingReport.val21 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 22)
                        LoadRatingReport.val22 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 23)
                        LoadRatingReport.val23 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 24)
                        LoadRatingReport.val24 = Convert.ToString(dato.Value);
                    if (item59 == 10)
                        LoadRatingReport.val25 = "N";
                    else
                        LoadRatingReport.val25 = Convert.ToString(item59);

                    if (dato.IdChecklistQuestion == 25)
                        LoadRatingReport.val26 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 26)
                        LoadRatingReport.val27 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 27)
                        LoadRatingReport.val28 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 28)
                        LoadRatingReport.val29 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 29)
                        LoadRatingReport.val30 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 30)
                        LoadRatingReport.va31 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 31)
                        LoadRatingReport.va32 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 32)
                        LoadRatingReport.va33 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 33)
                        LoadRatingReport.va34 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 34)
                        LoadRatingReport.va35 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 35)
                        LoadRatingReport.va36 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 36)
                        LoadRatingReport.va37 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 37)
                        LoadRatingReport.va38 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 38)
                        LoadRatingReport.va39 = Convert.ToString(dato.Value);
                    if (item60 == 10)
                        LoadRatingReport.val40 = "N";
                    else
                        LoadRatingReport.val40 = Convert.ToString(item60);

                    if (dato.IdChecklistQuestion == 44)
                        LoadRatingReport.val41 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 45)
                        LoadRatingReport.val42 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 46)
                        LoadRatingReport.val43 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 47)
                        LoadRatingReport.val44 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 48)
                        LoadRatingReport.val45 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 49)
                        LoadRatingReport.val46 = Convert.ToString(dato.Value);
                    if (item61 == 10)
                        LoadRatingReport.val47 = "N";
                    else
                        LoadRatingReport.val47 = Convert.ToString(item61);

                    if (dato.IdChecklistQuestion == 39)
                        LoadRatingReport.val48 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 40)
                        LoadRatingReport.val49 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 41)
                        LoadRatingReport.val50 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 42)
                        LoadRatingReport.val51 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 43)
                        LoadRatingReport.val52 = Convert.ToString(dato.Value);

                    if (item62 == 10)
                        LoadRatingReport.val53 = "N";
                    else
                        LoadRatingReport.val53 = Convert.ToString(item62);

                    if (dato.IdChecklistQuestion == 50)
                        LoadRatingReport.val54 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 51)
                        LoadRatingReport.val55 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 52)
                        LoadRatingReport.val56 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 53)
                        LoadRatingReport.val57 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 54)
                        LoadRatingReport.val58 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 55)
                        LoadRatingReport.val59 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 56)
                        LoadRatingReport.val60 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 57)
                        LoadRatingReport.val61 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 58)
                        LoadRatingReport.val62 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 59)
                        LoadRatingReport.val59a = Convert.ToString(dato.Value);
                    if (item65 == 10)
                        LoadRatingReport.val63 = "N";
                    else
                        LoadRatingReport.val63 = Convert.ToString(item65);

                    if (dato.IdChecklistQuestion == 64)
                        LoadRatingReport.val64 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 65)
                        LoadRatingReport.val65 = Convert.ToString(dato.Value);
                    if (Appraisal == 10)
                        LoadRatingReport.val66 = "N";
                    else
                        LoadRatingReport.val66 = Convert.ToString(Appraisal);
                    if (dato.IdChecklistQuestion == 66)
                        LoadRatingReport.val67 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 67)
                        LoadRatingReport.val68 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 68)
                        LoadRatingReport.val69 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 69)
                        LoadRatingReport.val70 = Convert.ToString(dato.Value);
                    if (dato.IdChecklistQuestion == 70)
                        LoadRatingReport.val71 = Convert.ToString(dato.Value);
                    if (Misce == 10)
                        LoadRatingReport.val72 = "N";
                    else
                        LoadRatingReport.val72 = Convert.ToString(Misce);
                    if (dato.IdChecklistQuestion == 60)
                        LoadRatingReport.val73 = Convert.ToString(dato.Value);total = total + dato.Value;
                    if (dato.IdChecklistQuestion == 61)
                        LoadRatingReport.val74 = Convert.ToString(dato.Value); total = total + dato.Value;
                    if (dato.IdChecklistQuestion == 62)
                        LoadRatingReport.val75 = Convert.ToString(dato.Value); total = total + dato.Value;
                    if (dato.IdChecklistQuestion == 63)
                        LoadRatingReport.val76 = Convert.ToString(dato.Value); total = total + dato.Value;
                    if (item36 == 10)
                        LoadRatingReport.val77 = "N";
                    else
                        LoadRatingReport.val77 = Convert.ToString(total);
                }
            }
            if (LoadRatingReport == null)
            {
                return HttpNotFound();
            }

            string header = Server.MapPath("~/PDF/Header.html");//Path of PrintFooter.html File
            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", "http"));

            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";


            if (accion == 1)
            {
                return View("ReportBridgeInspectionRecordE", LoadRatingReport);
               
            }
            else if (accion == 2)
            {

                return new ViewAsPdf("ReportBridgeInspectionRecord", LoadRatingReport)
                {

                    RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(15, 10, 15, 10), PageSize = Rotativa.Core.Options.Size.Letter }
                };
            }


            return new ViewAsPdf("ReportBridgeInspectionRecord", LoadRatingReport)
            {

                RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(15, 10, 15, 10), PageSize = Rotativa.Core.Options.Size.Letter }
            };

        }


        public ActionResult LoadRating(int? id, int? accion)
        {
            // int id = 5;
            var insp = db.InspectionDaily.Find(id);
            
            var compone = db.ComponentSummaries.Where(ins => ins.IdInspection == id);

            var inspList = db.ValueCheckList.ToList().Where(ins => ins.IdInspection == id);
            var section = db.CheckListSection.ToList();
            var config = db.Configurations.FirstOrDefault();
            LoadRatingReport LoadRatingReport = new LoadRatingReport();
            if (compone == null)
            {
                LoadRatingReport.ComponentSummary.LRCS = false;
                LoadRatingReport.ComponentSummary.ALRS = false;
                LoadRatingReport.ComponentSummary.ASLRS = false;
            }
            else
            {
                LoadRatingReport.ComponentSummary = compone.FirstOrDefault();
            }
            LoadRatingReport.InspectionDaily = insp;
           // LoadRatingReport.CheckListSections = section;
            LoadRatingReport.Configuration = config;
            LoadRatingReport.Reports = db.Reports.Find(2);
            if (inspList.Count() > 0)
            {
                int item58 = 0;
                var ite58 = db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 1 && ins.IdChecklistQuestion == 1);
                    if (ite58== null)
                    item58 = Convert.ToInt16(ite58.FirstOrDefault().Value);

                var item59 = db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 2).Min(value => value.Value);
                var item60 =db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 3).Min(value => value.Value);
                var item62 = db.ValueCheckList.Where(ins => ins.IdInspection == id && ins.RowIDQuestion == 4).Min(value => value.Value);

               // LoadRatingReport.ValuesCheclist = inspList.ToList();

                if (Convert.ToString(item58) != "")
                    LoadRatingReport.Item58 = Convert.ToString(item58);
                if (item59 == 10)
                    LoadRatingReport.Item59 = "N";
                else
                    LoadRatingReport.Item59 = Convert.ToString(item59);
                if (item60 == 10)
                    LoadRatingReport.Item60 = "N";
                else
                    LoadRatingReport.Item60 = Convert.ToString(item60);
                if (item62 == 10)
                    LoadRatingReport.Item62 = "N";
                else
                    LoadRatingReport.Item62 = Convert.ToString(item60);
            }
            if (LoadRatingReport == null)
            {
                return HttpNotFound();
            }

            string header = Server.MapPath("~/PDF/Header.html");//Path of PrintFooter.html File
            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", "http"));

            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";


            if (accion ==1)
            { return View("LoadRatingE", LoadRatingReport); }
            else
            
                if (accion == 2)
                {
                    return new ViewAsPdf("LoadRating", LoadRatingReport)
                    {

                        //  FileName = "firstPdf.pdf",
                        // CustomSwitches = footer
                        RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(5, 10, 0, 8), PageSize = Rotativa.Core.Options.Size.Letter }
                    };
                }
            return new ActionAsPdf("LoadRating", LoadRatingReport)
            {

                FileName = "ReportSummarySheet_" + id + ".pdf",
                // CustomSwitches = footer
                RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(5, 10, 0, 8), PageSize = Rotativa.Core.Options.Size.Letter }
            };
        




        }
        


        public ActionResult ReportBill(string dateI, string dateF, string user)
        {

         
                var insp = new List<InspectionDaily>();
                if (!String.IsNullOrEmpty(dateI))
                {
                    var fi = DateTime.Parse(dateI);
                    var ff = DateTime.Parse(dateF);
                    if (!String.IsNullOrEmpty(user) && user != "0")
                    {
                        insp = db.InspectionDaily.Where(i => i.Date > fi && i.Date < ff && i.UserDBs.UserName == user).ToList();
                    }
                    else
                    {
                        insp = db.InspectionDaily.Where(i => i.Date > fi && i.Date < ff).ToList();
                    }

                }
                else
                {
                    insp = db.InspectionDaily.ToList();
                }



                
            var TotalA = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A").Count();
            var TotalAA = db.InspectionDaily.ToList().Where(ing => ing.CommentGeneral == "A" && ing.Sync == "A").Count();
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


            if (insp == null)
            {
                return HttpNotFound();
            }

            string header = Server.MapPath("~/PDF/Header.html");//Path of PrintFooter.html File
            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", "http"));

            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";

            // return View("ReportInventoryRecord", InventoryReport);

            return new ActionAsPdf("ReportBill", insp)
            
            {

                 FileName = "firstPdf.pdf",
                // CustomSwitches = footer
                RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(10, 10, 10, 10), PageSize = Rotativa.Core.Options.Size.Letter }
            };


        }



        [HttpPost]
        public async Task<ActionResult> SaveRFU(BridgeInspectionFollowUp bridgeInspectionFollowUp)
        {
            if (ModelState.IsValid)
            {
                db.BridgeInspectionFollowUps.Add(bridgeInspectionFollowUp);
                await db.SaveChangesAsync();
                var inspd = db.InspectionDaily.Find(bridgeInspectionFollowUp.IdInspection);
                return View("Reports", inspd);
            }

            ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description", bridgeInspectionFollowUp.InspectionRaitingType);
            ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "idvalue", bridgeInspectionFollowUp.IdRecommendationType);
            ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description", bridgeInspectionFollowUp.IdReferenceFeatureType);
            return View(bridgeInspectionFollowUp);
        }

        public async Task<ActionResult> ReportInspFollowUp(int id, int? accion)
        {
            ViewBag.Idinspection = id;
            ReportInspFollowUp reportf = new ReportInspFollowUp();
            ReportInspFollowUpE reportfe = new ReportInspFollowUpE();
            reportf.InspectionDaily = await db.InspectionDaily.FindAsync(id);
            var distrcode = string.Format("{0}", reportf.InspectionDaily.DO);
            var distric = db.Districts.Where(d => d.NAME.Equals(distrcode)).FirstOrDefault();


            reportf.InspectionDaily.DO = distric.ABBR;
            var countrycode = reportf.InspectionDaily.Company.TrimStart('0');
            int code = int.Parse(countrycode);
            var country = db.Counties.Find(code);
            var dato1 = db.FollowUpOptional.Where(d => d.IdInspection.Equals(id)).FirstOrDefault();
            var dato2 = db.FollowUpOptional.Where(d => d.IdInspection.Equals(id)).FirstOrDefault();
            if (dato1 == null)
                reportf.Dato1 = "";
            else
                reportf.Dato1 = dato1.Data1;
            if (dato2 == null)
                reportf.Dato2 = "";
            else
                reportf.Dato2 = dato2.Data2;

            reportf.InspectionDaily.Company = country.Description;
            reportf.Reports = db.Reports.Find(3);
            reportf.Configuration = db.Configurations.FirstOrDefault();
            reportf.Usuario = UsersHelper.finduser(User.Identity.GetUserName());

            reportf.BridgeInspectionFollowUps = await db.BridgeInspectionFollowUps.Include(b => b.InspectionRaiting)
                .Include(b => b.RecommendationType)
                .Include(b => b.ReferenceFeatureType)
                .Where(i => i.IdInspection == id).ToListAsync();

            var inspListNo = db.InspectionBasicRegistryValue.ToList().Where(ins => ins.IdInspection == id && ins.idInspBasic==38).FirstOrDefault();
            if (inspListNo == null)
            {
                reportf.ComentGeneral = "";
                /*    ViewBag.Info = "<script type='text/javascript'>swal('¡Alert!', 'No found inspection in Inspection Basic Registry Value', 'error');</script>"; 
                    var inspd = db.InspectionDaily.Find(id);
                    return View("Reports", inspd);*/
            }
            else
            {
                reportf.ComentGeneral = inspListNo.Value;
            }
            // var inspListNo = db.NoveltyInspection.ToList().Where(ins => ins.IdInspection == id);

            // reportf.NoveltyInspection = inspListNo.ToList();

            // return View("ReportInspFollowUp", reportf);

            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";

            if (accion==1)
            {
                //ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description", reportf.BridgeInspectionFollowUps.FirstOrDefault().InspectionRaitingType);
                //ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "idvalue", reportf.BridgeInspectionFollowUps.FirstOrDefault().IdRecommendationType);
                //ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description", reportf.BridgeInspectionFollowUps.FirstOrDefault().IdReferenceFeatureType);
                //ViewBag.InspectionRaitingTypeS = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description");
                //ViewBag.IdRecommendationTypeS = new SelectList(db.RecommendationType, "IdRecommendationType", "idvalue");
                //ViewBag.IdReferenceFeatureTypeS = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description");
                ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description");
                ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "idvalue");
                ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description");
                return View("ReportInspFollowUpET", reportf);
            }
            else
                if (accion==2)
                {
                return new ViewAsPdf("ReportInspFollowUp", reportf)
                {

                    //  FileName = "firstPdf.pdf",
                    // CustomSwitches = footer
                    RotativaOptions = { MinimumFontSize = 11, PageMargins = new Margins(13, 15, 5, 8), PageSize = Rotativa.Core.Options.Size.Letter }
                };
            }
            return new ActionAsPdf("ReportInspFollowUp", reportf)
            {

                FileName = "ReportInspFollowUp" + id + ".pdf",
                // CustomSwitches = footer
                RotativaOptions = { MinimumFontSize = 11, PageMargins = new Margins(13, 15, 5, 8), PageSize = Rotativa.Core.Options.Size.Letter }
            };
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateReportS(ReportSummarySheet reportsummarysheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportsummarysheet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reportsummarysheet);
        }


        public async Task<ActionResult> ReportSummarySheet(int id, int? accion)

        {
          //  accion = 1;
            ReportSummarySheet reportf = new ReportSummarySheet();
            reportf.InspectionDaily = await db.InspectionDaily.FindAsync(id);
            var distrcode = string.Format("{0}", reportf.InspectionDaily.DO);
            var distric = db.Districts.Where(d => d.NAME.Equals(distrcode)).FirstOrDefault();
            reportf.InspectionDaily.DO = distric.ABBR;
            var countrycode = reportf.InspectionDaily.Company.TrimStart('0');
            int code = int.Parse(countrycode);
            var country = db.Counties.Find(code);
            reportf.InspectionDaily.Company = country.Description;
            reportf.Reports = db.Reports.Find(1);
            reportf.Configuration = db.Configurations.FirstOrDefault();
            reportf.Usuario = UsersHelper.finduser(User.Identity.GetUserName());

            reportf.BridgeSummaryComments = await db.BridgeSummaryComments
                .Where(i => i.IdInspection == id).ToListAsync();


            reportf.BridgeSummaryComponent = await db.BridgeSummaryComponent
                .Where(i => i.IdInspection == id).ToListAsync();

             string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";

        if (accion == 1)
        {
            return View("ReportSummarySheetE", reportf);
        }
        else
          if (accion == 2)
        {
            return new ViewAsPdf("ReportSummarySheet", reportf)
            {

                //  FileName = "firstPdf.pdf",
                // CustomSwitches = footer
                RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(5, 10, 5, 10), PageSize = Rotativa.Core.Options.Size.Letter }
            };
        }
        else
        {
            return new ActionAsPdf("ReportSummarySheet", reportf)
            {

                FileName = "ReportSummarySheet_" + id + ".pdf",
                // CustomSwitches = footer
                RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(5, 10, 5, 10), PageSize = Rotativa.Core.Options.Size.Letter }
            };
        }

        }

        public ActionResult DownLoadData( int id)
        {
            var archive = Server.MapPath("~/archive.zip");
            var temp = Server.MapPath("~/temp");
            List<Image> listimg = new List<Image>();
            ImageHelper help = new ImageHelper();

            if (!System.IO.Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }

            if (System.IO.File.Exists(archive))
            {
                System.IO.File.Delete(archive);
            }
           
            // empty the temp folder
            Directory.EnumerateFiles(temp).ToList().ForEach(f => System.IO.File.Delete(f));
            var images = db.Insp_Attach.Where(i => i.IDInspection == id).ToList();
            foreach (var item in images)
            {
                var tmp1 = help.Base64ToImage(item.ImageString);
                if (tmp1 != null)
                {
                    listimg.Add(tmp1);
                }
                tmp1 = null;
            }
            listimg.ForEach(f => System.IO.File.Copy(archive, Path.Combine(temp, Path.GetFileName(archive))));
            ZipFile.CreateFromDirectory(temp, archive);
            return File(archive, "application/zip", "archive.zip");

        }



        public ActionResult ReportStructuralCondition()
        {
            return View("ReportStructuralCondition");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReportIRE(InventoryReport inventoryreport)
        {
            var insp = db.InspectionDaily.Find(inventoryreport.IdInspection);

            var inspList = db.InspectionBasicRegistryValue.Where(ins => ins.IdInspection == inventoryreport.IdInspection).ToList().OrderBy(x => x.idInspBasic);
            if (inspList != null)
            {
                foreach (var data in inspList)
                {
                    if (data.idInspBasic == 1)
                        data.Value =  (Convert.ToBoolean(inventoryreport.Id1) == true) ? "1" : "0"; 
                    if (data.idInspBasic == 2)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id2) == true) ? "1" : "0";
                    if (data.idInspBasic == 3)
                        data.Value = inventoryreport.Id3;
                    if (data.idInspBasic == 4)
                        data.Value = inventoryreport.Id4;
                    if (data.idInspBasic == 5)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id5) == true) ? "1" : "0";
                    if (data.idInspBasic == 6)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id6) == true) ? "1" : "0";
                    if (data.idInspBasic == 7)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id7) == true) ? "1" : "0";
                    if (data.idInspBasic == 8)
                        data.Value = inventoryreport.Id8;
                    if (data.idInspBasic == 9)
                        data.Value = inventoryreport.Id9;
                    if (data.idInspBasic == 10)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id10) == true) ? "1" : "0";
                    if (data.idInspBasic == 11)
                        data.Value = inventoryreport.Id11;
                    if (data.idInspBasic == 12)
                        data.Value = inventoryreport.Id12;
                    if (data.idInspBasic == 13)
                        data.Value = inventoryreport.Id13;
                    if (data.idInspBasic == 14)
                        data.Value = inventoryreport.Id14;
                    if (data.idInspBasic == 15)
                        data.Value = inventoryreport.Id15;
                    if (data.idInspBasic == 16)
                        data.Value = inventoryreport.Id16;
                    if (data.idInspBasic == 17)
                        data.Value = inventoryreport.Id17;
                    if (data.idInspBasic == 18)
                        data.Value = inventoryreport.Id18;
                    if (data.idInspBasic == 19)
                        data.Value = inventoryreport.Id19;
                    if (data.idInspBasic == 20)
                        data.Value = inventoryreport.Id20;
                    if (data.idInspBasic == 21)
                        data.Value = inventoryreport.Id21;
                    if (data.idInspBasic == 22)
                        data.Value = inventoryreport.Id22;
                    if (data.idInspBasic == 23)
                        data.Value = inventoryreport.Id23;
                    if (data.idInspBasic == 24)
                        data.Value = inventoryreport.Id24;
                    if (data.idInspBasic == 25)
                        data.Value = inventoryreport.Id25;
                    if (data.idInspBasic == 26)
                        data.Value = inventoryreport.Id26;
                    if (data.idInspBasic == 27)
                        data.Value = inventoryreport.Id27;
                    if (data.idInspBasic == 28)
                        data.Value = inventoryreport.Id28;
                    if (data.idInspBasic == 29)
                        data.Value = inventoryreport.Id29;
                    if (data.idInspBasic == 30)
                        data.Value = inventoryreport.Id30;
                    if (data.idInspBasic == 31)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id31) == true) ? "1" : "0";
                    if (data.idInspBasic == 32)
                        data.Value = inventoryreport.Id32;
                    if (data.idInspBasic == 33)
                        data.Value = inventoryreport.Id33;
                    if (data.idInspBasic == 34)
                        data.Value = inventoryreport.Id34;
                    if (data.idInspBasic == 35)
                        data.Value = inventoryreport.Id35;
                    if (data.idInspBasic == 36)
                        data.Value = inventoryreport.Id36;
                    if (data.idInspBasic == 37)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id37) == true) ? "1" : "0";
                    if (data.idInspBasic == 38)
                        data.Value = inventoryreport.Id38;
                    if (data.idInspBasic == 39)
                        data.Value = inventoryreport.Id39;
                    if (data.idInspBasic == 42)
                        data.Value = inventoryreport.Id42;
                    if (data.idInspBasic == 43)
                        data.Value = inventoryreport.Id43;
                    if (data.idInspBasic == 44)
                        data.Value = inventoryreport.Id44;
                    if (data.idInspBasic == 45)
                        data.Value = inventoryreport.Id45;
                    if (data.idInspBasic == 46)
                        data.Value = inventoryreport.Id46;
                    if (data.idInspBasic == 47)
                        data.Value = inventoryreport.Id47;
                    if (data.idInspBasic == 48)
                        data.Value = inventoryreport.Id48;
                    if (data.idInspBasic == 49)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id49) == true) ? "1" : "0";
                    if (data.idInspBasic == 50)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id50) == true) ? "1" : "0";
                    if (data.idInspBasic == 51)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id51) == true) ? "1" : "0";
                    if (data.idInspBasic == 52)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id52) == true) ? "1" : "0";
                    if (data.idInspBasic == 53)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id53) == true) ? "1" : "0";
                    if (data.idInspBasic == 54)
                        data.Value = (Convert.ToBoolean(inventoryreport.Id54) == true) ? "1" : "0";
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            var inspd = db2.InspectionDaily.Find(inspList.FirstOrDefault().IdInspection);
            return View("Reports", inspd);
            
        }

        public ActionResult ReportInventoryRecord(int? id, int? accion)
        {
            // int id = 5;
            var insp = db.InspectionDaily.Find(id);

            var inspList = db.InspectionBasicRegistryValue.ToList().Where(ins => ins.IdInspection == id);


            InventoryReport InventoryReport = new InventoryReport();


            InventoryReport.IdInspection = insp.IdInspection;

            var distrcode = string.Format("{0}", insp.DO);
            var distric = db.Districts.Where(d => d.NAME.Equals(distrcode)).FirstOrDefault();
            InventoryReport.District = distric.ABBR;

            var countrycode = insp.Company.TrimStart('0');
            int code = int.Parse(countrycode);
            var country = db.Counties.Find(code);
            InventoryReport.County = country.Description;
            InventoryReport.Reports = db.Reports.Find(5);
            InventoryReport.Configuration = db.Configurations.FirstOrDefault();
            InventoryReport.Usuario = UsersHelper.finduser(User.Identity.GetUserName());

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
           if (insp.Date.HasValue)
            InventoryReport.DateInspectionEnd = Convert.ToDateTime(insp.Date).ToString("yyyy/MM/dd");
            if (inspList != null)
            {
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
            }

            if (InventoryReport == null)
            {
                return HttpNotFound();
            }

            string header = Server.MapPath("~/PDF/Header.html");//Path of PrintFooter.html File
            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", "http"));

            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";


            if (accion == 1)

            {
                return View("ReportInventoryRecordE", InventoryReport);
            }
            else
                if (accion == 2)
            {
                return new ViewAsPdf("ReportInventoryRecord", InventoryReport)
                {

                    //  FileName = "firstPdf.pdf",
                    // CustomSwitches = footer
                    //PageWidth = 180, PageHeight = 297, 

                    RotativaOptions = { MinimumFontSize = 12, PageMargins = new Margins(5, 10, 3, 5), PageSize = Rotativa.Core.Options.Size.Letter }
                };
            }
            else
            {
                return new ActionAsPdf("ReportInventoryRecord", InventoryReport)
                {
                    FileName = "ReportInventoryRecord" + id + ".pdf",
                    // CustomSwitches = footer
                    //PageWidth = 180, PageHeight = 297, 

                    RotativaOptions = { MinimumFontSize = 12, PageMargins = new Margins(5, 10, 3, 5), PageSize = Rotativa.Core.Options.Size.Letter }
                };
            }

        }
        /// <summary>


        public ActionResult ReportChannelCross(int? id)
        {
            var insp = db.InspectionDaily.Find(id);

            var inspList = db.CrossSectionValues.ToList().Where(ins => ins.IdInspection == id);
            ChannelCrossReport ChannelCrossReport = new ChannelCrossReport();
            ChannelCrossReport.InspectionDaily = insp;

            var distrcode = string.Format("{0}", insp.DO);
            var distric = db.Districts.Where(d => d.NAME.Equals(distrcode)).FirstOrDefault();
            insp.DO = distric.ABBR;

            var countrycode = insp.Company.TrimStart('0');
            int code = int.Parse(countrycode);
            var country = db.Counties.Find(code);
            insp.Company = country.Description;
            ChannelCrossReport.Reports = db.Reports.Find(7);
            ChannelCrossReport.Configuration = db.Configurations.FirstOrDefault();
            ChannelCrossReport.Usuario = UsersHelper.finduser(User.Identity.GetUserName());

            ChannelCrossReport.CrossSectionValues = inspList.ToList();

            if (ChannelCrossReport == null)
            {
                return HttpNotFound();
            }

            string header = Server.MapPath("~/PDF/Header.html");//Path of PrintFooter.html File
            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", "http"));

            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";



            return new ViewAsPdf("ReportChannelCross", ChannelCrossReport)
            {
                //  FileName = "firstPdf.pdf",
                // CustomSwitches = footer
                RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(10, 10, 10, 10), PageSize = Rotativa.Core.Options.Size.Letter }
            };
        }

        public ActionResult ReportUnderClear(int? id, int? accion)
        {
            // int id = 10;
            var insp = db.InspectionDaily.Find(id);
            // var inspListFeat = db.UnderClearanceRecord.ToList().Where(ins => ins.IdInspection == id).Select(ins => ins.FeatureXed).Distinct();
            var inspListFeat = db.UnderClearValues.Where(ins => ins.IdInspection == id).GroupBy(ins => ins.FeatureXed).Select(group => group.FirstOrDefault());
            var inspListPSN = db.UnderClearValues.Where(ins => ins.IdInspection == id).GroupBy(ins => ins.PSN).Select(group => group.FirstOrDefault());

            var inspList = db.UnderClearValues.ToList().Where(ins => ins.IdInspection == id).OrderBy(ins => ins.PSN);
            var imageUnder = String.Empty;
            if (!String.IsNullOrEmpty(db.Insp_Attach.Where(insp1 => insp1.IDInspection == id).FirstOrDefault().ImageString))
            {
                imageUnder = db.Insp_Attach.Where(insp1 => insp1.IDInspection == id).FirstOrDefault().ImageString;
            }
            UnderClearReport UnderClearReport = new UnderClearReport();


            var distrcode = string.Format("{0}", insp.DO);
            var distric = db.Districts.Where(d => d.NAME.Equals(distrcode)).FirstOrDefault();
            insp.DO = distric.ABBR;


            var countrycode = insp.Company.TrimStart('0');
            int code = int.Parse(countrycode);
            var country = db.Counties.Find(code);
            insp.Company = country.Description;
            UnderClearReport.Reports = db.Reports.Find(6);
            UnderClearReport.Configuration = db.Configurations.FirstOrDefault();
            UnderClearReport.Usuario = UsersHelper.finduser(User.Identity.GetUserName());
            UnderClearReport.UnderClearValues = inspList.ToList();

            UnderClearReport.InspectionDaily = insp;
            UnderClearReport.UnderClearValuesPSN = inspListPSN.ToList();
            UnderClearReport.UnderClearValuesFeat = inspListFeat.ToList();
            UnderClearReport.image = imageUnder;
            if (UnderClearReport == null)
            {
                return HttpNotFound();
            }

            string header = Server.MapPath("~/PDF/Header.html");//Path of PrintFooter.html File
            string customSwitches = string.Format("--header-html  \"{0}\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", "http"));

            string footer = "--footer-right \"Date: [date] [time]\" " + "--footer-center \"Page: [page] of [toPage]\" --footer-line --footer-font-size \"9\" --footer-spacing 5 --footer-font-name \"calibri light\"";


            //return View("ReportUnderClear", UnderClearReport);
            if (accion == 1)
            {
                return View("ReportUnderClearE", UnderClearReport);
            }
            else
                if (accion == 2)
            {

                return new ViewAsPdf("ReportUnderClear", UnderClearReport)
                {
                    FileName = "ReportUnderClear" + id + ".pdf",
                   
                    // CustomSwitches = footer
                    RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(10, 10, 10, 10), PageSize = Rotativa.Core.Options.Size.Letter }
                };
            }
            return new ActionAsPdf("ReportUnderClear", UnderClearReport)
            {

                  FileName = "firstPdf.pdf",
                // CustomSwitches = footer
                RotativaOptions = { CustomSwitches = footer, PageMargins = new Margins(10, 10, 10, 10), PageSize = Rotativa.Core.Options.Size.Letter }
            };
        

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


        public async Task<ActionResult> EditCS(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ComponentSummary = await db.ComponentSummaries.Where(i =>  i.IdInspection==id).FirstOrDefaultAsync();
            if (ComponentSummary == null)
            {

                return HttpNotFound();
            }
            ViewBag.InspectionRaiting = new SelectList(CombosHelper.InspectionRaiting(), "InspectionRaitingType", "Description",ComponentSummary.InspectionRaiting.InspectionRaitingType);
            return View("EditCS", ComponentSummary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCS(ComponentSummary componentSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(componentSummary).State = EntityState.Modified;
                await db.SaveChangesAsync();
                var inspd = db.InspectionDaily.Find(componentSummary.IdInspection);
                return View("Reports", inspd);
            }
            ViewBag.InspectionRaiting = new SelectList(CombosHelper.InspectionRaiting(), "InspectionRaitingType", "Description", componentSummary.InspectionRaiting.InspectionRaitingType);
            return View(componentSummary);
        }

        public async Task<ActionResult> DeleteCS(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComponentSummary componentSummary = await db.ComponentSummaries.Where(c =>c.IdInspection== id)
                .FirstOrDefaultAsync();
            if (componentSummary == null)
            {
                return HttpNotFound();
            }
            return View("DeleteCS", componentSummary);
        }




        public async Task<ActionResult> EditF(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bridgeInspectionFollowUp = await db.BridgeInspectionFollowUps.FindAsync(id);
            if (bridgeInspectionFollowUp == null)
            {
                return HttpNotFound();
            }
            ViewBag.idinspect = db.BridgeInspectionFollowUps.Find(id).IdInspection;
            ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description", bridgeInspectionFollowUp.InspectionRaitingType);
            ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "Description", bridgeInspectionFollowUp.IdRecommendationType);
            ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description", bridgeInspectionFollowUp.IdReferenceFeatureType);
            return View("EditF", bridgeInspectionFollowUp);
        }

        // POST: BridgeInspectionFollowUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditF(BridgeInspectionFollowUp bridgeInspectionFollowUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bridgeInspectionFollowUp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                var inspd = db.InspectionDaily.Find(bridgeInspectionFollowUp.IdInspection);
                return View("IndexF", inspd);
            }
            ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description", bridgeInspectionFollowUp.InspectionRaitingType);
            ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "Description", bridgeInspectionFollowUp.IdRecommendationType);
            ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description", bridgeInspectionFollowUp.IdReferenceFeatureType);
            return View(bridgeInspectionFollowUp);
        }

        [HttpPost]
        public async Task<ActionResult> Save(string id, string InspectionDescription, string InspectionOwner)
        {
            int idis = int.Parse(id);
            var inspectionDaily = db.InspectionDaily.Find(idis);
            var inspectionBasicRegistryValue = db2.InspectionBasicRegistryValue
                .Where(b => b.IdInspection == idis && b.idInspBasic == 38).FirstOrDefault();
            if (inspectionBasicRegistryValue == null)
            {
                inspectionBasicRegistryValue = new InspectionBasicRegistryValue();
                inspectionBasicRegistryValue.IdInspection = idis;
                inspectionBasicRegistryValue.idInspBasic = 38;
                inspectionBasicRegistryValue.Value = InspectionDescription;
                db2.InspectionBasicRegistryValue.Add(inspectionBasicRegistryValue);
                db2.SaveChanges();
                inspectionDaily.Owner = InspectionOwner;
                db.Entry(inspectionDaily).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["msg"] = "";
                ViewBag.Info = "<script type='text/javascript'>swal('¡Success!', 'Saved Data', 'success');</script>";
                var inspd = db.InspectionDaily.Find(idis);
                return View("Reports", inspd);
            }
            inspectionDaily.Owner = InspectionOwner;
            inspectionBasicRegistryValue.Value = InspectionDescription;
            db2.Entry(inspectionBasicRegistryValue).State = EntityState.Modified;
            await db2.SaveChangesAsync();
            db.Entry(inspectionDaily).State = EntityState.Modified;
            await db.SaveChangesAsync();
            var bridgeInspectionFollowUps = db.BridgeInspectionFollowUps.Include(b => b.InspectionRaiting)
                .Include(b => b.RecommendationType).Include(b => b.ReferenceFeatureType)
                .Where(i => i.IdInspection == idis);
            ViewBag.idinspect = idis;
            return View("IndexF", await bridgeInspectionFollowUps.ToListAsync());
        }

        public async Task<ActionResult> SaveCS(string id, string Description, bool ALRS, string CSJ, string desing, bool LRCS, bool ASLRS, string Item66, string Item64 )
        {
 
            int idis = int.Parse(id);
            var inspectionDaily = db.InspectionDaily.Find(idis);
            var inspectionBasicRegistryValue = db2.InspectionBasicRegistryValue
                .Where(b => b.IdInspection == idis && b.idInspBasic == 38).FirstOrDefault();
            if (inspectionBasicRegistryValue == null)
            {
                inspectionBasicRegistryValue = new InspectionBasicRegistryValue();
                inspectionBasicRegistryValue.IdInspection = idis;
                inspectionBasicRegistryValue.idInspBasic = 38;
                inspectionBasicRegistryValue.Value = Description;
                db2.InspectionBasicRegistryValue.Add(inspectionBasicRegistryValue);
                db2.SaveChanges();
                await db.SaveChangesAsync();
                TempData["msg"] = "";
                ViewBag.Info = "<script type='text/javascript'>swal('¡Success!', 'Saved Data', 'success');</script>";
               // var inspd = db.InspectionDaily.Find(idis);
               // return View("Reports", inspd);
            }
            var componentsummaries = db2.ComponentSummaries
            .Where(b => b.IdInspection == idis).FirstOrDefault();
            if (componentsummaries == null)
            {
                componentsummaries = new ComponentSummary();
                componentsummaries.IdInspection = idis;
                componentsummaries.Item64 = Item64;
                componentsummaries.Description = Description;
                componentsummaries.CSJ = CSJ;
                componentsummaries.Item66 = Item64;
                componentsummaries.Loadof = Description;
                componentsummaries.ALRS = ALRS;
                componentsummaries.ASLRS = ASLRS;
                componentsummaries.LRCS = LRCS;
                
                db2.ComponentSummaries.Add(componentsummaries);
                db2.SaveChanges();
                await db.SaveChangesAsync();
                TempData["msg"] = "";
                ViewBag.Info = "<script type='text/javascript'>swal('¡Success!', 'Saved Data', 'success');</script>";
              //  var inspd = db.InspectionDaily.Find(idis);
              //  return View("Reports", inspd);
            }

            inspectionBasicRegistryValue.Value = Description;
            db2.Entry(inspectionBasicRegistryValue).State = EntityState.Modified;
            await db2.SaveChangesAsync();
        
            componentsummaries.IdInspection = idis;
            componentsummaries.Item64 = Item64;
            componentsummaries.Description = Description;
            componentsummaries.CSJ = CSJ;
            componentsummaries.Item66 = Item64;
            componentsummaries.Loadof = Description;
            componentsummaries.ALRS = ALRS;
            componentsummaries.ASLRS = ASLRS;
            componentsummaries.LRCS = LRCS;
            db2.Entry(componentsummaries).State = EntityState.Modified;
          
            await db.SaveChangesAsync();
            /*       var bridgeInspectionFollowUps = db.BridgeInspectionFollowUps.Include(b => b.InspectionRaiting)
                       .Include(b => b.RecommendationType).Include(b => b.ReferenceFeatureType)
                       .Where(i => i.IdInspection == idis);*/
            var inspd = db.InspectionDaily.Find(idis);
            return View("Reports", inspd);
        }

        public ActionResult CreateF(int id)
        {
            BridgeInspectionFollowUp bfollowup = new BridgeInspectionFollowUp();
            var inspectionBasicRegistryValue = db.InspectionBasicRegistryValue
                .Where(b => b.IdInspection == id && b.idInspBasic == 38).FirstOrDefault();
            bfollowup.IdInspection = id;
            if (inspectionBasicRegistryValue == null)

                    bfollowup.InspectionDescription = "";
                else

                    bfollowup.InspectionDescription = inspectionBasicRegistryValue.Value;
            var inpd = db.InspectionDaily.Find(id);
            bfollowup.InspectionOwner = inpd.Owner;
            ViewBag.Idinspection = id;
            ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description");
            ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "Description");
            ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description");
            return View(bfollowup);
        }


        [HttpPost]
        public async Task<ActionResult> saveRIF(ReportInspFollowUpE reportinspfollowUp)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    return View("Index");

                }
                catch (Exception)
                {

                    return View("Index");
                }
            }
            return View("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateF(BridgeInspectionFollowUp bridgeInspectionFollowUp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.BridgeInspectionFollowUps.Add(bridgeInspectionFollowUp);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    
                }
                var inspd = db.InspectionDaily.Find(bridgeInspectionFollowUp.IdInspection);
                return View("Reports", inspd);
            }

            ViewBag.InspectionRaitingType = new SelectList(db.InspectionRaiting, "InspectionRaitingType", "Description", bridgeInspectionFollowUp.InspectionRaitingType);
            ViewBag.IdRecommendationType = new SelectList(db.RecommendationType, "IdRecommendationType", "Description", bridgeInspectionFollowUp.IdRecommendationType);
            ViewBag.IdReferenceFeatureType = new SelectList(db.ReferenceFeatureType, "IdReferenceFeatureType", "Description", bridgeInspectionFollowUp.IdReferenceFeatureType);
            return View(bridgeInspectionFollowUp);
        }

        public ActionResult CreateFD(int id)
        {
            ViewBag.Idinspection = id;
            FollowUpOther followUpOther = new FollowUpOther();
            followUpOther.inspectionId = id;
            return View(followUpOther);
        }

        public ActionResult CreateCS(int id)
        {
            ViewBag.Idinspection = id;
            ComponentSummary ComponentSummary = new ComponentSummary();
            var description = db.InspectionBasicRegistryValue.ToList().Where(ins => ins.IdInspection == id && ins.idInspBasic == 38).FirstOrDefault();
            if (description == null)
            {
                ComponentSummary.Description = "";
            }
            else
            {
                ComponentSummary.Description = description.Value;
            }
            ComponentSummary.IdInspection = id;
            ViewBag.InspectionRaiting = new SelectList(CombosHelper.InspectionRaiting(), "InspectionRaitingType", "Description");
            return View(ComponentSummary);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateBS(BridgeSummaryComponent bridgeSummaryComponent)
        {
            if (ModelState.IsValid)
            {
                db.BridgeSummaryComponent.Add(bridgeSummaryComponent);
                await db.SaveChangesAsync();
                var inspd = db.InspectionDaily.Find(bridgeSummaryComponent.IdInspection);
                ViewBag.InspectionRaiting = new SelectList(CombosHelper.InspectionRaiting(), "InspectionRaitingType", "Description");
                return View("IndexBS", inspd);
            }
            ViewBag.InspectionRaiting = new SelectList(CombosHelper.InspectionRaiting(), "InspectionRaitingType", "Description");
            return View(bridgeSummaryComponent);

        }
        public ActionResult CreateBS(int id)
        {
            ViewBag.Idinspection = id;

            ReportSummarySheet ReportSummarySheet = new ReportSummarySheet();
            var comments = db.BridgeSummaryComments.ToList().Where(ins => ins.IdInspection==id);
            if (comments != null)
            {
                ReportSummarySheet.BridgeSummaryComments= comments.ToList();
            }

            var data = db.BridgeSummaryData.ToList().Where(ins => ins.IdInspection==id).FirstOrDefault();
            if (data != null)
            {
                ReportSummarySheet.BridgeSummaryData = data;
            }

            var component = db.BridgeSummaryComponent.ToList().Where(ins => ins.IdInspection == id);
            if (component != null)
            {
                ReportSummarySheet.BridgeSummaryComponent = component.ToList();
            }

            ReportSummarySheet.InspectionDaily.IdInspection = id;
            ViewBag.ReportSummarySheet = new SelectList(CombosHelper.InspectionRaiting(), "InspectionRaitingType", "Description");
            return View(ReportSummarySheet);

        }

        public ActionResult CreateCross(int id)
        {
            ViewBag.Idinspection = id;
            CrossSectionValues CrossSectionValues = new CrossSectionValues();
            CrossSectionValues.IdInspection = id;
            ViewBag.ReferenceFeatureType = new SelectList(CombosHelper.ReferenceFeatureType(), "IdReferenceFeatureType", "Description");
            return View(CrossSectionValues);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCS(ComponentSummary componentSummary)
        {
            if (ModelState.IsValid)
            {
                db.ComponentSummaries.Add(componentSummary);
                await db.SaveChangesAsync();
                var inspd = db.InspectionDaily.Find(componentSummary.IdInspection);
                ViewBag.InspectionRaiting = new SelectList(CombosHelper.InspectionRaiting(), "InspectionRaitingType", "Description");
                return View("Reports", inspd);
            }
            ViewBag.InspectionRaiting = new SelectList(CombosHelper.InspectionRaiting(), "InspectionRaitingType", "Description");
            return View(componentSummary);

        }
        // POST: BridgeInspectionFollowUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateFD(FollowUpOther followUpOther)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.followUpOther.Add(followUpOther);
        //        await db.SaveChangesAsync();
        //        var inspd = db.InspectionDaily.Find(followUpOther.inspectionId);
        //        return View("Reports", inspd);
        //    }

        //    return View(followUpOther);
        //}

        // GET: BridgeInspectionFollowUps/Delete/5

        public async Task<ActionResult> DeleteF(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BridgeInspectionFollowUp bridgeInspectionFollowUp = await db.BridgeInspectionFollowUps
                .Include(b => b.InspectionRaiting)
                .Include(b => b.RecommendationType)
                .Include(b => b.ReferenceFeatureType)
                .Where(i => i.IdBridgeInspectionFollowUp == id).FirstOrDefaultAsync();
            if (bridgeInspectionFollowUp == null)
            {
                return HttpNotFound();
            }
            return View("DeleteF", bridgeInspectionFollowUp);
        }


        // POST: BridgeInspectionFollowUps/Delete/5
        // [HttpPost, ActionName("DeleteF")]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BridgeInspectionFollowUp bridgeInspectionFollowUp = await db.BridgeInspectionFollowUps.FindAsync(id);
            db.BridgeInspectionFollowUps.Remove(bridgeInspectionFollowUp);
            await db.SaveChangesAsync();
            var inspd = db.InspectionDaily.Find(bridgeInspectionFollowUp.IdInspection);
            return View("Reports", inspd);
        }
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
                            string[] name = file.FileName.Split('.');
                            //string name = file.FileName;
                            var nameaux = name[0].ToString();
                            //var nameaux = name.ToString();
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
                                mensaje.status = "Failed";
                                mensajes.Add(mensaje);
                                continue;
                            }

                        }
                        catch (Exception ex)
                        {

                            ViewBag.UploadStatus = "<script type='text/javascript'>swal('¡Alert!', '" + ex.Message.ToString() + "', 'error');</script>";
                            return View("LoadMultiFiles");
                        }

                    }

                }
                ViewBag.ok = JsonConvert.SerializeObject(mensajes);
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
            var district = db.Districts.Where(d => d.NAME == inspd.DO).FirstOrDefault();
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
                    inspectionDaily.Struc = inspectd.Structure;
                    inspectionDaily.Section  = inspectd.Section;
                    inspectionDaily.Control = inspectd.Control;
                    inspectionDaily.configuration = db.Configurations.FirstOrDefault();
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
                                   "--footer-center \"0\" " +
                                   "--header-spacing \"0\" " +
                                   "--footer-html \"{1}\" " +
                                   "--header-font-size \"10\" ", header, Url.Action("Footer", "Done", new { id = numinsp, area = "" }, "http"));
            //return View("Reporte", lismpdf);

            return new ViewAsPdf("ReportPDF", lismpdf)
            {

                RotativaOptions = { PageMargins = new Margins(10,8,0, 8), PageSize = Rotativa.Core.Options.Size.Letter }
            };
        }

        [AllowAnonymous]
        public ActionResult Footer(int? id)
        {
            Footer footer = new Footer();
            var numinsp = db.InspectionDaily.Find(id);
            var district = db.Districts.Where(d => d.NAME == numinsp.DO).FirstOrDefault();
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

            var auxInspTypeAttach = db.Insp_Type_Attach.Include(t => t.TypePicture)
                .Include(d => d.DirectionPhotoType);
            var InspTypeAttach = auxInspTypeAttach.Where(i => i.IDAttach == id).FirstOrDefault();
            var inspection = await db.InspectionDaily.Where(i => i.IdInspection == InspTypeAttach.IDInspection).FirstOrDefaultAsync();


            if (InspTypeAttach == null)
            {
                return HttpNotFound();
            }
            InspTypeAttach.numinspection = inspection.NumInspection;
            ViewBag.IDTypePicture = new SelectList(CombosHelper.TypePicture(), "IdTypePicture", "Description", InspTypeAttach.TypePicture.IdTypePicture);
            ViewBag.IdDirectionPhotoType = new SelectList(CombosHelper.PothoType(), "IdDirectionPhotoType", "Description", InspTypeAttach.DirectionPhotoType.IdDirectionPhotoType);
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
                if (file != null && file.ContentLength > 0)
                {
                    string theFileName = Path.GetFileName(file.FileName);
                    byte[] thePictureAsBytes = new byte[file.ContentLength];
                    using (BinaryReader theReader = new BinaryReader(file.InputStream))
                    {
                        thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                    }

                    Image_orig_attach imgoriattach = new Image_orig_attach();
                    imgoriattach.IDAttach = insptypeattach.IDAttach;
                    imgoriattach.IdDirectionPhotoType = insptypeattach.IdDirectionPhotoType;
                    imgoriattach.IDInspection = insptypeattach.IDInspection;
                    imgoriattach.IDTypePicture = insptypeattach.IDTypePicture;
                    imgoriattach.ImageString = insptypeattach.ImageString;
                    imgoriattach.InspectionDailys = insptypeattach.InspectionDailys;
                    imgoriattach.PhotoCameraNum = insptypeattach.PhotoCameraNum;
                    imgoriattach.TypePicture = insptypeattach.TypePicture;
                    db2.Image_orig_attachs.Add(imgoriattach);
                    await db2.SaveChangesAsync();
                    ////

                    using (MemoryStream ms = new MemoryStream(thePictureAsBytes, 0, thePictureAsBytes.Length))
                    {
                        using (Image img = Image.FromStream(ms))
                        {
                            float aspect = img.Width / (float)img.Height;
                            int newWidth, newHeight;
                            int BOXWIDTH = 300;
                            newWidth = (int)(BOXWIDTH * aspect);
                            newHeight = (int)(newWidth / aspect);

                            int w = newWidth;
                            int h = newHeight;

                            using (Bitmap b = new Bitmap(img, new System.Drawing.Size(w, h)))
                            {
                                using (MemoryStream ms2 = new MemoryStream())
                                {
                                    b.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    thePictureAsBytes = ms2.ToArray();
                                }
                            }
                        }
                    }

                    ////
                    string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
                    insptypeattach.ImageString = thePictureDataAsString;

                }
                try
                {
                    db.Entry(insptypeattach).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    ViewBag.Info = "<script type='text/javascript'>swal('¡Alert!', '" + ex.Message.ToString() + "', 'error');</script>";
                }

                return RedirectToAction("Index");
            }
            ViewBag.IDTypePicture = new SelectList(CombosHelper.TypePicture(), "IdTypePicture", "Description");
            ViewBag.IdDirectionPhotoType = new SelectList(CombosHelper.PothoType(), "IdDirectionPhotoType", "Description");
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
