namespace Geolocation.Blazor.Geocoding.Geoapify;
internal class GeoapifyGeocoder : IGeocoder
{
    // https://apidocs.geoapify.com/docs/geocoding/reverse-geocoding/#about

    readonly HttpClient Client;
    readonly string ApiKey;
    public GeoapifyGeocoder(HttpClient client, string apiKey)
    {
        Client = client;
        ApiKey = apiKey;
    }

    public async Task<GeocodingAddress> GetGeocodingAddressAsync(
        double latitude, double longitude)
    {
        const string BaseUri = "https://api.geoapify.com/v1/geocode/reverse";
        GeocodingAddress Address = null;

        var Result = await Client.GetFromJsonAsync<JsonResponse>(
            $"{BaseUri}?{BuildParameters(latitude, longitude, ApiKey)}");

        if (Result.Results.Any())
        {
            Address = new GeocodingAddress
            {
                Latitude = Result.Results[0].Lat,
                Longitude = Result.Results[0].Lon,
                DisplayAddress = Result.Results[0].Formatted,
                Country = Result.Results[0].Country,
                State = Result.Results[0].State,
                City = Result.Results[0].City,
                PostalCode = Result.Results[0].PostCode,
                HouseNumber = Result.Results[0].HouseNumber,
                AddressLine1 = Result.Results[0].Address_Line1,
                AddressLine2 = Result.Results[0].Address_Line2
            };
        }
        return Address;
    }

    string BuildParameters(double latitude, double longitude, string apiKey)
    {
        Dictionary<string, string> Parameters = new Dictionary<string, string>()
        {
            { "lat", latitude.ToString("###.#########")},
            { "lon", longitude.ToString("###.#########")},
            { "format", "json" },
            { "lang", "es" },
            { "type", "building" },
            { "limit", "1"},
            { "apiKey", apiKey }
        };

        return string.Join('&', Parameters
            .Select(p => $"{p.Key}={p.Value}").ToArray());
    }
}
