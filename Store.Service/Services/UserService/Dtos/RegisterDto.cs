using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.UserService.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_])(.)(?!\\1{2,}).{6,}$",
         ErrorMessage = "Password must be at least 6 characters long, contain at least one digit, one lowercase letter, one uppercase letter, one non-alphanumeric character, and at least two unique characters.")]
        public string Password { get; set; }
    }
}
