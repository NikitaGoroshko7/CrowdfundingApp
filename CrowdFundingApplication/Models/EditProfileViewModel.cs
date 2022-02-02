﻿namespace CrowdFundingApplication.Models;

public class EditProfileViewModel
{
    [EmailAddress (ErrorMessage = "Неверный email адрес !")]
    public string Email { get; set; }

    [Phone (ErrorMessage = "Неверный формат номера телефона !")]
    public string NumberOfPhone { get; set; }

    [Range(18, 80, ErrorMessage = "Недопустимый возраст !")]
    public int? Age { get; set; }

    public string Sex { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    [DataType(DataType.Password)]
    public string NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "Пароль введен неверно")]
    public string ConfirmPassword { get; set; }

    [StringLength(100, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 100 символов !")]
    public string Description { get; set; }

}

