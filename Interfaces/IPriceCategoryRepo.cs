using WebApi.Models;
using static WebApi.Dtos.PriceCategoryDtos;

namespace WebApi.Interfaces
{
    public interface IPriceCategoryRepo
    {
        // Create a new PriceCategory using the model
        Task<PriceCategory?> CreateAsync(PriceCategory priceCategoryModel);

        Task<List<PriceCategory>> GetAllAsync();
        Task<PriceCategory?> GetById(int id);

        // Update an existing PriceCategory using the dto model,
        // so only the determined fields can be updated
        Task<PriceCategory?> UpdateAsync(int id, AnUpdatePriceCategoryRequestDto anUpdateDto);


        Task<PriceCategory?> DeleteAsync(int id);
    }
}