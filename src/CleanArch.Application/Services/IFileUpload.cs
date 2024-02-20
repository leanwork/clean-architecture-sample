namespace CleanArch.Application.Services;

public interface IFileUpload
{
    string Upload(string fileName, Stream stream);
}
