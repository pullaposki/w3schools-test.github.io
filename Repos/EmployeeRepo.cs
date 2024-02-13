using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repos
{
    public class EmployeeRepo(ApplicationDbContext context) : IEmployeeRepo
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Employee> CreateAsync(Employee model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}