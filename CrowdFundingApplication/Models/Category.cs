namespace CrowdFundingApplication.Models;

public enum Category
{
    [Display(Name = "Музыка")]
    Music = 1,
    [Display(Name = "Кино и видео")]
    Cinema = 2,
    [Display(Name = "События")]
    Events = 3,
    [Display(Name = "Бизнесс")]
    Bussines = 4,
    [Display(Name = "Литература")]
    Litreature = 5,
    [Display(Name = "Журналистика")]
    Journalism = 6,
    [Display(Name = "Наука")]
    Science = 7,
    [Display(Name = "Благотварительность")]
    Charity = 8,
    [Display(Name = "Еда")]
    Food = 9,
    [Display(Name = "Игры")]
    Games = 10,
    [Display(Name = "Обучение")]
    Learning = 11,
    [Display(Name = "Спорт")]
    Sport = 12,
    [Display(Name = "Театр")]
    Theatre = 13,
    [Display(Name = "Путешествие")]
    Travel = 14,
    [Display(Name = "Технологии")]
    Technologys = 15,
    [Display(Name = "Природа")]
    Nature = 16,
    [Display(Name = "Фотография")]
    Photography = 17,
    [Display(Name = "Дизайн")]
    Design = 18
}