namespace WebApi.Interfaces
{
    public interface IRepo<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task<T> CreateAsync(T model);

    }
}