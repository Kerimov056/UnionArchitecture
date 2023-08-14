﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using UnionArchitecture.Aplication.Abstraction.Services;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly IStorageFile _uploadFile;
    public FilesController(IStorageFile uploadFile)
    {
        _uploadFile = uploadFile;
    }

    [HttpPost]
    [Route("UploadFile")]
    public async Task<IActionResult> UploadFile(string pathOrContainerName,IFormFile formFile)
    {
        var result = await _uploadFile.WriteFile(pathOrContainerName, formFile);
        return Ok(result);
    }

    [HttpGet]
    [Route("DownlandFile/{pathOrContainerName}/{file}")]
    public async Task<IActionResult> DownlandFile(string pathOrContainerName, string file)
    {
        var filepath = Path.Combine(Directory.GetCurrentDirectory(), pathOrContainerName, file);

        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(filepath, out var contenttype))
        {
            contenttype = "application/octet-stream";
        }
        var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
        return File(bytes, contenttype, Path.GetFileName(filepath));
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

    [HttpPost("{pathOrContainerName}")]
    public async Task<IActionResult> Upload(string pathOrContainerName, [FromForm] IFormFileCollection files)
    {
        if (files == null || files.Count == 0)
        {
            return BadRequest("No files were uploaded.");
        }

        List<(string fileName, string pathOrContainerName)> uploadedFiles = await _uploadFile.UploadAsync(pathOrContainerName, files);

        return Ok(uploadedFiles);
    }

}

        