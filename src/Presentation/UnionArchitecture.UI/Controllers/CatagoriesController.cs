using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatagoriesController : ControllerBase
{
    private readonly AppDbContext _appDbContext;
    public CatagoriesController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var catagory = new Catagory()
        {
            Name = "Gulum",
            Description = "iyle metanet gulu iyle"
        };

        //await _appDbContext.Catagories.AddAsync(catagory);
        //await _appDbContext.SaveChangesAsync();

        //var result = _appDbContext.Catagories.ToListAsync();
        return Ok(catagory);
    }
}
