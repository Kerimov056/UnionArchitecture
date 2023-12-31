﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Domain.Entities.Identity;
using UnionArchitecture.Persistence.Conficurations;

namespace UnionArchitecture.Persistence.Contexts;

public class AppDbContext : IdentityDbContext<AppUser> 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatagoryConficurations).Assembly);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Flower_Tag>()
            .HasKey(x => new {x.FlowersId,x.TagsId});

        modelBuilder.Entity<Flower_Tag>()
            .HasOne(x => x.Flowers)
            .WithMany(d => d.Flower_Tags)
            .HasForeignKey(x => x.FlowersId);

        modelBuilder.Entity<Flower_Tag>()
            .HasOne(f => f.Tags)
            .WithMany(s => s.Flower_Tags)
            .HasForeignKey(us => us.TagsId);

    }

    public DbSet<Catagory> Catagories { get; set; } = null!;
    public DbSet<Flowers> Flowers { get; set; } 
    public DbSet<FlowersDetails> FlowersDetails { get; set; }
    public DbSet<FlowersImage> FlowersImages { get; set; } 
    public DbSet<Tags> Tags { get; set; } 
    public DbSet<Flower_Tag> Flower_Tags { get; set; } 
    public DbSet<Slider> Sliders { get; set; } 
    public DbSet<Blog> Blogs { get; set; } 
    public DbSet<BlogImage> BlogImages { get; set; } 
    public DbSet<Car> Cars { get; set; } 
    public DbSet<Basket> Baskets { get; set; } 
    public DbSet<BasketProduct> BasketProducts { get; set; } 
}
