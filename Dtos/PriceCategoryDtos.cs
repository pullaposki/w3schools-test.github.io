using WebApi.Models;

namespace WebApi.Dtos
{
    // Response

    public class APriceCategoryResponseDto
    {
        public int PriceCategoryId { get; set; }
        public string PriceCategoryName { get; set; } = string.Empty;
        public ShipRates ShipRates { get; set; }
    }

    // Request

    public class ACreatePriceCategoryRequestDto
    {
        public string PriceCategoryName { get; set; } = string.Empty;
        public int ShipRatesId { get; set; }
    }

    public class AnUpdatePriceCategoryRequestDto
    {
        public string PriceCategoryName { get; set; } = string.Empty;
        public int ShipRatesId { get; set; }
    }

}