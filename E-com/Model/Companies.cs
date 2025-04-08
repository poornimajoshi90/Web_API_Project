using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Compression;
using System.Text.RegularExpressions;
using E_com.VeiwModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_com.Model
{
    public class Companies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public int? CreatedBy { get; set; }
        //public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ProductId { get; set; }
        public int? ServiceId { get; set; }
        public int? ToolId { get; set; }
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }
        //public int? UserID { get; set; }
    }
    public class CurrentEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Guid PublicId { get; set; }
        //public long Publicid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

    public class EducationKeywords
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public Guid PublicId { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

    public class Coursecategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
    public class Skills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

    public class JobCurrentEmployeerelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long JobId { get; set; }
        public long CurrentEmployeeId { get; set; }
        public DateTime Createddate { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class JobEducationkeywords
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long JobId { get; set; }
        public long EducationKeywordsId { get; set; }
        public DateTime Createddate { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class JobSkillls
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long JobId { get; set; }
        public long SkillsId { get; set; }
        public DateTime Createddate { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class JobCoursecategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long JobId { get; set; }
        public long CoursecategoryId { get; set; }
        public DateTime Createddate { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class JobIndustry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long JobId { get; set; }
        public long IndustryId { get; set; }
        public DateTime Createddate { get; set; }
        public string createdBy { get; set; }
        public int? Deleted { get; set; }
    }

    //public class JobAddUpdateModel
    //{
    //    public JobEducation JobEducation { get; set; }
    //    public JobCurrentemp JobCurrentemp { get; set; }
    //    public Jobcoursecategory Jobcoursecategory { get; set; }
    //    public JobSkillls JobSkillls { get; set; }
    //}

    public class CompanyDomainRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyId { get; set; }
       //public long DomainId { get; set; }
        public string DomainName { get; set; }


        public bool IsValidDomainName(string domainName)
        {
            string pattern = @"^(?:[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(domainName);
        }
    }

    //public class AllJobs
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int Id { get; set; }
    //    public string? JobType { get; set; }
    //    public string? JobName { get; set; }
    //    public string? JobLocation { get; set; }
    //    public string? JobCompany { get; set; }
    //    public long? SkillsId { get; set; }
    //    public long? EducationkeywordId { get; set; }
    //    public long? CurrentemployerId { get; set; }
    //    public long? CoursecategoryId { get; set; }
    //    public int? IsDeleted { get; set; }
    //}
}



