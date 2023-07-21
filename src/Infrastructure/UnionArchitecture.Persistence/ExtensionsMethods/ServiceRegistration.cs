using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.Validators.CatagoryValidators;
using UnionArchitecture.Persistence.Contexts;
using UnionArchitecture.Persistence.Implementations.Repositories;
using UnionArchitecture.Persistence.Implementations.Repositories.EntityRepository;
using UnionArchitecture.Persistence.Implementations.Services;
using UnionArchitecture.Persistence.MapperProfiles;

namespace UnionArchitecture.Persistence.ExtensionsMethods;

public static class ServiceRegistration // burda butun serviceleri yazib program.cs'de yalniz methodun adini tanidiriq
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {   //DataBase
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString("Default"));
        });

        //Validators
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining(typeof(CatagoryCreateDTOValidator));

        //AutoMapper
        services.AddAutoMapper(typeof(CatagoryProfile).Assembly);

        //Repository
        services.AddScoped<ICatagoryReadRepository, CatagoryReadRepository>();
        services.AddScoped<ICatagoryWriteRepository, CatagoryWriteRepository>();
        services.AddScoped<IFlowersReadRepository, FlowersReadRepository>();
        services.AddScoped<IFlowersWriteRepository, FlowersWriteRepository>();

        //Services
        services.AddScoped<ICatagoryService, CatagoryService>();
        services.AddScoped<IFlowerService, FlowerService>();
    }
}
