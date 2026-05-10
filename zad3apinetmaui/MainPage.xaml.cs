using System.Diagnostics;

namespace zad3apinetmaui
{
    public partial class MainPage : ContentPage
    {
        List<string> kody = new List<string> {"usd","eur","gbp","chf"}; 

        public MainPage()
        {
            InitializeComponent();
        }

        async private void OnCounterClicked(object? sender, EventArgs e)
        {
            var currencyService = new CurrencyService();
            Dictionary<string, double> kursy = await currencyService.GetMultipleRatesAsync(kody);
            foreach(var ele in kursy)
            {
                Debug.WriteLine($"{ele.Key}: {ele.Value}");
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
