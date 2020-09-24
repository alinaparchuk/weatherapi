using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        // GET api/weather/GetWeather/city
        [HttpGet("GetWeather/{city}")]
        public JsonResult GetWeather(string city)
        {
            var result = new WeatherCity().GetTodayWeather(city);
            return new JsonResult(result, new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            });
        }

        // GET api/weather/GetForecast/city
        [HttpGet("GetForecast/{city}")]
        public JsonResult GetForecast(string city)
        {
            var result = new ForecastCity().GetWeatherFiveDays(city);
            return new JsonResult(result, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.IsoDateFormat });
        }

       
    }
}
