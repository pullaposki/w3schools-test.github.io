using System.Net;
using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(typeof(IEnumerable<ACompanyResponseDto>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            IEnumerable<ACompanyResponseDto> companies = GetCompanyDtos();

            return Ok(companies);
        }

        private IEnumerable<ACompanyResponseDto> GetCompanyDtos()
        {
            // Use the ToList extension method to convert the DbSet<Company> to a List<Company>
            var companies = _context.Companies.ToList()

                // Use the ToCompanyDto extension method to convert the Company entities to CompanyDto objects using a c# version of the map function
                .Select(c => c.ToResponseDto());

            return companies;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _context.Companies.Find(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company.ToResponseDto());
        }        

        [HttpPost]
        public IActionResult Create([FromBody] ACreateCompanyRequestDto createACompanyRequestDto)
        {
            var companyModel = createACompanyRequestDto.ToModel();
            _context.Companies.Add(companyModel);
            _context.SaveChanges();

            // this line of code is creating an HTTP 201 response to indicate that a new company was successfully created. 
            //The response includes a Location header with a URL that can be used to retrieve the new company, and the body of the response includes a representation of the new company.
            return CreatedAtAction(nameof(GetById), new {id = companyModel.CompanyId}, companyModel.ToResponseDto() );
        }
    
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] AnUpdateCompanyRequestDto updateDto)
        {

            var companyModel = _context.Companies.FirstOrDefault(c => c.CompanyId == id);

            if(companyModel == null) return NotFound();


            companyModel.CompanyName = updateDto.CompanyName;
            companyModel.PriceCategoryId = updateDto.PriceCategoryId;
            // EF started tracking

            _context.SaveChanges();
            // Saved to db, tracking stopped

            return Ok(companyModel.ToResponseDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var companyModel  = _context.Companies.FirstOrDefault(c => c.CompanyId == id);

            if(companyModel == null) return NotFound();

            _context.Companies.Remove(companyModel);

            _context.SaveChanges();

            return NoContent();
        }
    }
}