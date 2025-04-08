using System.ComponentModel;
using System.Numerics;

namespace E_com.VeiwModel
{
    public class Classficationrequestcs
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        //public BigInteger CreatedBy { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime? ModifiedAt { get; set; }
        //public BigInteger? ModifiedBy { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime? DeletedAt { get; set; }
        public long UserId { get; set; }
        //public Sorting? sort { get; set; }
        //[DefaultValue(null)]
        //public object? filter { get; set; }
    }

    public class SubClassficationrequestcs
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }

    public class SuperClassficationrequestcs
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }

    public class Domainsreq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }

    public class Industriesreq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }

    public class SubIndustriesreq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }

    public class LocationsViewModel
    {
        public int pageNo { get; set; }
        public int pagesize { get; set; }
        [DefaultValue(null)]
        public Sorting? sort { get; set; }
        [DefaultValue(null)]
        public object? filter { get; set; }
    }
    public class Sorting
    {
        [DefaultValue(null)]
        public string? selector { get; set; }
        [DefaultValue(null)]
        public bool? desc { get; set; }
    }

    public class Productreq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }

    public class Industryreq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }

    public class Servicereq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }

    public class Processreq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }
    public class techreq 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }
    public class functionalreq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }
    public class subfuncreq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }

    public  class supfunreq
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public Guid PublicId { get; set; }
        public string? Description { get; set; }
        public long UserId { get; set; }
    }

    public class Currentemp
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public long CreatedBy { get; set; }
        //public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
    }

    public class Educationkey
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
       
        public string Description { get; set; }
        public int UserId { get; set; }
    }

    public class Coursecate
    {
        public long Id { get; set; }
        public string Name { get; set; }


        public string Description { get; set; }
        public int UserId { get; set; }
    }

    public class Skill
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public long CreatedBy { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public long ModifiedBy { get; set; }
        //public DateTime ModifiedAt { get; set; }

        public string Description { get; set; }
        public int UserId { get; set; }
    }
    





}
