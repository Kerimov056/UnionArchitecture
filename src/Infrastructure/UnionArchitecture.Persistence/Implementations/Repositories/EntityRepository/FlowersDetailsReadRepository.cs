using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class FlowersDetailsReadRepository : ReadRepository<FlowersDetails>, IFlowersDetailsReadRepository
{
    public FlowersDetailsReadRepository(AppDbContext context) : base(context)
    {
    }
}
