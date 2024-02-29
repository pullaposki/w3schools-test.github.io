using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/employee"), ApiController]
    public class EmployeeController(ApplicationDbContext context, IEmployeeRepo repo) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IEmployeeRepo _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _repo.GetAllAsync();
            var responseDto = employees.Select(employee => employee.ToResponseDto());

            return Ok(responseDto);
        }

        [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
        {
            var employee = await _repo.GetByIdAsync(id);
            if (employee == null) return NotFound();

            return Ok(employee.ToResponseDto());
        }

    }
}