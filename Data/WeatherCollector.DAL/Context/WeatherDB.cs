using Microsoft.EntityFrameworkCore;

namespace WeatherCollector.DAL.Context
{
    public class WeatherDB : DbContext
    {


        public WeatherDB(DbContextOptions<WeatherDB> options) : base(options) { }
    }
}
