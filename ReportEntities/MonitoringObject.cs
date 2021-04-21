using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReportEntities
{
    public class MonitoringObject
    {
        [JsonPropertyName("code")]
        [Display(Name = "Код объекта")]
        public int Code { get; set; }
        [JsonPropertyName("name")]
        [Display(Name = "Имя объекта")]
        public string Name { get; set; }
    }
}
