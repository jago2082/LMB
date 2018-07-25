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

        public static List<District> GetDistricts()
        {
            var districts = db.Districts;
            districts.Add(new District
            {
                NAME = "0",
                ABBR = "[Select District]",
            });
            return districts.OrderBy(d => d.ABBR).ToList();
        }

        public static List<Counties> GetCounties()
        {
            var counties = db.Counties;
            counties.Add(new Counties
            {
                IdCountries = 0,
                Description = "[Select District]",
            });
            return counties.OrderBy(d => d.Description).ToList();
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

        public static List<InspectionRaiting> InspectionRaiting()
        {
            var inspectionRaiting = db.InspectionRaiting;
            inspectionRaiting.Add(new InspectionRaiting
            {
                InspectionRaitingType =0,
                Description = "[Select Option]",
            });
            return inspectionRaiting.OrderBy(i => i.Description).ToList();
        }

        public static List<ReferenceFeatureType> ReferenceFeatureType()
        {
            var referenceFeatureType = db.ReferenceFeatureType;
            referenceFeatureType.Add(new ReferenceFeatureType
            {
                IdReferenceFeatureType = 0,
                Description = "[Select Option]",
            });
            return referenceFeatureType.OrderBy(i => i.Description).ToList();
        }

        public static List<SelectListItem> GetFiles()
        {
            var listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "[Select type of File]",
                Value = "0",
            });
            listItems.Add(new SelectListItem {
                Text = "Raw Data from District",
                Value = "1",
            });

     /*       listItems.Add(new SelectListItem
            {
                Text = "Brigde Inspection Follow-up",
                Value = "2",
            });*/
            listItems.Add(new SelectListItem
            {
                Text = "Configuration Checklist",
                Value = "2",
            });
            listItems.Add(new SelectListItem
            {
                Text = "Detailed Work Schedule  B",
                Value = "3",
            });
            /*
            listItems.Add(new SelectListItem
            {
                Text = "PonTex Detail Bridge",
                Value = "4",
            });
            */

            return listItems.OrderBy(c => c.Value).ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}