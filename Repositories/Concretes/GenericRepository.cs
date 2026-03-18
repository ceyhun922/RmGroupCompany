using Microsoft.EntityFrameworkCore;
using RmWebApi.Context;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly RmContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(RmContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
