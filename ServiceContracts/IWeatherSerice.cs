namespace ServiceContracts
{
    public interface IWeatherSerice
    {
        List<CityWeather> GetWeatherDetails();

        CityWeather? GetWeatherByCityCode(string CityCode);
    }
}
