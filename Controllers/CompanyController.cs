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
            // Model Validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // Business logic validation
            var priceCategory = _context.PriceCategories.Find(createDto.PriceCategoryId);

            if (priceCategory == null)
            {
                return BadRequest(new { error = "PriceCategory not found" });
            }

            var companyModel = createDto.ToModel(priceCategory);
            await _repo.CreateAsync(companyModel);

            return CreatedAtAction(
                nameof(GetById),
                new { id = companyModel.CompanyId },
                companyModel.ToResponseDto()
            );
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