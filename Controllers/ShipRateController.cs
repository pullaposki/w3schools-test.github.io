using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers
{

    [Route("api/shipRate"), ApiController]
    public class ShipRateController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public ShipRateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var shipRates = _context.ShipRates.ToList();
            return Ok(shipRates);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var shipRate = _context.ShipRates.Find(id);

            if (shipRate == null)
            {
                return NotFound();
            }

            return Ok(shipRate);
        }
    }
}