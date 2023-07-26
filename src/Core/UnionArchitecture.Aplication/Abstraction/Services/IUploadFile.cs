using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface IUploadFile
{
    Task<string> WriteFile(IFormFile file);
    Task<byte[]> DownlandFile(string file);
    Task<bool> DeleteFileAsync(string pathOrContainerName, string fileName);
    Task<List<string>> GetFilesAsync(string pathOrContainerName);
    Task<bool> HasFile(string pathOrContainerName, string fileName);

}

