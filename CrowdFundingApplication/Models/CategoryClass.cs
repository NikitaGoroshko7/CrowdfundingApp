namespace CrowdFundingApplication.Models;

public class CategoryClass
{
    [Required]
    public string CategoryTypeAsString
    {
        get
        {
            return this.CategoryType.ToString();
        }
        set
        {
            CategoryType = (Category)Enum.Parse(typeof(Category), value, true);
        }
    }

    public Category CategoryType { get; set; }
}