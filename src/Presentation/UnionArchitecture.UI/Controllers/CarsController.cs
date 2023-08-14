using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Product;
using UnionArchitecture.Domain.Entities;
using UnionArchitecture.Persistence.Implementations.Services;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;
    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBasket([Required][FromBody] CarCreateDTO CarDTO)
    {

        await _carService.CreateAsync(CarDTO);
        return StatusCode((int)HttpStatusCode.Created);
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Slider = await _carService.GetAllAsync();
        return Ok(Slider);
    }
}
