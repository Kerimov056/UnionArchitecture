using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.Abstraction.Services.Azure;
using UnionArchitecture.Infrastructur.Services.Token;
using UnionArchitecture.Infrastructure.Services;
//using UnionArchitecture.Infrastructure.Services.Azure;
using UnionArchitecture.Infrastructure.Services.Storge;

namespace UnionArchitecture.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHandler, TokenHandlerr>();
        services.AddScoped<IStorageFile, StogreFile>();
        services.AddScoped<IStorgeService, StorageService>();
        //services.AddScoped<IAzureStorge, AzureStorage>();
    }

    public static void AddStorageFile<T>(this IServiceCollection services) where T : Services.Storge.AzureStorage, IStorageFile
    {
        services.AddScoped<IStorageFile, T>();
    }

}

