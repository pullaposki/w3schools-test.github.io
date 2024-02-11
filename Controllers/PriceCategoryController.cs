using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/priceCategory"), ApiController]
    public class PriceCategoryController(ApplicationDbContext context, IPriceCategoryRepo priceCategoryRepo) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IPriceCategoryRepo _priceCategoryRepo = priceCategoryRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var priceCategories = await _priceCategoryRepo.GetAllAsync();

            var priceCategoriesDto = priceCategories.Select(pc => pc.ToResponseDto());

            return Ok(priceCategoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var priceCategory = await _priceCategoryRepo.GetById(id);

            if (priceCategory == null)
            {
                return NotFound();
            }

            return Ok(priceCategory);
        }

    }
}