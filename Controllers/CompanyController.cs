using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/company"), ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICompanyRepo _repo;
        private readonly ICompanyService _companyService;

        public CompanyController(ApplicationDbContext context, ICompanyRepo companyRepo, ICompanyService companyService)
        {
            _context = context;
            _repo = companyRepo;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _repo.GetAllAsync();

            if (companies == null) return NotFound();

            var responseDto = companies.Select(c => c.ToResponseDto());

            if (!responseDto.Any()) return NotFound();

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
            if (createDto == null)
                return BadRequest(new { error = "Request body cannot be null." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var companyModel = await _companyService.CreateCompany(createDto);

                await _repo.CreateAsync(companyModel);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = companyModel.CompanyId },
                    companyModel.ToResponseDto()
                );
            }
            catch
            {
                return StatusCode(500, new { error = "An error occured while creating." });
            }

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AnUpdateCompanyRequestDto requestDto)
        {
            if (requestDto == null)
                return BadRequest(new { error = "Request body cannot be null." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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