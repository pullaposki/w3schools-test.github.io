using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repos
{
    public class PriceCategoryRepo(ApplicationDbContext context) : IPriceCategoryRepo
    {
        private readonly ApplicationDbContext _context = context;



        public async Task<PriceCategory> CreateAsync(PriceCategory priceCategoryModel)
        {
            await _context.PriceCategories.AddAsync(priceCategoryModel);
            await _context.SaveChangesAsync();

            return priceCategoryModel;
        }

        public async Task<PriceCategory?> DeleteAsync(int id)
        {
            var existingModel = await _context.PriceCategories.FindAsync(id);

            if (existingModel == null) return null;

            _context.PriceCategories.Remove(existingModel);
            await _context.SaveChangesAsync();

            return existingModel;
        }

        public async Task<List<PriceCategory>> GetAllAsync()
        {
            await UpdatePriceCategoriesShipRates();

            return await _context.PriceCategories.ToListAsync();
        }

        public async Task<PriceCategory?> GetByIdAsync(int id)
        {
            await UpdatePriceCategoriesShipRates();

            return await _context.PriceCategories.FindAsync(id);
        }

        public async Task<PriceCategory?> UpdateAsync(int id, AnUpdatePriceCategoryRequestDto requestDto)
        {
            var existingModel = await _context.PriceCategories.FirstOrDefaultAsync(pc => pc.PriceCategoryId == id);

            if(existingModel == null) return null;

            existingModel.PriceCategoryName = requestDto.PriceCategoryName;

            await _context.SaveChangesAsync();

            return existingModel;
        }

        private async Task UpdatePriceCategoriesShipRates()
        {
            var shipRates = await _context.ShipRates.ToListAsync();
            var priceCategories = await _context.PriceCategories.ToListAsync();

            for (int i = 0; i < shipRates.Count; i++)
            {
                priceCategories[i].ShipRatesId = shipRates[i].ShipRatesId;
            }

            await _context.SaveChangesAsync();
        }
    }
}