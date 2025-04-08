using E_com.Model;
using E_com.VeiwModel;
using Microsoft.EntityFrameworkCore;

namespace E_com.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Products> Products{ get; set; }
        public DbSet<CompanyProducts> CompanyProducts { get; set; }
        public DbSet<CompanyTools> CompanyTools { get; set; }
        public DbSet<ComapanyServices> ComapanyServices { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<CompanyProductRelationship>  companyProductRelationship { get; set; }
        public DbSet<CompanyServiceRelationship>  CompanyServiceRelationship { get; set; }
        public DbSet<CompanyToolRelationship>  CompanyToolRelationship { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<AccountDummy> AccountDummy { get; set; }
        public DbSet<Classification> Classification { get; set; }
        public DbSet<Userss> Userss { get; set; }
        public DbSet<SubClassification> SubClassification { get; set; }
        public DbSet<SuperClassification> SuperClassification { get; set; }
        public DbSet<Domains> Domains { get; set; }
        public DbSet<Industries> Industries { get; set; }
        public DbSet<SubIndustries> SubIndustries { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<IndustryGroup> IndustryGroup { get; set; }

        public DbSet<Service> Service { get; set; }  
        public DbSet<Process> Process { get; set; }
        public DbSet<ToolandtechTechnologies> ToolandtechTechnologies { get; set; }
        public DbSet<FunctionalAreas> FunctionalAreas { get; set; }
        public DbSet<SubFunctionalAreas> SubFunctionalAreas { get; set; }
        public DbSet<SuperFunctionalAreas> SuperFunctionalAreas { get; set; }
        public DbSet<IndustryClassRelation> IndustryClassRelation { get; set; }
        public DbSet<ClassificationSubclassificationRelation> ClassificationSubclassificationRelation { get; set; }
        public DbSet<SubClassificationSuperClasiificationRelation> SubClassificationSuperClasiificationRelation { get; set; }
        public DbSet<ComapnyProcessRelation> ComapnyProcessRelation { get; set; }
        public DbSet<CompanyToolandtechnologies> CompanyToolandtechnologies { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<FunctionalSubRelational> FunctionalSubRelational { get; set; }
        public DbSet<SubFunctionalSuperRelational> SubFunctionalSuperRelational { get; set; }
        public DbSet<FunctionalJobRelational> FunctionalJobRelational { get; set; }
        public DbSet<ImportHistory> ImportHistory { get; set; }
        public DbSet<CurrentEmployee> CurrentEmployee { get; set; }
        public DbSet<EducationKeywords> EducationKeywords { get; set; }
        public DbSet<Coursecategory> Coursecategory { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<JobCoursecategory> JobCoursecategory { get; set; }
        public DbSet<JobCurrentEmployeerelation> JobCurrentEmployeerelation { get; set; }
        public DbSet<JobEducationkeywords> JobEducationkeywords { get; set; }
        //public DbSet<JobIndustry> JobIndustry { get; set; }
        public DbSet<JobSkillls> JobSkillls { get; set; }
        //public DbSet<AllJobs> AllJobs { get; set; }

        public DbSet<CompanyDomainRelation> CompanyDomainRelation { get; set; }




        //public DbSet<AdminreportModel> AdminreportModels { get; set; }
        //public DbSet<BrandsModel> BrandsModels { get; set; }
        //public DbSet<CartModel> CartModels { get; set; }
        //public DbSet<CategoriesModel> CategoriesModels  { get; set; }
        //public DbSet<OrderItemModel> OrderItemModels  { get; set; }
        //public DbSet<OrderModel> OrderModels   { get; set; }
        //public DbSet<PaymentModel> PaymentModels   { get; set; }
        //public DbSet<ProductModel> ProductModels   { get; set; }
        //public DbSet<ReviewsModel> ReviewsModels    { get; set; }
        //public DbSet<ShippingModel> ShippingModels   { get; set; }
        //public DbSet<UsersessionModel> UsersessionModels { get; set; }
        //public DbSet<UsersModel> UsersModels  { get; set; }
        //public DbSet<WishlistModel> WishlistModels   { get; set; }
    }
}
