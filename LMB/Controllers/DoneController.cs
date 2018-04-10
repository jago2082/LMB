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
            var inspectionDaily = db.InspectionDaily.Include(i => i.InspectionState)
                .Include(t => t.Insp_Type_Attach);
            return View(await inspectionDaily.Where(i => i.IdInspectionStates == 2).ToListAsync());
        }

        public ActionResult PDFReport(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inspectionDaily = db.InspectionDaily.Include(i => i.InspectionState)
                .Include(tp => tp.Insp_Type_Attach.TypePicture)
                .Include(t => t.Insp_Type_Attach.DirectionPhotoType)
                .Where(j => j.IdInspection ==id).ToList();


            if (inspectionDaily == null)
            {
                return HttpNotFound();
            }


            //return View("ReportPDF", inspectionDaily);
            return new ViewAsPdf("ReportPDF", inspectionDaily);
            //{
            //    RotativaOptions = { CustomSwitches = "--print-media-type --header-center \"text\"" ,PageSize=Rotativa.Core.Options.Size.Legal}
            //};
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
