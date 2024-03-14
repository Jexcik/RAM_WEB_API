﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Contracts.Identity
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage = "Имя должно быть заполнено")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

    }
}
