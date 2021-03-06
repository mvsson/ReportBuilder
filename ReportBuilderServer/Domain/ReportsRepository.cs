using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReportBuilderServer.Services.ReporterService;
using ReportEntities;
using ReportEntities.Enums;
using ReportEntities.Reports;

namespace ReportBuilderServer.Domain
{
    public class ReportsRepository
    {
        private readonly List<Report> _reports;
        private readonly List<MonitoringObject> _monitoringObjects;
        private readonly List<Sensor> _sensors;
        public ReportsRepository()
        {
            _reports = new List<Report>();
            _monitoringObjects = new List<MonitoringObject>()
            {
                new MonitoringObject(){Code = 1, Name = "o001oa178"},
                new MonitoringObject(){Code = 2, Name = "o002oo47"},
                new MonitoringObject(){Code = 3, Name = "a100aa777"}
            };
            _sensors = new List<Sensor>()
            {
                new FuelSensor() {Name = "FuelSensor"}, 
                new IgnitionSensor(){Name = "IgnitionSensor"},
                new SnockSensor(){Name = "SnockSensor"}
            };

            AddReport(new MessagesFromObjectReport()
            {
                Id = new Guid("95344e38-23d5-462b-a3eb-44d0afc13a2a"),
                JobTitle = "Ежедневный отчёт о001оа178",
                MonitoringObjects = new List<MonitoringObject>(){ _monitoringObjects[0] },
                FirstReportDate = DateTime.Today,
                Periodicity = Periodicity.OnceADay,
                SensorsPrefer = new List<Sensor>() { _sensors[1], _sensors[0] },
            });

            AddReport(new MoveAndStopReport()
            {
                Id = new Guid("95344e38-23d5-462b-a3eb-44d0afc13a2a"),
                JobTitle = "Ежемесячный маршрутный о002оо47",
                MonitoringObjects = new List<MonitoringObject>() { _monitoringObjects[1] },
                FirstReportDate = DateTime.Today.AddDays(20),
                Periodicity = Periodicity.OnceAMonth,
                Range = ReportRange.Month
            });
        }

        public IEnumerable<Report> GetReports()
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

        public ICollection<Sensor> GetSensors()
        {
            return _sensors;
        }
    }
}
