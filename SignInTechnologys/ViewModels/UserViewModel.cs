namespace SignInTechnologys.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string? ImagePath { get; set; }

        public string PhoneNumber { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string? CreatedAt { get; set; }

        public string? UpdatedAt { get; set; }
    }
}
