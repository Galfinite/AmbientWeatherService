using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using NLog;

namespace AmbientWeather.Controllers
{
    [Route("data")]
    [ApiController]


    public class DataController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        [HttpGet]
        public IActionResult RecordAllData()
        {
            logger.Debug("API hit");
            try
            {
                Singleton myDb = Singleton.Instance;

                var values = new Dictionary<string, string>();

                foreach (string key in Request.Query.Keys)
                {
                    values.Add(key, Request.Query[key].ToString());
                }

                myDb.InsertData(values);

                return Ok("");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                System.Diagnostics.Debug.WriteLine($"Something went wrong: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}