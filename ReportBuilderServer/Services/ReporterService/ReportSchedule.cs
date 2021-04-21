using System;
using System.Linq;
using System.Timers;
using ReportBuilderServer.Domain;
using ReportBuilderServer.Services.ReporterService.ReportsHandlers;
using ReportEntities;
using ReportEntities.Enums;
using ReportEntities.Reports;

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
                                                                              TimeSpan.FromDays((int) r.Periodicity).TotalDays == 0)
                                                                        .OrderBy(r => r.Code);
            IReportHandler handler = null;
            foreach (var report in actualReports)
            {
                switch (report.Code)
                {
                    case ReportCode.MoveAndStop:
                        if (handler == null || handler.GetType() != typeof(MoveAndStopReportHandler))
                        {
                            handler = new MoveAndStopReportHandler();
                        }
                        break;
                    case ReportCode.MessagesFromObject:
                        if (handler == null || handler.GetType() != typeof(MessagesFOReportsHandler))
                        {
                            handler = new MessagesFOReportsHandler();
                        }
                        break;
                    default:
                        continue;
                }
                report.ExecuteReport(handler);
            }
        }
    }
}
