using Microsoft.AspNetCore.Http;
using UnionArchitecture.Aplication.Abstraction.Services;

namespace UnionArchitecture.Infrastructure.Services;

public class StorageService : IStorgeService
{
    private readonly IStorageFile _storgeFile;
    public StorageService(IStorageFile storgeFile) =>  _storgeFile = storgeFile;

    public Task<bool> DeleteFileAsync(string pathOrContainerName, string fileName)
    => _storgeFile.DeleteFileAsync(pathOrContainerName, fileName);

    public Task<byte[]> DownlandFile(string file)
    => _storgeFile.DownlandFile(file);

    public Task<List<string>> GetFilesAsync(string pathOrContainerName)
    => _storgeFile.GetFilesAsync(pathOrContainerName);

    public Task<bool> HasFile(string pathOrContainerName, string fileName)
    => _storgeFile.HasFile(pathOrContainerName, fileName);

    public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
    => _storgeFile.UploadAsync(pathOrContainerName, files);

    public Task<string> UploadFileAsync(string pathOrContainerName, byte[] fileData, string fileName)
    => _storgeFile.UploadFileAsync(pathOrContainerName, fileData, fileName);

    public Task<string> WriteFile(string pathOrContainerName, IFormFile file)
    => _storgeFile.WriteFile(pathOrContainerName, file);
}
