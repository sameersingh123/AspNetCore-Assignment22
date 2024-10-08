using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;
namespace Assignment22.Controllers
{
    public class WeatherController : Controller
    {

        private readonly IWeatherSerice _weatherSerice;

        public WeatherController(IWeatherSerice weatherSerice)
        {
            _weatherSerice = weatherSerice;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<CityWeather> citiesWeather=_weatherSerice.GetWeatherDetails();
            return View(citiesWeather);
        }

        [Route("/weather/{cityCode?}")]

        public IActionResult City(string? cityCode)
        {
            //if cityCode is not supplied in the route parameter
            if (string.IsNullOrEmpty(cityCode))
            {
                //send null as model object to "Views/Weather/Index" view
                return View();
            }
            CityWeather? matchCity=_weatherSerice.GetWeatherByCityCode(cityCode);
            return View(matchCity);
        }
    }
}
