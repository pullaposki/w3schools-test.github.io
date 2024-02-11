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

        public Task<PriceCategory?> CreateAsync(PriceCategory priceCategoryModel)
        {
            throw new NotImplementedException();
        }

        public Task<PriceCategory?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PriceCategory>> GetAllAsync()
        {
            return await _context.PriceCategories.ToListAsync();
        }

        public async Task<PriceCategory?> GetById(int id)
        {
            return await _context.PriceCategories.FindAsync(id);
        }

        public Task<PriceCategory?> UpdateAsync(int id, PriceCategoryDtos.AnUpdatePriceCategoryRequestDto anUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}