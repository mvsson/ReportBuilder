using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportEntities.DTO;
using ReportEntities.Reports;

namespace ReportBuilderClient.Controllers
{
    public class ReportsController : Controller
    {
        private const string Api_Path = "https://localhost:44361/api/reports";
        private const string Token = "1234";
        private static readonly HttpClient Client = new();
        public async Task<IActionResult> Index()
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("token", Token);

            ViewBag.Title = "Все отчёты";

            var response = await Client.GetStringAsync(Api_Path);
            var reports = JsonSerializer.Deserialize<IEnumerable<ReportDto>>(response);
            return View(reports);
        }
        public async Task<IActionResult> ShowReport(string id)
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("token", Token);
            return null;
        }

        public async Task<IActionResult> AddReport()
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("token", Token);

            return null;
        }
        [HttpPost]
        public async Task<IActionResult> AddReport(Report report)
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("token", Token);
            return null;
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
