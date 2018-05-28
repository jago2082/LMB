using LMB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMB.Controllers
{
    public class ConfigurationAppsController : Controller
    {

        private DataContext db = new DataContext();

        // GET: ConfigurationApps
        public ActionResult Index()
        {
            ConfigurationApp configapp = new ConfigurationApp();
            configapp.configuration = db.Configurations.FirstOrDefault();
            configapp.reports = db.Reports.ToList(); 
            return View(configapp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Config(Configuration configuration)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files[0];
                HttpPostedFileBase file1 = Request.Files[1];
                string theFileName = Path.GetFileName(file.FileName);
                byte[] thePictureAsBytes = new byte[file.ContentLength];
                using (BinaryReader theReader = new BinaryReader(file.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                }
                string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}