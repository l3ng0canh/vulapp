using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace testVul.Controllers
{
    public class Sample5 : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ReadContentOfUrl(string url1)
        {
            // string url1 = Request.Query["url1"];
            Console.WriteLine(url1);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url1); // Noncompliant
            
            HttpWebResponse response  = (HttpWebResponse)request.GetResponse();
            Stream dataStream         = response.GetResponseStream();
            StreamReader reader       = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return Content(responseFromServer);
        }
    }
}