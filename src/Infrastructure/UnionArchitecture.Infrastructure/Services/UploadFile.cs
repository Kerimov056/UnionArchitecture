using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using UnionArchitecture.Aplication.Abstraction.Services;

namespace UnionArchitecture.Infrastructure.Services;

public class UploadFile : IUploadFile
{
    public async Task<bool> DeleteFileAsync(string pathOrContainerName, string fileName)
    {
        pathOrContainerName = "Upload\\Files";
        string filePath = Path.Combine(pathOrContainerName, fileName);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<byte[]> DownlandFile(string file)
    {
        var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", file);

        return await System.IO.File.ReadAllBytesAsync(filepath);
    }

    public async Task<string> WriteFile(IFormFile file)
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

