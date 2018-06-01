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
using System.Text.RegularExpressions;
using ExcelDataReader;
using System.IO;
using LMB.Helpers;

namespace LMB.Controllers
{
    [Authorize]
    public class RawDatasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: RawDatas
        public async Task<ActionResult> Index()
        {
            return View(await db.RawData.ToListAsync());
        }

        public ActionResult LoadData()
        {
            ViewBag.Files = new SelectList(CombosHelper.GetFiles(), "Value", "Text");
            return View();
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RawData rawData = await db.RawData.FindAsync(id);
            if (rawData == null)
            {
                return HttpNotFound();
            }
            return View(rawData);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RowData(HttpPostedFileBase uploadfile)
        {

            if (ModelState.IsValid)
            {
                if (uploadfile != null && uploadfile.ContentLength > 0)
                {
                    var dbContextTransaction = db.Database.BeginTransaction();
                    Message message = new Message();
                    //ExcelDataReader works on binary excel file
                    Stream stream = uploadfile.InputStream;
                    //We need to written the Interface.
                    IExcelDataReader reader = null;
                    if (uploadfile.FileName.EndsWith(".xls"))
                    {
                        //reads the excel file with .xls extension
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (uploadfile.FileName.EndsWith(".xlsx"))
                    {
                        //reads excel file with .xlsx extension
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        //Shows error if uploaded file is not Excel file
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                    var name = uploadfile.FileName.Split('.');
                    var tmp = name[0];
                    if (tmp == "Raw Data from District")
                    {
                        //treats the first row of excel file as Coluymn Names
                        //reader.IsFirstRowAsColumnNames = true;
                        //Adding reader data to DataSet()
                        DataSet result = reader.AsDataSet();
                        //result.Tables[0].Rows[0].
                        DataContext contex = new DataContext();
                        contex.Database.ExecuteSqlCommand("TRUNCATE TABLE RawDatas");
                        List<RawData> lstrdm = new List<RawData>();
                        List<InspectionDaily> linspdaily = new List<InspectionDaily>();
                        IList<RawData> ilstrdm = new List<RawData>();
                        IList<InspectionDaily> iinspdaily = new List<InspectionDaily>();
                        int loop = 0;

                        RawData rdt = new RawData();
                        InspectionDaily inspectiondaily = new InspectionDaily();
                        try
                        {
                            foreach (DataRow data in result.Tables[0].Rows)
                            {
                                if (loop == 0)
                                {
                                    loop++;
                                    continue;
                                }
                                //rdt.FileNo = data[0].ToString();
                                rdt.District = data[1].ToString();
                                rdt.County = data[2].ToString();
                                rdt.Control = data[3].ToString();
                                rdt.Section = data[4].ToString();
                                //rdt.Milepnt = data[5].ToString();
                                rdt.StrNo = data[6].ToString();
                                //rdt.DupRtOver = data[7].ToString();
                                rdt.RtStrFunc = data[8].ToString();
                                //rdt.Blanks1 = data[9].ToString();
                                rdt.RtDesign = data[10].ToString();
                                rdt.RtBusSfx = data[11].ToString();
                                rdt.RtSystem = data[12].ToString();
                                rdt.RtNo = data[13].ToString();
                                rdt.RtDir = data[14].ToString();
                                rdt.BRefMrk = data[15].ToString();
                                //if (string.IsNullOrEmpty(data[16].ToString())) { rdt.BRefMkSfx = 0; } else { rdt.BRefMkSfx = data[16].ToString()); };
                                //rdt.BRefMkSfx = data[16].ToString();
                                rdt.CIRRfMkSign = data[17].ToString();
                                rdt.BRfMkDispl = data[18].ToString();
                                rdt.PlaceCode = data[19].ToString();
                                rdt.FeatXed = data[20].ToString();
                                //rdt.CritBdg = data[21].ToString();
                                rdt.MiPtDatePr = data[22].ToString();
                                //rdt.AMiPtDateInt = data[23].ToString();
                                //rdt.Blanks2 = data[24].ToString();
                                rdt.FacCarried = data[25].ToString();
                                rdt.Location = data[26].ToString();
                                //rdt.RtMinVrtClear = data[27].ToString();
                                //if (string.IsNullOrEmpty(data[28].ToString())) { rdt.OLD16Latitude = 0; } else { rdt.OLD16Latitude = float.Parse(data[28].ToString()); };
                                //if (string.IsNullOrEmpty(data[29].ToString())) { rdt.OLD17Longitude = 0; } else { rdt.OLD17Longitude = float.Parse(data[29].ToString()); };
                                rdt.DetourLgth = data[30].ToString();
                                rdt.Toll = data[31].ToString();
                                rdt.Custodian = data[32].ToString();
                                rdt.Owner = data[33].ToString();
                                //rdt.MaintSect = data[34].ToString();
                                //rdt.ProjType = data[35].ToString();
                                if (string.IsNullOrEmpty(data[36].ToString())) { rdt.CSJWhnBlt = 0; } else { rdt.CSJWhnBlt = double.Parse(data[36].ToString()); };
                                //rdt.FuncClass = data[37].ToString();
                                rdt.YrBuilt = data[38].ToString();
                                //rdt.LanesOn = data[39].ToString();
                                //rdt.LanesUnder = data[40].ToString();
                                //if (string.IsNullOrEmpty(data[41].ToString())) { rdt.AADT = 0; } else { rdt.AADT = double.Parse(data[41].ToString()); };
                                //rdt.AADTYear = data[42].ToString();
                                //rdt.DesignLoad = data[43].ToString();
                                //rdt.ApprWidth = data[44].ToString();
                                //rdt.Median = data[45].ToString();
                                //rdt.Skew = data[46].ToString();
                                //rdt.StrFlared = data[47].ToString();
                                //rdt.TrfSafeFeat = data[48].ToString();
                                //rdt.HistSignif = data[49].ToString();
                                //rdt.NavControls = data[50].ToString();
                                //rdt.MnNavVrtClear = data[51].ToString();
                                //rdt.NavHrzClear = data[52].ToString();
                                //rdt.OperStatus = data[53].ToString();
                                //rdt.LoadType = data[54].ToString();
                                //rdt.Load1000lb = data[55].ToString();
                                //rdt.ServOnUnder = data[56].ToString();
                                //rdt.MnSpanTy = data[57].ToString();
                                //rdt.MjAprSpTy = data[58].ToString();
                                //rdt.MnAprSpTy = data[59].ToString();
                                //rdt.Culvert = data[60].ToString();
                                //rdt.TunnelTy = data[61].ToString();
                                //rdt.SubstrMSpan = data[62].ToString();
                                //rdt.SubMjAprSp = data[63].ToString();
                                //rdt.SubMnAprSp = data[64].ToString();
                                //rdt.NoMSpan = data[65].ToString();
                                //rdt.NoMjAprSp = data[66].ToString();
                                //rdt.NoMnAprSp = data[67].ToString();
                                //rdt.TotalNoSpans = data[68].ToString();
                                //rdt.TotHrzClear = data[69].ToString();
                                rdt.MaxSpLgth = data[70].ToString();
                                rdt.StrLgth = data[71].ToString();
                                //rdt.LtSdwalk = data[72].ToString();
                                //rdt.RtSdwalk = data[73].ToString();
                                rdt.RdwyWidth = data[74].ToString();
                                rdt.DeckWidth = data[75].ToString();
                                //rdt.VrtClrOver = data[76].ToString();
                                //rdt.VrtClrRefFeat = data[77].ToString();
                                //rdt.VrtClrUnder = data[78].ToString();
                                //rdt.LatClrRefFeat = data[79].ToString();
                                //rdt.RtLatClear = data[80].ToString();
                                //rdt.LtLatClear = data[81].ToString();
                                //rdt.Blanks3 = data[82].ToString();
                                //rdt.DeckCond = data[83].ToString();
                                //rdt.SuperCond = data[84].ToString();
                                //rdt.SubstrCond = data[85].ToString();
                                //rdt.ChanProt = data[86].ToString();
                                //rdt.Culvert = data[87].ToString();
                                //rdt.OperRate = data[88].ToString();
                                //rdt.RdApprCond = data[89].ToString();
                                //rdt.InvRate = data[90].ToString();
                                //rdt.StrEval = data[91].ToString();
                                //rdt.DeckGeom = data[92].ToString();
                                //rdt.UClrVrtHrz = data[93].ToString();
                                //rdt.SafeLoadCap = data[94].ToString();
                                //rdt.WaterwayAdeq = data[95].ToString();
                                //rdt.ApprRdAlign = data[96].ToString();
                                //rdt.TyWrkRepl = data[97].ToString();
                                //if (string.IsNullOrEmpty(data[98].ToString())) { rdt.LgthImprov = 0; } else { rdt.LgthImprov = double.Parse(data[98].ToString()); };
                                //rdt.SpecFlags = data[99].ToString();
                                //rdt.FHWAResvd = data[100].ToString();
                                //rdt.CostImprov1 = data[101].ToString();
                                if (string.IsNullOrEmpty(data[102].ToString())) { rdt.LastInspec = 0; } else { rdt.LastInspec = double.Parse(data[102].ToString()); };
                                //rdt.DesInspFreq = data[103].ToString();
                                //rdt.FracCritDet = data[104].ToString();
                                //rdt.UndwtrInspec = data[105].ToString();
                                //rdt.SpecialInspec = data[106].ToString();
                                //rdt.FracCritDate = data[107].ToString();
                                //rdt.UwtrInsDate = data[108].ToString();
                                //rdt.SpecInspDate = data[109].ToString();
                                //if (string.IsNullOrEmpty(data[110].ToString())) { rdt.BdgImprCost = 0; } else { rdt.BdgImprCost = double.Parse(data[110].ToString()); };
                                //if (string.IsNullOrEmpty(data[111].ToString())) { rdt.RdImprCost = 0; } else { rdt.RdImprCost = double.Parse(data[111].ToString()); };
                                //if (string.IsNullOrEmpty(data[112].ToString())) { rdt.TotProjCost = 0; } else { rdt.TotProjCost = double.Parse(data[112].ToString()); };
                                //rdt.YrImprCostEst = data[113].ToString();
                                //if (string.IsNullOrEmpty(data[114].ToString())) { rdt.BorderBdg = 0; } else { rdt.BorderBdg = double.Parse(data[114].ToString()); };
                                //rdt.BorderBdgNo = data[115].ToString();
                                //rdt.DefHwyDesn = data[116].ToString();
                                //rdt.ParlStrDesn = data[117].ToString();
                                //rdt.DirofTraffic = data[118].ToString();
                                //rdt.TempStrDesn = data[119].ToString();
                                //rdt.NHS = data[120].ToString();
                                //rdt.OldFAU = data[121].ToString();
                                //rdt.FHWAResvd_105 = data[121].ToString();
                                //rdt.YrReconstr = data[122].ToString();
                                //rdt.WidenCode = data[124].ToString();
                                //rdt.DeckTyMSp = data[125].ToString();
                                //rdt.MSpWrSurf = data[126].ToString();
                                //rdt.DeckMjAprSp = data[127].ToString();
                                //rdt.MjAprSpWrSrf = data[128].ToString();
                                //rdt.DkMnAprSp = data[129].ToString();
                                //rdt.MnAprSpWrSrf = data[130].ToString();
                                //rdt.AADTTruckPct = data[131].ToString();
                                //rdt.DesNatlNtwk = data[132].ToString();
                                //rdt.PierProtect = data[133].ToString();
                                //rdt.NBIBdgLgth = data[134].ToString();
                                //rdt.ScourCrit = data[135].ToString();
                                //if (string.IsNullOrEmpty(data[136].ToString())) { rdt.FutureAADT = 0; } else { rdt.FutureAADT = double.Parse(data[136].ToString()); };
                                //rdt.FutAADTYear = data[137].ToString();
                                //rdt.MnNavVrtClear = data[138].ToString();
                                //rdt.OrigCost = data[139].ToString();
                                //rdt.DefObs = data[140].ToString();
                                //if (string.IsNullOrEmpty(data[141].ToString())) { rdt.SuffRate = 0; } else { rdt.SuffRate = double.Parse(data[141].ToString()); };
                                //rdt.XrefPrinRtID = data[142].ToString();
                                //rdt.XrfStrFncPRt = data[143].ToString();
                                //rdt.SuffRatFlag = data[144].ToString();
                                //rdt.ScourVuln = data[145].ToString();
                                //rdt.OvHtLoadDmg = data[146].ToString();
                                //rdt.Blanks4 = data[147].ToString();
                                //rdt.XRfIRID = data[148].ToString();
                                //rdt.XRfIRStrFunc = data[149].ToString();
                                //rdt.Blanks5 = double.Parse(data[150].ToString());
                                //rdt.DistUse = data[151].ToString();
                                //rdt.AIRControl = data[152].ToString();
                                //rdt.AIRSection = data[153].ToString();
                                //rdt.AIRMilept = data[154].ToString();
                                //rdt.AIRStrNo = data[155].ToString();
                                //rdt.AIRDuplOver = data[156].ToString();
                                //rdt.AIRStrFunct = data[157].ToString();
                                //rdt.AIRDesignation = data[158].ToString();
                                //rdt.AIRBusSfx = data[159].ToString();
                                //rdt.AIRHwySys = data[160].ToString();
                                //rdt.AIRHwyNo = data[161].ToString();
                                //rdt.AIRDir = data[162].ToString();
                                //rdt.CIRRefMrk = data[163].ToString();
                                //rdt.CIRRefMkSfx = data[164].ToString();
                                //rdt.CIRRfMkSign = data[165].ToString();
                                //rdt.CIRRfMkDispl = data[166].ToString();
                                //rdt.AIRHrzClear = data[167].ToString();
                                //rdt.AIRMnVrtClear = data[168].ToString();
                                //rdt.AIRBypsLgth = data[169].ToString();
                                //rdt.AIRToll = data[170].ToString();
                                //rdt.AIRFuncClass = data[171].ToString();
                                //rdt.AIRAADT = data[172].ToString();
                                //rdt.AIRAADTYr = data[173].ToString();
                                //rdt.AIRDefHwyDes = data[174].ToString();
                                //rdt.AIRParlStr = data[175].ToString();
                                //rdt.AIRTrafDir = data[176].ToString();
                                //rdt.AIRTempStr = data[177].ToString();
                                //rdt.AIRNHS = data[178].ToString();
                                //rdt.OldFAU = data[179].ToString();
                                //rdt.AIRAADTTrkPct = data[180].ToString();
                                //rdt.AIRNatlNtwk = data[181].ToString();
                                //rdt.AIRFutAADT = data[182].ToString();
                                //rdt.AIRFAADTYr = data[183].ToString();
                                //rdt.Blanks6 = data[184].ToString();
                                //rdt.FHWAStrEval = data[185].ToString();
                                //rdt.FHWADkGeom = data[186].ToString();
                                //rdt.FHWAUClrVrtHrz = data[187].ToString();
                                //rdt.BaseHwyNet = data[188].ToString();
                                //rdt.LRSInvRte = data[189].ToString();
                                //rdt.LRSSubRte = data[190].ToString();
                                //rdt.Blanks7 = data[191].ToString();
                                if (string.IsNullOrEmpty(data[192].ToString())) { rdt.GPSLatitude = 0; } else { rdt.GPSLatitude = double.Parse(data[192].ToString()); };
                                //rdt.Blanks8 = data[193].ToString();
                                if (string.IsNullOrEmpty(data[194].ToString())) { rdt.GPSLongitude = 0; } else { rdt.GPSLongitude = double.Parse(data[194].ToString()); };
                                //rdt.GPSColMeth = data[195].ToString();
                                //rdt.MethOperRate = data[196].ToString();
                                //rdt.MethInvRate = data[197].ToString();
                                //rdt.FedLand = data[198].ToString();
                                if (string.IsNullOrEmpty(data[199].ToString())) { rdt.Latitude = 0; } else { rdt.Latitude = double.Parse(data[199].ToString()); };
                                if (string.IsNullOrEmpty(data[200].ToString())) { rdt.Longitude = 0; } else { rdt.Longitude = double.Parse(data[200].ToString()); };
                                //rdt.AIRBaseHwyNet = data[201].ToString();
                                //rdt.AIRLRSInvRte = data[202].ToString();
                                //rdt.AIRLRSSubRte = data[203].ToString();
                                //rdt.Blanks9 = data[204].ToString();
                                inspectiondaily.IDUser = 1;
                                inspectiondaily.IdClient = 1;
                                var idproject = validarcontrol(rdt.Control);
                                inspectiondaily.IdProject = idproject;
                                var numinsp = String.Format("{0}-{1}-{2}-{3}-{4}", rdt.District, rdt.County, rdt.Control, rdt.Section, rdt.StrNo);
                                var exist = db.InspectionDaily.Where(i => i.NumInspection == numinsp).FirstOrDefault();
                                //if (exist != null)
                                //{ message.mensaje = "La inpeccion ya se encuentra registrada "; message.fila = loop; break; }
                                inspectiondaily.NumInspection = numinsp;
                                inspectiondaily.DO = rdt.District;
                                inspectiondaily.Company = rdt.County;
                                inspectiondaily.Control = int.Parse(rdt.Control);
                                inspectiondaily.Section = rdt.Section;
                                inspectiondaily.Scope = rdt.FeatXed;
                                inspectiondaily.IdValueCheckList = 70;
                                inspectiondaily.IdAttach = 4;
                                inspectiondaily.Hour = rdt.YrBuilt;
                                inspectiondaily.IdStatus = 5;
                                inspectiondaily.City = rdt.FacCarried;
                                inspectiondaily.TypeInspection = 1;
                                inspectiondaily.Address = rdt.Location;
                                inspectiondaily.LatitudeIni = rdt.Latitude;
                                inspectiondaily.LongitudeIni = rdt.Longitude;
                                inspectiondaily.Structure = rdt.StrNo;
                                inspectiondaily.MaintanSection = rdt.MaintSect;
                                db.RawData.Add(rdt);
                                db.InspectionDaily.Add(inspectiondaily);
                                db.SaveChanges();
                                loop++;

                            }
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            reader.Close();
                            message.mensaje = ex.InnerException.InnerException.ToString();
                            if (message.mensaje.Contains("duplicate key"))
                            {

                                ViewBag.Script = "<script type='text/javascript'>swal('¡Alert!', 'inspection duplicate in row " + loop + "', 'error');</script>";
                            }
                            ViewBag.Files = new SelectList(CombosHelper.GetFiles(), "Value", "Text");
                            return View("LoadData");

                        }
                        dbContextTransaction.Commit();
                        reader.Close();
                        //Sending result data to View
                        return RedirectToAction("Index", "InspectionDailies");
                    }
                    else if (tmp == "Configuration Checklist")
                    {
                        DataSet result = reader.AsDataSet();
                        DataContext contex = new DataContext();
                        //contex.Database.ExecuteSqlCommand("TRUNCATE TABLE RawDatas");
                        DataTable dt = result.Tables[0];
                        var idProject = dt.Rows[0][1];


                    }


                }
            }
            else
            {
                ModelState.AddModelError("File", "Please upload your file");
            }
            ViewBag.Files = new SelectList(CombosHelper.GetFiles(), "Value", "Text");
            return RedirectToAction("LoadData", "RawDatas");
            //return View();
        }

        private int validarcontrol(string v)
        {
            var valido = 0;
            Regex Val = new Regex(@"^[a-zA-Z]");
            if (!Val.IsMatch(v, 1))
            {
                valido = 1;
            }
            else
            {
                valido = 2;
            }
            return valido;
        }

        // GET: RawDatas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RawData rawData = await db.RawData.FindAsync(id);
            if (rawData == null)
            {
                return HttpNotFound();
            }
            return View(rawData);
        }

        public ActionResult Details(RawData rawData)
        {


            if (rawData == null)
            {
                return HttpNotFound();
            }
            return View(rawData);
        }

        // GET: RawDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RawDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RawData rawData)
        {
            if (ModelState.IsValid)
            {
                db.RawData.Add(rawData);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rawData);
        }

        // GET: RawDatas/Edit/5
        public ActionResult RowData()
        {
            ViewBag.Script = "<script type='text/javascript'>swal('¡Alert!', 'Select a File!.', 'error');</script>";
            return View("LoadData");
        }

        // POST: RawDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RawData rawData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rawData).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rawData);
        }

        // GET: RawDatas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RawData rawData = await db.RawData.FindAsync(id);
            if (rawData == null)
            {
                return HttpNotFound();
            }
            return View(rawData);
        }

        // POST: RawDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RawData rawData = await db.RawData.FindAsync(id);
            db.RawData.Remove(rawData);
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