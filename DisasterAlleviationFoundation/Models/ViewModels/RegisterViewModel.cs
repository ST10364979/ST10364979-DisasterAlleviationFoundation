using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models.ViewModels
{

    // View model for the Register form
    public class RegisterViewModel
    {

        // Email used as the account username; must be a valid email format
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;

        // Chosen password; rendered as a password field
        [Required, DataType(DataType.Password)] public string Password { get; set; } = string.Empty;

        // Must match Password; confirms there were no typos
        [Required, DataType(DataType.Password), Compare(nameof(Password))] public string ConfirmPassword { get; set; } = string.Empty;
    }
}
