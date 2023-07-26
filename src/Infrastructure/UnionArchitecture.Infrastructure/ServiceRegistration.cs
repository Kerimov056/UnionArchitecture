using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Infrastructur.Services.Token;
using UnionArchitecture.Infrastructure.Services;

namespace UnionArchitecture.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHandler, TokenHandlerr>();
        services.AddScoped<IUploadFile, UploadFile>();
    }
}

