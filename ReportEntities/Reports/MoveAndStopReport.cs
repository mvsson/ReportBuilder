using System;
using System.ComponentModel.DataAnnotations;
using ReportEntities.Enums;

namespace ReportEntities.Reports
{
    public class MoveAndStopReport : Report
    {
        public MoveAndStopReport() : base(code : ReportCode.MoveAndStop)
        { }

        [Required]
        [Display(Name = "Период отчёта")]
        public ReportRange Range { get; set; }
    }
}