using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using UnionArchitecture.Domain.Entities.Identity;
using UnionArchitecture.Persistence.Contexts;
using UnionArchitecture.Persistence.ExtensionsMethods;
using UnionArchitecture.UI;
using UnionArchitecture.UI.Middelewares;
using UnionArchitecture.Infrastructure;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddLocalization();

List<CultureInfo> clutures = new()
{
    new CultureInfo("en-US"),
    new CultureInfo("es-ES")
};
RequestLocalizationOptions localizationOptions = new()
{
    ApplyCurrentCultureToResponseHeaders= true,
    SupportedCultures = clutures,
    SupportedUICultures = clutures,
};

localizationOptions.SetDefaultCulture("en-US");

builder.Services.AddCors();

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();

//builder.Services.AddScoped<AppDbContextInitializer>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])),
        LifetimeValidator = (_,expire,_,_) => expire>DateTime.UtcNow,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var instance = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
//    await instance.InitializeAsync();
//    await instance.RoleSeedAsync();
//    await instance.UserSeedAsync();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UserCustomExceptionHandler();
app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();

app.UseCors(cors => cors
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(x=>true)
            .AllowCredentials());
 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
