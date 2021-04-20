using System;
using System.Linq;
using System.Timers;
using ReportBuilderServer.Domain;
using ReportEntities;

namespace ReportBuilderServer.Services.ReporterService
{
    public class ReportSchedule
    {
        private readonly Timer _timer;
        private readonly ReportsRepository _reports;
        private const double TimerInterval = 86400000;
        public ReportSchedule(ReportsRepository reports)
        {
            _reports = reports;
            _timer = new Timer();
            _timer.Interval = TimerInterval;
            _timer.Elapsed += ExecuteReports;
        }
        public void Start()
        {
            _timer.Start();
        }

        public void ExecuteReports(object sender, ElapsedEventArgs args)
        {
            var actualReports = _reports.GetReports().Where(r => r.FirstReportDate >= DateTime.Today &&
                                                                 (DateTime.Today - r.FirstReportDate).TotalDays %
                                                                 TimeSpan.FromDays((int) r.Periodicity).TotalDays == 0);
            foreach (var report in actualReports)
            {
                var rep = report as IExecute;
                rep?.Execute();
            }
        }
    }
}
