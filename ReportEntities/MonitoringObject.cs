using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportEntities
{
    public class MonitoringObject
    {
        [Display(Name = "Код объекта")]
        public int Code { get; set; }
        [Display(Name = "Имя объекта")]
        public string Name { get; set; }
    }
}
