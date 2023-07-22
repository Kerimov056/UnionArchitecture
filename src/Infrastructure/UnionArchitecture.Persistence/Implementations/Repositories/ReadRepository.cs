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
        var query = Table.AsQueryable();   // burda evelce biz Table olduguna gore table'i query'ye beraberlesdirik sonra
        foreach (var inculde in inculdes)  // burda ise params'di yeni bir cox inculde gelir ve rahatca foreach'de inculdelari dondurub bir bir hamisin inculde edirik
        {
            query = query.Include(inculde);
        }
        return isTracking ? query: query.AsNoTracking();  // burda ise isTracking true'dursa query deyilse AsNoTracking()
    }

    public IQueryable<T> GetAllExpression(Expression<Func<T, bool>> expression, int Skip, int Take, bool isTracking = true, params string[] inculdes)
    {
        var query = Table.Where(expression).Skip(Skip).Take(Take).AsQueryable();
        foreach (var include in inculdes)  // 1 ustdeki ile eynidir yalniz ferqi gelen Skip ve Take'dir
        {
            query = query.Include(include);
        }
        return isTracking ? query : query.AsNoTracking();
    }

    public IQueryable<T> GetAllExpressionOrderBy(Expression<Func<T, bool>> expression, int Skip, int Take, Expression<Func<T, object>> expressionOrder, bool isOrdered = true, bool isTracking = true, params string[] inculdes)
    {
        var query = Table.Where(expression).AsQueryable(); 
        query = isOrdered ? query.OrderBy(expressionOrder) : query.OrderByDescending(expressionOrder);
        query = query.Skip(Skip).Take(Take);  // bununda bir usedeki ile ferqi isOrderedd'di eger isOrdered trudursa orderby etsin deyilse orderbydesencding
            foreach (var inculde in inculdes)
            {
            query = query.Include(inculde);
        }
            return isTracking ? query : query.AsNoTracking();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var category = await Table.FindAsync(id);
        return category;   // sadece tapib gonderirik
    }
    public async Task<T?> GetByIdAsyncExpression(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        var query = isTracking ? Table.AsQueryable() : Table.AsNoTracking(); // burdada eynidir yalniz bir ferq  evvelden biz queryni yazib sonra axtaririrq
        return await query.FirstOrDefaultAsync(expression);
    }

}
