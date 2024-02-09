using WebApi.Dtos.Company;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICompanyRepo
    {
        Task<List<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(int id); // First or default can be null
        Task<Company> CreateAsync(Company companyModel);
        Task<Company?> UpdateAsync(int id, AnUpdateCompanyRequestDto updateDto);
        Task<Company?> DeleteAsync(int id);

    }
}