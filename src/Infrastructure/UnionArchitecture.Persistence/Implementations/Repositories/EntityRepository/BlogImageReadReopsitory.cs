using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class BlogImageReadReopsitory : ReadRepository<BlogImage>, IBlogImageReadReopsitory
{
    public BlogImageReadReopsitory(AppDbContext context) : base(context)
    {
    }
}
