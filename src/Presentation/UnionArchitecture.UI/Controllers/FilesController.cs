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

    [HttpDelete("DeleteFile/{pathOrContainerName}/{fileName}")]
    public async Task<IActionResult> DeleteFile(string pathOrContainerName, string fileName)
    {
        bool isDeleted = await _uploadFile.DeleteFileAsync(pathOrContainerName, fileName);
        if (isDeleted)
        {
            return Ok("File Deleted");
        }
        else
        {
            return NotFound("Not Found File");
        }
    }

    [HttpGet("{pathOrContainerName}")]
    public async Task<IActionResult> GetFiles(string pathOrContainerName)
    {
        List<string> fileNames = await _uploadFile.GetFilesAsync(pathOrContainerName);
        return Ok(fileNames);
    }

    [HttpGet("HasFile/{pathOrContainerName}/{fileName}")]
    public async Task<IActionResult> HasFile(string pathOrContainerName, string fileName)
    {
        bool hasFile = await _uploadFile.HasFile(pathOrContainerName, fileName);
        return Ok(hasFile);
    }
}

        