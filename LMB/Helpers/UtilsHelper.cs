using LMB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LMB.Helpers
{
    public class UtilsHelper
    {
        private static DataContext db = new DataContext();
        public static async Task<List<marker>> GetMarcadores()
        {

            List<marker> markers = new List<marker>();
            var inspectionDaily = db.InspectionDaily.Include(i => i.InspectionState)
                .Include(u => u.UserDBs);
            foreach (var item in await inspectionDaily.Where(i => i.IdStatus != 2).OrderBy(u => u.UserDBs.UserName)
                .ToListAsync())
            {
                marker marker = new marker();
                marker.User = item.UserDBs.UserName;
                marker.Status = item.InspectionState.Description;
                marker.Text = "NumInspection: " + item.NumInspection + "</br> Location: " + item.Address;
                marker.latitude = item.LatitudeIni / 100000000;
                marker.longitude = item.LongitudeIni / 100000000;
                markers.Add(marker);
            }

            return markers;
        }

        public static async Task<centerMap> GetCenter()
        {
            centerMap CenterMap = new centerMap();
            var inspectionDaily = db.InspectionDaily.Include(i => i.InspectionState)
                .Include(u => u.UserDBs);
            var laticenterfin = (inspectionDaily.Max().LatitudeIni);
            var laticenterini = (inspectionDaily.Min().LatitudeIni);
            var laticenterRango = (laticenterfin - laticenterini) / 2;
            var laticenter = (laticenterini + laticenterRango) / 100000000;

            var longcenterfin = (inspectionDaily.Max().LongitudeIni);
            var longcenterini = (inspectionDaily.Min().LongitudeIni);
            var longcenterRango = (longcenterfin - longcenterini) / 2;
            var longcenter = (longcenterini + longcenterRango) / 100000000;

            CenterMap.latitude = laticenter;
            CenterMap.longitude = longcenter;
            return (CenterMap);

        }
        public class centerMap
        {

            public double? latitude { get; set; }

            public double? longitude { get; set; }
        }

        public class marker
        {
            public string User { get; set; }

            public string Status { get; set; }

            public string Text { get; set; }

            public double? latitude { get; set; }

            public double? longitude { get; set; }
        }
    }
    // The extension method
    public static class DataContextExtensions
    {
        public static DataContext BulkInsert<T>(this DataContext context, T entity, int count, int batchSize) where T : class
        {
            context.Set<T>().Add(entity);

            if (count % batchSize == 0)
            {
                context.SaveChanges();
                context.Dispose();
                context = new DataContext();

                // This is optional
                context.Configuration.AutoDetectChangesEnabled = false;
            }
            return context;
        }
    }
}