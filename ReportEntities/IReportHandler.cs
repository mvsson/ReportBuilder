using System;
using ReportEntities.Reports;

namespace ReportEntities
{
    public interface IReportHandler
    {
        public void Execute(Report report);
    }
}
