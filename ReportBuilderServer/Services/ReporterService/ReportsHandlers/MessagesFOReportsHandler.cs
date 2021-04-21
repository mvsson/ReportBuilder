using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportEntities;
using ReportEntities.Reports;

namespace ReportBuilderServer.Services.ReporterService.ReportsHandlers
{
    public class MessagesFOReportsHandler : IReportHandler
    {
        public void Execute(Report report)
        {
            var executableReport = report as MessagesFromObjectReport;
            /*
             * Do some work with report
             */
            Console.Beep(); // for test
        }
    }
}
