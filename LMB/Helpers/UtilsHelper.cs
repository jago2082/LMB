using LMB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LMB.Helpers
{
    public class UtilsHelper
    {
        private static DataContext db = new DataContext();
        public static List<marker> GetMarcadores()
        {
            
            List<marker> markers = new List<marker>(); 
            var inspectionDaily = db.InspectionDaily.Include(i => i.InspectionState)
                .Include(u => u.UserDBs);
            foreach (var item in inspectionDaily.Where(i => i.IdStatus != 2).ToList())
            {
                marker marker = new marker();
                marker.User = item.UserDBs.UserName;
                marker.Status = item.InspectionState.Description;
                marker.latitude = item.LatitudeIni;
                marker.longitude = item.LongitudeIni;
                markers.Add(marker);
            }
            
            return markers;
        }
    }
    public class marker
    {
        public string User { get; set; }

        public string Status { get; set; }

        public double? latitude { get; set; }

        public double? longitude { get; set; }
    }
}