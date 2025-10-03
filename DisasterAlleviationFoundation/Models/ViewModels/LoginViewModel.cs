using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models.ViewModels
{
    // View model that the Login form binds to
    public class LoginViewModel
    {
        // User's email (used to sign in); must be a valid email format
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;

        // User's password; rendered as a password field in the view
        [Required, DataType(DataType.Password)] public string Password { get; set; } = string.Empty;

        // Keep the user signed in across sessions if checked
        public bool RememberMe { get; set; }
    }
}
