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

        public static Company ToModel(this ACreateCompanyRequestDto companyDto, PriceCategory priceCategory)
        {
            return new Company
            {
                CompanyName = companyDto.CompanyName,
                PriceCategory = priceCategory
            };
        }
    }
}