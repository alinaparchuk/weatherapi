using System;
using System.Net;
using Newtonsoft.Json;
using SQLitePCL;
using static Api.Models.Weather;

namespace Api.Models
{
    public class WeatherCity
    {
        public object GetTodayWeather(string city)
        {
            AppSettings.City = city;
            var urlCurrentWeather = AppSettings.Url;
            var stringData = new WebClient().DownloadString(urlCurrentWeather);
            var currentWeather = JsonConvert.DeserializeObject<CurrentBunch>(stringData);
            var time = UnixTimeStampToDateTime(currentWeather.dt);
            var clouds = currentWeather.clouds;
            var wind = currentWeather.wind;
            var main = currentWeather.main;

            string v = string.Format("Time: {0}, Clouds: {1} %, Wind Speed: {2} meter/sec, Humidity: {3} %, Temperature: {4} °C", time, currentWeather.clouds.all, currentWeather.wind.Speed, currentWeather.main.Humidity, currentWeather.main.Temp);
            _ = new object[] { time, clouds, wind, main };
            return v;
            
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }      

        
    }
}
