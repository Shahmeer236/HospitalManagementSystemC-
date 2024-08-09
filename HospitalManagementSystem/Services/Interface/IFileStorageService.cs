public interface IFileStorageService
{
    Task<string> SaveFileAsync(byte[] fileBytes, string fileName);
    Task<byte[]> DownloadFileAsync(string filePath);
    void DeleteFile(string filePath);
}
