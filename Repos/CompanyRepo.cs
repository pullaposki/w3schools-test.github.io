using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repos
{
    public class CompanyRepo(ApplicationDbContext context) : ICompanyRepo
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company?> GetByIdWithEmployeesAsync(int id, bool includeEmployees = false)
        {
            if (includeEmployees)
            {
                return await _context.Companies
                    .Include(c => c.Employees)
                    .FirstOrDefaultAsync(c => c.CompanyId == id);
            }
            else
            {
                return await _context.Companies.FindAsync(id);
            }
        }

        public async Task<Company> CreateAsync(Company companyModel)
        {
            await _context.Companies.AddAsync(companyModel);
            await _context.SaveChangesAsync();
            return companyModel;
        }

        public async Task<Company?> UpdateAsync(int id, AnUpdateCompanyRequestDto updateDto)
        {
            var existingModel = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);

            if (existingModel == null) return null;

            existingModel.CompanyName = updateDto.CompanyName;
            existingModel.PriceCategoryId = updateDto.PriceCategoryId;

            await _context.SaveChangesAsync();

            return existingModel;
        }

        public async Task<Company?> DeleteAsync(int id)
        {
            var companyModel = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);

            if (companyModel == null) return null;

            _context.Companies.Remove(companyModel);

            await _context.SaveChangesAsync();

            return companyModel;
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _context.Companies.AnyAsync(c => c.CompanyId == id);
        }
    }
}