using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/company"), ApiController]
    public class CompanyController(ApplicationDbContext context, ICompanyRepo companyRepo) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ICompanyRepo _repo = companyRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _repo.GetAllAsync();
            var responseDto = companies.Select(c => c.ToResponseDto());

            return Ok(responseDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _repo.GetByIdAsync(id);
            if (company == null) return NotFound();

            return Ok(company.ToResponseDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ACreateCompanyRequestDto createDto)
        {
            try
            {
                var companyModel = createDto.ToModel(_context);
                await _repo.CreateAsync(companyModel);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = companyModel.CompanyId },
                    companyModel.ToResponseDto()
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while creating the company" });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AnUpdateCompanyRequestDto requestDto)
        {
            var updatedModel = await _repo.UpdateAsync(id, requestDto);

            if (updatedModel == null) return NotFound();

            return Ok(updatedModel.ToResponseDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var companyModel = await _repo.DeleteAsync(id);

            if (companyModel == null) return NotFound();

            return NoContent();
        }
    }
}