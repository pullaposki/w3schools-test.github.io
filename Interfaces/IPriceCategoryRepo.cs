using WebApi.Models;
using WebApi.Dtos;

namespace WebApi.Interfaces
{
    public interface IPriceCategoryRepo : IRepo<PriceCategory>
    {
        Task<PriceCategory?> UpdateAsync(int id, AnUpdatePriceCategoryRequestDto anUpdateDto);
        Task<PriceCategory?> GetByIdAsync(int id);
        Task<PriceCategory?> DeleteAsync(int id);
    }
}