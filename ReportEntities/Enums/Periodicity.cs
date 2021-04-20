using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
