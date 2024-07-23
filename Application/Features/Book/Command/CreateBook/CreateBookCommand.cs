using MediatR;

namespace Application.Features.Book.Command.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
