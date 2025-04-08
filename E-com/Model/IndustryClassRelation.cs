using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_com.Model
{
    public class IndustryClassRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long IndustryID { get; set; }
        public long ClassificationID { get; set; }

    }

    public class ClassificationSubclassificationRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ClasssificationId { get; set; }
        public long SubClassificationId { get; set; }

    }

    public class SubClassificationSuperClasiificationRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long SubClassificationId { get; set; }
        public long SuperClassificationID { get; set; }
    }

    public class ComapnyProcessRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int ComapnyId { get; set; }
        public long ProcessId { get; set; }
    }
    public class CompanyToolandtechnologies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int CompanyId { get; set; }
        public  long ToolandTechId { get; set; }
    }

    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
       
        public string? Name { get; set; }
        public string? JobType { get; set; }
        public string? JobLocation { get; set; }
        public string? JobCompany { get; set; }
        public string? Description { get; set; }
        public long  CreatedBy { get; set; }
        public DateTime  CreatedAt { get; set; }
        public DateTime?  ModifiedAt { get; set; }
        public long? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

    }

    public class FunctionalSubRelational
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long FunctionalId { get; set; }
        public long SubfunctionalId { get; set; }
       
    }
    public class SubFunctionalSuperRelational
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long SuperfunctionalId { get; set; }
        public long SubfunctionalId { get; set; }
    }

    public class FunctionalJobRelational
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long FunctionalId { get; set; }
        public long JobId { get; set; }
    }

    public class ImportHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long? ModuleId { get; set; }
        public string? ExcelFileName { get; set; }
        public string? FilePath { get; set; }
        public DateTime? ImportedAt { get; set; }
        public long? ImportedBy { get; set; }
        [MaxLength(500)]
        public string? ExcelNameBySystem { get; set; }
    }
}














