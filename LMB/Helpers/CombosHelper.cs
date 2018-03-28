using LMB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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


        public void Dispose()
        {
            db.Dispose();
        }
    }
}