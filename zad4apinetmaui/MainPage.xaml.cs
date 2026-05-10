using System.Diagnostics;
using zad3apinetmaui;

namespace zad4apinetmaui
{
    public partial class MainPage : ContentPage
    {
        List<string> kody = new List<string> { "usd", "eur"};

        public MainPage()
        {
            InitializeComponent();
        }

        async private void OnCounterClicked(object? sender, EventArgs e)
        {

            var currencyService = new CurrencyService();
            var weatherService = new WeatherService();
            WeatherResponse warsaw = await weatherService.GetWeatherAsync(52.23, 21.01);
            Dictionary<string, double> kursy = await currencyService.GetMultipleRatesAsync(kody);
            if (warsaw != null)
            {
                string message = "a";/*$"Warszawa: {warsaw.Current.Temperature}°C |";*/

                foreach (var ele in kursy)
                {
                    message += $"{ele.Key}: {ele.Value}";
                }
                Debug.WriteLine(message);
            }
        }
    }
}
/*
 **********************************************************************
 nazwa          OnCounterClicked
opis            funkcja wyświetlająca informacje w konsoli po kliknięciu przycisku

parametry       object sender, EventArgs e
opis            sender: obiekt wywołujący funkcję , e : Szczegóły dotyczące wywołania funkcji

zwracany typ    brak

***********************************************************************
 */