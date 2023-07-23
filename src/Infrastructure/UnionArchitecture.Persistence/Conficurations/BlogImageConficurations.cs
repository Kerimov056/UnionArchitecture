using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnionArchitecture.Domain.Entities;

namespace UnionArchitecture.Persistence.Conficurations;

public class BlogImageConficurations : IEntityTypeConfiguration<BlogImage>
{
    public void Configure(EntityTypeBuilder<BlogImage> builder)
    {
        builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(400);
    }
}
