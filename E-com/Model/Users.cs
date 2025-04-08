using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_com.Model
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? LoginId { get; set; }
        public string? UserType { get; set; }
        public string? ReportsTo { get; set; }
        public int? ReportsToPosition{ get; set; }
        public int? ManagerId{ get; set; } 
        public int? WorkShift{ get; set; } 
        public string? PseudoName { get; set; } 
        public int? MobileNumber { get; set; } 
        public int? AnotherMobileNumber { get; set; } 
        public int? CallerId { get; set; } 
        public int? CallerExtensionNumber{ get; set; } 
        public int? DidNumber { get; set; } 
        public DateTime? TimeZone { get; set; } 
        public DateTime? GroupId { get; set; } 
        public DateTime? RoleId { get; set; } 
        public bool IsActive { get; set; } 
        public DateTime? CreatedAt { get; set; } 
        public DateTime? ModifiedAt { get; set; } 
        public int? AuthenticationDirectory { get; set; } 

        
    }
}


     

