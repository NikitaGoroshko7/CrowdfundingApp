namespace CrowdFundingApplication.Models
{
    public class InputViewModel
    {
        [Required(ErrorMessage = "Вы не ввели имя!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вы не ввели пароль!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
