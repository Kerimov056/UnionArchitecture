using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Aplication.Abstraction.Repository;

public interface IRepository<T> where T : BaseEntity, new()
{
    public DbSet<T> Table { get;} //bu meselen _context.blogs.ToListAsync() <- elemirsen bunu eleyisenki birbasa uje istfade eledikde Table'i elmek kifayetdir. Meselen: var query = Table.IsQuarable(); artidq bundan sonra _context.name yox Table etmek kifayetdir.
    Task AddAsync(T entity); // bir entity gelir servicesden son onu add edirsen bu qeder Sade 
    Task AddRangeAsync(ICollection<T> entites); // bir cox entitler gelir add elemk ucun o zaman AddRangeAsync etmelisem
    void Remove(T entity); // bir entity gelir servicesden son onu Remove edirsen bu qeder Sade 
    void RemoveRange(ICollection<T> entites); // bir cox entitler gelir Remove elemk ucun o zaman RemoveRange etmelisem
    void Update(T entity); // bir entity gelir ve update edirsen
    IQueryable<T> GetAll(bool isTracking = true, params string[] inculdes);  //GetAll edirsen butun melumati cekirsen ve isTracking eger true'dusa Tracking edirsen deyilse elemeye ehtiyac yoxdu ve HasNotTracking() edirsen ve birde burda gonderilen entity inculde olunub gonderile biler menselen Details sehfesiyle inculde olunub gonderilir ona gor string tipinden ve params olmalidi cunki birden cox inculde ola biler.
    IQueryable<T> GetAllExpression(Expression<Func<T,bool>> expression,int Skip, int Take, bool isTracking = true, params string[] inculdes); // bunun 1 yuxardakiyla ferqi  Where edib getlist elemek isdeyir onda bunun ucun Expression yazirsan ve Take Skip ede biler onun ucun ne qeder tak,skip edecek deye int tipinden yazirsan Vacibdir Skip Take'den once olmalidir
    IQueryable<T> GetAllExpressionOrderBy(Expression<Func<T,bool>> expression,int Skip,int Take,Expression<Func<T,object>> expressionOrder,bool isOrdered = true, bool isTracking = true, params string[] inculdes);// bunun 1 yuxardakiyla ferqi Order'di order gere true'dursa order edceyik deyilse OrderByDesencding edeceyik ve name'e gore order ede biler id'ye gore order ede biler bunun ucun Expression yaziriq Expression<Func<T,object>> expressionOrder
    Task<T> GetByIdAsync(Guid id); // sene bir Id gelir ve bunu Task<T> tipinen olacaq Id'ni tapib return edecek.
    Task<T> GetByIdAsyncExpression(Expression<Func<T, bool>> expression, bool isTracking = true); // burda ise birden axtardigi sey name gore'de ola biler deye Expression yaziriq burada, isTracking propertisi eklemeyimizin sebebi Details sehfesinde track elemey ehtoyac yoxdur axi ona gore
    Task SaveChangeAsync(); // SaveChangeAsync edirsen axi sonda o 
}
