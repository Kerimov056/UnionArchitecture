using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class BlogImageWriteReopsitory : WriteRepository<BlogImage>, IBlogImageWriteReopsitory
{
    public BlogImageWriteReopsitory(AppDbContext context) : base(context)
    {
    }
}
