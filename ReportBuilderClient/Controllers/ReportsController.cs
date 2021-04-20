using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReportEntities.Reports;

namespace ReportBuilderClient.Controllers
{
    public class ReportsController : Controller
    {
        private const string Api_Path = "https://localhost:44361/api/reports";
        private static string Token = "1234";
        private static readonly HttpClient _client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("token", Token);

            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            ViewBag.Title = "Все отчёты";
            var response = await _client.GetStringAsync(Api_Path);
            var reports = JsonConvert.DeserializeObject<IEnumerable<Report>>(response, settings);
            
            return View(reports);
        }
        public async Task<IActionResult> ShowReport(string id)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("token", Token);
            return null;
        }

        public async Task<IActionResult> AddReport(string id)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("token", Token);

            return null;
        }
        [HttpPost]
        public async Task<IActionResult> AddReport(Report id)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("token", Token);
            return null;
        }

        public async Task<IActionResult> DeleteReport(string id)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("token", Token);
            await _client.DeleteAsync(Api_Path + $"?id={id}");

            return RedirectToAction(nameof(Index));
        }
    }
}
