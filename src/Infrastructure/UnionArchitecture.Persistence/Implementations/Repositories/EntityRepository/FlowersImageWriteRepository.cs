using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class FlowersImageWriteRepository : WriteRepository<FlowersImage>, IFlowersImageWriteRepository
{
    public FlowersImageWriteRepository(AppDbContext context) : base(context)
    {
    }
}
