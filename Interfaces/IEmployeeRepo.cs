using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IEmployeeRepo : IRepo<Employee>
    {
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee?> DeleteAsync(int id);
        Task<Employee>? UpdateAsync(int id, Employee employee);
    }
}