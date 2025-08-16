using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Pub_Mangement.Models.Enums;

namespace Pub_Mangement.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        [Required]
        public int TableId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100000)]
        public decimal Amount { get; set; }

        [Required]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        public int? PaidBy { get; set; }

        public DateTime? PaymentDate { get; set; }

        public Table Table { get; set; }
        public Customer? Customer { get; set; }
    }
}
