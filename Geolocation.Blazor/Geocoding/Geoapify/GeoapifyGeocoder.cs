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
        const string baseUri = "https://api.geoapify.com/v1/geocode/reverse";
        GeocodingAddress address = null;

        JsonResponse result = await Client.GetFromJsonAsync<JsonResponse>(
            $"{baseUri}?{BuildParameters(latitude, longitude, ApiKey)}");

        if (result.Results.Any())
        {
            address = new GeocodingAddress
            {
                Latitude = result.Results[0].Lat,
                Longitude = result.Results[0].Lon,
                DisplayAddress = result.Results[0].Formatted,
                Country = result.Results[0].Country,
                State = result.Results[0].State,
                City = result.Results[0].City,
                PostalCode = result.Results[0].PostCode,
                HouseNumber = result.Results[0].HouseNumber,
                AddressLine1 = result.Results[0].AddressLine1,
                AddressLine2 = result.Results[0].AddressLine2
            };
        }
        return address;
    }

    string BuildParameters(double latitude, double longitude, string apiKey)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>()
        {
            { "lat", latitude.ToString("###.#########")},
            { "lon", longitude.ToString("###.#########")},
            { "format", "json" },
            { "lang", "es" },
            { "type", "building" },
            { "limit", "1"},
            { "apiKey", apiKey }
        };

        return string.Join('&', parameters
            .Select(p => $"{p.Key}={p.Value}").ToArray());
    }
}
