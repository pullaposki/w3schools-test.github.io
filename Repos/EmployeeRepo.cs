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
            await _context.Employees.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Employee?> DeleteAsync(int id)
        {
            var model = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (model == null)
                return null;

            _context.Employees.Remove(model);

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
    }
}