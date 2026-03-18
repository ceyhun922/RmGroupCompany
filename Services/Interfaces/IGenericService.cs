namespace RmWebApi.Services.Interfaces;

public interface IGenericService<TResult, TCreate, TUpdate, TEntity>
    where TResult : class
    where TCreate : class
    where TUpdate : class
    where TEntity : class
{
    Task<List<TResult>> GetAllAsync();
    Task<TResult> GetByIdAsync(int id);
    Task CreateAsync(TCreate dto);
    Task UpdateAsync(TUpdate dto);
    Task DeleteAsync(int id);
}
