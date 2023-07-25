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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceServices();

builder.Services.AddScoped<AppDbContextInitializer>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var instance = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
    await instance.InitializeAsync();
    await instance.RoleSeedAsync();
    await instance.UserSeedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UserCustomExceptionHandler();

app.UseHttpsRedirection();
 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
