using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;

public class SliderReadRepository : ReadRepository<Slider>, ISliderReadRepository
{
    public SliderReadRepository(AppDbContext context) : base(context)
    {
    }
}
