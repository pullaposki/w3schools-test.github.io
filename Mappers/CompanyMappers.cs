using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Mappers
{
    public static class CompanyMappers
    {
        public static ACompanyResponseDto ToResponseDto(this Company companyModel)
        {
            return new ACompanyResponseDto
            {
                CompanyId = companyModel.CompanyId,
                CompanyName = companyModel.CompanyName,
                PriceCategoryId = companyModel.PriceCategoryId
            };
        }

        public static Company ToModel(this ACreateCompanyRequestDto companyDto, ApplicationDbContext context)
        {
            var priceCategory = context.PriceCategories.Find(companyDto.PriceCategoryId);

            if (priceCategory == null)
            {
                throw new ArgumentException("PriceCategory not found");
            }

            return new Company
            {
                CompanyName = companyDto.CompanyName,
                PriceCategory = priceCategory
            };
        }
    }
}