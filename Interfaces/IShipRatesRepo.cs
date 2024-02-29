using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IShipRatesRepo : IRepo<ShipRates>
    {
        Task<ShipRates?> UpdateAsync(int id, AnUpdateShipRatesRequestDto requestDto);
        Task<ShipRates?> GetByIdAsync(int id);
        Task<ShipRates?> DeleteAsync(int id);
    }
}