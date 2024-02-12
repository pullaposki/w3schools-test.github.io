using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Mappers;
using WebApi.Models;

namespace WebApi.Controllers
{

    [Route("api/shipRate"), ApiController]
    public class ShipRateController(IShipRatesRepo repo, ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IShipRatesRepo _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfShipRates = await _repo.GetAllAsync();
            return Ok(listOfShipRates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ACreateShipRatesRequestDto reqDto)
        {
            var model = reqDto.ToModel();
            var newShipRates = await _repo.CreateAsync(model);

            return CreatedAtAction(
                nameof(GetById),
                new { id = newShipRates.ShipRatesId },
                 newShipRates);
        }
    }
}