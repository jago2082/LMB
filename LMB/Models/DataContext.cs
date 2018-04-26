using System.Data.Entity;

namespace LMB.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
            
        }

        public System.Data.Entity.DbSet<LMB.Models.RawData> RawData { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionDaily> InspectionDaily { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.CamposClient> CamposClient { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.CheckListProject> CheckListProject { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.CheckListQuestion> CheckListQuestion { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.CheckListSection> CheckListSection { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Client> Client { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.FuncionalidadClient> FuncionalidadClient { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.HSEQuestion> HSEQuestion { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Insp_Attach> Insp_Attach { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Insp_Question_Attach> Insp_Question_Attach { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Insp_Type_Attach> Insp_Type_Attach { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Inspection> Inspection { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionBasicRegistry> InspectionBasicRegistry { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionBasicRegistryValue> InspectionBasicRegistryValue { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionDetailCount> InspectionDetailCount { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionHSEValue> InspectionHSEValue { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.NombreCampos> NombreCampos { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.NoveltyInspection> NoveltyInspection { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Project> Project { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.RegistrySerial> RegistrySerial { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.RegistrySerialAttach> RegistrySerialAttach { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.ServerConfiguration> ServerConfiguration { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.StatusReferenceSerial> StatusReferenceSerial { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.TypeFuncionalidad> TypeFuncionalidad { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.TypeInspection> TypeInspection { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.TypeInspectionProject> TypeInspectionProject { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.TypeNovelty> TypeNovelty { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.TypePicture> TypePicture { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.UserDB> UserDB { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.UserProject> UserProject { get; set; }

        
        public System.Data.Entity.DbSet<LMB.Models.ValueCheckList> ValueCheckList { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.ValueHSE> ValueHSE { get; set; }

        public DbSet<ReferenceFeatureType> ReferenceFeatureType { get; set; }

        public DbSet<ReferenceFeatureUnderType> ReferenceFeatureUnderType { get; set; }

        public DbSet<ItemUnderType> ItemUnderType { get; set; }

        public DbSet<RecommendationType> RecommendationType { get; set; }

        public DbSet<DirectionPhotoType> DirectionPhotoType { get; set; }

        public DbSet<InspectionRaiting> InspectionRaiting { get; set; }

        public DbSet<UnderClearValues> UnderClearanceRecord { get; set; }

        public DbSet<CrossSectionValues> CrossSectionValues { get; set; }

        public DbSet<TypeName> TypeName { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Pdf> Pdfs { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionStates> InspectionStates { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.District> Districts { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Counties> Counties { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.ItemName> ItemNames { get; set; }
    }
}
