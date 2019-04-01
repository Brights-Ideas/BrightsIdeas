using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using BrightsIdeas.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace BrightsIdeas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        private readonly HttpClient _client;

        public PropertiesController(HttpClient client, IMemoryCache memoryCache)
        {
            _client = client;
            _cache = memoryCache;
        }

        // GET api/properties
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var properties = await GetProperties();
            if (!properties.Any())
            {
                return NoContent();
            }
            return Ok(properties);
        }

        // GET api/properties/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var data = GetFilteredProperties(id);

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

        public async Task<string> GetProperties()
        {
            if (!_cache.TryGetValue("ListOfProperties", out string properties))
            {
                //Console.WriteLine("Cache miss....loading from database into cache");
                var endpoint = "get_properties.php";
                var xml = await _client.GetStringAsync($"{endpoint}?clientID=ce5385e4d6f49ce36a5e1c0b3fa981d4&passphrase=GHvYG9f");

                // To convert an XML node contained in string xml into a JSON string   
                var element = XElement.Parse(xml);

                var xElementResults = from x in element.Descendants("property")
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

                properties = JsonConvert.SerializeObject(xElementResults);

                _cache.Set("ListOfProperties", properties, TimeSpan.FromHours(12));
            }
            
            return properties;
        }

        public Properties GetFilteredProperties(string propertyId)
        {
            if (!_cache.TryGetValue($"ListOfProperties{propertyId}", out Properties property))
            {
                var properties = JsonConvert.DeserializeObject<IList<Properties>>(GetProperties().Result);

                property = properties.FirstOrDefault(p => p.PropertyId == propertyId);

                _cache.Set($"ListOfProperties{propertyId}", property, TimeSpan.FromHours(12));
            }

            return property;
        }

    }
}
