
namespace Application.ModelsDTO.FileInfo
{
    public record RevitFileInfoResponse(
        Guid id,
        string fileName,
        string filePath,
        string create,
        string editor,
        DateTime dateCreation,
        DateTime dateChange
        );
}
