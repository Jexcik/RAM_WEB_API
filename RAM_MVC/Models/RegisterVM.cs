using System.ComponentModel.DataAnnotations;

namespace RAM_MVC.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Имя пользователя должно содержать от 1 до 200 символов")]
        public string FirstName {  get; set; }

        [Required(ErrorMessage = "Не указана фамилия пользователя")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Фамилия пользователя должно содержать от 1 до 200 символов")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Введите корректный Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указано логин")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Логин должен содержать от 2 до 200 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 200 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
