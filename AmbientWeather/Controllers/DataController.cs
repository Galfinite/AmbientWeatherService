using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AmbientWeather.Controllers
{
    [Route("data")]
    [ApiController]


    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult RecordAllData()
        {
            try
            {
                Singleton myDb = Singleton.Instance;

                var values = new List<KeyValuePair<string, string>>();

                foreach (string key in Request.Query.Keys)
                {
                    values.Add(new KeyValuePair<string, string>(key, Request.Query[key].ToString()));
                }

                myDb.InsertData(values);

                return Ok("");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}