using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/priceCategory"), ApiController]
    public class PriceCategoryController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PriceCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var priceCategories = _context.PriceCategories.ToList();
            return Ok(priceCategories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var priceCategory = _context.PriceCategories.Find(id);

            if (priceCategory == null)
            {
                return NotFound();
            }

            return Ok(priceCategory);
        }
        
    }
}