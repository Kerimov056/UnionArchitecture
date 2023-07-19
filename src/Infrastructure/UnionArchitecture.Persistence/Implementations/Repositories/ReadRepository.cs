using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Domain.Entities.Common;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;
    public ReadRepository(AppDbContext context) => _context = context;
    public DbSet<T> Table => _context.Set<T>();


    public IQueryable<T> GetAll(bool isTracking = true, params string[] inculdes)
    {
        var query = Table.AsQueryable();
        foreach (var inculde in inculdes)
        {
            query.Include(inculde);
        }
        return isTracking ? query: query.AsNoTracking();
    }

    public IQueryable<T> GetAllExpression(Expression<Func<T, bool>> expression, int Skip, int Take, bool isTracking = true, params string[] inculdes)
    {
        var query = Table.Where(expression).Skip(Skip).Take(Take).AsQueryable();
        foreach (var inculdue in inculdes)
        {
            query.Include(inculdue);
        }
        return isTracking ? query : query.AsNoTracking();
    }

    public IQueryable<T> GetAllExpressionOrderBy(Expression<Func<T, bool>> expression, int Skip, int Take, Expression<Func<T, object>> expressionOrder, bool isOrdered = true, bool isTracking = true, params string[] inculdes)
    {
        var query = Table.Where(expression).AsQueryable();
        query = isOrdered ? query.OrderBy(expressionOrder) : query.OrderByDescending(expressionOrder);
        query = query.Skip(Skip).Take(Take);  
        foreach (var inculde in inculdes)
        {
            query.Include(inculde);
        }
        return isTracking ? query : query.AsNoTracking();
    }

    public  async Task<T?> GetByIdAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }
    public async Task<T?> GetByIdAsyncExpression(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        var query = isTracking ? Table.AsQueryable() : Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(expression);
    }
}
