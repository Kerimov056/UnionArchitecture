using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class TagReadRepository : ReadRepository<Tags>, ITagReadRepository
{
    public TagReadRepository(AppDbContext context) : base(context)
    {
    }
}
