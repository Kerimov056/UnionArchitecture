﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.TagDTOs;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;
    public TagsController(ITagService tagService) => _tagService = tagService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
       var tags = await _tagService.GetAllAsync();
       return Ok(tags);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdTag(Guid Id)
    {
        var tag = await _tagService.GetByIdAsync(Id);
        return Ok(tag);
    }

    [HttpPost]
    public async Task<IActionResult> Post(TagCreateDTOs tagCreateDTOs)
    {
        await _tagService.CreateAsync(tagCreateDTOs);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpDelete("{TagsId:Guid}")]
    public async Task<IActionResult> Remove(Guid TagsId)
    {
        await _tagService.RemoveAsync(TagsId);
        return Ok();
    }

    [HttpPut("{TagsId:Guid}")]
    public async Task<IActionResult> Uptade (Guid TagsId,[FromBody] TagUptadeDTO tagUptadeDTO)
    {
        await _tagService.UpdateAsync(TagsId, tagUptadeDTO);
        return Ok();
    }
}
