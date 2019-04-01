using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using BrightsIdeas.Web.Models;
using Newtonsoft.Json;

namespace BrightsIdeas.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            //client.SetBearerToken(GetAccessToken());

            var response = await client.GetAsync("http://localhost:52642/api/values");
            if (response.IsSuccessStatusCode)
            {
                var properties = await response.Content.ReadAsAsync<IEnumerable<Properties>>();

                return View(properties.Where(r =>r.department == "Sales"));
            }

            return View();
        }

        public async Task<IActionResult> Details(string propertyId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"http://localhost:52642/api/values/{propertyId}");
            if (response.IsSuccessStatusCode)
            {
                var properties = await response.Content.ReadAsAsync<Properties>();

                return View(properties);
            }

            return View("Error");
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
