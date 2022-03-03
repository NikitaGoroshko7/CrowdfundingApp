namespace CrowdFundingApplication.Models;

public class EditProjectViewModel
{
    [Required(ErrorMessage = "Не указано название проекта!")]
    public string NameOfProject { get; set; }

    public IFormFile Image { get; set; }
    public string ImageName { get; set; }

    [StringLength(125, MinimumLength = 25, ErrorMessage = "Длина строки должна быть от 25 до 125 символов !")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Не выбрана категория проекта!")]
    public CategoryEnum Category { get; set; }

    [Required(ErrorMessage = "Не указана сумма проекта!")]
    public decimal Sum { get; set; }

    [Required(ErrorMessage = "Не указана дата окончания проекта!")]
    public DateTime Date { get; set; }
}