﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Slider;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SlidersController : ControllerBase
{
    private readonly ISliderService _sliderService;
    public SlidersController(ISliderService sliderService) => _sliderService = sliderService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Slider = await _sliderService.GetAllAsync();
        return Ok(Slider);
    }

    [HttpPost]
    public async Task<IActionResult> Post(SliderCreateDTO sliderCreateDTO)
    {
        await _sliderService.CreateAsync(sliderCreateDTO);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var BySlider = await _sliderService.GetByIdAsync(id);
        return Ok(BySlider);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        await _sliderService.RemoveAsync(id);
        return Ok();
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Uptade(Guid id, [FromBody] SliderUptadeDTO sliderUptadeDTO)
    {
        await _sliderService.UpdateAsync(id, sliderUptadeDTO);
        return Ok();
    }
}
