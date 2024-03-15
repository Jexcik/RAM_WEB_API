
namespace Application.Contracts.Applcationi
{
    public interface IFile
    {
         Guid Id { get; set; }

        string? FileName { get; set; }

        string? FilePath { get; set; }

    }
}
