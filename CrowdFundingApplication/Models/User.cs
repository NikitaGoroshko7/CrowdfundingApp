namespace CrowdFundingApplication.Models
{
    public class User : IdentityUser
    {
        public string Avatar { get; set; }
        public string Description { get; set; }
        public int Balance { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
