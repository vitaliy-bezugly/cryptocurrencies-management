using System;
using System.Windows;
using Cryptocurrencies.DesktopUi.Views;

namespace Cryptocurrencies.DesktopUi;

public partial class MainWindow : Window
{
    private readonly CoinsPage _coinsPage;
    private readonly CurrencyPage _currencyPage;
    public MainWindow(CoinsPage coinsPage, CurrencyPage currencyPage)
    {
        _coinsPage = coinsPage;
        _currencyPage = currencyPage;
        
        InitializeComponent();

        Frame.NavigationService.Navigate(coinsPage);
    }

    private void CurrencyPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        Frame.NavigationService.Navigate(_currencyPage);
    }

    private void HomePageButton_OnClick(object sender, RoutedEventArgs e)
    {
        Frame.NavigationService.Navigate(_coinsPage);
    }

    private void ConvertButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}