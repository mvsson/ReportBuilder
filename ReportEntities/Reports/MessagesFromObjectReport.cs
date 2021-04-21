using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ReportEntities.Enums;

namespace ReportEntities.Reports
{
    public class MessagesFromObjectReport : Report
    {
        public MessagesFromObjectReport() : base(code : ReportCode.MessagesFromObject)
        {
            SensorsPrefer = new List<Sensor>();
        }

        [Required]
        [Display(Name = "Датчики для наблюдения")]
        public ICollection<Sensor> SensorsPrefer { get; set; }
    }
}