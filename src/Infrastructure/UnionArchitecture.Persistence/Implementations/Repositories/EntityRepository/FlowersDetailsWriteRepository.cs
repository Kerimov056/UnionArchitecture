using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class FlowersDetailsWriteRepository : WriteRepository<FlowersDetails>, IFlowersDetailsWriteRepository
{
    public FlowersDetailsWriteRepository(AppDbContext context) : base(context)
    {
    }
}
