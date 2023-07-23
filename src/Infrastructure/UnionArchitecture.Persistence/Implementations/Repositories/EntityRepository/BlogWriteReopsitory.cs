using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class BlogWriteReopsitory : WriteRepository<Blog>, IBlogWriteReopsitory
{
    public BlogWriteReopsitory(AppDbContext context) : base(context)
    {
    }
}
