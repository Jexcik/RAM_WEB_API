namespace Domain.Models
{
    public class RevitFile
    {
        private RevitFile(string fileName, string filePath, string creator, string editor, DateTime dateCreator, DateTime dateChange)
        {
            Id = Guid.NewGuid();
            FileName = fileName;
            FilePath = filePath;
            Creator = creator;
            Editor = editor;
            DateCreation = dateCreator;
            DateChange = dateChange;
        }
        public Guid? Id { get; }

        public string? FileName { get; }

        public string? FilePath { get; }

        public string? Creator { get; }

        public string? Editor { get; }

        public DateTime? DateCreation { get; }

        public DateTime? DateChange { get; }

        public static (RevitFile file, string Error) Create(string fileName, string filePath, string creator, string editor, DateTime dateCreator, DateTime dateChange)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(fileName) || fileName.Length > 10)
            {
                error = "Имя файла не может быть пустым!";
            }

            var file = new RevitFile(fileName, filePath, creator, editor, dateCreator, dateChange);

            return (file, error);
        }
    }
}
