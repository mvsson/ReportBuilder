using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            AvailableSensors = await JsonSerializer.DeserializeAsync<IList<Sensor>>(await response);

            response = Client.GetStreamAsync(Api_Path + "entities/monitoringObjects");
            AvailableMonitoringObjects = await JsonSerializer.DeserializeAsync<IList<MonitoringObject>>(await response);

            switch (reportType)
            {
                case ReportCode.MoveAndStop:
                    return PartialView("AddCode1Report",
                        new NewReportViewModel()
                        {
                            ReportModel = new ReportDto() {Code = ReportCode.MoveAndStop},
                            AvailableMonitoringObjects = AvailableMonitoringObjects?.Select(item => new SelectedItem<string>(item.Name)).ToList(),
                            AvailableSensors = AvailableSensors?.Select(item => new SelectedItem<string>(item.Name)).ToList()
                        });
                case ReportCode.MessagesFromObject:
                    return PartialView("AddCode2Report",
                        new NewReportViewModel()
                        {
                            ReportModel = new ReportDto() {Code = ReportCode.MessagesFromObject},
                            AvailableMonitoringObjects = AvailableMonitoringObjects?.Select(item => new SelectedItem<string>(item.Name)).ToList(),
                            AvailableSensors = AvailableSensors?.Select(item => new SelectedItem<string>(item.Name)).ToList()
                        });
                default:
                    return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddReport([FromForm] NewReportViewModel model)
        {
            #region Validation
            if (!model.AvailableMonitoringObjects.Any(obj => obj.IsSelected))
            {
                ModelState.AddModelError("AvailableMonitoringObjects", "Выберите хотя бы один объект для мониторинга");
            }
            if (!model.AvailableSensors.Any(obj => obj.IsSelected) &&
                model.ReportModel.Code == ReportCode.MessagesFromObject)
            {
                ModelState.AddModelError("AvailableSensors", "Выберите хотя бы один датчик для мониторинга");
            }
            if (!ModelState.IsValid)
            {
                switch (model.ReportModel.Code)
                {
                    case ReportCode.MoveAndStop:
                        return PartialView("AddCode1Report", model);
                    case ReportCode.MessagesFromObject:
                        return PartialView("AddCode2Report", model);
                }
            }
            #endregion
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("token", Token);

            var requestModel = model.ReportModel;
            var selectedObjects = model.AvailableMonitoringObjects.Where(obj => obj.IsSelected)
                                                                                 .Select(obj => obj.ItemName);
            requestModel.MonitoringObjects = AvailableMonitoringObjects.Where(obj => selectedObjects.Contains(obj.Name));
            
            if (requestModel.Code == ReportCode.MessagesFromObject)
            {
                var selectedSensors = model.AvailableSensors.Where(sensor => sensor.IsSelected)
                                                                           .Select(sensor => sensor.ItemName);
                requestModel.MonitoringSensors = AvailableSensors.Where(sensor => selectedSensors.Contains(sensor.Name));
            }

            var response = await Client.PostAsJsonAsync(Api_Path, requestModel);
            if (response.IsSuccessStatusCode)
                return PartialView("Successful");
            else
                return BadRequest(response?.RequestMessage);
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
