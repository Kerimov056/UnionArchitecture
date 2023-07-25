using Microsoft.AspNetCore.Http;

namespace UnionArchitecture.Aplication.Abstraction.Services;

public interface IUploadFile
{
    Task<string> WriteFile(IFormFile file);
    Task<byte[]> DownlandFile(string file);
}

