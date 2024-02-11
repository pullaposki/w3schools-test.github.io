using WebApi.Models;

namespace WebApi.Dtos
{
    public class PriceCategoryDtos
    {
        // Response

        public class APriceCategoryResponseDto
        {
            public int PriceCategoryId { get; set; }
            public string PriceCategoryName { get; set; } = string.Empty;
            public ShipRates ShipRates { get; set; } = new ShipRates();
        }

        // Request

        public class ACreatePriceCategoryRequestDto
        {
            public string PriceCategoryName { get; set; } = string.Empty;
            public ShipRates ShipRates { get; set; } = new ShipRates();
        }

        public class AnUpdatePriceCategoryRequestDto
        {
            public string PriceCategoryName { get; set; } = string.Empty;
            public ShipRates ShipRates { get; set; } = new ShipRates();
        }
    }
}