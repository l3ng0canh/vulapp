using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace testVul.Controllers
{
    public class Sample3Controller : Controller
    {
        private readonly ILogger<Sample3Controller> _logger;
        private readonly IWebHostEnvironment _environment;

        public Sample3Controller(
            ILogger<Sample3Controller> logger,
            IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OSCommandIjnection(string? id)
        {
            ViewData["Client"] = id;
            var process = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo();
            var contentPath = _environment.ContentRootPath;
            // string[] specialChars = new string[]{"&", "&&", "|", "||"};
            // foreach (string specialChar in specialChars)
            // {
            //     if (id.Contains(specialChar))
            //     {
            //         return StatusCode(500);
            //     }
            // }
            var filePath = System.IO.Path.Combine(contentPath, id);
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/C echo teste > {filePath}";
            process.StartInfo = startInfo;
            process.Start();

            if (process == null)
            {
                return StatusCode(500);
            }
            else
            {
                process.WaitForExit();
                return View();
            }
        }
    }
}