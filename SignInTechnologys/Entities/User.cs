namespace SignInTechnologys.Entities;
public class User
{
    public long Id { get; set; }

    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string? ImagePath { get; set; }

    public string PhoneNumber { get; set; } = String.Empty;

    public string Email { get; set; } = String.Empty;

    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
