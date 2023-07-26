using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UnionArchitecture.Aplication.Abstraction.Services;
using UnionArchitecture.Aplication.DTOs.Blog;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;
    public BlogsController(IBlogService blogService) => _blogService = blogService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Blogs = await _blogService.GetAllAsync();
        return Ok(Blogs);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] BlogCreateDTO blogCreateDTO)
    {
        await _blogService.AddAsync(blogCreateDTO);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpGet("{Id:Guid}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var ByBlog = await _blogService.GetByIdAsync(Id);
        return Ok(ByBlog);
    }

    [HttpPut("{Id:Guid}")]
    public async Task<IActionResult> Update(Guid Id, [FromForm] BlogUpdateDTo blogUpdateDTo)
    {
        await _blogService.UpdateAsync(Id, blogUpdateDTo);
        return Ok();
    }

    [HttpDelete("{Id:Guid}")]
    public async Task<IActionResult> Remove(Guid Id)
    {
        await _blogService.RemoveAsync(Id);
        return Ok();
    }
}
