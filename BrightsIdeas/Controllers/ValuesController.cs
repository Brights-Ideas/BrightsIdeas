using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using BrightsIdeas.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BrightsIdeas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly HttpClient _client;

        public ValuesController(HttpClient client)
        {
            _client = client;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var endpoint = "get_properties.php";
            var xml = await _client.GetStringAsync($"{endpoint}?clientID=ce5385e4d6f49ce36a5e1c0b3fa981d4&passphrase=GHvYG9f");
            
            // To convert an XML node contained in string xml into a JSON string   
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);

            //var output = JsonConvert.SerializeXmlNode(doc.DocumentElement);
            //var json = JsonConvert.DeserializeObject<PropertiesRootobject>(output);
            //string xml = await response.Content.ReadAsStringAsync();
            //var json = JsonConvert.DeserializeObject<Rootobject>(res);
            XElement element = XElement.Parse(xml);

            var properties = from x in element.Descendants("property")
                select new Properties
                {
                    PropertyId = x.Element("propertyID")?.Value,
                    Department = x.Element("department")?.Value,
                    DisplayAddress = x.Element("displayAddress")?.Value,
                    MainSummary = x.Element("mainSummary")?.Value,
                    Images = x.Element("images")?.Descendants("image")
                        .Select(i =>
                                i.Value
                        ).ToList()
                };

            var json = JsonConvert.SerializeObject(properties);
            var fred = JsonConvert.DeserializeObject<IEnumerable<Properties>>(json);
            //var json = JsonConvert.DeserializeObject<IEnumerable<Properties>>(properties.ToString());
            //return View(properties.Where(r => r.department == "Sales"));
            return Ok(properties); //..properties.property.Where(x => x.department == "Sales"));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var data = GetProperties().Result.FirstOrDefault(p => p.PropertyId == id);

            return Ok(data);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public async Task<IEnumerable<Properties>> GetProperties()
        {
            var endpoint = "get_properties.php";
            var xml = await _client.GetStringAsync($"{endpoint}?clientID=ce5385e4d6f49ce36a5e1c0b3fa981d4&passphrase=GHvYG9f");

            XElement element = XElement.Parse(xml);

            var properties = from x in element.Descendants("property")
                select new Properties
                {
                    PropertyId = x.Element("propertyID")?.Value,
                    Price = x.Element("price")?.Value,
                    Department = x.Element("department")?.Value,
                    DisplayAddress = x.Element("displayAddress")?.Value,
                    MainSummary = x.Element("mainSummary")?.Value,
                    Images = x.Element("images")?.Descendants("image")
                        .Select(i =>
                            i.Value
                        ).ToList()
                };

            var json = JsonConvert.SerializeObject(properties);
            //var fred = JsonConvert.DeserializeObject<IEnumerable<Properties>>(json);

            //var output = JsonConvert.SerializeXmlNode(doc.DocumentElement);
            return JsonConvert.DeserializeObject<IEnumerable<Properties>>(json); //JsonConvert.DeserializeObject<Properties>(output);
        }

    }
}
