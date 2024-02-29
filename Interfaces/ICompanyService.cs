using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> CreateCompany(ACreateCompanyRequestDto createDto);
    }
}