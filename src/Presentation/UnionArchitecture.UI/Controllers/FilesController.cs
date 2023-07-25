using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using UnionArchitecture.Aplication.Abstraction.Services;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly IUploadFile _uploadFile;
    public FilesController(IUploadFile uploadFile)
    {
        _uploadFile = uploadFile;
    }

    [HttpPost]
    [Route("UploadFile")]
    public async Task<IActionResult> UploadFile(IFormFile formFile, CancellationToken cancellationToken)
    {
        var result = await _uploadFile.WriteFile(formFile);
        return Ok(result);
    }

    [HttpGet]
    [Route("DownloadFile/{file}")]
    public async Task<IActionResult> DownlandFile(string file)
    {
        var fileData = await _uploadFile.DownlandFile(file);
        return File(fileData, "application/octet-stream", file);
    }
}

        