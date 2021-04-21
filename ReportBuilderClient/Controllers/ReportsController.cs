using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportBuilderClient.Models;
using ReportEntities;
using ReportEntities.DTO;
using ReportEntities.Enums;
using ReportEntities.Reports;

namespace ReportBuilderClient.Controllers
{
    public class ReportsController : Controller
    {
        #region props

        private const string Api_Path = "https://localhost:44361/api/reports/";
        private const string Token = "1234";
        private static readonly HttpClient Client = new();
        private static IEnumerable<Sensor> AvailableSensors { get; set; }
        private static IEnumerable<MonitoringObject> AvailableMonitoringObjects { get; set; }
        #endregion

        public async Task<IActionResult> Index()
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("token", Token);

            ViewBag.Title = "Все отчёты";

            var response = Client.GetStreamAsync(Api_Path);
            var reports = await JsonSerializer.DeserializeAsync<IEnumerable<ReportDto>>(await response);
            return View(reports);
        }
        public async Task<IActionResult> ShowReport(string id)
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("token", Token);
            var response = Client.GetStreamAsync(Api_Path + id);
            var model = await JsonSerializer.DeserializeAsync<ReportDto>(await response);
            return View(model);
        }

        public IActionResult SelectType()
        {
            return View();
        }
        public async Task<IActionResult> AddReport(ReportCode reportType)
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("token", Token);

            var response = Client.GetStreamAsync(Api_Path + "entities/sensors");
            AvailableSensors = await JsonSerializer.DeserializeAsync<IEnumerable<Sensor>>(await response);

            response = Client.GetStreamAsync(Api_Path + "entities/monitoringObjects");
            AvailableMonitoringObjects = await JsonSerializer.DeserializeAsync<IEnumerable<MonitoringObject>>(await response);

            switch (reportType)
            {
                case ReportCode.MoveAndStop:
                    return PartialView("AddCode1Report",
                        new NewReportViewModel()
                        {
                            ReportModel = new ReportDto() {Code = ReportCode.MoveAndStop},
                            AvailableMonitoringObjects = AvailableMonitoringObjects,
                            AvailableSensors = AvailableSensors
                        });
                case ReportCode.MessagesFromObject:
                    return PartialView("AddCode2Report",
                        new NewReportViewModel()
                        {
                            ReportModel = new ReportDto() {Code = ReportCode.MessagesFromObject},
                            AvailableMonitoringObjects = AvailableMonitoringObjects,
                            AvailableSensors = AvailableSensors
                        });
                default:
                    return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddReport(NewReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("token", Token);

            var response = await Client.PostAsJsonAsync(Api_Path, model.ReportModel);

            return response.IsSuccessStatusCode ? RedirectToAction(nameof(Index)) : BadRequest(response?.RequestMessage);
        }

        public async Task<IActionResult> DeleteReport(string id)
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("token", Token);
            await Client.DeleteAsync(Api_Path + $"?id={id}");

            return RedirectToAction(nameof(Index));
        }
    }
}
