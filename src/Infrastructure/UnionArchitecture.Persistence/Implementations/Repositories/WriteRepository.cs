using Microsoft.EntityFrameworkCore;
using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Domain.Entities.Common;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.Persistence.Implementations.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;
    public WriteRepository(AppDbContext context) => _context = context;

    public DbSet<T> Table => _context.Set<T>(); // artiq T tipinden olan Entity classlarimiz bir basa table beraberlesiririk

    public async Task AddAsync(T entity) => await Table.AddAsync(entity); // artiq Table istifade ede bilerik ve burda sadece add edirik

    public async Task AddRangeAsync(ICollection<T> entites) => await Table.AddRangeAsync(entites);  // hemcinin burdada eyni 1 ust setideki ile ferqi Range Range ne edir bir coxun eyni vaxta add edir.

    public void Remove(T entity) => Table.Remove(entity); // burdada sadece Remove edirik 

    public void RemoveRange(ICollection<T> entites) => Table.RemoveRange(entites); // burdada sadece Remove edirik  yalniz dediyim kim tek ferq Range

    public async Task SaveChangeAsync() => await _context.SaveChangesAsync(); // SaveChangeAsync Edirik 

    public void Update(T entity) => Table.Update(entity); // Table'a gelen entitimizi update edirik.
}
