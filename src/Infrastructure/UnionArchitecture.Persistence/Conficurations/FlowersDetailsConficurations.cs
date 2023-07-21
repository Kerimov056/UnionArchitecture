using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Conficurations;

internal class FlowersDetailsConficurations : IEntityTypeConfiguration<FlowersDetails>
{
    public void Configure(EntityTypeBuilder<FlowersDetails> builder)
    {
        builder.Property(x => x.Description).IsRequired().HasMaxLength(280);
        builder.Property(x => x.SKU).IsRequired();
        builder.Property(x => x.Weight).IsRequired();
        builder.Property(x => x.PowerFlowers).IsRequired().HasMaxLength(300);
    }
}
