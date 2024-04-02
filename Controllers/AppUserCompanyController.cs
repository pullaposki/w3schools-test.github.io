using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/appusercompany")] [ApiController]
public class AppUserCompanyController: ControllerBase
{
    readonly UserManager<AppUser> _userManager;
    readonly ICompanyRepo _companyRepo;
    readonly IAppUserCompanyRepo _appUserCompanyRepo;
    public AppUserCompanyController(UserManager<AppUser> userManager, ICompanyRepo companyRepo, IAppUserCompanyRepo appUserCompanyRepo)
    {
        _userManager = userManager;
        _companyRepo = companyRepo;
        _appUserCompanyRepo = appUserCompanyRepo;
    }

    [HttpGet, Authorize]
    public async Task<IActionResult> GetUserPortfolio()
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        var companies = await _appUserCompanyRepo.GetUserCompaniesAsync(appUser);
        return Ok(companies);
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> AddCompanyToUser(int companyId)
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        var companyToAdd = await _companyRepo.GetByIdWithEmployeesAsync(companyId);

        if (companyToAdd == null) return NotFound("Company not found");
        if (appUser == null) return NotFound("User not found");

        var appUserCompany = await _appUserCompanyRepo.GetUserCompaniesAsync(appUser);

        if (appUserCompany.Any(c => c.CompanyId == companyToAdd.CompanyId))
        {
            return BadRequest("Company already added to user");
        }

        var appUserCompanyToAdd = new AppUserCompany
        {
            AppUserId = appUser.Id,
            CompanyId = companyToAdd.CompanyId
        };

        await _appUserCompanyRepo.CreateAsync(appUserCompanyToAdd);

        return Ok(appUserCompanyToAdd);
    }
    
    [HttpDelete("{companyId}")]
    public async Task<IActionResult> RemoveCompanyFromUser(int companyId)
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        if (appUser == null) return NotFound("User not found");
        var appUserCompany = await _appUserCompanyRepo.GetUserCompaniesAsync(appUser);

        var companyToRemove = appUserCompany.FirstOrDefault(c => c.CompanyId == companyId);

        if (companyToRemove == null) return NotFound("Company not found in user portfolio");
        
        var filteredCompany = appUserCompany
            .Where(c => c.CompanyId == companyId)
            .ToList();

        if (filteredCompany.Count > 1) return BadRequest("Multiple companies with the same id found in user portfolio");
        
        await _appUserCompanyRepo.DeleteAsync(companyId, appUser);

        return Ok(companyToRemove);
    }
}