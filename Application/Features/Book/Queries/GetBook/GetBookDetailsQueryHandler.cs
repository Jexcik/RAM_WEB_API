using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Book.Queries.GetBook;

public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, BookDetailsDto>
{
    private IMapper _mapper;
    private IBooksRepository _repository;
    private readonly IAppLogger<GetBookDetailsQueryHandler> _logger;

    public GetBookDetailsQueryHandler(
        IMapper mapper,
        IBooksRepository repository,
        IAppLogger<GetBookDetailsQueryHandler> logger
    )
    {
        _mapper = mapper;
        _repository = repository;
        _logger = logger;
    }

    public async Task<BookDetailsDto> Handle(
        GetBookDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        var book = await _repository.GetByIdAsync(request.Id);
        var data = _mapper.Map<BookDetailsDto>(book);
        _logger.LogInformation("Книга была успешно получена");
        return data;
    }
}
