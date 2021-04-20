using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ReportBuilderClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string name = null)
        {
            return View("Index");
        }
    }
}
