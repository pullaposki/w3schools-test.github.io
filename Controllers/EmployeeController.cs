using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/employee"), ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmployeeRepo _repo;
        private readonly ICompanyRepo _companyRepo;

        public EmployeeController(ApplicationDbContext context, IEmployeeRepo repo, ICompanyRepo companyRepo)
        {
            _context = context;
            _repo = repo;
            _companyRepo = companyRepo;
        }

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

        [HttpPost("{companyId}")]
        public async Task<IActionResult> Create([FromRoute] int companyId, ACreateEmployeeRequestDto createReqDto)
        {
            if (!await _companyRepo.ExistsAsync(companyId))
                return BadRequest("Company does not exist");

            var employeeModel = createReqDto.ToModelFromACreateRequestDto(companyId);

            await _repo.CreateAsync(employeeModel);

            return CreatedAtAction(nameof(GetById), new { id = employeeModel.EmployeeId }, employeeModel.ToResponseDto());
        }
    }
}