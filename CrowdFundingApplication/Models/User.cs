namespace CrowdFundingApplication.Models;

public class User : IdentityUser
{
    public string AvatarFileName { get; set; }
    public string Description { get; set; }
    public decimal Balance { get; set; }
    public int Age { get; set; }
    public string Sex { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}
