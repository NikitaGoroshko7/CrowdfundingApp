namespace CrowdFundingApplication.Models;

public class ForgotPasswordViewModel
{
    [Required(ErrorMessage = "Email должен быть введен!")]
    [EmailAddress]
    public string Email { get; set; }
}
