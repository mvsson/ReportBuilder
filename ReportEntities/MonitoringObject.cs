using System.ComponentModel.DataAnnotations;

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
