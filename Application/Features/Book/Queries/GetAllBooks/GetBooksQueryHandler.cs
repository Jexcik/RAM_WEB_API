using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Book.Queries.GetAllBooks;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<BookDto>>
{
    private IMapper _mapper;
    private IBooksRepository _repository;

    public GetBooksQueryHandler(IMapper mapper, IBooksRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<BookDto>> Handle(
        GetBooksQuery request,
        CancellationToken cancellationToken
    )
    {
        var books = await _repository.GetAsync();
        var data = _mapper.Map<List<BookDto>>(books);
        return data;
    }
}
