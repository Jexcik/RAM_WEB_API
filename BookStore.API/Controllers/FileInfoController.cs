using Application.Contracts.Services;
using Application.ModelsDTO.FileInfo;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace RAM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileInfoController : ControllerBase
    {
        private readonly IFilesService _filesService;
        public FileInfoController(IFilesService filesService)
        {
            _filesService = filesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RevitFileInfoResponse>>> GetFiles()
        {
            var files = await _filesService.GetAllFiles();

            var responce = files
                .Select(f => new RevitFileInfoResponse(f.Id, f.FileName, f.FilePath, f.Creator, f.Editor, (DateTime)f.DateCreation, (DateTime)f.DateChange));

            return Ok(responce);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateFile([FromBody] RevitFileInfoRequest request)
        {
            var (file, error) = RevitFile.Create(
                request.fileName,
                request.filePath,
                request.creator,
                request.editor,
                request.dateCreation,
                request.dateChange
                );

            var fileId = await _filesService.CreateFile(file);

            return Ok(fileId);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            return Ok(await _filesService.DeleteFile(id));
        }
    }
}
