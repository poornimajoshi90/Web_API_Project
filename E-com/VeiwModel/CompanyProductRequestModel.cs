using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace E_com.VeiwModel
{
    public class CompanyProductRequestModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public List<int> ProductId { get; set; }
    }
    public class CompanyDummyDetails
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
    }
    public class AccountRequest
    {
        //public int Id { get; set; }
        public int AccountId { get; set; }
        public List<CompanyDummyDetails> dummy { get; set; }
    }

    public class CompanyServiceModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public List<int> ServiceId { get; set; }
    }
    public class CompanyToolModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public List<int> ToolId { get; set; }
    }

    public class CompanyProcess
    {
        public long Id { get; set; }
        public int CompanyId { get; set; }
        public List<long> ProcessId { get; set; }
    }

    public class ComapnyTooltech
    {
        public long Id { get; set; }
        public int CompanyId { get; set; }
        public List<long> ToolandTechId { get; set; }
    }

    public class FunctionalSubFunctional
    {
        public long Id { get; set; }
        public long FunctionalId { get; set; }
        public List<long> SubfunctionalId { get; set; }
    }

    public class SubfunctionalSuperfunctional
    {
        public long Id { get; set; }
        public long SubfunctionalId  { get; set; }
        public List<long> SuperfunctionalId { get; set; }
    }

    public class FunctionalJob
    {
        public long Id { get; set; }
        public long FunctionalId { get; set; }
        public List<long> JobId { get; set; }
    }

    public class Jobs
    {
        public long Id { get; set; }
        //public long? PublicId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }

    public class UploadExcelSheetViewModel
    {
        [Required]
        public IFormFile ExcelFile { get; set; }

    }

    public class MapedColumm
    {
        public string? csv_column { get; set; }
        public long? csv_columnIndexId { get; set;}
        public string? entity_column { get; set; }
        public string? entity_column_label { get; set; }
    }
    public class Csv_Column
    {
        public string? IndexName { get; set; }
        public long? IndexValue { get; set; }

    }


    public class Importmastersnew
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public long? NameIndexId { get; set; }
        public long? DescriptionId { get; set; }
    }

    public class importdatanew // import new
    {
        [DefaultValue(null)]
        public Exceldatanew? File { get; set; }
        [DefaultValue(null)]
        public Importmastersnew? importmasters { get; set; }

    }
    public class Exceldatanew // import new
    {
        public long? CreatedBy { get; set; } //add new
        [DefaultValue(null)]
        public string? FileName { get; set; }
        [DefaultValue(false)]
        public bool SkipDuplicate { get; set; }
        [DefaultValue(false)]
        public bool OverwriteDuplicate { get; set; }
    }

    public class JobCurrentemp
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public List<long> CurrentEmployeeId { get; set; }
        public DateTime Createddate { get; set; }
        public long? CreatedBy { get; set; }
    }
    public class JobEducation
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public List<long> EducationKeywordsId { get; set; }
        public DateTime Createddate { get; set; }
        public long? CreatedBy { get; set; }
    }
    public class JobSkills
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public List<long> SkillsId { get; set; }
        public DateTime Createddate { get; set; }
        public long? CreatedBy { get; set; }
    }
    public class Jobcoursecategory
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public List<long> CoursecategoryId { get; set; }
        public DateTime Createddate { get; set; }
        public long? CreatedBy { get; set; }
    }
    public class JobIndustry
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public List<long> IndustryId { get; set; }
        public DateTime Createddate { get; set; }
        public long? CreatedBy { get; set; }
    }

    public class AllJob
    {
        public int Id { get; set; }
        public string? JobType { get; set; }
        public string Name { get; set; }
        public string? JobLocation { get; set; }
        public string? JobCompany { get; set; }
        public long[]? SkillsId { get; set; }
        //[DefaultValue(null)]
        public long[]? EducationkeywordId { get; set; }
        //[DefaultValue(null)]
        public long[]? CurrentemployerId { get; set; }
        //[DefaultValue(null)]
        public long[]? CoursecategoryId { get; set; }
        //[DefaultValue(null)]
        public bool? IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        //public DateTime CreatedAt { get; set; }
        public long ModifiedBy { get; set; }
        //public DateTime ModifiedAt { get; set; }
        public string? Description { get; set; }
        //public long UserId { get; set; }
    }

    public class AllCompany
    {
        public int ComapnyId { get; set; }
        public string? CompanyName { get; set; }
      
       
        public int[]? ProductId { get; set; }
        //[DefaultValue(null)]
        public int[]? ServiceId { get; set; }
        //[DefaultValue(null)]
        public int[]? ToolId { get; set; }
        //[DefaultValue(null)]
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        //public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        //public DateTime ModifiedAt { get; set; }
        public string? Description { get; set; }
     
        //public long UserId { get; set; }
    }


    public class CompanyDomain
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public int CompanyId { get; set; }
        //public long DomainId { get; set; }
        public string[] DomainName { get; set; }

        public bool IsValidDomainName(string domainName)
        {
            string pattern = @"^(?:[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(domainName);
        }
    }


    //public class CompanyDummy
    //{
    //    public List<int> Id { get; set; }
    //    public int? AccountId { get; set; }
    //    public List<int> CompanyId { get; set; }
    //}
}
