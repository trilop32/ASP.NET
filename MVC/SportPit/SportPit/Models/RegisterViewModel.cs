namespace SportPit.Models;

public class RegisterViewModel
{
    public string EmailAddress { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set ; } = string.Empty;
}