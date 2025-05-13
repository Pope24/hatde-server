using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server_hatde.Entities
{
    public class VendorProfile
    {
        [Key]
        public int VendorId { get; set; }
        public string BusinessName { get; set; } = null!;
        public string? Description { get; set; }
        public string Mst { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }

        [ForeignKey("VendorId")]
        public User Vendor { get; set; } = null!;
        public User? ApprovedAdmin { get; set; }

        public ICollection<Service>? Services { get; set; }
    }

}
