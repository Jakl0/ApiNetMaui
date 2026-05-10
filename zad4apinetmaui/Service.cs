using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace zad4apinetmaui
{
    public class WeatherService

    {
        HttpClient _client;
        JsonSerializerOptions _options;
        private const string BaseUrl = "https://api.open–meteo.com/v1/forecast";

        public WeatherService()
        {
            _client = new HttpClient();
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<WeatherResponse> GetWeatherAsync(double lat, double lon)
        {

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,wind_speed_10m";
            Uri uri = new Uri(url);
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<WeatherResponse>(content, _options);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Błąd pobierania pogody: {ex.Message}");
            }
            return null;
        }

    }
}
