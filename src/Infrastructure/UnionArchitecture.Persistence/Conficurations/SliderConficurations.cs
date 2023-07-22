using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Conficurations;

public class SliderConficurations : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(111);
    }
}
