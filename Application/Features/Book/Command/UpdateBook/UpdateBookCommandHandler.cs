using Application.Contracts.Logging;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Book.Command.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private IMapper _mapper;
        private IBooksRepository _repository;
        private readonly IAppLogger<UpdateBookCommandHandler> _logger;

        public UpdateBookCommandHandler(
            IMapper mapper,
            IBooksRepository repository,
            IAppLogger<UpdateBookCommandHandler> logger
        )
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<Unit> Handle(
            UpdateBookCommand request,
            CancellationToken cancellationToken
        )
        {
            var response = _mapper.Map<Domain.Models.Book>(request);
            await _repository.UpdateAsync(response);
            return Unit.Value;
        }
    }
}
