using LMB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMB.Helpers
{
    public class CombosHelper : IDisposable
    {
        public static DataContext db = new DataContext();

        public static List<UserDB> GetUsersDB()
        {
            var userdbs = db.UserDB;
            userdbs.Add(new UserDB
            {
                IDUser = 0,
                UserName="[Select User]",
            });
            return userdbs.OrderBy(c => c.UserName).ToList();
        }

        public static List<SelectListItem> GetFiles()
        {
            var listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem {
                Text = "Row Data from District",
                Value = "1",
            });

            listItems.Add(new SelectListItem
            {
                Text = "Brigde Inspection Follow-up",
                Value = "2",
            });
            listItems.Add(new SelectListItem
            {
                Text = "Configuration Checklist",
                Value = "3",
            });
            listItems.Add(new SelectListItem
            {
                Text = "PonTex Detail Bridge",
                Value = "4",
            });

            return listItems.OrderBy(c => c.Value).ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}