using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos;
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

        public async Task<ShipRates?> DeleteAsync(int id)
        {
            var existingModel = await _context.ShipRates.FindAsync(id);

            if (existingModel == null) return null;

            _context.ShipRates.Remove(existingModel);
            _context.SaveChanges();

            return existingModel;
        }

        public async Task<List<ShipRates>> GetAllAsync()
        {
            return await _context.ShipRates.ToListAsync();
        }

        public async Task<ShipRates?> GetByIdAsync(int id)
        {
            return await _context.ShipRates.FindAsync(id);
        }

        public async Task<ShipRates?> UpdateAsync(int id, AnUpdateShipRatesRequestDto requestDto)
        {
            var existingModel = await _context.ShipRates.FindAsync(id);

            if (existingModel == null) return null;

            existingModel.PerCubicMeter = requestDto.PerCubicMeter;
            existingModel.PerKg = requestDto.PerCubicMeter;
            existingModel.PerKm = requestDto.PerKm;

            _context.SaveChanges();

            return existingModel;
        }
    }
}