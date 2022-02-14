namespace CrowdFundingApplication.Models;

public class PayViewModel
{
    public string Sum { get; set; }

    [Required]
    public string CardsName { get; set; }

    [Required]
    public string NumberOfCreadirCard { get; set; }

    [Required]
    public string MonthAndYear { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string CVC { get; set; }
}