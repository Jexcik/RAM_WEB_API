using Domain.Common;

namespace Domain.Models
{
    public class Book : BaseEntity
    {
        public const int MAX_TITLE_LENGTH = 250;

        //private Book(Guid id, string title, string description, decimal price)
        //{
        //    Id = id;
        //    Title = title;
        //    Description = description;
        //    Price = price;
        //}

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //public static (Book book, string Error) Create(
        //    Guid id,
        //    string title,
        //    string description,
        //    decimal price
        //)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
        //    {
        //        error = "Title can not be empty or longer then 250 symbols";
        //    }

        //    var book = new Book(id, title, description, price);

        //    return (book, error);
        //}
    }
}
