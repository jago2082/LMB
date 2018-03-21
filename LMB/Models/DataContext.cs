using System.Data.Entity;

namespace LMB.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
            
        }

        public System.Data.Entity.DbSet<LMB.Models.RawData> RawDatas { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionDaily> InspectionDailies { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.CamposClient> CamposClients { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.CheckListProject> CheckListProjects { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.CheckListQuestion> CheckListQuestions { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.CheckListSection> CheckListSections { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.FuncionalidadClient> FuncionalidadClients { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.HSEQuestion> HSEQuestions { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Insp_Attach> Insp_Attach { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Insp_Question_Attach> Insp_Question_Attach { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Insp_Type_Attach> Insp_Type_Attach { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Inspection> Inspections { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionBasicRegistry> InspectionBasicRegistries { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionBasicRegistryValue> InspectionBasicRegistryValues { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionDetailCount> InspectionDetailCounts { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.InspectionHSEValue> InspectionHSEValues { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.NombreCampos> NombreCampos { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.NoveltyInspection> NoveltyInspections { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.RegistrySerial> RegistrySerials { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.RegistrySerialAttach> RegistrySerialAttaches { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.ServerConfiguration> ServerConfigurations { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.StatusReferenceSerial> StatusReferenceSerials { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.TypeFuncionalidad> TypeFuncionalidads { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.TypeInspection> TypeInspections { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.TypeInspectionProject> TypeInspectionProjects { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.TypeNovelty> TypeNovelties { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.TypePicture> TypePictures { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.UserDB> UserDBs { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.UserProject> UserProjects { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.V_CheckListQuestion> V_CheckListQuestion { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.V_InspecionCount> V_InspecionCount { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.V_inspectionDailies> V_inspectionDailies { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.V_NamesProject> V_NamesProject { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.ValueCheckList> ValueCheckLists { get; set; }

        public System.Data.Entity.DbSet<LMB.Models.ValueHSE> ValueHSEs { get; set; }

        public DbSet<ReferenceFeatureType> ReferenceFeatureType { get; set; }

        public DbSet<ReferenceFeatureUnderType> ReferenceFeatureUnderType { get; set; }

        public DbSet<ItemUnderType> ItemUnderType { get; set; }

        public DbSet<RecommendationType> RecommendationType { get; set; }

        public DbSet<DirectionPhotoType> DirectionPhotoType { get; set; }

        public DbSet<InspectionRaiting> InspectionRaiting { get; set; }
    }
}
