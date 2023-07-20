using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class CatagoryWriteRepository : WriteRepository<Catagory>, ICatagoryWriteRepository
{
    public CatagoryWriteRepository(AppDbContext context) : base(context)
    {
    }
}
