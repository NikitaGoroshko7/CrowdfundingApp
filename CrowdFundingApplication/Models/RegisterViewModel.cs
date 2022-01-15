namespace CrowdFundingApplication.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool Agreement { get; set; }
    }
}
