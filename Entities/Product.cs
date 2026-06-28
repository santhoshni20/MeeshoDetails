using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeeshoDetails.Entities
{
    [Table("mstProducts")]
    public class Product
    {
        [Key]
        [Column("productId")]
        public int productId { get; set; }

        [Required]
        [Column("skuId")]
        [MaxLength(100)]
        public string skuId { get; set; } = string.Empty;

        [Column("productPhoto")]
        [MaxLength(255)]
        public string? productPhoto { get; set; }

        [Column("stock")]
        public int stock { get; set; } = 1;

        [Column("dateOfUpload")]
        public DateTime? dateOfUpload { get; set; }

        [Column("courierName")]
        [MaxLength(100)]
        public string? courierName { get; set; }

        [Column("dateOfPickup")]
        public DateTime? dateOfPickup { get; set; }

        [Column("investedAmount")]
        public decimal investedAmount { get; set; } = 0.00m;

        [Column("creditedAmount")]
        public decimal creditedAmount { get; set; } = 0.00m;

        [Column("profitAmount")]
        public decimal profitAmount { get; set; } = 0.00m;

        [Column("paymentStatus")]
        [MaxLength(50)]
        public string paymentStatus { get; set; } = "Unscheduled";

        [Column("dateOfPayment")]
        public DateTime? dateOfPayment { get; set; }

        [Column("arrived")]
        [MaxLength(10)]
        public string arrived { get; set; } = "No";
    }
}
