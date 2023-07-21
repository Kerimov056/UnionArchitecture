using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Conficurations;

public class CatagoryConficurations : IEntityTypeConfiguration<Catagory>
{
    public void Configure(EntityTypeBuilder<Catagory> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(34);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);

        
    }

}
 