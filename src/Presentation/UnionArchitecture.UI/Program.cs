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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(key:"JwtConfig"));

//builder.Services.AddAuthentication(configureOptions: options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(jwt =>
//{
//    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection(key: "JwtConfig:Secret").Value);

//    jwt.SaveToken = true;
//    jwt.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new  SymmetricSecurityKey(key),
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        RequireExpirationTime= false,
//        ValidateLifetime = true,
//    };
//});



var app = builder.Build();

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
