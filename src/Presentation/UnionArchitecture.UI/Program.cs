using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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


//builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(key: "JwtConfig"));

//builder.Services.AddAuthentication(configureOptions: options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(jwt =>
//{
//    //var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection(key: "JwtConfig:Secret").Value);
//    //jwt.SaveToken = true;

//    jwt.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidIssuer = config["JwtSettings:Issuer"],
//        ValidAudience = config["JwtSettings:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey
//        (Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//    };
//});




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

//IConfiguration configuration = app.Configuration;
//IWebHostEnvironment environment = app.Environment;

app.MapControllers();

app.Run();
