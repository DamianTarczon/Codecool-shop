using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Please enter your username")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Username should be at least 4 characters long")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail")]
        [StringLength(40, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }
    }
}
