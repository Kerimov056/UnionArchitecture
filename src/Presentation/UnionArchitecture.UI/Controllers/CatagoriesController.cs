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
    public CatagoriesController(ICatagoryService catagoryService) => _catagoryService = catagoryService;


    /// <summary>
    /// Catagory GetAll
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = await _catagoryService.GetAllAsync();
        return Ok(query);
    }

    /// <summary>
    /// GetByID Catagory
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdCatagory(Guid Id)
    {
        var query = await _catagoryService.GetByIdAsync(Id);
        return Ok(query);
    }

    /// <summary>
    /// Create Catagory
    /// </summary>
    /// <param name="CatagoryCreateDTO"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(CatagoryCreateDTO CatagoryCreateDTO)
    {
        await _catagoryService.CreateAsync(CatagoryCreateDTO);
        return StatusCode((int)HttpStatusCode.Created);
    }

    /// <summary>
    /// Remove Catagory id
    /// </summary>
    /// <param name="catagoryId"></param>
    /// <returns></returns>
    [HttpDelete("{catagoryId:Guid}")]
    public async Task<IActionResult> Remove(Guid catagoryId)
    {
        await _catagoryService.RemoveAsync(catagoryId);
        return Ok();
    }

    /// <summary>
    /// Update Catagory Id
    /// </summary>
    /// <param name="catagoryId"></param>
    /// <param name="catagoryUpdateDTO"></param>
    /// <returns></returns>
    [HttpPut("{catagoryId:Guid}")]
    public async Task<IActionResult> Update(Guid catagoryId, [FromBody] CatagoryUpdateDTO catagoryUpdateDTO)
    {
        await _catagoryService.UpdateAsync(catagoryId, catagoryUpdateDTO);
        return Ok();
    }

}
