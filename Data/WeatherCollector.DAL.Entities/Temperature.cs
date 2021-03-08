using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherCollector.DAL.Entities
{
    [Table("Temperature")]
    public class Temperature : FloatMeasurement { }
}