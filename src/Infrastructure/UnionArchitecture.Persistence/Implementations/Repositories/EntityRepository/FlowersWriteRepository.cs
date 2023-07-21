using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class FlowersWriteRepository : WriteRepository<Flowers>, IFlowersWriteRepository
{
    public FlowersWriteRepository(AppDbContext context) : base(context)
    {
    }
}
