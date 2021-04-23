using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ReportEntities.Enums;

namespace ReportEntities.Reports
{
    public abstract class Report
    {
        protected Report(ReportCode code)
        {
            MonitoringObjects = new List<MonitoringObject>();
            Code = code;
        }

        public Guid Id { get; set; }

        [Required]
        public ReportCode Code { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public IEnumerable<MonitoringObject> MonitoringObjects { get; set; }

        [Required]
        public DateTime FirstReportDate { get; set; }

        [Required]
        public Periodicity Periodicity { get; set; }

        public void ExecuteReport(IReportHandler handler)
        {
            handler.Execute(this);
        }
    }
}
