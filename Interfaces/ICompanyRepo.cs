using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICompanyRepo
    {
        Task<List<Company>> GetAllAsync();
        
        // First or default can be null
        Task<Company?> GetByIdAsync(int id); 
        
        Task<Company> CreateAsync(Company companyModel);
        Task<Company?> UpdateAsync(int id, AnUpdateCompanyRequestDto updateDto);
        Task<Company?> DeleteAsync(int id);

    }
}