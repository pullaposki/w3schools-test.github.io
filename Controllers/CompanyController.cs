using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos.Company;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/company"), ApiController]
    public class CompanyController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            // Use the ToList extension method to convert the DbSet<Company> to a List<Company>
            var companies = await _context.Companies.ToListAsync();

            // Use the ToCompanyDto extension method to convert the Company entities to CompanyDto objects using a c# version of the map function
            var companiesDto = companies.Select(c => c.ToResponseDto());
            
            return Ok(companiesDto);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company.ToResponseDto());
        }        

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ACreateCompanyRequestDto createACompanyRequestDto)
        {
            var companyModel = createACompanyRequestDto.ToModel();

            await _context.Companies.AddAsync(companyModel);
            await _context.SaveChangesAsync();

            // this line of code is creating an HTTP 201 response to indicate that a new company was successfully created. 
            // The response includes a Location header with a URL that can be used to retrieve the new company, 
            // and the body of the response includes a representation of the new company.
            return CreatedAtAction(nameof(GetById), new {id = companyModel.CompanyId}, companyModel.ToResponseDto() );
        }
    
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AnUpdateCompanyRequestDto updateDto)
        {
            var companyModel = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);

            if(companyModel == null) return NotFound();

            companyModel.CompanyName = updateDto.CompanyName;
            companyModel.PriceCategoryId = updateDto.PriceCategoryId;
            // EF started tracking

            await _context.SaveChangesAsync();
            // Saved to db, tracking stopped

            return Ok(companyModel.ToResponseDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var companyModel  = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);

            if(companyModel == null) return NotFound();

            // In-memory operation, no async needed
            _context.Companies.Remove(companyModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}