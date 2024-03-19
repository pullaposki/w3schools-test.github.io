using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Helpers;
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

        public async Task<List<Company>> GetAllAsyncWithAQuery(QueryObject queryObject)
        {
            var companies = _context.Companies
                .Include(c => c.PriceCategory)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryObject.CompanyName))
            {
                companies = companies.Where(c => c.CompanyName.Contains(queryObject.CompanyName));
            }

            if (queryObject.CompanyId != null)
            {
                companies = companies.Where(c => c.CompanyId.Equals(queryObject.CompanyId));
            }

            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if (queryObject.SortBy.Equals("companyName", StringComparison.OrdinalIgnoreCase))
                {
                    companies = queryObject.IsDecending ?
                    companies.OrderByDescending(c => c.CompanyName) :
                    companies.OrderBy(c => c.CompanyName);
                }
            }

            var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;

            return await companies
                .Skip(skipNumber)
                .Take(queryObject.PageSize)
                .ToListAsync();
        }
    }
}