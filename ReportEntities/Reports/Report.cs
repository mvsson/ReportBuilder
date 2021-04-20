using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ReportEntities.Enums;

namespace ReportEntities.Reports
{
    public abstract class Report
    {
        protected Report(int code)
        {
            MonitoringObjects = new List<MonitoringObject>();
            Code = code;
        }
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Код отчёта")]
        public readonly int Code;
        [Required]
        [Display(Name = "Должность")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "Объекты для наблюдения")]
        public ICollection<MonitoringObject> MonitoringObjects { get; set; }
        [Required]
        [Display(Name = "Первая дата отчёта")]
        public DateTime FirstReportDate { get; set; }
        [Required]
        [Display(Name = "Как часто отправлять отчёт?")]
        public Periodicity Periodicity { get; set; }
    }
}
