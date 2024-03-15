using Application.Contracts.Applcationi;

namespace Application.ModelsDTO.FileInfo.Base
{
    public abstract class FileBase : IFile
    {
        public Guid Id { get; }

        public string? FileName { get; }

        public string? FilePath { get; }

    }
}
