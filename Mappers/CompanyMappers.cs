using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Mappers
{
    public static class CompanyMappers
    {
        public static ACompanyResponseDto ToResponseDto(this Company model)
        {
            return new ACompanyResponseDto
            {
                CompanyId = model.CompanyId,
                CompanyName = model.CompanyName,
                PriceCategoryId = model.PriceCategoryId,
                Employees = model.Employees.Select(e => e.ToResponseDto()).ToList()
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