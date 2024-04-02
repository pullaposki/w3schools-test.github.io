using WebApi.Models;

namespace WebApi.Interfaces;

public interface IAppUserCompanyRepo
{
    Task<List<Company>> GetUserCompaniesAsync(AppUser appUser);
    Task<AppUserCompany> CreateAsync(AppUserCompany appUserCompany);
    Task<AppUserCompany> DeleteAsync(int companyId, AppUser appUser);
}