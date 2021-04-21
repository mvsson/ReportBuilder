using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportBuilderServer.Domain;
using ReportEntities;

namespace ReportBuilderServer.Controllers
{
    [Route("api/reports/entities/")]
    [ApiController]
    public class AvailableObjController : Controller
    {
        private readonly ReportsRepository _reports;
        private const string TokenEmulator = "1234";
        public AvailableObjController(ReportsRepository reports)
        {
            _reports = reports;
        }

        [HttpGet("monitoringObjects")]
        public ActionResult<IEnumerable<MonitoringObject>> GetMonitoringObjects()
        {
            string token = HttpContext.Request.Headers["token"];
            if (token != TokenEmulator)
            {
                return Unauthorized();
            }
            return new ActionResult<IEnumerable<MonitoringObject>>(_reports.GetMonitoringObjects());
        }

        [HttpGet("sensors")]
        public ActionResult<IEnumerable<Sensor>> GetSensors()
        {
            string token = HttpContext.Request.Headers["token"];
            if (token != TokenEmulator)
            {
                return Unauthorized();
            }
            return new ActionResult<IEnumerable<Sensor>>(_reports.GetSensors());
        }
    }
}
