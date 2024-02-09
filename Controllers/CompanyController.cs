using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos.Company;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/company"), ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyDto>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll()
        {
            IEnumerable<CompanyDto> companies = GetCompanyDtos();

            return Ok(companies);
        }

        private IEnumerable<CompanyDto> GetCompanyDtos()
        {
            // Use the ToList extension method to convert the DbSet<Company> to a List<Company>
            var companies = _context.Companies.ToList()

                // Use the ToCompanyDto extension method to convert the Company entities to CompanyDto objects using a c# version of the map function
                .Select(c => c.ToCompanyDto());

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

            return Ok(company.ToCompanyDto());
        }
        
    }
}