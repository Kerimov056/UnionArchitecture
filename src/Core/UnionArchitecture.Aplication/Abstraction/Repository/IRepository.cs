using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UnionArchitecture.Domain.Entities.Common;

namespace UnionArchitecture.Aplication.Abstraction.Repository;

public interface IRepository<T> where T : BaseEntity, new()
{
    public DbSet<T> Table { get;} //bu meselen _context.blogs.ToListAsync() <- elemirsen bunu eleyisenki birbasa uje istfade eledikde Table'i elmek kifayetdir. Meselen: var query = Table.IsQuarable(); artidq bundan sonra _context.name yox Table etmek kifayetdir.
   
}
