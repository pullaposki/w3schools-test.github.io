using WebApi.Data;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Mappers;
using WebApi.Models;

namespace WebApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICompanyRepo _repo;

        public CompanyService(ApplicationDbContext context, ICompanyRepo repo)
        {
            _context = context;
            _repo = repo;
        }

        public async Task<Company> CreateCompany(ACreateCompanyRequestDto createDto)
        {
            var priceCategory = await _context.PriceCategories.FindAsync(createDto.PriceCategoryId);

            if (priceCategory == null)
            {
                throw new Exception("Price category not found");
            }

            var companyModel = createDto.ToModel(priceCategory);
            await _repo.CreateAsync(companyModel);

            return companyModel;
        }
    }
}