using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Mappers
{
    public static class ShipRatesMapper
    {
        public static AShipRatesResponseDto ToResponseDto(this ShipRates model)
        {
            return new AShipRatesResponseDto
            {
                PerKm = model.PerKm,
                PerCubicMeter = model.PerCubicMeter,
                PerKg = model.PerKg
            };
        }

        public static ShipRates ToModel(this ACreateShipRatesRequestDto dto)
        {
            return new ShipRates
            {
                PerKm = dto.PerKm,
                PerCubicMeter = dto.PerCubicMeter,
                PerKg = dto.PerKg
            };
        }
    }
}