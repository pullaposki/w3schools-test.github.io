using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repos
{
    public class ShipRatesRepo(ApplicationDbContext context) : IShipRatesRepo
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ShipRates> CreateAsync(ShipRates model)
        {
            await _context.ShipRates.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task<ShipRates?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShipRates>> GetAllAsync()
        {
            return await _context.ShipRates.ToListAsync();
        }

        public async Task<ShipRates?> GetByIdAsync(int id)
        {
            return await _context.ShipRates.FindAsync(id);
        }

        public Task<ShipRates?> UpdateAsync(int id, ShipRates model)
        {
            throw new NotImplementedException();
        }
    }
}