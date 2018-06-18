using LMB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Config(Configuration configuration)
        {
            if (ModelState.IsValid)
            {
                if (configuration != null)
                {
                    
                    HttpPostedFileBase file = Request.Files[0];
                    HttpPostedFileBase file1 = Request.Files[1];
                    if (file != null && file.ContentLength > 0)
                    {
                        string theFileName = Path.GetFileName(file.FileName);
                        byte[] thePictureAsBytes = new byte[file.ContentLength];
                        using (BinaryReader theReader = new BinaryReader(file.InputStream))
                        {
                            thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                        }
                        string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
                        configuration.ImageSing = thePictureDataAsString;
                    }
                    if (file1 != null && file1.ContentLength > 0)
                    {
                        string theFileName = Path.GetFileName(file1.FileName);
                        byte[] thePictureAsBytes = new byte[file1.ContentLength];
                        using (BinaryReader theReader = new BinaryReader(file1.InputStream))
                        {
                            thePictureAsBytes = theReader.ReadBytes(file1.ContentLength);
                        }
                        string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
                        configuration.ImageContract = thePictureDataAsString;

                    }
                    db.Entry(configuration).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                

            }
            return RedirectToAction("Index");
        }
    }
}