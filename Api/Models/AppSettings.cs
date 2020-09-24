using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class AppSettings
    {
        public static string City { get; set; } 
        public static string Key { get; } = "fbbdf11deb4695675818209cd1d8d5e2";
        public static string Url { get; set; } = $"http://api.openweathermap.org/data/2.5/weather?q={City}&APPID={Key}&units=metric";


    }
}
