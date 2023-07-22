using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Catagory;
using UnionArchitecture.Aplication.DTOs.Flowers;
using UnionArchitecture.Persistence.Implementations.Services;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlowersController : ControllerBase
{
    private readonly IFlowerService _flowerService;
    public FlowersController(IFlowerService flowerService) => _flowerService = flowerService;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = await _flowerService.GetAllAsync();
        return Ok(query);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FlowerCreateDTO flowerCreateDTO)
    {
        await _flowerService.CreateAsync(flowerCreateDTO);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpDelete("{FlowerId:Guid}")]
    public async Task<IActionResult> Remove(Guid FlowerId)
    {
        await _flowerService.RemoveAsync(FlowerId);
        return Ok();
    }

    [HttpPut("{FlowersId:Guid}")]
    public async Task<IActionResult> Update(Guid FlowersId, [FromBody] FlowerUptadeDTO flowerUptadeDTO)
    {
        await _flowerService.UpdateAsync(FlowersId, flowerUptadeDTO);
        return Ok();
    }
}
