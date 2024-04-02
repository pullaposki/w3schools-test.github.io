using WebApi.Models;

namespace WebApi.Interfaces;

public interface IAppUserCompanyRepo
{
    Task<List<Company>> GetUserCompaniesAsync(AppUser appUser);
}