using Application.Features.Book.Command.CreateBook;
using Application.Features.Book.Command.DeleteBook;
using Application.Features.Book.Command.UpdateBook;
using Application.Features.Book.Queries.GetBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<BookDetailsDto> GetBooks(Guid id)
        {
            var entityDetails = await _mediator.Send(new GetBookDetailsQuery(id));
            return entityDetails;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBook(CreateBookCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBooks), new { id = response }, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateBooks([FromBody] UpdateBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            var command = new DeleteBookCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
