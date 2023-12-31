# google-analytics-measurement-protocol-client
Async wrapper around Google Analytics Measurement Protocol for Google Analytics 4 implemented in .NET Standard, to support both .NET Framework, .NET Core and .NET 5+.

## Example usage
```cs
using GoogleAnalytics4MeasurementProtocol.Client;

const string API_SECRET = "A11aAa1AAAAAA-aaaAAaAa"; // Admin > Data Streams > choose your stream > Measurement Protocol > Create
const string MEASUREMENT_ID = "G-P1a111AA1A"; // Admin > Data Streams > choose your stream > Measurement ID

const string CLIENT_ID = "1111111111.2222222222"; // Must be fetch from client side
const string USER_ID = "40"; // Id of the internal user

object[] events = new[]
{
    new
    {
        name = "sign_up",
        @params = new
        {
            method = "Facebook"
        }
    }
};

GoogleMeasurementClient measurementClient = new(API_SECRET, MEASUREMENT_ID);

await measurementClient.PublishEventAsync(CLIENT_ID, USER_ID, events);
```

You will need to replace API_SECRET, MEASUREMENT_ID, and CLIENT_ID with your values from Google Analytics 4, and replace USER_ID with the user's internal id.

* Api secret can be generated at: Admin > Data Streams > choose your stream > Measurement Protocol > Create
* Measurement Id can be found at: Admin > Data Streams > choose your stream > Measurement ID
* Client id must be fetched on client side using:
```js
gtag('get', 'UA-XXXXXXXX-Y', 'client_id', (clientId) => {
  console.log(clientId);
});
```

For now the events is just a object[], I intend to implement classes representing the supported events. Until then, the supported events can be found at https://developers.google.com/analytics/devguides/collection/protocol/ga4/reference/events
