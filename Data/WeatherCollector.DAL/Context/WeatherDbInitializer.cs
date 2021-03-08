using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WeatherCollector.DAL.Context
{
    public class WeatherDbInitializer
    {
        private readonly WeatherDB _db;

        public WeatherDbInitializer(WeatherDB db) => _db = db;

        public void Initialize() => _db.Database.Migrate();

        public async Task InitializeAsync() => await _db.Database.MigrateAsync();
    }
}
