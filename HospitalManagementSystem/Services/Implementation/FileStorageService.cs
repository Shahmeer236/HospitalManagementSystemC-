//public class FileStorageService : IFileStorageService
//{
//    private readonly string _storagePath = "PathToYourStorage"; // Define your storage path

//    public async Task<string> SaveFileAsync(byte[] fileBytes, string fileName)
//    {
//        var filePath = Path.Combine(_storagePath, fileName);
//        await File.WriteAllBytesAsync(filePath, fileBytes);
//        return filePath;
//    }


//    public async Task<byte[]> DownloadFileAsync(string filePath)
//    {
//        return await File.ReadAllBytesAsync(filePath);
//    }

//    public void DeleteFile(string filePath)
//    {
//        if (File.Exists(filePath))
//        {
//            File.Delete(filePath);
//        }
//    }
//}




using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class FileStorageService : IFileStorageService
{
    private readonly string _storagePath;

    public FileStorageService(IConfiguration configuration)
    {
        // Get the path to the configured storage folder from appsettings.json
        // _storagePath = configuration["FileStoragePath"] ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Downloads");
        _storagePath = "MedicalReport";
        // Ensure the directory exists
        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }

    public async Task<string> SaveFileAsync(byte[] fileBytes, string fileName)
    {
        var filePath = Path.Combine(_storagePath, fileName);
        await File.WriteAllBytesAsync(filePath, fileBytes);
        return filePath;
    }

    public async Task<byte[]> DownloadFileAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found.", filePath);
        }
        return await File.ReadAllBytesAsync(filePath);
    }

    public void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}
