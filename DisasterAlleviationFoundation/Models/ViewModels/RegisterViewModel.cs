﻿using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required, DataType(DataType.Password)] public string Password { get; set; } = string.Empty;
        [Required, DataType(DataType.Password), Compare(nameof(Password))] public string ConfirmPassword { get; set; } = string.Empty;
    }
}
