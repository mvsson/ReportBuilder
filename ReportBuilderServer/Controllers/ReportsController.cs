using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReportBuilderServer.Domain;
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
        public ActionResult<string> GetAllReports()
        {
            string token = HttpContext.Request.Headers["token"];

            if (token != TokenEmulator)
            {
                return Unauthorized();
            }

            var reports = new List<object>();
            foreach (var report in _reports.GetReports())
            {
                switch (report.Code)
                {
                    case ReportCode.MoveAndStop:
                        reports.Add(report as MoveAndStopReport);
                        break;
                    case ReportCode.MessagesFromObject:
                        reports.Add(report as MessagesFromObjectReport);
                        break;
                    default:
                        continue;
                }
            }
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            var response = JsonConvert.SerializeObject(reports, settings);

            return response;
        }

        [HttpGet("{id}")]
        public ActionResult<Report> GetReport(string id)
        {
            string token = HttpContext.Request.Headers["token"];

            if (token != TokenEmulator)
            {
                return Unauthorized();
            }
            var report = _reports.GetReportById(id);
            return report == default ? NotFound() : report;
        }

        [HttpPost]
        public ActionResult CreateReport(Report report)
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
            _reports.AddReport(report);
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
