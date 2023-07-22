using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Conficurations;

public class TagConficurations : IEntityTypeConfiguration<Tags>
{
    public void Configure(EntityTypeBuilder<Tags> builder)
    {
        builder.Property(x => x.Tag).IsRequired().HasMaxLength(50);
    }
}
