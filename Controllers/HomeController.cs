using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RagoWeather.Models;
using RagoWeather.Services;

namespace RagoWeather.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public RestService _rs { get; set; }
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _rs = new RestService();
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index Request");
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

        public IActionResult WeatherData(string id)
        {
            string prova = "https://api.openweathermap.org/data/2.5/weather?q=+"+id+"&units=metric&appid=54880c125693096ed43dc2fd0f5ceba4";
            WeatherData results = _rs.GetWeatherData(prova).Result;

            return View(results);
        }
    }
}
