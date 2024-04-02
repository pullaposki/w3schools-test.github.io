using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("ShipRates")]
    public class ShipRates
    {
        public int ShipRatesId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerKg { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerCubicMeter { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerKm { get; set; }
    }
}