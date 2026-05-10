using System.Diagnostics;

namespace zad2apinetmaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        async private void OnCounterClicked(object sender, EventArgs e)
        {
            var currencyService = new CurrencyService();

            double euro = await currencyService.GetRateAsync("eur");
            double dollar = await currencyService.GetRateAsync("usd");
            double pound = await currencyService.GetRateAsync("gbp");

            Debug.WriteLine($"euro {euro}");
            Debug.WriteLine($"usd {dollar}");
            Debug.WriteLine($"gbp {pound}");
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
