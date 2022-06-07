using System;
using System.IO;
using System.Net.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace testVul.Controllers
{
    public class Sample2Controller : Controller
    {
        private readonly ILogger<Sample2Controller> _logger;
        private readonly IWebHostEnvironment _environment;
        public Sample2Controller(
            ILogger<Sample2Controller> logger,
            IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult  Index(string filename)   
        {
            var contentPath = _environment.ContentRootPath;
            filename = Path.Combine(contentPath, filename);
            bool resultx = System.IO.File.Exists(filename);
            var fileExits = resultx.ToString() + ", file: " + filename;
            Console.WriteLine(fileExits);
            var content = System.IO.File.ReadAllText(filename);
            ViewBag.Message = content;
            return View();
        }
    }
}