using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookcaseManager.Models
{
    public class LoginModel
    {
        [Required]
        public string Nickname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Hasło musi składać się conajmniej z 6 znaków, a maksymalnie ze 100.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Podane hasła nie są identyczne.")]
        public string RetypePassword { get; set; }
    }
}