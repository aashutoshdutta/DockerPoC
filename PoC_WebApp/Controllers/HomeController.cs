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
         //  string URL = "http://172.26.60.92/api/values";
           string URL = "http://localhost:54271/api/values";
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
            
            //JObject formattedRes = JObject.Parse(newRes);
           
            //string study1 = formattedRes["projectid"].ToString();
            //string study2 = formattedRes["projectname"].ToString();
            //string study3 = formattedRes["updated_after"].ToString();
           
            //ViewBag.Study1 = study1;
            //ViewBag.Study2 = study2;
            //ViewBag.Study3 = study3;
            ViewBag.APIRes = newRes;

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
