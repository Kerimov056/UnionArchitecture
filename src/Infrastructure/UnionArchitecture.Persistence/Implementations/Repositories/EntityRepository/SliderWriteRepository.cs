using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class SliderWriteRepository : WriteRepository<Slider>, ISliderWriteRepository
{
    public SliderWriteRepository(AppDbContext context) : base(context)
    {
    }
}
