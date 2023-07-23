using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class BlogReadReopsitory : ReadRepository<Blog>, IBlogReadReopsitory
{
    public BlogReadReopsitory(AppDbContext context) : base(context)
    {
    }
}
