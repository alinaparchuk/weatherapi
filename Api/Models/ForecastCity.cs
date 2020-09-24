using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using static Api.Models.Forecast;

namespace Api.Models
{
    public class ForecastCity
    {
        public string City { get; set; }
        readonly string appId = "fbbdf11deb4695675818209cd1d8d5e2";

        public List<object> GetWeatherFiveDays(string city)
        {
            City = city;
            var urlForecast = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}&units=metric", City, appId);
            var stringData = new WebClient().DownloadString(urlForecast);
            var fiveWeather = JsonConvert.DeserializeObject<Example>(stringData);

            List<object> w = new List<object>();

            for (int i = 0; i < fiveWeather.list.Count; i++)
            {
                string m = string.Format("Time: {0}," +
                " Clouds: {1} %," +
                " Wind Speed: {2} meter/sec," +
                " Humidity: {3} %," +
                " Temperature: {4} °C",
                fiveWeather.list[i].dt_txt,
                fiveWeather.list[i].clouds.all,
                fiveWeather.list[i].wind.speed,
                fiveWeather.list[i].main.humidity,
                fiveWeather.list[i].main.temp);
                w.Add(m);
            };

            return w;
        }
    }
}

