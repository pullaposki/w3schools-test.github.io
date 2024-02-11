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
            var listOfShipRates = _context.ShipRates.ToList();
            return Ok(listOfShipRates);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var shipRates = _context.ShipRates.Find(id);

            if (shipRates == null)
            {
                return NotFound();
            }

            return Ok(shipRates);
        }
    }
}