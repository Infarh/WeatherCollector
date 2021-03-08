using Microsoft.EntityFrameworkCore;
using WeatherCollector.DAL.Entities;
using WeatherCollector.DAL.Entities.Base;

namespace WeatherCollector.DAL.Context
{
    public class WeatherDB : DbContext
    {
        public DbSet<Place> Places { get; set; }

        public DbSet<Temperature> Temperatures { get; set; }

        public DbSet<Pressure> Pressures { get; set; }

        public WeatherDB(DbContextOptions<WeatherDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.ApplyConfigurationsFromAssembly(typeof(Entity).Assembly);

        }
    }
}
