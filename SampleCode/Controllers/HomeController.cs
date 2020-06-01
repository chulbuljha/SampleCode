using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SampleCode.Models;

namespace SampleCode.Controllers
{
    public class HomeController : Controller
    {
        private API aPI;
      public  HomeController(IOptions<API> options)
        {
            aPI = options.Value;
        }
        public IActionResult Index()
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Only a test!");
            var request = webClient.DownloadString(aPI.url);

            var jsondata = JsonConvert.DeserializeObject(request);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
