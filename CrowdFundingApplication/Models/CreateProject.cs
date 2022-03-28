namespace CrowdFundingApplication.Models;

public class CreateProject
{
    public Guid Id { get; set; }
    public string NameOfProject { get; set; }
    public string ImageName { get; set; }
    public string Description { get; set; }
    public CategoryEnum Category { get; set; }
    public decimal Sum { get; set; }
    public DateTime Date { get; set; }
    public string FullDescription { get; set; }
    public string FullName { get; set; }
    public string Bill { get; set; }
    public string Bank { get; set; }
    public OrganizationEnum Type { get; set; }
    public string Initials { get; set; }
}