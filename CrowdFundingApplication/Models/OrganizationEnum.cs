namespace CrowdFundingApplication.Models;

public enum OrganizationEnum
{
    [Display(Name = "Физическое лицо")]
    Individual = 1,
    [Display(Name = "ИП")]
    IndividualEntrepreneur = 2,
    [Display(Name = "ООО")]
    OOO = 3,
    [Display(Name = "Некоммерческая организация")]
    NonComercial = 4,
    [Display(Name = "Другое юридическое лицо")]
    OtherLegalEntity = 5
}