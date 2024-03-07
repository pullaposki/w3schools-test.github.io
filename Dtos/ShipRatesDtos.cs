using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Dtos
{
    // Response

    public class AShipRatesResponseDto
    {
        public int ShipRatesId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerKg { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerCubicMeter { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerKm { get; set; }
    }

    // Request
    public class ACreateShipRatesRequestDto
    {
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerKg { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerCubicMeter { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PerKm { get; set; }
    }

    public class AnUpdateShipRatesRequestDto
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