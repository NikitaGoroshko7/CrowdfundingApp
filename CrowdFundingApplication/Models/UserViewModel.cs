namespace CrowdFundingApplication.Models;

public class UserViewModel
{
    public string UserName { get; set; }
    public string AvatarFileName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string Description { get; set; }
    public decimal Balance { get; set; }
    public Sex Sex { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}
