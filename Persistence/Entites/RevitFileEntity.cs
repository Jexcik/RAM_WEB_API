
namespace Persistence.Entites
{
    public class RevitFileEntity
    {
        public Guid? Id { get; set; }

        public string? FileName { get; set; }

        public string? FilePath { get; set; }

        public string? Creator { get; set; }

        public string? Editor { get; set; }

        public DateTime? DateCreation { get; set; }

        public DateTime? DateChange { get; set; }

    }
}
