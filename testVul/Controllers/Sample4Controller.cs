using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.Mvc;

namespace testVul.Controllers
{
    public class Sample4Controller : Controller
    {
        // GET
        public IActionResult Index(string base64encodedstring)
        {
            var binaryFormatter = new BinaryFormatter();
            var deserialized = binaryFormatter.Deserialize((new MemoryStream(Convert.FromBase64String(base64encodedstring))));
            return View();
        }
    }
}