using System;
using System.Collections.Generic;
using System.Linq;
using ReportEntities;
using ReportEntities.Enums;
using ReportEntities.Reports;

namespace ReportBuilderServer.Domain
{
    public class ReportsRepository
    {
        private readonly List<Report> _reports;
        private readonly List<MonitoringObject> _monitoringObjects;
        public ReportsRepository()
        {
            _reports = new List<Report>();
            _monitoringObjects = new List<MonitoringObject>()
            {
                new MonitoringObject(){Code = 1, Name = "o001oa178"},
                new MonitoringObject(){Code = 2, Name = "o002oo47"},
                new MonitoringObject(){Code = 3, Name = "a100aa777"}
            };

            AddReport(new MessagesFromObjectReport()
            {
                Id = new Guid("95344e38-23d5-462b-a3eb-44d0afc13a2a"),
                JobTitle = "Младший менеджер",
                MonitoringObjects = new List<MonitoringObject>(){ _monitoringObjects[0] },
                FirstReportDate = DateTime.Today,//.AddDays(3),
                Periodicity = Periodicity.OnceADay,
                SensorsPrefer = new List<Sensor>() { new FuelSensor(), new IgnitionSensor()},
            });

            AddReport(new MoveAndStopReport()
            {
                Id = new Guid("95344e38-23d5-462b-a3eb-44d0afc13a2a"),
                JobTitle = "Старший менеджер",
                MonitoringObjects = new List<MonitoringObject>() { _monitoringObjects[0] },
                FirstReportDate = DateTime.Today.AddDays(20),
                Periodicity = Periodicity.OnceAWeek,
                Range = ReportRange.Day
            });

            _reports.ForEach(r =>
            {
                if (r is IExecute report) 
                    report.ExecuteHandler += Console.Beep;
            });
        }

        public ICollection<Report> GetReports()
        {
            return _reports;
        }

        public Report GetReportById(string id)
        {
            return _reports.FirstOrDefault(r => r.Id == new Guid(id));
        }

        public void AddReport(Report report)
        {
            _reports.Add(report);
        }

        public void DeleteReport(string id)
        {
            _reports.Remove(
                _reports.FirstOrDefault(r => r.Id == new Guid(id)));
        }

        public ICollection<MonitoringObject> GetMonitoringObjects()
        {
            return _monitoringObjects;
        }
    }
}
