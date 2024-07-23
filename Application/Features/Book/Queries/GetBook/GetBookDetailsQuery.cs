using MediatR;

namespace Application.Features.Book.Queries.GetBook;

public record GetBookDetailsQuery(Guid Id) : IRequest<BookDetailsDto>;
