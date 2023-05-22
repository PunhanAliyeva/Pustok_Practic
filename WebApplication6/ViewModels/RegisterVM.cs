using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace WebApplication6.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(6)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
