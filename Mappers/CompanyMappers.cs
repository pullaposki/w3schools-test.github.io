using WebApi.Dtos.Company;
using WebApi.Models;

namespace WebApi.Mappers
{
    public static class CompanyMappers
    {
        public static CompanyDto ToCompanyDto(this Company companyModel)
        {
            return new CompanyDto
            {
                CompanyId = companyModel.CompanyId,
                CompanyName = companyModel.CompanyName,
                PriceCategoryId = companyModel.PriceCategoryId
            };
        }
    }
}