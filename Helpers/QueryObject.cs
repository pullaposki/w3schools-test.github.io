using WebApi.Models;

namespace WebApi.Helpers;

public class QueryObject
{
    public string? CompanyName { get; set; } = null;

    public int? CompanyId { get; set; } = null;

    public string? SortBy { get; set; } = null;

    public bool IsDecending { get; set; } = false;
}