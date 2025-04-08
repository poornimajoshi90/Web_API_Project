using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_com.Model
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsSold { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? SoldAt { get; set; }
        public string? PaymentMethod { get; set; }
        
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? DeletedBy { get; set; }
    }

    public enum PaymentMethod
    {
        COD,
        Online
    }
}


