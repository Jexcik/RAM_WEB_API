using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Book.Command.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private IBooksRepository _booksRepository;
        private readonly IAppLogger<DeleteBookCommandHandler> _logger;

        public DeleteBookCommandHandler(
            IBooksRepository booksRepository,
            IAppLogger<DeleteBookCommandHandler> logger
        )
        {
            _booksRepository = booksRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(
            DeleteBookCommand request,
            CancellationToken cancellationToken
        )
        {
            var response = await _booksRepository.GetByIdAsync(request.Id);
            await _booksRepository.DeleteAsync(response);
            return Unit.Value;
        }
    }
}
