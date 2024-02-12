using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IShipRatesRepo : IRepo<ShipRates>
    {
        Task<ShipRates?> UpdateAsync(int id, ShipRates model);
        Task<ShipRates?> DeleteAsync(int id);
    }
}