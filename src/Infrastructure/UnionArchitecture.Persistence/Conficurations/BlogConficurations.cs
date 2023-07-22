using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Conficurations;

public class BlogConficurations : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.Property(x=>x.ImagePath).IsRequired().HasMaxLength(400);
        builder.Property(x=>x.Title).IsRequired().HasMaxLength(40);
        builder.Property(x=>x.Description).IsRequired().HasMaxLength(1500);
    }
}
