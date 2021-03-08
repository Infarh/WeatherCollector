using Microsoft.EntityFrameworkCore;
using WeatherCollector.DAL.Entities;

namespace WeatherCollector.DAL.Context
{
    public class WeatherDB : DbContext
    {
        public DbSet<Place> Places { get; set; }

        public DbSet<Temperature> Temperatures { get; set; }

        public DbSet<Pressure> Pressures { get; set; }

        public WeatherDB(DbContextOptions<WeatherDB> options) : base(options) { }
    }
}
