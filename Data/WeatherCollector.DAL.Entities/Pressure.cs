using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherCollector.DAL.Entities
{
    [Table("Pressure")]
    public class Pressure : FloatMeasurement { }
}