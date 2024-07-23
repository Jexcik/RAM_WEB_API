namespace Application.Features.Book.Queries.GetAllBooks;

public class BookDto
{
    public Guid Id { get; }
    public string Title { get; }
    public string Description { get; }
    public decimal Price { get; }
}
