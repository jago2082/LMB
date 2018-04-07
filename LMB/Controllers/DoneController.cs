using LMB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Rotativa.MVC;
using System.Web.Mvc;

namespace LMB.Controllers
{
    [Authorize]
    public class DoneController : Controller
    {
        private DataContext db = new DataContext();

        // GET: InspectionDailies
        public async Task<ActionResult> Index()
        {
            var inspectionDaily = db.InspectionDaily.Include(i => i.InspectionState);
            return View(await inspectionDaily.Where(i => i.IdInspectionStates == 2).ToListAsync());
        }

        public async Task<ActionResult> PDFReport(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inspectionDaily = await db.InspectionDaily.FindAsync(id);
            Pdf pdf = new Pdf();
            if (inspectionDaily == null)
            {
                return HttpNotFound();
            }

            pdf.InspectionDaily = inspectionDaily;
            Insp_Type_Attach insp_Type_Attach = new Insp_Type_Attach();
            insp_Type_Attach.IDTypePicture = 2;
            insp_Type_Attach.IdDirection = 5;
            pdf.Insp_Type_Attach = insp_Type_Attach;
            return new ViewAsPdf("ReportPDF", pdf);
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
