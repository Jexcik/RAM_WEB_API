using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Book.Command.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IBooksRepository _booksRepository;
        private readonly IAppLogger<CreateBookCommandHandler> _logger;

        public CreateBookCommandHandler(
            IMapper mapper,
            IBooksRepository booksRepository,
            IAppLogger<CreateBookCommandHandler> logger
        )
        {
            _mapper = mapper;
            _booksRepository = booksRepository;
            _logger = logger;
        }

        public async Task<Guid> Handle(
            CreateBookCommand request,
            CancellationToken cancellationToken
        )
        {
            var book = _mapper.Map<Domain.Models.Book>(request);
            await _booksRepository.CreateAsync(book);
            _logger.LogInformation("Book была успешно получена");
            return book.Id;
        }
    }
}
