using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnionArchitecture.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    [HttpPost]
    [Route("UploadFile")]
    public async Task<IActionResult> UploadFile(IFormFile formFile, CancellationToken cancellationToken)
    {
        var result = await WriteFile(formFile);
        return Ok(result);
    }

    private async Task<string> WriteFile(IFormFile file)
    {
        string filename = "";
        var extension = "." + file.FileName.Split(".")[file.FileName.Split('.').Length - 1];
        filename = DateTime.Now.Ticks.ToString() + extension;

        var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");


        if (!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }


        var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
        using (var stream = new FileStream(exactpath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return filename;
    }
}
