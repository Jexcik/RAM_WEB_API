﻿namespace Application.ModelsDTO.FileInfo

{
    public record RevitFileInfoRequest(
        Guid id,
        string fileName,
        string filePath,
        string creator,
        string editor,
        DateTime dateCreation,
        DateTime dateChange
        );
}
