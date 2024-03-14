using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Contracts
{
    public record BooksRequest(

        [Required(ErrorMessage = "Название книги обязательно для заполнения!")]
        string Title,

        [Required(ErrorMessage = "Описание обязательно для заполнения!")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Описание должно содержать от 10 до 200 символов")]
        string Description,

        [Required(ErrorMessage ="Не указана цена товара!")]
        [Range(1000,10000, ErrorMessage ="Цена товара должна быть в диапазоне от 1000 до 10000 р.")]
        decimal Prise
        );
}
