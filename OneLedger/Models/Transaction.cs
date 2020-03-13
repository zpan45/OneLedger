using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneLedger.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        [Range(0, 10000)]
        public int Count { get; set; }

        [Required]
        [Display(Name = "Price Per Unit")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerUnit { get; set; }

        [Required]
        [Display(Name = "Total Charge")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalCharge { get; set; }

    }
}
