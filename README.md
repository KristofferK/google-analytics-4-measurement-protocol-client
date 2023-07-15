# google-analytics-measurement-protocol-client
Async wrapper around Google Analytics Measurement Protocol for Google Analytics 4 implemented in .NET.

## Example usage
```cs
using GoogleAnalyticsMeasurementProtocol;

const string API_SECRET = "A11aAa1AAAAAA-aaaAAaAa";
const string MEASUREMENT_ID = "G-P1a111AA1A";

const string CLIENT_ID = "1111111111.2222222222";
const string USER_ID = "40";

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
