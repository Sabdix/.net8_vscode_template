using System.Linq.Expressions;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
      _context = context;
      _dbSet = context.Set<T>();
    }

    public Task AddAsync(T entity)
    {
      throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
      return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate)
    {
      return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
      throw new NotImplementedException();
    }
  }
}