using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherCollector.DAL.Entities
{
    public abstract class FloatMeasurement : Measurement
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
    }
}