using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PoC_WebApp.Models;

namespace PoC_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
                                    
            return View();
        }

        private string getApiResponse()
        {
           //  string URL = "https://localhost:44376/api/values";
           string URL = "http://172.26.56.15/api/values";
            string result = "";
          //  var convRes="";
            using (var httpClient = new HttpClient())
            { 
                HttpResponseMessage apiresponse = httpClient.GetAsync(URL).Result;
                result = apiresponse.Content.ReadAsStringAsync().Result;
                //convRes = formattedRes.ToString();
                return result;
            }
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Please find the API response below";

            string newRes = getApiResponse();
            
            JObject formattedRes = JObject.Parse(newRes);
           
            string study1 = formattedRes["Study1001"].ToString();
            string study2 = formattedRes["Study1002"].ToString();
            string study3 = formattedRes["Study1003"].ToString();
            string study4 = formattedRes["Study1004"].ToString();
            string study5 = formattedRes["Study1005"].ToString();
            string study6 = formattedRes["Study1006"].ToString();
            ViewBag.Study1 = study1;
            ViewBag.Study2 = study2;
            ViewBag.Study3 = study3;
            ViewBag.Study4 = study4;
            ViewBag.Study5 = study5;
            ViewBag.Study6 = study6;

            return View();
        }

        

        public IActionResult Contact()
        {
            ViewData["Message"] = "Additional resources section.";



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
