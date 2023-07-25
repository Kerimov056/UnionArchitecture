using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Infrastructur.Services.Token;

namespace UnionArchitecture.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHandler, TokenHandlerr>();
    }
}

