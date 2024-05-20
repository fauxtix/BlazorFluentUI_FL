using EdamanFluentApi.Data;
using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Models.Youtube.Entities;
using EdamanFluentApi.Repositories.Interfaces;
using Google;
using Microsoft.EntityFrameworkCore;

namespace EdamanFluentApi.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly YoutubeDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(YoutubeDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
