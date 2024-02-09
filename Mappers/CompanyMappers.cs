using WebApi.Dtos.Company;
using WebApi.Models;

namespace WebApi.Mappers
{
    public static class CompanyMappers
    {
        public static CompanyResponseDto ToResponseDto(this Company companyModel)
        {
            return new CompanyResponseDto
            {
                CompanyId = companyModel.CompanyId,
                CompanyName = companyModel.CompanyName,
                PriceCategoryId = companyModel.PriceCategoryId
            };
        }

        public static Company ToModel(this ACreateCompanyRequestDto companyDto)
        {
            return new Company
            {
                CompanyName = companyDto.CompanyName,
                PriceCategoryId = companyDto.PriceCategoryId
            };
        }
    }
}