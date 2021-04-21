using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ReportEntities.Enums;

namespace ReportEntities.DTO
{
    public class ReportDto
    {
        [JsonConstructor]
        public ReportDto()
        {
            MonitoringObjects = new List<MonitoringObject>();
            SensorsPrefer = new List<Sensor>();
        }
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [Required]
        [JsonPropertyName("code")]
        [Display(Name = "Код отчёта")]
        public ReportCode Code { get; set; }
        [Required]
        [JsonPropertyName("jobTitle")]
        [Display(Name = "Название отчёта")]
        public string JobTitle { get; set; }
        [Required]
        [JsonPropertyName("monitoringObjects")]
        [Display(Name = "Объекты для наблюдения")]
        public ICollection<MonitoringObject> MonitoringObjects { get; set; }
        [Required]
        [JsonPropertyName("firstReportDate")]
        [Display(Name = "Первая дата отчёта")]
        public DateTime FirstReportDate { get; set; }
        [Required]
        [JsonPropertyName("periodicity")]
        [Display(Name = "Как часто отправлять отчёт?")]
        public Periodicity Periodicity { get; set; }
        [Required]
        [JsonPropertyName("sensorsPrefer")]
        [Display(Name = "Датчики для наблюдения")]
        public ICollection<Sensor> SensorsPrefer { get; set; }
        [Required]
        [JsonPropertyName("range")]
        [Display(Name = "Период отчёта")]
        public ReportRange Range { get; set; }
    }
}
