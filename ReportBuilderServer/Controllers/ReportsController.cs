using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReportBuilderServer.Domain;
using ReportEntities.DTO;
using ReportEntities.Enums;
using ReportEntities.Reports;

namespace ReportBuilderServer.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : Controller
    {
        private readonly ReportsRepository _reports;
        private const string TokenEmulator = "1234";
        public ReportsController(ReportsRepository reports)
        {
            _reports = reports;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReportDto>> GetAllReports()
        {
            string token = HttpContext.Request.Headers["token"];
            if (token != TokenEmulator)
            {
                return Unauthorized();
            }

            //var reports = new List<ReportDTO>();
            //foreach (var report in _reports.GetReports())
            //{
            //    ReportDTO reportDTO;
            //    switch (report.Code)
            //    {
            //        case ReportCode.MoveAndStop:
            //            var entity = report as MoveAndStopReport; 
            //            reportDTO = new ReportDTO()
            //            {
            //            };
            //            break;
            //        case ReportCode.MessagesFromObject:
            //            break;
            //        default:
            //            continue;
            //    }
            //    reports.Add(reportDTO);
            //}
            //var settings = new JsonSerializerSettings()
            //{
            //    TypeNameHandling = TypeNameHandling.Auto
            //};
            //var response = JsonConvert.SerializeObject(reports, settings);

            var response = DtoConverter.ConvertReportsToDtos(_reports.GetReports());
            return new ActionResult<IEnumerable<ReportDto>>(response);
        }

        [HttpGet("{id}")]
        public ActionResult<ReportDto> GetReport(string id)
        {
            string token = HttpContext.Request.Headers["token"];

            if (token != TokenEmulator)
            {
                return Unauthorized();
            }
            var report = _reports.GetReportById(id);

            return report == default ? NotFound() : DtoConverter.ConvertReportToDto(report);
        }

        [HttpPost]
        public ActionResult CreateReport(ReportDto report)
        {
            string token = HttpContext.Request.Headers["token"];
            if (token != TokenEmulator)
            {
                return Unauthorized();
            }
            if (report == null)
            {
                return BadRequest();
            }
            _reports.AddReport(DtoConverter.ConvertDtoToReport(report));
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteReport(string id)
        {
            string token = HttpContext.Request.Headers["token"];
            if (token != TokenEmulator)
            {
                return Unauthorized();
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            _reports.DeleteReport(id);
            return NoContent();
        }
    }
}
