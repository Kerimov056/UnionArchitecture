using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class TagWriteRepository : WriteRepository<Tags>, ITagWriteRepository
{
    public TagWriteRepository(AppDbContext context) : base(context)
    {
    }
}
