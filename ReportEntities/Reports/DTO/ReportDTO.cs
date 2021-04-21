using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using ReportEntities.Enums;

namespace ReportEntities.Reports.DTO
{
    public class ReportDTO
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Код отчёта")]
        public ReportCode Code { get; set; }
        [Required]
        [Display(Name = "Название отчёта")]
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
        [Required]
        [Display(Name = "Датчики для наблюдения")]
        public ICollection<Sensor> SensorsPrefer { get; set; }
        [Required]
        [Display(Name = "Период отчёта")]
        public ReportRange Range { get; set; }
    }
}
