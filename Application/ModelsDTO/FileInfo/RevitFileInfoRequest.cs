using Application.ModelsDTO.FileInfo.Base;

namespace Application.ModelsDTO.FileInfo
{
    public class RevitFileInfoRequest:FileBase
    {
        public string? Creator { get; }

        public string? Editor { get; }

        public DateTime? DateCreation { get; }

        public DateTime? DateChange { get; }

    }
}
