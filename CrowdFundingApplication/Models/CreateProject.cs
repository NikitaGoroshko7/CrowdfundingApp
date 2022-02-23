namespace CrowdFundingApplication.Models;

public class CreateProject
{
    public Guid Id { get; set; }
    public string NameOfProject { get; set; }
    public string ImageName { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int Sum { get; set; }
    public string Date { get; set; }
}