using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Persistence.Contexts;
using UnionArchitecture.Persistence.Implementations.Repositories;

namespace UnionArchitecture.Persistence.ExtensionsMethods;

public static class ServiceRegistration // burda butun serviceleri yazib program.cs'de yalniz methodun adini tanidiriq
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString("Default"));
        });
        services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>),typeof(WriteRepository<>)); 
    }
}
