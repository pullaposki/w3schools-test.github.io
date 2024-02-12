using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICompanyRepo : IRepo<Company>
    {
        Task<Company?> UpdateAsync(int id, AnUpdateCompanyRequestDto updateDto);
        Task<Company?> DeleteAsync(int id);

    }
}