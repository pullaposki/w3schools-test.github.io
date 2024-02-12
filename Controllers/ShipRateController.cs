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
        public async Task<IActionResult> Create([FromBody]ACreateShipRatesRequestDto reqDto)
        {
            var model = reqDto.ToModel();
            var newShipRates = await _repo.CreateAsync(model);

            return CreatedAtAction(
                nameof(GetById),
                new { id = newShipRates.ShipRatesId },
                 newShipRates);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] AnUpdateShipRatesRequestDto requestDto)
        {
            var updatedModel = await _repo.UpdateAsync(id, requestDto);

            if (updatedModel == null) return NotFound();

            return Ok(updatedModel.ToResponseDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var deletedModel = await _repo.DeleteAsync(id);

            if (deletedModel == null) return NotFound();

            return NoContent();
        }
    }
}