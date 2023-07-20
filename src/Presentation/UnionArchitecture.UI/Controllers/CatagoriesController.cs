using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Contexts;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatagoriesController : ControllerBase
{
    private readonly ICatagoryService _catagoryService;

    public CatagoriesController(ICatagoryService catagoryService)
    {
        _catagoryService = catagoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = await _catagoryService.GetAllAsync();
        return Ok(query);
    }

    //[HttpPost]
    //public async Task<IActionResult> Post(Catagory catagory)
    //{
    //    await _catagoryService.AddAsync(catagory);
    //    return StatusCode((int)HttpStatusCode.Created);
    //}

    //[HttpDelete("{catagoryId:Guid}")]
    //public async Task<IActionResult> Remove(string catagoryId)
    //{
    //    await _catagoryService.RemoveAsync(catagoryId);
    //    return Ok();
    //}

    //[HttpPut("{catagoryId:Guid}")]
    //public async Task<IActionResult> Update(Guid catagoryId, [FromBody] CatagoryUpdateDTO catagoryUpdateDTO)
    //{
    //    await _catagoryService.UpdateAsync(catagoryId, catagoryUpdateDTO);
    //    return Ok();
    //}

}
