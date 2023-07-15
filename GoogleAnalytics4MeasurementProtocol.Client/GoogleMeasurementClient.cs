using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoogleAnalytics4MeasurementProtocol.Client
{
    public class GoogleMeasurementClient : IGoogleMeasurementClient, IDisposable
    {
        private const string MEASUREMENT_PROTOCOL_BASE_URL = "https://www.google-analytics.com/mp/collect";
        private const string MEASUREMENT_PROTOCOL_VALIDATION_BASE_URL = "https://www.google-analytics.com/debug/mp/collect";

        private bool _isDisposed;
        private readonly HttpClient _httpClient;

        public GoogleMeasurementClient(string apiSecret, string measurementId, bool useValidationServer = false)
        {
            string baseUrl = useValidationServer ? MEASUREMENT_PROTOCOL_VALIDATION_BASE_URL : MEASUREMENT_PROTOCOL_BASE_URL;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"{baseUrl}?api_secret={apiSecret}&measurement_id={measurementId}")
            };
        }

        public Task PublishEventAsync(string clientId, string userId, object[] events)
        {
            string body = JsonSerializer.Serialize(new
            {
                client_id = clientId,
                user_id = userId,
                events
            });
            return _httpClient.PostAsync(string.Empty, new StringContent(body, Encoding.UTF8, "application/json"));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed || !disposing)
                return;

            _httpClient?.Dispose();

            _isDisposed = true;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}