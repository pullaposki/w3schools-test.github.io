using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Repos;

public class AppUserCompanyRepo: IAppUserCompanyRepo
{
    readonly ApplicationDbContext _context;

    public AppUserCompanyRepo(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Company>> GetUserCompaniesAsync(AppUser appUser)
    {
        return await _context.AppUserCompanies
            .Where(auc => auc.AppUserId == appUser.Id)
            .Select(company => new Company
            {
                CompanyId = company.CompanyId,
                CompanyName = company.Company.CompanyName,
                Employees = company.Company.Employees
            }).ToListAsync();

    }

    public async Task<AppUserCompany> CreateAsync(AppUserCompany appUserCompany)
    {
        await _context.AppUserCompanies.AddAsync(appUserCompany);
        await _context.SaveChangesAsync();
        return appUserCompany;
    }

    public async Task<AppUserCompany> DeleteAsync(int companyId, AppUser appUser)
    {
        var appUserCompanyModel = await _context.AppUserCompanies
            .FirstOrDefaultAsync(auc => auc.CompanyId == companyId && auc.AppUserId == appUser.Id);

        if (appUserCompanyModel == null) return null;
        
        _context.AppUserCompanies.Remove(appUserCompanyModel);
        await _context.SaveChangesAsync();
        return appUserCompanyModel;
    }
}