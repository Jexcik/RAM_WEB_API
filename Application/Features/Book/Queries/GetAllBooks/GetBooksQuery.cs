using MediatR;

namespace Application.Features.Book.Queries.GetAllBooks;

public record GetBooksQuery : IRequest<List<BookDto>>, IRequest<BookDto>;
