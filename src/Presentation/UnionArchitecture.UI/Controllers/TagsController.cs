using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnionArchitecture.Aplication.Abstraction.Services;

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
}
