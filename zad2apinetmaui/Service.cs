using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace zad2apinetmaui
{

    public class CurrencyService
    {
        HttpClient _client;
        JsonSerializerOptions _options;

        private const string BaseUrl = "https://api.nbp.pl/api/exchangerates/rates/a/{0}/?format=json";

        public CurrencyService()
        {
            _client = new HttpClient();
            _options = new JsonSerializerOptions

            {

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<double> GetRateAsync(string Code)

        {
            Uri uri = new Uri(string.Format(BaseUrl, Code.ToLower()));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    var a = JsonSerializer.Deserialize<NbpRateResponse>(content, _options);
                    return a.Rates[0].Mid;
                }
                else
                {
                    Debug.WriteLine($"Błąd API NBP. Kod: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Błąd pobierania kursu: {ex.Message}");
            }
            return 0;
        }
    }
}
