using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportEntities.Enums
{
    public enum ReportRange
    {
        [Display(Name = "Отчёт за день")]
        Day = 1,
        [Display(Name = "Отчёт за месяц")]
        Month = 30,
        [Display(Name = "Отчёт за год")]
        Year = 365,
    }
}
