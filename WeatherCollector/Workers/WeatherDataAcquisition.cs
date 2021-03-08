using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace WeatherCollector.Workers
{
    public class WeatherDataAcquisition : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken Stoping)
        {

        }
    }
}
