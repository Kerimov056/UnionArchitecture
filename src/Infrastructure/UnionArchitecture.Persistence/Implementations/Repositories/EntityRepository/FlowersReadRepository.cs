using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class FlowersReadRepository : ReadRepository<Flowers>, IFlowersReadRepository
{
    public FlowersReadRepository(AppDbContext context) : base(context)
    {
    }
}
