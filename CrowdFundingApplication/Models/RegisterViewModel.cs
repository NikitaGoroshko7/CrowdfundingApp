namespace CrowdFundingApplication.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не указано имя!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указан Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Вы не приняли соглашение!")]
        public bool Agreement { get; set; }
    }
}
