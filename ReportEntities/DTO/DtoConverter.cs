using System.Collections.Generic;
using System.Linq;
using ReportEntities.Enums;
using ReportEntities.Reports;

namespace ReportEntities.DTO
{
    public static class DtoConverter
    {
        public static IEnumerable<ReportDto> ConvertReportsToDtos(IEnumerable<Report> reports)
        {
            return reports.Select(ConvertReportToDto);
        }
        public static IEnumerable<Report> ConvertDtosToReports(IEnumerable<ReportDto> dtos)
        {
            return dtos.Select(ConvertDtoToReport);
        }

        public static ReportDto ConvertReportToDto(Report report)
        {
            switch (report.Code)
            {
                case ReportCode.MoveAndStop:
                    var reportCode1 = report as MoveAndStopReport;
                    if (reportCode1 == null)
                    {
                        return null;
                    }
                    return new ReportDto()
                    {
                        Id = reportCode1.Id,
                        Code = reportCode1.Code,
                        JobTitle = reportCode1.JobTitle,
                        MonitoringObjects = reportCode1.MonitoringObjects,
                        FirstReportDate = reportCode1.FirstReportDate,
                        Periodicity = reportCode1.Periodicity,
                        Range = reportCode1.Range
                    };
                case ReportCode.MessagesFromObject:
                    var reportCode2 = report as MessagesFromObjectReport;
                    if (reportCode2 == null)
                    {
                        return null;
                    }
                    return new ReportDto()
                    {
                        Id = reportCode2.Id,
                        Code = reportCode2.Code,
                        JobTitle = reportCode2.JobTitle,
                        MonitoringObjects = reportCode2.MonitoringObjects,
                        FirstReportDate = reportCode2.FirstReportDate,
                        Periodicity = reportCode2.Periodicity,
                        SensorsPrefer = reportCode2.SensorsPrefer
                    };
                default:
                    return null;
            }
        }

        public static Report ConvertDtoToReport(ReportDto dto)
        {
            switch (dto.Code)
            {
                case ReportCode.MoveAndStop:
                    return new MoveAndStopReport()
                    {
                        Id = dto.Id,
                        Code = dto.Code,
                        JobTitle = dto.JobTitle,
                        MonitoringObjects = dto.MonitoringObjects,
                        FirstReportDate = dto.FirstReportDate,
                        Periodicity = dto.Periodicity,
                        Range = dto.Range
                    };
                case ReportCode.MessagesFromObject:
                    return new MessagesFromObjectReport()
                    {
                        Id = dto.Id,
                        Code = dto.Code,
                        JobTitle = dto.JobTitle,
                        MonitoringObjects = dto.MonitoringObjects,
                        FirstReportDate = dto.FirstReportDate,
                        Periodicity = dto.Periodicity,
                        SensorsPrefer = dto.SensorsPrefer
                    };
                default:
                    return null;
            }
        }
    }
}
