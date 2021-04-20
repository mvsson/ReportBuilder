using System.ComponentModel.DataAnnotations;

namespace ReportEntities.Enums
{
    public enum Periodicity
    {
        [Display(Name = "Раз в день")]
        OnceADay = 1,
        [Display(Name = "Раз в неделю")]
        OnceAWeek = 7,
        [Display(Name = "Раз в месяц")]
        OnceAMonth = 30
    }
}
