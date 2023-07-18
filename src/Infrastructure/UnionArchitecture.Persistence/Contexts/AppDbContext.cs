using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Conficurations;

namespace UnionArchitecture.Persistence.Contexts;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatagoryConficurations).Assembly);
		base.OnModelCreating(modelBuilder);
	}

	public DbSet<Catagory> Catagories { get; set; } = null!;
}
