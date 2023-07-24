using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnionArchitecture.Aplication.Abstraction.Repository;
using UnionArchitecture.Aplication.Abstraction.Repository.IEntityRepository;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.Validators.CatagoryValidators;
using UnionArchitecture.Domain.Entities.Identity;
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
        services.AddValidatorsFromAssemblyContaining<CatagoryCreateDTOValidator>();

        //AutoMapper
        services.AddAutoMapper(typeof(CatagoryProfile).Assembly);

        //Repository
        services.AddScoped<ICatagoryReadRepository, CatagoryReadRepository>();
        services.AddScoped<ICatagoryWriteRepository, CatagoryWriteRepository>();
        services.AddScoped<IFlowersReadRepository, FlowersReadRepository>();
        services.AddScoped<IFlowersWriteRepository, FlowersWriteRepository>();
        services.AddScoped<IFlowersDetailsReadRepository, FlowersDetailsReadRepository>();
        services.AddScoped<IFlowersDetailsWriteRepository, FlowersDetailsWriteRepository>();
        services.AddScoped<IFlowersImageWriteRepository, FlowersImageWriteRepository>();
        services.AddScoped<IFlowersImageWriteRepository, FlowersImageWriteRepository>();
        //services.AddScoped<IFower_TagReadRepository, Fower_TagReadRepository>();
        //services.AddScoped<IFower_TagWriteRepository, Fower_TagWriteRepository>();
        services.AddScoped<ITagWriteRepository, TagWriteRepository>();
        services.AddScoped<ITagReadRepository, TagReadRepository>();
        services.AddScoped<ISliderReadRepository, SliderReadRepository>();
        services.AddScoped<ISliderWriteRepository, SliderWriteRepository>();
        services.AddScoped<IBlogReadReopsitory, BlogReadReopsitory>();
        services.AddScoped<IBlogWriteReopsitory, BlogWriteReopsitory>();
        services.AddScoped<IBlogImageReadReopsitory, BlogImageReadReopsitory>();
        services.AddScoped<IBlogImageWriteReopsitory, BlogImageWriteReopsitory>();

        //Services
        services.AddScoped<ICatagoryService, CatagoryService>();
        services.AddScoped<IFlowerService, FlowerService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<IBlogImageService, BlogImageService>();
        services.AddScoped<IAuthService, AuthServic>();

        //User 
        services.AddIdentity<AppUser, IdentityRole>(Options =>
        {
            Options.User.RequireUniqueEmail = true;
            Options.Password.RequireNonAlphanumeric = true;
            Options.Password.RequiredLength = 8;
            Options.Password.RequireDigit = true;
            Options.Password.RequireUppercase = true;
            Options.Password.RequireLowercase = true;

            Options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(3);
            Options.Lockout.MaxFailedAccessAttempts = 3;
            Options.Lockout.AllowedForNewUsers= true;
            //Options.SignIn.RequireConfirmedEmail = false;
        }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
    }
}
