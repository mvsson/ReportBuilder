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
        public IEnumerable<Sensor> SensorsPrefer { get; set; }
    }
}