using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportEntities;
using ReportEntities.DTO;

namespace ReportBuilderClient.Models
{
    public class NewReportViewModel
    {
        public NewReportViewModel()
        {
            AvailableSensors = new List<SelectedItem<string>>();
            AvailableMonitoringObjects = new List<SelectedItem<string>>();
        }
        public ReportDto ReportModel { get; set; }
        public IList<SelectedItem<string>> AvailableSensors { get; set; }
        public IList<SelectedItem<string>> AvailableMonitoringObjects { get; set; }
    }
}
