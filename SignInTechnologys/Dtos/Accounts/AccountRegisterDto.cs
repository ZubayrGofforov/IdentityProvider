using SignInTechnologys.Common.Attributes;
using SignInTechnologys.Entities;
using System.ComponentModel.DataAnnotations;

namespace SignInTechnologys.Dtos.Accounts
{
    public class AccountRegisterDto
    {
        [Required, MinLength(3), MaxLength(35)]
        public string FirstName { get; set; } = String.Empty;

        [Required, MinLength(3), MaxLength(35)]
        public string LastName { get; set; } = String.Empty;

        [MaxFileSize(2), AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
        public IFormFile? Image { get; set; }

        public string PhoneNumber { get; set; } = String.Empty;

        [Email]
        public string Email { get; set; } = String.Empty;

        [StrongPassword]
        public string Password { get; set; } = String.Empty;

        public static implicit operator User(AccountRegisterDto accountRegisterDto)
        {
            return new User() 
            { 
                FirstName = accountRegisterDto.FirstName,
                LastName = accountRegisterDto.LastName,
                PhoneNumber = accountRegisterDto.PhoneNumber,
                Email = accountRegisterDto.Email
            };
        }
    }
}
