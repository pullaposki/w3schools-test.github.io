using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class ShipRate
    {
        public int RateId  { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerKg { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerCubicMeter { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerKm { get; set; }
    }
}