using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportEntities;
using ReportEntities.DTO;

namespace ReportBuilderClient.Models
{
    public class NewReportViewModel
    {
        public ReportDto ReportModel { get; set; }
        public IEnumerable<Sensor> AvailableSensors { get; set; }
        public IEnumerable<MonitoringObject> AvailableMonitoringObjects { get; set; }
    }
}
