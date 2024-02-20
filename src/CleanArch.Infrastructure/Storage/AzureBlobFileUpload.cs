using CleanArch.Application.Services;

namespace CleanArch.Infrastructure.Storage;

internal class AzureBlobFileUpload : IFileUpload
{
    public string Upload(string fileName, Stream stream)
    {
        throw new NotImplementedException();
    }
}
