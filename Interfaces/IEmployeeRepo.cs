using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IEmployeeRepo : IRepo<Employee>
    {
        Task<Employee?> GetByIdAsync(int id);
    }
}