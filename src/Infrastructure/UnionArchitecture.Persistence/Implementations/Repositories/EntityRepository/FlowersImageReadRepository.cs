using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class FlowersImageReadRepository : ReadRepository<FlowersImage>, IFlowersImageReadRepository
{
    public FlowersImageReadRepository(AppDbContext context) : base(context)
    {
    }
}
