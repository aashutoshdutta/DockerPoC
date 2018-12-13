﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        //private IActionResult getApiResponse()
        //{
      //  // string URL = "http://localhost:54271/api/values";
        //    string result = "";
        //  //  var convRes="";
        //    using (var httpClient = new HttpClient())
        //    { 
        //        HttpResponseMessage apiresponse = httpClient.GetAsync(URL).Result;
        //        result = apiresponse.Content.ReadAsStringAsync().Result;
        //        var jsonObject = JsonConvert.DeserializeObject<List<Study>>(result);
        //        //convRes = formattedRes.ToString();
        //        return View(jsonObject);
        //    }

        //    //For Docker Demo
        //}
        public IActionResult About()
        {
            ViewData["Message"] = "Please find the API response below";

            string URL = "http://172.26.54.33/api/values";
           //string URL = "http://localhost:54271/api/values";
            string result = "";

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage apiresponse = httpClient.GetAsync(URL).Result;
                result = apiresponse.Content.ReadAsStringAsync().Result;
                var jsonObject = JsonConvert.DeserializeObject<List<Study>>(result);
                //convRes = formattedRes.ToString();
                return View(jsonObject);
            }

          //  string newRes = getApiResponse();
          // changed
            
            //JObject formattedRes = JObject.Parse(newRes);
           
            //string study1 = formattedRes["projectid"].ToString();
            //string study2 = formattedRes["projectname"].ToString();
            //string study3 = formattedRes["updated_after"].ToString();
           
            //ViewBag.Study1 = study1;
            //ViewBag.Study2 = study2;
            //ViewBag.Study3 = study3;
           // ViewBag.APIRes = newRes;

        //    return View();
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
