using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Mappers;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/priceCategory"), ApiController]
    public class PriceCategoryController(ApplicationDbContext context, IPriceCategoryRepo priceCategoryRepo) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IPriceCategoryRepo _repo = priceCategoryRepo;

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var selectedModel = await _repo.DeleteAsync(id);

            if (selectedModel == null) return NotFound();

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var priceCategories = await _repo.GetAllAsync();

            var priceCategoriesDto = priceCategories.Select(pc => pc.ToResponseDto());

            return Ok(priceCategoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var priceCategory = await _repo.GetByIdAsync(id);

            if (priceCategory == null)
            {
                return NotFound();
            }

            return Ok(priceCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ACreatePriceCategoryRequestDto requestDto)
        {
            var model = requestDto.ToModel();
            await _repo.CreateAsync(model);

            return CreatedAtAction(
                nameof(GetById),
                 new { id = model.PriceCategoryId },
                    model.ToResponseDto()
                );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AnUpdatePriceCategoryRequestDto requestDto)
        {
            var updatedModel = await _repo.UpdateAsync(id, requestDto);

            if (updatedModel == null) return NotFound();

            return Ok(updatedModel.ToResponseDto());
        }
    }
}