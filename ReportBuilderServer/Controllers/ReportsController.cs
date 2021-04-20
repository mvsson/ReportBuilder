using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReportBuilderServer.Domain;
using ReportEntities.Reports;

namespace ReportBuilderServer.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : Controller
    {
        private readonly ReportsRepository _reports;
        private const string Token = "1234";
        public ReportsController(ReportsRepository reports)
        {
            _reports = reports;
        }

        [HttpGet]
        public IEnumerable<Report> GetAllReports(string token = "")
        {
            if (token != Token)
            {
                return null;
            }
            return _reports.GetReports();
        }

        [HttpGet("{id}")]
        public ActionResult<Report> GetReport(string id, string token = "")
        {
            if (token != Token)
            {
                return BadRequest();
            }
            return _reports.GetReportById(id);
        }

        [HttpPost]
        public IActionResult PostReport(Report report, string token = "")
        {
            if (report == null || token != Token)
            {
                return BadRequest();
            }
            _reports.AddReport(report);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteReport(string id, string token = "")
        {
            if (string.IsNullOrWhiteSpace(id) || token != Token)
            {
                return BadRequest();
            }
            _reports.DeleteReport(id);
            return Ok();
        }
    }
}
