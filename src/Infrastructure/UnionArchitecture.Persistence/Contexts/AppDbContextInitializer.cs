using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Ini;
using UnionArchitecture.Domain.Entities.Identity;
using UnionArchitecture.Domain.Enums;

namespace UnionArchitecture.Persistence.Contexts;

public class AppDbContextInitializer   //bu claas onun ucundurku proqram ise dusende evvelce burdan ise dusecek gedib databasle elaqelenib burdan ise dusmeye baslayacaq
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
	private readonly IConfiguration _configuration; 
	public AppDbContextInitializer(AppDbContext context,
								UserManager<AppUser> userManager,
								RoleManager<IdentityRole> roleManager,
								IConfiguration configuration)
	{
		_context= context;
		_userManager= userManager;
		_roleManager= roleManager;
		_configuration= configuration;
	}

	public async Task InitializeAsync()
	{
		await _context.Database.MigrateAsync();
	}

	public async Task RoleSeed()
	{
		foreach (var role in Enum.GetValues(typeof(Role)))
		{
            if (!await _roleManager.RoleExistsAsync(Role.Admin.ToString()))
            {
                await _roleManager.CreateAsync(new() { Name = Role.Admin.ToString() });
            }
        }
	}

	public async Task UserSeedAsync()
	{
		AppUser user = new()
		{
			UserName = _configuration["SuperAdminSettings:username"],
			Email = _configuration["SuperAdminSettings:email"]
		};
		await _userManager.CreateAsync(user, _configuration["SuperAdminSettings:password"]);
		await _userManager.AddToRoleAsync(user,Role.SuperAdmin.ToString());
	}
}
