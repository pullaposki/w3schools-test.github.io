using WebApi.Models;
using WebApi.Dtos;

namespace WebApi.Mappers
{
    public static class PriceCategoryMapper
    {
        // Map the PriceCategory model to the response dto
        public static APriceCategoryResponseDto ToResponseDto(this PriceCategory priceCategoryModel)
        {
            return new APriceCategoryResponseDto
            {
                PriceCategoryId = priceCategoryModel.PriceCategoryId,
                PriceCategoryName = priceCategoryModel.PriceCategoryName,
                ShipRates = priceCategoryModel.ShipRates
            };
        }

        public static PriceCategory ToModel(this ACreatePriceCategoryRequestDto priceCategoryDto)
        {
            return new PriceCategory
            {
                PriceCategoryName = priceCategoryDto.PriceCategoryName,
            };
        }
    }
}