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
    
}