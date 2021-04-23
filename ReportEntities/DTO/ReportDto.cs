using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ReportEntities.Enums;

namespace ReportEntities.DTO
{
    public class  ReportDto
    {
        [JsonConstructor]
        public ReportDto()
        {
            MonitoringObjects = new List<MonitoringObject>();
            MonitoringSensors = new List<Sensor>();
        }
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonPropertyName("code")]
        [Display(Name = "Код отчёта")]
        public ReportCode Code { get; set; }

        [Required(ErrorMessage = "Введите название отчёта")]
        [JsonPropertyName("jobTitle")]
        [Display(Name = "Название отчёта")]
        public string JobTitle { get; set; }

        [Required]
        [JsonPropertyName("monitoringObjects")]
        [Display(Name = "Объекты для наблюдения")]
        public IEnumerable<MonitoringObject> MonitoringObjects { get; set; }

        [Required]
        [JsonPropertyName("firstReportDate")]
        [Display(Name = "Первая дата отчёта")]
        [DataType(DataType.Date)]
        public DateTime FirstReportDate { get; set; }

        [Required]
        [JsonPropertyName("periodicity")]
        [Display(Name = "Как часто отправлять отчёт?")]
        public Periodicity Periodicity { get; set; }

        [Required]
        [JsonPropertyName("sensorsPrefer")]
        [Display(Name = "Датчики для наблюдения")]
        public IEnumerable<Sensor> MonitoringSensors { get; set; }

        [Required]
        [JsonPropertyName("range")]
        [Display(Name = "Период отчёта")]
        public ReportRange Range { get; set; }
    }
}
