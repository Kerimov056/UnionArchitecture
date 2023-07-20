using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Conficurations;

namespace UnionArchitecture.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatagoryConficurations).Assembly);
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Catagory>()
        //        .HasMany(f => f.Flowers)
        //        .WithOne(f => f.Catagory)
        //        .HasForeignKey(f => f.CatagoryId)
        //        .HasPrincipalKey(c => c.Id);

        //modelBuilder.Entity<Flowers>()
        //        .HasOne(f => f.FlowersDetails)
        //        .WithOne(p => p.Flowers)
        //        .HasForeignKey<FlowersDetails>(fd => fd.FlowersId);

        //modelBuilder.Entity<FlowersDetails>()
        //        .HasMany(i => i.Images)
        //        .WithOne(f => f.FlowersDetails)
        //        .HasForeignKey(f => f.FlowersDetailsId)
        //        .HasPrincipalKey(c => c.Id);

    }

    public DbSet<Catagory> Catagories { get; set; } = null!;
}
