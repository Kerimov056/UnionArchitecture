using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class CatagoryReadRepository : ReadRepository<Catagory>, ICatagoryReadRepository
{
    public CatagoryReadRepository(AppDbContext context) : base(context)
    {
    }
}
