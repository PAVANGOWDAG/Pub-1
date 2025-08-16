using System.ComponentModel.DataAnnotations;

namespace Pub_Mangement.Models
{
    public class Table
    {
        public int TableId { get; set; }

        [Required]
        public int TableNumber { get; set; }

        [StringLength(260)]
        public string? QRCodePath { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
