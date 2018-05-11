using LMB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

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

        /// <summary>
        /// Funcion que retorno los usuarios ordenados por full name 
        /// </summary>
        /// <param name="bandera"></param>
        /// <returns>Una lista de usuario ordenados por fullname</returns>
        public static List<UserDB> GetUsersDB( int bandera)
        {
            var userdbs = db.UserDB;
            userdbs.Add(new UserDB
            {
                IDUser = 0,
                UserName = "[Select User]",
            });
            return userdbs.OrderBy(c => c.FirstName).ToList();

        }



        public static List<InspectionStates> GetInspectionStates()
        {
            var inspectionStates = db.InspectionStates;
            inspectionStates.Add(new InspectionStates
            {
                IdStatus = 0,
                Description = "[Select State]",
            });
            return inspectionStates.OrderBy(s => s.Description).ToList();
        }

        public static List<TypePicture> TypePicture()
        {
            var typecture = db.TypePicture;
            typecture.Add(new TypePicture
            {
                IdTypePicture =0,
                Description = "[Select TypePicture]",
            });

            return typecture.OrderBy(t => t.Description).ToList();
        }

        public static List<DirectionPhotoType> PothoType()
        {
            var directionpothotype = db.DirectionPhotoType;
            directionpothotype.Add(new DirectionPhotoType
            {
                IdDirectionPhotoType = 0,
                Description = "[Select DirectionPhotoType]",
            });
            return directionpothotype.OrderBy(t => t.Description).ToList();
        }

        public static List<SelectListItem> GetFiles()
        {
            var listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "[Select a File]",
                Value = "0",
            });
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