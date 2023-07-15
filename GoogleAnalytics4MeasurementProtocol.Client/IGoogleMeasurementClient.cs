using System.Threading.Tasks;

namespace GoogleAnalytics4MeasurementProtocol.Client
{
    public interface IGoogleMeasurementClient
    {
        Task PublishEventAsync(string clientId, string userId, object[] events);
    }
}
